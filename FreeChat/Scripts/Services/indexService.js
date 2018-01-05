(function (self, $, jsonLib, _document, _console, undefined) {
    "use strict";


    var dudfunc = function () { };
    var _baseUrl = "/API/RoomLists/";



    self.LoadMainCategories = function (config) {
        return invoke(config,
            {
                url: "GetMainCategories",
                method: "GET",
                dataType: "json",
                contentType: "application/json; charset=utf-8;"
            },
            _baseUrl);

    };




    function invoke(config, ajaxParams, rightUrl) {
        config = config || {};
        config.done = config.done || dudfunc;
        config.fail = config.fail || u.GenericAjaxFailHandler;
        config.always = config.always || dudfunc;
        config.received = config.received || dudfunc;

        ajaxParams.url = rightUrl + ajaxParams.url;
        var xdataSnapshot = config.extraCallbackData; //bestpractice
        return $.ajax(ajaxParams)
            .done(function (response, textStatus, jqXhr) {
                config.received(xdataSnapshot); //order
                config.done(response, xdataSnapshot, textStatus, jqXhr); //order
            })
            .fail(function (jqXhr, textStatus, error) {
                if ((!jqXhr || !jqXhr.status) && !error) //0 navigation
                    return;

                config.received(xdataSnapshot); //order
                if (jqXhr.status === 401) return; //1
                config.fail(jqXhr, xdataSnapshot, textStatus, error); //order
            })
            .always(function () { config.always(xdataSnapshot); });
    };

}(window.IndexService = window.IndexService || {}, jQuery,JSON, document, console));