function VialdUserName() {
    var username = $("#txtUserName").val();
    var name_reg = /^[\da-z]*$/;
    var name_reg_start_with_az = /^[a-z][\da-z]*$/;
    if (username == "") {
        $("#c_username").removeClass();
        $("#c_username").addClass("reg-error");
        $("#c_username").html("用户名不能为空");
        return false;
    } else if (!username.match(name_reg_start_with_az)) {
        $("#c_username").removeClass();
        $("#c_username").addClass("reg-error");
        $("#c_username").html("请用小写字母开头");
        return false;
    } else if (!(username.length >= 5 && username.length <= 20)) {
        $("#c_username").removeClass();
        $("#c_username").addClass("reg-error");
        $("#c_username").html("用户名长度不在指定范围内，请输入5-20个字符");
        return false;
    } else if (isUserNameused(username)) {
        $("#c_username").removeClass();
        $("#c_username").addClass("reg-error");
        $("#c_username").html("用户名已被使用，请更换");
        return false;
    } else {
        $("#c_username").removeClass();
        $("#c_username").addClass("reg-right");
        $("#c_username").html("可用的用户名");
        return true;
    }
}

function isUserNameused(username) {
    var flag = false;
    $.ajax({
        type: "get",
        url: "/ashx/UserReg.ashx?action=name&username=" + username,
        cache: false,
        async: false,
        dataType: "text",
        success: function(data) {
            if (data == "1")
                flag = true;
        }
    });
    return flag;
}

function VialdPass() {
    var pass = $("#txtPass").val();
    if (pass == "") {
        $("#c_pass").removeClass();
        $("#c_pass").addClass("reg-error");
        $("#c_pass").html("请输入密码");
        return false;
    } else if (!(pass.length >= 6 && pass.length <= 20)) {
        $("#c_pass").removeClass();
        $("#c_pass").addClass("reg-error");
        $("#c_pass").html("密码长度不在指定范围内，请输入6-20位");
        return false;
    } else {
        $("#c_pass").removeClass();
        $("#c_pass").addClass("reg-right");
        $("#c_pass").html("输入正确");
        return true;
    }
}

function VialdPass2() {
    var pass = $("#txtPass2").val();
    if (pass == "") {
        $("#c_pass2").removeClass();
        $("#c_pass2").addClass("reg-error");
        $("#c_pass2").html("请再次输入密码");
        return false;
    } else if (pass != $("#txtPass").val()) {
        $("#c_pass2").removeClass();
        $("#c_pass2").addClass("reg-error");
        $("#c_pass2").html("两次密码输入不一致");
        return false;
    } else {
        $("#c_pass2").removeClass();
        $("#c_pass2").addClass("reg-right");
        $("#c_pass2").html("输入正确");
        return true;
    }
}

function ismobileused(mobile) {
    var flag = false;
    $.ajax({
        type: "get",
        url: "/ashx/UserReg.ashx?action=mobile&mobile=" + mobile,
        cache: false,
        async: false,
        dataType: "text",
        success: function(data) {
            if (data == "1")
                flag = true;
        }
    });
    return flag;
}

function VialdMobile() {
    var mobile = $("#txtMobile").val();
    var mobile_reg = /^[1][3,5,8][0-9]{9}$/;
    if (mobile == "") {
        $("#c_mobile").removeClass();
        $("#c_mobile").addClass("reg-error");
        $("#c_mobile").html("请输入手机");
        return false;
    } else if (!mobile.match(mobile_reg)) {
        $("#c_mobile").removeClass();
        $("#c_mobile").addClass("reg-error");
        $("#c_mobile").html("手机号输入错误");
    } else if (ismobileused(mobile)) {
        $("#c_mobile").removeClass();
        $("#c_mobile").addClass("reg-error");
        $("#c_mobile").html("手机号已存在,请更换!");
    } else {
        $("#c_mobile").removeClass();
        $("#c_mobile").addClass("reg-right");
        $("#c_mobile").html("输入正确");
        return true;
    }
}

function isemailused(email) {
    var flag = false;
    $.ajax({
        type: "get",
        url: "/ashx/UserReg.ashx?action=email&email=" + email,
        cache: false,
        async: false,
        dataType: "text",
        success: function(data) {
            if (data == "1")
                flag = true;
        }
    });
    return flag;
}

function VialdEmail() {
    var email = $("#txtEmail").val();
    var email_reg = /\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*/;
    if (email == "") {
        $("#c_email").removeClass();
        $("#c_email").addClass("reg-error");
        $("#c_email").html("请输入邮箱");
        return false;
    } else if (!email.match(email_reg)) {
        $("#c_email").removeClass();
        $("#c_email").addClass("reg-error");
        $("#c_email").html("邮箱格式输入错误!");
    } else if (isemailused(email)) {
        $("#c_email").removeClass();
        $("#c_email").addClass("reg-error");
        $("#c_email").html("邮箱已被使用,请更换!");
    } else {
        $("#c_email").removeClass();
        $("#c_email").addClass("reg-right");
        $("#c_email").html("输入正确");
        return true;
    }
}

function VialdCode() {
    var verifycode = $("#txtCode").val();
    var flag = false;
    $.ajax({
        type: "get",
        url: "/ashx/UserReg.ashx?action=code&verifycode=" + verifycode,
        cache: false,
        async: false,
        dataType: "text",
        success: function(data) {
            if (data == "1") {
                $("#c_code").removeClass().addClass("reg-right");
                $("#c_code").html("输入正确");
                flag = true;
            } else {
                $("#c_code").removeClass().addClass("reg-error");
                $("#c_code").html("验证码输入错误");
                flag = false;
            }
        }
    });
    return flag;
}

function VialdCheck() {
    if ($("#chkagreement").attr("checked") == true) {
        return true;
    } else {
        alert("您还未同意用户协议!");
        return false;
    }
}

function CheckAll() {
    if (VialdUserName() && VialdPass() && VialdPass2() && VialdMobile() && VialdEmail() && VialdCode() && VialdCheck()) {
        return true;
    } else {
        return false;
    }
}