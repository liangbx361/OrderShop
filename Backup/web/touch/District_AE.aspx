<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="District_AE.aspx.cs" Inherits="web.touch.District_AE" %>

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
	            <span class="tt">楼宇/小区信息</span>
            </td>
            <td class="tr"></td>
        </tr>
    </table>
    <table width="98%" align="center" cellspacing="0" cellpadding="0">
    <tr>
        <td class="ml"></td>
        <td class="mm">   
            <div><img src="images/btn/bt_bak.gif" border="0" onclick="javascript:window.location='AreaList.aspx'" align="absmiddle"></div>  
            <div>
            <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0" style="font-size: 12px;">
            <tr>
                <td style="width: 10%;height:30px;"></td>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel" runat="server" UpdateMode="Always">
                      <ContentTemplate> 
                       <asp:DropDownList ID="ddl_counties" runat="server" AutoPostBack="true" onselectedindexchanged="ddl_counties_SelectedIndexChanged"></asp:DropDownList>&nbsp;
                       <asp:DropDownList ID="ddl_streets" runat="server"></asp:DropDownList>&nbsp;
                      </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td style="width: 10%;height:30px;">楼宇/小区：</td>
                <td><input type="text" id="txtDistrict" runat="server" class="inpu" />
                    <asp:Label ID="L_msg" runat="server" EnableViewState="false" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 10%;height:30px;">大写字母：</td>
                <td><input type="text" id="txtKey" runat="server" style="width:50px" class="inpu" maxlength="1" /></td>
            </tr>
            <tr>
                <td style="width: 10%;height:30px;"></td>
                <td><asp:Button ID="btnAdd" runat="server" Text="添 加" onclick="btnAdd_Click" OnClientClick="return checksub()" />
                    <asp:Button ID="btnMoidfy" runat="server" Text="修 改" onclick="btnMoidfy_Click" Visible="false" OnClientClick="return checksub()" />
                </td>
            </tr>
        </table>
        </div>   
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
    <script type="text/javascript">
        function checksub() {
            if (document.getElementById("ddl_streets").value == "") {
                alert("请选择街道");
                return false;
            } else if (document.getElementById("txtStreet").value == "") {
                alert("请填写街道");
                return false;
            } else if (document.getElementById("txtKey").value == "") {
                alert("请填写大写字母");
                return false;
            } else {
                return true;
            }
        }
    </script>
</body>
</html>
