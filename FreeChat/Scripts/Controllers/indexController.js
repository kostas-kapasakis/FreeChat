(function (self, $, _document, _console, _indexService, undefined) {
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
    };

    function initImpl(config) {

    }


}(window.IndexController = window.IndexController || {}, jQuery, document, console, IndexService));