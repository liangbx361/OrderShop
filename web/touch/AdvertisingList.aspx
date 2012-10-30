<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdvertisingList.aspx.cs" Inherits="web.touch.AdvertisingList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>广告管理</title> 
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/Common.js" type="text/javascript"></script>
    <style type="text/css">
#dhtmltooltip{
position: absolute;
width: 200px;
border: 2px dotted gray;
padding: 2px;
background-color: lightyellow;
visibility: hidden;
z-index: 100;
/*Remove below line to remove shadow. Below line should always appear last within this CSS*/
filter: progid:DXImageTransform.Microsoft.Shadow(color=#CCCCCC,direction=135);
}
</style>
</head>
<body>
<div id="dhtmltooltip"></div>
<script src="../common/admin_upfiles.js" type="text/javascript"></script>
    <form id="form1" runat="server">
    <div class="mframe">
        <table width="98%" align="center" cellspacing="0" cellpadding="0">
            <tr>
                <td class="tl"></td>
                <td class="tm"><span class="tt">广告管理</span></td>
                <td class="tr"></td>
            </tr>
        </table>
        <table width="98%" align="center" cellspacing="0" cellpadding="0">
            <tr>
                <td class="ml"></td>
                <td class="mm">
                    <div style="padding:5px 0px 5px 0px;">
                        <a href="Advertising_AE.aspx" title="添加" class="fLink">添 加</a>&nbsp; 
                        <asp:LinkButton ID="lbtnDelAll" runat="server" OnClientClick="return confirm('您确定要删除吗？')" onclick="lbtnDelAll_Click" ToolTip="批量删除" Text="批量删除" CssClass="fLink"></asp:LinkButton>&nbsp;  
                    </div>
                    <asp:DataGrid ID="myGrid" runat="server" AutoGenerateColumns="False" CssClass="grid" border="0" align="center" BorderColor="#C6DAE5"
                        Width="100%" CellPadding="6" CellSpacing="0" OnItemCommand="myGrid_ItemCommand"
                        OnItemCreated="myGrid_ItemCreated">
                        <HeaderStyle CssClass="gridHead" />
                        <ItemStyle CssClass="tdbg" />
                        <Columns>
                            <asp:BoundColumn DataField="Id" Visible="False"></asp:BoundColumn>
                            <asp:TemplateColumn>
                                <HeaderStyle Width="3%" />
                                <HeaderTemplate>
                                    <input type="checkbox" name="chkall" id="chkall" onclick="chkGridViewCheckBox(this,'chkdg')" title="全选/取消" />
                                </HeaderTemplate>
                                <ItemStyle HorizontalAlign="center"/>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkdg" runat="server" ToolTip="选中一行" />
                                </ItemTemplate>    
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="图 片">
                                <HeaderStyle Width="5%" />
                                <ItemStyle HorizontalAlign="center"/> 
                                <ItemTemplate>
                                    <a href="<%#"../"+Eval("AdvertPic")%>" target="_blank" onmouseover="dimgtip('<%#"../"+Eval("AdvertPic")%>');" onmouseout="hideddrivetip();"><img src='<%#"../"+Eval("AdvertPic")%>' width="50" height="30" border="0" /></a>
                                    <asp:HiddenField ID="hf_link_logo" runat="server" Value='<%#Eval("AdvertPic") %>' />
                                </ItemTemplate>    
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="名  称">
                                <HeaderStyle Width="5%" />
                                <ItemStyle HorizontalAlign="center"/>
                                <ItemTemplate>
                                    <%#Eval("AdvertName")%>
                                </ItemTemplate>    
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="链接地址">
                                <HeaderStyle Width="7%" />
                                <ItemStyle HorizontalAlign="center"/>
                                <ItemTemplate>
                                    <%#Eval("AdvertLink")%>
                                </ItemTemplate>    
                            </asp:TemplateColumn>
                            
                            <asp:TemplateColumn>
                                <HeaderStyle Width="3%" />
                                <HeaderTemplate>添加日期</HeaderTemplate> 
                                <ItemStyle HorizontalAlign="center"/> 
                                <ItemTemplate>
                                    <%#Eval("AddTime")%>
                                </ItemTemplate>    
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="管理信息">
                                <HeaderStyle Width="5%" />
                                <ItemStyle HorizontalAlign="center"/>
                                <ItemTemplate>
                                    <a title="编辑" href="<%#"Advertising_AE.aspx?id="+Eval("Id") %>"><img src="images/icon_edit.gif" border="0" alt="编辑" align="absmiddle" />编辑</a>&nbsp;&nbsp;
                                    <asp:LinkButton ID="lbtnDel" runat="server" CommandName="del" CommandArgument='<%#Eval("Id") %>' OnClientClick="return confirm('您确定要删除吗？')" ToolTip="删除"><img src="images/icon_delete.gif" alt="删除" border="0" align="absmiddle" />删除</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                        </Columns>
                    </asp:DataGrid>
                    <div class="pager">
                    <asp:AspNetPager ID="WebPager" runat="server" FirstPageText="首页" LastPageText="末页" NextPageText="下一页" PrevPageText="上一页"
                        AlwaysShow="false" ShowDisabledButtons="false" ShowPageIndexBox="Never" onpagechanged="WebPager_PageChanged" PageSize="10"></asp:AspNetPager>
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
