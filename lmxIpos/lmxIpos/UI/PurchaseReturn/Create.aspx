<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true"
    CodeBehind="Create.aspx.cs" Inherits="lmxIpos.UI.PurchaseReturn.Create" EnableEventValidation="false" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="true">
        <ContentTemplate>
            <div class="title-sitemap grid-12">
                <h1 class="grid-6">
                    <i>&#xf132;</i>Create Purchase Return<span>Creating Purchase Return</span></h1>
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
                            
                        </div>
                        <h3 id="Header3" runat="server" class="widget-header-title">Purchase Record of
                            <asp:Label ID="idLabel" runat="server" Text=""></asp:Label></h3>
                    </header>
                    <div class="widget-body no-padding">
                        <div class="widget-separator grid-12">
                            <div class="widget-separator no-border grid-3">
                                <asp:TextBox ID="purchesRecordIdTextBox" placeholder="Purcahse Record ID" required="required"
                                    CssClass="form form-full" runat="server"></asp:TextBox>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <asp:Button ID="getSalesDetailsButton" CssClass="btn btn-info" runat="server" OnClick="getPurchesDetailsButton_Click" Text="Get Purchase Details" />
                            </div>
                          <%--  <div class="widget-separator no-border grid-3">
                                <asp:TextBox ID="productTextBox" runat="server" CssClass="form form-full autoCompeleteOff"
                                    placeholder="Product By [Barcode, ID, Name]"></asp:TextBox>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <asp:Button ID="addProductButton" CssClass="btn btn-success" runat="server" Text="Add Product" />
                            </div>--%>
                        </div>
                        <div class="widget-separator no-border grid-12">
                        </div>
                        <div class="accordion" id="accordion2">
                            <div class="accordion-group">
                                <div class="accordion-heading">
                                    <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion2" href="#collapse1">Purchase Information Details </a>
                                </div>
                                <div id="collapse1" class="accordion-body collapse">
                                    <div class="accordion-inner" style="padding: 0;">
                                        <div id="orderInfoContainer">
                                            <div class="grid-12">
                                                <div class="widget-separator grid-6">
                                                    <div class="grid-4">
                                                        Purchase Record Date:
                                                    </div>
                                                    <div class="grid-8">
                                                        <asp:Label ID="recordDateLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="widget-separator grid-6">
                                                    <div class="grid-4">
                                                        Status:
                                                    </div>
                                                    <div class="grid-8">
                                                        <asp:Label ID="statusLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="widget-separator grid-6">
                                                    <div class="grid-4">
                                                        <asp:Label ID="salesCenterOrWareHouseIdLabel" runat="server" Text="Sales Center ID:"></asp:Label>

                                                    </div>
                                                    <div class="grid-8">
                                                        <asp:Label ID="salesCenterIdLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="widget-separator grid-6">
                                                    <div class="grid-4">
                                                        <asp:Label ID="salesCenterOrWareHouseNameLabel" runat="server" Text="Sales Center Name:"></asp:Label>

                                                    </div>
                                                    <div class="grid-8">
                                                        <asp:Label ID="salesCenterNameLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="widget-separator grid-6">
                                                    <div class="grid-4">
                                                        Vendor ID & Name:
                                                    </div>
                                                    <div class="grid-8">
                                                        <asp:Label ID="VendorIdLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                                        &nbsp;
                                                        <asp:Label ID="vendorNameLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="widget-separator grid-6">
                                                    <div class="grid-4">
                                                        Order & Receive Date:
                                                    </div>
                                                    <div class="grid-8">
                                                        <asp:Label ID="OderDatelabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                                        &nbsp;
                                                        <asp:Label ID="receiveDateLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="widget-separator grid-6">
                                                    <div class="grid-4">
                                                        Invoice Number:
                                                    </div>
                                                    <div class="grid-8">
                                                        <asp:Label ID="invoiceNumberLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                                    </div>
                                                </div>

                                                <div class="widget-separator grid-6">
                                                    <div class="grid-4">
                                                        Order Number:
                                                    </div>
                                                    <div class="grid-8">
                                                        <asp:Label ID="orderNumberLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
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
                                                        <asp:Label ID="totalpayableLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="widget-separator grid-6">
                                                    <div class="grid-4">
                                                        Paid Amount:
                                                    </div>
                                                    <div class="grid-8">
                                                        <asp:Label ID="paidAmountLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="widget-separator grid-6">
                                                    <div class="grid-4">
                                                        Naration:
                                                    </div>
                                                    <div class="grid-8">
                                                        <asp:Label ID="NarationLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="grid-12">
                                <div id="salesRecordProductListGridContainer">
                                    <asp:GridView ID="purchesRecordProductListGridView" runat="server" AutoGenerateColumns="false"
                                        CssClass="table table-hover gridView">
                                        <Columns>
                                            <asp:BoundField DataField="ProductId" HeaderText="Product ID" />
                                            <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                                            <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                                            <asp:BoundField DataField="RatePerUnit" HeaderText="Rate Per Unit" />
                                            <asp:BoundField DataField="Amount" HeaderText="Amount" />
                                             <%-- <asp:BoundField DataField="Amount" HeaderText="VAT(%)" />--%>
                                            <asp:BoundField DataField="ReturnedQuantity" HeaderText="Returned Qty" ItemStyle-Font-Bold="true"
                                                ItemStyle-BackColor="Yellow" />
                                            <asp:TemplateField HeaderText="Re. Quantity">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="returnQuantityTextBox" runat="server" Width="40" CssClass="oQty-amt-cal autoCompeleteOff"
                                                        Text="0"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Re. Amount">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="returnAmountTextBox" runat="server" Width="80" CssClass="read-only autoCompeleteOff"
                                                        Text="0"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                            <div class="grid-12">
                                <div class="widget-separator grid-4">
                                    <h5 class="typo">Due Amount:
                                    </h5>

                                    <asp:TextBox ID="salesDueAmountTextBox" CssClass="read-only" runat="server" placeholder="0.00"></asp:TextBox>

                                </div>
                                <div class="widget-separator grid-4">
                                    <h5 class="typo">Return Amount (-Discount):
                                    </h5>

                                    <asp:TextBox ID="totalReturnAmountTextBox" CssClass="read-only" runat="server" placeholder="0.00"></asp:TextBox>

                                </div>
                                <div class="widget-separator grid-4">
                                    <h5 class="typo">Return VAT:
                                    </h5>
                                    <div class="grid-8">
                                        <asp:TextBox ID="totalReturnVATAmountTextBox" CssClass="read-only" runat="server"
                                            placeholder="0.00"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="widget-separator no-border grid-12">
                                <asp:Button ID="receiveSalesReturnforAdjustButton" CssClass="btn btn-submit btn-3d" runat="server" OnClick="purchaseReturnButton_Click"
                                    Text="Purchase Return for Adjust Dues and Money Back" CommandArgument="Y" />
                                <asp:Button ID="receiveSalesReturnForMoneyBackButton" CssClass="btn btn-warning btn-3d" runat="server" CommandArgument="N"  OnClick="purchaseReturnButton_Click"
                                    Text="Purchase Return for Money Back Only" />
                            </div>
                        </div>
                    </div>
                    <asp:HiddenField ID="salesRecordIdForViewHiddenField" runat="server" />
                </div>
            </div>
        </ContentTemplate>
        <Triggers>

            <asp:AsyncPostBackTrigger ControlID="getSalesDetailsButton" EventName="Click" />
            <%--<asp:AsyncPostBackTrigger ControlID="addProductButton" EventName="Click" />--%>
            <asp:AsyncPostBackTrigger ControlID="purchesRecordProductListGridView" EventName="RowDataBound" />
            <asp:AsyncPostBackTrigger ControlID="receiveSalesReturnforAdjustButton" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="receiveSalesReturnForMoneyBackButton" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="scriptContent" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">

        function pageLoad(sender, args) {


            $("#purchesRecordProductListGridView").dataTable({
                "bProcessing": true,
                "sPaginationType": "full_numbers",
                "aLengthMenu": [[10, 15, 20, 25, 50, 100, -1], [10, 15, 20, 25, 50, 100, "All"]],
                "iDisplayLength": -1,
                "bSort": false,
                //"aoColumnDefs": [{ 'bSortable': false, 'aTargets': [5, 6]}],
                "bFilter": false,
                "bLengthChange": true,
                "bPaginate": false,
                "bInfo": false
            });

            $("#purchesRecordProductListGridView_wrapper .row-fluid:nth-child(1)").css("display", "none");

            function TotalAmountCalculation() {
                var tAmt = 0;
                var perUnitDiscount = 0;
                var totalVAT = 0;
                var vatPercentage = 0;//$("#vatPercentageLabel").text();

                $("#purchesRecordProductListGridView tr").each(function () {
                    if (!isNaN(+$(this).find("[id*=returnAmountTextBox]").val())) {
                        tAmt = tAmt + +$(this).find("[id*=returnAmountTextBox]").val();
                    }
                });

                perUnitDiscount = $("#discountAmountLabel").text() / $("#totalAmountLabel").text();
                tAmt = tAmt - tAmt * perUnitDiscount;
               // totalVAT = (tAmt * vatPercentage) / 100;
                //tAmt = tAmt + totalVAT;

                $("#totalReturnAmountTextBox").val(tAmt);
                $("#totalReturnVATAmountTextBox").val(totalVAT);
            }

            $(".oQty-amt-cal").on("change keyup", function () {
                var qty = $(this).parents().closest('tr').find('td:nth-child(3)').html();
                var rqty = +$(this).closest('tr').find("[id*=returnQuantityTextBox]").val();
                var rate = $(this).parents().closest('tr').find('td:nth-child(4)').html();
                var vat = 0;//$(this).parents().closest('tr').find('td:nth-child(6)').html();
                var returnedQty = $(this).parents().closest('tr').find('td:nth-child(6)').html();

                if ((qty - returnedQty) >= rqty) {

                } else {
                    $(this).closest('tr').find("[id*=returnQuantityTextBox]").val(0);
                }

                if (rqty > qty) {
                    rqty = qty;
                    $(this).closest('tr').find("[id*=returnQuantityTextBox]").val(qty);
                }

                var amt = rqty * rate;
               // var amt = amt + (amt * vat / 100);
                $(this).parent().parent().find("[id*=returnAmountTextBox]").val(amt);
                TotalAmountCalculation();
            });
        }
    </script>
</asp:Content>
