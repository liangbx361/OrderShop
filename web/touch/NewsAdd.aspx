<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsAdd.aspx.cs" Inherits="web.touch.NewsAdd" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>添加信息</title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <script src="fckeditor/fckeditor.js" type="text/javascript"></script>
    <link href="../common/Date/skin/WdatePicker.css" rel="stylesheet" type="text/css" />
    <script src="../common/Date/WdatePicker.js" type="text/javascript"></script>
    <script src="../common/Common.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="mframe">
    <table width="98%" align="center" cellspacing="0" cellpadding="0">
        <tr>
            <td class="tl"></td>
            <td class="tm">
	            <span class="tt">添加信息</span>
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
                <td style="width:10%;height:30px;">类别：</td>
                <td>
                    <asp:DropDownList ID="ddl_type" runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 10%;height:30px;">
                    标题：
                </td>
                <td>
                    <input type="text" id="txtArticleTitle" runat="server" style="width:500px;" class="inpu" />
                </td>
            </tr>
            <tr>
                <td style="width: 10%;height:30px;">排序：</td>
                <td><input type="text" id="txtSortId" runat="server" class="inpu" value="1" style="width:50px;" onkeyup="this.value=this.value.replace(/\D/g,'')" />
                </td>
            </tr>
            <tr>
                <td style="width: 10%;height:30px;">添加日期：</td>
                <td><input type="text" id="txtAddTime" runat="server" class="inpu Wdate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss',autoPickDate:true})" /> </td>
            </tr>
            <tr>
                <td style="width: 10%;height:30px;" valign="top">内容：
                </td>
                <td valign="top">
                    <script type="text/javascript">
                        function showFCK() {
                            var oFCKeditor = new FCKeditor('txtArticleContent');
                            oFCKeditor.BasePath = 'fckeditor/';
                            oFCKeditor.ToolbarSet = 'My_FCK';
                            oFCKeditor.Width = '100%';
                            oFCKeditor.Height = '300';
                            oFCKeditor.Value = '';
                            oFCKeditor.ReplaceTextarea();
                        }
                    </script>
                    <textarea name="txtArticleContent" id="txtArticleContent" rows="12" cols="80" class="area" runat="server"></textarea><br/>
                    <span id="ReHeightFCK"><a href="javascript:resizeEditor('txtArticleContent',100)"><img src="images/btn/bt_open.gif" border='0'></a> <a href="javascript:resizeEditor('txtArticleContent',-100)"><img src="images/btn/bt_close.gif" border='0'></a></span>
                    <script type="text/javascript">showFCK()</script>
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
