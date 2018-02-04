(function (self, $, _document, _console, _indexService, undefined) {
    "use strict";

    var $doc;
    var $html;
    var $config;
    var $table;

    self.Init = function (config) {
        digestConfig(config);
        initImpl(config);
        listeners();
    };

    function digestConfig(config) {
        $config = config;
    };

    function initImpl(config) {
        $table = $("#allChatRooms").DataTable({
            ajax: {
                url: "/api/RoomList/GetAllRooms",
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
                    data: "Id",
                    render: function (data, type, room) {
                        return "<button class='btn btn-success roominitBtn' id='" + data + "'>Enter Room</button>";
                    }
                }
            ]
        });
    }

    function listeners() {
        $(_document).on("click", ".roominitBtn", function () {
            var roomId = $(this).attr("id");

            $.ajax({
                method: "get",
                url: "/api/ChatEngineApi/Chatengine?roomId="+roomId,
               
                success: function(data) {
                    if (data) {                
                        window.location = "/ChatEngine/ChatStart?roomid=" + roomId;
                    } else {
                        alert("Room Anavailable");
                    }    
                                
            }
                
            });
        });

    }


   
    
}(window.AllChatRoomsPartialController = window.AllChatRoomsPartialController || {},jQuery,document,console,IndexService ));