<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true"
    CodeBehind="ApprovedPurchase.aspx.cs" Inherits="lmxIpos.UI.PurchaseToWH.ApprovedPurchase" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="false">
        <ContentTemplate>
            <div class="title-sitemap grid-12">
                <h1 class="grid-8">
                    <i>&#xf132;</i>Warehouse Purchase Record<span>Approved Warehouse Purchase Record</span></h1>
                <div class="sitemap grid-6">
                    <%--  <ul>
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
                            
                        </div>
                        <h3 id="Header3" runat="server" class="widget-header-title">Warehouse Purchase Record of
                            <asp:Label ID="idLabel" runat="server" Text=""></asp:Label></h3>
                    </header>
                    <div class="widget-body no-padding">

                        <div class="widget-separator">
                            <h4 class="">Purchase Information
                            </h4>
                        </div>
                         <div id="orderInfoContainer">
                            <div class="grid-12">
                                <div class="widget-separator grid-6">
                                    <div class="grid-6">
                                        Purchase Record Date:
                                    </div>
                                    <div class="grid-6">
                                        <asp:Label ID="recordDateLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                    </div>
                                </div>
                                <div class="widget-separator grid-6">
                                    <div class="grid-6">
                                        Status:
                                    </div>
                                    <div class="grid-6">
                                        <asp:Label ID="statusLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="widget-separator no-padding grid-12">
                                <div class="widget-separator grid-6">
                                    <div class="grid-6">
                                        Warehouse ID & Name:
                                    </div>
                                    <div class="grid-6">
                                        <asp:Label ID="warehouseIdLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label> & <asp:Label ID="warehouseNameLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                    </div>
                                </div>
                              <%--  <div class="widget-separator grid-6">
                                    <div class="grid-4">
                                        Warehouse Name:
                                    </div>
                                    <div class="grid-8">
                                        <asp:Label ID="warehouseNameLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                    </div>
                                </div>--%>
                                <div class="widget-separator grid-6">
                                    <div class="grid-6">
                                        Vendor ID & Name:
                                    </div>
                                    <div class="grid-6">
                                        <asp:Label ID="vendorIdLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label> &  <asp:Label ID="vendorNameLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                    </div>
                                </div>
                                <%--<div class="widget-separator grid-6">
                                    <div class="grid-4">
                                        Vendor Name:
                                    </div>
                                    <div class="grid-8">
                                        <asp:Label ID="vendorNameLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                    </div>
                                </div>--%>
                                <div class="widget-separator grid-6">
                                    <div class="grid-6">
                                        Vendor Order Date:
                                    </div>
                                    <div class="grid-6">
                                        <asp:Label ID="vendorOrderDateLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                     
                                    </div>
                                </div>
                                 <div class="widget-separator grid-6">
                                    <div class="grid-6">
                                        Vendor Order Number:
                                    </div>
                                    <div class="grid-6">
                                       <asp:Label ID="vendorOrderNumberLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                    </div>
                                </div>
                                <div class="widget-separator grid-6">
                                    <div class="grid-6">
                                        Vendor Invoice Number:
                                    </div>
                                    <div class="grid-6">
                                        <asp:Label ID="vendorInvoiceNumberLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                    </div>
                                </div>
                                <div class="widget-separator grid-6">
                                    <div class="grid-6">
                                        Received Date:
                                    </div>
                                    <div class="grid-6">
                                        <asp:Label ID="receivedDateLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                    </div>
                                </div>
                                <%--<div class="widget-separator grid-6">
                                    <div class="grid-4">
                                        LC Number:
                                    </div>
                                    <div class="grid-8">
                                        <asp:Label ID="lcNumberLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                    </div>
                                </div>--%>
                               <%-- <div class="widget-separator grid-6">
                                    <div class="grid-4">
                                        Transport Type:
                                    </div>
                                    <div class="grid-8">
                                        <asp:Label ID="transportTypeLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                    </div>
                                </div>--%>
                                 <div class="widget-separator grid-6">
                                    <div class="grid-6">
                                        Narration:
                                    </div>
                                    <div class="grid-6">
                                        <asp:Label ID="narrationLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                    </div>
                                </div>
                                <div class="widget-separator grid-6">
                                    <div class="grid-6">
                                        Payment Mode:
                                    </div>
                                    <div class="grid-6">
                                        <asp:Label ID="paymentModeLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                    </div>
                                </div>
                               
                                <div class="widget-separator grid-6">
                                    <div class="grid-6">
                                        Bank/ Bank Branch:
                                    </div>
                                    <div class="grid-6">
                                        <asp:Label ID="bankLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label> /  <asp:Label ID="bankBranchLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                    </div>
                                </div>
                                <%--<div class="widget-separator grid-6">
                                    <div class="grid-4">
                                        Bank Branch:
                                    </div>
                                    <div class="grid-8">
                                        <asp:Label ID="bankBranchLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                    </div>
                                </div>--%>
                                <div class="widget-separator grid-6">
                                    <div class="grid-6">
                                        Cheque Number:
                                    </div>
                                    <div class="grid-6">
                                        <asp:Label ID="chequeNumberLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                    </div>
                                </div>
                                <div class="widget-separator grid-6">
                                    <div class="grid-6">
                                        Cheque Date:
                                    </div>
                                    <div class="grid-6">
                                        <asp:Label ID="chequeDateLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                    </div>
                                </div>
                                  <div class="widget-separator grid-6">
                                    <div class="grid-6">
                                        Created By:
                                    </div>
                                    <div class="grid-6">
                                        <asp:Label ID="CreatedByLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                    </div>
                                </div>
                               <%-- <div class="widget-separator grid-6">
                                    <div class="grid-4">
                                        Shipping Address:
                                    </div>
                                    <div class="grid-8">
                                        <asp:Label ID="shippingAddressLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                    </div>
                                </div>--%>
                               <%-- <div class="widget-separator no-border grid-6">
                                    <div class="grid-4">
                                        Billing Address:
                                    </div>
                                    <div class="grid-8">
                                        <asp:Label ID="billingAddressLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                    </div>
                                </div>--%>
                            </div>
                            <div class="grid-12">
                                <div id="purchaseOrderProductListGridContainer">
                                    <asp:GridView ID="purchaseOrderProductListGridView" runat="server" AutoGenerateColumns="false"
                                        CssClass="table table-hover gridView">
                                        <Columns>
                                            <asp:BoundField DataField="ProductId" HeaderText="Product ID" />
                                            <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                                            <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                                            <asp:BoundField DataField="RatePerUnit" HeaderText="Rate Per Unit" />
                                            <asp:BoundField DataField="Amount" HeaderText="Amount" />
                                            <asp:BoundField DataField="UnitPrice" HeaderText="Unit Price" />
                                            <%--   <asp:BoundField DataField="Narration" HeaderText="Narration" />--%>
                                            <asp:BoundField DataField="Status" HeaderText="Status" />
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                            <div class="grid-12">
                                <div class="widget-separator grid-4">
                                    <div class="grid-4">
                                        Total Amount:
                                    </div>
                                    <div class="grid-8">
                                        <asp:Label ID="totalAmountLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                    </div>
                                </div>
                                <div class="widget-separator grid-4">
                                    <div class="grid-4">
                                        Discount:
                                    </div>
                                    <div class="grid-8">
                                        <asp:Label ID="discountAmountLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                    </div>
                                </div>
                                <div class="widget-separator grid-4">
                                    <div class="grid-4">
                                        Total Payable:
                                    </div>
                                    <div class="grid-8">
                                        <asp:Label ID="totalPayableLabel" runat="server" Text="" CssClass="text-warning bolder"></asp:Label>
                                    </div>
                                </div>
                                <div class="widget-separator grid-4">
                                    <div class="grid-4">
                                        Transport Cost:
                                    </div>
                                    <div class="grid-8">
                                        <asp:Label ID="transportCostLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                    </div>
                                </div>
                                <div class="widget-separator grid-4">
                                    <div class="grid-4">
                                        Paid Amount:
                                    </div>
                                    <div class="grid-8">
                                        <asp:Label ID="paidAmountLabel" runat="server" Text="" CssClass="text-success bolder"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:HiddenField ID="purchaseRecordIdForViewHiddenField" runat="server" />
</asp:Content>
<asp:Content ID="scriptContent" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        $(function () {
            $("#purchaseOrderProductListGridView").dataTable({
                "bProcessing": true,
                "sPaginationType": "full_numbers",
                "aLengthMenu": [[10, 15, 20, 25, 50, 100, -1], [10, 15, 20, 25, 50, 100, "All"]],
                "iDisplayLength": -1,
                "bSort": false,
                //"aoColumnDefs": [{ 'bSortable': false, 'aTargets': [5, 6]}],
                "bFilter": false,
                "bLengthChange": true,
                "bPaginate": false,
                "bInfo": true
            });

            $("#purchaseOrderProductListGridView_wrapper .row-fluid:nth-child(1)").css("display", "none");
        });
    </script>
</asp:Content>
