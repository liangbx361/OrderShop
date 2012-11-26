<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HeaderTest.ascx.cs"
    Inherits="web.ascx.HeaderTest" %>
<%@ Import Namespace="Cudo.Entities" %>

    <script src="/js/fansy.js"></script>
    <link style="/text/css" rel="stylesheet" href="/css/fansy.css" />

    <script language="javascript">
        //107吃饭首页 帮助中心 按钮切换
        function fansy_bzzx_onm(fansy_bzzx_obj) {
            fansy_bzzx_obj.src = "images/fansy_top_bzzxbutonc.jpg";
        }
        function fansy_bzzx_out(fansy_bzzx_obj) {
            fansy_bzzx_obj.src = "images/fansy_top_bzzxbut.jpg";
        }
    </script>

<div id="header">
    <div class="fansy_top">
        <table width="1000" height="64" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td width="140" height="64" align="center">
                    <img src="/images/fansy_toplogo.jpg" width="79" height="64" style="cursor: pointer;" />
                </td>
                <td width="370" align="center">
                    <img src="/images/fansy_toprx.jpg" width="362" height="64" />
                </td>
                <td width="20">
                    &nbsp;
                </td>
                <td width="200" align="center">
                    <a href="help.aspx">
                        <img src="/images/fansy_top_bzzxbut.jpg" width="96" height="30" onmouseover="fansy_bzzx_onm(this)"
                            onmouseout="fansy_bzzx_out(this)" style="cursor: pointer;" />
                    </a>
                </td>
                <td width="20">
                    &nbsp;
                </td>
                <td width="250">
                    <table width="240" class="fansy_toptab" height="20" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td width="20" align="center">
                                <img src="/images/house2.png" width="18" height="18" style="margin-top: -2px;" />
                            </td>
                            <td width="60">
                                <a href="javascript:;" onclick="this.style.behavior='url(#default#homepage)';this.setHomePage('http://www.107fan.com');">
                                    设为首页</a>
                            </td>
                            <td width="20" align="center">
                                <img src="/images/star.png" width="16" height="16" style="margin-top: -2px;" />
                            </td>
                            <td width="60">
                                <a href="javascript:;" onclick="window.external.AddFavorite('http://www.107fan.com','邀您吃饭网')">
                                    加入收藏</a>
                            </td>
                            <td width="20" align="center">
                                <img src="/images/coins.png" width="16" height="16" style="margin-top: -2px;" />
                            </td>
                            <td width="60">
                                <a href="/Users/onlinerecharge.aspx">积分充值</a>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <div class="fansy_baner">
        <div class="fansy_baner_lxx">
            最新消息：<a href="###">东街口85度C新店开业！</a></div>
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
