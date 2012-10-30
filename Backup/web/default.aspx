<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="web._default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title><%=webset.WebName%></title>
    <meta name="keywords" content="<%=webset.WebKeywords %>" />
    <meta name="description" content="<%=webset.WebDescription %>" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/jquery.pack.js" type="text/javascript"></script>
    <script src="js/jQuery.blockUI.js" type="text/javascript"></script>
    <script src="js/jquery.SuperSlide.js" type="text/javascript"></script>
    <style type="text/css">
        #menu #menu0 a{background:url(images/yncf_07.gif);font-weight:bold;color:#FFF;}
        .banner{ margin-top:5px;text-align:center;}
        .slideBox{ width:996px; height:130px; overflow:hidden; margin:0 auto; position:relative;}  
        .slideBox .hd{ height:15px; overflow:hidden; position:absolute; right:10px; bottom:10px; z-index:1; }  
        .slideBox .hd ul{ overflow:hidden; zoom:1; float:left;}  
        .slideBox .hd ul li{ float:left; margin-right:5px; width:15px; height:15px; line-height:14px; text-align:center; background:#fff; cursor:pointer; }  
        .slideBox .hd ul li.on{ background:#f00; color:#fff;}  
        .slideBox .bd{ position:relative; height:100%; z-index:0;}  
        .slideBox .bd img{ width:996px; height:130px; }  
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
    <div class="banner">
        <div id="slideBox" class="slideBox">
					<div class="hd">
						<ul><asp:Repeater ID="rpt_advertnum" runat="server" EnableViewState="false"><ItemTemplate><li><%#Container.ItemIndex+1 %></li></ItemTemplate></asp:Repeater></ul>
					</div>
					<div class="bd">
						<ul><asp:Repeater ID="rpt_adverts" runat="server" EnableViewState="false"><ItemTemplate>
						    <li><a href="<%#Eval("AdvertLink") %>"><img src="<%#Eval("AdvertPic") %>" /></a></li></ItemTemplate></asp:Repeater>
						</ul>
					</div>
				</div>
				<script type="text/javascript">jQuery(".slideBox").slide({ mainCell: ".bd ul", effect: "leftLoop", autoPlay: true });</script>
    </div>
    <div id="main">
    <table width="100%" border="0" cellspacing="0" cellpadding="0" id="condition">
    <tr>
    <td style="padding:20px"><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td width="8%" height="35" align="right"><strong>按区域：</strong></td>
        <td width="92%" class="area"><a href="default.aspx?aid=0"><span <%=aid==0?"class=\"qy\"":"" %>>全市</span></a><a href="default.aspx?aid=1"><span <%=aid==1?"class=\"qy\"":"" %>>鼓楼区</span></a><a href="default.aspx?aid=2"><span <%=aid==2?"class=\"qy\"":"" %>>台江区</span></a><a href="default.aspx?aid=3"><span <%=aid==3?"class=\"qy\"":"" %>>晋安区</span></a><a href="default.aspx?aid=4"><span <%=aid==4?"class=\"qy\"":"" %>>仓山区</span></a></td>
      </tr>
      <tr>
        <td>&nbsp;</td>
        <td class="city" id="city_street">
            <asp:Repeater ID="rpt_streets" runat="server" EnableViewState="false"><ItemTemplate>
            <a href="default.aspx?aid=<%#Eval("Pid") %>&sid=<%#Eval("Id") %>" <%#Eval("Id").Equals(sid)?"class=\"current\"":"" %>>[<%#Eval("AreaName") %>]</a>
            </ItemTemplate></asp:Repeater>
        </td>
      </tr>
    </table></td>
  </tr>
  <tr>
    <td style="padding:0 20px;"><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td width="8%" height="35" align="right"><strong>楼宇\小区：</strong></td>
        <td width="92%" class="area1" id="city_district"><span id="z" class="qy" onclick="seltZM1('')">全部</span><span id="zA" onclick="seltZM1('A')">A</span><span id="zB" onclick="seltZM1('B')">B</span><span id="zC" onclick="seltZM1('C')">C</span><span id="zD" onclick="seltZM1('D')">D</span><span id="zE" onclick="seltZM1('E')">E</span><span id="zF" onclick="seltZM1('F')">F</span><span id="zG" onclick="seltZM1('G')">G</span><span id="zH" onclick="seltZM1('H')">H</span><span id="zI" onclick="seltZM1('I')">I</span><span id="zJ" onclick="seltZM1('J')">J</span><span id="zK" onclick="seltZM1('K')">K</span><span id="zL" onclick="seltZM1('L')">L</span><span id="zM" onclick="seltZM1('M')">M</span><span id="zN" onclick="seltZM1('N')">N</span><span id="zO" onclick="seltZM1('O')">O</span><span id="zP" onclick="seltZM1('P')">P</span><span id="zQ" onclick="seltZM1('Q')">Q</span><span id="zR" onclick="seltZM1('R')">R</span><span id="zS" onclick="seltZM1('S')">S</span><span id="zT" onclick="seltZM1('T')">T</span><span id="zU" onclick="seltZM1('U')">U</span><span id="zV" onclick="seltZM1('V')">V</span><span id="zW" onclick="seltZM1('W')">W</span><span id="zX" onclick="seltZM1('X')">X</span><span id="zY" onclick="seltZM1('Y')">Y</span><span id="zZ" onclick="seltZM1('Z')">Z</span></td>
      </tr>
      <tr>
        <td></td>
<td><div id="s1" style="display:<%=did > 0 ||aid==0 ? "none" : "block"%>"><ul id="path1">
<asp:Repeater ID="rpt_district" runat="server" EnableViewState="false"><ItemTemplate>
<li><a href="default.aspx?aid=<%#GetPidById(Eval("Pid")) %>&sid=<%#Eval("Pid") %>&did=<%#Eval("Id") %>"><%#Eval("AreaName") %></a></li>
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
<div id="product">
<div class="fill"></div>
<asp:Repeater ID="rpt_list" runat="server" EnableViewState="false"><ItemTemplate>
<table id="pdt" cellspacing="0" cellpadding="0" class="pr_box">
  <tr>
    <td valign="top" class="pdt1"><a href="shopinfo.aspx?shopid=<%#Eval("id") %>"><img src="<%#Eval("shoppic") %>" width="212" height="160" border="0" /></a></td>
  </tr>
  <tr>
    <td height="20" class="pdt2">营业时间：<%#Eval("opentime") %></td>
  </tr>
  <tr>
    <td height="20" class="pdt3">口味：<span><%#Eval("AvgTastePoint")%></span> 环境：<span><%#Eval("AvgMilieuPoint")%></span> 服务：<span><%#Eval("AvgServicePoint")%></span></td>
  </tr>
  <tr>
    <td height="20" class="pdt4"><div class="star<%#Eval("AvgPoint") %>"></div>
    </td>
  </tr>
  <tr>
    <td height="60" class="pdt5"><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td><a href="shopinfo.aspx?shopid=<%#Eval("id") %>"><img src="images/yncf_37.gif" width="134" height="42" /></a></td>
        <td valign="bottom" class="pdt6">历史订单<span><%#Eval("ShopOrder") %></span>笔</td>
      </tr>
    </table></td>
  </tr>
</table>
</ItemTemplate></asp:Repeater>
<%if (rpt_list.Items.Count == 0) { Response.Write("<div style='padding:10px;height:30px;line-height:30px;'>暂无匹配的店铺信息！</div>"); } %>
<div class="fill"></div>
<div id="goTopBtn" style="display:none;"><img src="images/yncf_17.gif" width="19" height="75" /></div>
<div class="fill"></div>
<div style="text-align:right;">
    <asp:AspNetPager CssClass="anpager" CurrentPageButtonClass="cpb" ID="WebPager" runat="server" FirstPageText="首页" LastPageText="末页" NextPageText="下一页" PrevPageText="上一页"
             AlwaysShow="false" ShowDisabledButtons="false" ShowPageIndexBox="Never" onpagechanged="WebPager_PageChanged" PageSize="16" UrlPaging="true">
    </asp:AspNetPager>
</div>
</div>
</div>
    <ucl:Footer ID="Footer" runat="server" />
    </form>
    <script src="js/userarea.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function() {
            if ($("#s1").css("display") == "block") {
                $("#img1").attr("src", "images/yncf_33.GIF");
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
