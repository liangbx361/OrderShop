<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="shopinfo.aspx.cs" Inherits="web.Shops.shopinfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title><%=webset.WebName%></title>
    <link href="/css/style.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        #dh00 #dh01 a{color:#ff6600;font-weight:bold}
        .inpu{border:1px solid #cbcbcb;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <ucl:Header ID="Header" runat="server" />
    <div id="main">
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="80%" height="20" id="path2">当前位置：<a href="/">首页</a> > 商家管理中心</td>
    <td width="4%"></td>
    <td width="16%" id="path3"></td>
  </tr>
</table>
<table width="100%" border="0" cellspacing="0" cellpadding="0" style="margin:10px 0">
  <tr>
    <td width="190" valign="top"><ucl:UserLeft2 ID="UserLeft2" runat="server" />
    </td>
    <td width="20">&nbsp;</td>
    <td valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0" height="31" background="/images/yncf_73.gif">
      <tr>
        <td width="2%">&nbsp;</td>
        <td width="79%">
        <div id="me1">
        <ul>
        <li id="mee0" class="me3" onclick="mee(0)">商家基本信息</li>
        </ul>
        </div>
        </td>
        <td width="19%">&nbsp;</td>
      </tr>
    </table>
<table width="100%" border="0" cellspacing="0" cellpadding="0" style="margin-top:20px;font-size:14px">
  <tr>
    <td width="120" height="30" align="right">餐厅名称：</td>
    <td width="10" rowspan="6">&nbsp;</td>
    <td><input type="text" size="30" name="shopname" id="shopname" runat="server" class="inpu" readonly /></td>
  </tr>
  <tr>
    <td height="30" align="right">具体地址：</td>
    <td><input type="text" size="30" name="address" id="address" runat="server" class="inpu" readonly /></td>
  </tr>
  <tr>
    <td height="30" align="right">电话：</td>
    <td><input type="text" size="20" name="phone" id="phone" runat="server" class="inpu" readonly /></td>
  </tr>
  <tr>
    <td height="30" align="right">简介：</td>
    <td><textarea name="intro" id="intro" runat="server" rows="5" cols="50"></textarea></td>
  </tr>
</table>
</td>
  </tr>
</table>

</div>
    <ucl:Footer ID="Footer" runat="server" />
    </form>
</body>
</html>
