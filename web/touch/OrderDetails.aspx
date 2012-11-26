<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderDetails.aspx.cs" Inherits="web.touch.OrderDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title></title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div align=center><h2>送餐时间:<%=remark%></h2></div>
    <div style="padding:6px 0;">
    <table width="100%" border="0" cellspacing="1" cellpadding="4" bgcolor="#e8e8e8">
      <tr style="font-weight:bold; ">
        <td align="center" bgcolor="#f3f3f3">餐品名称</td>
        <td align="center" bgcolor="#f3f3f3" width="100">单价</td>
        <td align="center" bgcolor="#f3f3f3" width="80">购买数量</td>
        <td align="center" bgcolor="#f3f3f3" width="100">小计</td>
      </tr>
        <asp:Repeater ID="rp_OrderList" runat="server" EnableViewState="false">
            <ItemTemplate>
                <tr>
                    <td style="padding:5px;" bgcolor="#FFFFFF" align="center">
                    <%#Eval("ProductName")%></td>
                    <td align="center" bgcolor="#FFFFFF" width="100">￥<%#Eval("Price")%></td>
                    <td bgcolor="#FFFFFF" align="center" width="80"><%#Eval("BuyNum")%></td>
                    <td align="center" bgcolor="#FFFFFF" width="100">￥<%#Eval("TotalPrice")%></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    </div>
    </form>
</body>
</html>
