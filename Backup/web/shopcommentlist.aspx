<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="shopcommentlist.aspx.cs" Inherits="web.shopcommentlist" %>

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
    <td width="80%" height="20" id="path2">��ǰλ�ã�<a href="/">�����Է�</a> > <a href="shoplist.aspx">��������</a> > <%=item.ShopName %></td>
    <td width="4%">����</td>
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
        <td height="24"><span class="bdms_07" style="float:left;">��ζ��<span><%=item.AvgTastePoint %></span> ������<span><%=item.AvgMilieuPoint %></span> ����<span><%=item.AvgServicePoint %></span></span> <span class="bdms_15" style="float:left;"><div class="star<%=item.AvgPoint %>"></div></span></td>
      </tr>
      <tr>
        <td height="24"><span class="bdms_08">��ַ��<%=item.Address %></span></td>
      </tr>
      <tr>
        <td height="24" style="color:#999;font-size:13px;"><span class="bdms_10"><span id="limit"><%=item.LimitPrice %></span>Ԫ����</span><span class="bdms_11">���ͷ�<%=item.SendPrice == 0 ? "��" : item.SendPrice + "Ԫ"%></span><span class="bdms_12">Լ<%=item.SendTime %>�����ʹ�</span><span class="bdms_13">�͵�����</span></td>
      </tr>
      <tr>
        <td height="30"><span class="bdms_06">Ӫҵʱ�䣺<%=item.OpenTime %></span><span class="bdms_06">Ԥ��ʱ�䣺<%=item.OrderTime %></span></td>
      </tr>
      <tr>
        <td height="24"><span class="bdms_09"><a href="shopcommentlist.aspx?shopid=<%=item.ShopId %>"><%=item.ShopComment %>��ͺ����</a> /<a href="shoporderlist.aspx?shopid=<%=item.ShopId %>"><%=item.ShopOrder %>�ʽ��ڶ���</a> /<a href="javascript:;" onclick="favoriteshop(<%=item.ShopId %>)">��ע</a></span></td>
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
    <td width="108" align="center" id="mu0" class="mu0"><span onclick="openpage(0)">�����˵�</span></td>
    <td width="5" align="center"></td>
    <td width="108" align="center" id="mu1" class="mu0"><span onclick="openpage(1)">������¼</span></td>
    <td width="5" align="center"></td>
    <td width="108" align="center" id="mu2" class="mu1"><span onclick="openpage(2)">��������</span></td>
    <td>&nbsp;</td>
  </tr>
</table>
    <div style="border:1px solid #e6e6e6;border-top:none;margin-bottom:10px;">
    <div>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
<tr>
<td height="24" valign="top" style="font-weight:bold"><table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="84%" height="45" style="padding-left:20px">> �������� > ��<span style="color:#cd0808;font-weight:bold"><%=item.ShopComment %></span>���������</td>
    <td width="16%">&nbsp;</td>
  </tr>
</table>
</td>
</tr>
  <tr>
    <td>
<asp:Repeater ID="rpt_list" runat="server" EnableViewState="false"><ItemTemplate>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="79%" height="30" bgcolor="#fff0e0" style="padding-left:50px"><%#Eval("UserName") %></td>
    <td width="21%" bgcolor="#fff0e0"><%#Eval("AddTime") %></td>
  </tr>
  <tr>
    <td height="35" colspan="2" style="padding-left:50px"><span class="bdms_15" style="float:left;"><div class="star<%#Eval("TotalPoint")%>"></div></span> <span class="bdms_07">��ζ��<span><%#Eval("TastePoint")%></span> ������<span><%#Eval("MilieuPoint")%></span> ����<span><%#Eval("ServicePoint")%></span></span></td>
    </tr>
  <tr>
    <td colspan="2" style="padding:0 30px 0 50px;">
    <div style="line-height:24px;padding:10px 0;color:#666">
    <%#Eval("CommentContent")%>
    </div>
    </td>
    </tr>
</table>
</ItemTemplate></asp:Repeater>
</td>
  </tr>
  <tr>
    <td style="padding-left:50px;">
        <asp:AspNetPager CssClass="anpager" CurrentPageButtonClass="cpb" ID="WebPager" runat="server" FirstPageText="��ҳ" LastPageText="ĩҳ" NextPageText="��һҳ" PrevPageText="��һҳ"
             AlwaysShow="false" ShowDisabledButtons="false" ShowPageIndexBox="Never" onpagechanged="WebPager_PageChanged" PageSize="5" UrlPaging="true">
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
    <div class="shopcar_btn">
        <div class="shopcar_tip">�������Լ�������е绰����</div>
        <div class="shopcar_tel"><%=item.Phone %></div>
    </div>
</div>
<div class="shopcar_bottom"><img src="images/yncf_59.gif" width="122" height="22" onclick="carnext()" /></div>
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
