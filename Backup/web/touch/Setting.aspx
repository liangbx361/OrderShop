<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Setting.aspx.cs" Inherits="web.admin.Setting" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>基本设置</title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <script src="fckeditor/fckeditor.js" type="text/javascript"></script>
    <script src="../common/Common.js" type="text/javascript"></script>
    <link href="../common/jquery-easyui/themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../common/jquery-easyui/themes/icon.css" rel="stylesheet" type="text/css" />
    <script src="../common/jquery-easyui/jquery-1.4.4.min.js" type="text/javascript"></script>
    <script src="../common/jquery-easyui/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="js/function.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="mframe">
	<span><input type="image" src="images/btn/bt_bak.gif" border="0" alt=" 返回 " title=" 返回 " onclick="location.href='javascript:history.back()';return false;" align="absmiddle"></span>
    <table width="99%" align="center" cellspacing="0" cellpadding="0">
        <tr>
            <td class="tl"></td>
            <td class="tm">
	            <span class="tt">基本设置</span>
            </td>
            <td class="tr"></td>
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
                        <input type="text" id="txtname" runat="server" size="50" class="inpu" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 10%;height:30px; text-align:right;">电话：</td>
                    <td>
                        <input type="text" id="txttel" runat="server" class="inpu" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 10%;height:30px; text-align:right;">传真：</td>
                    <td>
                        <input type="text" id="txtfax" runat="server" class="inpu" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 10%;height:30px; text-align:right;">电子邮件：</td>
                    <td >
                       <input type="text" id="txtemail" runat="server" size="30" class="inpu" /><asp:RegularExpressionValidator
                           ID="revemail" runat="server" ErrorMessage="格式输入错误" ControlToValidate="txtemail" 
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width:10%;height:30px;text-align:right;">Smtp服务器地址：</td>
                    <td><input type="text" id="txt_email_smtp" runat="server" class="inpu" /><font color="red">*</font><span id="C_smtp" class="explain">必填（邮件的服务器地址 例如：qq邮件地址为 qq.com）</span></td>
                </tr>
                <tr>
                    <td style="width:10%;height:30px;text-align:right;">登录密码：</td>
                    <td>
                        <input type="password" id="txt_password" runat="server" maxlength="50" class="inpu" /><font color="red">*</font>
                    </td>
                </tr>
                <tr>
                    <td style="width:10%;height:30px;text-align:right;">热门楼宇：</td>
                    <td>
                        <input type="text" id="txthotdistrict" runat="server" maxlength="100" class="inpu" style="width:600px;" /><span class="explain">多个请用“|”隔开</span>
                    </td>
                </tr>
                <tr>
                    <td style="width: 10%;height:30px; text-align:right;">底部信息：</td>
                    <td>
                        <script type="text/javascript">
                            function showFCK() {
                                var oFCKeditor = new FCKeditor('txtcopyright');
                                oFCKeditor.BasePath = 'fckeditor/';
                                oFCKeditor.ToolbarSet = 'My_FCK';
                                oFCKeditor.Width = '90%';
                                oFCKeditor.Height = '200';
                                oFCKeditor.Value = '';
                                oFCKeditor.ReplaceTextarea();
                            }
                    </script>
                    <textarea name="txtcopyright" id="txtcopyright" rows="8" cols="80" class="text" runat="server"></textarea>
                    <br /><span id="ReHeightFCK" ><a href="javascript:resizeEditor('txtcopyright',100)"><img src="images/btn/bt_open.gif" border='0'></a>&nbsp;<a href="javascript:resizeEditor('txtcopyright',-100)"><img src="images/btn/bt_close.gif" border='0'></a></span>
                    <script type="text/javascript">showFCK()</script>
                    </td>
                </tr> 
                <tr>
                    <td style="width: 10%;height:30px;" valign="top">关键字：(用于被搜索引擎检索的关键字)</td>
                    <td>
                        <textarea id="txtkey" runat="server" rows="5" cols="50" class="area"></textarea>
                        <br /><a href="javascript:u_Size(5,'txtkey')"><img src="images/btn/bt_open.gif" border='0'></a>&nbsp;<a href="javascript:u_Size(-5,'txtkey')"><img src="images/btn/bt_close.gif" border='0'></a> 
                    </td>
                </tr>
                <tr>
                    <td style="width: 10%;height:30px;" valign="top">描述：(用于被搜索引擎检索后的描述)</td>
                    <td>
                        <textarea id="txtdesc" runat="server" rows="5" cols="50" class="area"></textarea> 
                        <br /><a href="javascript:u_Size(5,'txtdesc')"><img src="images/btn/bt_open.gif" border='0'></a>&nbsp;<a href="javascript:u_Size(-5,'txtdesc')"><img src="images/btn/bt_close.gif" border='0'></a> 
                    </td>
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
    <table width="99%" align="center" cellspacing="0" cellpadding="0" >
        <tr>
            <td class="bl"></td>
            <td class="bm">&nbsp;</td>
            <td class="br"></td>
        </tr>
    </table>    
    </div>
    </form>
    <asp:Literal ID="ltl_script" runat="server" EnableViewState="false"></asp:Literal>
</body>
</html>
