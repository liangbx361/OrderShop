<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="createcomment.aspx.cs" Inherits="web.Users.createcomment" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title><%=webset.WebName%></title>
    <link href="/css/style.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery.js" type="text/javascript"></script>
    <script src="/js/userarea.js" type="text/javascript"></script>
    <style type="text/css">
        #menu #menu1 a{background:url(images/yncf_07.gif);font-weight:bold;color:#FFF;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <ucl:Header ID="Header" runat="server" />
    <div id="main">
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="80%" height="20" id="path2">当前位置：<a href="/">首页</a> > 会员管理中心</td>
    <td width="4%">&nbsp;</td>
    <td width="16%" id="path3">&nbsp;</td>
  </tr>
</table>
<table width="100%" border="0" cellspacing="0" cellpadding="0" style="margin:10px 0">
  <tr>
    <td width="190" valign="top">
        <ucl:UserLeft ID="UserLeft" runat="server" />
    </td>
    <td width="20">&nbsp;</td>
    <td valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0" height="31" background="images/yncf_73.gif">
      <tr>
        <td width="2%">&nbsp;</td>
        <td width="79%">
<div id="me1">
<ul>
<li id="mee0" class="me2" onclick="javascript:self.location='myfavoritelist.aspx'">我的收藏</li>
<li id="mee1" class="me3" onclick="javascript:self.location='mycommentlist.aspx'">我的评论</li>
<li id="mee2" class="me2" onclick="mee(2)">站内信息</li>
</ul>
</div>
</td>
        <td width="19%">&nbsp;</td>
      </tr>
    </table>
      <table width="100%" border="0" cellspacing="0" cellpadding="0" style="margin-top:10px">
        <tr>
          <td style="padding:0 20px;">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" style="border-top:1px solid #e6e6e6;margin-top:20px;font-size:13px">
  <tr>
    <td height="30" colspan="2" bgcolor="#f1f0f0" style="font-size:14px;font-weight:bold;padding-left:30px;" id="dpa">用户评价</td>
    </tr>
  <tr>
    <td width="13%" height="35" align="right">总体评价：<span style="color:#ce0b0b">*&nbsp;</span></td>
    <td width="87%">
    <span class="bdms_15" style="float:left;">
        <div class="shop-rating">
            <span class="star5" id="stars"></span>
            <input type="hidden" id="stars_input" runat="server" name="startinput" value="5" size="2" />
        </div>
    </span><span class="rating-result">点击星星为商户打分</span></td>
  </tr>
  <tr>
    <td height="35" align="right">口味：<span style="color:#ce0b0b">*&nbsp;</span> </td>
    <td><select id="ddltaste" runat="server">
      <option value="0">请选择</option>
      <option value="1">差(1)</option>
      <option value="2">一般(2)</option>
      <option value="3">好(3)</option>
      <option value="4">很好(4)</option>
      <option value="5">非常好(5)</option>
    </select>&nbsp;&nbsp;&nbsp;环境：<span style="color:#ce0b0b">*&nbsp;</span>  
     <select id="ddlmilieu" runat="server">
      <option value="0">请选择</option>
      <option value="1">差(1)</option>
      <option value="2">一般(2)</option>
      <option value="3">好(3)</option>
      <option value="4">很好(4)</option>
      <option value="5">非常好(5)</option>
    </select>&nbsp;&nbsp;&nbsp;服务：<span style="color:#ce0b0b">*&nbsp;</span>
    <select id="ddlservice" runat="server">
      <option value="0">请选择</option>
      <option value="1">差(1)</option>
      <option value="2">一般(2)</option>
      <option value="3">好(3)</option>
      <option value="4">很好(4)</option>
      <option value="5">非常好(5)</option>
    </select> </td>
  </tr>
  <tr>
    <td align="right">评价：<span style="color:#ce0b0b">&nbsp;*&nbsp;</span></td>
    <td>
      <label for="textarea"></label>
      <textarea name="textarea" id="txtcontent" runat="server" cols="80" rows="8"></textarea>
    </td>
  </tr>
  <tr>
    <td>&nbsp;</td>
    <td height="50">
        <asp:LinkButton ID="btnSubmit" runat="server" onclick="btnSubmit_Click" OnClientClick="return checksub()"><img style="margin-left:230px" src="/images/yncf_66.gif" width="81" height="28" /></asp:LinkButton>
    </td>
  </tr>
</table>
          </td>
        </tr>
        <tr>
          <td height="10"></td>
        </tr>
      </table>
</td>
  </tr>
</table>
</div>    
    <ucl:Footer ID="Footer" runat="server" />
    </form>
    <script type="text/javascript">
        var startips = [ '非常差','差', '一般', '好', '很好', '非常好'];
        $("#stars").mousemove(function(e) {
            var e = e || window.event, x = (e.pageX - $(this).offset().left), i = Math.ceil(x / 16);
            if (isNaN(i) || i < 1 || i > 5) i = 1;
            $(this).attr("className", "star" + i);
            $(".rating-result").html(startips[i]);
            $("#stars_input").val(i);
        }).click(function(e) {
            var e = e || window.event, x = (e.pageX - $(this).offset().left), i = Math.ceil(x / 16);
            $(this).attr("className", "star" + i);
            $(".rating-result").html(startips[i]);
            $("#stars_input").val(i);
        });
    </script>
</body>
</html>
