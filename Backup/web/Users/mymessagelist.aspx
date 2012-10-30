<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mymessagelist.aspx.cs" Inherits="web.Users.mymessagelist" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title><%=webset.WebName%></title>
    <link href="/css/style.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery.js" type="text/javascript"></script>
    <script src="/js/userarea.js" type="text/javascript"></script>
    <style type="text/css">
       #dh00 #dh04 a{color:#ff6600;font-weight:bold}
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
    <td width="190" valign="top"><ucl:UserLeft ID="UserLeft" runat="server" /></td>
    <td width="20">&nbsp;</td>
    <td valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0" height="31" background="/images/yncf_73.gif">
      <tr>
        <td width="2%">&nbsp;</td>
        <td width="79%">
<div id="me1">
<ul>
<li id="mee0" class="me2" onclick="javascript:self.location='myfavoritelist.aspx'">�ҵ��ղ�</li>
<li id="mee1" class="me2" onclick="javascript:self.location='mycommentlist.aspx'">�ҵ�����</li>
<li id="mee2" class="me3" onclick="javascript:self.location='mymessagelist.aspx'">վ����Ϣ</li>
</ul>
</div>
</td>
        <td width="19%"></td>
      </tr>
    </table>
<table width="100%" border="0" cellspacing="0" cellpadding="0" style="margin-top:10px" id="mse0">
        <tr>
          <td height="30" bgcolor="#f3f3f3" style="border-top:1px solid #dedee0"><table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
              <td width="45%" height="30" align="center"><strong>�� ��</strong></td>
              <td width="15%" align="center"><strong>����</strong></td>
              <td width="10%" align="center"><strong>״̬</strong></td>
              <td width="10%" align="center"><strong>����</strong></td>
            </tr>
          </table></td>
        </tr>
        <tr>
          <td>
<table width="100%" border="0" cellspacing="0" cellpadding="0" class="sem">
<asp:Repeater ID="rpt_list" runat="server" onitemcommand="rpt_list_ItemCommand"><ItemTemplate>
            <tr>
              <td width="45%"  height="30" align="center"><a href="messageinfo.aspx?id=<%#Eval("Id") %>" style="color:#1d54a5" class="thickbox"><%#Eval("Title")%></a></td>
              <td width="15%" align="center"><%#Eval("AddTime")%></td>
              <td width="10%" align="center"><%#Eval("Status").Equals(0) ? "<font color='red'>δ��</font>" : "<font color='green'>�Ѷ�</font>"%></td>
              <td width="10%" align="center"><asp:LinkButton ID="lbtndel" runat="server" CommandArgument='<%#Eval("Id") %>' CommandName="del" Text="ɾ��" style="color:#1d54a5"></asp:LinkButton></td>
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
            <asp:AspNetPager CssClass="anpager2" CurrentPageButtonClass="cpb" ID="WebPager" runat="server" FirstPageText="�� ҳ" LastPageText="ĩ ҳ" NextPageText="��һҳ" PrevPageText="��һҳ"
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
