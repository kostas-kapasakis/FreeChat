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
        _onlineUsersOptions,
        _$imagePath,
        _messageCount = 0;

    self.Init = function (config) {
  
        digestConfig(config);
        listeners();
        initImpl(config);
        _domElems = _ui.viewDomElems();
        _onlineUsersOptions = _ui.onlineUsersOptions();
    };

    function digestConfig(config) {
        _config = config;
    };

    function initImpl(config) {
        $.when(
            $("#sidenavToggler").trigger("click"),
            $(".content-wrapper").addClass("chatEngineMode")
            
           
        ).then(function() {
            initialLoadEffect();
        }).done(function() {

            $(document).ready(function () {
                _domElems.fullchatmodeBtn.show(300);
                $('.modal').on('show.bs.modal',
                    function() {
                        if ($(document).height() > $(window).height()) {
                            // no-scroll
                            $('body').addClass("modal-open-noscroll");
                        } else {
                            $('body').removeClass("modal-open-noscroll");
                        }
                    });
                $('.modal').on('hide.bs.modal',
                    function() {
                        $('body').removeClass("modal-open-noscroll");
                    });
            });


            _roomName = config.RoomName;


            // Declare a proxy to reference the hub.
            _$chat = $.connection.chat;

            //energopoihsh tou hub logging
            $.connection.hub.logging = true;

            _$chat.client.newMessage = displayNewMessage;

            _$chat.client.newMessagePrivate = displayPrivateMessage;

            _$chat.client.onlineUsers = displayConnectedUsersInRoom;

            _$chat.client.onlineUsersUpdate = onlineUsersUpdate;

            _$chat.client.loadHistory = displayRoomMessagesHistory;

            _$chat.client.sendName = saveUsernameGotFromHub;

            _$chat.client.private = isInPrivateChat;

            //start the connection // Start Hub
            $.connection.hub.start().done(function() {

                    _$chat.server.joinRoom(_roomName);
                    _$chat.server.sendUsername();

                    clearTheOnlineUsersList();
                    _$chat.server.sendRoomConnectedUsers(_roomName, _onlineUsersOptions.initialSeeding);
                    _$chat.server.sendSavedRoomMessages(_roomName);
                    _domElems.sendMessageBtn.click(broadcastMessage);

                })
                .fail(function() {
                    alert(`Error connecting to group : ${_roomName}`);
                    window.location.href = "/Home/Index";
                });


            $.connection.hub.error(function(err) {
                alert(`An error occured: ${err}`);

            });
        });


    }

    function listeners() {
        $(document).ready(function () {
            _domElems.filterSearchBarinput.on("keyup", filterOnlineUsers);
            _domElems.cancelFilterBtn.on("click", cancelFilterBtnClicked);
            _domElems.exitRoomBtn.click(leaveRoom);
            _domElems.roomDetailsModalInit.click(fillModalBodyWithRoomDetails);
            _domElems.fullchatmodeBtn.on("click", fullchatModeToggle);
        });
    }

    function fullchatModeToggle() {
        const viewportWidth = $(window).width();

        if (_domElems.chatEngineContentWrapper.hasClass("fullModeOpened")) {
            _domElems.chatEngineContentWrapper.toggleClass("fullModeOpened");

            $("#nav-topMenu").slideDown("fast");
            $("#mainNav .navbar-brand").slideDown("fast");
            _domElems.chatEngineContentWrapper.css("margin-top", "0");
            _domElems.chatEngineContentWrapper.css("min-height", "89%");
            $("#leftNavBar").css("margin-top", "50px");

            switch (true) {
            case viewportWidth <= 1366:
                $("#chatEngineMiddle").css("min-height", "400px");
                $("#messagesContainerArea").css("min-height", "400px");
                break;
            case viewportWidth > 1366:
                $("#chatEngineMiddle").css("min-height", "600px");
                $("#messagesContainerArea").css("min-height", "600px");
                break;
            default:
                console.log("not supported viewport yet for full chat mode");
            }

        } else {
            _domElems.chatEngineContentWrapper.toggleClass("fullModeOpened");
           

            $("#nav-topMenu").slideUp("fast");
            $("#mainNav .navbar-brand").slideUp("fast");
            _domElems.chatEngineContentWrapper.css("margin-top", "-50px");
            _domElems.chatEngineContentWrapper.css("min-height", "95%");
            $("#leftNavBar").css("margin-top", "0px");

            switch (true) {
            case viewportWidth <= 1366:
                $("#chatEngineMiddle").css("min-height", "550px");
                $("#messagesContainerArea").css("min-height", "550px");
                break;
            case viewportWidth > 1366:
                $("#chatEngineMiddle").css("min-height", "850px");
                $("#messagesContainerArea").css("min-height", "850px");
                break;
            default:
                console.log("not supported viewport yet for full chat mode");
            }
        }

      
    
     
       
    }
