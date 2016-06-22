<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true"
    CodeBehind="ChequeUse.aspx.cs" Inherits="lmxIpos.UI.AccUI.BankChequeBook.ChequeUse" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
    <link href="/Content/Style/CSSPages/ChequeUse.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server" ID="UpdatePanel1">
        <ContentTemplate>
            <div class="title-sitemap grid-12">
                <h1 class="grid-6">
                    <i>&#xf132;</i>Cheque Book Entry Pages<span>Created Cheque Book Entry Pages</span></h1>
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
                            Cheque Book Entry Pages of <asp:Label ID="Label3" runat="server" Text=""></asp:Label></h3>
                    </header>
                    <div class="widget-body no-padding">
                        <div class="widget-separator no-padding grid-12">
                            <div class="widget-separator" style="margin-top: 5px;">
                                <h4>
                                    Cheque Use</h4>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">
                                    Bank Account Head
                                </h5>
                                <asp:DropDownList ID="bankAccountHeadDropDownList" runat="server" CssClass="form form-full">
                                </asp:DropDownList>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">
                                    Auto Ref. No.
                                </h5>
                                <asp:TextBox ID="autoRefNoTextBox" runat="server" CssClass="form form-full"></asp:TextBox>
                            </div>
                            <div class="widget-separator no-border grid-3" style="margin-top: 29px;">
                                <asp:Button ID="chequeBookEntryButton" runat="server" Text="Get Cheque Book Entry"
                                    CssClass="btn btn-info" OnClick="chequeBookEntryButton_Click" />
                            </div>
                        </div>
                        <div id="chequeBookEntry" runat="server">
                            <div class="widget-separator no-border grid-12">
                            </div>
                            <div class="widget-separator">
                                <h4>
                                    Cheque Book Entry of
                                    <asp:Label ID="numberLabel" runat="server" Text=""></asp:Label></h4>
                            </div>
                            <div class="grid-12">
                                <div class="widget-separator grid-6">
                                    <div class="grid-4">
                                        Bank Account Head:
                                    </div>
                                    <div class="grid-8">
                                        <asp:Label ID="bankAccountHeadLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                    </div>
                                </div>
                                <div class="widget-separator grid-6">
                                    <div class="grid-4">
                                        Cheque Book Ref. No.:
                                    </div>
                                    <div class="grid-8">
                                        <asp:Label ID="chequeBookRefNoLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                    </div>
                                </div>
                                <div class="widget-separator grid-6">
                                    <div class="grid-4">
                                        Start Page No.:
                                    </div>
                                    <div class="grid-8">
                                        <asp:Label ID="startPageNoLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                    </div>
                                </div>
                                <div class="widget-separator grid-6">
                                    <div class="grid-4">
                                        End Page No.:
                                    </div>
                                    <div class="grid-8">
                                        <asp:Label ID="endPageNoLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                    </div>
                                </div>
                                <div class="widget-separator grid-6">
                                    <div class="grid-4">
                                        Entry Date:
                                    </div>
                                    <div class="grid-8">
                                        <asp:Label ID="entryDateLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
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
                            </div>
                            <div class="widget-separator no-border grid-12">
                                <div id="chequeBookPageListGridContainer">
                                    <asp:GridView ID="chequeBookPageListGridView" runat="server" AutoGenerateColumns="false"
                                        CssClass="table table-hover gridView">
                                        <Columns>
                                            <asp:BoundField DataField="SN" HeaderText="SN" />
                                            <asp:BoundField DataField="ChequeNo" HeaderText="Cheque No." />
                                            <asp:BoundField DataField="Status" HeaderText="Status" />
                                            <asp:TemplateField HeaderText="Used Date">
                                                <ItemTemplate>
                                                    <i class="icon-calendar"></i>
                                                    <asp:TextBox ID="usedDateTextBox" runat="server" CssClass="date-textbox gridTextBox"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Used Voucher No.">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="usedVoucherNoTextBox" runat="server" CssClass="gridTextBox"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Used Journal No.">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="usedJournalNoTextBox" runat="server" CssClass="gridTextBox"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Used Narration">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="usedNarrationTextBox" runat="server" CssClass="gridTextBox"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="useLinkButton" runat="server" CssClass="btn btn-mini btn-warning clickProcessing"
                                                        OnClick="useLinkButton_Click">Use</asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="scriptContent" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        function pageLoad(sender, args) {
            $(".gridTextBox").prop("autocomplete", "off");

            $(".datepicker").remove();
            var dateFormat = '<%= Session["DateFormatForDatePicker"] %>';
            $(".date-textbox").datepicker({ format: dateFormat });
            $(".date-textbox, .icon-calendar").click(function () {
                $(this).parent().find(".date-textbox").focus();
            });

            $("#bankAccountHeadDropDownList").live("change", function (e) {
                $('#autoRefNoTextBox').val("");
                $('#autoRefNoTextBox').unbind('.autocomplete').autocomplete();
                var accId = $("#bankAccountHeadDropDownList option:selected").val();

                if (accId != "") {
                    $.ajax({
                        type: "POST",
                        url: "/AutoCompletePage.aspx/GetBankChequeBookAutoRefNosByAccountId",
                        data: "{'accountId':'" + accId + "'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (data) {
                            $("#autoRefNoTextBox").autocomplete(data.d.toString().split("\r\n"));
                        }
                    });
                }
            });

            $("#chequeBookPageListGridView").dataTable({
                "bProcessing": true,
                "sPaginationType": "full_numbers",
                "aLengthMenu": [[10, 15, 20, 25, 50, -1], [10, 15, 20, 25, 50, "All"]],
                "iDisplayLength": -1,
                "aoColumnDefs": [{ 'bSortable': false, 'aTargets': [6, 7]}],
                "bFilter": false,
                "bLengthChange": true,
                "bPaginate": false,
                "bInfo": true
            });

            $("#chequeBookPageListGridView_wrapper .row-fluid:nth-child(1)").css("display", "none");

            $("#chequeBookEntryButton").click(function (e) {
                $("#form1").validate().currentForm = $("#form1")[0];
                $("#bankAccountHeadDropDownList").rules("add", {
                    required: true
                });

                $("#autoRefNoTextBox").rules("add", {
                    required: true
                });

                if (haveOverlay == 0) {
                    $("#form1").valid();

                    if (haveOverlay == 1) {
                        return false;
                    } else {
                        MyOverlayStart();
                    }
                }
            });
        }
    </script>
    <script type="text/javascript">
        $(function () {
            $(".clickProcessing").live("click", function (e) {
                if (haveOverlay == 0) {

                    var col = $(this).parent().children().parent().index();
                    var row = $(this).parent().parent().index();
                    sn = $("#chequeBookPageListGridView").find("tr td:nth-child(1)").eq(row).text();
                    usedDate = $("#chequeBookPageListGridView").find("tr td:nth-child(4) #usedDateTextBox").eq(row).val();
                    usedVoucherNo = $("#chequeBookPageListGridView").find("tr td:nth-child(5) #usedVoucherNoTextBox").eq(row).val();
                    usedJournalNo = $("#chequeBookPageListGridView").find("tr td:nth-child(6) #usedJournalNoTextBox").eq(row).val();
                    usedNarration = $("#chequeBookPageListGridView").find("tr td:nth-child(7) #usedNarrationTextBox").eq(row).val();

                    var id = $(this).attr("id");
                    var str = $(this).attr("href");
                    var arr = str.split("'");
                    var msg = "";

                    if (id == "useLinkButton") {
                        msg = "Are you sure you want to <span class='actionTopic'>use</span> this cheque?";
                    }

                    ConfirmProcess(msg, function () {
                        if (usedDate == "") {
                            $("#chequeBookPageListGridView").find("tr td:nth-child(4) #usedDateTextBox").eq(row).addClass("error");
                        }
                        if (usedVoucherNo == "") {
                            $("#chequeBookPageListGridView").find("tr td:nth-child(5) #usedVoucherNoTextBox").eq(row).addClass("error");
                        }
                        if (usedJournalNo == "") {
                            $("#chequeBookPageListGridView").find("tr td:nth-child(6) #usedJournalNoTextBox").eq(row).addClass("error");
                        }
                        if (usedNarration == "") {
                            $("#chequeBookPageListGridView").find("tr td:nth-child(7) #usedNarrationTextBox").eq(row).addClass("error");
                        }

                        if (usedDate == "" || usedVoucherNo == "" || usedJournalNo == "" || usedNarration == "") {
                            ValidationAlert("Follow the required field(s) to use the cheque.");
                        }
                        else {
                            MyOverlayStart();
                            __doPostBack(arr[1], '');
                        }
                    }, function () {

                    });

                    e.preventDefault();
                }
            });
        });
    </script>
</asp:Content>
