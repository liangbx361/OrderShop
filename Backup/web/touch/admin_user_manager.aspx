<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin_user_manager.aspx.cs" Inherits="web.touch.admin_user_manager" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>管理员列表</title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link href="css/thickbox.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/Common.js" type="text/javascript"></script>
    <script src="js/thickbox.jquery.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="mframe">
        <table width="98%" align="center" cellspacing="0" cellpadding="0">
            <tr>
                <td class="tl"></td>
                <td class="tm"><span class="tt">管理员列表</span></td>
                <td class="tr"></td>
            </tr>
        </table>
        <table width="98%" align="center" cellspacing="0" cellpadding="0">
            <tr>
                <td class="ml"></td>
                <td class="mm">
                    <div style="padding:5px 0px 5px 0px;">
                        <a href="admin_user_AE.aspx?keepThis=true&TB_iframe=true&height=300&width=500" title="添加管理员" class="fLink thickbox">添 加</a>
                    </div>
                    <asp:DataGrid ID="myGrid" runat="server" AutoGenerateColumns="False" CssClass="grid" border="0" align="center" BorderColor="#C6DAE5"
                        Width="100%" CellPadding="6" CellSpacing="0" OnItemCommand="myGrid_ItemCommand"
                        OnItemCreated="myGrid_ItemCreated" OnItemDataBound="myGrid_ItemDataBound">
                        <HeaderStyle CssClass="gridHead" />
                        <ItemStyle CssClass="tdbg" />
                        <Columns>
                            <asp:BoundColumn DataField="id" Visible="False"></asp:BoundColumn>
                            <asp:TemplateColumn>
                                <HeaderStyle Width="2%" />
                                <HeaderTemplate>
                                    <input type="checkbox" name="chkall" id="chkall" onclick="chkGridViewCheckBox(this,'chkdg')" title="全选/取消" />
                                </HeaderTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkdg" runat="server" ToolTip="选中一行" />
                                </ItemTemplate>    
                            </asp:TemplateColumn>
                            <asp:TemplateColumn>
                                <HeaderStyle Width="7%" />
                                <HeaderTemplate>用户名</HeaderTemplate> 
                                <ItemStyle HorizontalAlign="Center" />  
                                <ItemTemplate>
                                    <%#Eval("username")%>
                                </ItemTemplate>    
                            </asp:TemplateColumn>
                            <asp:TemplateColumn>
                                <HeaderStyle Width="7%" />
                                <HeaderTemplate>登录IP</HeaderTemplate> 
                                <ItemStyle HorizontalAlign="Center" />  
                                <ItemTemplate>
                                    <%#Eval("loginip")%>
                                </ItemTemplate>    
                            </asp:TemplateColumn>
                            <asp:TemplateColumn>
                                <HeaderStyle Width="7%" />
                                <HeaderTemplate>上次登录时间</HeaderTemplate> 
                                <ItemStyle HorizontalAlign="Center" />  
                                <ItemTemplate>
                                    <%#Eval("logintime") %>
                                </ItemTemplate>    
                            </asp:TemplateColumn>
                            <asp:TemplateColumn>
                                <HeaderStyle Width="7%" />
                                <HeaderTemplate>添加日期</HeaderTemplate> 
                                <ItemStyle HorizontalAlign="Center" />  
                                <ItemTemplate>
                                    <%#Eval("addtime")%>
                                </ItemTemplate>    
                            </asp:TemplateColumn>       
                            <asp:TemplateColumn HeaderText="管理信息">
                                <HeaderStyle Width="7%" />
                                <HeaderTemplate>
                                    管理信息
                                </HeaderTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Literal ID="labIsSystem" runat="server" Text='<%#Eval("issystem")  %>' Visible="false"></asp:Literal>
                                    <asp:HyperLink ID="hylrole" runat="server" NavigateUrl='<%# "admin_roleRight_manager.aspx?id="+Eval("id")  %>'>权限配置</asp:HyperLink>&nbsp;&nbsp;
                                    <a href="admin_user_AE.aspx?id=<%#Eval("id") %>&keepThis=true&TB_iframe=true&height=300&width=500" title="修改管理员信息" class="thickbox"><img src="images/icon_edit.gif" border="0" alt="编辑" align="absmiddle" />编辑</a>&nbsp;&nbsp;
                                    <asp:LinkButton ID="lbtnDel" runat="server" CommandName="del" CommandArgument='<%#Eval("id") %>' OnClientClick="return confirm('您确定要删除吗？')" ToolTip="删除"><img src="images/icon_delete.gif" alt="删除" border="0" align="absmiddle" />删除</asp:LinkButton>
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
