<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="shoporderinfo.aspx.cs" Inherits="web.Shops.shoporderinfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <link href="/css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
          <td height="33" align="left" bgcolor="#f3f3f3" class="se" style="font-size:14px;padding-left:0">&nbsp;&nbsp;订单号：<%=orderno %></td>
        </tr>
</table><table width="80%" border="0" cellspacing="0" cellpadding="0" style="margin:20px auto;font-size:14px" class="qerqwer" >
  <tr>
    <td width="16%" height="35" align="right"><strong>订单时间</strong>：</td>
    <td width="51%" style="padding-left:10px;"><asp:Literal ID="L_OrderTime" runat="server" EnableViewState="false"></asp:Literal></td>
    <td width="31%" align="center"><strong>餐品名称</strong></td>
  </tr>
  <tr>
    <td align="right"><strong>送餐地址</strong>：</td>
    <td style="padding:10px;line-height:20px"><asp:Literal ID="L_Address" runat="server" EnableViewState="false"></asp:Literal></td>
    <td rowspan="5" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0" class="adfadf">
      <tr>
        <td height="10"></td>
      </tr>
      <asp:Repeater ID="rpt_list" runat="server" EnableViewState="false"><ItemTemplate>
      <tr>
        <td height="25" align="right" style="padding-right:15px;font-size:12px"><%#Eval("ProductName")%>(<strong style="color:#C00"><%#Eval("BuyNum")%></strong>)</td>
      </tr>
      </ItemTemplate></asp:Repeater> 
      <tr>
        <td height="10"></td>
      </tr>
      <tr>
        <td height="30" align="right" style="padding:0 5px;"><div style="line-height:30px;border-top:1px dashed #CCC"><strong>共计</strong>：<span style="color:#C00;font-weight:bold"><asp:Literal ID="L_OrderCount" runat="server" EnableViewState="false"></asp:Literal></span><strong>份</strong><br /><strong>金额</strong>：<span style="color:#C00;font-weight:bold"><asp:Literal ID="L_SumPrice" runat="server" EnableViewState="false"></asp:Literal></span><strong>元</strong></div></td>
      </tr>
    </table></td>
  </tr>
  <tr>
    <td height="35" align="right"><strong>订单金额</strong>：</td>
    <td style="padding-left:10px;"><asp:Literal ID="L_OrderPrice" runat="server" EnableViewState="false"></asp:Literal>元</td>
  </tr>
  <tr>
    <td height="35" align="right"><strong>联系人</strong>：</td>
    <td style="padding-left:10px;"><asp:Literal ID="L_UserName" runat="server" EnableViewState="false"></asp:Literal></td>
  </tr>
  <tr>
    <td height="35" align="right"><strong>电话</strong>：</td>
    <td style="padding-left:10px;"><asp:Literal ID="L_Phone" runat="server" EnableViewState="false"></asp:Literal></td>
  </tr>
  <tr>
    <td height="35" align="right"><strong>送餐时间</strong>：</td>
    <td style="padding-left:10px;"><asp:Literal ID="L_SendTime" runat="server" EnableViewState="false"></asp:Literal></td>
  </tr>
</table>
    </form>
</body>
</html>
