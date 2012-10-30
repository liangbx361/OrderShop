<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin_roleRight_manager.aspx.cs" Inherits="web.touch.admin_roleRight_manager" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>权限管理</title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/Common.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="mframe">
    <table width="98%" align="center" cellspacing="0" cellpadding="0">
        <tr>
            <td class="tl"></td>
            <td class="tm">
	            <span class="tt">权限管理-<asp:Literal ID="lbl_Permissions" runat="server" EnableViewState="false"></asp:Literal>
	            &nbsp;<input type="checkbox" id="chkAll" onclick="chkall(this,'CheckBox1');chkall(this,'cbkrowone');chkall(this,'cblist')" title="全选/取消" /></span>
            </td>
            <td class="tr"></td>
        </tr>
    </table>
    <table width="98%" align="center" cellspacing="0" cellpadding="0">
    <tr>
        <td class="ml"></td>
        <td class="mm">
            <div><a href="admin_user_manager.aspx"><img src="images/btn/bt_bak.gif" border="0" alt=" 返回 " align="absmiddle" /></a></div>  
            <div style="height:10px;line-height:10px;"></div>
            <asp:Repeater runat="server" ID="rpt_UserRole" OnItemDataBound="rpt_UserRole_ItemDataBound">
            <ItemTemplate>
            <table border="0" align="center" cellpadding="0" cellspacing="0" class="grid" width="98%" style="font-size: 12px;">
                    <tr>
                        <td style="width: 10%;background:#EDF6FC" align="left" valign="top">
                            &nbsp;<asp:CheckBox ID="CheckBox1" runat="server" Text='<%#Eval("MenuName") %>' ToolTip='<%# "选中"+Eval("MenuName") %>' onclick="checkRow(this,'cbkrowone')" />
                            <asp:Label runat="server" ID="lbl_id" Visible="false" Text='<%#Eval("Id") %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 10%;line-height:25px;">
                            <asp:Repeater ID="rptRole" runat="server"><ItemTemplate>
                                    <div>
                                        <dl>
                                            <dd style="float:left;"><asp:HiddenField ID="hfid" runat="server" Value='<%#Eval("Id") %>' />
                                                <asp:CheckBox ID="cbkrowone" runat="server" onclick="checkRow2(this,'cblist2')" ToolTip="选中" /><%#Eval("MenuName")%>
                                            </dd>
                                        </dl>
                                    </div></ItemTemplate></asp:Repeater>
                        </td>
                    </tr>
                </table>
                <div style="height:10px; line-height:10px;"></div>
            </ItemTemplate>
            </asp:Repeater>
            <table border="0" align="center" cellpadding="0" cellspacing="0" class="grid" width="98%" style="font-size: 12px;">
                <tr>
                    <td style="width: 10%;background:#EDF6FC" valign="top" >&nbsp;<asp:CheckBox ID="cbk_Permissions" runat="server" Text="权限管理" />
                    </td>
                </tr>
            </table>
            <div style="padding:10px 10px 5px 10px;"><asp:Button ID="btn_Submit" runat="server" CssClass="btn" onclick="btnsubmit_Click" /></div>  
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
