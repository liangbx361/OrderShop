<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="accountmanagement.aspx.cs" Inherits="web.Users.accountmanagement" %>
<%@ Import Namespace="Cudo.Entities" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title><%=webset.WebName%></title>
    <link href="/css/style.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery.js" type="text/javascript"></script>
    <script src="/js/userarea.js" type="text/javascript"></script>
    <style type="text/css">
        #dh00 #dh02 a{color:#ff6600;font-weight:bold}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <ucl:Header ID="Header" runat="server" />
    <div id="main">
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="80%" height="20" id="path2">当前位置：<a href="/">首页</a> > 会员管理中心</td>
    <td width="4%"></td>
    <td width="16%" id="path3"></td>
  </tr>
</table>
<table width="100%" border="0" cellspacing="0" cellpadding="0" style="margin:10px 0">
  <tr>
    <td width="190" valign="top"><ucl:UserLeft ID="UserLeft" runat="server" />
</td>
    <td width="20">&nbsp;</td>
    <td valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0" height="31" background="/images/yncf_73.gif">
      <tr>
        <td width="2%">&nbsp;</td>
        <td width="79%">
<div id="me1">
<ul>
<li id="mee0" class="me3" onclick="mee(0)">账户余额</li>
<li id="mee1" class="me2" onclick="javascript:self.location='onlinerecharge.aspx'">在线充值</li>
<li id="mee2" class="me2" onclick="javascript:self.location='rechargeorders.aspx'">充值订单</li>
</ul>
</div>
</td>
        <td width="19%">&nbsp;</td>
      </tr>
    </table>
<!--内容-->
<table width="100%" border="0" cellspacing="0" cellpadding="0" style="margin-top:10px" id="mse0">
        <tr>
          <td height="30" bgcolor="#f3f3f3" style="border-top:1px solid #dedee0;font-size:14px;font-weight:bold;padding-left:20px">积分明细</td>
        </tr>
        <tr>
          <td>
          <%UserInfo item = Session["cudoUser"] as UserInfo;%>
<table width="100%" border="0" cellspacing="0" cellpadding="0" class="sem1">
  <tr>
    <td width="24%" height="35" style="color:#0353ce;padding-left:20px">可用积分</td>
    <td width="76%" style="color:#666666;">已消费积分</td>
  </tr>
  <tr>
    <td height="35" style="color:#b91616;padding-left:20px"><%=item.CurrentPoint %></td>
    <td style="color:#b91616"><%=item.UsePoint %></td>
  </tr>
</table>
        </td>
        </tr>
        <tr>
          <td height="10"></td>
        </tr>
        <tr>
          <td valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0" style="border:1px solid #dedee0; background-color:#fffee2">
  <tr>
    <td width="48%" valign="top" style="padding:20px;line-height:24px;font-size:14px">
什么是帐户余额？<BR /> 账户余额是会员账户金额变更后剩下的总金额。<BR /> 
账户余额可用于支付零数。<BR /> 
账户余额可提现。<BR /> 
我的帐户为什么会产生余额？
</td>
    <td width="52%" valign="top" style="padding:20px;line-height:24px;font-size:14px">1、您关闭了已经支付的订单并且选择转入账户余额。<BR /> 
2、您申请退款时选择了退入账户余额。<BR /> 
3、有路联盟佣金结算金额将自动打入账户余额。<BR /> 
4、有路网赠送的余额。<BR /> 
5、其他情况可咨询在线客服。</td>
  </tr>
</table>
</td>
        </tr>
        </table>
</td>
  </tr>
</table>

</div>
    <ucl:Footer ID="Footer" runat="server" />
    </form>
</body>
</html>
