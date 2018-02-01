(function(self, $, _document, _console, _indexService, undefined) {
    "use strict";

    var $doc;
    var $html;
    var $config;
    var loadingVar;


    self.Init = function(config) {
        loadingAnimation();
        digestConfig(config);
        initImpl(config);

    };

    function digestConfig(config) {
        $config = config;
    };

    function initImpl(config) {
        initialListeners();
    }

    function initialListeners() {

        $(_document).on("mouseenter",
            ".inner",
            function() {
                var $target = this;
                $($target).parent("li").find("button").css("display", "block");
               
            });
        $(_document).on("mouseleave",
            ".inner",
            function() {
                var $target = this;
                $($target).parent("li").find("button").css("display", "none");
            });
        $(_document).on("click",".goToRoomsBtn",
            function() {
                var categId = $(this).parents("li").attr("data-categ-id");
                displayRoomsByCateg();
                populateDataTable(categId);
            });

    }
    function displayRoomsByCateg() {
        $("#container-categories-img-list").fadeOut(200);
        $("#roomsByCategory").fadeIn(300);
        $("#redirectPanel").fadeIn(300);
    }

    function populateDataTable(id) {
        
        var $tablebyGenre = $("#ChatRoomsByGenre").DataTable({
            ajax: {
                url: "/api/RoomList/GetRoomsForSpecificGenre?id="+id,
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
   

    function loadingAnimation() {
        loadingVar = setTimeout(showPage, 1000);
    }



    function showPage() {
        $("#loader").css("display", "none");
        $("#IndexContainer").css("display", "block");
    }

}(window.IndexController = window.IndexController || {}, jQuery, document, console, IndexService));