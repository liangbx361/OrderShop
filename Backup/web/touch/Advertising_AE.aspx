<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Advertising_AE.aspx.cs" Inherits="web.touch.Advertising_AE" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title></title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <script src="js/Common.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="mframe">
    <table width="95%" align="center" cellspacing="0" cellpadding="0">
        <tr>
            <td class="tl"></td>
            <td class="tm"><span class="tt"><asp:Literal ID="ltl_oprater" runat="server" EnableViewState="false" Text="广告添加"></asp:Literal></span></td>
            <td class="tr"></td>
        </tr>
    </table>
    <table width="95%" align="center" cellspacing="0" cellpadding="0">
    <tr>
        <td class="ml"></td>
        <td class="mm"> 
            <div><input type="image" src="images/btn/bt_bak.gif" border="0" alt=" 返回 " title=" 返回 " onclick="location.href='javascript:history.back()';return false;" align="absmiddle"></div>
            <table width="98%" align="center" cellpadding="0" cellspacing="0" style="font-size: 12px;">
                <tr style="display:none;">
                    <td style="width:10%;height:30px;">广告类别：</td>
                    <td>
                        <asp:DropDownList ID="ddl_type" runat="server">
                            <asp:ListItem Text="首页广告图" Value="1"></asp:ListItem>
                        </asp:DropDownList> <span id="C_type" class="explain">请选择类别</span>
                    </td>
                </tr>
                <tr>
                    <td style="width:10%;height:30px;">名 称：</td>
                    <td>
                        <input id="txtAdvertName" runat="server" class="inpu" maxlength="255" style="width:200px;" /> <span id="Span2" class="explain">广告名称</span>
                    </td>
                </tr>
                <tr>
                    <td style="width:10%;height:30px;">链接地址：</td>
                    <td>
                        <input id="txt_link_url" runat="server" class="inpu" maxlength="255" style="width:200px;" /> <span id="C_site_url" class="explain">链接地址</span>
                    </td>
                </tr>
                <tr style="display:none;">
                    <td style="width:10%;height:30px;">排序号：</td>
                    <td>
                        <input id="txt_sortid" runat="server" style="width:50px;" class="inpu" value="1" onkeyup="this.value=this.value.replace(/\D/g,'')" /><span id="Span1" class="explain">必须是数字</span>
                    </td>
                </tr>
                <tr>
                    <td style="width:10%;height:30px;" valign="top">图片：</td>
                    <td><br/><asp:HyperLink ID="hy_img" runat="server" Target="_blank" ToolTip="查看原图"></asp:HyperLink><br/><br/>
                        <input id="txt_link_logo" runat="server" class="inpu" style="width:200px;" />
                        <span id="uploadSpan"><asp:FileUpload ID="file_link_logo" runat="server" CssClass="inpu" onchange="checkFormat(this.value,'uploadSpan')" /></span>
                        <asp:LinkButton ID="btn_upload" runat="server" onclick="btn_upload_Click" Text="上  传" CssClass="fLink"></asp:LinkButton>
                        <span id="C_link_logo" class="explain">请上传正确格式的图片</span>
                    </td>
                </tr>
                <tr>
                    <td style="width:10%;height:30px;"></td>
                    <td valign="middle">
                    <asp:Button ID="btn_Submit" runat="server" CssClass="btn" onclick="btn_Submit_Click" />
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
