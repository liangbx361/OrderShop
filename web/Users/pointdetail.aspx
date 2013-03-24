<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pointdetail.aspx.cs" Inherits="web.Users.pointdetail" %>
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
<li id="mee0" class="me2" onclick="javascript:self.location='accountmanagement.aspx'">积分账户</li>
<li id="mee1" class="me2" onclick="javascript:self.location='fetchpoint.aspx'">收取积分</li>
<li id="mee2" class="me3" >积分明细</li>
<li id="mee3" class="me2" onclick="javascript:self.location='pointspread.aspx'">我的推广积分</li>
</ul>
</div>
</td>
        <td width="19%">&nbsp;</td>
      </tr>
    </table>
<!--内容-->
<table width="100%" border="0" cellspacing="0" cellpadding="0" style="margin-top:10px" id="mse0">
        <tr>
          <td>
         <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
              <td width="15%" height="30" align="center"><strong>订单号</strong></td>
              <td width="20%" align="center"><strong>餐厅名称</strong></td>
              <td width="25%" align="center"><strong>订单时间</strong></td>
              <td width="15%" align="center"><strong>订单金额</strong></td>
              <td width="10%" align="center"><strong>已获取积分</strong></td>
            </tr>
          </table>
        </td>
        </tr>
        <tr>
          <td>
<table width="100%" border="0" cellspacing="0" cellpadding="0" class="sem">
<asp:Repeater ID="rpt_list" runat="server" EnableViewState="false">
    <ItemTemplate>
            <tr>
              <td width="15%"  height="30" align="center"><a href="orderinfo.aspx?orderno=<%#Eval("OrderNo") %>&keepThis=true&TB_iframe=true" style="color:#1d54a5" class="thickbox"><%#Eval("OrderNo")%></a></td>
              <td width="20%" align="center"><a href="/shopinfo.aspx?shopid=<%#Eval("ShopId") %>"><%#Eval("ShopName")%></a></td>
              <td width="25%" align="center"><%#Eval("AddTime")%></td>
              <td width="15%" align="center"><%#Eval("TotalPrice")%>元</td>
              <td width="10%" align="center"><%# getOrderPoint(Eval("OrderPoint")) %></td>
            </tr>
    </ItemTemplate>
</asp:Repeater>         
</table>
</td>
        </tr>
        <tr>
          <td height="10"></td>
        </tr>
        <tr>
          <td height="33" align="center" bgcolor="#f3f3f3" class="se">
            <asp:AspNetPager CssClass="anpager2" CurrentPageButtonClass="cpb" ID="WebPager" runat="server" FirstPageText="首 页" LastPageText="末 页" NextPageText="下一页" PrevPageText="上一页"
                AlwaysShow="false" ShowDisabledButtons="false" ShowPageIndexBox="Never" onpagechanged="WebPager_PageChanged" PageSize="5" UrlPaging="true">
            </asp:AspNetPager>
          </td>
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
