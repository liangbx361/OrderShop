<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userprofitlist.aspx.cs" Inherits="web.Users.userprofitlist" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title></title>
    <link href="/css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="margin-top:10px" id="mse0">
        <tr>
          <td height="30" bgcolor="#f3f3f3" style="border-top:1px solid #dedee0"><table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
              <td width="22%" height="30" align="center"><strong>会员名称</strong></td>
              <td width="24%" align="center"><strong>消费时间</strong></td>
              <td width="19%" align="center"><strong>消费积分</strong></td>
              <td width="20%" align="center"><strong>收益积分</strong></td>
              </tr>
          </table></td>
        </tr>
        <tr>
          <td>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="sem">
            <asp:Repeater ID="rpt_list" runat="server" EnableViewState="false"><ItemTemplate>
            <tr>
              <td width="22%"  height="30" align="center" style="color:#0077bb;"><%#Eval("UserName")%></td>
              <td width="24%" align="center"><%#Eval("xftime")%></td>
              <td width="19%" align="center"><%#Eval("xfpoint")%></td>
              <td width="20%" align="center"><%#Eval("sypoint")%></td>
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
                AlwaysShow="false" ShowDisabledButtons="false" ShowPageIndexBox="Never" onpagechanged="WebPager_PageChanged" PageSize="5" UrlPaging="true">
            </asp:AspNetPager>
          </td>
        </tr>
      </table>
    </form>
</body>
</html>
