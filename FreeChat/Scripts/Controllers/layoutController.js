var LayoutController = (function (self, $) {
    "use strict";

    const layoutDomElems = {
        leftNavMenu: $("#leftNavBar"),
        topNavMenu: $("#nav-topMenu"),
        navLogo: $("#mainNav .navbar-brand"),
        toggleNavIcon: $("#sidenavToggler"),
        contentWrapper: $(".content-wrapper"),
        fullChatModebtn: $("#leftPanel-fullchatmode"),
        myRoomsBtn: $("#topMenu-myRoomsBtn"),
        logoutBtn: $("#topMenu-logoutBtn")
};

    const toggleAllNavItemsOnChatFullMode = 
    () => {
        const navItems = layoutDomElems.leftNavMenu.find(".nav-item").not(layoutDomElems.fullChatModebtn);
        navItems.hide({ duration: 0, queue: false });
        layoutDomElems.fullChatModebtn.toggleClass("onfullChatMode");
        layoutDomElems.toggleNavIcon.hide({ duration: 0, queue: false });
    };

    return {
        layoutDomElems: layoutDomElems,
        toggleAllNavItemsOnChatFullMode: toggleAllNavItemsOnChatFullMode
    }


}(window.LayoutController = window.LayoutController || {}, jQuery, document));