<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true" EnableEventValidation="false"
    CodeBehind="warehose_stock.aspx.cs" Inherits="lmxIpos.UI.Warehouse.warehose_stock" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="True">
        <ContentTemplate>
            <div class="title-sitemap grid-12">
                <h1 class="grid-6">
                    <i>&#xf132;</i>Warehouse Stock<span>System Stock of Warehouse</span></h1>
                <div class="sitemap grid-6">
                    <%--<ul>
                        <li><span>IPOS</span><i>/</i></li>
                        <li><a href="/Default.aspx">Dashboard</a></li>
                    </ul>--%>
                </div>
            </div>
            <div class="data">
                <div id="msgbox" runat="server" visible="false" class="alert alert-error">
                    <button type="button" class="close" data-dismiss="alert">
                        &times;</button>
                    <h4>
                        <asp:Label ID="msgTitleLabel" runat="server" Text=""></asp:Label>
                    </h4>
                    <asp:Label ID="msgDetailLabel" runat="server" Text=""></asp:Label>
                </div>
                <div class="widget">
                    <header class="widget-header">
                        <div class="widget-header-icon">
                            </div>
                        <h3 id="Header3" runat="server" class="widget-header-title">
                            Warehouse Stock List</h3>
                    </header>
                    <div class="widget-body no-padding">
                        <div class="widget-separator no-padding grid-12">
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">
                                    Warehouse Name
                                </h5>
                                <asp:DropDownList ID="drpdwnWarehoseName" CssClass="form form-full" runat="server"
                                    AutoPostBack="True" OnSelectedIndexChanged="drpdwnWarehoseName_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                            <div id="divNotifyLimit" runat="server" class="widget-separator no-border pull-right grid-3">
                                <h5 class="typo">
                                    Stock Notification Limit
                                </h5>
                                <div class="input-append form form-full">
                                    <asp:TextBox ID="txtNotification" CssClass="input-mini " runat="server"></asp:TextBox>
                                    <asp:Button ID="btnNotificationLimit" OnClick="btnNotificationLimit_Click" CssClass="btn btn-warning"
                                        runat="server" Height="30px" Text="Save" />
                                </div>
                            </div>
                        </div>
                        <div class="grid-12">
                            <asp:GridView ID="gridviewwarehouseStock" runat="server" AutoGenerateColumns="false" OnRowDataBound="gridviewwarehouseStock_SelectedIndexChanged"
                                CssClass="table table-hover gridView">
                                <Columns>
                                    <asp:BoundField DataField="ProductId" HeaderText="Product ID" />
                                    <asp:BoundField DataField="ProductName" HeaderText="Name" />
                                    <asp:BoundField DataField="UnitPrice" HeaderText="Avg Cost" />
                                    <asp:BoundField DataField="LastUnitPrice" HeaderText="Last Unit Cost" />
                                    <asp:BoundField DataField="FreeQuantity" HeaderText="In Stock" />
                                    <%--<asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="viewLinkButton" runat="server" CssClass="btn btn-mini btn-info clickProcessing"
                                                OnClick="viewLinkButton_Click">View</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="drpdwnWarehoseName" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="gridviewwarehouseStock" EventName="RowDataBound" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        function pageLoad(sender, args) {
            $("#gridviewwarehouseStock").dataTable({
                "sPaginationType": "full_numbers",
                "aLengthMenu": [[10, 25, 50, -1], [10, 25, 50, "All"]],
                "bStateSave": true
            });
        }
    </script>
</asp:Content>
