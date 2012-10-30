<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrdersList.aspx.cs" Inherits="web.touch.OrdersList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title></title>
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
                <td class="tm"><span class="tt">订单管理</span></td>
                <td class="tr"></td>
            </tr>
        </table>
        <table width="98%" align="center" cellspacing="0" cellpadding="0">
            <tr>
                <td class="ml"></td>
                <td class="mm">
                    <div style="padding:5px 0;">
                        订单号：<input type="text" id="txtorderno" runat="server" class="inpu" />
                        电 话：<input type="text" id="txtmobile" runat="server" class="inpu" />
                        订单状态：<asp:DropDownList ID="ddl_orderstatus" runat="server">
                        <asp:ListItem Value="" Text="-请选择-"></asp:ListItem>
                        <asp:ListItem Value="0" Text="未处理"></asp:ListItem>
                        <asp:ListItem Value="1" Text="处理中"></asp:ListItem>
                        <asp:ListItem Value="2" Text="已完成"></asp:ListItem>
                        <asp:ListItem Value="3" Text="作废"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:LinkButton ID="btn_select" runat="server" OnClick="btn_Select_Click" CssClass="fLink" ToolTip="搜索" Text="  搜 索 "></asp:LinkButton>
                    </div>
	                <asp:DataGrid ID="myGrid" runat="server" ShowHeader="true" ShowFooter="false" AutoGenerateColumns="False" CssClass="grid" border="0" align="center" BorderColor="#C6DAE5"
                        Width="100%" CellPadding="6" CellSpacing="0" OnItemCommand="myGrid_ItemCommand" OnItemCreated="myGrid_ItemCreated" OnItemDataBound="myGrid_ItemDataBound">
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
                            <asp:TemplateColumn HeaderText="订单号">
                                <ItemStyle HorizontalAlign="center"/>
				                <HeaderStyle Width="3%"/>     
                                <ItemTemplate>
                                    <a href="OrderDetails.aspx?orderno=<%#Eval("OrderNo") %>&keepThis=true&TB_iframe=true" class="thickbox"><%#Eval("OrderNo")%></a>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="店 铺">
                                <ItemStyle HorizontalAlign="center"/>
				                <HeaderStyle Width="3%"/>     
                                <ItemTemplate>
                                    <%#Eval("ShopName")%>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="总 额">
                                <ItemStyle HorizontalAlign="center"/>
				                <HeaderStyle Width="2%"/> 
                                <ItemTemplate>
                                    <%#Eval("TotalPrice")%>
                                </ItemTemplate>    
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="联系人">
                                <ItemStyle HorizontalAlign="center"/>
				                <HeaderStyle Width="2%"/> 
                                <ItemTemplate>
                                    <%#Eval("UserName")%>
                                </ItemTemplate>    
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="电 话">
                                <ItemStyle HorizontalAlign="center"/>
				                <HeaderStyle Width="3%"/> 
                                <ItemTemplate>
                                    <%#Eval("UserTel")%>
                                </ItemTemplate>    
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="地 址">
                                <ItemStyle HorizontalAlign="center"/>
				                <HeaderStyle Width="3%"/> 
                                <ItemTemplate>
                                    <%#Eval("UserAddress")%>
                                </ItemTemplate>    
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="订单日期">
                                <ItemStyle HorizontalAlign="center"/>
				                <HeaderStyle Width="3%"/> 
                                <ItemTemplate>
                                    <%#Eval("AddTime")%>
                                </ItemTemplate>    
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="订单状态">
                                <ItemStyle HorizontalAlign="center"/>
				                <HeaderStyle Width="2%"/> 
                                <ItemTemplate>
                                    <%#ShopOrderStatus(Eval("OrderStatus"))%>
                                </ItemTemplate>    
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="管理信息">
                                <ItemStyle HorizontalAlign="center"/>
				                <HeaderStyle Width="3%"/> 
                                <ItemStyle HorizontalAlign="center"  />
                                <ItemTemplate>
                                    <asp:Literal ID="L_OrderStatus" Text='<%#Eval("OrderStatus") %>' Visible="false" runat="server"></asp:Literal>
                                    <asp:LinkButton ID="btnhandle" runat="server" Text="[处理]" CommandName="handle" CommandArgument='<%#Eval("Id") %>'></asp:LinkButton>
                                    <asp:LinkButton ID="btnfins" runat="server" Text="[完成]" CommandName="fins" CommandArgument='<%#Eval("Id") %>'></asp:LinkButton>
                                    <asp:LinkButton ID="btninvalid" runat="server" Text="[作废]" CommandName="invalid" CommandArgument='<%#Eval("Id") %>'></asp:LinkButton>
                                    <asp:LinkButton ID="lbtnDel" runat="server" CommandName="del" CommandArgument='<%#Eval("OrderNo") %>' OnClientClick="return confirm('您确定要删除吗？')" ToolTip="删除">[删除]</asp:LinkButton>
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
