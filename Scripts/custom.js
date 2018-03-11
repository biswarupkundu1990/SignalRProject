//alert("ok");
//start hub

//$("#logoutall").unbind("click").bind("click", function () {

//    $.connection.myHub.server.logoutall();
        
//})


$.connection.hub.start().
    done(function () {
        console.log("working");
        $.connection.myHub.server.allowclient("This is a test message to Myhub");
        //$.connection.myHub.server.logoutall();
        //location.reload();
    }).
    fail(function () {
        console.log("error");
    });

$.connection.myHub.client.allowclient = function (msg) {
    
    console.log(msg);
}
$.connection.myHub.client.logoutall = function () {
    logoutAll();
}

// ajax part
function logoutAll() {
    console.log("response to logout")
    var model = $('#dataTable');
    $.ajax({
        url: '/Account/AsyncLogOff',
        type: 'post'        
    })
        .success(function (result) { location.reload(); })
    //.error(function (e) { alert(e); });
}