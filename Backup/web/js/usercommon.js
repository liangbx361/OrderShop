function showintro(e) {
    if (e == 1) {
        $("#shopintro").show();
    } else {
        $("#shopintro").hide();
    }
}

function openpage(i) {
    var shopid = $("#hidden_shopid").val();
    var jumpurl = "";
    switch (i) {
        case 0:
            jumpurl = "shopinfo.aspx?shopid=" + shopid;
            break;
        case 1:
            jumpurl = "shoporderlist.aspx?shopid=" + shopid;
            break;
        case 2:
            jumpurl = "shopcommentlist.aspx?shopid=" + shopid;
            break;
        default: break;
    }
    window.self.location = jumpurl;
}

function checksub() {
    if (!checklogin()) {
        return false;
    }
    if ($("#ddltaste").val() == "0") {
        alert("请给它的口味打分");
        return false;
    } else if ($("#ddlmilieu").val() == "0") {
        alert("请给它的环境打分");
        return false;
    } else if ($("#ddlservice").val() == "0") {
        alert("请给它的服务打分");
        return false;
    } else if ($("#txtcontent").val() == "") {
        alert("请填写您的评价");
        return false;
    } else {
        return true;
    }
}

function checkAll(e) {
    if (e.checked) {
        $(".checkall input").attr("checked", true);
    } else {
        $(".checkall input").attr("checked", false);
    }
}

function copyurl() {
    var url = $("#joinurl").val();
    if (url.indexOf("userid=") > -1) {
        var temp = url;
        copyToClipboard(temp);
    }
}

function copyToClipboard(txt) {
    if (window.clipboardData) {
        window.clipboardData.clearData();
        window.clipboardData.setData("Text", txt);
    }
    else if (navigator.userAgent.indexOf("Opera") != -1) {
        window.location = txt;
    }
    else if (window.netscape) {
        try {
            netscape.security.PrivilegeManager.enablePrivilege("UniversalXPConnect");
        } catch (e) {
            alert("如果您正在使用FireFox！\n请在浏览器地址栏输入'about:config'并回车\n然后将'signed.applets.codebase_principal_support'设置为'true'");
        }
        var clip = Components.classes['@mozilla.org/widget/clipboard;1'].createInstance(Components.interfaces.nsIClipboard);
        if (!clip) return;
        var trans = Components.classes['@mozilla.org/widget/transferable;1'].createInstance(Components.interfaces.nsITransferable);
        if (!trans) return;
        trans.addDataFlavor('text/unicode');
        var str = new Object();
        var len = new Object();
        var str = Components.classes["@mozilla.org/supports-string;1"].createInstance(Components.interfaces.nsISupportsString);
        var copytext = txt;
        str.data = copytext;
        trans.setTransferData("text/unicode", str, copytext.length * 2);
        var clipid = Components.interfaces.nsIClipboard;
        if (!clip) return false;
        clip.setData(trans, null, clipid.kGlobalClipboard);
    }
} 