(function (self, $, _document, _console, _indexService, undefined) {
    "use strict";

    var $doc;
    var $html;
    var $config;
    var $table;
    var $userCreator;

    self.Init = function (config) {
        digestConfig(config);
        initImpl(config);
        listeners();
    };

    function digestConfig(config) {
        $config = config;
    };

    function initImpl(config) {
        $table = $("#allChatRoomsAdmin").DataTable({
            ajax: {
                url: "/api/RoomList/GetTopicsFull",
                dataSrc: ""
            },
            columns: [
                {
                    data: "Name"
                },
                {
                    data: "Genre"
                },
                {
                    data: "Description"
                },
                {
                    data: "DateExpired",
                    render: function (data) {
                        var dateString = data;
                        var yearDate = dateString.substring(0, dateString.indexOf("T"));
                        var time = dateString.substring(dateString.indexOf("T") + 1, dateString.length - 4);
                        return yearDate + "  " + time;
                    }

                },
                {
                    data: "UserCreatorId",
                    render: function (data, type, room) {
                    
                        return "<button class='btn btn-default userBtn' id='" + data + "' data-toggle='modal' data-target='#usersModal'>User</button>";
                    }
                },
                {
                    data: "Id",
                    render: function (data, type, room) {
                        if (room.Active) {
                            return `<button class='btn-link js-deactivate btn-info changeStatusBtn' data-room-id='${room.Id
                                }'>Deactivate</button>`;
                        } else {
                            return `<button class='btn-link js-deactivate btn-warning changeStatusBtn' data-room-id='${room.Id
                                }'>Activate</button>`;
                        }
                    }
                },
                {
                    data: "Id",
                    render: function (data, type, room) {
                        return "<button class='btn btn-danger deleteRoomBtn' id='" + data + "'>Delete</button>";
                    }
                }
            ]
        });
    }

    function listeners() {
        $(_document).on("click", ".changeStatusBtn", function () {
            var roomId = $(this).attr("id");

            $.ajax({
                method: "post",
                url: "/api/RoomList/ChangeTopicStatus",
                data: {
                    id:roomId,
                    status:false
                },
                success: function (data) {
                    if (data) {
                        window.location = "/ChatEngine/ChatStart?roomid=" + roomId;
                    } else {
                        alert("Room Anavailable");
                    }

                }

            });
        });

        $(_document).on("click", ".deleteRoomBtn", function () {
            var roomId = $(this).attr("id");

            $.ajax({
                method: "delete",
                url: "/api/RoomList/DeleteTopic",
                data: {
                    id: roomId
                },
                success: function (data) {
                    if (data) {
                        alert("Room deleted");
                    } else {
                        alert("Room Anavailable");
                    }

                }

            });
        });


        $(_document).on("click", ".userBtn", function() {
            var  userId = $(this).attr("id");

            $.ajax({
                method: "get",
                url: "/api/Users/GetUser?id=" + userId,

                success: function (data) {
                    if (data) {

                        $("#userNameLabelModal").append(data.UserName);
                        $("#idLabelModal").append(data.Id);
                        $("#emailLabelModal").append(data.Email);
                        $("#statusLabelModal").append(data.Active);
                        $("#roomsLeftLabelModal").append(data.RoomsLeft);

                    } else {
                        alert("User Does not exist");
                    }

                }

            });
        });

        $("#registeredUsers").on("click",
            ".js-deactivate",
            function () {
                if ($(this).hasClass("active")) {
                    var button = $(this);
                    var roomId = button.attr("data-room-id");
                    bootbox.confirm("Are you sure you want to deactivate this room?",
                        function (result) {
                            if (result) {
                                $.ajax({
                                    method: "post",
                                    url: "/api/RoomList/ChangeTopicStatus",
                                    data: {
                                        id: roomId,
                                        status: false
                                    },
                                    success: function (response) {
                                        $table.row(button.text("Activate").removeClass("btn-info")
                                            .addClass("btn-warning")).draw();

                                    }
                                });
                            }
                        });
                } else {
                    var button2 = $(this);
                    var roomId2 = button2.attr("data-room-id");
                    bootbox.confirm("Are you sure you want to activate this room?",
                        function (result) {
                            if (result) {
                                $.ajax({
                                    method: "post",
                                    url: "/api/RoomList/ChangeTopicStatus",
                                    data: {
                                        id: roomId2,
                                        status: true
                                    },
                                    success: function (response) {
                                        $table.row(button2.text("Deactivate").removeClass("btn-warning")
                                            .addClass("btn-info")).draw();


                                    }
                                });
                            }
                        });
                }
            });

     

    }




}(window.ChatRoomsAdminPartialController = window.ChatRoomsAdminPartialController || {}, jQuery, document, console, IndexService));