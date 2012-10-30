<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FriendLink_AE.aspx.cs" Inherits="web.touch.FriendLink_AE" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>友情链接管理</title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <script src="js/Common.js" type="text/javascript"></script>
    <script src="../common/Common.js" type="text/javascript"></script>
    <script type="text/javascript">
        function CheckInput() {
            var obj_link_name = document.getElementById("txt_link_name");
            if (Empty(obj_link_name)) {
                ShowinnerHTML(obj_link_name, C_link_name, "请填写名称");
                return false;
            } 
            else {
                return true;
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="mframe">
    <table width="95%" align="center" cellspacing="0" cellpadding="0">
        <tr>
            <td class="tl"></td>
            <td class="tm"><span class="tt"><asp:Literal ID="ltl_oprater" runat="server" EnableViewState="false" Text="友情链接添加"></asp:Literal></span></td>
            <td class="tr"></td>
        </tr>
    </table>
    <table width="95%" align="center" cellspacing="0" cellpadding="0">
    <tr>
        <td class="ml"></td>
        <td class="mm"> 
            <div><input type="image" src="images/btn/bt_bak.gif" border="0" alt=" 返回 " title=" 返回 " onclick="location.href='javascript:history.back()';return false;" align="absmiddle"></div>
            <table width="800" align="center" cellpadding="0" cellspacing="0" style="font-size: 12px;">
                <tr>
                    <td style="width:10%;height:30px;">名  称：</td>
                    <td>
                        <input id="txt_link_name" runat="server" class="inpu" maxlength="100" /> <span id="C_link_name" class="explain">名称不能为空</span>
                    </td>
                </tr>
                <tr>
                    <td style="width:10%;height:30px;">链接网址：</td>
                    <td>
                        <input id="txt_link_site_url" runat="server" value="#" class="inpu" maxlength="255" style="width:200px;" /> <span id="C_site_url" class="explain">网站的链接地址</span>
                    </td>
                </tr>
                <tr>
                    <td style="width:10%;height:30px;">排序号：</td>
                    <td>
                        <input id="txt_sortid" runat="server" style="width:50px;" class="inpu" value="1" onkeyup="this.value=this.value.replace(/\D/g,'')" />
                    </td>
                </tr>
                <tr>
                    <td style="width:10%;height:30px;"></td>
                    <td valign="middle">
                    <asp:Button ID="btn_Submit" runat="server" CssClass="btn" onclick="btn_Submit_Click" OnClientClick="return CheckInput()" />
                    </td>
                </tr>
                <tr>
                    <td style="height: 10px" colspan="2"></td>
                </tr>
            </table>
            </td>
        <td class="mr"></td>
    </tr>
    </table>
    <table width="95%" align="center" cellspacing="0" cellpadding="0" >
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
