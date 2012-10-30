<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AreaList.aspx.cs" Inherits="web.touch.AreaList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function ShowDiv(e) {
            var objid = document.getElementById(e);
            objid.style.display = objid.style.display == "none" ? "block" : "none";
        }
    </script>
    <style type="text/css">
        .dline{width:98%;padding-left:20px;border-bottom:dashed 1px #114983;float:left;}
        .dleft{width:50%; cursor:pointer; float:left;}
        .dright{float:right;width:48%;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="mframe">
        <table width="98%" align="center" cellspacing="0" cellpadding="0">
            <tr>
                <td class="tl">
                </td>
                <td class="tm">
                    <span class="tt">地区管理</span>
                </td>
                <td class="tr">
                </td>
            </tr>
        </table>
        <table width="98%" align="center" cellspacing="0" cellpadding="0">
            <tr>
                <td class="ml">
                </td>
                <td class="mm">
                    <div style="height:25px;line-height:22px;">
                        <a href="Street_AE.aspx?action=add" class="fLink">添加街道</a>
                        <a href="District_AE.aspx?action=add" class="fLink">添加楼宇</a>
                    </div>
                    <table align="center" cellpadding="6" width="100%" cellspacing="0" bordercolor="#C6DAE5"
                        class="grid">
                        <tr>
                            <td style="line-height: 30px;">
                                <div style="width:98%;padding-left:20px;border-bottom:solid 1px #114983;" onmouseover="a=this.style.backgroundColor;this.style.backgroundColor='#E2E6E5'" onmouseout="this.style.backgroundColor=a">
                                    <div style="width:45%;float:right"><a href="Street_AE.aspx?action=add&pid=1">添加街道</a></div>
                                    <div style="width:50%; cursor:pointer;" onclick="ShowDiv('child1')">鼓楼区</div>
                                </div>
                                <div id="child1" style="display:none;">
                                    <%=GetStreet(1)%>
                                </div>
                                <div style="width:98%;padding-left:20px;border-bottom:solid 1px #114983;" onmouseover="a=this.style.backgroundColor;this.style.backgroundColor='#E2E6E5'" onmouseout="this.style.backgroundColor=a">
                                    <div style="width:45%;float:right"><a href="Street_AE.aspx?action=add&pid=2">添加街道</a></div>
                                    <div style="width:50%; cursor:pointer;" onclick="ShowDiv('child2')">台江区</div>
                                </div>
                                <div id="child2" style="display:none;">
                                    <%=GetStreet(2)%>
                                </div>
                                <div style="width:98%;padding-left:20px;border-bottom:solid 1px #114983;" onmouseover="a=this.style.backgroundColor;this.style.backgroundColor='#E2E6E5'" onmouseout="this.style.backgroundColor=a">
                                    <div style="width:45%;float:right"><a href="Street_AE.aspx?action=add&pid=3">添加街道</a></div>
                                    <div style="width:50%; cursor:pointer;" onclick="ShowDiv('child3')">晋安区</div>
                                </div>
                                <div id="child3" style="display:none;">
                                    <%=GetStreet(3)%>
                                </div>
                                <div style="width:98%;padding-left:20px;border-bottom:solid 1px #114983;" onmouseover="a=this.style.backgroundColor;this.style.backgroundColor='#E2E6E5'" onmouseout="this.style.backgroundColor=a">
                                    <div style="width:45%;float:right"><a href="Street_AE.aspx?action=add&pid=4">添加街道</a></div>
                                    <div style="width:50%; cursor:pointer;" onclick="ShowDiv('child4')">仓山区</div>
                                </div>
                                <div id="child4" style="display:none;">
                                    <%=GetStreet(4)%>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
                <td class="mr">
                </td>
            </tr>
        </table>
        <table width="98%" align="center" cellspacing="0" cellpadding="0">
            <tr>
                <td class="bl">
                </td>
                <td class="bm">
                    &nbsp;
                </td>
                <td class="br">
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
