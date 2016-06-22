/* File Created: February 28, 2013 */

/// <reference path="jquery-2.0.3-vsdoc.js" />


// some global variables!!!
var haveOverlay = 0;
// --------------------------------------------------------------

// function to prevent the event when pressing _keys!!!  [ 27=Esc, 9=Tab ]
$(document).keydown(function (e) {
    if (e.keyCode == 27) {
        e.preventDefault(); // FIXES FIREFOX GIF STOPPING
    }
    if (e.keyCode == 9 && haveOverlay != 0) {
        e.preventDefault();
    }
});
// --------------------------------------------------------------

// method to clear all child field values of a parent selector!!!
function MyFieldCleaner(parentSelector) {
    $(parentSelector + " input[type='text']").val("");
};
// --------------------------------------------------------------

// method to create & remove the overlay for processing a process!!!
function MyOverlayStart() {
    $(".alert_overlay").remove();

    var overlay = $('<div id="alert_overlay" class="alert_overlay"><img id="loading_img" alt="Processing . . ." src="/Content/Images/loading.gif" /></div>');
    $("body").append(overlay);
    haveOverlay = 1;

    methodToFixLoadingImg();
    $(window).on("resize", methodToFixLoadingImg);
    function methodToFixLoadingImg(e) {
        $("#loading_img").css("margin-left", ($(window).width() / 2) - ($("#loading_img").width() / 2));
        $("#loading_img").css("margin-top", ($(window).height() / 2) - ($("#loading_img").height() / 2));
    }
};
function MyOverlayStop() { $(".alert_overlay").remove(); haveOverlay = 0; };
// --------------------------------------------------------------

// method for generic confirm alertbox!!!
function MyConfirmBox(boxType, imgType, headerText, messageText, okButtonText, cancelButtonText, callbackOk, callbackCancel, yesNo) {
    $(".alert_modal").remove(); $(".alert_overlay").remove();

    var imgSrc = "";
    if (imgType == "e") { imgSrc = "/Content/Images/error_24.png"; }
    if (imgType == "i") { imgSrc = "/Content/Images/information_24.png"; }
    if (imgType == "s") { imgSrc = "/Content/Images/success_24.png"; }
    if (imgType == "w") { imgSrc = "/Content/Images/warning_24.png"; }
    if (imgType == "h") { imgSrc = "/Content/Images/help_24.png"; }

    if (boxType != "block" && boxType != "info" && boxType != "error" && boxType != "success" && boxType != "danger")
    { boxType = ""; } else { boxType = "alert-" + boxType; }

    var confirmBox = $('<div id="alert_overlay" class="alert_overlay"></div>' +
        '<div id="alert_modal" class="alert_modal alert alert-block ' + boxType + ' fade in hide">' +
        '<div id="alert_header">' +
        '<a id="alert_close_link" class="close">&times;</a>' +
        '<img id="alert_type_img" alt="" src="' + imgSrc + '" />' +
        '<h4 id="alert_title">' + headerText + '</h4></div>' +
        '<div id="alert_body"><p>' + messageText + '</p></div>' +
        '<div id="alert_footer">' +
        '<a id="alert_ok_link" class="btn btn-success btn-3d msgButton">' + okButtonText + '</a> &nbsp; <a id="alert_cancel_link" class="btn btn-warning btn-3d msgButton">' + cancelButtonText + '</a>' +
        '</div></div>');

    confirmBox.find("#alert_close_link").click(function (e) {
        $("#alert_modal").hide(300, function () { $(".alert_modal").remove(); $(".alert_overlay").remove(); haveOverlay = 0; });
    });

    confirmBox.find("#alert_ok_link").click(function (e) {
        $("#alert_modal").hide(300, function () { $(".alert_modal").remove(); $(".alert_overlay").remove(); haveOverlay = 0; if (callbackOk && typeof (callbackOk) === "function") { callbackOk(); } });
    });

    confirmBox.find("#alert_cancel_link").click(function (e) {
        $("#alert_modal").hide(300, function () { $(".alert_modal").remove(); $(".alert_overlay").remove(); haveOverlay = 0; if (callbackCancel && typeof (callbackCancel) === "function") { callbackCancel(); } });
    });

    $("body").append(confirmBox);

    if (yesNo == "0") { $("#alert_footer").hide(); } else { $("#alert_close_link").hide(); }
    if (yesNo == "1") { $("#alert_cancel_link").hide(); }

    $("#alert_modal").show(300);
    haveOverlay = 1;
};
// --------------------------------------------------------------

// method to confirm the process of clearing field values!!!
function ConfirmFieldClear(parentSelector) {
    MyConfirmBox("info", "h", "Field Values Clearness Confirmation", "Are you sure you want to clean all fields?", "Yes", "No", function () { MyFieldCleaner(parentSelector); }, "", "2");
};
// --------------------------------------------------------------

// method to confirm the process of clearing field values!!!
function ConfirmProcess(msg, callbackOk, callbackCancel) {
    MyConfirmBox("info", "h", "Process Confirmation", msg, "Yes", "No", callbackOk, callbackCancel, "2");
};
// --------------------------------------------------------------

// method to alert about field validation error!!!
function ValidationAlert(fieldValidationMsg) {
    MyConfirmBox("error", "e", "Field Validation Error", fieldValidationMsg, "OK", "", "", "", "1");
};
// --------------------------------------------------------------

// method to alert error!!!
function ErrorAlert(alertTitle, alertMsg) {
    MyConfirmBox("error", "e", alertTitle, alertMsg, "OK", "", "", "", "1");
};
// --------------------------------------------------------------

// method to alert success processing!!!
function SuccessAlert(alertTitle, alertMsg, callbackOk) {
    MyConfirmBox("success", "s", alertTitle, alertMsg, "OK", "", callbackOk, "", "1");
};
// --------------------------------------------------------------

// method to alert process warning!!!
function WarningAlert(alertTitle, alertMsg, callbackOk) {
    MyConfirmBox("block", "w", alertTitle, alertMsg, "OK", "", callbackOk, "", "1");
};
// --------------------------------------------------------------

function pingSession() {
    $.ajax({
        type: "POST",
        url: "/KeepAlive.asmx/PingSession",
        data: "{}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            //alert(data.d);
        }
    });
};

function blink(e) {
    $(e).fadeOut('slow', function () {
        $(this).fadeIn('slow', function () {
            blink(this);
        });
    });
}

function getAbsolutePath() {
    //alert(window.location);
    //alert($(location).attr('href'));

    var loc = window.location;
    var pathName = loc.pathname.substring(0, loc.pathname.lastIndexOf('/') + 1);
    return loc.href.substring(0, loc.href.length - ((loc.pathname + loc.search + loc.hash).length - pathName.length));
}

$(".disableValidation").click(function () {
    $("#form1").validate().currentForm = "";
});

$(".enableValidation").click(function () {
    $("#form1").validate().currentForm = $("#form1")[0];
});

//e.preventDefault();
//$("#form1").valid();

$(function () {

});
