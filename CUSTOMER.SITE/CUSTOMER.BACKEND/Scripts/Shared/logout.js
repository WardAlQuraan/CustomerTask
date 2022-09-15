$(document).ready(function () {
    $("#logout").click(function () {
        sessionStorage.clear();
        window.location.href = "../Login/Index";
    });
});