<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true"
    CodeBehind="TransferOrderCancelRequestList.aspx.cs" Inherits="lmxIpos.UI.ProductTransferOrder.TransferOrderCancelRequestList" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
    <link href="/Content/Style/CSSPages/ProductTransferOrderListAction.css" rel="stylesheet"
        type="text/css" />
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="true">
        <ContentTemplate>
            <div class="title-sitemap grid-12">
                <h1 class="grid-10">
                    <i>&#xf132;</i>Product Transfer Order Cancel Request List<span>Created Product Transfer
                        Order Cancel Request List</span></h1>
                <div class="sitemap grid-6">
                    <%--<ul>
                        <li><span>Acura</span><i>/</i></li>
                        <li><a href="Default.aspx">Dashboard</a></li>
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
                            Product Transfer Order Cancel Request List of System</h3>
                    </header>
                    <div class="widget-body no-padding">
                        <div class="widget-separator grid-12">
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">
                                    Transfer Description
                                </h5>
                                <asp:DropDownList ID="transferDescriptionDropDownList" runat="server">
                                    <asp:ListItem>All</asp:ListItem>
                                    <asp:ListItem>Product Requisition</asp:ListItem>
                                    <asp:ListItem>Transfer Requisition</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">
                                    Transfer Type (WH/SC~WH/SC)</h5>
                                <asp:DropDownList ID="transferTypeDropDownList" runat="server" AutoPostBack="true"
                                    OnSelectedIndexChanged="transferTypeDropDownList_SelectedIndexChanged">
                                    <asp:ListItem Value="All">All</asp:ListItem>
                                    <asp:ListItem Value="WH-WH">Warehouse to Warehouse</asp:ListItem>
                                    <asp:ListItem Value="WH-SC">Warehouse to Salse Center</asp:ListItem>
                                    <asp:ListItem Value="SC-SC">Salse Center to Salse Center</asp:ListItem>
                                    <asp:ListItem Value="SC-WH">Salse Center to Warehouse</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">
                                    Transfer From (WH/SC)
                                </h5>
                                <asp:DropDownList ID="transferFromDropDownList" runat="server">
                                </asp:DropDownList>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">
                                    Transfer To (WH/SC)</h5>
                                <asp:DropDownList ID="transferToDropDownList" runat="server">
                                </asp:DropDownList>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <asp:Button ID="cancelRequestListButton" runat="server" Text="Get Cancel Request List"
                                    CssClass="btn btn-info" OnClick="cancelRequestListButton_Click" />
                            </div>
                        </div>
                        <div class="widget-separator grid-12">
                            <div id="transferOrderListGridContainer">
                                <asp:GridView ID="transferOrderListGridView" runat="server" AutoGenerateColumns="false"
                                    CssClass="table table-hover gridView">
                                    <Columns>
                                        <asp:BoundField DataField="TransferOrderId" HeaderText="Transfer Order ID" />
                                        <asp:BoundField DataField="OrderDate" HeaderText="Transfer Order Date" />
                                        <asp:BoundField DataField="RequisitionId" HeaderText="Requisition ID" />
                                        <asp:BoundField DataField="RequisitionDate" HeaderText="Requisition Date" />
                                        <asp:BoundField DataField="TransferType" HeaderText="Transfer Type" />
                                        <asp:BoundField DataField="TransferFromName" HeaderText="Transfer From (WH/SC)" />
                                        <asp:BoundField DataField="TransferToName" HeaderText="Transfer To (WH/SC)" />
                                        <asp:BoundField DataField="Description" HeaderText="Transfer Description" />
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="viewLinkButton" runat="server" CssClass="btn btn-mini btn-info"
                                                    OnClick="viewLinkButton_Click">View</asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="cancelRequestListButton" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="transferOrderListGridView" EventName="RowDataBound" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="scriptContent" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        $(function () {
            $("#transferDescriptionDropDownList").rules("add", {
                required: true
            });

            $("#transferTypeDropDownList").rules("add", {
                required: true
            });

            $("#transferFromDropDownList").rules("add", {
                required: true
            });

            $("#transferToDropDownList").rules("add", {
                required: true
            });

            $("#transferOrderListGridView").dataTable({
                "bProcessing": true,
                "sPaginationType": "full_numbers",
                "aLengthMenu": [[10, 15, 20, 25, 50, -1], [10, 15, 20, 25, 50, "All"]],
                "aoColumnDefs": [{ 'bSortable': false, 'aTargets': [8]}]
            });
        });
    </script>
</asp:Content>
