$(document).ready(function () {
    var decodedToken = parseJwt(sessionStorage.getItem("authToken"));
    if (decodedToken == null || decodedToken.length == 0 || decodedToken.role != "Admin")
    { window.location.href = "../Home/Index"; }
});