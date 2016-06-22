<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true"
    CodeBehind="ChequeVoidList.aspx.cs" Inherits="lmxIpos.UI.AccUI.BankChequeBook.ChequeVoidList" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
    <link href="/Content/Style/CSSPages/ChequeVoidList.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server" ID="UpdatePanel1">
        <ContentTemplate>
            <div class="title-sitemap grid-12">
                <h1 class="grid-6">
                    <i>&#xf132;</i>Cheque Void List<span>Created Cheque Void List</span></h1>
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
                            Cheque Void List of System</h3>
                    </header>
                    <div class="widget-body no-padding">
                        <div class="widget-separator no-padding grid-12">
                            <div class="widget-separator no-border grid-3">
                                <div class="grid-12">
                                    <h5 class="typo">
                                        Date From</h5>
                                </div>
                                <div class="grid-11">
                                    <div class="grid-1">
                                        <i class="icon-calendar"></i>
                                    </div>
                                    <div class="grid-11">
                                        <asp:TextBox ID="fromDateTextBox" CssClass="date-textbox form form-full" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <div class="grid-12">
                                    <h5 class="typo">
                                        Date To</h5>
                                </div>
                                <div class="grid-11">
                                    <div class="grid-1">
                                        <i class="icon-calendar"></i>
                                    </div>
                                    <div class="grid-11">
                                        <asp:TextBox ID="toDateTextBox" CssClass="date-textbox form form-full" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="widget-separator no-border grid-4" style="margin-top:29px;">
                                <asp:Button ID="getVoidListButton" runat="server" Text="Get Void List" CssClass="btn btn-info"
                                    OnClick="getVoidListButton_Click" />
                                <asp:Button ID="getAllVoidListButton" runat="server" Text="Get All Void List" CssClass="btn btn-info"
                                    OnClick="getAllVoidListButton_Click" />
                            </div>
                            <div class="widget-separator no-border grid-12">
                                <div id="chequeVoidListGridContainer">
                                    <asp:GridView ID="chequeVoidListGridView" runat="server" AutoGenerateColumns="false"
                                        CssClass="table table-hover gridView">
                                        <Columns>
                                            <asp:BoundField DataField="AccountHead" HeaderText="Bank Account Head" />
                                            <asp:BoundField DataField="AutoRefNo" HeaderText="Auto Ref. No." />
                                            <asp:BoundField DataField="ChequeNo" HeaderText="Cheque No." />
                                            <asp:BoundField DataField="UsedDate" HeaderText="Used Date" />
                                            <asp:BoundField DataField="UsedVoucherNo" HeaderText="Used Voucher No." />
                                            <asp:BoundField DataField="VoidDate" HeaderText="Void Date" />
                                            <asp:BoundField DataField="VoidNarration" HeaderText="Void Narration" />
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="chequeBookAutoRefNoForViewHiddenField" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="scriptContent" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        function pageLoad(sender, args) {
            $(".datepicker").remove();
            var dateFormat = '<%= Session["DateFormatForDatePicker"] %>';
            $(".date-textbox").datepicker({ format: dateFormat });
            $(".date-textbox, .icon-calendar").click(function () {
                $(this).parent().find(".date-textbox").focus();
            });

            $("#chequeVoidListGridView").dataTable({
                "bProcessing": true,
                "bStateSave": true,
                //"bRetrieve": true,
                //"bDestroy": true,
                "sPaginationType": "full_numbers",
                "aLengthMenu": [[10, 15, 20, 25, 50, -1], [10, 15, 20, 25, 50, "All"]],
                "aoColumnDefs": [{ 'bSortable': false, 'aTargets': []}],
            });

            $("#getAllVoidListButton").click(function () {
                $("#form1").validate().currentForm = "";
                if (haveOverlay == 0) {
                    MyOverlayStart();
                }
            });

            $("#getVoidListButton").click(function (e) {
                $("#form1").validate().currentForm = $("#form1")[0];
                $("#fromDateTextBox").rules("add", {
                    required: true
                });

                $("#toDateTextBox").rules("add", {
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
</asp:Content>
