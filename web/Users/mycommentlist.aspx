<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mycommentlist.aspx.cs" Inherits="web.Users.mycommentlist" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title><%=webset.WebName%></title>
    <link href="/css/style.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery.js" type="text/javascript"></script>
    <script src="/js/usercommon.js" type="text/javascript"></script>
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
    <td width="4%">&nbsp;</td>
    <td width="16%" id="path3">&nbsp;</td>
  </tr>
</table>
<table width="100%" border="0" cellspacing="0" cellpadding="0" style="margin:10px 0">
  <tr>
    <td width="190" valign="top">
        <ucl:UserLeft ID="UserLeft" runat="server" />
    </td>
    <td width="20">&nbsp;</td>
    <td valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0" height="31" background="images/yncf_73.gif">
      <tr>
        <td width="2%">&nbsp;</td>
        <td width="79%">
<div id="me1">
<ul>
<li id="mee0" class="me2" onclick="javascript:self.location='myfavoritelist.aspx'">�ҵ��ղ�</li>
<li id="mee1" class="me3" onclick="javascript:self.location='mycommentlist.aspx'">�ҵ�����</li>
<li id="mee2" class="me2" onclick="javascript:self.location='mymessagelist.aspx'">վ����Ϣ</li>
</ul>
</div>
</td>
        <td width="19%">&nbsp;</td>
      </tr>
    </table>
      <table width="100%" border="0" cellspacing="0" cellpadding="0" style="margin-top:10px">
        <tr>
          <td style="padding:0 20px;">
<asp:Repeater ID="rpt_list" runat="server" OnItemCommand="rpt_list_ItemCommand"><ItemTemplate>
<table width="100%" border="0" cellspacing="0" cellpadding="0" class="af">
  <tr>
    <td height="25" colspan="2"><a href="/shopinfo.aspx?shopid=<%#Eval("ShopId") %>" target="_blank" style="color:#0353ce"><%#Eval("ShopName") %></a></td>
    </tr>
  <tr>
    <td height="25" colspan="2"><span class="bdms_15" style="float:left;"><div class="star<%#Eval("TotalPoint") %>"></div></span> <span class="bdms_07">��ζ��<span><%#Eval("TastePoint")%></span> ������<span><%#Eval("MilieuPoint")%></span> ����<span><%#Eval("ServicePoint")%></span></td>
    </tr>
  <tr>
    <td colspan="2" style="padding:10px 0;line-height:20px"><%#Eval("CommentContent")%></td>
    </tr>
  <tr>
    <td width="95%" height="25" bgcolor="#f9f9f9" style="color:#acb5b4">��<%#Eval("AddTime")%>&nbsp;��������</td>
    <td width="5%" bgcolor="#f9f9f9" class="sc5">
        [<asp:LinkButton ID="lbtn_delete" runat="server" CommandName="del" CommandArgument='<%#Eval("Id") %>' OnClientClick="return confirm('��ȷ��Ҫɾ����')">ɾ��</asp:LinkButton>]
    </td>
  </tr>
</table>
</ItemTemplate></asp:Repeater>
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
