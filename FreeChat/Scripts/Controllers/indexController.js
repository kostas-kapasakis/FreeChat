(function(self, $, _document, _console, _indexService, undefined) {
    "use strict";

    var _$doc;
    var _$html;
    var _config;


    console.log(_indexService);
    self.Init = function (config) {
        digestConfig(config);
        initImpl(config);
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

       
        _indexService.LoadMainCategories({
            done: function (data) {
                console.log(data);
            },
            fail: function (jqXhr) {
                _console.log("Error in getting main Categories");
                _console.log(jqXhr);
            }
        });

    }

}(window.IndexController = window.IndexController || {}, jQuery, document, console, IndexService));