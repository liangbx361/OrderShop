<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShopUserEdit.aspx.cs" Inherits="web.touch.ShopUserEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title></title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="mframe">
    <table width="98%" align="center" cellspacing="0" cellpadding="0">
        <tr>
            <td class="tl"></td>
            <td class="tm">
	            <span class="tt">修改商户会员信息</span>
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
                <td style="width: 10%;height:30px;">店铺名称：</td>
                <td>
                   <input type="text" id="txtshopname" runat="server" class="inpu" readonly />
                </td>
            </tr>
            <tr>
                <td style="width: 10%;height:30px;">用户名：</td>
                <td>
                   <input type="text" id="txtUserName" runat="server" readonly class="inpu" />
                </td>
            </tr>
            <tr>
                <td style="width: 10%;height:30px;">密 码：</td>
                <td>
                   <input type="password" id="txtpassword" runat="server" class="inpu" />
                </td>
            </tr>
            <tr>
                <td style="width: 10%;height:30px;">昵 称：</td>
                <td>
                    <input type="text" id="txtNickName" runat="server" class="inpu" />
                </td>
            </tr>
            <tr>
                <td style="width: 10%;height:30px;">手 机：</td>
                <td><input type="text" id="txtMobile" runat="server" class="inpu" /><asp:RequiredFieldValidator
                        ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtMobile" ErrorMessage="必填"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="width: 10%;height:30px;">E-Mail：</td>
                <td>
                    <input type="text" id="txtEmail" runat="server" class="inpu" />
                </td>
            </tr>
            <tr>
                <td style="width: 10%;height:30px;"></td>
                <td>
                    <asp:Button ID="btnSubmit" runat="server" Text="修 改" onclick="btnSubmit_Click" />
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
