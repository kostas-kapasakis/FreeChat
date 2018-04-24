(function(self,$,_document,_console,_utils,_chatEngineService,undefined) {
    "use strict";

    var _$doc;
    var _$html;
    var _config;
    var _roomName;
    var _$chat;
    var messageCountHistory = 100;//
    var connectedUser;
    var userFullName;
    var realMessage;
    var timeSend;
    var _loader;
    var _$privateChatAlreadInProgress = false;
    var _userInPrivateChat="";
    //chat room name sto opoio sundethike o xrhsths

    var imagePath;

    //metavlhth gia to connection


    var messageCount = 0;


    self.Init = function (config) {
        digestConfig(config);
        listeners();

        initImpl(config);
      
    };

    function digestConfig(config) {
        _config = config;
    };

    function initImpl(config) {
        $(document).ready(function () {
            initialLoadEffect();
        });
       
        $(".content-wrapper").addClass("chatEngineMode");
        $("#sidenavToggler").trigger("click");

        _roomName = config.RoomName;
     
           

            // Declare a proxy to reference the hub.
            _$chat = $.connection.chat;

            //energopoihsh tou hub logging
             $.connection.hub.logging = true;

            _$chat.client.newMessage = onNewMessage;

            _$chat.client.newMessagePrivate = onNewMessagePrivate;

            _$chat.client.onlineUsers = connectedUsers;

            _$chat.client.loadHistory = showHistory;

            _$chat.client.sendName = saveUsernameGotFromHub;

            _$chat.client.private = isInPrivateChat;

            //start the connection // Start Hub
            $.connection.hub.start().done(function () {

                    _$chat.server.joinRoom(_roomName);
                    _$chat.server.sendUsername();
                    _$chat.server.sendRoomConnectedUsers(_roomName);
                    _$chat.server.sendSavedRoomMessages(_roomName);
                    $("#send").click(onSend);

            })
                .fail(function () {
                    alert("Error connecting to group : " + _roomName);
                    window.location.href = '/Home/Index';
                });

            

        function connectedUsers(users) {
           let chipContainer, linkContainer, container;
           const usersContainer = $("#card-body-online");

            $("#list-onlineUsers").empty();
            

            for (var x = 0, leng = users.length; x < leng; x++) {
                chipContainer = $("<div/>")
                    .addClass("chip")
                    .addClass("chip-lg")
                    .append(
                    "<img src='https://mdbootstrap.com/img/Photos/Avatars/avatar-10.jpg' class='hoverable' alt='Contact Person'>" + users[x].toString());


                linkContainer = $("<a/>")
                    .addClass("list-group-item-light")
                    .append(chipContainer);

                container = $("<div/>")
                    .addClass("onlineUserActualPart")
                    .prop("Id", users[x])
                    .append(linkContainer);


                usersContainer.append(container);

             }
            }

        $.connection.hub.error(function (err) {
            alert(`An error occured: ${err}`);

        });
       
    }

    function leaveRoom() {
        _$chat.server.leaveRoom(_roomName);
        _$chat.server.sendRoomConnectedUsers(_roomName);
        window.location.href = "/Home/AllChatRooms";
    } 




    function onNewMessage(message) {
        userFullName = message[0];
        realMessage = message[1];
        timeSend = message[2];

        const sameUser = userFullName === connectedUser ? true : false;

        const pullClass = sameUser ? "pull-right" : "pull-left";
        const alignContentsClass = sameUser ? "left" : "right";

        const timestamp = $.now();

        const messageList = $(".inner-list");

        const userInfo = $("<p/>")
            .addClass("card-text")
            .addClass("d-inline")
            .append(`<strong>&nbsp;&nbsp;${userFullName}</strong> : `)
            .append(`<small class="text-muted ${pullClass}">${timeSend}</small>`);

        const messageData = $("<p/>")
            .addClass("card-text")
            .addClass("realMessageContent")
            .append(realMessage);

        const messageBody = $("<div/>")
            .addClass("card-body")
            .append(`<img src='' class='${sameUser ? "" : "right"}' alt='User Avatar' id='${timestamp + "img"}'>` )
            .append(userInfo)
            .append(messageData);

        const messageContainer = $("<div/>")
            .addClass("card")
            .addClass(alignContentsClass)
            .prop("Id",timestamp)
            .append(messageBody);


        messageList.append(messageContainer);

        let letter = userFullName.substring(0, 1);
        imagePath = findApropriateImage(letter);

        messageCount = messageCount + 1;

        $(`#${timestamp}img`).attr("src", imagePath);
        $("#messageTyped").val("");

    };


    function onNewMessagePrivate(message) {
        userFullName = message[0];
        realMessage = message[1];
        timeSend = message[2];
        var user = message[0].substring(0, 4);

       

        //if the message sender is the current user then the message displays to the right otherwise to the left
        if (userFullName.substring(0, 4) !== connectedUser.substring(0, 4)) {
            //if()

            $(".inner-list").append(
                "<li class='left clearfix' id ='" + user + messageCount + "nm" + "'> " +
                "<div class='messageContainer'>" +
                "<img src='' alt='Avatar' id='" + user + messageCount + "img" + "'>" +
                "<p>" + realMessage + "</p>" +
                "<span class='time-right'>" + timeSend + "</span>" +
                "</div></li>");
        } else {
            $(".inner-list").append(
                "<li class='right clearfix' id ='" + user + messageCount + "nm" + "'> " +
                "<div class='messageContainer sameUsername'>" +
                "<img src='' alt='Avatar' class='right'  id='" + user + messageCount + "img" + "'>" +
                "<p>" + realMessage + "</p>" +
                "<span class='time-left'>" + timeSend + "</span>" +
                "</div></li>");
        }

        var letter = user.substring(0, 1);
        imagePath = findApropriateImage(letter);
        var selectorForImg = "#" + user + messageCount + "img";

        messageCount = messageCount + 1;

        $(selectorForImg).attr("src", imagePath);
        $("#messageTyped").val("");
    }

    function onSend() {



        var message = $("#messageTyped").val();


        if (message !== null && message.length > 0) {
            //klhsh ths server method gia apostolh se olous tous xrhstes sundedemenous me to room efoson
            //o xrhsths plhkrologhse kati
            (_$privateChatAlreadInProgress) ? 
           _$chat.server.sendMessageToUser(_userInPrivateChat,$('#messageTyped').val(), _roomName):
           _$chat.server.sendMessageToRoom(_roomName, $('#messageTyped').val());
        }
        else {
            alert("You have to type something first");
        }

        //katharismos tou text area meta apo apostolh munhmatos
        $("#messageTyped").text("");


    };

    function initialLoadEffect() {
        _loader = setTimeout(showPage, 1500);
    }
    function showPage() {
        $("#ChatEngineContainer").fadeIn(100);
        $("#loader").hide();
    }

    function onlineUsers() {
        _$chat.server.connectedUsers();
    }

    function saveUsernameGotFromHub(name) {
        connectedUser = name;
        console.log("the name i got form the server is " + name);
    }


    function isInPrivateChat(id) {

        if (id !== connectedUser) {
            _$chat.server.privateChat(id);
          
        }


    }

    function showHistory(existing) {

        if (existing.length <= 0)
            return;

       
        for (var i = 0, len = existing.length; i < len; i++) {
            if (existing[i].UserName.substring(0, 4) !== connectedUser.substring(0, 4)) {
                   $(".inner-list").append(
                    "<li class='left clearfix' id ='" + existing[i].UserName.substring(0, 4) + messageCountHistory + "nm" + "'> " +
                    "<div class='messageContainer'>"+
                    "<img src='' alt='Avatar' id='" + existing[i].UserName.substring(0, 4) + messageCountHistory + "img" + "'>" +
                    '<p class="real_message">' + "<h5 class='chatRealUsername'>" + existing[i].UserName + "</h5>" + " : " + "<h4 class='chatRealMessage'>" + existing[i].Message + '</h4></p>' +
                    "<span class='time-right'>" + existing[i].TimeSend +"</span>"+
                    "</div></li>");
            } else {

                $(".inner-list").append(
                    "<li class='right clearfix' id ='" + existing[i].UserName.substring(0, 4) + messageCountHistory + "nm" + "'> " +
                    "<div class='messageContainer sameUsername'>" +
                    "<img src='' alt='Avatar' class='right'  id='" + existing[i].UserName.substring(0, 4) + messageCountHistory + "img" + "'>" +
                    '<p class="real_message">' + "<h5 class='chatRealUsername'>" + existing[i].UserName + "</h5>" + " : " + "<h4 class='chatRealMessage'>" + existing[i].Message + '</h4></p>' +
                    "<span class='time-left'>" + existing[i].TimeSend + "</span>" +
                    "</div></li>");
        
            }
            var letter = existing[i].UserName.substring(0, 1);
            var selector = "#" + existing[i].UserName.substring(0, 4) + messageCountHistory + "img";
            messageCountHistory++;
            var imagePathhistory = findApropriateImage(letter);
            $(selector).attr("src", imagePathhistory );

          

        }
    }
    function startTime() {
        var today = new Date();
        var h = today.getHours();
        var m = today.getMinutes();
        var s = today.getSeconds();
        m = checkTime(m);
        s = checkTime(s);

        $("#dateValue").text(h + ":" + m + ":" + s);;
        var t = setTimeout(startTime, 500);
    }
    function checkTime(i) {
        if (i < 10) { i = "0" + i };  // add zero in front of numbers < 10
        return i;
    }

    function fillModalBodyWithRoomDetails() {
        var currentDate = new Date().toLocaleString();
        var resArray = startTime();
      
        

    }


    function findApropriateImage(letter) {
        var imagePath;

        switch (letter) {
            case "a":
            case "A":
                imagePath = "/Content/images/letters/Letter-A-blue-icon.png";
                break;

            case "b":
            case "B":
                imagePath = "/Content/images/letters/Letter-K-blue-icon.png";
                break;
            case "c":
            case "C":
                imagePath = "/Content/images/letters/Letter-K-blue-icon.png";
                break;
            case "d":
            case "D":
                imagePath = "/Content/images/letters/Letter-K-blue-icon.png";
                break;
            case "e":
            case "E":
                imagePath = "/Content/images/letters/Letter-K-blue-icon.png";
                break;
            case "f":
            case "F":
                imagePath = "/Content/images/letters/Letter-K-blue-icon.png";
                break;
            case "g":
            case "G":
                imagePath = "/Content/images/letters/Letter-K-blue-icon.png";
                break;
            case "h":
            case "H":
                imagePath = "/Content/images/letters/Letter-K-blue-icon.png";
                break;
            case "i":
            case "I":
                imagePath = "/Content/images/letters/Letter-K-blue-icon.png";
                break;
            case "j":
            case "J":
                imagePath = "/Content/images/letters/Letter-K-blue-icon.png";
                break;
            case "k":
            case "K":
                imagePath = "/Content/images/letters/Letter-K-blue-icon.png";
                break;
            case "l":
            case "L":
                imagePath = "/Content/images/letters/Letter-K-blue-icon.png";
                break;
            case "m":
            case "M":
                imagePath = "/Content/images/letters/Letter-K-blue-icon.png";
                break;
            case "n":
            case "N":
                imagePath = "/Content/images/letters/Letter-K-blue-icon.png";
                break;
            case "o":
            case "O":
                imagePath = "/Content/images/letters/Letter-K-blue-icon.png";
                break;
            case "p":
            case "P":
                imagePath = "/Content/images/letters/Letter-K-blue-icon.png";
                break;
            case "q":
            case "Q":
                imagePath = "/Content/images/letters/Letter-K-blue-icon.png";
                break;
            case "r":
            case "R":
                imagePath = "/Content/images/letters/Letter-K-blue-icon.png";
                break;
            case "s":
            case "S":
                imagePath = "/Content/images/letters/Letter-K-blue-icon.png";
                break;
            case "t":
            case "T":
                imagePath = "/Content/images/letters/Letter-T-blue-icon.png";
                break;
            case "u":
            case "U":
                imagePath = "/Content/images/letters/Letter-K-blue-icon.png";
                break;
            case "x":
            case "X":
                imagePath = "/Content/images/letters/Letter-K-blue-icon.png";
                break;
            case "y":
            case "Y":
                imagePath = "/Content/images/letters/Letter-K-blue-icon.png";
                break;
            case "z":
            case "Z":
                imagePath = "/Content/images/letters/Letter-K-blue-icon.png";
                break;

            default:
                console.log("Usernmame doesnt belong in any category");
                imagePath = "/Content/images/letters/Letter-K-blue-icon.png";
        }
        return imagePath;
    }

    function listeners() {
        $(document).ready(function () {
            $("#modalInitializerBtn").click(fillModalBodyWithRoomDetails);


            $("#leaveRoomBtn").click(leaveRoom);
              
            $("#logoff").click(leaveRoom);

            $(document).on("click", ".onlineUser", function () {
                var ulListOnlineUsers = $(this).parents("ul").children();
                var isTheSameUser = false;

                //check to see if there is a private discussion already
                $.each(ulListOnlineUsers,
                    function (i, x) {
                        if ($(x).hasClass("privateMessage")) {
                            _$privateChatAlreadInProgress = true;
                            return false;
                        }   
                    });

                //check if not the same user is clicked
                if (connectedUser !== $(this).attr("id")) {
                    if (!_$privateChatAlreadInProgress) {
                        $(this).parent("li").toggleClass("privateMessage");
                        _userInPrivateChat = $(this).attr("id");

                    }
                } 
              
                   



            });

            
        });
    }

}(window.ChatEngineController = window.ChatEngineController || {},jQuery,document,console,UtilsController,ChatEngineService));