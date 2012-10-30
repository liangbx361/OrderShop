<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="search.aspx.cs" Inherits="web.search" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title><%=webset.WebName%></title>
    <meta name="keywords" content="<%=webset.WebKeywords %>" />
    <meta name="description" content="<%=webset.WebDescription %>" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/userfavorite.js" type="text/javascript"></script>
    <script src="js/userarea.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function() {
            $(window).scroll(function() {
                if ($(window).scrollTop() > $(window).height() / 2) {
                    $('#goTopBtn').show();
                } else {
                    $('#goTopBtn').hide();
                }
            });
            $('#goTopBtn').click(function() {
                $(window).scrollTop(0);
            });
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <ucl:Header ID="Header" runat="server" />
    <div id="main">
<table width="100%" border="0" cellspacing="0" cellpadding="0" style=" position:relative;margin-top:10px;">
  <tr>
    <td>
<table id="ps2" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="188">&nbsp;</td>
    <td width="74">&nbsp;</td>
    <td width="198" id="ps3">&nbsp;</td>
    <td width="557" valign="middle">
     <div style="text-align:right;">
        <asp:AspNetPager CssClass="anpager" CurrentPageButtonClass="cpb" ID="AspNetPager1" runat="server" CloneFrom="WebPager">
        </asp:AspNetPager>
     </div>
    </td>
  </tr>
</table>
<table width="100%" border="0" cellspacing="0" cellpadding="0" style="border:1px solid #e6e6e6;border-top:none;" >
  <tr>
    <td valign="top" style="padding-top:30px;">
<asp:Repeater ID="rpt_shoplist" runat="server" EnableViewState="false"><ItemTemplate>
<table width="100%" border="0" cellspacing="0" cellpadding="0" style="height:160px;border-bottom:1px solid #e6e6e6;">
  <tr>
    <td width="230" rowspan="2" align="center" class="bdms_01"><a href="shopinfo.aspx?shopid=<%#Eval("id") %>"><img src="<%#Eval("ShopPic") %>" width="200" height="120" border="0" /></a></td>
    <td colspan="2"><table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="66%" height="40" valign="bottom"><a href="shopinfo.aspx?shopid=<%#Eval("id") %>" class="bdms_02"><%#Eval("ShopName") %></a></td>
    <td width="34%"><span class="bdms_03"><a href="shoporderlist.aspx?shopid=<%#Eval("id") %>">近期订单(<span><%#Eval("ShopOrder")%></span>)</a></span><span class="bdms_05"><a href="shopcommentlist.aspx?shopid=<%#Eval("id") %>">餐厅点评(<span><%#Eval("ShopComment") %></span>)</a></span><span class="bdms_04"><a href="javascript:;" onclick="favoriteshop(<%#Eval("id") %>)">收藏</a></span></td>
  </tr>
</table>
</td>
    </tr>
  <tr>
    <td valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td height="25"><span class="bdms_15" style="float:left; padding-right:10px;"><div class="star<%#Eval("AvgPoint") %>"></div></span><span class="bdms_07">口味：<span><%#Eval("AvgTastePoint")%></span> 环境：<span><%#Eval("AvgMilieuPoint")%></span> 服务：<span><%#Eval("AvgServicePoint")%></span></span></td>
      </tr>
      <tr>
        <td height="23"><span class="bdms_08">地址：<%#Eval("Address") %></span></td>
      </tr>
      <tr>
        <td height="25" style="color:#999;font-size:13px;"><span class="bdms_10"><%#Eval("LimitPrice")%>元起送</span><span class="bdms_11">外送费<%#Eval("SendPrice").Equals(0) ? "无" : Eval("SendPrice") + "元"%></span><span class="bdms_12">约<%#Eval("SendTime")%>分钟送达</span><span class="bdms_13">餐到付款</span></td>
      </tr>
      <tr><td height="22"><span class="bdms_06">营业时间：<%#Eval("opentime")%></span><span class="bdms_06">预定时间：<%#Eval("ordertime") %></span></td>
      </tr>
    </table></td>
    <td width="16%"><span class="bdms_14"><a href="shopinfo.aspx?shopid=<%#Eval("id") %>"><img src="images/yncf_45.gif" width="134" height="37" /></a></span></td>
  </tr>
</table>
</ItemTemplate></asp:Repeater>
<%if (rpt_shoplist.Items.Count == 0) { Response.Write("<div style='padding:10px;height:30px;line-height:30px;'>暂无匹配的店铺信息！</div>"); } %>
<div class="fill"></div>
<div id="goTopBtn" style="display:none;"><img src="images/yncf_17.gif" width="19" height="75" /></div>
<div class="fill"></div>
<div style="text-align:right;">
    <asp:AspNetPager CssClass="anpager" CurrentPageButtonClass="cpb" ID="WebPager" runat="server" FirstPageText="首页" LastPageText="末页" NextPageText="下一页" PrevPageText="上一页"
             AlwaysShow="false" ShowDisabledButtons="false" ShowPageIndexBox="Never" onpagechanged="WebPager_PageChanged" PageSize="10" UrlPaging="true">
    </asp:AspNetPager>
</div>
</td>
  </tr>
</table>
</td>
  </tr>
</table>
    <ucl:Footer ID="Footer" runat="server" />
    </form>
    </form>
</body>
</html>
