(function(self,$,_document,_console,_utils,_ui,_chatEngineService,undefined) {
    "use strict";

//    var _$doc;
//    var _$html;
    var _config,
        _roomName,
        _$chat,
        _$messageCountHistory = 100,
        _$connectedUser,
        _$userFullName,
        _$realMessage,
        _$timeSend,
        _loader,
        _$privateChatAlreadInProgress = false,
        _userInPrivateChat = "",
        _domElems,
        _$imagePath,
        _messageCount = 0;

    self.Init = function (config) {
        digestConfig(config);
        listeners();
        initImpl(config);
      
    };

    function digestConfig(config) {
        _config = config;
    };

    function initImpl(config) {
        _domElems = _ui.viewDomElems();

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
                    _domElems.sendMessageBtn.click(onSend);

            })
                .fail(function () {
                    alert(`Error connecting to group : ${_roomName}`);
                    window.location.href = "/Home/Index";
                });

            

        function connectedUsers(users) {
           let chipContainer, linkContainer, container;

           _domElems.onlineUserContainer.remove();
            

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


                _domElems.onlineUserWrapper.append(container);

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
        _$userFullName = message[0];
        _$realMessage = message[1];
        _$timeSend = message[2];

        const timestamp = $.now();

        const userInfo = $("<p/>")
            .addClass("card-text")
            .addClass("d-inline")
            .append(`<strong>&nbsp;&nbsp;${_$userFullName}</strong> : `)
            .append(`<small class="text-muted pull-right">${_$timeSend}</small>`);

        const messageData = $("<p/>")
            .addClass("card-text")
            .addClass("realMessageContent")
            .append(_$realMessage);

        const messageBody = $("<div/>")
            .addClass("card-body")
            .append(`<img src=''  rounded-circle hoverable' alt='User Avatar' id='${timestamp + "img"}'>`)
            .append(userInfo)
            .append(messageData);

        const messageContainer = $("<div/>")
            .addClass("card")
            .addClass("left")
            .prop("Id",timestamp)
            .append(messageBody);


        _domElems.messageList.append(messageContainer);

        const letter = _$userFullName.substring(0, 1);
        _$imagePath = findApropriateImage(letter);

        _messageCount = _messageCount + 1;

        $(`#${timestamp}img`).attr("src", _$imagePath);
        _domElems.userMessageTextArea.val("");

    };


    function onNewMessagePrivate(message) {
        _$userFullName = message[0];
        _$realMessage = message[1];
        _$timeSend = message[2];

        const timestamp = $.now();

        const userInfo = $("<p/>")
            .addClass("card-text")
            .addClass("d-inline")
            .append(`<strong>&nbsp;&nbsp;${_$userFullName}</strong> : `)
            .append(`<small class="text-muted pull-right">${_$timeSend}</small>`);

        const messageData = $("<p/>")
            .addClass("card-text")
            .addClass("realMessageContent")
            .append(_$realMessage);

        const messageBody = $("<div/>")
            .addClass("card-body")
            .append(`<img src=''  rounded-circle hoverable' alt='User Avatar' id='${timestamp + "img"}'>`)
            .append(userInfo)
            .append(messageData);

        const messageContainer = $("<div/>")
            .addClass("card")
            .addClass("left")
            .prop("Id", timestamp)
            .append(messageBody);


        _domElems.messageList.append(messageContainer);



        const letter = user.substring(0, 1);
        _$imagePath = findApropriateImage(letter);

        _messageCount = _messageCount + 1;

        $(`#${timestamp}img`).attr("src", _$imagePath);
       _domElems.userMessageTextArea.val("");
    }

    function onSend() {
        const message = _domElems.userMessageTextArea.val();


        if (message !== null && message.length > 0) {
            //klhsh ths server method gia apostolh se olous tous xrhstes sundedemenous me to room efoson
            //o xrhsths plhkrologhse kati
            (_$privateChatAlreadInProgress) ? 
                _$chat.server.sendMessageToUser(_userInPrivateChat, _domElems.userMessageTextArea.val(), _roomName):
                _$chat.server.sendMessageToRoom(_roomName, _domElems.userMessageTextArea.val());
        }
        else {
            alert("You have to type something first");
        }
        //katharismos tou text area meta apo apostolh munhmatos
        _domElems.userMessageTextArea.val("");
    };

    function initialLoadEffect() {
        _loader = setTimeout(showPage, 1500);
    }

    function showPage() {
        _domElems.chatEngineWrapperContainer.fadeIn(100);
        _domElems.chatEngineLoader.hide();
    }

    function onlineUsers() {
        _$chat.server.connectedUsers();
    }

    function saveUsernameGotFromHub(name) {
        _$connectedUser = name;
        console.log("the name i got form the server is " + name);
    }


    function isInPrivateChat(id) {

        if (id !== _$connectedUser) {
            _$chat.server.privateChat(id);
          
        }
    }

    function showHistory(existing) {
        let userInfo, messageData, messageBody, messageContainer,timestamp;


        if (existing.length <= 0)
            return;
        for (var x = 0, lenght = existing.length; x < lenght; x++) {

             timestamp = `_${Math.random().toString(36).substr(2, 9)}`;;

             userInfo = $("<p/>")
                .addClass("card-text")
                .addClass("d-inline")
                .append(`<strong>&nbsp;&nbsp;${existing[x].UserName}</strong> : `)
                .append(`<small class="text-muted pull-right">${existing[x].TimeSend}</small>`);

             messageData = $("<p/>")
                .addClass("card-text")
                .addClass("realMessageContent")
                .append(existing[x].Message);

             messageBody = $("<div/>")
                .addClass("card-body")
                .append(`<img src=''   rounded-circle hoverable' alt='User Avatar' id='${timestamp + "img"}'>`)
                .append(userInfo)
                .append(messageData);

             messageContainer = $("<div/>")
                .addClass("card")
                //.addClass(alignContentsClass)
                 .addClass("left")
                .prop("Id", timestamp)
                .append(messageBody );


             _domElems.messageList.append(messageContainer);
            const letter = existing[x].UserName.substring(0, 1);
            _$messageCountHistory++;
            const imagePathhistory = findApropriateImage(letter);

            $(`#${timestamp}img`).attr("src", imagePathhistory);

        }       
    }
    function startTime() {
        const today = new Date();
        const h = today.getHours();
        var m = today.getMinutes();
        var s = today.getSeconds();
        m = checkTime(m);
        s = checkTime(s);

        $("#dateValue").text(h + ":" + m + ":" + s);;
        setTimeout(startTime, 500);
    }
    function checkTime(i) {
        if (i < 10) { i = `0${i}` };  // add zero in front of numbers < 10
        return i;
    }

    function fillModalBodyWithRoomDetails() {

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
                const ulListOnlineUsers = $(this).parents("ul").children();
                const isTheSameUser = false;

                //check to see if there is a private discussion already
                $.each(ulListOnlineUsers,
                    function (i, x) {
                        if ($(x).hasClass("privateMessage")) {
                            _$privateChatAlreadInProgress = true;
                            return false;
                        }
                        return false;
                    });

                //check if not the same user is clicked
                if (_$connectedUser !== $(this).attr("id")) {
                    if (!_$privateChatAlreadInProgress) {
                        $(this).parent("li").toggleClass("privateMessage");
                        _userInPrivateChat = $(this).attr("id");

                    }
                }


              

            });
            $("#searchOnlineUsers input").on("keyup", filterOnlineUsers);
            
        });
    }


    function filterOnlineUsers(event) {
        const filter = $(event.target).val();
        $("#cancelIconFilter").css("display", "block");

    
      



    }

}(window.ChatEngineController = window.ChatEngineController || {}, jQuery, document, console, UtilsController,ChatEngineUiController,ChatEngineService));