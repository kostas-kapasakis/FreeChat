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
        displayMainCategories();
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
    function displayMainCategories() { 
        _indexService.GetMainCategories({
            done: function (data) {
                populateMainCategoriesList(data);
                showPage();
            },
            fail: function (jqXhr) {
                _console.log("Error in getting main Categories");
                _console.log(jqXhr);
            }
        });

    }

   

    function loadingAnimation() {
        loadingVar = setTimeout(showPage, 1000);
    }


    function populateMainCategoriesList(data) {

        $.each(data,
            function(index, obj) {
                $("#imglistMainCategories").append
                (
                    `<li data-categ-id='${obj.Id}'>
                        <a href='#' class='inner'>
                           <div  class='li-img'> <img src='${obj.CategoryImage}' alt='${obj.Name}' height='120px'/></div>                                                                        <div class='li-text'>
                           <h3 class='li-head'>${obj.Name}</h3>
                           <div class='li-sub'> <p>${obj.CategoryDescription}.</p> 
                       </div></div></a><button type="button" class="btn btn-primary goToRoomsBtn">See Rooms</button></li>`

                );

            });
        $(".goToRoomsBtn").css("display", "none");
    }


    function showPage() {
        $("#loader").css("display", "none");
        $("#IndexContainer").css("display", "block");
    }

}(window.IndexController = window.IndexController || {}, jQuery, document, console, IndexService));