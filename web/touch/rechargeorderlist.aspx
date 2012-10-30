<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rechargeorderlist.aspx.cs" Inherits="web.touch.rechargeorderlist" %>

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
                <td class="tm"><span class="tt">充值订单管理</span></td>
                <td class="tr"></td>
            </tr>
        </table>
        <table width="98%" align="center" cellspacing="0" cellpadding="0">
            <tr>
                <td class="ml"></td>
                <td class="mm">
                    <div style="padding:5px 0;">
                        订单号：<input type="text" id="txtorderno" runat="server" class="inpu" />
                        用户名：<input type="text" id="txtusername" runat="server" class="inpu" />
                        充值金额：<input type="text" id="txtprice" runat="server" class="inpu" />
                        <asp:LinkButton ID="btn_select" runat="server" OnClick="btn_Select_Click" CssClass="fLink" ToolTip="搜索" Text="  搜 索 "></asp:LinkButton>
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
                            <asp:TemplateColumn HeaderText="订单号">
                                <ItemStyle HorizontalAlign="center"/>
				                <HeaderStyle Width="3%"/>     
                                <ItemTemplate>
                                    <%#Eval("OrderNo")%>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="用户名">
                                <ItemStyle HorizontalAlign="center"/>
				                <HeaderStyle Width="3%"/>     
                                <ItemTemplate>
                                    <%#GetUserName(Eval("userid"))%>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="支付宝交易号">
                                <ItemStyle HorizontalAlign="center"/>
				                <HeaderStyle Width="3%"/> 
                                <ItemTemplate>
                                    <%#Eval("TradeNo")%>
                                </ItemTemplate>    
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="充值方式">
                                <ItemStyle HorizontalAlign="center"/>
				                <HeaderStyle Width="3%"/> 
                                <ItemTemplate>
                                    <%#Eval("Payment")%>
                                </ItemTemplate>    
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="充值金额">
                                <ItemStyle HorizontalAlign="center"/>
				                <HeaderStyle Width="2%"/> 
                                <ItemTemplate>
                                    <%#Eval("OrderPrice")%> 元
                                </ItemTemplate>    
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="订单状态">
                                <ItemStyle HorizontalAlign="center"/>
				                <HeaderStyle Width="2%"/> 
                                <ItemTemplate>
                                    <%#Eval("OrderStatus").Equals(0)?"未完成":"已完成"%>
                                </ItemTemplate>    
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="充值日期">
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
                                    <asp:LinkButton ID="lbtnDel" runat="server" CommandName="del" CommandArgument='<%#Eval("OrderNo") %>' OnClientClick="return confirm('您确定要删除吗？')" ToolTip="删除"><img src="images/icon_delete.gif" alt="删除" border="0" align="absmiddle" />删除</asp:LinkButton>
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
