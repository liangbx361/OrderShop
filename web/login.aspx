<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="web.login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>
        <%=webset.WebName%></title>
    <link style="text/css" rel="stylesheet" href="css/fansy.css" />
    <!--107�Է���ҳcss-->
    <link style="text/css" rel="stylesheet" href="css/fan_lg.css" />
    <!--107�Է���ҳcss-->
    
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/userarea.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <ucl:Header ID="Header" runat="server" />
    <!--107�Է���ҳ �м䲿-->
    <div id="main">
        <!--107�Է���¼-->
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
                        <font color="#CC0000" style="font-family: ����; font-weight: bold; font-size: 24px;">��¼</font>
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
                            <!--107�Է� �������ݱ�-->
                            <div class="cfw_lg_nrstop">
                                <table width="623" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td height="34" colspan="3" valign="top">
                                            <img src="images/cfw_lg_txhhmmm.gif" width="228" height="22" />&nbsp;&nbsp;&nbsp;&nbsp;
                                            <font color="#FF0000">* </font>Ϊ����
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="100" height="40" align="right" class="lzitd">
                                            �û�����&nbsp;&nbsp;
                                        </td>
                                        <td width="200" class="rinpput_td">
                                            <input type="text" id="username" runat="server" class="rinpputs" />
                                        </td>
                                        <td width="323">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="40" align="right" class="lzitd">
                                            ��<span style="margin-left: 14px;">�룺</span>&nbsp;&nbsp;
                                        </td>
                                        <td class="rinpput_td">
                                            <input type="password" id="upassword" runat="server" class="rinpputs" />
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="40">
                                            &nbsp;
                                        </td>
                                        <td colspan="2">
                                            <a href="/findpwd.aspx">�������룿</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="register.aspx">����ע��</a>&nbsp;&nbsp;&nbsp;&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="40">
                                            &nbsp;
                                        </td>
                                        <td colspan="2">
                                            <asp:LinkButton ID="btnLogin" runat="server" OnClick="btnLogin_Click"><img src="/images/fw_lg_tjbut.gif" width="117" height="33" style="cursor:pointer;"/></asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="70" colspan="3">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <!--107�Է� �ָ���-->
                            <div class="cfw_lg_fgx">
                            </div>
                            <!--107�Է� ����˵�-->
                            <div class="cfw_lg_llcd">
                                <table width="623" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="33" height="40">
                                        </td>
                                        <td width="75" height="40">
                                            <font style="font-size: 15px"><strong>�����ȣ�</strong></font>
                                        </td>
                                        <td width="515" height="40">
                                            <asp:LinkButton ID="btnLook" runat="server" OnClick="btnLook_Click">
                                            <img src="images/fw_lg_llcdbut.gif" width="117" height="33" />
                                            </asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="30">
                                            &nbsp;
                                        </td>
                                        <td height="30" colspan="2">
                                            �������⣬���µ�0591-28068107.
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
                                        ����
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
                                        �κγ���300Ԫ�Ķ������벦��107�����绰��<font color="#FF0000">0591-28068107</font>
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
                                        107��������ֻ����һ����Ԥ��
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
                                        �Ͳͷ��������������������ɿ�����ԭ����жϻ��ӳ١�
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
    <script type="text/javascript">
        function document.onkeydown() {
            if (event.keyCode == 13) {
                document.getElementById("btnLogin").click();
                return false;
            }
        }
    </script>
</body>
</html>