//
//    function headerTableClicked(event) {
//        const target = $(event.target);
//        if (!target.is("button")) {
//            $(this).slideToggle(300);
//            $("#chatEngineMiddle").css("height", "530px");
//        }
//    }


    function clearTheOnlineUsersList() {
        const elems = _domElems.onlineUserContainer();
        $.each(elems, function (obj) { $(obj).remove(); });
        $(".onlineUserActualPart").remove();
    }

    function displayConnectedUsersInRoom(users) {
        let chipContainer, linkContainer, container;
        clearTheOnlineUsersList();

        for (var x = 0, leng = users.length; x < leng; x++) {
            chipContainer = $("<div/>")
                .addClass("chip")
                .addClass("chip-lg")
                .append(
                    `<img src='https://mdbootstrap.com/img/Photos/Avatars/avatar-10.jpg' class='hoverable' alt='Contact Person'>${users[x].toString()}`);


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

    function leaveRoom() {
        bootbox.confirm(`Leave Room : ${_roomName} ?`,
            function (result) {
                if (result) {               
                    _$chat.server.leaveRoom(_roomName);
                    _$chat.server.sendRoomConnectedUsers(_roomName, _onlineUsersOptions.initialSeeding);//todo must be update
                    window.location.href = "/Home/AllChatRooms";                   
                }
            });
      
    } 

    function displayNewMessage(message) {
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

    function displayPrivateMessage(message) {
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

    function broadcastMessage() {
        const message = _domElems.userMessageTextArea.val();


        if (message !== null && message.length > 0) {
            (_$privateChatAlreadInProgress) ? 
                _$chat.server.sendMessageToUser(_userInPrivateChat, _domElems.userMessageTextArea.val(), _roomName):
                _$chat.server.sendMessageToRoom(_roomName, _domElems.userMessageTextArea.val());
        }
        else {
            alert("You have to type something first");
        }
        _domElems.userMessageTextArea.val("");
    };

    function initialLoadEffect() {
        _loader = setTimeout(showPage, 1500);
    }

    function showPage() {
        _domElems.chatEngineWrapperContainer.fadeIn(100);
        _domElems.chatEngineLoader.hide();
    }

    function onlineUsersUpdate(usersArray) {
        clearTheOnlineUsersList();
        displayConnectedUsersInRoom(usersArray);
    }

    function saveUsernameGotFromHub(name) {
        _$connectedUser = name;
    }

    function isInPrivateChat(id) {

        if (id !== _$connectedUser) {
            _$chat.server.privateChat(id);
          
        }
    }

    function displayRoomMessagesHistory(existing) {
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

        _domElems.timeContainer.text(`Current Time : ${h}:${m}:${s}`);;
        setTimeout(startTime, 500);
    }

    function checkTime(i) {
        if (i < 10) { i = `0${i}` };  // add zero in front of numbers < 10
        return i;
    }

    function fillModalBodyWithRoomDetails() {
        startTime();
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

    function filterOnlineUsers(event) {
        const filter = $(event.target).val().toUpperCase();
        const connectedUsers = _domElems.onlineUserContainer();

       _domElems.cancelFilterBtn.css("display", "block");
       
        $.each(connectedUsers,
            function (index, user) {
                const username = $(user).find("div.chip").text().toUpperCase();
                if (username.indexOf(filter) > -1) {
                    $(user).fadeIn(250);
                } else {
                    $(user).fadeOut(250);
                } 
            });
       
    }

    function cancelFilterBtnClicked() {
        _domElems.filterSearchBarinput.val(""); 
        _domElems.cancelFilterBtn.fadeOut(300);
        _$chat.server.sendRoomConnectedUsers(_roomName, _onlineUsersOptions.update);
    }

}(window.ChatEngineController = window.ChatEngineController || {}, jQuery, document, console, UtilsController,ChatEngineUiController,ChatEngineService));