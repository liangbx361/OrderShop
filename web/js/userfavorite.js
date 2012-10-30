function checklogin() {
    if (!document.getElementById("userinfo")) {
        alert("您还未登录，请先登录!");
        return false;
    } else {
        return true;
    }
}

function favoriteshop(shopid) {
    if (!checklogin()) {
        return;
    } else {
        $.ajax({
            type: "get",
            dataType: "json",
            url: '/ashx/UserFavorite.ashx',
            data: { "shopid": shopid },
            async: true,
            success: function(json) {
                if (json.types == "0") {
                    alert(json.msg);
                    return false;
                }
                alert(json.msg);
                return true;
            }
        });
    }
}