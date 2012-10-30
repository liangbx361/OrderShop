<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="leftmenu.aspx.cs" Inherits="web.admin.leftmenu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title></title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1">
    <table cellpadding="0" cellspacing="0" width="162" align="center" border="0">
	<tr>
	<td>
	    <div id="menuNews" class="menu">
	        <%=GetMenu()%>
	    </div>
	</td>
	</tr>
	</table>
    </form>
</body>
</html>
