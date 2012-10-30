<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu_AE.aspx.cs" Inherits="web.touch.Menu_AE" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title></title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <script src="../common/Common.js" type="text/javascript"></script>
    <script type="text/javascript">
        function checkForm() {
            var obj_menu = document.getElementById("txt_menuName");
            if (Empty(obj_menu)) {
                ShowinnerHTML(obj_menu, c_menu, '菜单名不能为空'); return false;
            } else {
                return true;
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="mframe">
    <table width="700" align="center" cellspacing="0" cellpadding="0">
        <tr>
            <td class="tl"></td>
            <td class="tm">
	            <span class="tt"><asp:Literal ID="ltlmenu"  runat="server" Text="添加菜单" EnableViewState="false"></asp:Literal></span>
            </td>
            <td class="tr"></td>
        </tr>
    </table>
    <table width="700" align="center" cellspacing="0" cellpadding="0">
    <tr>
        <td class="ml"></td>
        <td class="mm">     
            <div><input type="image" src="images/btn/bt_bak.gif" border="0" alt=" 返回 " title=" 返回 " onclick="location.href='javascript:history.back()';return false;" align="absmiddle"></div>
            <table border="0" align="center" cellpadding="0" cellspacing="0" style="font-size: 12px;">
                <tr>
                    <td style="width:10%;height:30px;">菜单名：</td>
                    <td>
                        <input type="text" id="txt_menuName" runat="server" style="width:200px;" class="inpu" /><span id="c_menu" class="explain">(菜单名不能为空)</span>
                    </td>
                </tr>
                <tr>
                    <td style="width:10%;height:30px;">父级菜单：</td>
                    <td>
                       <asp:DropDownList ID="ddl_menu" runat="server"><asp:ListItem Text="-请选择-" Value="0"></asp:ListItem></asp:DropDownList><span class="explain">(默认为一级菜单)</span>
                    </td>
                </tr>           
                <tr>
                    <td style="width:10%;height:30px;">链接地址：</td>
                    <td>
                       <input type="text" id="txt_urlLink" runat="server" style="width:300px;" class="inpu" />
                    </td>
                </tr>       
                <tr>
                    <td style="width:10%;height:30px;">排序号：</td>
                    <td>
                       <input type="text" id="txt_sortId" value="1" runat="server" style="width:50px;" class="inpu" onkeyup="this.value=this.value.replace(/\D/g,'')" onafterpaste="this.value=this.value.replace(/\D/g,'')" />
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
    <table width="700" align="center" cellspacing="0" cellpadding="0" >
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
