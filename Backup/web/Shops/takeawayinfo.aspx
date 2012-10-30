<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="takeawayinfo.aspx.cs" Inherits="web.Shops.takeawayinfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title><%=webset.WebName%></title>
    <link href="/css/style.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery.js" type="text/javascript"></script>
    <style type="text/css">
        #dh00 #dh02 a{color:#ff6600;font-weight:bold}
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
    <td width="80%" height="20" id="path2">��ǰλ�ã�<a href="/">��ҳ</a> > �̼ҹ�������</td>
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
<li id="mee0" class="me3" onclick="mee(0)">�̼�������Ϣ</li>
</ul>
</div>
</td>
        <td width="19%">&nbsp;</td>
      </tr>
    </table><table width="100%" border="0" cellspacing="0" cellpadding="0" style="margin-top:10px">
  <tr>
    <td width="30">&nbsp;</td>
    <td height="35">Ӫҵʱ�䣺
      <input type="text" id="opentime" runat="server" size="20" class="inpu" readonly />
    </td>
  </tr>
  <tr><td width="30">&nbsp;</td>
    <td height="35">���ʱ��Σ�
      ����<input type="text" id="amtime" runat="server" size="10" class="inpu" readonly />  
      ����<input type="text" id="pmtime" runat="server" size="10" class="inpu" readonly />
    </td>
  </tr>
  <tr>
    <td width="30">&nbsp;</td>
    <td height="35">���ͷ��ã�
      <input type="text" id="sendlimitprice" runat="server" size="5" class="inpu" value="0" readonly />
      &nbsp;���ͷѣ�&nbsp;
      <input type="text" id="sendprice" runat="server" size="5" class="inpu" value="0" readonly />
      &nbsp;�ʹ�ʱ�䣺&nbsp;
     <input type="text" id="sendtime" runat="server" size="5" class="inpu" value="0" readonly />
     </td>
  </tr>
</table><table width="100%" border="0" cellspacing="0" cellpadding="0" height="31" background="/images/yncf_73.gif" style="margin-top:20px">
      <tr>
        <td width="2%">&nbsp;</td>
        <td width="79%">

<div id="me2">
<ul>
<li id="mee1" class="me3" onclick="mee(0)">¥��С�����</li>
</ul>
</div>
</td>
        <td width="19%">&nbsp;</td>
      </tr>
    </table><table width="100%" border="0" cellspacing="0" cellpadding="0" style="margin:10px 0">
  <tr>
    <td width="30" rowspan="3">&nbsp;</td>
    <td height="35">
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
      <asp:Button ID="btnSubmit" runat="server" Text="���" onclick="btnSubmit_Click" OnClientClick="return checksub()" />
    </td>
  </tr>
  <tr>
    <td height="35" id="adfad"><ul id="path1">
<asp:Repeater ID="rpt_shoparealist" runat="server" EnableViewState="false"><ItemTemplate>
<li><a href="#"><%#Eval("AreaName") %></a><img src="/images/yncf_94.gif" onclick="deleteitem(<%#Eval("Id") %>)" /></li>
</ItemTemplate></asp:Repeater>
</ul>
</td>
  </tr>
    </table>
</td>
  </tr>
</table>
</div>
    <ucl:Footer ID="Footer" runat="server" />
    </form>
    <script src="/js/userarea.js" type="text/javascript"></script>
    <script type="text/javascript">
        function checksub() {
            if (document.getElementById("ddl_district").value == "") {
                alert("��ѡ��С��");
                return false;
            }
            return true;
        }
    </script>
</body>
</html>
