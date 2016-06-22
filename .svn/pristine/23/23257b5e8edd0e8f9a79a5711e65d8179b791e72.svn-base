<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true"
    CodeBehind="PurchaseOrderDetail.aspx.cs" Inherits="lmxIpos.UI.PurchaseOrder.PurchaseOrderDetail" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
    <link href="/Content/Style/CSSPages/PurchaseOrderDetail.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <div id="body_content">
        <fieldset>
            <legend>Purchase Order [<asp:Label ID="idLabel" runat="server" Text=""></asp:Label>]</legend>
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
                            Order Date:
                            <asp:Label ID="orderDateLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                        </label>
                        <label>
                            PR ID, Date:
                            <asp:Label ID="prIDLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                            <asp:Label ID="prDateLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                        </label>
                    </td>
                    <td>
                        <label>
                            Warehouse ID & Name:
                            <asp:Label ID="warehouseIdLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                        </label>
                        <label>
                            <asp:Label ID="warehouseNameLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                        </label>
                    </td>
                    <td>
                        <label>
                            Vendor ID & Name:
                            <asp:Label ID="vendorIdLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                        </label>
                        <label>
                            <asp:Label ID="vendorNameLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                        </label>
                    </td>
                    <td>
                        <label>
                            Narration:
                            <asp:Label ID="narrationLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                        </label>
                        <label>
                            Status:
                            <asp:Label ID="statusLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                        </label>
                    </td>
                </tr>
            </table>
            <hr />
            <div id="purchaseOrderProductListGridContainer" class="container">
                <asp:GridView ID="purchaseOrderProductListGridView" runat="server" AutoGenerateColumns="false"
                    CssClass="table table-hover gridView">
                    <Columns>
                        <asp:BoundField DataField="ProductId" HeaderText="Product ID" />
                        <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                        <asp:BoundField DataField="RequisitionQuantityUnit" HeaderText="Reqi. Qty" />
                        <asp:BoundField DataField="QuantityUnit" HeaderText="Order Quantity" />
                        <asp:BoundField DataField="RequiredDate" HeaderText="Required Date" />
                        <asp:BoundField DataField="Narration" HeaderText="Narration" />
                    </Columns>
                </asp:GridView>
            </div>
        </fieldset>
    </div>
    <asp:HiddenField ID="purchaseOrderIdForViewHiddenField" runat="server" />
</asp:Content>
<asp:Content ID="scriptContent" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        $(function () {
            $("#purchaseOrderProductListGridView").dataTable({
                "bProcessing": true,
                "sPaginationType": "full_numbers",
                "aLengthMenu": [[10, 15, 20, 25, 50, -1], [10, 15, 20, 25, 50, "All"]],
                "iDisplayLength": -1,
                "bSort": true,
                //"aoColumnDefs": [{ 'bSortable': false, 'aTargets': []}],
                "bFilter": false,
                "bLengthChange": true,
                "bPaginate": false,
                "bInfo": true
            });

            $("#purchaseOrderProductListGridView_wrapper .row-fluid:nth-child(1)").css("display", "none");
        });
    </script>
</asp:Content>
