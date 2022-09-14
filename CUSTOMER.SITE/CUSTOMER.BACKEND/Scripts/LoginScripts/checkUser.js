$(document).ready(function () {
    $("#submitBtn").click(function () {
        var userName = $("#username").val();
        var password = $("#password").val();
        if (userName.length == 0) {
            alert("Username is required");
        } else if (password.length == 0) {
            alert("Password is required")
        } else {
            $.ajax({
                type: "POST",
                url: '../api/Users/Login',
                data: {
                    "UserName": userName,
                    "Password": password
                },
                dataType: "json",
                success: function (data) {
                    var token = data.JwtAuth;
                    if (token.length > 0) {
                        sessionStorage.setItem("authToken", token);
                        sessionStorage.setItem("username", userName);
                        window.location.href = "../Home/Index"
                    } else {
                        alert("Your email or password is not valid");
                    }
                },
                error: function (error) {
                    console.log(error)
                }
            });
        }

    });
});


