<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="modifyaddress.aspx.cs" Inherits="web.modifyaddress" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>更新地址</title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .inpu{border:1px solid #cbcbcb;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="text-align:center"><asp:Literal ID="L_msg" runat="server" EnableViewState="false"></asp:Literal></div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td height="35" align="right"><span class="rds">*</span>联系人：</td>
        <td><input type="text" size="25" id="txtusername" runat="server" maxlength="20" class="inpu" /></td>
      </tr>
      <tr>
        <td height="35" align="right"><span class="rds">*</span>地址：</td>
        <td>
            <asp:UpdatePanel ID="UpdatePanel" runat="server" UpdateMode="Always">
              <ContentTemplate>     
              <asp:DropDownList ID="ddl_counties" runat="server" AutoPostBack="true" onselectedindexchanged="ddl_counties_SelectedIndexChanged">
              </asp:DropDownList>&nbsp;
              <asp:DropDownList ID="ddl_streets" runat="server" AutoPostBack="true" onselectedindexchanged="ddl_streets_SelectedIndexChanged">
              </asp:DropDownList>&nbsp;
             <asp:DropDownList ID="ddl_district" runat="server">
             </asp:DropDownList>
              </ContentTemplate>
            </asp:UpdatePanel>
        </td>
      </tr>
      <tr>
        <td height="35">&nbsp;</td>
        <td>
            <asp:LinkButton ID="btn_modify" runat="server" onclick="btn_modify_Click" OnClientClick="return checksub()"><img src="images/yncf_87.GIF" width="64" height="21" /></asp:LinkButton>
        </td>
      </tr>
    </table>
    </form>
    <script type="text/javascript">
        function checksub() {
            if (document.getElementById("txtusername").value == "") {
                alert("请填写联系人");
                return false;
            } else if (document.getElementById("ddl_district").value == "") {
                alert("请选择地址");
                return false;
            } else {
                return true;
            }
        }
    </script>
</body>
</html>
