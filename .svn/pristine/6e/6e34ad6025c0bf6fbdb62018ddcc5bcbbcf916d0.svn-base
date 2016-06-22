<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true" EnableEventValidation="false"
    CodeBehind="ApproveDebitVoucherCheque.aspx.cs" Inherits="lmxIpos.UI.AccUI.DebitVoucher.ApproveDebitVoucherCheque" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server" ID="UpdatePanel1">
        <ContentTemplate>
            <div class="title-sitemap grid-12">
                <h1 class="grid-6">
                    <i>&#xf132;</i>D.V. Cheque Approval List<span>Approval D.V. Cheque List</span></h1>
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
                        <h3 id="Header3" runat="server" class="widget-header-title">Debit Voucher Cheque Approval List of System
                        </h3>
                    </header>
                    <div class="widget-body no-padding">
                        <div class="widget-separator no-padding grid-12">
                            <div class="widget-separator no-border grid-3">
                                <div class="grid-12">
                                    <h5 class="typo">Account On</h5>
                                </div>
                                <div class="grid-11">
                                    <asp:DropDownList ID="drpdwnAccountOn" runat="server" OnSelectedIndexChanged="drpdwnAccountOn_SelectedIndexChanged"
                                        AutoPostBack="true">
                                        <asp:ListItem>Sales Center</asp:ListItem>
                                        <asp:ListItem>Warehouse</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <div class="grid-12">
                                    <h5 class="typo">
                                        <asp:Label runat="server" Text="Sales Center Name" ID="titleSalesCenterOrWarehouse"></asp:Label>
                                    </h5>
                                </div>
                                <div class="grid-11">
                                    <asp:DropDownList ID="drpdwnSalesCenterOrWarehouse" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="widget-separator no-border grid-4" style="margin-top: 27px;">
                                <asp:Button ID="GetListButton" runat="server" Text="Get Jurnal Voucher List" CssClass="btn btn-info"
                                    OnClick="GetListButton_Click" />
                            </div>
                        </div>
                        <div class="widget-separator grid-12">
                            <div id="voucherListGridContainer">
                                <asp:GridView ID="voucherListGridView" runat="server" AutoGenerateColumns="false"
                                    CssClass="table table-hover gridView">
                                    <Columns>
                                        <asp:BoundField DataField="JournalNumber" HeaderText="Journal" />
                                        <asp:BoundField DataField="TransactionDate" HeaderText="Date" />
                                        <asp:BoundField DataField="AccountHead" HeaderText="Account Head" />
                                        <asp:BoundField DataField="Amount" HeaderText="Amount" />
                                        <asp:BoundField DataField="CounterAccountHead" HeaderText="Counter Head" />
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="allCheckBox" runat="server" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="selectCheckBox" runat="server" CssClass="clickCheckBox" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="viewLinkButton" runat="server" CssClass="btn btn-mini btn-success viewLinkButton"
                                                    OnClientClick="return false;">View to...</asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                        <div class="widget-separator grid-12">
                            <asp:Button ID="approveButton" runat="server" Text="Approve Voucher(s)" CssClass="btn btn-success"
                                Enabled="false" OnClick="approveButton_Click" />
                            <asp:Button ID="rejectButton" runat="server" Text="Reject Voucher(s)" CssClass="btn btn-danger"
                                Enabled="false" OnClick="rejectButton_Click" />
                        </div>
                        <div id="viewDetailsModal" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
                            aria-hidden="true">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                    &times;</button>
                                <h3>Debit Voucher Cheque - Details
                                </h3>
                            </div>
                            <div class="modal-body">
                                <div id="loadingDiv">
                                </div>
                                <div id="contentContainer">
                                    <div class="grid-12">
                                        <div class="widget-separator grid-6">
                                            <div class="grid-12" style="background-color: #0ABFBC">
                                                Journal Number
                                            </div>
                                            <div class="grid-12">
                                                <asp:Label ID="journalNumberLabel" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>
                                        <div class="widget-separator grid-6">
                                            <div class="grid-12" style="background-color: #0ABFBC">
                                                Transaction Date
                                            </div>
                                            <div class="grid-12">
                                                <asp:Label ID="transactionDateLabel" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>
                                        <div class="widget-separator grid-6">
                                            <div class="grid-12" style="background-color: #0ABFBC">
                                                Auto Voucher Number
                                            </div>
                                            <div class="grid-12">
                                                <asp:Label ID="autoVoucherNumberLabel" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>
                                        <div class="widget-separator grid-6">
                                            <div class="grid-12" style="background-color: #0ABFBC">
                                                Manual Voucher Number
                                            </div>
                                            <div class="grid-12">
                                                <asp:Label ID="manualVoucherNumberLabel" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>
                                        <div class="widget-separator grid-6">
                                            <div class="grid-12" style="background-color: #0ABFBC">
                                                Account Head
                                            </div>
                                            <div class="grid-12">
                                                <asp:Label ID="accountHeadLabel" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>
                                        <div class="widget-separator grid-6">
                                            <div class="grid-12" style="background-color: #0ABFBC">
                                                Amount
                                            </div>
                                            <div class="grid-12">
                                                <asp:Label ID="amountLabel" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>
                                        <div class="widget-separator grid-6">
                                            <div class="grid-12">
                                                Counter Account Head
                                            </div>
                                            <div class="grid-12">
                                                <asp:Label ID="counterAccountHeadLabel" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>
                                        <div class="widget-separator grid-6">
                                            <div class="grid-12" style="background-color: #0ABFBC">
                                                Pay To/From Company
                                            </div>
                                            <div class="grid-12">
                                                <asp:Label ID="payToFromCompanyLabel" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>
                                        <div class="widget-separator grid-6">
                                            <div class="grid-12" style="background-color: #0ABFBC">
                                                Cheque Number
                                            </div>
                                            <div class="grid-12">
                                                <asp:Label ID="chequeNumberLabel" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>
                                        <div class="widget-separator grid-6">
                                            <div class="grid-12" style="background-color: #0ABFBC">
                                                Cheque Date
                                            </div>
                                            <div class="grid-12">
                                                <asp:Label ID="chequeDateLabel" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>
                                        <div class="widget-separator grid-6">
                                            <div class="grid-12" style="background-color: #0ABFBC">
                                                Bank
                                            </div>
                                            <div class="grid-12">
                                                <asp:Label ID="bankLabel" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>
                                        <div class="widget-separator grid-6">
                                            <div class="grid-12" style="background-color: #0ABFBC">
                                                Bank Branch
                                            </div>
                                            <div class="grid-12">
                                                <asp:Label ID="bankBranchLabel" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>
                                        <div class="widget-separator grid-6">
                                            <div class="grid-12" style="background-color: #0ABFBC">
                                                Description
                                            </div>
                                            <div class="grid-12">
                                                <asp:Label ID="descriptionLabel" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>
                                        <div class="widget-separator grid-6">
                                            <div class="grid-12" style="background-color: #0ABFBC">
                                                Status
                                            </div>
                                            <div class="grid-12">
                                                <asp:Label ID="statusLabel" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>
                                        <div class="widget-separator grid-6">
                                            <div class="grid-12" style="background-color: #0ABFBC">
                                                Narration
                                            </div>
                                            <div class="grid-12">
                                                <asp:Label ID="narrationLabel" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <asp:LinkButton ID="approveLinkButton" runat="server" CssClass="btn btn-success"
                                    OnClick="approveLinkButton_Click">Approve</asp:LinkButton>
                                <asp:LinkButton ID="rejectLinkButton" runat="server" CssClass="btn btn-danger" OnClick="rejectLinkButton_Click">Reject</asp:LinkButton>
                                <button class="btn btn-inverse" data-dismiss="modal" aria-hidden="true">
                                    Cancel</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="journalNumberForApproveHiddenField" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="scriptContent" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        function pageLoad(sender, args) {
            var checkedRowCount = 0;
            $(":checkbox").prop("autocomplete", "off");
            $('.modal-backdrop').remove();

            $("#voucherListGridView").dataTable({
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

            $("#voucherListGridView_wrapper .row-fluid:nth-child(1)").css("display", "none");

            var journalNumber;
            $(".viewLinkButton").click(function () {
                var row = $(this).parent().parent().index();
                var col = $(this).parent().index();
                journalNumber = $("#voucherListGridView").find("tr td:first-child").eq(row).text();

                $('#viewDetailsModal').modal();
                $("#contentContainer").hide();
                $("#approveLinkButton").hide();
                $("#rejectLinkButton").hide();
                $("#loadingDiv").show();
            });

            $("#viewDetailsModal").on("shown", function () {
                $.ajax({
                    type: "POST",
                    url: "/UI/AccUI/DebitVoucher/ApproveDebitVoucherCheque.aspx/GetDebitVoucherViewByJournal",
                    data: "{'journalNumber':'" + journalNumber + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        var obj = (new Function('return ' + data.d))();

                        $("#journalNumberLabel").text(obj.JournalNumber);
                        $("#transactionDateLabel").text(obj.TransactionDate);
                        $("#autoVoucherNumberLabel").text(obj.AutoVoucherNumber);
                        $("#manualVoucherNumberLabel").text(obj.ManualVoucherNumber);
                        $("#accountHeadLabel").text(obj.AccountHead);
                        $("#amountLabel").text(obj.Amount);
                        $("#counterAccountHeadLabel").text(obj.CounterAccountHead);

                        if (obj.Bank == null) {
                            $("#bankLabel").text("N/A");
                        }
                        else {
                            $("#bankLabel").text(obj.Bank);
                        }

                        $("#bankBranchLabel").text(obj.BankBranch);
                        $("#chequeNumberLabel").text(obj.ChequeNumber);
                        $("#chequeDateLabel").text(obj.ChequeDate);
                        $("#descriptionLabel").text(obj.Description);

                        if (obj.PayToFromCompany == null) {
                            $("#payToFromCompanyLabel").text("N/A");
                        }
                        else {
                            $("#payToFromCompanyLabel").text(obj.PayToFromCompany);
                        }

                        $("#narrationLabel").text(obj.Narration);
                        $("#statusLabel").text(obj.Status);

                        $("#loadingDiv").hide();
                        $("#contentContainer").show();
                        $("#approveLinkButton").show();
                        $("#rejectLinkButton").show();
                    }
                });
            });

            $("#allCheckBox").click(function () {
                if ($(this).is(":checked")) {
                    $(".clickCheckBox>#selectCheckBox").prop('checked', true);
                    checkedRowCount = $(".clickCheckBox").length;
                } else {
                    $(".clickCheckBox>#selectCheckBox").prop('checked', false);
                    checkedRowCount = 0;
                }
            });

            $(".clickCheckBox").click(function () {
                if ($(this).find("#selectCheckBox").is(":checked")) {
                    checkedRowCount++;
                    if (checkedRowCount == $(".clickCheckBox").length) {
                        $("#allCheckBox").prop('checked', true);
                    }
                } else {
                    checkedRowCount--;
                    $("#allCheckBox").prop('checked', false);

                    if (checkedRowCount < 1) {
                        checkedRowCount = 0;
                    }
                }
            });

            $("#approveLinkButton, #rejectLinkButton").click(function (e) {
                if (haveOverlay == 0) {
                    $("#journalNumberForApproveHiddenField").val($("#journalNumberLabel").text());
                    MyOverlayStart();
                }
            });

            $("#approveButton, #rejectButton").click(function (e) {
                if (checkedRowCount < 1) {
                    WarningAlert("Data Selection", "Select Voucher(s) to Approve or Reject.", "");
                    e.preventDefault();
                } else {
                    if (haveOverlay == 0) {
                        MyOverlayStart();
                    }
                }
            });
        }
    </script>
</asp:Content>
