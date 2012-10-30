<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="top.aspx.cs" Inherits="web.admin.top" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title></title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
body{margin:0;background:url(images/admin_tbg.png) repeat-x;padding:0; color:#fff;font-family:宋体,arial; font-size:12px }
</style>
</head>
<body>
    <script type="text/javascript">
    function displaytime() {
        var time = new Date(); //获取当前时间
        var year = time.getYear();
        var month = time.getMonth();
        var day = time.getDate();
        var week = time.getDay();
        var hour = time.getHours();
        var minute = time.getMinutes();
        var second = time.getSeconds();
        var str = "";
        switch (week) {
            case 0: str = "星期天"; break;
            case 1: str = "星期一"; break;
            case 2: str = "星期二"; break;
            case 3: str = "星期三"; break;
            case 4: str = "星期四"; break;
            case 5: str = "星期五"; break;
            case 6: str = "星期六"; break;
            default: str = ""; break;
        }
        //设置文本框的内容为当前时间
        document.getElementById("myclock").innerHTML = "今天是：" + time.toLocaleDateString() + "\r\r" + str + "\r\r" + hour + ":" + (minute < 10 ? "0" + minute : minute) + ":" + (second < 10 ? "0" + second : second);
        //设置定时器每隔1000毫秒，调用函数displaytime()执行，刷新时钟显示
        var myTime = setTimeout("displaytime()", 1000);
    }
    //window.onload = displaytime();
</script>
<div class="logo">
<div class="s1"><div style="float:right;"><%=GetMenu() %></div></div>
<div class="s2"><span id="myclock"><script type="text/javascript">displaytime()</script></span><span><a href="javascript:void(0)" onclick="if(confirm('您确定退出？'))javascript:top.location.href='logout.aspx'"><img src="images/ico2.gif" style="border:0px;" align="absmiddle" title="退出" />退出</a></span>
<span style="color:#1796E0;padding-right:5px;"><a href="/" target="_blank">前台首页</a>|<a href="userpass.aspx" target="main">修改密码</a></span></div>
</div>
</body>
</html>
