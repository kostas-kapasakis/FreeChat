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
        $(_document).on("click",
            "#allRoomsButton",
            function() {
                LoadAllrooms();
            });

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


    }
    function LoadAllrooms() {
        $("#musicChatRoomsdiv").hide();
        $("#sportsChatRoomsdiv").hide();
        $("#tripsChatRoomsdiv").hide();

        $('#allrooms').fadeOut();
        $("#chatrooms").fadeIn();
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
                    `<li>
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