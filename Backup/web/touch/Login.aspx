<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="web.admin.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>��վ��̨����ϵͳ</title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="css/login.css" type="text/css"/>
    <script type="text/javascript">
        function checkLogin() {
            if (document.getElementById("txt_loginName").value == "") {
                alert("�������û���");
                document.getElementById("txt_loginName").focus();
                return false;
            }
            else if (document.getElementById("txt_loginPwd").value == "") {
                alert("����������");
                document.getElementById("txt_loginPwd").focus();
                return false;
            } else if (document.getElementById("txt_code").value == "") {
                alert("��������֤��");
                document.getElementById("txt_code").focus();
                return false;
            }else {
                return true;
            }
        }
        
    </script>
</head>
<body style="padding-top:167px;">
    <form id="form1" runat="server">
    <div class="box">
<dl>
<dd><div class="s1">�û�����</div><div class="s2"><input type="text" id="txt_loginName" runat="server" class="inp1" name="memberName" size="12" maxlength="50"/></div></dd>
<dd><div class="s3">��&nbsp;&nbsp;&nbsp;&nbsp;�룺</div><div class="s4"><input type="password" id="txt_loginPwd" runat="server" class="inp2" name="memberPass" size="12" maxlength="50"/></div></dd>
<dd><div class="s5">��֤�룺</div><div class="s6"><input type="text" class="inp3" name="vcode" id="txt_code" runat="server" size="12" maxlength="4"/> <img src="checkcode.aspx" alt="�����壿�������" style="cursor:pointer" onclick="this.src=this.src+'?'" align="absmiddle"></div></dd>
<dd><div class="s7"><asp:Button ID="btn_login" runat="server" Text="�� ¼" CssClass="button" onclick="btn_login_Click" OnClientClick="return checkLogin()" /></div></dd>
</dl>
	</div>
    </form>
</body>
</html>
