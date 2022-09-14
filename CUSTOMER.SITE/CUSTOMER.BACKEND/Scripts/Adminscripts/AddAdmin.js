$(document).ready(function () {
    if (sessionStorage.getItem("authToken") == null || sessionStorage.getItem("authToken").length == 0) {
        window.location.href = "../Home/Index";
    }
    else {
        var decodedToken = parseJwt(sessionStorage.getItem("authToken"));
        if (decodedToken.role != "Admin") {
            window.location.href = "../Home/Index";

        }
        $("#submitBtn").click(function () {
            var userName = $("#username").val();
            var firstname = $("#firstname").val();
            var lastname = $("#lastname").val();
            var password = $("#password").val();
            var confirmPassword = $("#confirmPassword").val();

            if (userName.length == 0 || firstname.length == 0 || lastname.length == 0 || password.length == 0 || confirmPassword.length == 0) {
                alert("Please fill all data");
            }
            else if (password.lastIndexOf < 6) {
                alert("password must be at least 6 charcacters");
            }
            else if (password != confirmPassword) {
                alert("passwords not match");
            }
            else {
                $.ajax({
                    type: "POST",
                    url: '../api/Users/CreateAdmin',
                    data: {
                        "UserName": userName,
                        "Password": password,
                        "FirstName": firstname,
                        "LastName": lastname
                    },
                    headers: {
                        'Authorization': sessionStorage.getItem("authToken")
                    },
                    dataType: "json",
                    success: function (data) {
                        alert("Added New Admin Successfully");
                        window.location.href = "Index";
                    },
                    error: function (error) {
                        alert(error.responseJSON.Message);
                    }
                });
            }

        });

        $("#logout").click(function () {
            sessionStorage.clear();
            window.location.href = "../Home/Index";
        });
    }
});

function parseJwt(token) {
    var base64Url = token.split('.')[1];
    var base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
    var jsonPayload = decodeURIComponent(atob(base64).split('').map(function (c) {
        return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
    }).join(''));

    return JSON.parse(jsonPayload);
};
