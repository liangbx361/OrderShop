<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="myuserlist.aspx.cs" Inherits="web.Users.myuserlist" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title><%=webset.WebName%></title>
    <link href="/css/style.css" rel="stylesheet" type="text/css" />
    <link href="/css/thickbox.jquery.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery.js" type="text/javascript"></script>
    <script src="/js/thickbox.jquery.js" type="text/javascript"></script>
    <script src="/js/userarea.js" type="text/javascript"></script>
    <style type="text/css">
        #dh00 #dh03 a{color:#ff6600;font-weight:bold}
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
        <li id="mee0" class="me3" onclick="javascript:self.location='myuserlist.aspx'">推广会员列表</li>
        <li id="mee1" class="me2" onclick="javascript:self.location='joinpromotion.aspx'">我的推广链接</li>
        </ul>
        </div>
        </td>
        <td width="19%">&nbsp;</td>
      </tr>
    </table>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="margin-top:10px">
        <tr>
          <td height="33" align="left" bgcolor="#f3f3f3">&nbsp;&nbsp;<strong>消费积分</strong>：<span style="color:#C00;font-weight:bold"><asp:Literal ID="L_xfpointcount" runat="server" EnableViewState="false"></asp:Literal></span>  &nbsp;&nbsp;&nbsp;&nbsp;<strong>收益积分</strong>：<span style="color:#C00;font-weight:bold"><asp:Literal ID="L_sypointcount" runat="server"></asp:Literal></span> </td>
        </tr>
    </table>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="margin-top:10px" id="mse0">
        <tr>
          <td height="30" bgcolor="#f3f3f3" style="border-top:1px solid #dedee0"><table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
              <td width="22%" height="30" align="center"><strong>会员名称</strong></td>
              <td width="15%" align="center"><strong>会员等级</strong></td>
              <td width="24%" align="center"><strong>消费时间</strong></td>
              <td width="19%" align="center"><strong>消费积分</strong></td>
              <td width="20%" align="center"><strong>收益积分</strong></td>
              </tr>
          </table></td>
        </tr>
        <tr>
          <td>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="sem">
            <asp:Repeater ID="rpt_list" runat="server" EnableViewState="false"><ItemTemplate>
            <tr>
              <td width="22%"  height="30" align="center"><a href="userprofitlist.aspx?uid=<%#Eval("reguid") %>&keepThis=true&TB_iframe=true" style="color:#0077bb;" class="thickbox"><%#Eval("username") %></a></td>
              <td width="15%" align="center"><%#Eval("groupname")%></td>
              <td width="24%" align="center"><%#Eval("xftime")%></td>
              <td width="19%" align="center"><%#Eval("xfpoint")%></td>
              <td width="20%" align="center"><%#Eval("sypoint")%></td>
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
            <asp:AspNetPager CssClass="anpager2" CurrentPageButtonClass="cpb" ID="WebPager" runat="server" FirstPageText="首 页" LastPageText="末 页" NextPageText="下一页" PrevPageText="上一页"
                AlwaysShow="false" ShowDisabledButtons="false" ShowPageIndexBox="Never" onpagechanged="WebPager_PageChanged" PageSize="10" UrlPaging="true">
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
