$(document).ready(function () {

    if (sessionStorage.getItem("authToken") == null || sessionStorage.getItem("authToken").length == 0) {
        window.location.href = "../Home/Index";
    }
    else {
        var decodedToken = parseJwt(sessionStorage.getItem("authToken"));
        if (decodedToken.role != "Admin") {
            window.location.href = "../Home/Index";

        }
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

function getCardClass(id) {
    return 
    $(
        '<div class="card">'+
        '<div class= "card-header">'+
        '<h1>Profile Page</h1>'+
        '</div>'+
        '<div class="card-body">'+
            '<div class="card-details">'+
                '<h2 id="username">Username: </h2>'+
                '<p id="role">Role: </p>'+
            '</div>'+
            '<div class="card-footer">'+
                '<h1 id="name"></h1>'+
            '</div>'+
        '</div>'+
    '</div>'
    );
}