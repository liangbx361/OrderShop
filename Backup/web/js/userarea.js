function loadstreet(pid) {
    $(".area span").removeClass("qy");
    $("#a" + pid).addClass("qy");
    $("#hidden_aid").attr("value", pid);
    $("#useladdress").html($("#a" + pid).html());
    $.ajax({
        type: "POST",
        url: "/ashx/ShopAreaHandler.ashx?action=street&pid=" + pid + "&A=" + Math.random(),
        success: function(returnData) {
            $("#city_street").html(returnData);
        }
    });
    refresh(pid);
}

function district(pid) {
    var district = $("#district" + pid);
    var aid = district.attr("rel");
    $("#city_district span").removeClass("qy");
    $("#z").addClass("qy");
    $("#city_street a").removeClass("current");
    district.addClass("current");
    $("#hidden_aid").attr("value", aid);
    $("#hidden_sid").attr("value", pid);
    $("#useladdress").html($("#a" + aid).html() + district.html());
    $.ajax({
        type: "POST",
        url: "/ashx/ShopAreaHandler.ashx?action=district&pid=" + pid + "&A=" + Math.random(),
        success: function(returnData) {
            $("#path1").html(returnData);
        }
    });
}

function seldistrict(did, sid, dname) {
    var aid = $("#district" + sid).attr("rel");
    $("#hidden_aid").attr("value", aid);
    $("#hidden_sid").attr("value", sid);
    $("#hidden_did").attr("value", did);
    $("#useladdress").html($("#a" + aid).html() + $("#district" + sid).html() + dname);
}

function refresh(pid) {
    $.ajax({
        type: "POST",
        url: "/ashx/ShopAreaHandler.ashx?action=s-d&pid=" + pid + "&A=" + Math.random(),
        success: function(returnData) {
            $("#path1").html(returnData);
        }
    });
}

function seltZM(zm) {
    var dqid = $("#hidden_aid").attr("value");
    var sid = $("#hidden_sid").attr("value");
    $("#city_district span").removeClass("qy");
    $("#z" + zm).addClass("qy");
    $.ajax({
        type: "POST",
        url: "/ashx/ShopAreaHandler.ashx?action=d-zm&pid=" + dqid + "&sid=" + sid + "&zm=" + zm + "&A=" + Math.random(),
        success: function(returnData) {
            $("#path1").html(returnData);
        }
    });
}

function seltZM1(zm) {
    var dqid = $("#hiddenaid").attr("value");
    var sid = $("#hiddensid").attr("value");
    $("#city_district span").removeClass("qy");
    $("#z" + zm).addClass("qy");
    $.ajax({
        type: "POST",
        url: "/ashx/ShopAreaHandler.ashx?action=d-zm&pid=" + dqid + "&sid=" + sid + "&zm=" + zm + "&ot=1&A=" + Math.random(),
        success: function(returnData) {
            $("#path1").html(returnData);
            $("#s1").css("display", "block");
            $("#img1").attr("src", "images/yncf_33.GIF");
        }
    });
}

function seltZM2(zm) {
    var dqid = $("#hiddenaid").attr("value");
    var sid = $("#hiddensid").attr("value");
    $("#city_district span").removeClass("qy");
    $("#z" + zm).addClass("qy");
    $.ajax({
        type: "POST",
        url: "/ashx/ShopAreaHandler.ashx?action=d-zm&pid=" + dqid + "&sid=" + sid + "&zm=" + zm + "&ot=2&A=" + Math.random(),
        success: function(returnData) {
            $("#path1").html(returnData);
            $("#s1").css("display", "block");
            $("#img1").attr("src", "images/yncf_33.GIF");
        }
    });
}

function deleteitem(e) {
    if (ShowConfirm("您确定要删除吗？")) {
        $.ajax({
            type: "POST",
            url: "/ashx/ShopAreaHandler.ashx?action=delete&areaid=" + e + "&A=" + Math.random(),
            success: function(returnData) {
                if (returnData == "0")
                    alert("删除失败!");
                else
                    window.self.location = "takeawayinfo.aspx";
            }
        });
    }
}

function ShowConfirm(text) {
    return confirm(text);
}

function subaddress() {
    var aid = $("#hidden_aid").attr("value");
    var sid = $("#hidden_sid").attr("value");
    var did = $("#hidden_did").attr("value");
    if (did == 0) {
        alert("请选择楼宇!");
        return;
    } else {
        $.ajax({
            type: "POST",
            url: "/ashx/ModifyHandler.ashx?action=sendadd&aid=" + aid + "&sid=" + sid + "&did=" + did + "&A=" + Math.random(),
            success: function(returnData) {
                if (returnData == "0")
                    alert("未知错误,请重新操作!");
                else
                    window.parent.self.location = "shoplist.aspx?aid=" + aid + "&sid=" + sid + "&did=" + did;
            }
        });
        //window.parent.self.location = "shoplist.aspx?aid=" + aid + "&sid=" + sid + "&did=" + did;
    }
}

function searchbykey(e) {
    if (e == "请输入您所在的小区/楼宇" || e == "") {
        $("#searchlist").hide();
    } else {
        $.ajax({
            type: "POST",
            url: "/ashx/ShopAreaHandler.ashx?action=search&keyword=" + e + "&A=" + Math.random(),
            success: function(returnData) {
                if (returnData != "") {
                    $("#searchlist").html(returnData);
                    $("#searchlist").show();
                }
            }
        });
    }
}

function selsearchval(e) {
    $("#searchkeyword").attr("value", e);
    $("#searchlist").hide();
}


$(function() {
    var pholder1 = "请输入您所在的小区/楼宇";
    $("#searchkeyword").val(pholder1).blur(function() {
        if ($(this).val() == '')
            $(this).val(pholder1);
    }).focus(function() {
        $(this).val('');
        $("#searchlist").hide();
    });
});