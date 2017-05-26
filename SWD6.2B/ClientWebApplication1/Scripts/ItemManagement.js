/// <reference path="jquery-3.1.1.min.js" />

$(document).ready(function () {
    var username = $("#divMyUser").html();
    PopulateItems();
})

function PopulateItems() {
    $.getJSON("http://localhost:61047/Items/GetItemsAsync", function (data) {
        var mydiv = "<div class=\"row\">";
        var mydiv = "<div class=\"row\">";
        $.each(data, function (index, prod) {
            mydiv += "<div class=\"col-xs-3\" style=\"border-style:solid; margin:1px\">";
            mydiv += "ID: " + prod.ProductID;
            mydiv += "<br/> Name: " + prod.ProductName;
            mydiv += "<br/> Description: " + prod.ProductDescription;
            mydiv += "<br/> Stock: " + prod.Stock;
             mydiv += "<br/> Price: " + prod.UnitPrice;
            mydiv += "<br/><input type=\"number\" id = \"txtQty" + prod.ProductID + "\" />";
            mydiv += "<br/><input type=\"button\" value=\"Add to Cart\" id = \"btnAddtoCart " + prod.ProductID + "\" onclick=\"AddToCart(" + prod.ProductID + "," + prod.Stock +")\" />";
            mydiv += "<br/><input type=\"button\" value=\"Remove From Cart\" id = \"btnRemoveFromCart " + prod.ProductID + "\" onclick=\"RemoveFromCart('" + prod.ProductID + "')\" />";
            mydiv += "<br/> <input type=\"button\" value=\"Checkout\" onclick=\"checkout()\" />";
            mydiv += "</div>";
        })
        mydiv += "</div>";
        $("#divItems").html(mydiv);
    });
}

function AddToCart(ProductID,Stock) {
    var username = $("#divMyUser").html();
    var myCart = [];
    if (localStorage.getItem(username) != null) {
        myCart = JSON.parse(localStorage.getItem(username));
    }

    var qty = $('#txtQty' + ProductID).val();

    var flag = false;
    $.each(myCart, function (index, v) {
        if (v.Id == ProductID) {
            v.Qty += Number(qty);
            if (v.Qty > Stock)
            {
                v.Qty = Stock;
                alert("Error, Adjusting Value to meet the Stock Qty");
            }

            else {
                alert("Item Added to Cart");
            }
            flag = true;
            return;
        }
    })

    if (flag == false) {
        var item = { "Id": ProductID, "Qty": Number(qty) };
        myCart.push(item);
       console.log("New Item Added to Cart");
    }

    var myJsonString = JSON.stringify(myCart);
    localStorage.setItem(username, myJsonString);
}

function RemoveFromCart(ProductID) {
    var username = $("#divMyUser").html();
    var myCart = [];
    var newCart = [];
    if (localStorage.getItem(username) != null) {
        myCart = JSON.parse(localStorage.getItem(username));
    }

    $.each(myCart, function (index, v) {
        if (v.Id != ProductID) {
            var item = { "Id": v.Id, "Qty": Number(v.Qty) };
            newCart.push(item);
        }
    })
    var myJsonString = JSON.stringify(newCart);
    localStorage.setItem(username, myJsonString);
}

function checkout() {
    var username = $("#divMyUser").html();
    var items = localStorage.getItem(username);
    /*$.ajax({
        type: 'POST',
        url: 'http://localhost:61047/Items/IndexWithJQuery',
        data: { 'Items ': localStorage.getItem(username) },
        success: function (data) { alert(data); },
        contentType: "application/json",
        dataType: 'json'
    });
    */

    window.location = 'http://localhost:61047/Items/Checkout';
}

function Search() {
    var keyword = $("#txtKeyword").val();

    $.getJSON("/Items/SearchItemsAsync?keyword=" + keyword, function (data) {
        var table = "<table border='1px'>";
        $.each(data, function (index, prod) {
            table += "<tr><th>Product</th></tr>";
            table += "<tr><td>Product ID : " + prod.ProductID + "</td></tr>";
            table += "<tr><td>ProductName : " + prod.ProductName + "</td></tr>";
            table += "<tr><td>Product Description :" + prod.ProductDescription + "</td></tr>";
            table += "<tr><td>Stock : " + prod.Stock + "</td></tr>";
            table += "<tr><td>APiKey : " + prod.ApiID + "</td></tr>";
        })
        table += "</table>";
        $("#divItems").html(table);
    });
}

