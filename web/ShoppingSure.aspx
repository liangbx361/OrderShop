<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="shoppingsure.aspx.cs" Inherits="web.shoppingsure" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title><%=webset.WebName%>-��ѷ��͵��ֻ�</title>
    <link href="css/public.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
    body{ background-color:#ebebeb}
    .dx01{margin:0 auto;margin-top:50px;width:465px;border:1px solid #999; background-color:#FFF}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <input type="hidden" id="hiddenshoptel" runat="server" />
    <table border="0" cellspacing="0" cellpadding="0" class="dx01">
  <tr>
    <td height="23" colspan="3" background="images/yncf_88.gif" style="padding-left:20px;">��ѷ��͵��ֻ�</td>
  </tr>
  <tr>
    <td width="10" rowspan="12">&nbsp;</td>
    <td height="50" style="border-bottom:1px solid #c1c1c1"><strong style="font-size:14px">��ѡ�Ĳ�(<asp:Label ID="L_ShopName" runat="server"></asp:Label>)-</strong><span style="color:#999">���Ͷ���</span></td>
    <td width="10" rowspan="12">&nbsp;</td>
  </tr>
  <tr>
    <td height="30" style="color:#666">��������ͨ���ֻ����ŵ���ʽ�����͵��� ָ�����ֻ���</td>
  </tr>
  <tr>
    <td style="background:#6e6e6e;padding:10px 20px;line-height:18px; color:#FFF">
        <asp:Repeater ID="rpt_list" runat="server" EnableViewState="false"><ItemTemplate>
        <%#Eval("ProductName") %>(<%#Eval("BuyNum") %>)&nbsp;
        </ItemTemplate></asp:Repeater>
    </td>
  </tr>
  <tr>
    <td height="35" style="padding-left:20px;"><strong>��ַ��</strong>
            <asp:Label ID="L_Address" runat="server"></asp:Label>
            <input type="text" id="txtAddress" value="" runat="server" maxlength="20" style="border:solid 1px #000;width:100px;" />��¥��+��˾���(��Ԫ��)��¥��+��Ԫ�ţ�
            <asp:RequiredFieldValidator ID="rfvaddress" runat="server" ControlToValidate="txtAddress" ErrorMessage="����Ϊ��"></asp:RequiredFieldValidator>
            <input type="hidden" id="hiddenaid" value="0" runat="server" />
    </td>
  </tr>
  <tr>
    <td height="25" style="padding-left:20px;"><strong>��ϵ�ˣ�</strong><asp:Label ID="L_Name" runat="server"></asp:Label></td>
  </tr>
  <tr>
    <td height="25" style="padding-left:20px;"><strong>�ֻ��ţ�</strong>
        <asp:Label ID="L_Mobile" runat="server"></asp:Label>
    </td>
  </tr>
  <tr>
    <td height="25" style="padding-left:20px;"><strong>�Ͳ�ʱ�䣺</strong>
        <select name="hours" id="hours">
            <option value="10">10��</option>
            <option value="11">11��</option>
            <option value="12">12��</option>
            <option value="13">13��</option>
            <option value="14">14��</option>
            <option value="15">15��</option>
            <option value="16">16��</option>
            <option value="17">17��</option>
            <option value="18">18��</option>
            <option value="19">19��</option>
            <option value="20">20��</option>
            <option value="21">21��</option>
        </select>
        <select name="minutes" id="minutes">
            <option value="00">00��</option>
            <option value="15">15��</option>
            <option value="40">30��</option>
            <option value="45">45��</option>
        </select>
    </td>
  </tr>
  <tr>
    <td height="35" style="padding-left:20px;"><strong>��֤�룺</strong>
        <input type="text" size="5" id="txtcode" runat="server" maxlength="4" style="border:solid 1px #000" /> <img src="VerifyCode.aspx" alt="�������?��һ��" align="absmiddle" style="cursor:pointer" onclick="this.src=this.src+'?'+Math.random();" />
        <asp:Label ID="L_vialcode" runat="server" Text="" ForeColor="Red" EnableViewState="false"></asp:Label>
    </td>
  </tr>
  <tr>
    <td height="50" style="padding-left:20px;"><asp:LinkButton ID="btnSubmit" runat="server" OnClick="btnSubmit_Click"><img src="images/yncf_89.gif" width="84" height="28" /></asp:LinkButton></td>
  </tr>
  <tr>
    <td style="padding:10px;line-height:20px;color:#999">*�����������֤�룬����ͼƬˢ�¡�<BR />*���ſ�����3-5���ӵ���ʱ���벻Ҫ�ڶ�ʱ���ڶ���ظ����͡�<BR />*�������ݹ��������ܻ�ֶ������͡�<BR />*���δ�յ����ţ��뵽��Ա�������»�ȡ��<BR />*�����ֻ���������ڷ�������Ҫ���̻���Ϣ������͸¶����������</td>
  </tr>
  <tr>
    <td align="center" style="padding:10px;line-height:20px;color:#999"><a href="shopinfo.aspx?shopid=<%=shopid %>"><img src="images/yncf_93.gif" width="126" height="27" border="0" /></a></td>
  </tr>
</table>
    </form>
</body>
</html>
