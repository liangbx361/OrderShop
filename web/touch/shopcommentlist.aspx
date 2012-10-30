<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="shopcommentlist.aspx.cs" Inherits="web.touch.shopcommentlist" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title></title>
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
                <td class="tm"><span class="tt"><%=ShopName %>的评论管理</span></td>
                <td class="tr"></td>
            </tr>
        </table>
        <table width="98%" align="center" cellspacing="0" cellpadding="0">
            <tr>
                <td class="ml"></td>
                <td class="mm">
                    <div style="padding:5px 0px 5px 0px;">
                        <asp:LinkButton ID="btnCheck" runat="server" CssClass="fLink" Text="批量审核" onclick="btnCheck_Click"></asp:LinkButton>
                        <asp:LinkButton ID="btnUnCheck" runat="server" CssClass="fLink" Text="取消审核" onclick="btnUnCheck_Click"></asp:LinkButton>
                        <a href="shoplist.aspx" class="fLink">返回</a>
                    </div>
	                <asp:DataGrid ID="myGrid" runat="server" ShowHeader="true" ShowFooter="false" AutoGenerateColumns="False" CssClass="grid" border="0" align="center" BorderColor="#C6DAE5"
                        Width="100%" CellPadding="6" CellSpacing="0" OnItemCommand="myGrid_ItemCommand" OnItemCreated="myGrid_ItemCreated">
                        <HeaderStyle CssClass="gridHead" />
                        <ItemStyle CssClass="tdbg" />    
                        <Columns>
                            <asp:BoundColumn DataField="Id" HeaderText="ID" Visible="false"></asp:BoundColumn>
                            <asp:TemplateColumn>
                                <HeaderTemplate>
                                    <input type="checkbox" name="chkall" id="chkall" title="全选/取消" onclick="chkGridViewCheckBox(this,'chkdg')" />
                                </HeaderTemplate>
                                <ItemStyle HorizontalAlign="center"/>
				                <HeaderStyle Width="1%"/>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkdg" runat="server" ToolTip="选中一行" />
                                </ItemTemplate>    
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="用户名">
                                <ItemStyle HorizontalAlign="center"/>
				                <HeaderStyle Width="2%"/>     
                                <ItemTemplate>
                                    <%#Eval("UserName")%>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="总评分">
                                <ItemStyle HorizontalAlign="center"/>
				                <HeaderStyle Width="2%"/> 
                                <ItemTemplate>
                                    <%#Eval("TotalPoint")%>
                                </ItemTemplate>    
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="口味评分">
                                <ItemStyle HorizontalAlign="center"/>
				                <HeaderStyle Width="2%"/> 
                                <ItemTemplate>
                                    <%#Eval("TastePoint")%>
                                </ItemTemplate>    
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="环境评分">
                                <ItemStyle HorizontalAlign="center"/>
				                <HeaderStyle Width="2%"/> 
                                <ItemTemplate>
                                    <%#Eval("MilieuPoint")%> 元
                                </ItemTemplate>    
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="服务评分">
                                <ItemStyle HorizontalAlign="center"/>
				                <HeaderStyle Width="2%"/> 
                                <ItemTemplate>
                                    <%#Eval("ServicePoint")%>
                                </ItemTemplate>    
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="评价内容">
                                <ItemStyle HorizontalAlign="center"/>
				                <HeaderStyle Width="5%"/> 
                                <ItemTemplate>
                                    <%#Eval("CommentContent")%>
                                </ItemTemplate>    
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="状态">
                                <ItemStyle HorizontalAlign="center"/>
				                <HeaderStyle Width="2%"/> 
                                <ItemTemplate>
                                    <%#Eval("CheckStatus").Equals(1) ? "<font color='red'>未审核</font>" : "<font color='green'>已审核</font>"%>
                                </ItemTemplate>    
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="管理信息">
                                <ItemStyle HorizontalAlign="center"/>
				                <HeaderStyle Width="3%"/> 
                                <ItemStyle HorizontalAlign="center"  />
                                <ItemTemplate>
                                    <asp:LinkButton ID="ltbtnchk" runat="server" CommandName="chk" CommandArgument='<%#Eval("Id") %>' Text="审核"></asp:LinkButton>
                                    <asp:LinkButton ID="ltbtnunchk" runat="server" CommandName="unchk" CommandArgument='<%#Eval("Id") %>' Text="取消审核"></asp:LinkButton>
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
