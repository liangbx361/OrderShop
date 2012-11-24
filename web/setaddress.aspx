<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="setaddress.aspx.cs" Inherits="web.setaddress" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title><%=webset.WebName%></title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .mian{width:980px; margin:0 auto;border:solid 1px #ccc;}
        .ctitle{ padding-left:10px; font-size:18px;font-weight:bold;height:40px;line-height:40px;border-bottom:solid 1px #ccc;}
        .sc{background:url(images/dian.gif) no-repeat;font-size:14px;font-weight:bold;height:22px; line-height:22px;padding-left:25px;}
        .pay_address{ width:948px; margin-left:5px; margin-top:15px; display:inline; text-align:left;}
        .pay_address .sline{height:30px;line-height:30px;font-size:14px; font-weight:bold;color:#5F5F5F}
        .pay_address .sline .sl{width:120px; display:block; float:left;}
        .pay_address .sline .sr{padding-left:30px; float:left;}
        .bsu{width:230px;padding-top:20px;height:60px;}
        .bsu img{border:0;cursor:pointer;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <ucl:Header ID="Header" runat="server" />
    <div class="mian">
        <div class="ctitle">送餐信息</div>
        <div style="padding:10px 0px 0px 20px;">
            <div class="sc">收餐地址</div>
            <div style="margin:10px;" class="pay_address">
                <table width="950" cellpadding="0" cellspacing="0" border="0" style="margin-bottom:10px;*margin-top:10px;_margin-top:10px;">
                    <tr>
                        <td width="550">
                            <div id="addressview">
                                <div class="sline"><span class="sl">送餐场所：</span><span class="sr"><asp:DropDownList ID="ddladdress" runat="server" onselectedindexchanged="ddladdress_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList></span></div>
                                <div class="sline"><span class="sl">区 域：</span><span class="sr"><asp:Literal ID="L_Area" runat="server" EnableViewState="false"></asp:Literal></span></div>
                                <div class="sline"><span class="sl">街道/楼宇：</span><span class="sr"><asp:Literal ID="L_Address" runat="server" EnableViewState="false"></asp:Literal></span></div>
                                <div class="sline"><span class="sl">联系人：</span><span class="sr"><asp:Literal ID="L_UserName" runat="server" EnableViewState="false"></asp:Literal></span></div>
                                <div class="sline"><span class="sl">联系电话：</span><span class="sr"><asp:Literal ID="L_UserTel" runat="server" EnableViewState="false"></asp:Literal></span></div>
                            </div>
                            <div style="margin-top:15px;"><a href="Users/useraddress.aspx"><img src="images/addaddress.jpg" /></a></div>
                            <div class="bsu">
                                <span style="float:left;"><img src="images/cancel.jpg" onclick="javascript:history.back()" /></span>
                                <span style="float:right;"><asp:LinkButton ID="btnSubmit" runat="server" onclick="btnSubmit_Click"><img src="images/submit.jpg" /></asp:LinkButton></span>
                            </div>
                        </td>
                        <td width="100" style="border-left:dashed 1px #000;padding:10px;">&nbsp;</td>
                        <td width="300" valign="top">
                            <div><img src="images/t1.jpg" /></div>
                            <div style="font-size:15px; font-weight:bold;height:40px;">107饭网只接受当天的预定</div>
                            <div style="font-size:13px; line-height:22px;">
                                <strong style="font-size:14px;">天气状况</strong><br />
                                商家送餐服务可能因恶劣天气、<br />
                                不可抗力等原因而中断或延时。
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <ucl:Footer ID="Footer" runat="server" />
    </form>
</body>
</html>
