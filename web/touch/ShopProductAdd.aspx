<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShopProductAdd.aspx.cs" Inherits="web.touch.ShopProductAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title></title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function VialdPrice() {
            var price_reg = /^[0-9]*[1-9][0-9]*.*$/;
            var price = document.getElementById("txtPrice");
            if (!price.value.match(price_reg)) {
                alert("价格格式输入错误！");
                price.value = "0.0";
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
	            <span class="tt">添加菜品</span>
            </td>
            <td class="tr"></td>
        </tr>
    </table>
    <table width="98%" align="center" cellspacing="0" cellpadding="0">
    <tr>
        <td class="ml"></td>
        <td class="mm">   
            <div><asp:Literal ID="ltl_msg" runat="server" EnableViewState="false"></asp:Literal></div>  
            <div>
            <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0" style="font-size: 12px;">
            <tr>
                <td style="width: 15%;height:30px;">菜品名称：</td>
                <td>
                    <input type="text" id="txtProductName" runat="server" class="inpu" /><asp:RequiredFieldValidator
                        ID="rfvname" runat="server" ControlToValidate="txtProductName" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 10%;height:30px;">菜品类别：</td>
                <td>
                    <asp:DropDownList ID="ddl_shoptype" runat="server">
                        <asp:ListItem Value="0" Text="-请选择-"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 10%;height:30px;">价格：</td>
                <td>
                    <input type="text" id="txtPrice" runat="server" class="inpu" style="width:50px;" value="0.0" maxlength="5" onblur="VialdPrice()" />
                </td>
            </tr>
            <tr>
                <td style="width: 10%;height:30px;">会员价：</td>
                <td>
                    <input type="text" id="txtPrice2" runat="server" class="inpu" style="width:50px;" value="0.0" maxlength="5" onblur="VialdPrice()" />
                </td>
            </tr>
            <tr>
                <td style="width:10%;height:30px">图片</td>
                <td><input type="text" id="txtImgSrc" runat="server" class="inpu" style="width:230px;" />
                    <iframe src="UploadImg.aspx?cid=<%=txtImgSrc.ClientID %>" frameborder="0" width="80%"
                        height="30px" scrolling="no"></iframe>
                </td>
            </tr>
            <tr>
                <td style="width: 10%;height:30px;">
                </td>
                <td style="height:25px;line-height:25px;">
                    <asp:Button ID="btn_Submit" runat="server" Text="确认添加" onclick="btn_Submit_Click"/>
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
