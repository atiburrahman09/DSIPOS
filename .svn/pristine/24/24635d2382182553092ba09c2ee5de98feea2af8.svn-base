<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true"
    CodeBehind="ChequeBookPages.aspx.cs" Inherits="lmxIpos.UI.AccUI.BankChequeBook.ChequeBookPages" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
    <link href="/Content/Style/CSSPages/ChequeBookPages.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
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
                            Cheque Book Entry Pages of <asp:Label ID="numberLabel" runat="server" Text=""></asp:Label></h3>
                    </header>
            <div class="widget-body no-padding">
                <div class="widget-separator no-padding no-border grid-12">
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
    <asp:HiddenField ID="chequeBookAutoRefNoForViewHiddenField" runat="server" />
</asp:Content>
<asp:Content ID="scriptContent" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        $(function () {
            $("#chequeBookPageListGridView").dataTable({
                "bProcessing": true,
                "sPaginationType": "full_numbers",
                "aLengthMenu": [[10, 15, 20, 25, 50, -1], [10, 15, 20, 25, 50, "All"]],
                "iDisplayLength": -1,
                "aoColumnDefs": [{ 'bSortable': false, 'aTargets': []}],
                "bFilter": false,
                "bLengthChange": true,
                "bPaginate": false,
                "bInfo": true
            });

            $("#chequeBookPageListGridView_wrapper .row-fluid:nth-child(1)").css("display", "none");
        });
    </script>
</asp:Content>
