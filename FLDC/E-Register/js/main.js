function Show() {
    $("#1").css({
        "visibility": "hidden"
    });
    $(".collapse:not(.show)").css({
        "display": "block"
    });
}

function Close() {
    $("#1").css({
        "visibility": "visible"
    });
    $(".collapse:not(.show)").css({
        "display": "none"
    });
}

$(document).ready(function() {
    new WOW().init();
});
if ($(document).height() <= 653) {
    $("footer").css({
        "position": "fixed",
        "bottom": "0"
    });
} else {
    console.log($(document).height())
}