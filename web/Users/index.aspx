<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="web.Users.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title><%=webset.WebName%></title>
    <link href="/css/style.css" rel="stylesheet" type="text/css" />
    <link href="/css/thickbox.jquery.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery.js" type="text/javascript"></script>
    <script src="/js/thickbox.jquery.js" type="text/javascript"></script>
    <script src="/js/userarea.js" type="text/javascript"></script>
    <style type="text/css">
        #dh00 #dh01 a{color:#ff6600;font-weight:bold}
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
        <li id="mee0" class="me3" onclick="javascript:self.location='index.aspx'">今日订单</li>
        <li id="mee1" class="me2" onclick="javascript:self.location='myorderlist.aspx'">历史订单</li>
        </ul>
        </div>
        </td>
        <td width="19%">&nbsp;</td>
      </tr>
    </table>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="margin-top:10px" id="mse0">
        <tr>
          <td height="30" bgcolor="#f3f3f3" style="border-top:1px solid #dedee0">
          <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
              <td width="15%" height="30" align="center"><strong>订单号</strong></td>
              <td width="20%" align="center"><strong>餐厅名称</strong></td>
              <td width="25%" align="center"><strong>订单时间</strong></td>
              <td width="15%" align="center"><strong>订单金额</strong></td>
              <td width="10%" align="center"><strong>操作</strong></td>
            </tr>
          </table></td>
        </tr>
        <tr>
          <td>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="sem">
            <asp:Repeater ID="rpt_list" runat="server" EnableViewState="false"><ItemTemplate>
            <tr>
              <td width="15%"  height="30" align="center"><a href="orderinfo.aspx?orderno=<%#Eval("OrderNo") %>&keepThis=true&TB_iframe=true" style="color:#1d54a5" class="thickbox"><%#Eval("OrderNo")%></a></td>
              <td width="20%" align="center"><a href="/shopinfo.aspx?shopid=<%#Eval("ShopId") %>"><%#GetShopName(Eval("ShopId"))%></a></td>
              <td width="25%" align="center"><%#Eval("AddTime")%></td>
              <td width="15%" align="center"><%#Eval("TotalPrice")%>元</td>
              <td width="10%" align="center"><a href="createcomment.aspx?shopid=<%#Eval("ShopId") %>" style="color:#1d54a5">评论</a></td>
            </tr>
            </ItemTemplate></asp:Repeater>
            </table>
        </td>
        </tr>
        <tr>
          <td height="10"></td>
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
