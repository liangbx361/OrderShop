<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="web.login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title><%=webset.WebName%></title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link href="css/login.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/userarea.js" type="text/javascript"></script>
    <style type="text/css">
    #menu #menu3 a{background:url(images/yncf_07.gif);font-weight:bold;color:#FFF;}
    #dh00 #dh01 a{color:#ff6600;font-weight:bold}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <ucl:Header ID="Header" runat="server" />
    <div id="main">
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="80%" height="20" id="path2">当前位置：<a href="/">邀您吃饭</a> > 会员登录</td>
    <td width="4%">分享：</td>
    <td width="16%" id="path3"><a href="#"><img src="images/yncf_50.gif" width="19" height="24" /></a><a href="#"><img src="images/yncf_51.gif" width="20" height="24" /></a><a href="#"><img src="images/yncf_52.gif" width="20" height="24" /></a><a href="#"><img src="images/yncf_53.gif" width="20" height="24" /></a><a href="#"><img src="images/yncf_54.gif" width="20" height="24" /></a><a href="#"><img src="images/yncf_55.gif" width="20" height="24" /></a></td>
  </tr>
</table>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td valign="top"><div id="lo01">
<div id="lo02">
<div id="lo04">
<ul>
<li><h1>用户名：</h1><h2><input type="text" id="username" runat="server" class="text_lo"/></h2></li>
<li><h1>密码：</h1><h2><input type="password" id="upassword" runat="server" class="text_lo" /></h2></li>
<li><h1>&nbsp;</h1><h2><input type="checkbox" name="CheckboxGroup1" id="chkusername" runat="server" class="checkboxGroup_lo"/><span>记住用户名</span><span style="padding-left:10px;"><a href="findpwd.aspx">忘记密码？</a></span></h2></li>
<li><h1>&nbsp;</h1><h2><asp:LinkButton ID="btnLogin" runat="server" onclick="btnLogin_Click"><img src="images/lo01.gif" width="79" height="35" /></asp:LinkButton></h2>
</li>
<li><h1>&nbsp;</h1>
</li>
</ul>
</div>
</div>
<div id="lo03">
<div id="lo07">
<strong>您还不是本站会员？</strong><BR />现在免费注册成为用户，<br />便能立刻享受便宜又放心的订餐乐趣。<BR />
<a href="register.aspx"><img src="images/lo04.gif" width="117" height="36" /></a></div>
</div>
</div></td>
    </tr>
</table>
</div>
    <ucl:Footer ID="Footer" runat="server" />
    </form>
    <script type="text/javascript">
        function document.onkeydown() {
            if (event.keyCode == 13) {
                document.getElementById("btnLogin").click();
                return false;
            }
        }
    </script>
</body>
</html>
