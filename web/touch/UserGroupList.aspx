<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserGroupList.aspx.cs" Inherits="web.touch.UserGroupList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title></title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link href="css/thickbox.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/thickbox.jquery.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="mframe">
        <table width="98%" align="center" cellspacing="0" cellpadding="0">
            <tr>
                <td class="tl"></td>
                <td class="tm"><span class="tt">会员管理</span></td>
                <td class="tr"></td>
            </tr>
        </table>
        <table width="98%" align="center" cellspacing="0" cellpadding="0">
            <tr>
                <td class="ml"></td>
                <td class="mm">
                    <div style="padding:5px 0px 5px 0px;">
                        <a href="UserGroupAdd.aspx?keepThis=true&TB_iframe=true" class="fLink thickbox">添 加</a>
                        <a href="javascript:location.replace(location.href)" class="fLink">刷 新</a>
                    </div>
	                <asp:DataGrid ID="myGrid" runat="server" ShowHeader="true" ShowFooter="false" AutoGenerateColumns="False" CssClass="grid" border="0" align="center" BorderColor="#C6DAE5"
                        Width="100%" CellPadding="6" CellSpacing="0" OnItemCommand="myGrid_ItemCommand" OnItemCreated="myGrid_ItemCreated">
                        <HeaderStyle CssClass="gridHead" />
                        <ItemStyle CssClass="tdbg" />    
                        <Columns>
                            <asp:BoundColumn DataField="Id" HeaderText="ID" Visible="false"></asp:BoundColumn>
                            <asp:TemplateColumn HeaderText="名 称">
                                <ItemStyle HorizontalAlign="center"/>
				                <HeaderStyle Width="3%"/> 
                                <ItemTemplate>
                                    <%#Eval("GroupName")%>
                                </ItemTemplate>    
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="折扣">
                                <ItemStyle HorizontalAlign="center"/>
				                <HeaderStyle Width="3%"/> 
                                <ItemTemplate>
                                    <%#Eval("Zk") + " %"%>
                                </ItemTemplate>    
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="管理信息">
                                <ItemStyle HorizontalAlign="center"/>
				                <HeaderStyle Width="3%"/> 
                                <ItemStyle HorizontalAlign="center"  />
                                <ItemTemplate>
                                    <a href="UserGroupEdit.aspx?id=<%#Eval("Id") %>&true&TB_iframe=true" class="thickbox"><img src="images/icon_edit.gif" border="0" alt="编辑" align="absmiddle" />编辑</a>&nbsp;&nbsp;
                                    <%--<asp:LinkButton ID="lbtnDel" runat="server" CommandName="del" CommandArgument='<%#Eval("Id") %>' OnClientClick="return confirm('您确定要删除吗？')" ToolTip="删除"><img src="images/icon_delete.gif" alt="删除" border="0" align="absmiddle" />删除</asp:LinkButton>--%>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                        </Columns>
                    </asp:DataGrid>
                </td>
                <td class="mr"></td>
            </tr>
        </table>
        <table width="98%" align="center" cellspacing="0" cellpadding="0" >
            <tr>
                <td class="bl"></td>
                <td class="bm">&nbsp;</td>
                <td class="br"></td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
