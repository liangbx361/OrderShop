<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShopTypeList.aspx.cs" Inherits="web.touch.ShopTypeList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title></title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .inpu2{border:1px #3399ff solid;height:21px; line-height:21px; padding:0;}
        .inpu1{border:1px #fff solid;height:21px; line-height:21px; padding:0;}
        .inpu1:hover{height:21px;background-color: #F5F9FD;padding: 0px;border: 1px double #3399ff;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="mframe">
        <table width="98%" align="center" cellspacing="0" cellpadding="0">
            <tr>
                <td class="tl"></td>
                <td class="tm"><span class="tt">店铺类别</span></td>
                <td class="tr"></td>
            </tr>
        </table>
        <table width="98%" align="center" cellspacing="0" cellpadding="0">
            <tr>
                <td class="ml"></td>
                <td class="mm">
                    <div style="padding:5px 0px 5px 0px;">
                        <a href="#areacontrol" title="添加" class="fLink">添 加</a> 
                        <a href="javascript:location.replace(location.href)" class="fLink">刷 新</a>
                    </div>
                    <table align="center" cellpadding="6" width="100%" cellspacing="0" bordercolor="#C6DAE5" class="grid">
                        <tr>
                            <td style="line-height:30px;">
                            <asp:Repeater ID="rpt_list" runat="server" onitemcommand="rpt_list_ItemCommand"><ItemTemplate>
                                <div style="width:98%;padding-left:20px;border-bottom:solid 1px #114983;" onmouseover="a=this.style.backgroundColor;this.style.backgroundColor='#E2E6E5'" onmouseout="this.style.backgroundColor=a">
                                    <div style="width:45%;float:right"><asp:LinkButton ID="ledit" runat="server" CommandArgument='<%#Eval("Id") %>' CommandName="edit" Text="修改" ToolTip="修改"></asp:LinkButton>&nbsp;&nbsp;&nbsp;<asp:LinkButton ID="ldel" runat="server" CommandName="del" CommandArgument='<%#Eval("Id") %>' OnClientClick="javascript:return confirm('您确定要删除吗？');" Text="删除"></asp:LinkButton></div>
                                    <div style="width:50%; cursor:pointer;"><asp:TextBox ID="txttypename" runat="server" Text='<%#Eval("TypeName")%>' CssClass="inpu1" onfocus="this.className='inpu2'" onblur="this.className='inpu1'"></asp:TextBox></div>
                                </div>
                            </ItemTemplate></asp:Repeater>
                            </td>
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
    <div class="mframe" >
        <a name="areacontrol"></a>
        <table width="400" cellpadding="0" cellspacing="0" align="left">
            <tr>
                <td style="line-height:30px; width:100px;" align="right">名 称：</td>
                <td><input type="text" id="txtinpTypeName" runat="server" /></td>
            </tr>
            <tr>
                <td style="line-height:30px; width:100px;"></td>
                <td><asp:Button ID="btnSubmit" runat="server" Text="确认添加" onclick="btnSubmit_Click" /></td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
