<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true"
    CodeBehind="ApprovedRetailSales.aspx.cs" Inherits="lmxIpos.UI.Sales.ApprovedRetailSales" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <div class="title-sitemap grid-12">
        <h1 class="grid-8">
            <i>&#xf132;</i>Sales Center Sales Record<span>Approved Sales Center Sales Record</span></h1>
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
                <h3 id="Header3" runat="server" class="widget-header-title">Sales Center Sales Record of
                    <asp:Label ID="idLabel" runat="server" Text=""></asp:Label></h3>
            </header>
            <div class="widget-body no-padding">

                <div class="widget-separator no-border grid-12">
                </div>
                <div class="widget-separator">
                    <h4>Sales Information</h4>
                </div>
                <div id="orderInfoContainer">
                    <div class="grid-12">
                        <div class="widget-separator grid-6">
                            <div class="grid-4">
                                Sales Record Date:
                            </div>
                            <div class="grid-8">
                                <asp:Label ID="recordDateLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                            </div>
                        </div>
                        <div class="widget-separator grid-6">
                            <div class="grid-4">
                                Sales Person:
                            </div>
                            <div class="grid-8">
                                <asp:Label ID="lblSalesPerson" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                            </div>
                        </div>
                        <%-- <div class="widget-separator grid-3">
                            <div class="grid-4">
                                Status:
                            </div>
                            <div class="grid-8">
                                <asp:Label ID="statusLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                            </div>
                        </div>--%>
                    </div>
                    <div class="grid-12">
                        <div class="widget-separator grid-6">
                            <div class="grid-4">
                                SC/Wh Name[ID] :
                            </div>
                            <div class="grid-8">
                                <asp:Label ID="salesCenterNameLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                [
                       
                                <asp:Label ID="salesCenterIdLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>]
                            </div>
                        </div>

                        <div class="widget-separator grid-6">
                            <div class="grid-4">
                                Customer Name [ID]:
                            </div>
                            <div class="grid-8">
                                <asp:Label ID="customerNameLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                [
              
                                <asp:Label ID="customerIdLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>]
                            </div>
                        </div>

                        <div class="widget-separator grid-6">
                            <div class="grid-4">
                                Customer Contact:
                            </div>
                            <div class="grid-8">
                                <asp:Label ID="customerContactLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                            </div>
                        </div>
                        <div class="widget-separator grid-6">
                            <div class="grid-4">
                                Customer Address:
                            </div>
                            <div class="grid-8">
                                <asp:Label ID="customerAddressLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="grid-12">
                        <div class="widget-separator grid-6">
                            <div class="grid-4">
                                Total Amount:
                            </div>
                            <div class="grid-8">
                                <asp:Label ID="totalAmountLabel" runat="server" Text="" CssClass="bold"></asp:Label>
                            </div>
                        </div>
                        <div class="widget-separator grid-6">
                            <div class="grid-4">
                                Service Charge [%]:
                            </div>
                            <div class="grid-8">
                                <asp:Label ID="serviceChargeLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                [<asp:Label ID="serviceChargeParLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>%]
                        
                            </div>
                        </div>

                        <div class="widget-separator grid-6">
                            <div class="grid-4">
                                Discount [%]:
                            </div>
                            <div class="grid-8">
                                <asp:Label ID="discountAmountLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                [ 
                                <asp:Label ID="DiscountParLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>%]
                            </div>
                        </div>
                        <%--   <div class="widget-separator grid-6">
                            <div class="grid-4">
                                VAT (%):
                            </div>
                            <div class="grid-8">
                                <asp:Label ID="vatPercentageLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                            </div>
                        </div>--%>
                        <%-- <div class="widget-separator grid-6">
                            <div class="grid-4">
                                Total VAT Amount:
                            </div>
                            <div class="grid-8">
                                <asp:Label ID="totalVATAmountLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                            </div>
                        </div>--%>

                        <div class="widget-separator grid-6">
                            <div class="grid-4">
                                Total Receivable:
                            </div>
                            <div class="grid-8">
                                <asp:Label ID="totalReceivableLabel" runat="server" Text="" CssClass="bold"></asp:Label>
                            </div>
                        </div>
                        <div class="widget-separator grid-6">
                            <div class="grid-4">
                                Received Amount:
                            </div>
                            <div class="grid-8">
                                <asp:Label ID="receivedAmountLabel" runat="server" Text="" CssClass="text-success bold"></asp:Label>
                            </div>
                        </div>
                        <div class="widget-separator grid-6">
                            <div class="grid-4">
                                Uncollected Amount:
                            </div>
                            <div class="grid-8">
                                <asp:Label ID="UncollectedAmountLabel" runat="server" Text="" CssClass="text-warning bold"></asp:Label>
                            </div>
                        </div>
                        <div class="widget-separator grid-6">
                            <div class="grid-4">
                                Added Service Charge:
                            </div>
                            <div class="grid-8">
                                <asp:Label ID="AddedServiceChargeLabel" runat="server" Text="" CssClass="text-success bold"></asp:Label>
                            </div>
                        </div>
                        <div class="widget-separator grid-6">
                            <div class="grid-4">
                                Credit Status:
                            </div>
                            <div class="grid-8">
                                <asp:Label ID="creditStatusLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                            </div>
                        </div>

                        <div class="widget-separator grid-12">
                            <div class="grid-4">
                                Others Sale [Amount]:
                            </div>
                            <div class="grid-8">
                                <asp:Label ID="OthersSaleLabel" runat="server" Text="" CssClass="text-success bold"></asp:Label>[<asp:Label ID="otherAmountLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>]
                            </div>
                        </div>

                    </div>
                    <div class="grid-12">
                        <div id="salesRecordProductListGridContainer">
                            <asp:GridView ID="salesRecordProductListGridView" runat="server" AutoGenerateColumns="false"
                                CssClass="table table-hover gridView">
                                <Columns>
                                    <asp:BoundField DataField="ProductId" HeaderText="Product ID" />
                                    <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                                    <asp:BoundField DataField="RatePerUnit" HeaderText="Rate Per Unit" />
                                    <asp:BoundField DataField="Amount" HeaderText="Amount" />
                                    <asp:BoundField DataField="VATPercentage" HeaderText="Discount(%)" />
                                    <asp:BoundField DataField="VATAmount" HeaderText="Discount Amount" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="salesRecordIdForViewHiddenField" runat="server" />
</asp:Content>
<asp:Content ID="scriptContent" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        $(function () {
            $("#salesRecordProductListGridView").dataTable({
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

            $("#salesRecordProductListGridView_wrapper .row-fluid:nth-child(1)").css("display", "none");
        });
    </script>
</asp:Content>
