var ChatEngineUiController = (function() {
    "use strict";

    const viewDomElems = function() {

        return {
            chatEngineWrapperContainer: $("#ChatEngineContainer"),
            messageList: $(".inner-list"),
            onlineUserContainer: $(".onlineUserActualPart"),
            onlineUserWrapper: $("#card-body-online"),
            sendMessageBtn: $("#send"),
            userMessageTextArea: $("#messageTyped"),
            chatEngineLoader: $("#loader"),
            cancelFilterBtn: $("#cancelIconFilter"),
            filterSearchBarinput: $("#searchOnlineUsers input"),
            exitRoomBtn: $("#exitRoomBtn"),
            roomDetailsModalInit: $("#modalInitializerBtn"),
            roomNameContainer: $("#roomNameValue")
        }
    }
        
    





    return {
        viewDomElems: viewDomElems


    }


}(window.ChatEngineUiController = window.ChatEngineUiController || {}, jQuery, document, console, UtilsController));