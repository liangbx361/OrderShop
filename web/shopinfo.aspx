<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="shopinfo.aspx.cs" Inherits="web.shopinfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title><%=webset.WebName%></title>
    <meta name="keywords" content="<%=webset.WebKeywords %>" />
    <meta name="description" content="<%=webset.WebDescription %>" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link href="css/thickbox.jquery.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/thickbox.jquery.js" type="text/javascript"></script>
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
    <td width="80%" height="20" id="path2">当前位置：<a href="/index.aspx">邀您吃饭</a> > 
        <asp:LinkButton id="shopListLink" runat="server" onclick="shopInof_onClick">外卖餐厅</asp:LinkButton> > <%=item.ShopName %></td>
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
    <td width="108" align="center" id="mu0" class="mu1"><span onclick="openpage(0)">餐厅菜单</span></td>
    <td width="5" align="center"></td>
    <td width="108" align="center" id="mu1" class="mu0"><span onclick="openpage(1)">订单记录</span></td>
    <td width="5" align="center"></td>
    <td width="108" align="center" id="mu2" class="mu0"><span onclick="openpage(2)">餐厅点评</span></td>
    <td>&nbsp;</td>
  </tr>
</table>
<div style="border:1px solid #e6e6e6;border-top:none;margin-bottom:10px;">
<div id="men0">
<table width="100%" border="0" cellspacing="0" cellpadding="0" background="images/yncf_91.gif">
  <tr>
    <td width="18%" height="30" style="padding-left:10px;">显示方式：<a href="shopinfo.aspx?shopid=<%=shopid %>&see_pic=0"><img src="images/text_act.gif" /></a> <a href="shopinfo.aspx?shopid=<%=shopid %>&see_pic=1"><img src="images/grid_act.gif" /></a></td>
    <td width="82%" align="right" style="padding-right:10px;">
        <a href="#">全部</a>&nbsp;&nbsp;
        <asp:Repeater ID="rpt_typelist" runat="server" EnableViewState="false"><ItemTemplate>
        <a href="#cd_<%#Eval("Id") %>"><%#Eval("TypeName") %></a>&nbsp;&nbsp;
        </ItemTemplate></asp:Repeater>
    </td>
  </tr>
</table>
<div style="padding:10px 20px;">
<asp:Repeater ID="rpt_tyleprolist" runat="server" EnableViewState="false"><ItemTemplate>
<table width="100%" border="0" cellspacing="0" cellpadding="0" style="margin-bottom:10px;">
<tr>
<td style="font-size:14px;font-weight:bold;border-bottom:1px solid #CCC;line-height:30px;" id="cd_<%#Eval("Id") %>">
    &nbsp;>&nbsp;<%#Eval("TypeName") %><% if (see_pic == 0)
       {%><ul class="cdlist2" style="position:absolute; z-index:10; margin-top:-30px;">
	    <li style="border-bottom:none;">
            <span class="sl"></span>
            <span class="sr"></span>
		    <img src="/images/cfw_yjtu.gif" style="margin-left:196px;"/>
		    <S class="price"></S>
		    <img src="/images/cfw_hyjtu.gif"/>
		    <span class="price2" color=#ffff></span>		
	    </li>
        <li style="border-bottom:none;">
            <span class="sl"></span>
            <span class="sr"></span>
		    <img src="/images/cfw_yjtu.gif"style="margin-left:196px;" />
		    <S class="price"></S>
		    <img src="/images/cfw_hyjtu.gif"/>
		    <span class="price2" color=#ffff></span>		
	    </li>
    </ul> 
    <% } %>
</td>
</tr>
  <tr>
    <td>
        <%#GetProductByTypeId(Eval("Id")) %>
    </td>
  </tr>
</table>
</ItemTemplate></asp:Repeater>
</div>
</div>
<!--ctcd-->
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
        <div class="shopcar_tip">非网络订餐时段请自行电话订餐</div>
        <div class="shopcar_tel" style="height:70px;"><%=item.Phone %></div>
    </div>
</div>
<div class="shopcar_bottom" style="height:48px; padding-top:6px;"><img src="images/btn_check_order.gif" width="141" height="32" onclick="carnext()" onmouseover="fansy_order_onm(this)" onmouseout="fansy_order_out(this)"/></div>
</div>
</div>
</div>
    </td>
  </tr>
</table>
</div>
    <ucl:Footer ID="Footer" runat="server" />
    <a id="mdyadd" href="modifyaddress.aspx?keepThis=true&TB_iframe=true&width=400&height=200" title="请选择默认送餐地址" style="display:none;" class="thickbox">更新地址</a>
    <a id="mdyadd2" href="modifyaddress2.aspx?keepThis=true&TB_iframe=true&width=750&height=450" title="更新地址" style="display:none;" class="thickbox">更新地址</a>
    </form>
    <script src="js/shoppingCart.js" type="text/javascript"></script>
</body>
</html>
