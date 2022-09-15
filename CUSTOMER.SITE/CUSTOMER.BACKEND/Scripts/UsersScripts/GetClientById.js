$(document).ready(function () {

    if (sessionStorage.getItem("authToken") == null || sessionStorage.getItem("authToken").length == 0) {
        window.location.href = "../Login/Index";
    }
    else {
        var decodedToken = parseJwt(sessionStorage.getItem("authToken"));
        if (decodedToken.role == "Admin") {
            window.location.href = "../Admin/Index";

        }
        $.ajax({
            type: "GET",
            url: '../api/Users/GetUserById/' + decodedToken.ID,
            dataType: "json",
            headers: {
                'Authorization':  sessionStorage.getItem("authToken")
            },
            success: function (data) {
                $("#username").append(data.UserName);
                $("#role").append(data.Role);
                $("#name").append(data.FirstName+ " "+data.LastName);

            },
            error: function (error) {
                alert(error.toString());
                window.location.href = "../Login/Index";

            }
        });

    }

});

