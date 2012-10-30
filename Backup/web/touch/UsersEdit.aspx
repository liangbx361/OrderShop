<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsersEdit.aspx.cs" Inherits="web.touch.UsersEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title></title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link href="../common/Date/skin/WdatePicker.css" rel="stylesheet" type="text/css" />
    <script src="../common/Date/WdatePicker.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="mframe">
    <table width="98%" align="center" cellspacing="0" cellpadding="0">
        <tr>
            <td class="tl"></td>
            <td class="tm">
	            <span class="tt">会员信息</span>
            </td>
            <td class="tr"></td>
        </tr>
    </table>
    <table width="98%" align="center" cellspacing="0" cellpadding="0">
    <tr>
        <td class="ml"></td>
        <td class="mm">   
            <div><input type="image" src="images/btn/bt_bak.gif" border="0" alt=" 返回 " title=" 返回 " onclick="location.href='javascript:history.back()';return false;" align="absmiddle"></div>  
            <div>
            <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0" style="font-size: 12px;">
            <tr>
                <td style="width: 10%;height:30px;">用户名：</td>
                <td colspan="3">
                    <%=this.UserName %>
                </td>
            </tr>
            <tr>
                <td style="width: 10%;height:30px;">昵 称：</td>
                <td>
                    <input type="text" id="txtNickName" runat="server" class="inpu" />
                </td>
                <td style="width: 10%;">出生年月：</td>
                <td style="width: 50%;">
                    <input type="text" id="txtBirthday" runat="server" class="inpu Wdate" />
                </td>
            </tr>
            <tr>
                <td style="width: 10%;height:30px;">手 机：</td>
                <td><input type="text" id="txtMobile" runat="server" class="inpu" /></td>
                <td style="width: 10%;height:30px;">电 话：</td>
                <td>
                    <input type="text" id="txtPhone" runat="server" class="inpu" />
                </td>
            </tr>
            <tr>
                <td style="width: 10%;height:30px;">E-Mail：</td>
                <td>
                    <input type="text" id="txtEmail" runat="server" class="inpu" />
                </td>
                <td style="width: 10%;height:30px;">地 址：</td>
                <td>
                    <input type="text" id="txtAddress" runat="server" class="inpu" style="width:300px;" />
                </td>
            </tr>
            <tr>
                <td style="width: 10%;height:30px;">积分：</td>
                <td>
                    <input type="text" id="txtPoint" runat="server" class="inpu" style="width:50px;" />
                </td>
            </tr>
            <tr>
                <td style="width: 10%;height:30px;">
                </td>
                <td style="height:25px;line-height:25px;">
                    <asp:Button ID="btn_Submit" runat="server" CssClass="btn" onclick="btn_Submit_Click"/>
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
</body>
</html>
