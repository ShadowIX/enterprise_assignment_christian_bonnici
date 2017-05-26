/// <reference path="jquery-3.1.1.min.js" />

$(document).ready(function () {
    var username = $("#divMyUser").html();
    PopulateItems();
})

function PopulateItems() {
    $.getJSON("http://localhost:61047/Items/GetOrdersAsync", function (data) {
        var Id = 0;
        var mydiv = "<div class=\"row\">";
        mydiv += "<p> Order </p>";

       
        $.each(data, function (index, prod) {
            mydiv += "<div class=\"col-xs-3\" style=\"border-style:solid; margin:1px\">";
            mydiv += "Order ID: " + prod.OrderID;
            mydiv += "</br>Product ID: " + prod.ProductID;
            mydiv += "</br>Product Name: " + prod.ProductName;
            mydiv += "</br>Product Name: " + prod.ProductDescription;
            mydiv += "</br>Product Name: " + prod.UnitPrice;
            mydiv += "</br>Product Quantity: " + prod.Stock;
            mydiv += "</br>Product Api ID: " + prod.ApiID;
            mydiv += "<br/> <input type=\"button\" value=\"Cancel Order\" onclick=\"Cancel(" + prod.OrderID + ")\" />";
            mydiv += "</div>";
        })
        mydiv += "</div>";
        $("#divItems").html(mydiv);
    });
}

function Cancel(orderID)
{
    console.log(orderID);
    $.ajax({
        type: 'POST',
        url: 'Orders',
        data: { "Id": orderID},
        success: function (data) {
            alert("returned");
        },
        //contentType: "application/json",
        dataType: 'json'
    });
}