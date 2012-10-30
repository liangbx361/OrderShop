<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="modifyaddress2.aspx.cs" Inherits="web.modifyaddress2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>更新地址</title>
    <link href="/css/style.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery.js" type="text/javascript"></script>
    <style type="text/css">
        .subcs{width:40px;height:20px;background:url(/images/yncf_11.gif) no-repeat;border:0; cursor:pointer;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <input type="hidden" id="hidden_aid" value="0" />
    <input type="hidden" id="hidden_sid" value="0" />
    <input type="hidden" id="hidden_did" value="0" />
    <div style="padding-left:10px;height:40px; line-height:30px;">
        您已选择：<span id="useladdress" style="color:#ff0000; font-size:13px;"></span> <input type="button" value="提交" class="subcs" onclick="subaddress()" />
    </div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" id="condition">
    <tr>
    <td style="padding:20px"><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td width="8%" height="35" align="right"><strong>按区域：</strong></td>
        <td width="92%" class="area"><span id="a0" class="qy" onclick="loadstreet(0)">全市</span><span id="a1" onclick="loadstreet(1)">鼓楼区</span><span id="a2" onclick="loadstreet(2)">台江区</span><span id="a3" onclick="loadstreet(3)">晋安区</span><span id="a4" onclick="loadstreet(4)">仓山区</span></td>
      </tr>
      <tr>
        <td>&nbsp;</td>
        <td class="city" id="city_street">
            <asp:Repeater ID="rpt_streets" runat="server" EnableViewState="false"><ItemTemplate>
            <a id="district<%#Eval("Id") %>" rel="<%#Eval("Pid") %>" href="javascript:;" onclick="district(<%#Eval("Id") %>)">[<%#Eval("AreaName") %>]</a>
            </ItemTemplate></asp:Repeater>
        </td>
      </tr>
    </table></td>
  </tr>
  <tr>
    <td style="padding:0 20px;"><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td width="8%" height="35" align="right"><strong>楼宇\小区：</strong></td>
        <td width="92%" class="area1" id="city_district"><span id="z" class="qy" onclick="seltZM('')">全部</span><span id="zA" onclick="seltZM('A')">A</span><span id="zB" onclick="seltZM('B')">B</span><span id="zC" onclick="seltZM('C')">C</span><span id="zD" onclick="seltZM('D')">D</span><span id="zE" onclick="seltZM('E')">E</span><span id="zF" onclick="seltZM('F')">F</span><span id="zG" onclick="seltZM('G')">G</span><span id="zH" onclick="seltZM('H')">H</span><span id="zI" onclick="seltZM('I')">I</span><span id="zJ" onclick="seltZM('J')">J</span><span id="zK" onclick="seltZM('K')">K</span><span id="zL" onclick="seltZM('L')">L</span><span id="zM" onclick="seltZM('M')">M</span><span id="zN" onclick="seltZM('N')">N</span><span id="zO" onclick="seltZM('O')">O</span><span id="zP" onclick="seltZM('P')">P</span><span id="zQ" onclick="seltZM('Q')">Q</span><span id="zR" onclick="seltZM('R')">R</span><span id="zS" onclick="seltZM('S')">S</span><span id="zT" onclick="seltZM('T')">T</span><span id="zU" onclick="seltZM('U')">U</span><span id="zV" onclick="seltZM('V')">V</span><span id="zW" onclick="seltZM('W')">W</span><span id="zX" onclick="seltZM('X')">X</span><span id="zY" onclick="seltZM('Y')">Y</span><span id="zZ" onclick="seltZM('Z')">Z</span></td>
      </tr>
      <tr>
        <td></td>
<td><div id="s1"><ul id="path1">
<asp:Repeater ID="rpt_district" runat="server" EnableViewState="false"><ItemTemplate>
<li><a href="javascript:;" onclick="seldistrict(<%#Eval("Id") %>,<%#Eval("Pid") %>,'<%#Eval("AreaName") %>')"><%#Eval("AreaName") %></a></li>
</ItemTemplate></asp:Repeater>
</ul>
<div class="fill"></div>
<div style="height:10px"></div>
</div>
</td></tr>
    </table></td>
  </tr>
</table>
    </form>
    <script src="/js/userarea.js" type="text/javascript"></script>
</body>
</html>
