<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsList.aspx.cs" Inherits="web.touch.NewsList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>信息管理</title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/Common.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="mframe">
        <table width="98%" align="center" cellspacing="0" cellpadding="0">
            <tr>
                <td class="tl"></td>
                <td class="tm"><span class="tt">信息管理</span></td>
                <td class="tr"></td>
            </tr>
        </table>
        <table width="98%" align="center" cellspacing="0" cellpadding="0">
            <tr>
                <td class="ml"></td>
                <td class="mm">
                    <div style="padding-left:10px; display:none;"><asp:DropDownList ID="ddl_type" runat="server"></asp:DropDownList>
                        <asp:LinkButton ID="btn_select" runat="server" OnClick="btn_Select_Click" ToolTip="搜索"><img src="images/btn/bt_search.gif" border="0" alt="搜索" align="absmiddle" /></asp:LinkButton>
                    </div>
                    <div style="padding:5px 0px 5px 0px;">
                        <a href="NewsAdd.aspx?pid=<%=parentId %>" title="添加" class="fLink"> 添 加 </a>&nbsp;
                        <asp:LinkButton ID="lbtnDelAll" runat="server" OnClientClick="return confirm('您确定要删除吗？')" onclick="btn_del_Click" ToolTip="批量删除" class="fLink" Text="批量删除"></asp:LinkButton>&nbsp;
                        <asp:LinkButton ID="btn_update" runat="server" onclick="btn_up_Click" ToolTip="批量修改" class="fLink" Text="批量修改"></asp:LinkButton>
                    </div>
                    <asp:DataGrid ID="myGrid" runat="server" AutoGenerateColumns="False"  CssClass="grid" border="0" align="center" BorderColor="#C6DAE5"
                    Width="100%" CellPadding="6" CellSpacing="0" OnItemCommand="myGrid_ItemCommand" OnItemCreated="myGrid_ItemCreated">
                    <HeaderStyle CssClass="gridHead" />
                    <ItemStyle CssClass="tdbg" />
                    <Columns>
                        <asp:BoundColumn DataField="Id" Visible="false"></asp:BoundColumn>
                        <asp:TemplateColumn>
                            <HeaderStyle Width="3%" />
                            <HeaderTemplate>
                                <input type="checkbox" name="chkall" id="chkall" onclick="chkGridViewCheckBox(this,'chkdg')" title="全选/取消" />
                            </HeaderTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:CheckBox ID="chkdg" runat="server" ToolTip="选中一行" />
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="Id"  HeaderText="ID" ItemStyle-Width="3%" ItemStyle-HorizontalAlign="Center"></asp:BoundColumn>
                        <asp:TemplateColumn HeaderText="标 题">
                            <HeaderStyle Width="20%" />
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                                    <%#Eval("NewTitle")%>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="类 别">
                            <HeaderStyle Width="7%" />
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <%#GetTypeNameById(Eval("ClassId"))%>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="AddTime" HeaderText="时 间">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle Width="7%" />
                        </asp:BoundColumn>
                        <asp:TemplateColumn HeaderText="排序ID">
                            <HeaderStyle Width="5%" />
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:TextBox ID="txt_SortID" runat="server" CssClass="inpu" MaxLength="8" onkeypress="if (event.keyCode < 45 || event.keyCode > 57 || event.keyCode == 46) event.returnValue = false;"
                                    Text='<%#Eval("SortID") %>' Width="40px"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="操 作">
                            <HeaderStyle Width="7%" />
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <a title="编辑" href="NewsEdit.aspx?id=<%#Eval("Id") %>&pid=<%=parentId %>"><img src="images/icon_edit.gif" border="0" alt="编辑" align="absmiddle" />编辑</a>&nbsp;&nbsp;
                                <asp:LinkButton ID="btn_listdel" runat="server" ToolTip="删除" CommandName="del" CommandArgument='<%#Eval("Id") %>' OnClientClick="return confirm('您确定要删除吗？')"><img src="images/icon_delete.gif" alt="删除" border="0" align="absmiddle" />删除</asp:LinkButton>
                                <asp:HiddenField ID="hf_img" runat="server" Value='<%#Eval("ImgSrc") %>' />
                            </ItemTemplate>
                        </asp:TemplateColumn>
                    </Columns>
                    </asp:DataGrid>
                    <div class="pager">
                    <asp:AspNetPager ID="WebPager" runat="server" FirstPageText="首页" LastPageText="末页" NextPageText="下一页" PrevPageText="上一页"
                        AlwaysShow="false" ShowDisabledButtons="false" ShowPageIndexBox="Never" onpagechanged="WebPager_PageChanged" PageSize="15"></asp:AspNetPager>
                    </div>
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
