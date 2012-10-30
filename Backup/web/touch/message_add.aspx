<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="message_add.aspx.cs" Inherits="web.touch.message_add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title></title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link href="css/thickbox.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/thickbox.jquery.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="mframe">
    <table width="95%" align="center" cellspacing="0" cellpadding="0">
        <tr>
            <td class="tl"></td>
            <td class="tm"><span class="tt">发送站内信</span></td>
            <td class="tr"></td>
        </tr>
    </table>
    <table width="95%" align="center" cellspacing="0" cellpadding="0">
    <tr>
        <td class="ml"></td>
        <td class="mm"> 
            <div><input type="image" src="images/btn/bt_bak.gif" border="0" alt=" 返回 " title=" 返回 " onclick="javascript:history.back()" align="absmiddle"></div>
            <table width="800" align="center" cellpadding="0" cellspacing="0" style="font-size: 12px;">
                <tr>
                    <td style="width:10%;height:30px;">用户名：</td>
                    <td>
                        <textarea id="txt_names" runat="server" class="area" rows="3" cols="50" readonly="readonly" ></textarea>
                        <input type="hidden" id="hidden_ids" runat="server" class="inpu" style="width:300px;" />
                        <a href="/#TB_inline?inlineId=tousers&modal=true" class="thickbox">选择</a>
                    </td>
                </tr>
                <tr>
                    <td style="width:10%;height:30px;">标 题：</td>
                    <td>
                        <input id="txt_title" runat="server" class="inpu" maxlength="100" style="width:300px;" />
                    </td>
                </tr>
                <tr>
                    <td style="width:10%;height:30px;">内 容：</td>
                    <td>
                        <textarea id="txt_content" runat="server" class="area" rows="8" cols="60"></textarea>
                    </td>
                </tr>
                <tr>
                    <td style="width:10%;height:30px;"></td>
                    <td valign="middle">
                    <asp:Button ID="btn_Submit" runat="server" CssClass="btn" onclick="btn_Submit_Click" OnClientClick="return CheckInput()" />
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
    <div id="tousers" style="display:none; margin:0 auto;">
        <div>
        <asp:Repeater ID="rpt_list" runat="server" EnableViewState="false"><ItemTemplate>
            <span><input type="checkbox" name="chsers" id="chk_<%#Eval("Id") %>" value="<%#Eval("UserName") %>" /><%#Eval("UserName") %></span>
        </ItemTemplate></asp:Repeater>
        </div>
        <div style="text-align:center; margin-top:10px;"><input type="button" id="btnsure" value="确定" onclick="seluser()" /></div>
        <div style="text-align:center;height:25px; line-height:24px;"><a href="javascript:;" onclick="tb_remove();">【关闭本窗口】</a></div>
    </div>
    </form>
    <script type="text/javascript">
        function seluser() {
            var namestr = "";
            var idstr = "";
            var arraylist = document.getElementsByName("chsers");
            var num = 0;
            for (var i = 0; i < arraylist.length; i++) {
                if (arraylist[i].checked) {
                    num++;
                    namestr += arraylist[i].value + ";";
                    idstr += arraylist[i].id.substr(4) + ",";
                }
            }
            if (num > 10) {
                alert("一次只能选择10人");
                return;
            }
            $("#txt_names").attr("value", namestr);
            $("#hidden_ids").attr("value", idstr);
            tb_remove();
        }
    </script>
</body>
</html>
