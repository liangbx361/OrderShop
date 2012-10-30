<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShopUserList.aspx.cs" Inherits="web.touch.ShopUserList" %>

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
                <td class="tm"><span class="tt">商户会员管理</span></td>
                <td class="tr"></td>
            </tr>
        </table>
        <table width="98%" align="center" cellspacing="0" cellpadding="0">
            <tr>
                <td class="ml"></td>
                <td class="mm">
                    <div style="padding:0 10px 5px 10px;">
                        用户名<input type="text" id="txtusername" runat="server" style="width:100px;" class="inpu" />&nbsp;
                        店铺名<input type="text" id="txtshopname" runat="server" style="width:100px;" class="inpu" />&nbsp;
                        &nbsp;<asp:LinkButton ID="btn_select" runat="server" OnClick="btn_Select_Click" CssClass="fLink" ToolTip="搜索" Text="  搜 索 "></asp:LinkButton>
                    </div>
                    <div style="padding:5px 0px 5px 0px;">
                        <a href="ShopUserAdd.aspx" class="fLink">添 加</a>
                        <a href="javascript:location.replace(location.href)" class="fLink">刷 新</a>
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
				                <HeaderStyle Width="3%"/> 
                                <ItemTemplate>
                                    <%#Eval("UserName")%>
                                </ItemTemplate>    
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="店铺名称">
                                <ItemStyle HorizontalAlign="center"/>
				                <HeaderStyle Width="3%"/> 
                                <ItemTemplate>
                                    <%#GetShopName(Eval("shopid"))%>
                                </ItemTemplate>    
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="昵 称">
                                <ItemStyle HorizontalAlign="center"/>
				                <HeaderStyle Width="3%"/> 
                                <ItemTemplate>
                                    <%#Eval("NickName")%>
                                </ItemTemplate>    
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="性别">
                                <ItemStyle HorizontalAlign="center"/>
				                <HeaderStyle Width="2%"/> 
                                <ItemTemplate>
                                    <%#Eval("Gender").Equals(0) ? "男" : "女"%>
                                </ItemTemplate>    
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="手 机">
                                <ItemStyle HorizontalAlign="center"/>
				                <HeaderStyle Width="3%"/> 
                                <ItemTemplate>
                                    <%#Eval("Mobile")%>
                                </ItemTemplate>    
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="E-mail">
                                <ItemStyle HorizontalAlign="center"/>
				                <HeaderStyle Width="3%"/> 
                                <ItemTemplate>
                                    <%#Eval("Email")%>
                                </ItemTemplate>    
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="注册日期">
                                <ItemStyle HorizontalAlign="center"/>
				                <HeaderStyle Width="3%"/> 
                                <ItemTemplate>
                                    <%#Eval("AddTime")%>
                                </ItemTemplate>    
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="管理信息">
                                <ItemStyle HorizontalAlign="center"/>
				                <HeaderStyle Width="3%"/> 
                                <ItemStyle HorizontalAlign="center"  />
                                <ItemTemplate>
                                    <a href="ShopUserEdit.aspx?id=<%#Eval("Id") %>"><img src="images/icon_edit.gif" border="0" alt="编辑" align="absmiddle" />编辑</a>&nbsp;&nbsp;
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
