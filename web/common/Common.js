/// <reference path="jQuery.1.2.6.zh-cn-vsdoc.js" />

//取得页面高度
function pageHeight() {
    return window.innerHeight != null ? window.innerHeight : document.documentElement && document.documentElement.clientHeight ? document.documentElement.clientHeight : document.body != null ? document.body.clientHeight : null;
}
//取得页面宽度
function pageWidth() {
    return window.innerWidth != null ? window.innerWidth : document.documentElement && document.documentElement.clientWidth ? document.documentElement.clientWidth : document.body != null ? document.body.clientWidth : null;
}

//全选
function chkall(ckbox, checkboxname) {
    $(":checkbox").each(function() {
        if (this.name.lastIndexOf(checkboxname) != -1) { this.checked = ckbox.checked; } 
    }
    );
}

//判断是否选中(复选框)一项
function isCheck(checkboxname) {
    var i = 0;
    $(":checkbox[@name:contains('" + checkboxname + "')]").each(function() {
        if (this.checked == true) {i++;return;}
    }
    );
    if(i>0) {return true;}
    else{alert('请选择一项，然后进行操作');return false;}
}

//提交判断公共函数
//提交判断--文本框

function IsListCheck() {
    var lst = document.getElementById('cblCategory').getElementsByTagName('input');
    
    var isCheck = false;
    if (lst.length > 0)
        for (var i = 0; i < lst.length; i++) {
        if (lst[i].checked) isCheck = true;
        continue;
    }
    return isCheck;
}
//提交判断--列表框
function CheckSelect(controlName) {
    if ( $("#" + controlName).get(0)==null || $.trim($("#" + controlName).attr("value")) == "" || $.trim($("#" + controlName).attr("value")) == "00") {
        $("#" + controlName).focus().blur(function() { outtips(); });
        return false;
    }
    return true;
}
//提交判断--上限与下限验证
function CheckLowertoUpper(controlNameLower,controlNameUpper) {
    if ($.trim($("#" + controlNameLower).attr("value")) != "00" && $.trim($("#" + controlNameUpper).attr("value")) == "00") {
        $("#" + controlNameUpper).focus().blur(function() { outtips(); });
        return false;
    }
    var a = $.trim($("#" + controlNameLower).attr("value"));
    var b = $.trim($("#" + controlNameUpper).attr("value"));
    a = Date.parse(new Date(a.replace(/-/g, "/")));
    b = Date.parse(new Date(b.replace(/-/g, "/")));
    if ( a > b ) {
        $("#" + controlNameUpper).focus().blur(function() { outtips(); });
        return false;
    }
    
    return true;
}
//提交判断--上限大于下限验证
function CheckUpperBigLower(controlNameUpper, controlNameLower) {    
    if ($.trim($("#" + controlNameLower).attr("value")) != "00" && $.trim($("#" + controlNameUpper).attr("value")) !== "00") {       
        if ($.trim($("#" + controlNameLower).attr("value")) > $.trim($("#" + controlNameUpper).attr("value"))) {
            $("#" + controlNameUpper).focus().blur(function() { outtips(); });
            return false;
        }
    }
    return true;
}


//提交判断--文本框不为空
function CheckEmpty(controlName) {
    if ($.trim($("#" + controlName).attr("value")) == "") {        
        return false;
    }
    return true;
}

//提交判断--身份证格式
function CheckIdCard(controlName,controlBirthday) {    
    var idReg =/^(\d{15}$|^\d{18}$|^\d{17}(\d|X|x))$/;
    if (!idReg.test($.trim($("#" + controlName).attr("value")))) {
        $("#" + controlName).focus().blur(function() { outtips(); });
        return false;
    }
    var a = $.trim($("#" + controlName).attr("value")).substring(6, 14);
    var b = $.trim($("#" + controlBirthday).attr("value")).substring(0, 4) + $.trim($("#" + controlBirthday).attr("value")).substring(5, 7) + $.trim($("#" + controlBirthday).attr("value")).substring(8, 10);
    if (a != b) {
        $("#" + controlName).focus().blur(function() { outtips(); });
        return false;
    }
    return true;
}


//日期格式的判断
function CheckDateTime(controlName) {
    if (CheckShortDateTime($("#" + controlName).attr("value")) || CheckLongDateTime($("#" + controlName).attr("value")) || $("#" + controlName).attr("value") == "") {
        return true;
    }
    else {
        $("#" + controlName).focus().blur(function() { outtips(); });
        return false;
    }
}
//1 短时间，形如 (13:04:06)
//function isTime(str) {
//    var a = str.match(/^(\d{1,2})(:)?(\d{1,2})\2(\d{1,2})$/);
//    if (a == null) { alert('输入的参数不是时间格式'); return false; }
//    if (a[1] > 24 || a[3] > 60 || a[4] > 60) {
//        alert("时间格式不对");
//        return false
//    }
//    return true;
//}

//2. 短日期，形如 (2008-07-22)
function CheckShortDateTime(str) {
    var r = str.match(/^(\d{1,4})(-|\/)(\d{1,2})\2(\d{1,2})$/);
    if (r == null) return false;
    var d = new Date(r[1], r[3] - 1, r[4]);
    return (d.getFullYear() == r[1] && (d.getMonth() + 1) == r[3] && d.getDate() == r[4]);
}

//3 长时间，形如 (2008-07-22 13:04:06)
function CheckLongDateTime(str) {
    var reg = /^(\d{1,4})(-|\/)(\d{1,2})\2(\d{1,2}) (\d{1,2}):(\d{1,2}):(\d{1,2})$/;
    var r = str.match(reg);
    if (r == null) return false;
    var d = new Date(r[1], r[3] - 1, r[4], r[5], r[6], r[7]);
    return (d.getFullYear() == r[1] && (d.getMonth() + 1) == r[3] && d.getDate() == r[4] && d.getHours() == r[5] && d.getMinutes() == r[6] && d.getSeconds() == r[7]);
}

