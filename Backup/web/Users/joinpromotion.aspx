<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="joinpromotion.aspx.cs" Inherits="web.Users.joinpromotion" %>
<%@ Import Namespace="Cudo.Entities" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title><%=webset.WebName%></title>
    <link href="/css/style.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery.js" type="text/javascript"></script>
    <script src="/js/userarea.js" type="text/javascript"></script>
    <style type="text/css">
        #dh00 #dh03 a{color:#ff6600;font-weight:bold}
    </style>
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
        <li id="mee0" class="me2" onclick="javascript:self.location='myuserlist.aspx'">推广会员列表</li>
        <li id="mee1" class="me3" onclick="javascript:self.location='joinpromotion.aspx'">我的推广链接</li>
        </ul>
        </div>
        </td>
        <td width="19%">&nbsp;</td>
      </tr>
    </table>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="margin-top:50px;color:#666">
  <tr>
    <td height="30" colspan="2" style="font-weight:bold;padding-left:50px;">复制以下链接通过MSN、QQ或论坛等方式发送给您的朋友</td>
    </tr>
  <tr>
    <td width="81%" height="30" style="padding-left:50px;">
    <%UserInfo item = Session["cudoUser"] as UserInfo; %>
    <input type="text" id="joinurl" value="http://www.107fan.com/register.aspx?userid=<%=item.Id %>" size="80" readonly="readonly" style="color:#666;height:20px;line-height:20px;"/></td>
    <td width="19%" height="30"><img src="/images/yncf_77.gif" width="80" height="28" style="cursor:pointer;" onclick="copyurl()" /></td>
  </tr>
  <tr>
    <td height="35" colspan="2" style="padding-left:50px;">如果点击"复制链接"按钮没反应，请全选链接"ctrl+c"复制此链接</td>
    </tr>
</table>
</td>
  </tr>
</table>
</div>
    <ucl:Footer ID="Footer" runat="server" />
    </form>
    <script src="/js/usercommon.js" type="text/javascript"></script>
</body>
</html>
