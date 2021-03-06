<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="feedback.aspx.cs" Inherits="web.feedback" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title><%=webset.WebName%></title>
    <meta name="keywords" content="<%=webset.WebKeywords %>" />
    <meta name="description" content="<%=webset.WebDescription %>" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/userarea.js" type="text/javascript"></script>
    <style type="text/css">
        #menu #menu3 a{background:url(images/yncf_07.gif);font-weight:bold;color:#FFF;}
        #dh00 .current{color:#ff6600;font-weight:bold}
        .inpu{border:1px solid #cbcbcb;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <ucl:Header ID="Header" runat="server" />
    <div id="main">
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="80%" height="20" id="path2">当前位置：<a href="/">邀您吃饭</a> > 商务合作</td>
    <td width="4%">分享：</td>
    <td width="16%" id="path3"><a href="#"><img src="images/yncf_50.gif" width="19" height="24" /></a><a href="#"><img src="images/yncf_51.gif" width="20" height="24" /></a><a href="#"><img src="images/yncf_52.gif" width="20" height="24" /></a><a href="#"><img src="images/yncf_53.gif" width="20" height="24" /></a><a href="#"><img src="images/yncf_54.gif" width="20" height="24" /></a><a href="#"><img src="images/yncf_55.gif" width="20" height="24" /></a></td>
  </tr>
</table>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="190" valign="top"><table width="190" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td background="images/yncf_67.gif" height="39" style="font-size:14px;font-weight:bold;padding-left:20px">问题分类</td>
  </tr>
  <tr>
    <td background="images/yncf_69.gif">
<div id="dh00">
<ul>
<li><a href="feedback.aspx" class="current">意见反馈</a>
<asp:Repeater ID="rpt_list" runat="server" EnableViewState="false"><ItemTemplate>
<li><a href="about.aspx?id=<%#Eval("Id") %>"><%#Eval("NewTitle") %></a></li>
</ItemTemplate></asp:Repeater>
</ul>
</div>
<div style="font-size:14px;font-weight:bold;padding-left:20px; background-color:#f3f3f3;line-height:35px;width:158px;margin:0 auto">客户服务</div>
<div style="padding:10px;line-height:20px;padding-left:20px;">工作时间：09：00-19：00<BR />
    客服热线：0591-28068107<BR />
    传    真：0591-80018228<BR />
    地    址：鼓楼区五四玉泉路<BR />
    1号明阳天下23F<BR />
    邮政编码：350000</div>

</td>
  </tr>

  <tr>
    <td background="images/yncf_70.gif" height="9"></td>
  </tr>
</table></td>
    <td width="10">&nbsp;</td>
    <td valign="top">
        <div style="line-height:36px;padding:10px 20px 20px 20px;font-size:13px;color:#666;border:1px solid #ededed;margin-bottom:10px;">
            <table cellpadding="0" cellspacing="0">
            <tr>
                <td>昵 称：</td>
                <td><input id="txtusername" runat="server" class="inpu" />
                    <asp:RequiredFieldValidator ID="rfvusername" runat="server" ControlToValidate="txtusername" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>主 题：</td>
                <td><input id="txtsubject" runat="server" class="inpu" style="width:300px" />
                    <asp:RequiredFieldValidator ID="rfvsubject" runat="server" ControlToValidate="txtsubject" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>意见建议：</td>
                <td><textarea id="txtcontent" runat="server" class="inpu" rows="8" cols="60"></textarea>
                    <asp:RequiredFieldValidator ID="rfvcontent" runat="server" ControlToValidate="txtcontent" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td></td>
                <td><asp:Button ID="btnSubmit" runat="server" CssClass="new-btn-login" Text="提交" onclick="btnSubmit_Click" />
                <input type="reset" class="new-btn-login" value="取消" />
                </td>
            </tr>
            </table>
        </div>
    </td>
  </tr>
</table>
    </div>
    <ucl:Footer ID="Footer" runat="server" />
    </form>
</body>
</html>
