<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin_user_AE.aspx.cs" Inherits="web.touch.admin_user_AE" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title></title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function checkForm() {
            if (document.getElementById("txtuserName").value == "") {
                alert("请输入用户名");
                document.getElementById("txtuserName").focus();
                return false;
            } else if (document.getElementById("txtpassword").value != "") {
                if (document.getElementById("txtpassword").value != document.getElementById("txtpassword2").value) {
                    alert("两次密码输入不一致");
                    document.getElementById("txtpassword2").focus();
                    return false;
                }
            } else {
                return true;
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="mframe">
    <table width="98%" align="center" cellspacing="0" cellpadding="0">
        <tr>
            <td class="tl"></td>
            <td class="tm">
	            <span class="tt">管理员信息</span>
            </td>
            <td class="tr"></td>
        </tr>
    </table>
    <table width="98%" align="center" cellspacing="0" cellpadding="0">
    <tr>
        <td class="ml"></td>
        <td class="mm">   
            <table width="98%" border="0" align="center" cellpadding="0" cellspacing="0" style="font-size: 12px;">
                <tr>
                    <td style="width:10%;height:30px;">用户名：</td>
                    <td>
                        <asp:TextBox ID="txtuserName" runat="server" MaxLength="11" CssClass="inpu"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width:10%;height:30px;">密码：</td>
                    <td>
                        <asp:TextBox ID="txtpassword" TextMode="Password" runat="server" MaxLength="11" CssClass="inpu"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width:15%;height:30px;">确认密码：</td>
                    <td>
                        <asp:TextBox ID="txtpassword2" TextMode="Password" runat="server" MaxLength="11" CssClass="inpu"></asp:TextBox>
                    </td>
                </tr> 
                <tr>
                    <td style="width: 10%" valign="top"></td>
                    <td style="height: 25px; vertical-align:middle;">
                        <asp:Button ID="btn_Submit" runat="server" CssClass="btn" onclick="btn_Submit_Click" OnClientClick="return checkForm()" />
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
