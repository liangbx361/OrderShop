<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="web.index" %>
<%@ Import Namespace="Cudo.Entities" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>无标题文档</title>
    <script type="text/javascript" src="js/unitpngfix.js"></script>
    <!--ie6 支持png透明 js-->
    <link style="text/css" rel="stylesheet" href="css/fansy.css" />
    <!--107吃饭首页css-->
    <script src="js/fansy.js"></script>
    <!--107吃饭首页 js-->
    <script language="javascript">
        //107吃饭首页 现在订餐 按钮切换
        function fansy_xzdc_onm(fansy_xzdc_obj) {
            fansy_xzdc_obj.src = "images/fansy_top_xzdcbutonc.jpg";
        }
        function fansy_xzdc_out(fansy_xzdc_obj) {
            fansy_xzdc_obj.src = "images/fansy_top_xzdcbut.jpg";
        }

        //107吃饭首页 帮助中心 按钮切换
        function fansy_bzzx_onm(fansy_bzzx_obj) {
            fansy_bzzx_obj.src = "images/fansy_top_bzzxbutonc.jpg";
        }
        function fansy_bzzx_out(fansy_bzzx_obj) {
            fansy_bzzx_obj.src = "images/fansy_top_bzzxbut.jpg";
        }

        //107吃饭首页 立刻订餐 按钮切换
        function fansy_lkdc_onm(fansy_lkdc_obj) {
            fansy_lkdc_obj.src = "images/fansy_lnr_dcbutonc.gif";
        }
        function fansy_lkdc_out(fansy_lkdc_obj) {
            fansy_lkdc_obj.src = "images/fansy_lnr_dcbut.gif";
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <!--107吃饭首页 头部-->
    <div id="header">
        <div class="fansy_top">
            <table width="1000" height="64" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="140" height="64" align="center">
                        <img src="images/fansy_toplogo.jpg" width="79" height="64" style="cursor: pointer;" />
                    </td>
                    <td width="370" align="center">
                        <img src="images/fansy_toprx.jpg" width="362" height="64" />
                    </td>
                    <td width="20">
                        &nbsp;
                    </td>
                    <td width="200" align="center">
                        <a href="help.aspx">
                            <img src="images/fansy_top_bzzxbut.jpg" width="96" height="30" onmouseover="fansy_bzzx_onm(this)"
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
                                    <img src="images/house2.png" width="18" height="18" style="margin-top: -2px;" />
                                </td>
                                <td width="60">
                                    <a href="javascript:;" onclick="this.style.behavior='url(#default#homepage)';this.setHomePage('http://www.107fan.com');">设为首页</a>
                                </td>
                                <td width="20" align="center">
                                    <img src="images/star.png" width="16" height="16" style="margin-top: -2px;" />
                                </td>
                                <td width="60">
                                    <a href="javascript:;" onclick="window.external.AddFavorite('http://www.107fan.com','邀您吃饭网')">加入收藏</a>
                                </td>
                                <td width="20" align="center">
                                    <img src="images/coins.png" width="16" height="16" style="margin-top: -2px;" />
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

                <%if (item == null)
                  { %>
                <a href="/login.aspx">登录</a>
                <a href="/register.aspx" style="margin-left: 30px;">免费注册</a>
                <%}
                  else
                  {
                %>
                <span id="userinfo">
                    <%=item.UserName%>&nbsp;<a href="<%=item.Utype == 1 ? "/Shops/shoporderlist.aspx" : "/Users/" %>" class="color0">[个人中心]</a>&nbsp
                        <a href="/logout.aspx" class="color0">[退出]</a>
                </span> 
                <%} %>  
                
            </div>
        </div>
    </div>
    <!--107吃饭首页 中间部-->
    <div id="main">
        <div class="fansy_midnr">
            <div class="fansy_midnr_lnr">
                <table width="353" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td height="340">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td height="80" align="center">  
                            
                            <asp:LinkButton ID="btnSubmit" runat="server" onclick="btnSubmit_Click">
                                <img src="images/fansy_lnr_dcbut.gif" width="214" height="70" onmouseover="fansy_lkdc_onm(this)"
                                    onmouseout="fansy_lkdc_out(this)" style="cursor: pointer;" />
                            </asp:LinkButton>
                            
                        </td>
                    </tr>
                </table>
            </div>
            <div class="fansy_midnr_rnr">
                <script>
                    //设置下宽高
                    var widths = 647;
                    var heights = 526;
                    //设置下页数              
                    var counts = 4;
                    //添加页数 修改连接
                    img1 = new Image(); img1.src = 'images/fansy_rnr_tu1.jpg';
                    img2 = new Image(); img2.src = 'http://notebook.yesky.com/imagelist/2007/017/hub8x795v23m.jpg';
                    img3 = new Image(); img3.src = 'http://www.yesky.com/imagelist/2007/017/dt741w2a2n42.jpg';
                    img4 = new Image(); img4.src = 'http://www.yesky.com/imagelist/2007/016/hda926w5t574.jpg';
                    url1 = new Image(); url1.src = 'http://www.baidu.com';
                    url2 = new Image(); url2.src = 'http://www.baidu.com';
                    url3 = new Image(); url3.src = 'http://www.baidu.com';
                    url4 = new Image(); url4.src = 'http://www.baidu.com';


                    var nn = 1;
                    var key = 0;
                    function change_img() {
                        if (key == 0) { key = 1; }
                        else if (document.all)
                        { document.getElementById("pic").filters[0].Apply(); document.getElementById("pic").filters[0].Play(duration = 2); }
                        eval('document.getElementById("pic").src=img' + nn + '.src');
                        eval('document.getElementById("url").href=url' + nn + '.src');
                        for (var i = 1; i <= counts; i++) { document.getElementById("xxjdjj" + i).className = 'axx'; }
                        document.getElementById("xxjdjj" + nn).className = 'bxx';
                        nn++; if (nn > counts) { nn = 1; }
                        tt = setTimeout('change_img()', 4000);
                    }
                    function changeimg(n) { nn = n; window.clearInterval(tt); change_img(); }
                    document.write('<style>');
                    document.write('.axx{padding:1px 7px;border-left:#cccccc 1px solid;}');
                    document.write('a.axx:link,a.axx:visited{text-decoration:none;color:#fff;line-height:12px;font:9px sans-serif;background-color:#666;}');
                    document.write('a.axx:active,a.axx:hover{text-decoration:none;color:#fff;line-height:12px;font:9px sans-serif;background-color:#999;}');
                    document.write('.bxx{padding:1px 7px;border-left:#cccccc 1px solid;}');
                    document.write('a.bxx:link,a.bxx:visited{text-decoration:none;color:#fff;line-height:12px;font:9px sans-serif;background-color:#D34600;}');
                    document.write('a.bxx:active,a.bxx:hover{text-decoration:none;color:#fff;line-height:12px;font:9px sans-serif;background-color:#D34600;}');
                    document.write('</style>');
                    document.write('<div style="width:' + widths + 'px;height:' + heights + 'px;overflow:hidden;text-overflow:clip;">');
                    document.write('<div><a id="url" target="_blank"><img id="pic" style="border:0px;filter:progid:dximagetransform.microsoft.wipe(gradientsize=1.0,wipestyle=4, motion=forward)" width=' + widths + ' height=' + heights + ' /></a></div>');
                    document.write('<div style="filter:alpha(style=1,opacity=10,finishOpacity=80);background: #888888;width:100%-2px;text-align:right;top:-12px;position:relative;margin:1px;height:12px;padding:0px;margin:0px;border:0px;display:none;">');
                    for (var i = 1; i < counts + 1; i++) { document.write('<a href="javascript:changeimg(' + i + ');" id="xxjdjj' + i + '" class="axx" target="_self">' + i + '</a>'); }
                    document.write('</div></div>');
                    change_img();
                </script>
            </div>
        </div>
        <div class="fansy_fotnr">
            <table width="1000" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="353" height="28" align="center">
                        <a href="###">网站条款</a>
                        |
                        <a href="###">关于107饭网</a>
                        |
                        <a href="###">联系我们</a>
                        |
                        <a href="###">商家合作</a>
                        |
                        <a href="###">常见问题</a>
                    </td>
                    <td width="647" align="center">
                        Copyright &copy; 邀您吃饭. All Rights Reserved. 闽ICP备12013601号
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
