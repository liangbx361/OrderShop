<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="shoppingsure.aspx.cs" Inherits="web.shoppingsure" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title><%=webset.WebName%>-免费发送到手机</title>
    <link href="css/public.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
    body{ background-color:#ebebeb}
    .dx01{margin:0 auto;margin-top:50px;width:465px;border:1px solid #999; background-color:#FFF}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <input type="hidden" id="hiddenshoptel" runat="server" />
    <table border="0" cellspacing="0" cellpadding="0" class="dx01">
  <tr>
    <td height="23" colspan="3" background="images/yncf_88.gif" style="padding-left:20px;">免费发送到手机</td>
  </tr>
  <tr>
    <td width="10" rowspan="12">&nbsp;</td>
    <td height="50" style="border-bottom:1px solid #c1c1c1"><strong style="font-size:14px">我选的菜(<asp:Label ID="L_ShopName" runat="server"></asp:Label>)-</strong><span style="color:#999">发送短信</span></td>
    <td width="10" rowspan="12">&nbsp;</td>
  </tr>
  <tr>
    <td height="30" style="color:#666">以下内容通过手机短信的形式，发送到您 指定的手机：</td>
  </tr>
  <tr>
    <td style="background:#6e6e6e;padding:10px 20px;line-height:18px; color:#FFF">
        <asp:Repeater ID="rpt_list" runat="server" EnableViewState="false"><ItemTemplate>
        <%#Eval("ProductName") %>(<%#Eval("BuyNum") %>)&nbsp;
        </ItemTemplate></asp:Repeater>
    </td>
  </tr>
  <tr>
    <td height="35" style="padding-left:20px;"><strong>地址：</strong>
            <asp:Label ID="L_Address" runat="server"></asp:Label>
            <input type="text" id="txtAddress" value="" runat="server" maxlength="20" style="border:solid 1px #000;width:100px;" />（楼层+公司简称(单元号)或楼号+单元号）
            <asp:RequiredFieldValidator ID="rfvaddress" runat="server" ControlToValidate="txtAddress" ErrorMessage="不能为空"></asp:RequiredFieldValidator>
            <input type="hidden" id="hiddenaid" value="0" runat="server" />
    </td>
  </tr>
  <tr>
    <td height="25" style="padding-left:20px;"><strong>联系人：</strong><asp:Label ID="L_Name" runat="server"></asp:Label></td>
  </tr>
  <tr>
    <td height="25" style="padding-left:20px;"><strong>手机号：</strong>
        <asp:Label ID="L_Mobile" runat="server"></asp:Label>
    </td>
  </tr>
  <tr>
    <td height="25" style="padding-left:20px;"><strong>送餐时间：</strong>
        <select name="hours" id="hours">
            <option value="10">10点</option>
            <option value="11">11点</option>
            <option value="12">12点</option>
            <option value="13">13点</option>
            <option value="14">14点</option>
            <option value="15">15点</option>
            <option value="16">16点</option>
            <option value="17">17点</option>
            <option value="18">18点</option>
            <option value="19">19点</option>
            <option value="20">20点</option>
            <option value="21">21点</option>
        </select>
        <select name="minutes" id="minutes">
            <option value="00">00分</option>
            <option value="15">15分</option>
            <option value="40">30分</option>
            <option value="45">45分</option>
        </select>
    </td>
  </tr>
  <tr>
    <td height="35" style="padding-left:20px;"><strong>验证码：</strong>
        <input type="text" size="5" id="txtcode" runat="server" maxlength="4" style="border:solid 1px #000" /> <img src="VerifyCode.aspx" alt="看不清楚?换一个" align="absmiddle" style="cursor:pointer" onclick="this.src=this.src+'?'+Math.random();" />
        <asp:Label ID="L_vialcode" runat="server" Text="" ForeColor="Red" EnableViewState="false"></asp:Label>
    </td>
  </tr>
  <tr>
    <td height="50" style="padding-left:20px;"><asp:LinkButton ID="btnSubmit" runat="server" OnClick="btnSubmit_Click"><img src="images/yncf_89.gif" width="84" height="28" /></asp:LinkButton></td>
  </tr>
  <tr>
    <td style="padding:10px;line-height:20px;color:#999">*如果看不清验证码，请点击图片刷新。<BR />*短信可能有3-5分钟的延时，请不要在短时间内多次重复发送。<BR />*短信内容过长，可能会分多条发送。<BR />*如果未收到短信，请到会员中心重新获取。<BR />*您的手机号码仅用于发送您需要的商户信息，不会透露给第三方。</td>
  </tr>
  <tr>
    <td align="center" style="padding:10px;line-height:20px;color:#999"><a href="shopinfo.aspx?shopid=<%=shopid %>"><img src="images/yncf_93.gif" width="126" height="27" border="0" /></a></td>
  </tr>
</table>
    </form>
</body>
</html>
