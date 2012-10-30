<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="shoporderlist.aspx.cs" Inherits="web.Shops.shoporderlist" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title><%=webset.WebName%></title>
    <link href="/css/style.css" rel="stylesheet" type="text/css" />
    <link href="/css/thickbox.jquery.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery.js" type="text/javascript"></script>
    <script src="/js/thickbox.jquery.js" type="text/javascript"></script>
    <style type="text/css">
        #dh00 #dh04 a{color:#ff6600;font-weight:bold}
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
<li id="mee0" class="me3" onclick="mee(0)">订单查询</li>
</ul>
</div>
</td>
        <td width="19%">&nbsp;</td>
      </tr>
    </table><table width="100%" border="0" cellspacing="0" cellpadding="0" style="margin-top:10px">
  <tr>
    <td width="30" rowspan="2">&nbsp;</td>
    <td height="35">楼宇小区：
<asp:DropDownList ID="ddl_district" runat="server"></asp:DropDownList>&nbsp;
订单状态：<asp:DropDownList ID="ddl_orderstatus" runat="server">
    <asp:ListItem Value="" Text="-请选择-"></asp:ListItem>
    <asp:ListItem Value="0" Text="未处理"></asp:ListItem>
    <asp:ListItem Value="1" Text="处理中"></asp:ListItem>
    <asp:ListItem Value="2" Text="已完成"></asp:ListItem>
    <asp:ListItem Value="3" Text="作废"></asp:ListItem>
    </asp:DropDownList>
    &nbsp;<asp:Button ID="btnsearch" runat="server" Text="查询" onclick="btnsearch_Click" />
 </td>
  </tr>
</table>
<table width="100%" border="0" cellspacing="0" cellpadding="0" style="margin-top:10px" id="mse0">
        <tr>
          <td height="30" bgcolor="#f3f3f3" style="border-top:1px solid #dedee0"><table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
              <td width="15%" align="center"><strong>订单号</strong></td>
              <td width="19%" align="center"><strong>订单时间</strong></td>
              <td width="9%" align="center"><strong>订单金额</strong></td>
              <td width="32%" align="center"><strong>送餐地址</strong></td>
              <td width="12%" align="center"><strong>订单状态</strong></td>
              <td width="12%" align="center"><strong>操 作</strong></td>
              </tr>
          </table></td>
        </tr>
        <tr>
          <td>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="sem">
            <asp:Repeater ID="rpt_list" runat="server" onitemcommand="rpt_list_ItemCommand" 
                    onitemdatabound="rpt_list_ItemDataBound"><ItemTemplate>
            <tr>
              <td width="15%" align="center"><a href="shoporderinfo.aspx?orderno=<%#Eval("OrderNo") %>&keepThis=true&TB_iframe=true" style="color:#1d54a5" class="thickbox"><%#Eval("OrderNo")%></a></td>
              <td width="19%" align="center"><%#Eval("AddTime")%></td>
              <td width="9%" align="center"><%#Eval("TotalPrice")%>元</td>
              <td width="32%" align="left" style="line-height:20px;padding:10px"><%#Eval("UserAddress")%></td>
              <td width="12%" align="center">
                <%#ShopOrderStatus(Eval("OrderStatus"))%>
              </td>
              <td width="12%" align="center">
                <asp:Literal ID="L_OrderStatus" Text='<%#Eval("OrderStatus") %>' Visible="false" runat="server"></asp:Literal>
                <asp:LinkButton ID="btnhandle" runat="server" Text="[处理]" CommandName="handle" CommandArgument='<%#Eval("Id") %>'></asp:LinkButton>
                <asp:LinkButton ID="btnfins" runat="server" Text="[完成]" CommandName="fins" CommandArgument='<%#Eval("Id") %>'></asp:LinkButton>
                <asp:LinkButton ID="btninvalid" runat="server" Text="[作废]" CommandName="invalid" CommandArgument='<%#Eval("Id") %>'></asp:LinkButton>
              </td>
              </tr>
            </ItemTemplate></asp:Repeater>        
            </table>
            </td>
        </tr>
        <tr>
          <td height="10"></td>
        </tr>
        <tr>
          <td height="33" align="center" bgcolor="#f3f3f3" class="se">
            <asp:AspNetPager CssClass="anpager2" CurrentPageButtonClass="cpb" ID="WebPager" runat="server" FirstPageText="首 页" LastPageText="末 页" NextPageText="下一页" PrevPageText="上一页"
                AlwaysShow="false" ShowDisabledButtons="false" ShowPageIndexBox="Never" onpagechanged="WebPager_PageChanged" PageSize="10" UrlPaging="true">
            </asp:AspNetPager>
          </td>
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
