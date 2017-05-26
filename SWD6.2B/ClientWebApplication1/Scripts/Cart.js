/// <reference path="jquery-3.1.1.min.js" />

$(document).ready(function () {
    GetItemsFromCart();
})

function GetItemsFromCart() {
    var username = $("#divMyUser").html();
    var items = localStorage.getItem(username);
    data = JSON.parse(items);
    console.log(data);
    var counter = 0;
    var idarr = [];
    var qtyarr = [];
    var mydiv = "<div class=\"row\">";
    var mydiv = "<div class=\"row\">";

    $.each(data, function (index, prod) {
        mydiv += "<div class=\"col-xs-3\" style=\"border-style:solid; margin:1px\">";
        mydiv += "Product ID: " + prod.Id;
        mydiv += "<br/> Qty bought: " + prod.Qty;
        mydiv += "</div>";
        idarr[counter] = prod.Id;
        qtyarr[counter] = prod.Qty;
        counter++;
    })

    data = JSON.stringify(data);
    console.log(data);
    mydiv += '</br> <input type="button" value="Submit Order " onClick="submitOrder()" />'
    mydiv += "</div>";
    $("#divItems").html(mydiv);
    //submitOrder(idarr,qtyarr);
}
function submitOrder() {
    var idarr = [];
    var qtyarr = [];
    var counter = 0;
    var username = $("#divMyUser").html();

    if (localStorage.getItem(username) != null)
    {
        cart = localStorage.getItem(username);
    }
    var milliseconds = new Date().getTime();
    data = JSON.parse(cart);
    console.log("Details From Cart : " + data);
    $.each(data, function (index, prod) {
        $.ajax({
            type: 'POST',
            url: 'Checkout',
            data: {"Id":prod.Id,"Qty":prod.Qty, "Timestamp" : milliseconds},
            success: function (data) {
                console.log("Success");
            },
            // contentType: "application/json",
            dataType: 'json'
        });
    })

   EraseCart();

}

function EraseCart() {
    var username = $("#divMyUser").html();
    var myCart = [];
    var myJsonString = JSON.stringify(myCart);
    localStorage.setItem(username, myJsonString);
}

    
