<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserGroupEdit.aspx.cs" Inherits="web.touch.UserGroupEdit" %>

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
	            <span class="tt">修改会员等级</span>
            </td>
            <td class="tr"></td>
        </tr>
    </table>
    <table width="98%" align="center" cellspacing="0" cellpadding="0">
    <tr>
        <td class="ml"></td>
        <td class="mm">   
            <div>
            <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0" style="font-size: 12px;">
            <tr>
                <td style="width: 15%;height:30px;">名称：</td>
                <td>
                    <input type="text" id="txtGroupName" runat="server" class="inpu" /><asp:RequiredFieldValidator
                        ID="rfvname" runat="server" ControlToValidate="txtGroupName" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 10%;height:30px;">折扣：</td>
                <td>
                    <input type="text" id="txtZK" runat="server" class="inpu" style="width:50px;" value="0" maxlength="5" /> %
                </td>
            </tr>
            <tr>
                <td style="width: 10%;height:30px;">
                </td>
                <td style="height:25px;line-height:25px;">
                    <asp:Button ID="btn_Submit" runat="server" Text="确认修改" onclick="btn_Submit_Click"/>
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
