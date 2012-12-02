<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="useraddress.aspx.cs" Inherits="web.Users.useraddress" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title><%=webset.WebName%></title>
    <link href="/css/style.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery.js" type="text/javascript"></script>
    <script src="/js/userarea.js" type="text/javascript"></script>
    <style type="text/css">
        #dh00 #dh05 a{color:#ff6600;font-weight:bold}
        .isdefault{color:#941006}
        .inpu{border:1px solid #cbcbcb;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
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
    <td valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0" height="31" background="/images/yncf_73.gif">
      <tr>
        <td width="2%">&nbsp;</td>
        <td width="79%">
<div id="me1">
<ul>
<li id="mee0" class="me2" onclick="javascript:self.location='userinfo.aspx'">��������</li>
<li id="mee1" class="me2" onclick="javascript:self.location='editpassword.aspx'">�޸�����</li>
<li id="mee2" class="me3" onclick="javascript:self.location='useraddress.aspx'">��ַ����</li>
</ul>
</div>
</td>
        <td width="19%">&nbsp;</td>
      </tr>
    </table>
<div style="padding:30px 60px;">
<table border="0" cellspacing="0" cellpadding="0" class="af3">
  <tr>
    <td height="35" background="/images/yncf_86.gif" style="border-bottom:1px solid #dcdcdc;font-weight:bold;padding-left:30px;">�ջ���ַ����
    </td>
    </tr>
  <tr>
    <td height="40" align="right" style="padding:5px">
    <table width="100%" border="0" cellspacing="0" cellpadding="0" bgcolor="#ededed">
      <tr>
        <td width="12%" height="30" align="center">�Ͳͳ���</td>       
        <td width="12%"align="center">����</td>
        <td width="40%" align="center">��ַ</td>
        <td width="12%" align="center">�绰</td>
        <td width="27%" align="center">����</td>
      </tr>
    </table></td>
    </tr>
  <tr>
    <td style="padding:0 5px">
    <asp:Repeater ID="rpt_list" runat="server" OnItemCommand="rpt_list_ItemCommand"><ItemTemplate>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="border-bottom:1px solid #e7e7e7">
      <tr>
        <td width="12%" align="center"><asp:HiddenField ID="hfaddtype" runat="server" Value='<%#SubAddressStr(Eval("Address").ToString()) %>' /> <%#AddressType(Eval("Address").ToString().Split('|')[1])%></td>
        <td width="12%" align="center"><%#Eval("UserName") %></td>
        <td width="40%" style="line-height:20px;padding:10px 0"><%#Eval("Address").ToString().Split('|')[1]%><%#Eval("IsDefault").Equals(1)?"[<span class=\"isdefault\">Ĭ�ϵ�ַ</span>]":"" %></td>
        <td width="12%" align="center"><%#Eval("Mobile") %></td>
        <td width="27%" align="center">
            <asp:LinkButton ID="lbtndefualt" runat="server" CommandName="default" CommandArgument='<%#Eval("id") %>' CssClass="color0">��ΪĬ��</asp:LinkButton>
            <asp:LinkButton ID="lbtnmodify" runat="server" CommandName="edit" CommandArgument='<%#Eval("id") %>' CssClass="color0">�༭</asp:LinkButton>            
            <asp:LinkButton ID="lbtnDel" CommandName="del" CommandArgument='<%#Eval("id") %>' runat="server" Visible='<%#Eval("IsDefault").Equals(1)?false:true %>' OnClientClick="return config('ȷ��Ҫɾ����?');" CssClass="color0">ɾ��</asp:LinkButton>
            <asp:LinkButton ID="lbtnorder" runat="server" CommandName="order" CommandArgument='<%#Eval("id") %>' oncommand="order_command" CssClass="color0">����</asp:LinkButton>
        </td>
      </tr>
    </table>
    </ItemTemplate></asp:Repeater>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="margin-top:20px;">
      <tr><td colspan="2" bgcolor="#ededed" height="30" style="font-size:13px;font-weight:bold;padding-left:20px;">���/�༭��ַ</td></tr>
      <tr>
        <td width="26%" height="35" align="right"><span class="rds">*</span><span style="color:#666">Ϊ������</span> </td>
        <td width="74%">&nbsp;</td>
      </tr>
      <tr>
        <td height="35" align="right"><span class="rds">*</span>�Ͳͳ�����</td>
        <td>
            <select name="addtype" id="ddladdtype" runat="server">
                <option value="1">סլ��ַ</option>
                <option value="2">�칫��ַ</option>
                <option value="3">����</option>
            </select>
        </td>
      </tr>
      <tr>
        <td height="35" align="right"><span class="rds">*</span>��ϵ�ˣ�</td>
        <td><input type="text" size="25" id="txtusername" runat="server" class="inpu" /></td>
      </tr>
      <tr>
        <td height="35" align="right"><span class="rds">*</span>��ַ��</td>
        <td>
            <asp:UpdatePanel ID="UpdatePanel" runat="server" UpdateMode="Always">
      <ContentTemplate>     
      <asp:DropDownList ID="ddl_counties" runat="server" AutoPostBack="true" onselectedindexchanged="ddl_counties_SelectedIndexChanged"></asp:DropDownList>
      &nbsp;
      <asp:DropDownList ID="ddl_streets" runat="server" AutoPostBack="true" onselectedindexchanged="ddl_streets_SelectedIndexChanged">
      
      </asp:DropDownList>&nbsp;
     <asp:DropDownList ID="ddl_district" runat="server">
     </asp:DropDownList>
      </ContentTemplate>
      </asp:UpdatePanel>
        </td>
      </tr>
      <tr>
        <td height="35" align="right"><span class="rds">*</span>�ֻ���</td>
        <td><input type="text" size="25" id="txtmobile" runat="server" maxlength="11" class="inpu" /></td>
      </tr>
      <tr>
        <td height="35">&nbsp;</td>
        <td>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="4%" height="35"><input type="checkbox" name="chkdefult" id="chkdefult" runat="server" /></td>
            <td width="96%">��ΪĬ�ϵ�ַ</td>
          </tr>
        </table>      
          </td>
      </tr>
      <tr>
        <td height="35">&nbsp;</td>
        <td>
            <input type="hidden" id="hiddenid" runat="server" />
            <asp:LinkButton ID="btn_Add" runat="server" onclick="btn_Add_Click" OnClientClick="return checksub()"><img src="/images/yncf_87.GIF" width="64" height="21" /></asp:LinkButton>
            <asp:LinkButton ID="btn_modify" runat="server" onclick="btn_modify_Click" OnClientClick="return checksub()" Visible="false"><img src="/images/yncf_87.GIF" width="64" height="21" /></asp:LinkButton>
        </td>
      </tr>
    </table></td>
    </tr>
</table>
</div>
</td>
  </tr>
</table>
</div>
    <ucl:Footer ID="Footer" runat="server" />
    </form>
    <script type="text/javascript">
        function checksub() {
            var mobile_reg = /^[1][3,5,8][0-9]{9}$/;
            var mobile = document.getElementById("txtmobile").value;
            if (document.getElementById("txtusername").value == "") {
                alert("����д��ϵ��");
                return false;
            } else if (document.getElementById("ddl_district").value == "") {
                alert("��ѡ���ַ");
                return false;
            } else if (mobile == "") {
                alert("����д�ֻ���");
                return false;
            } else if (!mobile.match(mobile_reg)) {
                alert("�ֻ���ʽ�������!");
                return false;
            } else {
                return true;
            }
        }
    </script>
</body>
</html>
