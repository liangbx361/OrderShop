<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuList.aspx.cs" Inherits="web.touch.MenuList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>菜单管理</title>
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
                <td class="tm"><span class="tt">菜单管理</span></td>
                <td class="tr"></td>
            </tr>
        </table>
        <table width="98%" align="center" cellspacing="0" cellpadding="0">
            <tr>
                <td class="ml"></td>
                <td class="mm">
                    <div style="padding-left:10px;">
                        <asp:DropDownList ID="ddl_menu" runat="server">
                        </asp:DropDownList>
                        &nbsp;<asp:LinkButton ID="btn_select" runat="server" OnClick="btn_Select_Click" CssClass="fLink" ToolTip="搜索" Text="  搜 索 "></asp:LinkButton>
                    </div>
                    <div style="padding:5px 0px 5px 0px;">
                        <a href="Menu_AE.aspx" title="添加" class="fLink">添 加</a>&nbsp;
                        <asp:LinkButton ID="lbtnDelAll" runat="server" OnClientClick="return confirm('您确定要删除吗？')" onclick="lbtnDelAll_Click" ToolTip="批量删除" CssClass="fLink" Text="批量删除"></asp:LinkButton>&nbsp;
                        <asp:LinkButton ID="btn_update" runat="server" onclick="btn_up_Click" ToolTip="批量修改" CssClass="fLink" Text="批量修改"></asp:LinkButton>
                    </div>
	                <asp:DataGrid ID="myGrid" runat="server" ShowHeader="true" ShowFooter="false" AutoGenerateColumns="False" CssClass="grid" border="0" align="center" BorderColor="#C6DAE5"
                        Width="100%" CellPadding="6" CellSpacing="0" OnItemCommand="myGrid_ItemCommand" OnItemCreated="myGrid_ItemCreated">
                        <HeaderStyle CssClass="gridHead" />
                        <ItemStyle CssClass="tdbg" />    
                        <Columns>
                            <asp:BoundColumn DataField="id" HeaderText="ID" Visible="false"></asp:BoundColumn>
                            <asp:TemplateColumn>
                                <HeaderTemplate>
                                    <input type="checkbox" name="chkall" id="chkall" title="全选/取消" onclick="chkGridViewCheckBox(this,'chkdg')" />
                                </HeaderTemplate>
                                <ItemStyle HorizontalAlign="center"/>
				                <HeaderStyle Width="3%"/>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkdg" runat="server" ToolTip="选中一行" />
                                </ItemTemplate>    
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="ID">
                                <ItemStyle HorizontalAlign="center"/>
				                <HeaderStyle Width="3%"/>     
                                <ItemTemplate>
                                    <%#Eval("Id")%>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="菜单名称">
                                <ItemStyle HorizontalAlign="center"/>
				                <HeaderStyle Width="5%"/> 
                                <ItemTemplate>
                                    <%#Eval("MenuName")%>
                                </ItemTemplate>    
                            </asp:TemplateColumn>
                            
                            <asp:TemplateColumn HeaderText="父级菜单">
                                <ItemStyle HorizontalAlign="center"/>
				                <HeaderStyle Width="5%"/> 
                                <ItemTemplate>
                                    <%#GetMenuNameByID(Eval("ParentId"))%>
                                </ItemTemplate>    
                            </asp:TemplateColumn>
                            
                            <asp:TemplateColumn HeaderText="链接地址">
                                <ItemStyle HorizontalAlign="center"/>
				                <HeaderStyle Width="7%"/> 
                                <ItemTemplate>
                                    <%#Eval("UrlLink")%>
                                </ItemTemplate>    
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="排序号">
                                <ItemStyle HorizontalAlign="center"/>
				                <HeaderStyle Width="3%"/> 
                                <ItemTemplate>
                                    <asp:TextBox ID="txt_SortID" runat="server" CssClass="inpu" onkeypress="if (event.keyCode < 45 || event.keyCode > 57 || event.keyCode == 46) event.returnValue = false;"
                                    Text='<%#Eval("SortId")%>' Width="40px"></asp:TextBox>
                                </ItemTemplate>    
                            </asp:TemplateColumn>       
                            <asp:TemplateColumn HeaderText="管理信息">
                                <ItemStyle HorizontalAlign="center"/>
				                <HeaderStyle Width="5%"/> 
                                <ItemStyle HorizontalAlign="center"  />
                                <ItemTemplate>
                                    <a href="<%#"Menu_AE.aspx?id="+Eval("Id") %>" title="编辑"><img src="images/icon_edit.gif" border="0" alt="编辑" align="absmiddle" />编辑</a>&nbsp;&nbsp;
                                    <asp:LinkButton ID="lbtnDel" runat="server" CommandName="del" CommandArgument='<%#Eval("Id") %>' OnClientClick="return confirm('您确定要删除吗？')" ToolTip="删除"><img src="images/icon_delete.gif" alt="删除" border="0" align="absmiddle" />删除</asp:LinkButton>
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
