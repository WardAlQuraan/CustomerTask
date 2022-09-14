﻿$(document).ready(function () {

    $("#submitBtn").click(function () {
        var userName = $("#username").val();
        var firstname = $("#firstname").val();
        var lastname = $("#lastname").val();
        var password = $("#password").val();
        var confirmPassword = $("#confirmPassword").val();

        if (userName.length == 0 || firstname.length == 0 || lastname.length == 0 || password.length == 0 || confirmPassword.length==0) {
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
                url: '../api/Users/SignUp',
                data: {
                    "UserName": userName,
                    "Password": password,
                    "FirstName": firstname,
                    "LastName": lastname
                },
                dataType: "json",
                success: function (data) {
                    alert("you are registered successfully");
                    window.location.href = "Login";
                },
                error: function (error) {
                    alert(error.responseJSON.Message);
                }
            });
        }

    });
});