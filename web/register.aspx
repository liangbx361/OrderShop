<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="web.register" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>
        <%=webset.WebName%></title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link href="css/login.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/userarea.js" type="text/javascript"></script>
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
    <div id="main">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td width="80%" height="20" id="path2">
                    ��ǰλ�ã�<a href="/">�����Է�</a>
                    > �û�ע��
                </td>
                <td width="4%">
                    ����
                </td>
                <td width="16%" id="path3">
                    <a href="#">
                        <img src="images/yncf_50.gif" width="19" height="24" /></a><a href="#"><img src="images/yncf_51.gif"
                            width="20" height="24" /></a><a href="#"><img src="images/yncf_52.gif" width="20"
                                height="24" /></a><a href="#"><img src="images/yncf_53.gif" width="20" height="24" /></a><a
                                    href="#"><img src="images/yncf_54.gif" width="20" height="24" /></a><a href="#"><img
                                        src="images/yncf_55.gif" width="20" height="24" /></a>
                </td>
            </tr>
        </table>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td valign="top">
                    <div id="main_re" class="best">
                        <div id="re01">
                            ���Ѿ�ע�ᣬ���ھ�<a href="login.aspx">��¼</a></div>
                        <div id="re02">
                            <ul>
                                <li>
                                    <h1>
                                        �û�����</h1>
                                    <h2>
                                        <input type="text" id="txtUserName" runat="server" onblur="VialdUserName()" maxlength="20" /><span
                                            id="c_username" class=""></span></h2>
                                </li>
                                <li>
                                    <h1>
                                        �ֻ���</h1>
                                    <h2>
                                        <input type="text" id="txtMobile" runat="server" onblur="VialdMobile()" maxlength="11" /><span
                                            id="c_mobile" class=""></span></h2>
                                </li>
                                <li>
                                    <h1>
                                        ���䣺</h1>
                                    <h2>
                                        <input type="text" id="txtEmail" runat="server" onblur="VialdEmail()" maxlength="100" /><span
                                            id="c_email" class=""></span></h2>
                                </li>
                                <li>
                                    <h1>
                                        �������룺</h1>
                                    <h2>
                                        <input type="password" id="txtPass" runat="server" onblur="VialdPass()" maxlength="20" /><span
                                            id="c_pass" class=""></span></h2>
                                </li>
                                <li>
                                    <h1>
                                        ȷ�����룺</h1>
                                    <h2>
                                        <input type="password" id="txtPass2" runat="server" onblur="VialdPass2()" maxlength="20" /><span
                                            id="c_pass2" class=""></span></h2>
                                </li>
                                <li>
                                    <h1>
                                        ��֤�룺</h1>
                                    <h2>
                                        <span>
                                            <input type="text" id="txtCode" runat="server" onblur="VialdCode()" style="width: 50px;"
                                                maxlength="4" /></span><span id="re04">&nbsp;<img src="VerifyCode.aspx" alt="�������?��һ��"
                                                    align="absmiddle" style="cursor: pointer" onclick="this.src=this.src+'?'+Math.random();" />&nbsp;</span><span
                                                        id="c_code" class=""></span></h2>
                                </li>
                                <li>
                                    <h1>
                                        &nbsp;</h1>
                                    <h2>
                                        <input type="checkbox" id="chkagreement" checked style="width: 15px; height: 19px;" /><span
                                            style="line-height: 25px">���ѿ�����ͬ��<a href="user_agreement.aspx">���û�Э�顷</a></span></h2>
                                </li>
                                <li id="re05">
                                    <asp:LinkButton ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" OnClientClick="return CheckAll()"><img src="images/lo07.gif" width="213" height="34" style="cursor:pointer;" /></asp:LinkButton>
                                </li>
                            </ul>
                        </div>
                        <div class="clearfloat">
                        </div>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <ucl:Footer ID="Footer" runat="server" />
    </form>
    <script src="js/userregister.js" type="text/javascript"></script>
</body>
</html>
