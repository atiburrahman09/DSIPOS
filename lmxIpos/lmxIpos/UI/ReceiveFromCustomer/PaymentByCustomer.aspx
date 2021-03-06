﻿<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true" EnableEventValidation="false"
    CodeBehind="PaymentByCustomer.aspx.cs" Inherits="lmxIpos.UI.ReceiveFromCustomer.PaymentByCustomer" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
  <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="true">
        <ContentTemplate>
            <div class="title-sitemap grid-12">
                <h1 class="grid-6">
                    <i>&#xf132;</i>Customer Payment<span>Customer Receivable Payment List</span></h1>
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
                        <h3 id="Header3" runat="server" class="widget-header-title">Customer Payment Form</h3>
                    </header>
                    <div class="widget-body no-padding">
                        <div class="widget-separator grid-12">
                            <div class="widget-separator no-border grid-3">
                                <div class="grid-12">
                                    <h5 class="typo">Account On</h5>
                                </div>
                                <div class="grid-11">
                                    <asp:DropDownList ID="drpdwnAccountOn" runat="server" OnSelectedIndexChanged="purchaseReturnFormDropdownList_SelectedIndexChanged"
                                        AutoPostBack="true">
                                        <asp:ListItem Value="SC">Sales Center</asp:ListItem>
                                        <asp:ListItem Value="WH">Warehouse</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">
                                    <asp:Label ID="wareHouseorSCLabel" runat="server" Text="Warehouse"></asp:Label>
                                </h5>
                                <asp:DropDownList ID="salesCenterDropDownList" runat="server" CssClass="form form-full"
                                    required="required">
                                </asp:DropDownList>
                            </div>
                            <div class="widget-separator no-border grid-4">
                                <div class="grid-12">
                                    <h5 class="typo">Customer ID</h5>
                                </div>
                                <div class="grid-11">
                                    <asp:DropDownList ID="customerIdDropDownList" AutoPostBack="True" required="required" CssClass="chosen-select" runat="server" OnSelectedIndexChanged="customerIdDropDownList_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <%--<div class="widget-separator no-border grid-4">
                                  <div class="grid-12">
                                    <h5 class="typo">&nbsp;</h5>
                                </div>
                                <asp:Button ID="receivableListButton" runat="server" Text="Get Receivable List" CssClass="btn btn-info"
                                    OnClick="receivableListButton_Click" />
                            </div>--%>
                        </div>
                        <div class=" grid-12">
                            <div class="widget-separator no-border grid-3">
                                <div class="grid-12">
                                    <h5 class="typo">Current Receivable:</h5>
                                </div>
                                <div class="grid-11">
                                    <asp:Label ID="currentReceivableLabel" CssClass="text-error bolder" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <div class="grid-12">
                                    <h5 class="typo">Amount:</h5>
                                </div>
                                <div class="grid-11">
                                    <asp:TextBox ID="amountTextBox" runat="server" Text="0.00" onfocus="this.select()"></asp:TextBox>
                                    <asp:CompareValidator ID="cmpVldCurrency" runat="server" ErrorMessage="Currency Only" ControlToValidate="amountTextBox"
                                        ValidationGroup="2" Type="Currency" Operator="DataTypeCheck" ForeColor="Red"
                                        Visible="True"> </asp:CompareValidator>
                                </div>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Payment Mode
                                </h5>
                                <asp:DropDownList ID="paymentModeDropDownList" required="required" runat="server" OnSelectedIndexChanged="paymentModeDropDownList_SelectedIndexChanged" AutoPostBack="True" CssClass="form form-full">
                                    
                                    <asp:ListItem>Cash</asp:ListItem>
                                    <asp:ListItem>Cheque</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Account Head
                                </h5>
                                <asp:DropDownList ID="accountHeadDropDownList" required="required" runat="server" CssClass="form form-full">
                                </asp:DropDownList>
                            </div>

                        </div>
                        <div class="widget-separator grid-12">
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Cheque Number
                                </h5>
                                <asp:TextBox ID="chequeNumberTextBox" runat="server" CssClass="cash-cheque form form-full"
                                    placeholder="Cheque Number"></asp:TextBox>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Cheque Date
                                </h5>
                                <div class="grid-12">
                                    <div class="grid-1">
                                        <i class="icon-calendar"></i>
                                    </div>
                                    <div class="grid-11">
                                        <asp:TextBox ID="chequeDateTextBox" CssClass="date-textbox cash-cheque form form-full"
                                            runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Bank
                                </h5>
                                <asp:TextBox ID="bankDropDownList" runat="server" CssClass="cash-cheque form form-full"
                                    placeholder="Bank"></asp:TextBox>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Bank Branch
                                </h5>
                                <asp:TextBox ID="bankBranchTextBox" runat="server" CssClass="cash-cheque form form-full"
                                    placeholder="Bank Branch"></asp:TextBox>
                            </div>


                        </div>
                        <div class="widget-separator grid-12 text-center">

                            <asp:Button ID="saveButton" ValidationGroup="2" runat="server" Text="Receive Payment"
                                CssClass="btn btn-submit btn-3d" OnClick="saveButton_Click" />

                        </div>
                        <div class="grid-12">
                            <div id="receivableListGridContainer">
                                <asp:GridView ID="receivableListGridView" runat="server" AutoGenerateColumns="false"
                                    CssClass="table table-hover gridView dataTable">
                                    <Columns>
                                        <asp:BoundField DataField="RecordDate" HeaderText="Record Date" />
                                        <asp:BoundField DataField="SalesRecordId" HeaderText="Record ID" />
                                        <asp:BoundField DataField="SalesCenterName" HeaderText="SC Name" />
                                        <asp:BoundField DataField="TotalAmount" HeaderText="Total Amount" />
                                        <asp:BoundField DataField="DiscountAmount" HeaderText="Discount" />
                                        <asp:BoundField DataField="TotalVATAmount" HeaderText="VAT Amount" />
                                        <asp:BoundField DataField="OthersAmount" HeaderText="Others Amount" />
                                        <asp:BoundField DataField="TotalReceivable" HeaderText="Total Receivable" />
                                        <asp:BoundField DataField="ReceivedAmount" HeaderText="Received Amount" />
                                        <asp:BoundField DataField="Due" HeaderText="Due Amount" />
                                        <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="allCheckBox" runat="server" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="selectCheckBox" runat="server" CssClass="clickCheckBox" />
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
            <asp:AsyncPostBackTrigger ControlID="customerIdDropDownList" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="saveButton" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="receivableListGridView" EventName="RowDataBound" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="scriptContent" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        function pageLoad(sender, args) {
            $("#receivableListGridView").dataTable({
                "bProcessing": true,
                "bStateSave": true,
                //"bRetrieve": true,
                //"bDestroy": true,
                "sPaginationType": "full_numbers",
                "aLengthMenu": [[10, 15, 20, 25, 50, -1], [10, 15, 20, 25, 50, "All"]],
                "aoColumnDefs": [{ 'bSortable': false, 'aTargets': [] }]
            });

            $("#receivableListButton_Click").click(function (e) {
                if (haveOverlay == 0) {
                    MyOverlayStart();
                }
            });
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
            var config = {
                '.chosen-select': {},
                '.chosen-select-deselect': { allow_single_deselect: true },
                '.chosen-select-no-single': { disable_search_threshold: 20 },
                '.chosen-select-no-results': { no_results_text: 'Oops, nothing found!' },
                '.chosen-select-width': { width: "96%" }
            }
            for (var selector in config) {
                $(selector).chosen(config[selector]);
            }
        }
    </script>
    <script type="text/javascript">
        $(function () {
            $(".clickProcessing").live("click", function () {
                if (haveOverlay == 0) {
                    MyOverlayStart();
                }
            });

            $("#saveButton").live("click", function (e) {
                if ($("#amountTextBox").val() > 0) {

                } else {
                    alert("Amount must be gather than 0");
                    e.preventDefault();
                }
            });
        });
    </script>
</asp:Content>
