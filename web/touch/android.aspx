<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="android.aspx.cs" Inherits="web.touch.android" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>android客户端管理</title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="mframe">
        <table width="98%" align="center" cellspacing="0" cellpadding="0">
            <tr>
                <td class="tl">
                </td>
                <td class="tm">
                    <span class="tt">android客户端管理</span>
                </td>
                <td class="tr">
                </td>
            </tr>
        </table>
         <table width="99%" align="center" cellspacing="0" cellpadding="0">
    <tr>
        <td class="ml"></td>
        <td class="mm">
            <table align="center" cellpadding="0" cellspacing="0" style="font-size: 13px;">
                <tr>
                    <td style="width: 10%;height:30px; text-align:right;">名称：</td>
                    <td>
                        <input type="text" id="txtname" runat="server" class="inpu" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 10%;height:30px; text-align:right;">版本号：</td>
                    <td>
                        <input type="text" id="txtVersionCode" runat="server" class="inpu" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 10%;height:30px; text-align:right;">版本名称：</td>
                    <td>
                        <input type="text" id="txtVersionName" runat="server" class="inpu" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 10%;height:30px; text-align:right;">下载地址：</td>
                    <td >
                       <input type="text" id="txtDownloadAddr" runat="server" size="30" class="inpu" /></td>
                </tr>
                <tr>
                    <td style="width:10%;height:30px;text-align:right;">更新说明：</td>
                    <td><textarea name="txtcopyright" id="txtIntroduction" rows="8" cols="80" class="text" runat="server"></textarea></td>
                </tr>
                <tr>
                    <td style="width: 10%;height:30px; text-align:right;"></td>
                    <td>
                        <asp:Button ID="btnsubmit" runat="server" CssClass="btn" onclick="btnsubmit_Click" />
                    </td>
                </tr>            
            </table>
    </td>
    <td class="mr"></td>
    </tr>
    </table>   
    </div>
    </form>
</body>
</html>
