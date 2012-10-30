<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userinfo.aspx.cs" Inherits="web.Users.userinfo" %>
<%@ Import Namespace="Cudo.Entities" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title><%=webset.WebName%></title>
    <link href="/css/style.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        #dh00 #dh05 a{color:#ff6600;font-weight:bold}
    </style>
    <link href="/common/Date/skin/WdatePicker.css" rel="stylesheet" type="text/css" />
    <script src="/common/Date/WdatePicker.js" type="text/javascript"></script>
    <script src="/js/jquery.js" type="text/javascript"></script>
    <script src="/js/userarea.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <ucl:Header ID="Header" runat="server" />
    <div id="main">
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="80%" height="20" id="path2">当前位置：<a href="/">首页</a> > 会员管理中心</td>
    <td width="4%">&nbsp;</td>
    <td width="16%" id="path3">&nbsp;</td>
  </tr>
</table>
<table width="100%" border="0" cellspacing="0" cellpadding="0" style="margin:10px 0">
  <tr>
    <td width="190" valign="top">
        <ucl:UserLeft ID="UserLeft" runat="server" />    
    </td>
    <td width="20">&nbsp;</td>
    <td valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0" height="31" background="/images/yncf_73.gif">
      <tr>
        <td width="2%">&nbsp;</td>
        <td width="79%">
<div id="me1">
<ul>
<li id="mee0" class="me3" onclick="javascript:self.location='userinfo.aspx'">个人资料</li>
<li id="mee1" class="me2" onclick="javascript:self.location='editpassword.aspx'">修改密码</li>
<li id="mee2" class="me2" onclick="javascript:self.location='useraddress.aspx'">地址管理</li>
</ul>
</div>
</td>
        <td width="19%">&nbsp;</td>
      </tr>
    </table>
<div style="padding:30px 60px;">
<!--内容-->
<table width="100%" border="0" cellspacing="0" cellpadding="0" id="mse0" class="afds">
  <tr>
    <td height="30" colspan="2" align="center" style="border-bottom:1px dashed #d9dada">完善个人资料，有助于我们根据您的情况提供更加个性化的服务;邀您吃饭网会对您的个人资料隐私加以保密。</td>
    </tr>
  <tr>
    <td width="78%" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td width="85" height="35" align="right">用户名：</td>
        <td width="10" rowspan="10">&nbsp;</td>
        <td><span style="color:#cc0000;"><%UserInfo item = Session["cudoUser"] as UserInfo; %> <%=item.UserName %></span>&nbsp;<%=GetGroupName(item.UserGroup) %></td>
      </tr>
      <tr>
        <td height="35" align="right">邮箱：</td>
        <td><input type="text" size="25" id="txt_Email" runat="server" />
        </td>
      </tr>
      <tr>
        <td height="35" align="right">昵称：</td>
        <td><input type="text" size="25" id="txt_NickName" runat="server" /></td>
      </tr>
      <tr>
        <td height="35" align="right">姓别：</td>
        <td>
            <asp:RadioButtonList ID="rdogender" runat="server" RepeatColumns="2">
                <asp:ListItem Value="0" Text="男" Selected="True"></asp:ListItem>
                <asp:ListItem Value="1" Text="女"></asp:ListItem>
            </asp:RadioButtonList>
        </td>
      </tr>
      <tr>
        <td height="35" align="right">手机号：</td>
        <td><input type="text" size="25" id="txt_Mobile" runat="server" maxlength="11" /></td>
      </tr>
      <tr>
        <td height="35" align="right">生日：</td>
        <td><input type="text" size="25" id="txt_BirthDay" runat="server" class="Wdate" onfocus="WdatePicker({maxDate:'%y-%M-%d'})" /></td>
      </tr>
      <tr>
        <td>&nbsp;</td>
        <td height="50" style="padding-left:40px;">
            <asp:LinkButton ID="btnSubmit" runat="server" onclick="btnSubmit_Click"><img src="/images/yncf_83.gif" width="75" height="25" /></asp:LinkButton>
        </td>
      </tr>
    </table></td>
  </tr>
</table>
</div>
</td>
  </tr>
</table>

</div>
    <ucl:Footer ID="Footer" runat="server" />
    </form>
</body>
</html>
