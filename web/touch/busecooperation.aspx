<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="busecooperation.aspx.cs" Inherits="web.touch.busecooperation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>商家合作</title>
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
                <td class="tm"><span class="tt">商家合作管理</span></td>
                <td class="tr"></td>
            </tr>
        </table>
        <table width="98%" align="center" cellspacing="0" cellpadding="0">
            <tr>
                <td class="ml"></td>
                <td class="mm">
                    <div style="padding:5px 0px 5px 0px;">
                        <asp:LinkButton ID="lbtnDelAll" runat="server" OnClientClick="return confirm('您确定要删除吗？')" onclick="lbtnDelAll_Click" CssClass="fLink" Text="批量删除"></asp:LinkButton>&nbsp;  
                    </div>
                    <asp:DataGrid ID="myGrid" runat="server" AutoGenerateColumns="False" CssClass="grid" border="0" align="center" BorderColor="#C6DAE5"
                        Width="100%" CellPadding="6" CellSpacing="0" OnItemCommand="myGrid_ItemCommand"
                        OnItemCreated="myGrid_ItemCreated">
                        <HeaderStyle CssClass="gridHead" />
                        <ItemStyle CssClass="tdbg" />
                        <Columns>
                            <asp:BoundColumn DataField="Id" Visible="False"></asp:BoundColumn>
                            <asp:TemplateColumn>
                                <HeaderStyle Width="1%" />
                                <HeaderTemplate>
                                    <input type="checkbox" name="chkall" id="chkall" onclick="chkGridViewCheckBox(this,'chkdg')" title="全选/取消" />
                                </HeaderTemplate>
                                <ItemStyle HorizontalAlign="center"/>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkdg" runat="server" ToolTip="选中一行" />
                                </ItemTemplate>    
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="商家名称">
                                <HeaderStyle Width="3%" />
                                <ItemStyle HorizontalAlign="center"/>
                                <ItemTemplate>
                                    <%#Eval("ShopName")%>
                                </ItemTemplate>    
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="联系人">
                                <HeaderStyle Width="3%" />
                                <ItemStyle HorizontalAlign="center"/>
                                <ItemTemplate>
                                    <%#Eval("UserName")%>
                                </ItemTemplate>    
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="联系号码">
                                <HeaderStyle Width="3%" />
                                <ItemStyle HorizontalAlign="center"/>
                                <ItemTemplate>
                                    <%#Eval("Phone")%>
                                </ItemTemplate>    
                            </asp:TemplateColumn>
                            <asp:TemplateColumn>
                                <HeaderStyle Width="5%" />
                                <HeaderTemplate>商家地址</HeaderTemplate> 
                                <ItemStyle HorizontalAlign="center"/> 
                                <ItemTemplate>
                                    <%#Eval("Address")%>
                                </ItemTemplate>    
                            </asp:TemplateColumn>
                            <asp:TemplateColumn>
                                <HeaderStyle Width="3%" />
                                <HeaderTemplate>提交日期</HeaderTemplate> 
                                <ItemStyle HorizontalAlign="center"/> 
                                <ItemTemplate>
                                    <%#Eval("AddTime")%>
                                </ItemTemplate>    
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="管理信息">
                                <HeaderStyle Width="2%" />
                                <ItemStyle HorizontalAlign="center"/>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnDel" runat="server" CommandName="del" CommandArgument='<%#Eval("Id") %>' OnClientClick="return confirm('您确定要删除吗？')" ToolTip="删除"><img src="images/icon_delete.gif" alt="删除" border="0" align="absmiddle" />删除</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                        </Columns>
                    </asp:DataGrid>
                    <div class="pager">
                    <asp:AspNetPager ID="WebPager" runat="server" FirstPageText="首页" LastPageText="末页" NextPageText="下一页" PrevPageText="上一页"
                        AlwaysShow="false" ShowDisabledButtons="false" ShowPageIndexBox="Never" onpagechanged="WebPager_PageChanged" PageSize="20"></asp:AspNetPager>
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
