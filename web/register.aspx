<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="web.register" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title><%=webset.WebName%></title>        
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link href="css/login.css" rel="stylesheet" type="text/css" />
    <link style="text/css" rel="stylesheet" href="css/fan_lg.css" />    <!--107吃饭首页css-->
    
    <script src="js/fansy.js" type="text/javascript"></script> <!--107吃饭首页 js-->   
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/userarea.js" type="text/javascript"></script>
    <script src="js/userregister.js" type="text/javascript"></script>

    <style type="text/css">
        #menu #menu3 a
        {
            background: url(images/yncf_07.gif);
            font-weight: bold;
            color: #FFF;
        }
        #dh00 #dh01 a
        {
            color: #ff6600;
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <ucl:Header ID="Header" runat="server" />
    <!--107吃饭首页 中间部-->
    <div id="main">
        <!--107吃饭登录-->
        <div class="fan_lg">
            <table width="998" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td height="10" colspan="5">
                    </td>
                </tr>
                <tr>
                    <td width="32" height="38">
                        &nbsp;
                    </td>
                    <td width="966" colspan="4">
                        <font color="#CC0000" style="font-family: 黑体; font-weight: bold; font-size: 24px;">注册新用户</font>
                    </td>
                </tr>
                <tr>
                    <td width="32">
                        &nbsp;
                    </td>
                    <td width="645" valign="top">
                        <div class="cfw_lg_thx">
                        </div>
                        <div class="cfw_lg_nrs">
                            <!--107吃饭 左上数据表-->
                            <div class="cfw_lg_nrstop">
                                <table width="623" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td height="34" colspan="3" valign="top">
                                            <img src="images/cfw_lg_txhhmmm.gif" width="228" height="22" />&nbsp;&nbsp;&nbsp;&nbsp;
                                            <font color="#FF0000">* </font>
                                            为必填
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="100" height="40" align="right" class="lzitd">
                                            称<span style="margin-left: 28px;">呼：</span>&nbsp;&nbsp;
                                        </td>
                                        <td width="200">
                                            <asp:RadioButtonList ID="RadioButtonListGender" runat="server" 
                                                RepeatDirection="Horizontal" 
                                                onselectedindexchanged="radioButtonListGender" Font-Size="14px" 
                                                ontextchanged="radioButtonListGender" Font-Bold="True" 
                                                ForeColor="#666666">
                                                <asp:ListItem Value="0" Text="0">先生</asp:ListItem>
                                                <asp:ListItem Value="1" Text="0">小姐</asp:ListItem>
                                            </asp:RadioButtonList>
                                            <!-- 
                                            <input type="radio" name="radio" id="male" value="0" runat="server" />
                                            <font color="#666666" style="font-size: 14px; font-weight: bold">先生</font>
                                            <input type="radio" name="radio" id="femal" value="1" runat="server" />
                                            <font color="#666666" style="font-size: 14px; font-weight: bold">小姐</font>
                                            -->
                                        </td>
                                        <td width="323">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="100" height="40" align="right" class="lzitd">
                                            用<span style="margin-left: 7px;">户</span><span style="margin-left: 7px;">名：</span>&nbsp;&nbsp;
                                        </td>
                                        <td width="200" class="rinpput_td">
                                            <input type="text" class="rinpputs" id="txtUserName" runat="server" onblur="VialdUserName()"
                                                maxlength="20" />
                                        </td>
                                        <td width="323">
                                            &nbsp;
                                            <font color=red>*</font>
                                            <span id="c_username" class=""></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="100" height="40" align="right" class="lzitd">
                                            手<span style="margin-left: 28px;">机：</span>&nbsp;&nbsp;
                                        </td>
                                        <td width="200" class="rinpput_td">
                                            <input type="text" class="rinpputs" id="txtMobile" runat="server" onblur="VialdMobile()"
                                                maxlength="11" />
                                        </td>
                                        <td width="323">
                                            &nbsp;
                                            <font color=red>*</font>
                                            <span id="c_mobile" class=""></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="100" height="40" align="right" class="lzitd">
                                            邮<span style="margin-left: 28px;">箱：</span>&nbsp;&nbsp;
                                        </td>
                                        <td width="200" class="rinpput_td">
                                            <input type="text" class="rinpputs" id="txtEmail" runat="server" onblur="VialdEmail()"
                                                maxlength="100" />
                                        </td>
                                        <td width="323">
                                            &nbsp;
                                            <font color=red>*</font>
                                            <span id="c_email" class=""></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="40" align="right" class="lzitd">
                                            设置密码：</span>&nbsp;&nbsp;
                                        </td>
                                        <td class="rinpput_td">
                                            <input type="password" class="rinpputs" id="txtPass" runat="server" onblur="VialdPass()"
                                                maxlength="20" />
                                        </td>
                                        <td>
                                            &nbsp;
                                            <font color=red>*</font>
                                            <span id="c_pass" class=""></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="40" align="right" class="lzitd">
                                            确认密码：&nbsp;&nbsp;
                                        </td>
                                        <td class="rinpput_td">
                                            <input type="password" class="rinpputs" id="txtPass2" runat="server" onblur="VialdPass2()"
                                                maxlength="20" />
                                        </td>
                                        <td>
                                            &nbsp;
                                            <font color=red>*</font>
                                            <span id="c_pass2" class="">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="40" align="right" class="lzitd">
                                            验<span style="margin-left: 7px;">证</span><span style="margin-left: 7px;">码：</span>&nbsp;&nbsp;
                                        </td>
                                        <td class="rinpput_td">
                                            <input type="text" class="rinpputs" id="txtCode" runat="server" onblur="VialdCode()" />
                                        </td>
                                        <td>
                                            <span >
                                                &nbsp;&nbsp;
                                                <font color=red>*</font>
                                                <img src="VerifyCode.aspx" alt="看不清楚?换一个" align="absmiddle" style="cursor: pointer"
                                                    onclick="this.src=this.src+'?'+Math.random();" /></span>
                                                    
                                                    <span id="c_code" class=""></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="40">
                                            &nbsp;
                                        </td>
                                        <td colspan="2">
                                            <input name="" type="checkbox" id="chkagreement" value="" style="margin-top: -2px;" />
                                            我已看过并同意<a href="user_agreement.aspx" style="color: #996">《用户协议》</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="40">
                                            &nbsp;
                                        </td>
                                        <td colspan="2">
                                            <asp:LinkButton ID="btnSubmit" runat="server" onclick="btnSubmit_Click" OnClientClick="return CheckAll()">
                                            <img src="images/fw_lg_tjbut.gif" width="117" height="33" onmouseover="fansy_submit_onm(this)" onmouseout="fansy_submit_out(this)" style="cursor: pointer;" />
                                            </asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="70" colspan="3">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <!--107吃饭 分割线-->
                            <div class="cfw_lg_fgx">
                            </div>
                            <!--107吃饭 浏览菜单-->
                            <div class="cfw_lg_llcd">
                                <table width="623" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="33" height="40">
                                        </td>
                                        <td width="75" height="40">
                                            <font style="font-size: 15px">
                                                <strong>我想先：</strong></font>
                                        </td>
                                        <td width="515" height="40">
                                            <asp:LinkButton ID="btnLook" runat="server" OnClick="btnLook_Click">
                                            <img src="images/fw_lg_lldpbut.gif" width="117" height="33" onmouseover="fansy_lldp_onm(this)" onmouseout="fansy_lldp_out(this)"/>
                                            </asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="30">
                                            &nbsp;
                                        </td>
                                        <td height="30" colspan="2">
                                            如遇问题，请致电0591-28068107.
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div class="cfw_lg_dbyy">
                        </div>
                    </td>
                    <td width="30">
                        &nbsp;
                    </td>
                    <td width="259" valign="top">
                        <div class="cfw_lg_rnrts">
                            <table width="259" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td height="114" colspan="3">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td width="6" height="24">
                                        &nbsp;
                                    </td>
                                    <td width="247" class="cfw_lg_rtiltd">
                                        大额订单
                                    </td>
                                    <td width="6">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td class="cfw_lg_rnrstd">
                                        任何超过300元的订单，请拨打107饭网电话：<font color="#FF0000">0591-28068107</font>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td height="10">
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="24">
                                        &nbsp;
                                    </td>
                                    <td class="cfw_lg_rtiltd">
                                        107饭网订餐只接受一周内预定
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td height="24">
                                        &nbsp;
                                    </td>
                                    <td class="cfw_lg_rnrstd">
                                        送餐服务可能因恶劣天气，不可抗力等原因而中断或延迟。
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td height="24">
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                    <td width="32">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td height="10" colspan="5">
                    </td>
                </tr>
            </table>
        </div>
        <ucl:Footer ID="Footer" runat="server" />
    </form>
</body>
</html>
