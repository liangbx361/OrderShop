<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShopArea.aspx.cs" Inherits="web.touch.ShopArea" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title></title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="mframe">
    <table width="98%" align="center" cellspacing="0" cellpadding="0">
        <tr>
            <td class="tl"></td>
            <td class="tm">
	            <span class="tt">店铺送餐地址</span>
            </td>
            <td class="tr"></td>
        </tr>
    </table>
    <table width="98%" align="center" cellspacing="0" cellpadding="0">
    <tr>
        <td class="ml"></td>
        <td class="mm">
            <div style="text-align:center;"><asp:Literal ID="l_msg" runat="server" EnableViewState="false"></asp:Literal></div>   
            <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0" style="font-size: 12px;">
            <tr>
                <td style="width: 10%;height:30px;"></td>
                <td>
                   <asp:UpdatePanel ID="UpdatePanel" runat="server" UpdateMode="Always">
                  <ContentTemplate>     
                  <asp:DropDownList ID="ddl_counties" runat="server" AutoPostBack="true" onselectedindexchanged="ddl_counties_SelectedIndexChanged"></asp:DropDownList>
                  &nbsp;
                  <asp:DropDownList ID="ddl_streets" runat="server" AutoPostBack="true" onselectedindexchanged="ddl_streets_SelectedIndexChanged"></asp:DropDownList>
                  &nbsp;
                 <asp:DropDownList ID="ddl_district" runat="server">
                 </asp:DropDownList>
                  </ContentTemplate>
                  </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td style="width: 10%;height:30px;"></td>
                <td>
                    <asp:Button ID="btnSubmit" runat="server" Text="添 加" onclick="btnSubmit_Click" />
                </td>
            </tr>
            <tr>
                <td style="width: 10%;height:30px;"></td>
                <td>
                   <asp:Repeater ID="rpt_list" runat="server" onitemcommand="rpt_list_ItemCommand"><ItemTemplate>
                   <%#Eval("AreaName") %> [<asp:LinkButton ID="btndel" runat="server" Text="删除" CommandArgument='<%#Eval("Id") %>'></asp:LinkButton>]&nbsp;&nbsp;
                   </ItemTemplate></asp:Repeater>
                </td>
            </tr>
        </table> 
        </td>
        <td class="mr"></td>
    </tr>
    </table>
    <table width="98%" align="center" cellspacing="0" cellpadding="0" >
    <tr>
        <td class="bl"></td>
        <td class="bm">&nbsp;</td>
        <td class="br"></td>
    </tr>
    </table>
    </div>
    </form>
</body>
</html>
