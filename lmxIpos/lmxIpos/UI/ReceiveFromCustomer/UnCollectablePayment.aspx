<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true" EnableEventValidation="false"
    CodeBehind="UnCollectablePayment.aspx.cs" Inherits="lmxIpos.UI.ReceiveFromCustomer.UnCollectablePayment" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="false">
        <ContentTemplate>
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
                        <div class="widget-separator no-padding grid-12">
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Sales Record ID:</h5>
                                <asp:TextBox ID="salesRecordIdTextBox" PlaceHolder="Sales Record Id" runat="server"></asp:TextBox>

                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">&nbsp;</h5>
                                <asp:Button ID="getSalesRecordButton" runat="server" Text="Get Sales Record" CssClass="btn btn-info"
                                    OnClick="getSalesRecordButton_Click" />
                            </div>
                            <div id="divSalesDuePay" runat="server" visible="False" class="widget-separator no-border grid-6">
                                <div class="grid-12">
                                    <h5 class="typo">Amount 
                                    </h5>
                                    <asp:TextBox ID="uncollectableAmountTextBox" runat="server"></asp:TextBox>
                                    <asp:Button ID="saveButton" runat="server" Text="Not Receivable Payment" CssClass="btn btn-submit btn-3d" OnClick="saveButton_Click" />
                                </div>
                            </div>
                        </div>

                        <div id="divSalesInformation" runat="server" visible="False" class="widget-separator no-border grid-12">
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
                                            <asp:Label ID="SalesPersonLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                        </div>
                                    </div>

                                    <div class="widget-separator grid-6">
                                        <div class="grid-4">
                                            Sales Center ID & Name:
                                        </div>
                                        <div class="grid-8">
                                            <asp:Label ID="salesCenterIdLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                            <asp:Label ID="salesCenterNameLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>

                                        </div>
                                    </div>

                                    <div class="widget-separator grid-6">
                                        <div class="grid-4">
                                            Customer ID & Name:
                                        </div>
                                        <div class="grid-8">
                                            <asp:Label ID="customerIdLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                            <asp:Label ID="customerNameLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>

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
                                            <asp:Label ID="totalAmountLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="widget-separator grid-6">
                                        <div class="grid-4">
                                            Discount:
                                        </div>
                                        <div class="grid-8">
                                            <asp:Label ID="discountAmountLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="widget-separator grid-6">
                                        <div class="grid-4">
                                            VAT (%):
                                        </div>
                                        <div class="grid-8">
                                            <asp:Label ID="vatPercentageLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="widget-separator grid-6">
                                        <div class="grid-4">
                                            Total VAT Amount:
                                        </div>
                                        <div class="grid-8">
                                            <asp:Label ID="totalVATAmountLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="widget-separator grid-6">
                                        <div class="grid-4">
                                            Receivable (at Sale):
                                        </div>
                                        <div class="grid-8">
                                            <asp:Label ID="totalReceivableLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="widget-separator grid-6">
                                        <div class="grid-4 text-success">
                                            Received Amount:
                                        </div>
                                        <div class="grid-8">
                                            <asp:Label ID="receivedAmountLabel" runat="server" Text="" CssClass="text-success bolder infoLabel"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="widget-separator grid-6">
                                        <div class="grid-4 text-error">
                                            Due Amount:
                                        </div>
                                        <div class="grid-8">
                                            <asp:Label ID="dueAmountLabel" runat="server" Text="" CssClass="text-error bolder infoLabel"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="widget-separator grid-6">
                                        <div class="grid-4 text-warning">
                                            Uncollected Amount:
                                        </div>
                                        <div class="grid-8">
                                            <asp:Label ID="lblUncollectedAmount" runat="server" Text="" CssClass="text-warning bolder infoLabel"></asp:Label>
                                        </div>
                                    </div>
                                    <%--<div class="widget-separator grid-6">
                                        <div class="grid-4">
                                            Status:
                                        </div>
                                        <div class="grid-8">
                                            <asp:Label ID="statusLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                        </div>
                                    </div>--%>
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
                                                <asp:BoundField DataField="VATPercentage" HeaderText="VAT(%)" />
                                                <asp:BoundField DataField="VATAmount" HeaderText="VAT Amount" />
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="salesRecordIdForViewHiddenField" runat="server" />
        </ContentTemplate>
        <Triggers>

            <asp:AsyncPostBackTrigger ControlID="getSalesRecordButton" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="saveButton" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="scriptContent" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        function pageLoad(sender, args) {
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

            $("#saveButton").live("click", function (e) {
                if ($("#uncollectableAmountTextBox").val() > 0) {

                } else {
                    alert("Amount must be gather than 0");
                    e.preventDefault();
                }
            });
        }
    </script>
</asp:Content>
