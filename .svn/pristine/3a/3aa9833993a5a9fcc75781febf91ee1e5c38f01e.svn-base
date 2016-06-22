<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true"
    CodeBehind="PayVendorPayment.aspx.cs" Inherits="lmxIpos.UI.PaymentToVendor.PayVendorPayment" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <div class="title-sitemap grid-12">
        <h1 class="grid-6">
            <i>&#xf132;</i>Pay Vendor Payment<span>Paying Vendor Payment</span></h1>
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
                            System of Pay Vendor Payment</h3>
                    </header>
            <div class="widget-body no-padding">
                <div class="widget-separator no-padding grid-12">
                    <div class="widget-separator no-border grid-3">
                        <h5 class="typo">
                            Purchase Record ID</h5>
                        <asp:TextBox ID="purchaseRecordIdTextBox" runat="server" placeholder="Purchase Record ID"
                            CssClass="form form-full"></asp:TextBox>
                    </div>
                    <div class="widget-separator no-border grid-3" style="margin-top: 29px;">
                        <asp:Button ID="makePaymentButton" runat="server" Text="Make Payment" CssClass="btn btn-info"
                            OnClick="makePaymentButton_Click" />
                    </div>
                </div>
                <div class="widget-separator no-padding grid-12">
                    <div class="widget-separator grid-6">
                        <div class="grid-4">
                            Record ID & Date:
                        </div>
                        <div class="grid-8">
                            <asp:Label ID="recordIdLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                            <asp:Label ID="recordDateLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                        </div>
                    </div>
                    <div class="widget-separator grid-6">
                        <div class="grid-4">
                            Vendor ID & Name:
                        </div>
                        <div class="grid-8">
                            <asp:Label ID="vendorIdLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                            <asp:Label ID="vendorNameLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                        </div>
                    </div>
                    <div class="widget-separator grid-6">
                        <div class="grid-4">
                            Warehouse ID & Name:
                        </div>
                        <div class="grid-8">
                            <asp:Label ID="warehouseIdLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                            <asp:Label ID="warehouseNameLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
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
                            Total Amount:
                        </div>
                        <div class="grid-8">
                            <asp:Label ID="totalAmountLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                        </div>
                    </div>
                    <div class="widget-separator grid-6">
                        <div class="grid-4">
                            Transport Cost:
                        </div>
                        <div class="grid-8">
                            <asp:Label ID="transportCostLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                        </div>
                    </div>
                    <div class="widget-separator grid-6">
                        <div class="grid-4">
                            Total Payable:
                        </div>
                        <div class="grid-8">
                            <asp:Label ID="totalPayableLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                        </div>
                    </div>
                    <div class="widget-separator grid-6">
                        <div class="grid-4">
                            Total Received:
                        </div>
                        <div class="grid-8">
                            <asp:Label ID="totalReceivedLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                        </div>
                    </div>
                    <div class="widget-separator no-border grid-6">
                        <div class="grid-4">
                            Current Payable:
                        </div>
                        <div class="grid-8">
                            <asp:Label ID="currentPayableLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                        </div>
                    </div>
                    <div class="widget-separator no-border grid-6">
                        <div class="grid-4">
                            Amount:
                        </div>
                        <div class="grid-8">
                            <asp:TextBox ID="amountTextBox" runat="server" placeholder="0.00"></asp:TextBox>
                            <asp:CompareValidator ID="CompareValidator3" runat="server" ErrorMessage="*" ControlToValidate="amountTextBox"
                                ValidationGroup="2" Type="Currency" Operator="DataTypeCheck" ForeColor="Red"
                                Visible="true"> </asp:CompareValidator>
                        </div>
                    </div>
                </div>
                <div class="widget-separator grid-12">
                    <asp:Button ID="saveButton" runat="server" Text="Save" CssClass="btn btn-submit btn-3d"
                        OnClick="saveButton_Click" />
                </div>
                <div id="paymentPane" runat="server">
                    <div class="widget-separator no-border grid-12">
                        <div class="accordion" id="accordion2">
                            <div class="accordion-group">
                                <div class="accordion-heading">
                                    <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion2" href="#collapse1">
                                        Payment Details </a>
                                </div>
                                <div id="collapse1" class="accordion-body collapse in">
                                    <div class="accordion-inner">
                                        <div id="paymentDetailsGridContainer" class="container">
                                            <asp:GridView ID="paymentDetailsGridView" runat="server" AutoGenerateColumns="false"
                                                CssClass="table table-hover gridView">
                                                <Columns>
                                                    <asp:BoundField DataField="Serial" HeaderText="SN" />
                                                    <asp:BoundField DataField="ReceivePaymentDate" HeaderText="Payment Date" />
                                                    <asp:BoundField DataField="Amount" HeaderText="Amount" />
                                                    <asp:BoundField DataField="DueAmount" HeaderText="Due Amount" />
                                                    <asp:BoundField DataField="Status" HeaderText="Status" />
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="scriptContent" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        $(function () {
            $("#paymentDetailsGridView").dataTable({
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

            $("#paymentDetailsGridView_wrapper .row-fluid:nth-child(1)").css("display", "none");
        });
    </script>
</asp:Content>
