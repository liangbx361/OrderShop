<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="orderinfo.aspx.cs" Inherits="web.Users.orderinfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <link href="/css/style.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .btn{color:#C00; font-weight:800;text-decoration:underline;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
          <td height="33" align="left" bgcolor="#f3f3f3" class="se" style="font-size:14px;padding-left:0">&nbsp;&nbsp;�����ţ�<%=orderno %></td>
        </tr>
    </table>
<table width="80%" border="0" cellspacing="0" cellpadding="0" style="margin:20px auto;font-size:14px" class="qerqwer" >
  <tr>
    <td width="16%" height="35" align="right"><strong>����ʱ��</strong>��</td>
    <td width="51%" style="padding-left:10px;"><asp:Literal ID="L_OrderTime" runat="server" EnableViewState="false"></asp:Literal></td>
    <td width="31%" align="center"><strong>��Ʒ����</strong></td>
  </tr>
  <tr>
    <td align="right"><strong>�Ͳ͵�ַ</strong>��</td>
    <td style="padding:10px;line-height:20px"><asp:Literal ID="L_Address" runat="server" EnableViewState="false"></asp:Literal></td>
    <td rowspan="4" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0" class="adfadf">
      <tr>
        <td height="10"></td>
      </tr>
      <asp:Repeater ID="rpt_list" runat="server" EnableViewState="false"><ItemTemplate>
      <tr>
        <td height="25" align="right" style="padding-right:15px;font-size:12px"><%#Eval("ProductName")%>(<strong style="color:#C00"><%#Eval("BuyNum")%></strong>)</td>
      </tr>
      </ItemTemplate></asp:Repeater> 
      <tr>
        <td height="10"></td>
      </tr>
      <tr>
        <td height="30" align="right" style="padding:0 5px;"><div style="line-height:30px;border-top:1px dashed #CCC"><strong>����</strong>��<span style="color:#C00;font-weight:bold"><asp:Literal ID="L_OrderCount" runat="server" EnableViewState="false"></asp:Literal></span><strong>��</strong><br /><strong>���</strong>��<span style="color:#C00;font-weight:bold"><asp:Literal ID="L_SumPrice" runat="server" EnableViewState="false"></asp:Literal></span><strong>Ԫ</strong></div></td>
      </tr>
    </table></td>
  </tr>
  <tr>
    <td height="35" align="right"><strong>�������</strong>��</td>
    <td style="padding-left:10px;"><asp:Literal ID="L_OrderPrice" runat="server" EnableViewState="false"></asp:Literal>Ԫ</td>
    </tr>
  <tr>
    <td height="35" align="right"><strong>��ϵ��</strong>��</td>
    <td style="padding-left:10px;"><asp:Literal ID="L_UserName" runat="server" EnableViewState="false"></asp:Literal></td>
    </tr>
  <tr>
    <td height="35" align="right"><strong>�绰</strong>��</td>
    <td style="padding-left:10px;"><asp:Literal ID="L_Phone" runat="server" EnableViewState="false"></asp:Literal></td>
    </tr>
</table>
    <div style="text-align:center;">
        <span style="color:#C00">��ʾ�������ʱ��δ��ȡ��������</span>
        <asp:LinkButton ID="btnSend" runat="server" Text="���»�ȡ" CssClass="btn" onclick="btnSend_Click"></asp:LinkButton>
    </div>
    <div style="text-align:center; margin-top:20px; line-height:22px;">
        <input type="button" value="�رմ���" class="new-btn-login" onclick="window.parent.tb_remove()" />
    </div>
    </form>
</body>
</html>
