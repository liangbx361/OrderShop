<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShopAdd.aspx.cs" Inherits="web.touch.ShopAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>添加店铺</title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function VialdPrice(objid) {
            var price_reg = /^[0-9]*[1-9][0-9]*.*$/;
            if (!objid.value.match(price_reg)) {
                alert("价格格式输入错误！");
                objid.value = "0.0";
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
	            <span class="tt">添加店铺信息</span>
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
                <td style="width: 10%;height:30px;">店铺类型：</td>
                <td>
                    <asp:DropDownList ID="ddl_type" runat="server">
                        <asp:ListItem Value="0" Text="-请选择-"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 10%;height:30px;">店铺名称：</td>
                <td><input type="text" id="txtShopName" runat="server" class="inpu" style="width:200px;" /></td>
            </tr>
            <tr>
                <td style="width: 10%;height:30px;">电 话：</td>
                <td><input type="text" id="txtPhone" runat="server" class="inpu" /></td>
            </tr>
            <tr>
                <td style="width: 10%;height:30px;">店铺地址：</td>
                <td><input type="text" id="txtAddress" runat="server" class="inpu" style="width:300px;" /></td>
            </tr>
            <tr>
                <td style="width: 10%;height:30px;">营业时间：</td>
                <td><input type="text" id="txtOpenTime" runat="server" class="inpu" value="09:00-21:00" /><span class="explain">例如：09:00-21:00</span></td>
            </tr>
            <tr>
                <td style="width: 10%;height:30px;">点餐时间：</td>
                <td>
                    上午：<input type="text" id="txtamtime" runat="server" class="inpu" value="09:30-11:30" />
                    下午：<input type="text" id="txtpmtime" runat="server" class="inpu" value="16:30-18:30" />
                    <span class="explain">例如：09:00-21:00</span>
                </td>
            </tr>
            <tr>
                <td style="width: 10%;height:30px;">送餐时间：</td>
                <td><input type="text" id="txtSendTime" runat="server" class="inpu" value="30" style="width:50px;" /><span class="explain">例如（分钟）：30</span></td>
            </tr>
            <tr>
                <td style="width: 10%;height:30px;">配送费用：</td>
                <td><input type="text" id="txtSendPrice" runat="server" class="inpu" value="0.0" style="width:50px;" onblur="VialdPrice(this)" /><span class="explain">例如：0.0</span></td>
            </tr>
            <tr>
                <td style="width: 10%;height:30px;">起送费：</td>
                <td><input type="text" id="txtLimitPrice" runat="server" class="inpu" value="0.0" style="width:50px;" onblur="VialdPrice(this)" /><span class="explain">例如：20.0</span></td>
            </tr>
            <tr>
                <td style="width: 10%;height:30px;">折扣比例：</td>
                <td><input type="text" id="txtzk" runat="server" class="inpu" value="0" style="width:50px;" />%<span class="explain">请填写数字，例如：10</span></td>
            </tr>
            <tr style="display:none;">
                <td style="width: 10%;height:30px;">付款方式：</td>
                <td><input type="text" id="txtPayment" runat="server" class="inpu" value="餐到付款" /></td>
            </tr>
            <tr>
                <td style="width:10%;height:30px;">简介：</td>
                <td>
                    <textarea id="txtIntro" runat="server" class="area" rows="5" cols="80"></textarea>
                </td>
            </tr>
            <tr>
                <td style="width: 10%;height:30px;">店面图片：</td>
                <td>
                    <input type="text" id="txtShopPic" runat="server" class="inpu" style="width:230px;" />
                    <iframe src="UploadImg.aspx?cid=<%=txtShopPic.ClientID %>" frameborder="0" width="80%"
                        height="30px" scrolling="no"></iframe>
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
