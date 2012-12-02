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
    <td width="80%" height="20" id="path2">当前位置：<a href="/">首页</a> > 会员管理中心</td>
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
<li id="mee0" class="me2" onclick="javascript:self.location='userinfo.aspx'">个人资料</li>
<li id="mee1" class="me2" onclick="javascript:self.location='editpassword.aspx'">修改密码</li>
<li id="mee2" class="me3" onclick="javascript:self.location='useraddress.aspx'">地址管理</li>
</ul>
</div>
</td>
        <td width="19%">&nbsp;</td>
      </tr>
    </table>
<div style="padding:30px 60px;">
<table border="0" cellspacing="0" cellpadding="0" class="af3">
  <tr>
    <td height="35" background="/images/yncf_86.gif" style="border-bottom:1px solid #dcdcdc;font-weight:bold;padding-left:30px;">收货地址管理
    </td>
    </tr>
  <tr>
    <td height="40" align="right" style="padding:5px">
    <table width="100%" border="0" cellspacing="0" cellpadding="0" bgcolor="#ededed">
      <tr>
        <td width="12%" height="30" align="center">送餐场所</td>       
        <td width="12%"align="center">姓名</td>
        <td width="40%" align="center">地址</td>
        <td width="12%" align="center">电话</td>
        <td width="27%" align="center">操作</td>
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
        <td width="40%" style="line-height:20px;padding:10px 0"><%#Eval("Address").ToString().Split('|')[1]%><%#Eval("IsDefault").Equals(1)?"[<span class=\"isdefault\">默认地址</span>]":"" %></td>
        <td width="12%" align="center"><%#Eval("Mobile") %></td>
        <td width="27%" align="center">
            <asp:LinkButton ID="lbtndefualt" runat="server" CommandName="default" CommandArgument='<%#Eval("id") %>' CssClass="color0">设为默认</asp:LinkButton>
            <asp:LinkButton ID="lbtnmodify" runat="server" CommandName="edit" CommandArgument='<%#Eval("id") %>' CssClass="color0">编辑</asp:LinkButton>            
            <asp:LinkButton ID="lbtnDel" CommandName="del" CommandArgument='<%#Eval("id") %>' runat="server" Visible='<%#Eval("IsDefault").Equals(1)?false:true %>' OnClientClick="return config('确定要删除吗?');" CssClass="color0">删除</asp:LinkButton>
            <asp:LinkButton ID="lbtnorder" runat="server" CommandName="order" CommandArgument='<%#Eval("id") %>' oncommand="order_command" CssClass="color0">定餐</asp:LinkButton>
        </td>
      </tr>
    </table>
    </ItemTemplate></asp:Repeater>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="margin-top:20px;">
      <tr><td colspan="2" bgcolor="#ededed" height="30" style="font-size:13px;font-weight:bold;padding-left:20px;">添加/编辑地址</td></tr>
      <tr>
        <td width="26%" height="35" align="right"><span class="rds">*</span><span style="color:#666">为必填项</span> </td>
        <td width="74%">&nbsp;</td>
      </tr>
      <tr>
        <td height="35" align="right"><span class="rds">*</span>送餐场所：</td>
        <td>
            <select name="addtype" id="ddladdtype" runat="server">
                <option value="1">住宅地址</option>
                <option value="2">办公地址</option>
                <option value="3">其他</option>
            </select>
        </td>
      </tr>
      <tr>
        <td height="35" align="right"><span class="rds">*</span>联系人：</td>
        <td><input type="text" size="25" id="txtusername" runat="server" class="inpu" /></td>
      </tr>
      <tr>
        <td height="35" align="right"><span class="rds">*</span>地址：</td>
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
        <td height="35" align="right"><span class="rds">*</span>手机：</td>
        <td><input type="text" size="25" id="txtmobile" runat="server" maxlength="11" class="inpu" /></td>
      </tr>
      <tr>
        <td height="35">&nbsp;</td>
        <td>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="4%" height="35"><input type="checkbox" name="chkdefult" id="chkdefult" runat="server" /></td>
            <td width="96%">设为默认地址</td>
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
                alert("请填写联系人");
                return false;
            } else if (document.getElementById("ddl_district").value == "") {
                alert("请选择地址");
                return false;
            } else if (mobile == "") {
                alert("请填写手机号");
                return false;
            } else if (!mobile.match(mobile_reg)) {
                alert("手机格式输入错误!");
                return false;
            } else {
                return true;
            }
        }
    </script>
</body>
</html>
