﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="web.Header" %>
<%@ Import Namespace="Cudo.Entities" %>

<script type="text/javascript" src="/js/unitpngfix.js"></script><!--ie6 支持png透明 js-->

<link style="text/css" rel="stylesheet" href="/css/fansy.css"/><!--107吃饭首页css-->
<script src="/js/fansy.js" type="text/javascript" language="javascript"></script><!--107吃饭首页 js-->

<div id="header">
    <div class="fansy_top">
  	<table width="1000" height="64" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td width="260" height="64" align="center"><img src="/images/fansy_toplogo2.jpg" width="226" height="64" /></td>
        <td width="250" align="center">&nbsp;</td>
        <td width="20">&nbsp;</td>
        <td width="120" align="center">
        <asp:LinkButton ID="btnSubmit" runat="server" onclick="btnOrder_Click">
        <img src="/images/fansy_top_xzdcbut.jpg" width="95" height="30" onmouseover="fansy_xzdc_onm(this)" onmouseout="fansy_xzdc_out(this)" style="cursor:pointer;"/>
        </asp:LinkButton>
        </td>
        <td width="20">&nbsp;</td>
        <td width="330">
   	        <table width="320" class="fansy_toptab" height="20" border="0" cellspacing="0" cellpadding="0">
              <tr>
              	<td width="20" align="center"><img src="/images/help.png" width="16" height="16" style="margin-top:-2px;"/></td>
                <td width="60"><a href="/help.aspx">帮助中心</a></td>
                <td width="20" align="center"><img src="/images/house2.png" width="18" height="18" style="margin-top:-2px;"/></td>
                <td width="60"><a href="javascript:;" onclick="this.style.behavior='url(#default#homepage)';this.setHomePage('http://www.107fan.com');">设为首页</a></td>
                <td width="20" align="center"><img src="/images/star.png" width="16" height="16"  style="margin-top:-2px;"/></td>
                <td width="60"><a href="javascript:;" onclick="window.external.AddFavorite('http://www.107fan.com','邀您吃饭网')">加入收藏</a></td>
                <td width="20" align="center"><img src="/images/coins.png" width="16" height="16"  style="margin-top:-2px;"/></td>
                <td width="60"><a href="/Users/onlinerecharge.aspx">积分查看</a></td>
              </tr>
            </table>
        </td>
      </tr>
    </table>
  </div>
    <div class="fansy_baner">
        <div class="fansy_baner_lxx">
            最新消息：<a href="/client/fan107.apk">107饭网安卓客户端上线，欢迎下载体验！</a></div>
        <div class="fansy_baner_rxx">
            &nbsp;&nbsp;
            <%if (Session["cudoUser"] == null)
              { %>
            <a href="/login.aspx">登录</a>
            <a href="/register.aspx" style="margin-left: 30px;">免费注册</a>
            <%}
              else
              {
                  UserInfo item = Session["cudoUser"] as UserInfo;
            %>
            <span id="userinfo">
                <%=item.UserName%>&nbsp;<a href="<%=item.Utype == 1 ? "/Shops/shoporderlist.aspx" : "/Users/" %>"
                    class="color0">[个人中心]</a>&nbsp
                <a href="/logout.aspx" class="color0">[退出]</a>
            </span>
            <%} %>
        </div>
    </div>
</div>
