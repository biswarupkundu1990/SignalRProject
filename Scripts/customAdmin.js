//alert("ok");
//start hub

$("#logoutall").unbind("click").bind("click", function () {

    $.ajax({
        url: "/Account/Randomlogout",
        type: "get",
        success: function (d) {

        }
    })

})


