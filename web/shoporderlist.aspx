<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="shoporderlist.aspx.cs" Inherits="web.shoporderlist" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title><%=webset.WebName%></title>
    <meta name="keywords" content="<%=webset.WebKeywords %>" />
    <meta name="description" content="<%=webset.WebDescription %>" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/usercommon.js" type="text/javascript"></script>
    <script src="js/userfavorite.js" type="text/javascript"></script>
    <script src="js/userarea.js" type="text/javascript"></script>
    <style type="text/css">
        #menu #menu1 a{background:url(images/yncf_07.gif);font-weight:bold;color:#FFF;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <ucl:Header ID="Header" runat="server" />
    <div id="main">
    <input type="hidden" id="hidden_shopid" runat="server" value="0" />
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="80%" height="20" id="path2">当前位置：<a href="/">邀您吃饭</a> > <a href="shoplist.aspx">外卖餐厅</a> > <%=item.ShopName %></td>
    <td width="4%">分享：</td>
    <td width="16%" id="path3"><a href="#"><img src="images/yncf_50.gif" width="19" height="24" /></a><a href="#"><img src="images/yncf_51.gif" width="20" height="24" /></a><a href="#"><img src="images/yncf_52.gif" width="20" height="24" /></a><a href="#"><img src="images/yncf_53.gif" width="20" height="24" /></a><a href="#"><img src="images/yncf_54.gif" width="20" height="24" /></a><a href="#"><img src="images/yncf_55.gif" width="20" height="24" /></a></td>
  </tr>
</table>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td valign="top">
<table width="100%" border="0" cellspacing="0" cellpadding="0" style="border:1px solid #e6e6e6">
  <tr>
    <td width="9" rowspan="3"></td>
    <td height="10" colspan="3"></td>
    <td width="12"></td>
  </tr>
  <tr>
    <td width="202" height="152" id="cp01"><img src="<%=item.ShopPic %>" width="200" height="150" /></td>
    <td width="20">&nbsp;</td>
    <td valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td height="30" class="bdms_02" style="border-bottom:1px dashed #CCC">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
              <td width="81%" height="30"><%=item.ShopName %></td>
              <td width="19%" align="center"><div style="position:relative"><img style="cursor:pointer" onmouseover="showintro(1)" onmouseout="showintro(0)" src="images/yncf_95.jpg" />
                    <div id="shopintro"><%=item.Intro %></div>
                </div>
              </td>  
            </tr>
            </table>
        </td>
      </tr>
      <tr>
        <td height="24"><span class="bdms_07" style="float:left;">口味：<span><%=item.AvgTastePoint %></span> 环境：<span><%=item.AvgMilieuPoint %></span> 服务：<span><%=item.AvgServicePoint %></span></span> <span class="bdms_15" style="float:left;"><div class="star<%=item.AvgPoint %>"></div></span></td>
      </tr>
      <tr>
        <td height="24"><span class="bdms_08">地址：<%=item.Address %></span></td>
      </tr>
      <tr>
        <td height="24" style="color:#999;font-size:13px;"><span class="bdms_10"><span id="limit"><%=item.LimitPrice %></span>元起送</span><span class="bdms_11">外送费<%=item.SendPrice == 0 ? "无" : item.SendPrice + "元"%></span><span class="bdms_12">约<%=item.SendTime %>分钟送达</span><span class="bdms_13">餐到付款</span></td>
      </tr>
      <tr>
        <td height="30"><span class="bdms_06">营业时间：<%=item.OpenTime %></span><span class="bdms_06">预定时间：<%=item.OrderTime %></span></td>
      </tr>
      <tr>
        <td height="24"><span class="bdms_09"><a href="shopcommentlist.aspx?shopid=<%=item.ShopId %>"><%=item.ShopComment %>封餐后点评</a> /<a href="shoporderlist.aspx?shopid=<%=item.ShopId %>"><%=item.ShopOrder %>笔近期订单</a> /<a href="javascript:;" onclick="favoriteshop(<%=item.ShopId %>)">关注</a></span></td>
      </tr>
    </table></td>
    <td width="12"></td>
  </tr>
  <tr>
    <td height="10" colspan="3"></td>
    <td width="12"></td>
  </tr>
</table>
<table width="100%" border="0" cellspacing="0" cellpadding="0" height="34" background="images/yncf_64.gif" style="margin-top:10px;font-size:14px;font-weight:bold; cursor:pointer">
  <tr>
    <td width="108" align="center" id="mu0" class="mu0"><span onclick="openpage(0)">餐厅菜单</span></td>
    <td width="5" align="center"></td>
    <td width="108" align="center" id="mu1" class="mu1"><span onclick="openpage(1)">订单记录</span></td>
    <td width="5" align="center"></td>
    <td width="108" align="center" id="mu2" class="mu0"><span onclick="openpage(2)">餐厅点评</span></td>
    <td>&nbsp;</td>
  </tr>
</table>
<div style="border:1px solid #e6e6e6;border-top:none;margin-bottom:10px;">
    <div id="content">
<table width="100%" border="0" cellspacing="0" cellpadding="0">
<tr>
<td height="45" valign="middle" style="font-weight:bold;padding-left:20px">> 订单记录 > 累计订单<span style="color:#cd0808;font-weight:bold"><%=item.ShopOrder %></span>笔</td>
</tr>
  <tr>
    <td>
<div style="padding:10px 20px;">
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td class="ca">消费用户</td>
    <td class="ca">消费金额</td>
    <td class="ca">消费份数</td>
    <td class="ca">消费时间</td>
  </tr>
  <asp:Repeater ID="rpt_orderlist" runat="server" EnableViewState="false"><ItemTemplate>
  <tr>
    <td class="cb" align="center"><%#GetUserName(Eval("userid"))%></td>
    <td class="cb" align="center">￥<%#Eval("TotalPrice") %></td>
    <td class="cb cc" align="center"><%#GetOrderCount(Eval("OrderNo").ToString())%>份</td>
    <td class="cb" align="center"><%#Eval("AddTime") %></td>
  </tr>
  </ItemTemplate></asp:Repeater>
</table>
</div>
</td>
  </tr>
  <tr>
    <td style="padding-left:50px;">
        <asp:AspNetPager CssClass="anpager" CurrentPageButtonClass="cpb" ID="WebPager" runat="server" FirstPageText="首页" LastPageText="末页" NextPageText="下一页" PrevPageText="上一页"
             AlwaysShow="false" ShowDisabledButtons="false" ShowPageIndexBox="Never" onpagechanged="WebPager_PageChanged" PageSize="10" UrlPaging="true">
        </asp:AspNetPager>
    </td>
  </tr>
</table>
</div>
</div>
</td>
    <td width="10">&nbsp;</td>
    <td width="242" valign="top">
    <div class="right">
<div id="rightCol">
<div class="shopcar">
<div class="shopcar_top"></div>
<div class="shopcar_middle">
    <div id="order_list">
    </div>
    <div class="shopcar_btn" style=" overflow:hidden;">
        <div class="shopcar_tip">本店非特约，请自行电话订餐</div>
        <div class="shopcar_tel" style="height:70px;"><%=item.Phone %></div>
    </div>
</div>
<div class="shopcar_bottom" style="height:48px; padding-top:6px;"><img src="images/btn_check_order.gif" width="141" height="32" onclick="carnext()" /></div>
</div>
</div>
</div>
    </td>
  </tr>
</table>
</div>
    <ucl:Footer ID="Footer" runat="server" />
    </form>
    <script src="js/shoppingCart.js" type="text/javascript"></script>
</body>
</html>
