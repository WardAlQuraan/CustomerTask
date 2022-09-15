$(document).ready(function () {
        $.ajax({
            type: "GET",
            url: '../api/Users/GetAllClients/',
            dataType: "json",
            headers: {
                'Authorization': sessionStorage.getItem("authToken")
            },
            success: function (data) {
                
                $.each(data, function (key, value) {
                    $(".main").append(

                    $(
                        '<div class="card">' +
                        '<div class="card-body">' +
                        '<div class="card-details">' +
                        '<h2 id="username">Username:' + value.UserName + '</h2>' +
                        '<p id="role">Role: ' + value.Role + ' </p>' +
                        '</div>' +
                        '<div class="card-footer">' +
                        '<h1 id="name">' + value.FirstName + ' ' + value.LastName + '</h1>' +
                        '</div>' +
                        '</div>' +
                        '</div>'
                    )
                    );

                });

            },
            error: function (error) {
                alert(error.toString());
                window.location.href = "../Home/Index";

            }
        });

});
