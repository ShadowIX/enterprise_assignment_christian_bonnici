/// <reference path="jquery-3.1.1.min.js" />

$(document).ready(function () {

	PopulateUsers();

})


function PopulateUsers()
{
    $.getJSON("http://localhost:49700/api/UsersApi/GetUsers", function (data) {

        var mydiv = "<div class=\"row\">";
        $.each(data, function (index, user) {
            mydiv += "<div class=\"col-xs-3\" style=\"border-style:solid; margin:1px\">";
            mydiv += "Username: " + user.Username;
            mydiv += "<br/> First Name: " + user.FirstName;
            mydiv += "<br/> Surname: " + user.Surname;
            mydiv += "<br/><input type=\"number\" id = \"txtQty" + user.Username + "\" />";
            mydiv += "<br/><input type=\"button\" value=\"Add to Cart\" id = \"btnAddtoCart " + user.Username + "\" onclick=\"AddToCart('" + user.Username + "')\" />";
            mydiv += "<br/> <input type=\"button\" value=\"Checkout\" onclick=\"checkout()\" />";
            mydiv += "<br/> <input type=\"button\" value=\"Get Roles\" onclick=\"GetRoles('" + user.Username + "')\" />";
            mydiv += "</div>";
        })
        mydiv += "</div>";

        //var table = "<table class=\"table table-hover\"><tr><th>Username</th><th>Full Name</th></tr>";
        //$.each(data, function (index, user) {

        //	table += "<tr><td>"+user.Username+"</td><td>"+user.FirstName +" " +user.Surname+"</td></tr>";
        //})
        //table += "</table>";
        $("#divUsers").html(mydiv);

    });
}
function GetRoles(username) {

    $.getJSON("http://localhost:49700/api/UsersApi/GetUserRoles?username=" + username, function (data) {

        var mydiv = "<div>";
        $.each(data, function (index, role) {
            mydiv += "Id: " + role.Id + "<br/>Title: " + role.Title +"<br/>";
        })
        mydiv += "</div>";
 
        $("#divRoles").html(mydiv);

    }).done(function () { $("#myModal").modal("show"); });
    
}

function Search()
{
    var keyword = $("#txtKeyword").val();

    $.getJSON("/Users/SearchUsersAsync?keyword=" + keyword, function (data) {
        var table = "<table><tr><th>Username</th></tr>";
        $.each(data, function (index, user) {

            table += "<tr><td>" + user.Username + "</td></tr>";
        })
        table += "</table>";
        $("#divUsers").html(table);

    });
}


function AddToCart(username) {
    var myCart = [];
    if (localStorage.getItem("myCart") != null) {
        myCart = JSON.parse(localStorage.getItem("myCart"));
    }

    var qty = $('#txtQty' + username).val();

    var flag = false;
    $.each(myCart, function (index, v) {
        if (v.Id == username) {
            v.Qty += Number(qty);
            flag = true;
            return;
        }
    })

    if (flag == false) {
        var item = { "Id": username, "Qty": Number(qty) };
        myCart.push(item);
    }

    var myJsonString = JSON.stringify(myCart);
    localStorage.setItem("myCart", myJsonString);
}


function checkout()
{
    var items = localStorage.getItem("myCart");

    $.ajax({
        type: 'POST',
        url: 'http://localhost:61047/Users/IndexWithJQuery',
        data: { 'Items ': localStorage.getItem("myCart") },
        success: function (data) { alert(data); },
        contentType: "application/json",
        dataType: 'json'    
    });
}