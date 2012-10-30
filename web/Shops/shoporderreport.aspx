<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="shoporderreport.aspx.cs" Inherits="web.Shops.shoporderreport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title><%=webset.WebName%></title>
    <link href="/css/style.css" rel="stylesheet" type="text/css" />
    <link href="/common/Date/skin/WdatePicker.css" rel="stylesheet" type="text/css" />
    <script src="/common/Date/WdatePicker.js" type="text/javascript"></script>
    <style type="text/css">
        #dh00 #dh05 a{color:#ff6600;font-weight:bold}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <ucl:Header ID="Header" runat="server" />
    <div id="main">
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="80%" height="20" id="path2">当前位置：<a href="/">首页</a> > 商家管理中心</td>
    <td width="4%"></td>
    <td width="16%" id="path3"></td>
  </tr>
</table>
<table width="100%" border="0" cellspacing="0" cellpadding="0" style="margin:10px 0">
  <tr>
    <td width="190" valign="top"><ucl:UserLeft2 ID="UserLeft2" runat="server" />
</td>
    <td width="20">&nbsp;</td>
    <td valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0" height="31" background="/images/yncf_73.gif">
      <tr>
        <td width="2%">&nbsp;</td>
        <td width="79%">
<div id="me1">
<ul>
<li id="mee0" class="me3" onclick="mee(0)">日订单报表查询</li>
</ul>
</div>
</td>
        <td width="19%">&nbsp;</td>
      </tr>
    </table><table width="100%" border="0" cellspacing="0" cellpadding="0" style="margin-top:10px">
  <tr>
    <td width="30" rowspan="2">&nbsp;</td>
    <td height="35">日期：
      <input type="text" id="txtstartdate" runat="server" style="width:100px;border:1px solid #8ab6dd;height:18px;" class="Wdate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd',autoPickDate:true})" />  
&nbsp;至&nbsp;
<input type="text" id="txtenddate" runat="server" style="width:100px;border:1px solid #8ab6dd;height:18px;" class="Wdate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd',autoPickDate:true})" />
&nbsp;<asp:Button ID="btnsearch" runat="server" Text="查询" onclick="btnsearch_Click" />
</td>
  </tr>
</table>
<table width="100%" border="0" cellspacing="0" cellpadding="0" style="margin-top:10px">
        <tr>
          <td height="33" align="left" bgcolor="#f3f3f3">&nbsp;&nbsp;<strong>订单笔数</strong>：<span style="color:#C00;font-weight:bold"><asp:Literal ID="L_ordercount" runat="server" EnableViewState="false"></asp:Literal></span>  笔&nbsp;&nbsp;&nbsp;&nbsp;<strong>总金额</strong>：<span style="color:#C00;font-weight:bold"><asp:Literal ID="L_sumprice" runat="server"></asp:Literal></span> 元</td>
        </tr>
</table>
<table width="100%" border="0" cellspacing="0" cellpadding="0" style="margin-top:10px" id="mse0">
        <tr>
          <td height="30" bgcolor="#f3f3f3" style="border-top:1px solid #dedee0"><table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
              <td width="12%" height="30" align="center"><strong>序号</strong></td>
              <td width="36%" align="center"><strong>日期</strong></td>
              <td width="29%" align="center"><strong>订单笔数</strong></td>
              <td width="23%" align="center">订单金额（元）<br /></td>
              </tr>
          </table></td>
        </tr>
        <tr>
          <td>

<table width="100%" border="0" cellspacing="0" cellpadding="0" class="sem">
<asp:Repeater ID="rpt_list" runat="server" EnableViewState="false"><ItemTemplate>
            <tr>
              <td width="12%"  height="30" align="center"><%#Container.ItemIndex+1%></td>
              <td width="36%" align="center"><a href="shoporderlist.aspx?date=<%#Eval("date")%>"><%#Eval("date")%></a></td>
              <td width="29%" align="center"><%#Eval("ordercount")%></td>
              <td width="23%" align="center"><%#Eval("sumprice")%>元</td>
              </tr>
</ItemTemplate></asp:Repeater>         
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
      </table>
</td>
  </tr>
</table>

</div>
    <ucl:Footer ID="Footer" runat="server" />
    </form>
</body>
</html>
