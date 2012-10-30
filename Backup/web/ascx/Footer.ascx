<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Footer.ascx.cs" Inherits="web.Footer" %>
<table border="0" cellspacing="0" cellpadding="0" class="wrad">
  <tr>
    <td height="18" background="/images/yncf_38.GIF">&nbsp;</td>
  </tr>
</table>
<table class="wrad" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="25%" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td><img src="/images/yncf_18.GIF" width="222" height="30" /></td>
  </tr>
  <tr>
    <td class="list"><ul>
    <asp:Repeater ID="rpt_help" runat="server" EnableViewState="false"><ItemTemplate>
    <li><a href="help.aspx?id=<%#Eval("Id") %>"><%#Eval("NewTitle")%></a></li>
    </ItemTemplate></asp:Repeater>
</ul></td>
  </tr>
</table>
</td>
    <td width="25%" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td><img src="/images/yncf_19.GIF" width="222" height="30" /></td>
  </tr>
  <tr>
    <td class="list"><ul>
    <li><a href="busecooperation.aspx">商家合作</a></li>
    <asp:Repeater ID="rpt_hz" runat="server" EnableViewState="false"><ItemTemplate>
    <li><a href="cooperation.aspx?id=<%#Eval("Id") %>"><%#Eval("NewTitle")%></a></li>
    </ItemTemplate></asp:Repeater>
</ul></td>
  </tr>
</table></td>
    <td width="25%" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td><img src="/images/yncf_20.GIF" width="222" height="30" /></td>
  </tr>
  <tr>
    <td class="list"><ul>
    <li><a href="feedback.aspx">意见反馈</a></li>
    <asp:Repeater ID="rpt_about" runat="server" EnableViewState="false"><ItemTemplate>
    <li><a href="about.aspx?id=<%#Eval("Id") %>"><%#Eval("NewTitle") %></a></li>
    </ItemTemplate></asp:Repeater>
</ul></td>
  </tr>
</table></td>
    <td width="25%" align="center"><img src="/images/yncf_21.GIF" width="172" height="124" /></td>
  </tr>
</table>
<table class="wrad" border="0" cellspacing="0" cellpadding="0" style="margin-top:10px">
  <tr>
    <td align="center"><a href="#"><img src="/images/yncf_22.gif" width="110" height="41" /></a>&nbsp;<a href="#"><img src="/images/yncf_23.gif" width="103" height="41" /></a>&nbsp;<a href="#"><img src="/images/yncf_24.gif" width="104" height="41" /></a>&nbsp;<a href="#"><img src="/images/yncf_25.gif" width="127" height="41" /></a>&nbsp;<a href="#"><img src="/images/yncf_26.gif" width="96" height="41" /></a>&nbsp;<a href="#"><img src="/images/yncf_27.gif" width="104" height="41" /></a>&nbsp;<a href="#"><img src="/images/yncf_28.gif" width="104" height="41" /></a></td>
  </tr>
</table>
<table class="wrad" border="0" cellspacing="0" cellpadding="0" style="margin-top:10px">
  <tr>
    <td align="center" style="line-height:24px; color:#666"><asp:Literal ID="ltl_copyright" runat="server" EnableViewState="false"></asp:Literal></td>
  </tr>
</table>