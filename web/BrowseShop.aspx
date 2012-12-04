<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BrowseShop.aspx.cs" Inherits="web.BrowseShop" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title></title>
    <meta name="keywords" content="<%=webset.WebKeywords %>" />
    <meta name="description" content="<%=webset.WebDescription %>" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/userfavorite.js" type="text/javascript"></script>
    <script src="js/jquery.pack.js" type="text/javascript"></script>
    <script src="js/jQuery.blockUI.js" type="text/javascript"></script>
    <script src="js/jquery.SuperSlide.js" type="text/javascript"></script>
    <style type="text/css">
        #menu #menu1 a
        {
            background: url(images/yncf_07.gif);
            font-weight: bold;
            color: #FFF;
        }
        .banner
        {
            margin-top: 5px;
            text-align: center;
        }
        .slideBox
        {
            width: 996px;
            height: 130px;
            overflow: hidden;
            margin: 0 auto;
            position: relative;
        }
        .slideBox .hd
        {
            height: 15px;
            overflow: hidden;
            position: absolute;
            right: 10px;
            bottom: 10px;
            z-index: 1;
        }
        .slideBox .hd ul
        {
            overflow: hidden;
            zoom: 1;
            float: left;
        }
        .slideBox .hd ul li
        {
            float: left;
            margin-right: 5px;
            width: 15px;
            height: 15px;
            line-height: 14px;
            text-align: center;
            background: #fff;
            cursor: pointer;
        }
        .slideBox .hd ul li.on
        {
            background: #f00;
            color: #fff;
        }
        .slideBox .bd
        {
            position: relative;
            height: 100%;
            z-index: 0;
        }
        .slideBox .bd img
        {
            width: 996px;
            height: 130px;
        }
    </style>
    <script type="text/javascript">
        $(function () {
            $(window).scroll(function () {
                if ($(window).scrollTop() > $(window).height() / 2) {
                    $('#goTopBtn').show();
                } else {
                    $('#goTopBtn').hide();
                }
            });
            $('#goTopBtn').click(function () {
                $(window).scrollTop(0);
            });
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <input type="hidden" id="hiddenaid" runat="server" value="0" />
    <input type="hidden" id="hiddensid" runat="server" value="0" />
    <ucl:Header ID="Header" runat="server" />
    <div class="banner">
        <div id="slideBox" class="slideBox">
            <div class="hd">
                <ul>
                    <asp:Repeater ID="rpt_advertnum" runat="server" EnableViewState="false">
                        <ItemTemplate>
                            <li>
                                <%#Container.ItemIndex+1 %></li></ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
            <div class="bd">
                <ul>
                    <asp:Repeater ID="rpt_adverts" runat="server" EnableViewState="false">
                        <ItemTemplate>
                            <li>
                                <a href="<%#Eval("AdvertLink") %>">
                                    <img src="<%#Eval("AdvertPic") %>" /></a></li></ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </div>
        <script type="text/javascript">            jQuery(".slideBox").slide({ mainCell: ".bd ul", effect: "leftLoop", autoPlay: true });</script>
    </div>
    <div id="main">
        <div style="height: 10px;">
        </div>
        <table width="100%" border="0" cellspacing="0" cellpadding="0" style="margin-top: 0px;">
            <tr>
                <td>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" height="0" style="margin-top: 10px;">
                        <tr>
                            <table height="26" border="0" cellspacing="0" cellpadding="0" background="images/yncf_12.gif"
                                style="width: 126%">
                                <tr>
                                    <td width="30" colspan="2" style="font-weight: bold; color: #FFFF; padding-left: 20px">
                                        所有餐店(<%=WebPager.RecordCount %>
                                        )
                                    </td>
                                    <td width="70%" align="right">
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </tr>
                        <tr>
                            <td width="79%" id="cx" height="32">
                                菜系：<a href="<%=CreateTypeUrl() %>typeid=0" <%=TypeId.Equals(0)?"class=\"dq1\"":"" %>>全部</a>
                                <asp:Repeater ID="rpt_shoptypelist" runat="server" EnableViewState="false">
                                    <ItemTemplate>
                                        &nbsp;&nbsp;<a href="<%=CreateTypeUrl() %>typeid=<%#Eval("Id") %>" <%#Eval("Id").Equals(TypeId)?"class=\"dq1\"":"" %>><%#Eval("TypeName") %></a>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </td>
                            <td width="21%">
                                <table width="200" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td>
                                            排序：
                                        </td>
                                        <td id="time1">
                                            <a href="<%=CreateSortUrl() %>order=time" <%=sortstr=="time"?"class=\"time2\"":"" %>>
                                                时间</a><a href="<%=CreateSortUrl() %>order=hit" <%=sortstr=="hit"?"class=\"time2\"":"" %>>人气</a><a
                                                    href="<%=CreateSortUrl() %>order=point" <%=sortstr=="point"?"class=\"time2\"":"" %>>评分</a>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <!-- 显示可浏览的商店 -->
                    <div id="product">
                        <div class="fill">
                        </div>
                        <asp:Repeater ID="rpt_list" runat="server" EnableViewState="false">
                            <ItemTemplate>
                                <table id="pdt" cellspacing="0" cellpadding="0" class="pr_box">
                                    <tr>
                                        <td valign="top" class="pdt1">
                                            <a href="shopinfo.aspx?shopid=<%#Eval("id") %>">
                                                <img src="<%#Eval("shoppic") %>" width="212" height="160" border="0" /></a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="20" class="pdt2">
                                            营业时间：<%#Eval("opentime") %>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="20" class="pdt3">
                                            口味：<span><%#Eval("AvgTastePoint")%></span> 环境：<span><%#Eval("AvgMilieuPoint")%></span>
                                            服务：<span><%#Eval("AvgServicePoint")%></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="20" class="pdt4">
                                            <div class="star<%#Eval("AvgPoint") %>">
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="60" class="pdt5">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td>
                                                        <a href="shopinfo.aspx?shopid=<%#Eval("id") %>">
                                                            <img src="images/yncf_37.gif" width="134" height="42" /></a>
                                                    </td>
                                                    <td valign="bottom" class="pdt6">
                                                        历史订单<span><%#Eval("ShopOrder") %></span>笔
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:Repeater>
                        <%if (rpt_list.Items.Count == 0) { Response.Write("<div style='padding:10px;height:30px;line-height:30px;'>暂无匹配的店铺信息！</div>"); } %>
                        <div class="fill">
                        </div>
                        <div id="goTopBtn" style="display: none;">
                            <img src="images/yncf_17.gif" width="19" height="75" /></div>
                        <div class="fill">
                        </div>
                        <div style="text-align: right;">
                            <asp:AspNetPager CssClass="anpager" CurrentPageButtonClass="cpb" ID="WebPager" runat="server"
                                FirstPageText="首页" LastPageText="末页" NextPageText="下一页" PrevPageText="上一页" AlwaysShow="false"
                                ShowDisabledButtons="false" ShowPageIndexBox="Never" OnPageChanged="WebPager_PageChanged"
                                PageSize="16" UrlPaging="true">
                            </asp:AspNetPager>
                        </div>
                    </div>
                </td>
            </tr>
        </table>
        <ucl:Footer ID="Footer" runat="server" />
    </form>
    <script src="js/userarea.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            if ($("#s1").css("display") == "block") {
                $("#img1").attr("src", "images/yncf_33.GIF");
            }
            else {
                $("#img1").attr("src", "images/yncf_34.GIF");
            }
        });
        function path1() {
            if ($("#s1").css("display") == "none") {
                $("#s1").css("display", "block");
                $("#img1").attr("src", "images/yncf_33.GIF");
            } else {
                $("#s1").css("display", "none");
                $("#img1").attr("src", "images/yncf_34.GIF");
            }
        }
    </script>
</body>
</html>
