<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true"
    CodeBehind="CreatePurchase.aspx.cs" Inherits="lmxIpos.UI.PurchaseRecord.CreatePurchase" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <div class="title-sitemap grid-12">
        <h1 class="grid-6">
            <i>&#xf132;</i>Create Purchase<span>Creating Purchase</span></h1>
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
                    </div>
                <h3 id="Header3" runat="server" class="widget-header-title">
                    Create Purchase of System</h3>
            </header>
            <div class="widget-body no-padding">
                <div class="widget-separator">
                    <h4>
                        Create Purchase Record</h4>
                </div>
                <div class="widget-separator grid-12">
                    <div class="widget-separator no-border grid-3">
                        <h5 class="typo">
                            Warehouse Name
                        </h5>
                        <asp:DropDownList ID="warehouseDropDownList" runat="server" CssClass="form form-full">
                        </asp:DropDownList>
                    </div>
                    <div class="widget-separator no-border grid-3">
                        <h5 class="typo">
                            Purchase Order ID
                        </h5>
                        <asp:TextBox ID="purchaseOrderIdTextBox" runat="server" CssClass="form form-full"></asp:TextBox>
                    </div>
                    <div class="widget-separator no-border grid-3">
                        <asp:Button ID="purchaseOrderDetailsButton" runat="server" Text="Get Purchase Order Details"
                            CssClass="btn btn-info" OnClick="purchaseOrderDetailsButton_Click" />
                    </div>
                </div>
                <div class="widget-separator no-border grid-12">
                </div>
                <div class="widget-separator">
                    <h4>
                        Purchase Information</h4>
                </div>
                <div id="orderInfoContainer" runat="server" visible="false">
                    <div class="widget-separator no-padding grid-12">
                        <div class="widget-separator grid-6">
                            <div class="grid-4">
                                PR ID, Date:
                            </div>
                            <div class="grid-8">
                                <asp:Label ID="prIDLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                <asp:Label ID="prDateLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                            </div>
                        </div>
                        <div class="widget-separator grid-6">
                            <div class="grid-4">
                                PO ID, Date:
                            </div>
                            <div class="grid-8">
                                <asp:Label ID="poIDLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                <asp:Label ID="poDateLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
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
                                Vendor ID & Name:
                            </div>
                            <div class="grid-8">
                                <asp:Label ID="vendorIdLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                <asp:Label ID="vendorNameLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                            </div>
                        </div>
                        <div class="widget-separator no-border grid-6">
                            <div class="grid-4">
                                Requisition Narration:
                            </div>
                            <div class="grid-8">
                                <asp:Label ID="requisitionNarrationLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="widget-separator no-border grid-12">
                    </div>
                    <div class="widget-separator no-padding no-border grid-12">
                        <div class="widget-separator grid-3">
                            <div class="grid-12">
                                <h5 class="typo">
                                    Vendor Order Date</h5>
                            </div>
                            <div class="grid-11">
                                <div class="grid-1">
                                    <i class="icon-calendar"></i>
                                </div>
                                <div class="grid-11">
                                    <asp:TextBox ID="vendorOrderDateTextBox" CssClass="date-textbox form form-full" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="widget-separator grid-3">
                            <h5 class="typo">
                                Vendor Order Number
                            </h5>
                            <asp:TextBox ID="vendorOrderNumberTextBox" runat="server" CssClass="form form-full"></asp:TextBox>
                        </div>
                        <div class="widget-separator grid-3">
                            <h5 class="typo">
                                Vendor Invoice Number
                            </h5>
                            <asp:TextBox ID="vendorInvoiceNumberTextBox" runat="server" CssClass="form form-full"></asp:TextBox>
                        </div>
                        <div class="widget-separator grid-3">
                            <div class="grid-12">
                                <h5 class="typo">
                                    Received Date</h5>
                            </div>
                            <div class="grid-11">
                                <div class="grid-1">
                                    <i class="icon-calendar"></i>
                                </div>
                                <div class="grid-11">
                                    <asp:TextBox ID="receivedDateTextBox" CssClass="date-textbox form form-full" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="widget-separator grid-3">
                            <h5 class="typo">
                                Transport Type
                            </h5>
                            <asp:DropDownList ID="transportTypeDropDownList" runat="server" CssClass="form form-full">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem>Air</asp:ListItem>
                                <asp:ListItem>Road</asp:ListItem>
                                <asp:ListItem>Ship</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="widget-separator grid-3">
                            <h5 class="typo">
                                Shipping Address
                            </h5>
                            <asp:TextBox ID="shippingAddressTextBox" runat="server" CssClass="form form-full"></asp:TextBox>
                        </div>
                        <div class="widget-separator grid-3">
                            <h5 class="typo">
                                Billing Address
                            </h5>
                            <asp:TextBox ID="billingAddressTextBox" runat="server" CssClass="form form-full"></asp:TextBox>
                        </div>
                        <div class="widget-separator grid-3">
                            <h5 class="typo">
                                Payment Mode
                            </h5>
                            <asp:DropDownList ID="paymentModeDropDownList" runat="server" CssClass="form form-full">
                                <asp:ListItem>Cash</asp:ListItem>
                                <asp:ListItem>Cheque</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="widget-separator no-border grid-3">
                            <h5 class="typo">
                                Account Head
                            </h5>
                            <asp:DropDownList ID="accountHeadDropDownList" runat="server" CssClass="form form-full"
                                required="required">
                            </asp:DropDownList>
                        </div>
                        <div class="widget-separator grid-3">
                            <h5 class="typo">
                                Cheque Number
                            </h5>
                            <asp:TextBox ID="chequeNumberTextBox" runat="server" CssClass="cash-cheque form form-full"></asp:TextBox>
                        </div>
                        <div class="widget-separator grid-3">
                            <div class="grid-12">
                                <h5 class="typo">
                                    Cheque Date
                                </h5>
                            </div>
                            <div class="grid-11">
                                <div class="grid-1">
                                    <i class="icon-calendar"></i>
                                </div>
                                <div class="grid-11">
                                    <asp:TextBox ID="chequeDateTextBox" CssClass="date-textbox cash-cheque form form-full"
                                        runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="widget-separator grid-3">
                            <h5 class="typo">
                                Bank
                            </h5>
                            <asp:DropDownList ID="bankDropDownList" runat="server" CssClass="cash-cheque form form-full">
                            </asp:DropDownList>
                        </div>
                        <div class="widget-separator grid-3">
                            <h5 class="typo">
                                Bank Branch
                            </h5>
                            <asp:TextBox ID="bankBranchTextBox" runat="server" CssClass="cash-cheque form form-full"></asp:TextBox>
                        </div>
                        <div class="widget-separator grid-3">
                            <h5 class="typo">
                                LC Number
                            </h5>
                            <asp:TextBox ID="lcNumberTextBox" runat="server" CssClass="form form-full"></asp:TextBox>
                        </div>
                        <div class="widget-separator grid-6">
                            <h5 class="typo">
                                Narration
                            </h5>
                            <asp:TextBox ID="narrationTextBox" runat="server" CssClass="form form-full"></asp:TextBox>
                        </div>
                    </div>
                    <div class="widget-separator no-border grid-12">
                    </div>
                    <div class="widget-separator no-padding grid-12">
                        <div id="purchaseOrderProductListGridContainer">
                            <asp:GridView ID="purchaseOrderProductListGridView" runat="server" AutoGenerateColumns="false"
                                CssClass="table table-hover gridView">
                                <Columns>
                                    <asp:BoundField DataField="Barcode" HeaderText="Barcode" />
                                    <asp:BoundField DataField="ProductId" HeaderText="Product ID" />
                                    <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                                    <asp:BoundField DataField="ProductUnit" HeaderText="Unit" />
                                    <asp:BoundField DataField="QuantityUnit" HeaderText="Order Qty" />
                                    <asp:TemplateField HeaderText="Purchase Qty">
                                        <ItemTemplate>
                                            <asp:TextBox ID="purchaseQuantityTextBox" Width="80" CssClass="pQty-rpu-amt-cal"
                                                runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Rate Per Unit">
                                        <ItemTemplate>
                                            <asp:TextBox ID="ratePerUnitTextBox" Width="80" CssClass="pQty-rpu-amt-cal" runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Amount">
                                        <ItemTemplate>
                                            <asp:TextBox ID="amountTextBox" Width="80" CssClass="amt-cal" runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Unit Price">
                                        <ItemTemplate>
                                            <asp:TextBox ID="unitPriceTextBox" Width="80" CssClass="read-only" runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Narration">
                                        <ItemTemplate>
                                            <asp:TextBox ID="productNarrationTextBox" Width="80" runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                    <div class="widget-separator no-border grid-12">
                    </div>
                    <div class="widget-separator no-padding grid-12">
                        <div class="widget-separator no-border grid-3">
                            <h5 class="typo">
                                Total Amount
                            </h5>
                            <asp:TextBox ID="totalAmountTextBox" CssClass="read-only form form-full" runat="server"
                                placeholder="Total Amount"></asp:TextBox>
                        </div>
                        <div class="widget-separator no-border grid-3">
                            <h5 class="typo">
                                Discount Amount
                            </h5>
                            <asp:TextBox ID="discountTextBox" runat="server" CssClass="form form-full" AutoPostBack="true"
                                OnTextChanged="discountTextBox_TextChanged" placeholder="Discount"></asp:TextBox>
                        </div>
                        <div class="widget-separator no-border grid-3">
                            <h5 class="typo">
                                Total Payable
                            </h5>
                            <asp:TextBox ID="totalPayableTextBox" runat="server" CssClass="read-only form form-full"
                                placeholder=""></asp:TextBox>
                        </div>
                        <div class="widget-separator no-border grid-3">
                            <h5 class="typo">
                                Transport Cost
                            </h5>
                            <asp:TextBox ID="transportCostTextBox" runat="server" AutoPostBack="true" OnTextChanged="transportCostTextBox_TextChanged"
                                CssClass="form form-full" placeholder="Transport Cost"></asp:TextBox>
                        </div>
                        <div class="widget-separator no-border grid-3">
                            <h5 class="typo">
                                Paid Amount
                            </h5>
                            <asp:TextBox ID="paidAmountTextBox" onfocus="this.select()" runat="server" CssClass="form form-full"
                                placeholder="Paid Amount">0.00</asp:TextBox>
                        </div>
                    </div>
                    <div class="widget-separator no-border grid-12">
                        <asp:Button ID="saveButton" CssClass="btn btn-submit btn-3d" runat="server" Enabled="false"
                            Text="Save" OnClick="saveButton_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        $(function () {
            if ($("#paymentModeDropDownList option:selected").text() == "Cash") {
                $(".cash-cheque").attr("disabled", true);
            }

            $(".read-only").attr("ReadOnly", true);

            $("#paymentModeDropDownList").on("change", function () {
                if ($("#paymentModeDropDownList option:selected").text() == "Cash") {
                    $(".cash-cheque").attr("disabled", true);
                    //$(".cash-cheque").val("");
                } else {
                    $(".cash-cheque").removeAttr("disabled");
                }
            });

            var dateFormat = '<%= Session["DateFormatForDatePicker"] %>';
            $(".date-textbox").datepicker({ format: dateFormat });
            $(".date-textbox, .icon-calendar").click(function () {
                $(this).parent().find(".date-textbox").focus();
            });

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

            $(".pQty-rpu-amt-cal").on("change keyup", function () {
                var qty = +$(this).closest('tr').find("[id*=purchaseQuantityTextBox]").val();
                var rate = +$(this).closest('tr').find("[id*=ratePerUnitTextBox]").val();
                var amt = qty * rate;

                $(this).parent().parent().find("[id*=amountTextBox]").val(amt);
                TotalAmountCalculation();
                CalculateUnitPrice();

                //                if (!isNaN(+$("#totalAmountTextBox").val()) && !isNaN($("#vatTextBox").val())) {
                //                    $("#totalPayableTextBox").val(($("#totalAmountTextBox").val() * ($("#vatTextBox").val() / 100)) + +$("#totalAmountTextBox").val());
                //                }
            });

            $(".amt-cal").on("change keyup", function () {
                var qty = +$(this).closest('tr').find("[id*=purchaseQuantityTextBox]").val();
                var amt = +$(this).closest('tr').find("[id*=amountTextBox]").val();
                var rpu = amt / qty;

                $(this).parent().parent().find("[id*=ratePerUnitTextBox]").val(rpu);
                TotalAmountCalculation();
                CalculateUnitPrice();

                //                if (!isNaN(amt)) {
                //                    $("#totalAmountTextBox").val(tAmt + amt);
                //                }
            });

            //            $("#vatTextBox").on("change keyup", function () {
            //                if (!isNaN(+$("#totalAmountTextBox").val())) {
            //                    $("#totalPayableTextBox").val(($("#totalAmountTextBox").val() * ($("#vatTextBox").val() / 100)) + +$("#totalAmountTextBox").val());
            //                }
            //            });

            $("#discountTextBox").on("change keyup", function () {
                if (!isNaN(+$("#totalAmountTextBox").val())) {
                    $("#totalPayableTextBox").val($("#totalAmountTextBox").val() - +$("#discountTextBox").val());
                }
                //$("#transportCostTextBox").val("");
            });

            function TotalAmountCalculation() {
                var tAmt = 0;
                $("#purchaseOrderProductListGridView tr").each(function () {
                    if (!isNaN(+$(this).find("[id*=amountTextBox]").val())) {
                        tAmt = tAmt + +$(this).find("[id*=amountTextBox]").val();
                    }
                    //tAmt = tAmt + +$(this).find("[id*=amountTextBox]").val();
                    //alert($(this).find("[id*=amountTextBox]").val());
                });
                $("#totalAmountTextBox").val(tAmt);

                //Total Payble Calculation
                $("#totalPayableTextBox").val(tAmt);
                if (!isNaN(+$("#totalAmountTextBox").val())) {
                    $("#totalPayableTextBox").val($("#totalAmountTextBox").val() - +$("#discountTextBox").val());
                }
            }

            function CalculateUnitPrice() {
                if ($("#discountTextBox").val() == "") {
                    $("#discountTextBox").val("0");
                }

                if ($("#transportCostTextBox").val() == "") {
                    $("#transportCostTextBox").val("0");
                }

                var ratePerTaka = (+$("#transportCostTextBox").val() - +$("#discountTextBox").val()) / (+$("#totalAmountTextBox").val());

                $("#purchaseOrderProductListGridView tr").each(function () {
                    if (!isNaN(+$(this).find("[id*=amountTextBox]").val()) && !isNaN(+$(this).find("[id*=purchaseQuantityTextBox]").val())) {
                        var untp = ((ratePerTaka * +$(this).find("[id*=amountTextBox]").val()) + +$(this).find("[id*=amountTextBox]").val()) / (+$(this).find("[id*=purchaseQuantityTextBox]").val());
                        $(this).find("[id*=unitPriceTextBox]").val(untp);
                    }
                });
            }
        });
    </script>
</asp:Content>
