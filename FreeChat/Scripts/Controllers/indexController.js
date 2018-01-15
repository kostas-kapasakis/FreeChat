(function(self, $, _document, _console, _indexService, undefined) {
    "use strict";

    var _$doc;
    var _$html;
    var _config;
    var _loadingVar;

   
    self.Init = function (config) {
        //LoadingAnimation();
        digestConfig(config);
        initImpl(config);
        //showPage();
    };

    function digestConfig(config) {
        _config = config;
    };

    function initImpl(config) {
        InitialListeners();
        DisplayMainCategories();
    }

    function InitialListeners() {
        $(_document).on("click", "#allRoomsButton",function() {
            LoadAllrooms();
        });
    }
    function LoadAllrooms() {
        $("#musicChatRoomsdiv").hide();
        $("#sportsChatRoomsdiv").hide();
        $("#tripsChatRoomsdiv").hide();

        $('#allrooms').fadeOut();
        $("#chatrooms").fadeIn();
    }

    function DisplayMainCategories() {

       
        _indexService.GetMainCategories({
            done: function (data) {
                populateMainCategoriesList(data);
            },
            fail: function (jqXhr) {
                _console.log("Error in getting main Categories");
                _console.log(jqXhr);
            }
        });

    }

   

//    function LoadingAnimation() {
//        _loadingVar = setTimeout(showPage, 1000);
//    }


    function populateMainCategoriesList(data) {

        $.each(data,
            function(index, obj) {
                $("#imglistMainCategories").append
                (
                    "<li>" +
                    "   <a href='#' class='inner'>                                                 " +
                    "       <div  class='li-img'>                                                  " +
                    "           <img src='" + obj.CategoryImage + "' alt='" + obj.Name + "' />     " +
                    "       </div>                                                                 " +
                    "       <div class='li-text'>                                                   " +
                    "         <h3 class='li-head'>" + obj.Name + "</h3>                            " +
                    "           <div class='li-sub'> <p>" + obj.CategoryDescription + ".</p>       " +
                    "            </div></div></a></li>"

                );

            });
    }


    function showPage() {
        $("#loader").css("display", "none");
        $("#IndexContainer").css("display", "block");
    }

}(window.IndexController = window.IndexController || {}, jQuery, document, console, IndexService));