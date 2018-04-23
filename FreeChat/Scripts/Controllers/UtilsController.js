var UtilsController = (function() {


    function getDate(timestamp)
    {
        // Multiply by 1000 because JS works in milliseconds instead of the UNIX seconds
        var date = new Date(timestamp * 1000);
        //var date = new Date(timestamp);

        var year = date.getUTCFullYear();
        var month = date.getUTCMonth() + 1; // getMonth() is zero-indexed, so we'll increment to get the correct month number
        var day = date.getUTCDate();
        var hours = date.getUTCHours();
        
        var minutes = date.getUTCMinutes();
        var seconds = date.getUTCSeconds();

        month = (month < 10) ? "0" + month : month;
        day = (day < 10) ? "0" + day : day;
        hours = (hours < 10) ? "0" + hours : hours;
        minutes = (minutes < 10) ? "0" + minutes : minutes;
        seconds = (seconds < 10) ? "0" + seconds : seconds;

        return year + "-" + month + "-" + day + " " + hours + ":" + minutes;
    }

    function startTime() {
        var today = new Date();
        var h = today.getHours();
        var m = today.getMinutes();
        var s = today.getSeconds();
        m = checkTime(m);
        s = checkTime(s);

        return [h, m, s];

    }
    function checkTime(i) {
        if (i < 10) { i = "0" + i };  // add zero in front of numbers < 10
        return i;
    }


    return {
        getClock: function() {
            return startTime();
        }
    }


}(window.UtilsController = window.UtilsController || {}, undefined));
