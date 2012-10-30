<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShopList.aspx.cs" Inherits="web.touch.ShopList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>店铺管理</title>
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
                <td class="tm"><span class="tt">店铺列表</span></td>
                <td class="tr"></td>
            </tr>
        </table>
        <table width="98%" align="center" cellspacing="0" cellpadding="0">
            <tr>
                <td class="ml"></td>
                <td class="mm">
                    <div style="padding:5px 0px 5px 0px;">
                        店铺名称：<input type="text" id="txtshopname" runat="server" class="inpu" />
                        店铺类别：<asp:DropDownList ID="ddltype" runat="server"></asp:DropDownList>
                        <asp:LinkButton ID="btn_select" runat="server" OnClick="btn_Select_Click" CssClass="fLink" ToolTip="搜索" Text="  搜 索 "></asp:LinkButton>
                    </div>
                    <div style="padding:5px 0px 5px 0px;">
                        <a href="ShopAdd.aspx" title="添加" class="fLink">添 加</a>
                        <asp:LinkButton ID="lbtnDelAll" runat="server" CssClass="fLink" Text="批量删除" OnClientClick="return confirm('您确定要删除吗？')" onclick="btn_del_Click" ToolTip="批量删除"></asp:LinkButton>
                        <a href="javascript:location.replace(location.href)" class="fLink">刷 新</a>
                    </div>
                    <asp:DataGrid ID="myGrid" runat="server" AutoGenerateColumns="False"  CssClass="grid" border="0" align="center" BorderColor="#C6DAE5"
                    Width="100%" CellPadding="6" CellSpacing="0" OnItemCommand="myGrid_ItemCommand" OnItemCreated="myGrid_ItemCreated">
                    <HeaderStyle CssClass="gridHead" />
                    <ItemStyle CssClass="tdbg" />
                    <Columns>
                        <asp:BoundColumn DataField="ShopId" Visible="false"></asp:BoundColumn>
                        <asp:TemplateColumn>
                            <HeaderStyle Width="1%" />
                            <HeaderTemplate>
                                <input type="checkbox" name="chkall" id="chkall" onclick="chkGridViewCheckBox(this,'chkdg')" title="全选/取消" />
                            </HeaderTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:CheckBox ID="chkdg" runat="server" ToolTip="选中一行" />
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="店铺名称">
                            <HeaderStyle Width="4%" />
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                    <%#Eval("ShopName")%>
                                    <asp:HiddenField ID="hf_img" runat="server" Value='<%#Eval("ShopPic") %>' />
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="店铺类别">
                            <HeaderStyle Width="2%" />
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                    <%#GetShopType(Eval("ShopType"))%>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="配送时间">
                            <HeaderStyle Width="2%" />
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <%#Eval("SendTime")%>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="配送费">
                            <HeaderStyle Width="2%" />
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <%#Eval("SendPrice")%>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="起送费">
                            <HeaderStyle Width="2%" />
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <%#Eval("LimitPrice")%>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="营业时间">
                            <HeaderStyle Width="2%" />
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <%#Eval("OpenTime")%>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="电 话">
                            <HeaderStyle Width="2%" />
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <%#Eval("Phone")%>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="地 址">
                            <HeaderStyle Width="5%" />
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                                <%#Eval("Address")%>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="操 作">
                            <HeaderStyle Width="5%" />
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <a href="ProductTypeList.aspx?shopid=<%#Eval("ShopId") %>">菜品分类</a>
                                <a href="ShopProductList.aspx?shopid=<%#Eval("ShopId") %>">菜品管理</a>
                                <a href="shopcommentlist.aspx?shopid=<%#Eval("ShopId") %>">评论管理</a>
                                <a href="ShopArea.aspx?shopid=<%#Eval("ShopId") %>&keepThis=true&TB_iframe=true" class="thickbox">送餐地址</a>
                                <a title="编辑" href="ShopEdit.aspx?id=<%#Eval("ShopId") %>"><img src="images/icon_edit.gif" border="0" alt="编辑" align="absmiddle" />编辑</a>
                                <asp:LinkButton ID="btn_listdel" runat="server" ToolTip="删除" CommandName="del" CommandArgument='<%#Eval("ShopId") %>' OnClientClick="return confirm('您确定要删除吗？')"><img src="images/icon_delete.gif" alt="删除" border="0" align="absmiddle" />删除</asp:LinkButton>
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
