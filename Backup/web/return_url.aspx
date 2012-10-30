<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="return_url.aspx.cs" Inherits="web.return_url" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title></title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        #menu #menu3 a{background:url(images/yncf_07.gif);font-weight:bold;color:#FFF;}
        #dh00 #dh01 .current{color:#ff6600;font-weight:bold}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <ucl:Header ID="Header" runat="server" />
    <div style="text-align:center; height:40px; line-height:30px;">
        <asp:Literal ID="ltl_msg" runat="server" EnableViewState="false"></asp:Literal>
    </div>
    <ucl:Footer ID="Footer" runat="server" />
    </form>
</body>
</html>
