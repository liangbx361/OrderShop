<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="findpwd.aspx.cs" Inherits="web.findpwd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title><%=webset.WebName%></title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link href="css/login.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/userarea.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <ucl:Header ID="Header" runat="server" />
    <div id="main">
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="80%" height="20" id="path2">当前位置：<a href="/">邀您吃饭</a> > 密码找回</td>
    <td width="4%">&nbsp;</td>
    <td width="16%" id="path3">&nbsp;</td>
  </tr>
</table>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td valign="top"><div id="main_re" class="best">
    <div style="text-align:center;"><asp:Literal ID="L_msg" runat="server" EnableViewState="false"></asp:Literal></div>
<div id="re02">
<ul>
<li><h1>用户名：</h1><h2><input type="text" id="txtUserName" runat="server" maxlength="20" /></h2></li>
<li><h1>手机：</h1><h2><input type="text" id="txtMobile" runat="server" maxlength="11" /></h2></li>
<li><h1>邮箱：</h1><h2><input type="text" id="txtEmail" runat="server" maxlength="100" /></h2></li>
<li id="re05"><asp:Button ID="btnSubmit" runat="server" CssClass="new-btn-login" Text="确认提交" onclick="btnSubmit_Click" /></li>
</ul>
</div>
<div class="clearfloat"></div>
</div></td>
    </tr>
</table>
</div>
    <ucl:Footer ID="Footer" runat="server" />
    </form>
</body>
</html>
