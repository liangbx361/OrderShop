<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="web.Header" %>
<%@ Import Namespace="Cudo.Entities" %>
<script type="text/javascript">
    function search() {
        var keywords = document.getElementById("searchkeyword");
        if (keywords.value == "" || keywords.value == "请输入您所在的小区/楼宇") {
            alert("请输入您所在的小区/楼宇");
            keywords.focus();
            return;
        }
        window.location.href = "search.aspx?keyword=" + escape(keywords.value.replace(/\s+/g,""));
    } 
</script>
<div id="function">
<table border="0" cellspacing="0" cellpadding="0" height="31" class="wrad"  id="rotdot">
  <tr>
    <td width="144">您好，欢迎来邀您吃饭！</td>
    <%if (Session["cudoUser"] == null){ %>
    <td width="52"><a href="/login.aspx" class="color0">[登录]</a></td>
    <td width="66"><a href="/register.aspx" class="color0">[免费注册]</a></td>
    <td width="571">&nbsp;</td>
    <%}else{
          UserInfo item = Session["cudoUser"] as UserInfo;
          %>
    <td width="689">
        <span id="userinfo">
        <%=item.UserName %>&nbsp;<a href="<%=item.Utype == 1 ? "/Shops/shoporderlist.aspx" : "/Users/"%>" class="color0">[个人中心]</a>&nbsp<a href="/logout.aspx" class="color0">[退出]</a>
        </span>
    </td>
    <%} %>
    <td width="20" valign="top" style="padding-top:7px;"><img src="/images/yncf_02.gif" width="14" height="12" /></td>
    <td width="60"><a href="javascript:;" onclick="this.style.behavior='url(#default#homepage)';this.setHomePage('http://www.107fan.com');">设为首页</a></td>
    <td width="20" valign="top" style="padding-top:7px;"><img src="/images/yncf_03.gif" width="12" height="12" /></td>
    <td width="67"><a href="javascript:;" onclick="window.external.AddFavorite('http://www.107fan.com','邀您吃饭网')">加入收藏</a></td>
    <td width="20" valign="top" style="padding-top:7px;"><img src="/images/jb.png" width="16" height="16" /></td>
    <td width="67"><a href="/Users/onlinerecharge.aspx">积分充值</a></td>
  </tr>
</table>
</div>
<div id="header">
<table class="wrad" height="95" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="209" align="center"><a href="/"><img src="/images/logo.png" width="180" height="90" /></a></td>
    <td width="10" align="center"><img src="/images/yncf_04.gif" width="1" height="70" /></td>
    <td width="85" align="center">
        &nbsp;
    </td>
    <td width="505" valign="bottom">
<div id="menu">
<li id="menu0" class="cur0"><a href="/">首 页</a></li>
<li id="menu1" class="cur0"><a href="/setaddress.aspx">现在订餐</a></li>
<li id="menu2" class="cur0"><a href="#">论坛</a></li>
<li id="menu3" class="cur0"><a href="/help.aspx">帮助中心</a></li>
 </div>
</td>
    <td width="191" align="center"><img src="/images/yncf_06.jpg" width="174" height="40" /></td>
  </tr>
</table>

</div>
<div id="search">
<table  class="wrad" border="0" cellspacing="0" cellpadding="0" height="40">
  <tr>
    <td class="stn">热门楼宇：
    <asp:Literal ID="L_HotDistrict" runat="server" EnableViewState="false"></asp:Literal>
</td>
    <td width="339" align="center"><table width="310" height="29" background="/images/yncf_10.gif" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="29">&nbsp;</td>
    <td width="204">
        <div style="position:relative"><input type="text" id="searchkeyword" name="searchkeyword" onkeyup="searchbykey(this.value)" value="请输入您所在的小区/楼宇" style="border:0;width:190px;color:#CCC" />
        <div id="searchlist" class="searchlist" style="display:none;">
        </div>
        </div>
    </td>
    <td width="77" align="center" class="btn"><a href="javascript:search();">去订餐</a></td>
  </tr>
</table>
</td>
  </tr>
</table>
</div>
