<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="myfavoritelist.aspx.cs" Inherits="web.Users.myfavoritelist" %>

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
    <td valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0" height="31" background="images/yncf_73.gif">
      <tr>
        <td width="2%">&nbsp;</td>
        <td width="79%">
<div id="me1">
<ul>
<li id="mee0" class="me3" onclick="javascript:self.location='myfavoritelist.aspx'">我的收藏</li>
<li id="mee1" class="me2" onclick="javascript:self.location='mycommentlist.aspx'">我的评论</li>
<li id="mee2" class="me2" onclick="javascript:self.location='mymessagelist.aspx'">站内信息</li>
</ul>
</div>
</td>
        <td width="19%">&nbsp;</td>
      </tr>
    </table>
<!--内容-->
<table width="100%" border="0" cellspacing="0" cellpadding="0" id="mse0">
<tr><td height="10"></td></tr>
<tr>
  <td height="37" background="/images/yncf_79.gif"><table width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td width="4%" align="center"><input type="checkbox" id="chkall" onclick="checkAll(this)" /></td>
      <td width="5%" align="center"><span>全选</span></td>
      <td width="5%" align="center" class="sc5"><span><asp:LinkButton ID="btndeleteall" runat="server" Text="删除" onclick="btndeleteall_Click"></asp:LinkButton></span></td>
      <td width="16%" align="center">显示：每页&nbsp;<strong><%=WebPager.PageSize %></strong> 条/<%=WebPager.PageCount %> 页</td>
 <td width="70%">&nbsp;</td>
    </tr>
  </table>
  </td></tr>
<tr>
  <td height="31" background="/images/yncf_80.gif">
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="8%" height="31">&nbsp;</td>
    <td width="53%">店铺信息 </td>
    <td width="18%" align="center"><a href="#"><img src="/images/yncf_78.gif" width="85" height="20" /></a></td>
    <td width="12%" align="center">收藏人气</td>
    <td width="9%" align="center">操作</td>
  </tr>
</table>
  </td></tr>
        <tr>
          <td height="30">
          <asp:Repeater ID="rpt_list" runat="server" OnItemCommand="rpt_list_ItemCommand"><ItemTemplate>
          <table width="100%" border="0" cellspacing="0" cellpadding="0" class="sc">
            <tr>
              <td width="4%" align="center" valign="top" style="padding-top:32px;"><asp:CheckBox ID="cb_id" CssClass="checkall" runat="server" /></td>
              <td width="15%" height="95" align="left" valign="top"><a href="/shopinfo.aspx?shopid=<%#Eval("ShopId") %>" target="_blank"><img src="/<%#Eval("ShopPic") %>" width="105" height="80" border="0" /></a></td>
              <td width="42%" valign="top" class="sc1 sc2"><a href="/shopinfo.aspx?shopid=<%#Eval("ShopId") %>" target="_blank"><%#Eval("ShopName") %></a></td>
              <td width="18%" align="center" valign="top" class="sc1 sc3"><%#Eval("addtime") %></td>
              <td width="12%" align="center" valign="top" class="sc1 sc4"><%#Eval("Hit") %></td>
              <td width="9%" align="center" valign="top" class="sc1 sc5">
                [<asp:LinkButton ID="lbtn_delete" runat="server" CommandName="del" CommandArgument='<%#Eval("Id") %>' OnClientClick="return confirm('您确定要删除？')">删除</asp:LinkButton>]
              </td>
            </tr>
          </table>
          </ItemTemplate></asp:Repeater>
          </td>
        </tr>
        <tr>
          <td>&nbsp;</td>
        </tr>
        <tr>
          <td height="10"></td>
        </tr>
        <tr>
          <td height="33" align="center" bgcolor="#f3f3f3" class="se" style="padding-left:0"><table width="100%" border="0" cellspacing="0" cellpadding="0" height="33">
  <tr>
    <td width="5%" align="center"><input type="checkbox" id="chkall2" onclick="checkAll(this)" /></td>
    <td width="5%" align="center"><span>全选</span></td>
    <td width="7%" align="center" class="sc5"><span><asp:LinkButton ID="btndeleteall2" runat="server" Text="删除" onclick="btndeleteall_Click"></asp:LinkButton></span></td>
    <td width="7%">&nbsp;</td>
    <td width="76%">
        <asp:AspNetPager CssClass="anpager2" CurrentPageButtonClass="cpb" ID="WebPager" runat="server" FirstPageText="首 页" LastPageText="末 页" NextPageText="下一页" PrevPageText="上一页"
          AlwaysShow="false" ShowDisabledButtons="false" ShowPageIndexBox="Never" onpagechanged="WebPager_PageChanged" PageSize="5" UrlPaging="true">
        </asp:AspNetPager>
    </td>
  </tr>
</table>
</td>
        </tr>
<tr><td height="10"></td></tr>
      </table>
</td>
  </tr>
</table>

</div>    
    <ucl:Footer ID="Footer" runat="server" />
    </form>
</body>
</html>
