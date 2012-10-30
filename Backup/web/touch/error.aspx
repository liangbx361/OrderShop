<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="error.aspx.cs" Inherits="web.admin.error" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>页面提示</title>
    <style type="text/css">
.Msg{background-image: url(images/msg_4.gif);background-repeat: repeat-y;}
.alert1{float:left;width:11px;height:25px;background:url(images/msg_1.gif) no-repeat;}
.alert2{float:left;width:564px;height:25px;background:url(images/msg_2.gif) repeat-x;color: #FFFFFF; padding-top:5px;}
.alert3{float:left;width:28px;height:25px;background:url(images/msg_3.gif) no-repeat;}
.alert31{float:left;width:28px;background:url(images/msg_3_1.gif) no-repeat;height: 25px;}
.alert4{width:3px;height:180px;font-size:3px;float:left;background:url(images/msg_4.gif) repeat-y;}
.alert5{width:3px;height:180px;font-size:3px;float:left;background:url(images/msg_4.gif) repeat-y;}
.alert6{width:3px;height: 5px;float:left;background:url(images/msg_6.gif) no-repeat;}
.alert7{width:600px;height:5px;float:left;background:url(images/msg_7.gif) no-repeat;}
.msg_box{width:603px;}
.cls{clear:both;font-size:0;height:0;line-height:0;} 
a:active{color: #2175a3;text-decoration: none;}
a:hover{text-decoration: none;color: #ff6600;}
a:link{color: #2175a3;text-decoration: none;}
a:visited{color: #2175a3;text-decoration: none;}
</style>
</head>
<body>
    <form id="form1" runat="server">
    <script type="text/javascript">
        var secs = 3; //倒计时的秒数 
        for (var i = secs; i >= 0; i--) {
            window.setTimeout("doUpdate(" + i + ")", (secs - i) * 1000);
        }
        function doUpdate(num) {
            document.getElementById("timeout").innerHTML = num;
            if (num == 0) {
                window.location = "<%=url %>";
            }
        }
    </script>
     <div style="font-size:12px; padding:50px 200px;">
        <div class="msg_box" style="height:25px;overflow:hidden">
            <div class="alert1"></div>
            <div class="alert2">提示信息</div>
            <div class="alert31"></div>
            <div class="cls"></div>
        </div>
        <div class="msg_box">
            <div class="alert4"></div>
            <div style="width:597px;height:180px;float:left;">
                <table width="100%" height="100%">
                    <tr>
                        <td align="center"><span style="font-size:24px; color:Red"><b><%=FlagStr %></b></span></td>
                        <td style="line-height:150%;word-break:break-all;word-wrap:break-word;"><asp:Literal ID="ltlmsg" runat="server" EnableViewState="false"></asp:Literal>
                        <p><a href='<%=url %>' style="text-decoration: underline" class="white">
                                    立即返回</a>上级页面，<span id="timeout">3</span>秒后自动跳转</p>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="alert5"></div>
        </div>
        <div class="msg_box">
            <div class="alert6"></div>
            <div class="alert7"></div>
        </div>
        </div>
    </form>
</body>
</html>
