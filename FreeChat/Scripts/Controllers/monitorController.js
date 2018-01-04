(function() {
    var monitor;

    $(function () {

        monitor = $.connection.monitor;
        //monitoring about who connected who disconnected
        monitor.client.newEvent = onNewEvent;
        //update usersInRoom and Rooms Active at IndexView
        monitor.client.updateOnlineUsersInRooms = updateUsersInRoom;
        //update online users at index View
        monitor.client.updateOnlineUsers = updateUsers;

        $.connection.hub.start().done(function () {
            //start hub logging
            $.connection.hub.logging = true;
            //call registerd users that will notify all clients by executing updateUsers
            monitor.server.registeredUsersOnline();
        })

            .fail(function () {

                alert("Error connecting to monitor ");

            });
    });
    function onNewEvent(eventType, client, users) {
        $('#monitorUl').append('<li>' + eventType + ' from' + client + '</li>');
    };
    function updateUsers(howmany) {
        $('#usersOnline').html(howmany);
    }


    function updateUsersInRoom(onlineUsers, roomsActive) {
        if (onlineUsers != null && onlineUsers != undefined) {
            $('#usersInRooms').html(onlineUsers);
        }
        else {
            onlineUsers = 0;
            $('#usersInRooms').html(onlineUsers);
        }
        if (roomsActive != null && roomsActive != undefined) {
            $('#roomsActive').html(roomsActive);
        } else {
            roomsActive = 0;
            $('#roomsActive').html(roomsActive);
        }
        /*
        thelei users san parametro for (var i = 0, len = users.length; i < len; i++) {
            $('#ullist').append("<li>" + users[i] + "</li>");
        }*/
    }

    function loadchatrooms(id) {
        $("#chatrooms").hide();

        if (id.toString() == "musicChatRooms") {

            //$("#musicChatRoomsdiv").load('Url.Action("chatmusic", "Home")');
            $('#allrooms').fadeIn();
            $("#sportsChatRoomsdiv").hide();
            $("#tripsChatRoomsdiv").hide();
            $("#musicChatRoomsdiv").fadeIn();
        }
        else if (id.toString() == "sportsChatRooms") {
            $('#allrooms').fadeIn();
            //$("#sportsChatRoomsdiv").load("Url.Action("chatsports", "Home")) ");
            $("#tripsChatRoomsdiv").hide();
            $("#musicChatRoomsdiv").hide();
            $("#sportsChatRoomsdiv").fadeIn();
        } else {
            $('#allrooms').fadeIn();
            //$("#tripsChatRoomsdiv").load("Url.Action("chattrips", "Home")) ");
            $("#musicChatRoomsdiv").hide();
            $("#sportsChatRoomsdiv").hide();
            $("#tripsChatRoomsdiv").fadeIn();
        }

    }
    function loadAllrooms() {
        $("#musicChatRoomsdiv").hide();
        $("#sportsChatRoomsdiv").hide();
        $("#tripsChatRoomsdiv").hide();

        $('#allrooms').fadeOut();
        $("#chatrooms").fadeIn();
    }
}());