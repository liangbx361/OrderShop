<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="web.index" %>
<%@ Import Namespace="Cudo.Entities" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<meta name="description" content="邀您吃饭（107饭网），福州最大最全网络折扣送餐平台，一家最大力度让利给消费者的一个网络订餐平台，一个让你边吃饭边省钱又边省时间，打造最具特色的美食网站，只要你想网络点餐订餐就能想起我们107饭网。" />
<meta name="keywords" content="订餐网,福州网上订餐，福州网络订餐,福州网络送餐,福州订餐,福州点餐，福州外卖网,福州送外卖的网站,福州网络订餐网站,107饭,107fan,福州美食网" />

    <title>107饭网-福州订餐_福州网上订餐_福州网络订餐_福州网上送餐网|邀您吃饭网-福州最大网络折扣订餐平台</title>
    <script type="text/javascript" src="js/unitpngfix.js"></script>
    <!--ie6 支持png透明 js-->
    <link style="text/css" rel="stylesheet" href="css/fansy.css" />
    <!--107吃饭首页css-->
    <script type="text/javascript" src="js/fansy.js"></script>
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
            fansy_lkdc_obj.src = "images/fansy_lnr_kk.gif";
        }
        function fansy_lkdc_out(fansy_lkdc_obj) {
            fansy_lkdc_obj.src = "images/fansy_lnr_kk2.gif";
        }    

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <!--107吃饭首页 头部-->
    <ucl:Header ID="Header1" runat="server" />

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
                                <img src="images/fansy_lnr_kk.gif" width="214" height="70" onmouseover="fansy_lkdc_onm(this)"
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
                    var counts = 5;
                    //添加页数 修改连接
                    img1 = new Image(); img1.src = 'images/sd1.jpg';
                    img2 = new Image(); img2.src = 'images/meiwei.jpg';
                    img3 = new Image(); img3.src = 'images/meiwei2.jpg';
                    img4 = new Image(); img4.src = 'images/meiwei3.jpg';
                    img5 = new Image(); img5.src = 'images/meiwei4.jpg';

                    url1 = new Image(); url1.src = 'http://url.cn/5oH5Hb';
                    url2 = new Image(); url2.src = 'http://www.107fan.com/BrowseShop.aspx';
                    url3 = new Image(); url3.src = 'http://www.107fan.com/BrowseShop.aspx';
                    url4 = new Image(); url4.src = 'http://www.107fan.com/BrowseShop.aspx';
                    url5 = new Image(); url5.src = 'http://www.107fan.com/BrowseShop.aspx';

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
                        <a href="/user_agreement.aspx">网站条款</a>
                        |
                        <a href="/help.aspx?id=1">关于107饭网</a>
                        |
                        <a href="/about.aspx?id=5">联系我们</a>
                        |
                        <a href="/busecooperation.aspx">商家合作</a>
                        |
                        <a href="/help.aspx?id=10">常见问题</a>
                    </td>
                    <td width="647" align="center">
                        Copyright &copy; 邀您吃饭. All Rights Reserved. 闽ICP备12013601号<script src="http://s25.cnzz.com/stat.php?id=4589327&web_id=4589327" language="JavaScript">统计</script>

                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
