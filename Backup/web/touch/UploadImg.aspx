<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadImg.aspx.cs" Inherits="web.touch.UploadImg" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title></title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <script src="js/Common.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <span id="uploadSpan"><input id="File_ImgLink" runat="server" type="file" class="inpu" onchange="javascript:checkFormat(this.value,'uploadSpan');" /></span>
        <asp:LinkButton ID="btn_upload" runat="server" Text="上 传" CssClass="fLink" OnClick="btn_upload_Click"></asp:LinkButton>
    </div>
    </form>
</body>
</html>
