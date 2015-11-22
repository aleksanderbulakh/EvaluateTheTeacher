$(document).ready(function(){
    $(".entry").click(function () {
        $(".login-form").css({ display: "block" });
        $(".backing").css({ display: "block" });
    });
});
$(window).load(function () {
    $('#slider').nivoSlider();
});
function hidden_block() {
    $(".login-form").css({ display: "none" });
    $(".backing").css({ display: "none" });
}