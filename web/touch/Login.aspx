<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="web.admin.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>网站后台管理系统</title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="css/login.css" type="text/css"/>
    <script type="text/javascript">
        function checkLogin() {
            if (document.getElementById("txt_loginName").value == "") {
                alert("请输入用户名");
                document.getElementById("txt_loginName").focus();
                return false;
            }
            else if (document.getElementById("txt_loginPwd").value == "") {
                alert("请输入密码");
                document.getElementById("txt_loginPwd").focus();
                return false;
            } else if (document.getElementById("txt_code").value == "") {
                alert("请输入验证码");
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
<dd><div class="s1">用户名：</div><div class="s2"><input type="text" id="txt_loginName" runat="server" class="inp1" name="memberName" size="12" maxlength="50"/></div></dd>
<dd><div class="s3">密&nbsp;&nbsp;&nbsp;&nbsp;码：</div><div class="s4"><input type="password" id="txt_loginPwd" runat="server" class="inp2" name="memberPass" size="12" maxlength="50"/></div></dd>
<dd><div class="s5">验证码：</div><div class="s6"><input type="text" class="inp3" name="vcode" id="txt_code" runat="server" size="12" maxlength="4"/> <img src="checkcode.aspx" alt="看不清？点击更换" style="cursor:pointer" onclick="this.src=this.src+'?'" align="absmiddle"></div></dd>
<dd><div class="s7"><asp:Button ID="btn_login" runat="server" Text="登 录" CssClass="button" onclick="btn_login_Click" OnClientClick="return checkLogin()" /></div></dd>
</dl>
	</div>
    </form>
</body>
</html>
