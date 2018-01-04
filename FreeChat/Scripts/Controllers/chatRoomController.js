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
        
    }

}(window.ChatRoomController = window.ChatRoomController || {}, jQuery, document, console, ChatRoomService));