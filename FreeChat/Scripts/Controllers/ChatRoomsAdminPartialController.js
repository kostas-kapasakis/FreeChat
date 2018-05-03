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
                        return yearDate;
                    }

                },
                {
                    data: "UserCreatorId",
                    render: function (data, type, room) {
                    
                        return `<button class='btn btn-default userBtn' id='${data
                            }' data-toggle='modal' data-target='#usersModal'><i class='fa fa-user'></i>&nbsp;User</button>`;
                    }
                },
                {
                    data: "Id",
                    render: function (data, type, room) {
                        if (room.Active) {
                            return `<button class='btn btn-outline-warning waves-effect deactivate  changeStatusBtn' data-room-id='${room.Id
                                }'>Deactivate</button>`;
                        } else {
                            return `<button class='btn btn-outline-warning waves-effect activate btn-warning changeStatusBtn' data-room-id='${room.Id
                                }'>Activate</button>`;
                        }
                    }
                },
                {
                    data: "Id",
                    render: function (data, type, room) {
                        return `<button class='btn btn-outline-danger waves-effect deleteRoomBtn' id='${room.Id}'>Delete</button>`;
                    }
                }
            ]
        });
    }

    function listeners() {

        $(_document).on("click", ".deleteRoomBtn", function () {
            var roomId = $(this).attr("id");
            var button = $(this);
            bootbox.confirm("Are you sure you want to delete this room?",
                function(result) {
                    if (result) {

                        $.ajax({
                            method: "delete",
                            url: "/api/RoomList/DeleteTopic?Id="+roomId,
                            success: function(data) {
                                if (data) {
                                    $table.row(button.parents("tr")).remove().draw();
                                } else {
                                    alert("Room Anavailable");
                                }

                            }

                        });
                    }
                });
        });


        $(_document).on("click", ".userBtn", function() {
            const userId = $(this).attr("id");

            $.ajax({
                method: "get",
                url: `/api/Users/GetUser?id=${userId}`,

                success: function (data) {
                    if (data) {

                        $("#userNameLabelModal .valueofModal").append(data.UserName);
                        $("#idLabelModal .valueofModal").append(data.Id);
                        $("#emailLabelModal .valueofModal").append(data.Email);
                        $("#statusLabelModal .valueofModal").append(data.Active);
                        $("#roomsLeftLabelModal .valueofModal").append(data.RoomsLeft);

                    } else {
                        alert("User Does not exist");
                    }

                }

            });
        });



        $("#allChatRoomsAdmin").on("click",
            ".changeStatusBtn",
            function () {
                if ($(this).hasClass("deactivate")) {
                    var button = $(this);
                    $(this).toggleClass("deactivate");
                    $(this).toggleClass("activate");
                    var roomId = button.attr("data-room-id");
                    bootbox.confirm("Are you sure you want to deactivate this room?",
                        function (result) {
                            if (result) {
                                $.ajax({
                                    method: "POST",
                                    url: `/api/RoomList/ChangeTopicStatus?id=${roomId}&status=false`,
                                    success: function (response) {
                                        $table.row(button.text("Activate")).draw();

                                    }
                                });
                            }
                        });
                } else {
                    var button2 = $(this);
                    var roomId2 = button2.attr("data-room-id");
                    $(this).toggleClass("deactivate");
                    $(this).toggleClass("activate");
                    bootbox.confirm("Are you sure you want to activate this room?",
                        function (result) {
                            if (result) {
                                $.ajax({
                                    method: "POST",
                                    url: `/api/RoomList/ChangeTopicStatus?id=${roomId2}&status=true`,
                                   
                                    success: function (response) {
                                        $table.row(button2.text("Deactivate")).draw();


                                    }
                                });
                            }
                        });
                }
            });

        $("#closeModal").click(function() {
            $("#usersModalBody .valueofModal").text("");
        });

    }




}(window.ChatRoomsAdminPartialController = window.ChatRoomsAdminPartialController || {}, jQuery, document, console, IndexService));