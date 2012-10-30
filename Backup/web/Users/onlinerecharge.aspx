<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="onlinerecharge.aspx.cs" Inherits="web.Users.onlinerecharge" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title><%=webset.WebName%></title>
    <link href="/css/style.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery.js" type="text/javascript"></script>
    <script src="/js/userarea.js" type="text/javascript"></script>
    <style type="text/css">
        #dh00 #dh02 a{color:#ff6600;font-weight:bold}
    </style>
    <script type="text/javascript">
        function VialdPrice() {
            var price_reg = /^[0-9]*[1-9][0-9]*.*$/;
            var price = document.getElementById("txtorderprice");
            if (!price.value.match(price_reg)) {
                alert("充值金额格式输入错误！");
                price.value = "1";
                document.getElementById("orderpoint").innerHTML = "";
            } else {
                document.getElementById("orderpoint").innerHTML = "可获得 " + parseFloat(price.value) * 5 + "积分";
            }
        }
        function checksub() {
            if (document.getElementById("txtorderprice").value == "0") {
                alert("请输入充值金额");
                document.getElementById("txtorderprice").focus();
                return false;
            }
            return true;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <ucl:Header ID="Header" runat="server" />
    <div id="main">
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="80%" height="20" id="path2">当前位置：<a href="/">首页</a> > 会员管理中心</td>
    <td width="4%"></td>
    <td width="16%" id="path3"></td>
  </tr>
</table>
<table width="100%" border="0" cellspacing="0" cellpadding="0" style="margin:10px 0">
  <tr>
    <td width="190" valign="top"><ucl:UserLeft ID="UserLeft" runat="server" />
</td>
    <td width="20">&nbsp;</td>
    <td valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0" height="31" background="/images/yncf_73.gif">
      <tr>
        <td width="2%">&nbsp;</td>
        <td width="79%">
<div id="me1">
<ul>
<li id="mee0" class="me2" onclick="javascript:self.location='accountmanagement.aspx'">账户余额</li>
<li id="mee1" class="me3">在线充值</li>
<li id="mee2" class="me2" onclick="javascript:self.location='rechargeorders.aspx'">充值订单</li>
</ul>
</div>
</td>
        <td width="19%">&nbsp;</td>
      </tr>
    </table>
<table width="100%" border="0" cellspacing="0" cellpadding="0" style="margin-top:10px" id="mse0">
        <tr>
          <td width="60">充值金额：</td>  
          <td width="90">
              <input type="hidden" id="hidden_orderno" runat="server" value="" />  
              <input type="text" id="txtorderprice" runat="server" value="1" style="border:1px solid #8ab6dd;width:80px;height:18px;" maxlength="8" onkeyup="VialdPrice()" />
        </td>
        <td><asp:LinkButton ID="btnSubmit" runat="server" onclick="btnSubmit_Click" OnClientClick="return checksub()"><img src="/images/yncf_85.gif" /></asp:LinkButton>
            <span id="orderpoint"></span>
        </td>
        </tr>
        <tr>
          <td height="10" colspan="3">&nbsp;</td>
        </tr>
        <tr>
          <td valign="top" colspan="3"><table width="100%" border="0" cellspacing="0" cellpadding="0" style="border:1px solid #dedee0; background-color:#fffee2">
  <tr>
    <td valign="top" style="padding:20px;line-height:24px;font-size:14px">
    1、最低1元起充值，充值金额为整数值。<BR /> 
2、1元=5pv（积分）。<BR /> 
3、在实际点餐过程中1pv=1元。（相当于您的钱放大了5倍）。<BR /> 
  </tr>
</table>
</td>
        </tr>
        </table>
</td>
  </tr>
</table>

</div>
    <ucl:Footer ID="Footer" runat="server" />
    </form>
</body>
</html>
