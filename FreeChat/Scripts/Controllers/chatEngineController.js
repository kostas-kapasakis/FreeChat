(function(self,$,_document,_console,_chatEngineService,undefined) {
    "use strict";

    var _$doc;
    var _$html;
    var _config;

    self.Init = function (config) {
        digestConfig(config);
        initImpl(config);
    };

    function digestConfig(config) {
        _config = config;
    };

    function initImpl(config) {


        var connectedUser;
        var userFullName;
        var realMessage;
        var timeSend;
        //chat room name sto opoio sundethike o xrhsths

        var imagePath;

        //metavlhth gia to connection
        var chat;

        var messageCount = 0;
        var messageCountHistory = 0;
        //1)metavlhth gia thn hmeromhnia panw aristera
        //2)topothethsh shmerinhs hmeromhnias sto top container

        var d = new Date();

        $("#date").append("<p>" + d.toDateString() + "</p>");







        $(function () {




            // Declare a proxy to reference the hub.
            chat = $.connection.chat;

            //energopoihsh tou hub logging
            $.connection.hub.logging = true;

            chat.client.newMessage = onNewMessage;

            chat.client.onlineUsers = connectedUsers;

            chat.client.loadHistory = showHistory;

            chat.client.sendName = saveUsernameGotFromHub;

            chat.client.private = isInPrivateChat;

            //start the connection // Start Hub
            $.connection.hub.start().done(function () {





                chat.server.joinRoom(roomName);
                chat.server.sendUsername();
                chat.server.sendRoomConnectedUsers(roomName);
                chat.server.sendSavedRoomMessages(roomName);
                $('#send').click(onSend);



            })
                .fail(function () {
                    alert("Error connecting to group : " + roomName);
                    window.location.href = '/Home/Index';
                });

            $('#leaveRoom').click(leaveRoom);
            $('#logoff').click(leaveRoom);

            $(document).on("click", ".onlineUser", function () {
                isInPrivateChat($(this).attr('id'));
            });

        });

        function onNewMessage(message) {

            var d = new Date();
            d.toLocaleTimeString()
            userFullName = message[0];
            realMessage = message[1];






            var user = message[0].substring(0, 4);


            //if the message sender is the current user then the message displays to the right otherwise to the left
            if (userFullName.substring(0, 4) !== username) {
                //if()
                $('.inner-list').append("<li class='left clearfix' id ='" + user + messageCount + "nm" + "'> " +
                    " <span class='chat-img1 pull-left' id='" + user + messageCount + "img" + "'></span>" +
                    '<div class="chat-body1 clearfix">' +
                    '<p class="real_message">' + "<h5 class='chatRealUsername'>" + userFullName + "</h5>" + " : " + "<h4 class='chatRealMessage'>" + realMessage + '</h4></p>' +
                    '<div class="chat_time pull-right">' + d.toLocaleTimeString() + '</div>' +
                    ' </div>' +
                    '</li>');
            } else {
                $('.inner-list').append("<li class='left clearfix admin_chat' id ='" + user + messageCount + "nm" + "'> " +
                    "<span class='chat-img1 pull-right'id='" + user + messageCount + "img" + "'></span>" +
                    '<div class="chat-body1 clearfix">' +
                    '<p class="real_message">' + "<h4 class='chatRealMessage'>" + realMessage + '</h4></p>' +
                    '<div class="chat_time pull-left">' + d.toLocaleTimeString() + '</div>' +
                    ' </div>' +
                    '</li>');
            }
            //if it isnt the first message in the chat area
            //take the previous li sibling
            //take his second children which must be the username of the previous message sender 

            /* if (messageCount > 0) {
                 var sibling = document.getElementById(user + (messageCount-1) + "nm").children[1];
        
                 var usernameFrPreMessage = sibling.children[1].innerHTML;
                 console.log("sibling " + sibling);
                 console.log("h5selector " + usernameFrPreMessage);
        
                 
             }*/

            var letter = user.substring(0, 1);
            imagePath = findApropriateImage(letter);
            var selectorForImg = "#" + user + messageCount + "img";

            messageCount = messageCount + 1;

            $(selectorForImg).append("<img src='" + imagePath + "' alt='User Avatar' class='img-circle' />");

        };


        function leaveRoom() {
            chat.server.leaveRoom(roomName);
            chat.server.sendRoomConnectedUsers(roomName);
            //$('.list-unstyled').empty();
            window.location.href = '/Home/Index';


        }


        function connectedUsers(users) {

            $('.list-unstyled').empty();

            for (var i = 0, len = users.length; i < len; i++) {

                $(".list-unstyled").append("<li class ='online' id=" + users[i].substring(0, 4) + "ou" + "><div class ='onlineUser' id=" + users[i] + " >" +
                    " <center><strong class='primary-font'>" + users[i]
                    + "</strong><img src='/Content/images/privateMessage.png' id='privateMessageIcon' onmouseover='this.width=40px; this.height=40px;' onmouseout='this.width=30px; this.height=30px;'/></center></div></li>");
            }



        }
        function onSend() {
            var message = $('#messageTyped').val();
            if (message !== null && message.length > 0) {
                //klhsh ths server method gia apostolh se olous tous xrhstes sundedemenous me to room efoson
                //o xrhsths plhkrologhse kati

                chat.server.sendMessageToRoom(roomName, $('#messageTyped').val());
            }
            else {

                alert("You have to type something first");

            }

            //katharismos tou text area meta apo apostolh munhmatos
            document.getElementById('messageTyped').value = "";

            //krataw to div sunexws se scroll bottom wste na fainontai ta kainourgia munhmata
            $(".chat_area").scrollTop($(".chat_area")[0].scrollHeight);


        };



        $.connection.hub.error(function (err) {
            alert("An error occured: " + err);

        });

        function onlineUsers() {
            chat.server.connectedUsers()
        }

        function saveUsernameGotFromHub(name) {
            connectedUser = name;
        }


        function isInPrivateChat(id) {

            if (id !== connectedUser) {
                chat.server.privateChat(id);
                createTabsForPrivate(id);
            }


        }

        function createTabsForPrivate(name) {
            var selector = "#" + name.substring(0, 4) + "ou";
            console.log(selector.toString());
            $(selector).css("background-color", "#e6ffff");

        }




        function showHistory(existing) {

            for (var i = 0, len = existing.length; i < len; i++) {
                if (existing[i].UserName.substring(0, 4) !== username) {
                    $('.inner-list').append("<li class='left clearfix'> " +
                        " <span class='chat-img1 pull-left' id=" + existing[i].UserName.substring(0, 4) + messageCountHistory + "></span>" +
                        '<div class="chat-body1 clearfix">' +
                        '<p class="real_message">' + "<h5 class='chatRealUsername'>" + existing[i].UserName + "</h5>" + " : " + "<h4 class='chatRealMessage'>" + existing[i].Message + '</h4></p>' +
                        '<div class="chat_time pull-right">' + existing[i].timeSend + '</div>' +
                        ' </div>' +
                        '</li>');
                } else {
                    $('.inner-list').append("<li class='left clearfix admin_chat'>" +
                        "<span class='chat-img1 pull-right'id=" + existing[i].UserName.substring(0, 4) + messageCountHistory + "></span>" +
                        '<div class="chat-body1 clearfix">' +
                        '<p class="real_message">' + "<h4 class='chatRealMessage'>" + existing[i].Message + '</h4></p>' +
                        '<div class="chat_time pull-left">' + existing[i].timeSend + '</div>' +
                        ' </div>' +
                        '</li>');
                }
                var letter = existing[i].UserName.substring(0, 1);
                var selector = "#" + existing[i].UserName.substring(0, 4) + messageCountHistory;
                messageCountHistory++;
                var imagePathhistory = findApropriateImage(letter);
                $(selector).append("<img src='" + imagePathhistory + "' alt='User Avatar' class='img-circle' />");



            }
        }



        function findApropriateImage(letter) {
            var imagePath;

            switch (letter) {
                case "a":
                    imagePath = "/Content/images/letters/Letter-A-blue-icon.png";
                    break;

                case "b":
                    imagePath = "/Content/images/letters/Letter-K-blue-icon.png";
                    break;
                case "c":
                    imagePath = "/Content/images/letters/Letter-K-blue-icon.png";
                    break;
                case "d":
                    imagePath = "/Content/images/letters/Letter-K-blue-icon.png";
                    break;
                case "e":
                    imagePath = "/Content/images/letters/Letter-K-blue-icon.png";
                    break;
                case "f":
                    imagePath = "/Content/images/letters/Letter-K-blue-icon.png";
                    break;
                case "g":
                    imagePath = "/Content/images/letters/Letter-K-blue-icon.png";
                    break;
                case "h":
                    imagePath = "/Content/images/letters/Letter-K-blue-icon.png";
                    break;
                case "i":
                    imagePath = "/Content/images/letters/Letter-K-blue-icon.png";
                    break;
                case "j":
                    imagePath = "/Content/images/letters/Letter-K-blue-icon.png";
                    break;
                case "k":
                    imagePath = "/Content/images/letters/Letter-K-blue-icon.png";
                    break;
                case "l":
                    imagePath = "/Content/images/letters/Letter-K-blue-icon.png";
                    break;
                case "m":
                    imagePath = "/Content/images/letters/Letter-K-blue-icon.png";
                    break;
                case "n":
                    imagePath = "/Content/images/letters/Letter-K-blue-icon.png";
                    break;
                case "o":
                    imagePath = "/Content/images/letters/Letter-K-blue-icon.png";
                    break;
                case "p":
                    imagePath = "/Content/images/letters/Letter-K-blue-icon.png";
                    break;
                case "q":
                    imagePath = "/Content/images/letters/Letter-K-blue-icon.png";
                    break;
                case "r":
                    imagePath = "/Content/images/letters/Letter-K-blue-icon.png";
                    break;
                case "s":
                    imagePath = "/Content/images/letters/Letter-K-blue-icon.png";
                    break;
                case "t":
                    imagePath = "/Content/images/letters/Letter-T-blue-icon.png";
                    break;
                case "u":
                    imagePath = "/Content/images/letters/Letter-K-blue-icon.png";
                    break;
                case "x":
                    imagePath = "/Content/images/letters/Letter-K-blue-icon.png";
                    break;
                case "y":
                    imagePath = "/Content/images/letters/Letter-K-blue-icon.png";
                    break;
                case "z":
                    imagePath = "/Content/images/letters/Letter-K-blue-icon.png";
                    break;

                default:
                    console.log("Usernmame doesnt belong in any category");
            }
            return imagePath;
        }

    }



}(window.ChatEngineController = window.ChatEngineController || {},jQuery,document,console,ChatEngineService));