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
    <td width="80%" height="20" id="path2">��ǰλ�ã�<a href="/">��ҳ</a> > ��Ա��������</td>
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
<li id="mee0" class="me2" onclick="javascript:self.location='accountmanagement.aspx'">�����˻�</li>
<li id="mee1" class="me2" onclick="javascript:self.location='fetchpoint.aspx'">��ȡ����</li>
<li id="mee2" class="me3" >������ϸ</li>
<li id="mee3" class="me2" onclick="javascript:self.location='pointspread.aspx'">�ҵ��ƹ����</li>
</ul>
</div>
</td>
        <td width="19%">&nbsp;</td>
      </tr>
    </table>
<!--����-->
<table width="100%" border="0" cellspacing="0" cellpadding="0" style="margin-top:10px" id="mse0">
        <tr>
          <td>
         <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
              <td width="15%" height="30" align="center"><strong>������</strong></td>
              <td width="20%" align="center"><strong>��������</strong></td>
              <td width="25%" align="center"><strong>����ʱ��</strong></td>
              <td width="15%" align="center"><strong>�������</strong></td>
              <td width="10%" align="center"><strong>�ѻ�ȡ����</strong></td>
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
              <td width="15%" align="center"><%#Eval("TotalPrice")%>Ԫ</td>
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
            <asp:AspNetPager CssClass="anpager2" CurrentPageButtonClass="cpb" ID="WebPager" runat="server" FirstPageText="�� ҳ" LastPageText="ĩ ҳ" NextPageText="��һҳ" PrevPageText="��һҳ"
                AlwaysShow="false" ShowDisabledButtons="false" ShowPageIndexBox="Never" onpagechanged="WebPager_PageChanged" PageSize="5" UrlPaging="true">
            </asp:AspNetPager>
          </td>
        </tr>
        <tr>
          <td valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0" style="border:1px solid #dedee0; background-color:#fffee2">
            <tr>
<td width="48%" valign="top" style="padding:20px;line-height:24px;font-size:14px">
ʲô���ʻ���<BR /> �˻�����ǻ�Ա�˻��������ʣ�µ��ܽ�<BR /> 
�˻���������֧��������<BR /> 
�˻��������֡�<BR /> 
�ҵ��ʻ�Ϊʲô�������
</td>
    <td width="52%" valign="top" style="padding:20px;line-height:24px;font-size:14px">1�����ر����Ѿ�֧���Ķ�������ѡ��ת���˻���<BR /> 
2���������˿�ʱѡ���������˻���<BR /> 
3����·����Ӷ�������Զ������˻���<BR /> 
4����·�����͵���<BR /> 
5�������������ѯ���߿ͷ���</td>
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
