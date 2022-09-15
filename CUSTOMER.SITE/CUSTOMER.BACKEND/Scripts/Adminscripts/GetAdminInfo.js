$(document).ready(function () {

        var decodedToken = parseJwt(sessionStorage.getItem("authToken"));
        if (decodedToken.role != "Admin") {
            window.location.href = "../Home/Index";

        }
        $.ajax({
            type: "GET",
            url: '../api/Users/GetUserById/' + decodedToken.ID,
            dataType: "json",
            headers: {
                'Authorization': sessionStorage.getItem("authToken")
            },
            success: function (data) {
                $("#username").append(data.UserName);
                $("#role").append(data.Role);
                $("#name").append(data.FirstName + " " + data.LastName);

            },
            error: function (error) {
                alert(error.toString());
                window.location.href = "../Home/Index";

            }
        });
});
