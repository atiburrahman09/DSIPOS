<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true"
    CodeBehind="PurchaseOrderCancelRequest.aspx.cs" Inherits="lmxIpos.UI.PurchaseOrder.PurchaseOrderCancelRequest" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
    <link href="/Content/Style/CSSPages/PurchaseOrderCancelRequest.css" rel="stylesheet"
        type="text/css" />
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <div id="body_content">
        <fieldset>
            <legend>Purchase Order Cancel Request</legend>
            <div id="msgbox" runat="server" visible="false" class="alert alert-error">
                <button type="button" class="close" data-dismiss="alert">
                    &times;</button>
                <h4>
                    <asp:Label ID="msgTitleLabel" runat="server" Text=""></asp:Label>
                </h4>
                <asp:Label ID="msgDetailLabel" runat="server" Text=""></asp:Label>
            </div>
            <table class="inputControlContainer">
                <tr>
                    <td>
                        <label>
                            Warehouse Name
                        </label>
                        <asp:DropDownList ID="warehouseDropDownList" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Button ID="pendingOrderListButton" runat="server" Text="Get Pending Order List"
                            CssClass="btn btn-info" OnClick="pendingOrderListButton_Click" />
                    </td>
                </tr>
            </table>
            <hr />
            <div id="pendingPurchaseOrderListGridContainer" class="container">
                <asp:GridView ID="pendingPurchaseOrderListGridView" runat="server" AutoGenerateColumns="false"
                    CssClass="table table-hover gridView">
                    <Columns>
                        <asp:BoundField DataField="PurchaseOrderId" HeaderText="PO ID" />
                        <asp:BoundField DataField="OrderDate" HeaderText="Order Date" />
                        <asp:BoundField DataField="PurchaseRequisitionId" HeaderText="PR ID" />
                        <asp:BoundField DataField="PurchaseRequisitionDate" HeaderText="PR Date" />
                        <%--<asp:BoundField DataField="WarehouseName" HeaderText="Warehouse Name" />--%>
                        <asp:BoundField DataField="VendorName" HeaderText="Vendor Name" />
                        <asp:BoundField DataField="Narration" HeaderText="Requisition Narration" />
                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:LinkButton ID="viewLinkButton" runat="server" CssClass="btn btn-mini btn-info"
                                    OnClick="viewLinkButton_Click">View</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:LinkButton ID="cancelRequestLinkButton" runat="server" CssClass="btn btn-mini btn-success"
                                    OnClick="cancelRequestLinkButton_Click" OnClientClick="return confirm('Are you sure you want to cancel the purchase order?');">Request to Cancel</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </fieldset>
    </div>
</asp:Content>
<asp:Content ID="scriptContent" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        $(function () {
            $("#warehouseDropDownList").rules("add", {
                required: true
            });

            $("#pendingPurchaseOrderListGridView").dataTable({
                "bProcessing": true,
                "sPaginationType": "full_numbers",
                "aLengthMenu": [[10, 15, 20, 25, 50, -1], [10, 15, 20, 25, 50, "All"]],
                "aoColumnDefs": [{ 'bSortable': false, 'aTargets': [6, 7]}]
            });
        });
    </script>
</asp:Content>
