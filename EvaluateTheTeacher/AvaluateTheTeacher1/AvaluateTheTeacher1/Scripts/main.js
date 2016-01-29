$(document).ready(function(){
    $(".entry").click(function () {
        $(".login-form").css({ display: "block" });
        $(".backing").css({ display: "block" });
    });
});

function menu_mobile_open() {
    $("header .menu").css({ display: "block" });
    $(".close_mob").css({ display: "block" });
}
function menu_mobile_close() {
    $("header .menu").css({ display: "none" }); 
    $(".close_mob").css({ display: "none" });
}

$(window).load(function () {
    $('#slider').nivoSlider();
});
function hidden_block() {
    $(".login-form").css({ display: "none" });
    $(".backing").css({ display: "none" });
}
$(".form-control").change(function () {
    var value = $(this).val('["Courseware"]');
});

(function () {

    "use strict";

    var toggles = document.querySelectorAll(".cmn-toggle-switch");

    for (var i = toggles.length - 1; i >= 0; i--) {
        var toggle = toggles[i];
        toggleHandler(toggle);
    };
    
    function toggleHandler(toggle) {
        toggle.addEventListener("click", function (e) {
            e.preventDefault();
            (this.classList.contains("active") === true) ? this.classList.remove("active") : this.classList.add("active");
        });
    }

})();