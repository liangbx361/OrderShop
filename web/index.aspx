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
                        //eval('document.getElementById("url").href=url' + nn + '.src');
                        for (var i = 1; i <= counts; i++) { document.getElementById("xxjdjj" + i).className = 'axx'; }
                        document.getElementById("xxjdjj" + nn).className = 'bxx';
                        nn++; if (nn > counts) { nn = 1; }                        
                        //tt = setTimeout('change_img()', 4000);
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
                        Copyright &copy; 邀您吃饭. All Rights Reserved. 闽ICP备12013601号
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
