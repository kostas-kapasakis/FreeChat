(function (self, $, _document, _console, _chatRoomService, undefined) {
    "use strict";

    var _$doc;
    var _$html;
    var _config;

    self.Init = function (config) {
        digestConfig(config);
        initImpl(config);
    };

    function digestConfig(config) {
        _config = config;
    }

    function initImpl(config) {
        InitialListeners();
    }

    function InitialListeners() {
        $(_document).on("click","#createRoomForm",function() {
            _chatRoomService.createRoom({
                data: {
                    name: $("#Topic_Name").val(),
                    genre: $("#MainCategories").find(":selected").attr("value"),
                    description: $("#Topic_Description").val()
                },
                done: function (data) {

                    console.log("mphke");
                    $("#Topic_Name").val("");
                    $("#Topic_Description").val("");
                    $("#MainCategories").val("");

                },
                fail: function(jqXhr) {
                    _console.log("Error in Submiting the form");
                    _console.log(jqXhr);
                }
            });
        });
    }

}(window.ChatRoomController = window.ChatRoomController || {}, jQuery, document, console, ChatRoomService));