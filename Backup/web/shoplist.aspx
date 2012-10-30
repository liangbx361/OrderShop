<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="shoplist.aspx.cs" Inherits="web.shoplist" %>

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
    <style type="text/css">
        #menu #menu1 a{background:url(images/yncf_07.gif);font-weight:bold;color:#FFF;}
    </style>
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
    <input type="hidden" id="hiddenaid" runat="server" value="0" />
    <input type="hidden" id="hiddensid" runat="server" value="0" />
    <ucl:Header ID="Header" runat="server" />
    <div id="main">
<table width="100%" border="0" cellspacing="0" cellpadding="0" id="condition">
    <tr>
    <td style="padding:20px"><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td width="8%" height="35" align="right"><strong>按区域：</strong></td>
        <td width="92%" class="area"><a href="shoplist.aspx?aid=0"><span <%=aid==0?"class=\"qy\"":"" %>>全市</span></a><a href="shoplist.aspx?aid=1"><span <%=aid==1?"class=\"qy\"":"" %>>鼓楼区</span></a><a href="shoplist.aspx?aid=2"><span <%=aid==2?"class=\"qy\"":"" %>>台江区</span></a><a href="shoplist.aspx?aid=3"><span <%=aid==3?"class=\"qy\"":"" %>>晋安区</span></a><a href="shoplist.aspx?aid=4"><span <%=aid==4?"class=\"qy\"":"" %>>仓山区</span></a></td>
      </tr>
      <tr>
        <td>&nbsp;</td>
        <td class="city" id="city_street">
            <asp:Repeater ID="rpt_streets" runat="server" EnableViewState="false"><ItemTemplate>
            <a href="shoplist.aspx?aid=<%#Eval("Pid") %>&sid=<%#Eval("Id") %>" <%#Eval("Id").Equals(sid)?"class=\"current\"":"" %>>[<%#Eval("AreaName") %>]</a>
            </ItemTemplate></asp:Repeater>
        </td>
      </tr>
    </table></td>
  </tr>
  <tr>
    <td style="padding:0 20px;"><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td width="8%" height="35" align="right"><strong>楼宇\小区：</strong></td>
        <td width="92%" class="area1" id="city_district"><span id="z" class="qy" onclick="seltZM2('')">全部</span><span id="zA" onclick="seltZM2('A')">A</span><span id="zB" onclick="seltZM2('B')">B</span><span id="zC" onclick="seltZM2('C')">C</span><span id="zD" onclick="seltZM2('D')">D</span><span id="zE" onclick="seltZM2('E')">E</span><span id="zF" onclick="seltZM2('F')">F</span><span id="zG" onclick="seltZM2('G')">G</span><span id="zH" onclick="seltZM2('H')">H</span><span id="zI" onclick="seltZM2('I')">I</span><span id="zJ" onclick="seltZM2('J')">J</span><span id="zK" onclick="seltZM2('K')">K</span><span id="zL" onclick="seltZM2('L')">L</span><span id="zM" onclick="seltZM2('M')">M</span><span id="zN" onclick="seltZM2('N')">N</span><span id="zO" onclick="seltZM2('O')">O</span><span id="zP" onclick="seltZM2('P')">P</span><span id="zQ" onclick="seltZM2('Q')">Q</span><span id="zR" onclick="seltZM2('R')">R</span><span id="zS" onclick="seltZM2('S')">S</span><span id="zT" onclick="seltZM2('T')">T</span><span id="zU" onclick="seltZM2('U')">U</span><span id="zV" onclick="seltZM2('V')">V</span><span id="zW" onclick="seltZM2('W')">W</span><span id="zX" onclick="seltZM2('X')">X</span><span id="zY" onclick="seltZM2('Y')">Y</span><span id="zZ" onclick="seltZM2('Z')">Z</span></td>
      </tr>
      <tr>
        <td></td>
<td><div id="s1" style="display:<%=did > 0 ||aid==0 ? "none" : "block"%>"><ul id="path1">
<asp:Repeater ID="rpt_district" runat="server" EnableViewState="false"><ItemTemplate>
<li><a href="shoplist.aspx?aid=<%#GetPidById(Eval("Pid")) %>&sid=<%#Eval("Pid") %>&did=<%#Eval("Id") %>"><%#Eval("AreaName") %></a></li>
</ItemTemplate></asp:Repeater>
</ul>
<div class="fill"></div>
<div style="height:10px"></div>
</div>
</td></tr>
    </table></td>
  </tr>
</table>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td background="images/yncf_32.GIF" height="5"></td>
  </tr>
