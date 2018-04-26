var ChatEngineUiController = (function() {
    "use strict";

    const viewDomElems = function() {

        return {
            chatEngineWrapperContainer: $("#ChatEngineContainer"),
            messageList: $(".inner-list"),
            onlineUserContainer: function () { return $(document).find(".onlineUserActualPart")},
            onlineUserWrapper: $("#card-body-online"),
            sendMessageBtn: $("#send"),
            userMessageTextArea: $("#messageTyped"),
            chatEngineLoader: $("#loader"),
            cancelFilterBtn: $("#cancelIconFilter"),
            filterSearchBarinput: $("#searchOnlineUsers input"),
            exitRoomBtn: $("#exitRoomBtn"),
            roomDetailsModalInit: $("#modalInitializerBtn")
        }
    }

    const onlineUsersOptions = function() {
        return {
            initialSeeding: 0,
            update: 1,
            confirmation:2
        }
    }
    
    





    return {
        viewDomElems: viewDomElems,
        onlineUsersOptions: onlineUsersOptions


    }


}(window.ChatEngineUiController = window.ChatEngineUiController || {}, jQuery, document, console, UtilsController));