///验证邮箱格式
function IsEmail(strEmail) {
    // if (strEmail.search(/^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$/) != -1) {
    if (strEmail.search(/\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*/) != -1) {
        return true;
    }
    else {
        return false;
    }
}

//验证手机号码
function IsMobile(s) {
    var regu = /^[1][3,5][0-9]{9}$/;
    var re = new RegExp(regu);
    if (re.test(s)) {
        return true;
    } else {
        return false;
    }
}

//验证电话号码
function IsPhone(strPhone) {
    var phoneRegWithArea = /^[0][1-9]{3,4}[-]?[0-9]{5,8}$/;
    var phoneRegNoArea = /^[1-9]{1}[0-9]{5,8}$/;
    if (strPhone.length > 9) {
        if (phoneRegWithArea.test(strPhone)) { return true; } else { return false; }
    } else {
        if (phoneRegNoArea.test(strPhone)) { return true; } else { return false; }
    }
}

//验证邮政号码
function IsPostCode(strPostalcode) {
    var postalcodeReg = /^[1-9]{1}[0-9]{5}$/;
    if (postalcodeReg.test(strPostalcode)) {
        return true;
    } else {
        return false; 
    }
}

//验证URL
function IsURL(strUrl) {
    var re = /(http[s]?|ftp):\/\/[^\/\.]+?\..+\w$/i;
    if (re.test(strUrl)) {
        return (true);
    } else {
        return (false);
    }
}

//验证INT类型
function IsInt(strInt) {
    var intReg = /^[1-9]{1}[0-9]{0,8}$/;
    if (intReg.test(strInt)) {
        return true;
    }
    else {
        return false; 
     }

 }
//限制输入最大字符数
function textCounter(field, countfield, maxlimit) {
    // 函数，3个参数，textarea对象，剩余字符数text对象，最大限制字符；
    if (field.value.length > maxlimit)
        //如果元素区字符数大于最大字符数，按照最大字符数截断；
        field.value = field.value.substring(0, maxlimit);
    else
        //在记数区文本框内显示剩余的字符数；
        countfield.value = maxlimit - field.value.length;
}
//验证输入最少字符数
function CheckTextCounter(controlName,  minlimit) {
    if ($.trim($("#" + controlName).attr("value")).length < minlimit) {
        $("#" + controlName).focus().blur(function() { outtips(); });
        return false;
    }        
}
//验证只能输入数字
function checkNumber(field) {
    //定义正则表达式部分
    //var reg = /^\d+$/; //只能输入数字
    var reg = /^\+?[1-9][0-9]*$/; //只能输入非零的正整数
    if (field.value.constructor == String) {
        var re = field.value.match(reg);
        var str = field.value.substring(0, field.value.length - 1);
        if (re == null && str.match(reg) == null) { re = ""; } //屏蔽粘贴或一次键入词组
        else if (re == null && str.match(reg) != null) { re = str; }//保留已录入的数字
        field.value = re;
    }
}

////验证只能输入汉字
//function checkChar(field) {
//    //定义正则表达式部分
//    var reg = /[^\u4E00-\u9FA5]/g;
//    if (field.value.constructor === String) {
//        var re = field.value.match(reg);
//        if (re == null) { re = "" }
//        field.value = re;
//    }
//}


////去左空格;
//function ltrim(s) {
//    return s.replace(/^\s*/, "");
//}
////去右空格;
//function rtrim(s) {
//    return s.replace(/\s*$/, "");
//}
////左右空格;
//function trim(s) {
//    return rtrim(ltrim(s));
//}

//调整编辑框的高度
function u_Size(num, objname) {
    var obj = document.getElementById(objname)
    if (parseInt(obj.rows) + num >= 3) {
        obj.rows = parseInt(obj.rows) + num;
    }
    if (num > 0) {
        obj.width = "90%";
    }
}

//调整FCK的高度
function resizeEditor(name, size) {
    var newheight = parseInt(document.getElementById(name + "___Frame").style.height, 10) + size;
    if (newheight >= 150) {
        document.getElementById(name + "___Frame").style.height = newheight + 'px';
    }
} 

function Trim(str) {
    if (str.charAt(0) == " ") {
        str = str.slice(1);
        str = Trim(str);
    }
    return str;
}

//判断是否为空
/*pObj 控件对象*/
/*errMsg 提示信息*/
function isEmpty(pObj, errMsg) {
    var obj = eval(pObj);
    if (obj == null || Trim(obj.value) == "") {
        if (errMsg == null || errMsg == "")
            alert("输入为空!");
        else
            alert(errMsg);
        obj.focus();
        return false;
    }
    return true;
}
/*pObj 控件对象*/
function Empty(pObj) {
    if (pObj == null || Trim(pObj.value) == "") {
        return true;
    }
    return false;
}

//显示错误信息
function ShowinnerHTML(pObj, iobj, errMsg) {
    iobj.className = "error";
    //iobj.innerHTML = "<img src=\"images/error.gif\" align=\"absmiddle\"> <font color=\"red\">" + errMsg + "</font>";
    iobj.innerHTML = "<font color=\"red\">" + errMsg + "</font>";
    pObj.focus();
}

//判断长度是否大于某个值
/*controlObj 控件对象
len 长度范围
*/
function LengthGT(controlObj, objlen) {
    if (controlObj.value.length > objlen) {
        return true;
    }
    return false;
}

//判断长度是否小于某个值
/*controlObj 控件对象
len 长度范围
*/
function LengthLT(controlObj, objlen) {
    if (controlObj.value.length < objlen) {
        return true;
    }
    return false;
}