<tr>
<td align="center"><img id="img1" onclick="path1()" src="images/yncf_33.GIF" /></td>
</tr>
</table>
<div style="position:relative; height:25px;">
<table id="ps2" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="188">&nbsp;</td>
    <td width="74">您已选择：</td>
    <td width="198" id="ps3"><%if (AreaName!=string.Empty){ %><div><span><%=AreaName%></span><span><a href="javascript:;" onclick="javascript:self.location='shoplist.aspx'"><img src="images/yncf_39.gif"/></a></span></div><%} %></td>
    <td width="557" valign="middle">
     <div style="text-align:right;">
        <asp:AspNetPager CssClass="anpager" CurrentPageButtonClass="cpb" ID="AspNetPager1" runat="server" CloneFrom="WebPager">
        </asp:AspNetPager>
     </div>
    </td>
  </tr>
</table>
</div>
<table width="100%" border="0" cellspacing="0" cellpadding="0" style="margin-top:10px;">
  <tr>
    <td>
<table width="100%" border="0" cellspacing="0" cellpadding="0" background="images/yncf_12.gif" height="58" style="margin-top:10px;">
  <tr>
    <td height="26" colspan="2" style="font-weight:bold;color:#FFF;padding-left:20px">所有餐店(<%=WebPager.RecordCount %>)</td>
    </tr>
  <tr>
    <td width="79%" id="cx" height="32">菜系：<a href="<%=CreateTypeUrl() %>typeid=0" <%=TypeId.Equals(0)?"class=\"dq1\"":"" %>>全部</a>
    <asp:Repeater ID="rpt_shoptypelist" runat="server" EnableViewState="false"><ItemTemplate>
    &nbsp;&nbsp;<a href="<%=CreateTypeUrl() %>typeid=<%#Eval("Id") %>" <%#Eval("Id").Equals(TypeId)?"class=\"dq1\"":"" %>><%#Eval("TypeName") %></a>
    </ItemTemplate></asp:Repeater>
    </td>
    <td width="21%"><table width="200" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td>排序：</td>
    <td id="time1"><a href="<%=CreateSortUrl() %>order=time" <%=sortstr=="time"?"class=\"time2\"":"" %>>时间</a><a href="<%=CreateSortUrl() %>order=hit" <%=sortstr=="hit"?"class=\"time2\"":"" %>>人气</a><a href="<%=CreateSortUrl() %>order=point"<%=sortstr=="point"?"class=\"time2\"":"" %>>评分</a></td>
  </tr>
</table>
</td>
  </tr>
</table>
<table width="100%" border="0" cellspacing="0" cellpadding="0" style="border:1px solid #e6e6e6;border-top:none;" >
  <tr>
    <td valign="top" style="padding-top:30px;">
<asp:Repeater ID="rpt_shoplist" runat="server" EnableViewState="false"><ItemTemplate>
<table width="100%" border="0" cellspacing="0" cellpadding="0" style="height:160px;border-bottom:1px solid #e6e6e6;">
  <tr>
    <td width="230" rowspan="2" align="center" class="bdms_01"><a href="shopinfo.aspx?shopid=<%#Eval("id") %>" target="_blank"><img src="<%#Eval("ShopPic") %>" width="200" height="120" border="0" /></a></td>
    <td colspan="2"><table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="66%" height="40" valign="bottom"><a href="shopinfo.aspx?shopid=<%#Eval("id") %>" class="bdms_02" target="_blank"><%#Eval("ShopName") %></a></td>
    <td width="34%"><span class="bdms_03"><a href="shoporderlist.aspx?shopid=<%#Eval("id") %>" target="_blank">近期订单(<span><%#Eval("ShopOrder")%></span>)</a></span><span class="bdms_05"><a href="shopcommentlist.aspx?shopid=<%#Eval("id") %>" target="_blank">餐厅点评(<span><%#Eval("ShopComment") %></span>)</a></span><span class="bdms_04"><a href="javascript:;" onclick="favoriteshop(<%#Eval("id") %>)">收藏</a></span></td>
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
    <td width="16%"><span class="bdms_14"><a href="shopinfo.aspx?shopid=<%#Eval("id") %>" target="_blank"><img src="images/yncf_45.gif" width="134" height="37" /></a></span></td>
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
    <script src="js/userarea.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function() {
            if ($("#s1").css("display") == "block") {
                $("#img1").attr("src","images/yncf_33.GIF");
            }
            else {
                $("#img1").attr("src", "images/yncf_34.GIF");
            }
        });
        function path1() {
            if ($("#s1").css("display") == "none") {
                $("#s1").css("display", "block");
                $("#img1").attr("src", "images/yncf_33.GIF");
            } else {
                $("#s1").css("display", "none");
                $("#img1").attr("src", "images/yncf_34.GIF");
            }
        }
    </script>
</body>
</html>
