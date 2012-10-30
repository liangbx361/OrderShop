<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsType_AE.aspx.cs" Inherits="web.touch.NewsType_AE" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>分类管理</title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function CheckInput() {
            if (document.getElementById("txt_ClassName").value == "") {
                alert("请输入类别名称");
                return false;
            } else {
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
            <td class="tm"><span class="tt"><asp:Literal ID="ltltitle" runat="server" EnableViewState="false" Text="添加分类"></asp:Literal></span></td>
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
                    <td style="width:10%;height:30px;">类别名称：</td>
                    <td>
                        <asp:TextBox ID="txt_ClassName" runat="server" CssClass="inpu" MaxLength="200" style="width:200px;"></asp:TextBox> <span class="explain">类别名称不能为空</span>
                    </td>
                </tr>
                <tr>
                    <td style="width:10%;height:30px;">父级分类：</td>
                    <td>
                        <asp:DropDownList ID="ddl_type" runat="server">
                            <asp:ListItem Text="-请选择-" Value="0"></asp:ListItem>
                        </asp:DropDownList> <span class="explain">默认为根节点</span>
                    </td>
                </tr>
                <tr>
                    <td style="width:10%;height:30px;">排序号：</td>
                    <td>
                       <input type="text" id="txt_SortId" value="1" runat="server" maxlength="4" class="inpu" style="width:50px;" onkeyup="this.value=this.value.replace(/\D/g,'')" onafterpaste="this.value=this.value.replace(/\D/g,'')" />
                    </td>
                </tr>
                <tr>
                    <td style="width:10%;height:30px;"></td>
                    <td valign="middle" height="25">
                        <asp:Button ID="btn_Submit" runat="server" CssClass="btn" onclick="btn_Submit_Click" OnClientClick="return CheckInput()" />
                    </td>
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
