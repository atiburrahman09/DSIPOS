<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true"
    CodeBehind="ApproveChequeBookEntry.aspx.cs" Inherits="lmxIpos.UI.AccUI.BankChequeBook.ApproveChequeBookEntry" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
    <link href="/Content/Style/CSSPages/ApproveChequeBookEntry.css" rel="stylesheet"
        type="text/css" />
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server" ID="UpdatePanel1">
        <ContentTemplate>
            <div class="title-sitemap grid-12">
                <h1 class="grid-7">
                    <i>&#xf132;</i>Cheque Book Entry Approval List<span>Created Cheque Approval List</span></h1>
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
                            Cheque Book Entry Approval List of System</h3>
                    </header>
                    <div class="widget-body no-padding">
                        <div class="widget-separator no-padding grid-12">
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">
                                    Bank Account Head
                                </h5>
                                <asp:DropDownList ID="bankAccountHeadDropDownList" runat="server" CssClass="form form-full">
                                </asp:DropDownList>
                            </div>
                            <div class="widget-separator no-border grid-3" style="margin-top: 28px;">
                                <asp:Button ID="pendingEntryListButton" runat="server" Text="Get Pending Entry List"
                                    CssClass="btn btn-info" OnClick="pendingEntryListButton_Click" />
                            </div>
                        </div>
                        <div class="widget-separator no-border grid-12">
                            <div id="chequeBookEntryListGridContainer">
                                <asp:GridView ID="chequeBookEntryListGridView" runat="server" AutoGenerateColumns="false"
                                    CssClass="table table-hover gridView">
                                    <Columns>
                                        <asp:BoundField DataField="EntryDate" HeaderText="Entry Date" />
                                        <asp:BoundField DataField="AccountHead" HeaderText="Bank Account Head" />
                                        <asp:BoundField DataField="ChequeBookRefNo" HeaderText="Cheque Book Ref." />
                                        <asp:BoundField DataField="AutoRefNo" HeaderText="Auto Ref." />
                                        <asp:BoundField DataField="StartPageNo" HeaderText="Start Page" />
                                        <asp:BoundField DataField="EndPageNo" HeaderText="End Page" />
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="approveLinkButton" runat="server" CssClass="btn btn-mini btn-success clickProcessing"
                                                    OnClick="approveLinkButton_Click">Approve</asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="rejectLinkButton" runat="server" CssClass="btn btn-mini btn-danger clickProcessing"
                                                    OnClick="rejectLinkButton_Click">Reject</asp:LinkButton>
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
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="scriptContent" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        function pageLoad(sender, args) {
            $("#chequeBookEntryListGridView").dataTable({
                "bProcessing": true,
                "bStateSave": true,
                "sPaginationType": "full_numbers",
                "aLengthMenu": [[10, 15, 20, 25, 50, -1], [10, 15, 20, 25, 50, "All"]],
                "aoColumnDefs": [{ 'bSortable': false, 'aTargets': [6, 7]}]
            });
        }
    </script>
    <script type="text/javascript">
        $(function () {
            $("#pendingEntryListButton").live("click", function (e) {
                MyOverlayStart();
            });

            $(".clickProcessing").live("click", function (e) {
                if (haveOverlay == 0) {
                    var id = $(this).attr("id");
                    var str = $(this).attr("href");
                    var arr = str.split("'");
                    var msg = "";


                    if (id == "approveLinkButton") {
                        msg = "Are you sure you want to <span class='actionTopic'>approve</span> this entry?";
                    }
                    else if (id == "rejectLinkButton") {
                        msg = "Are you sure you want to <span class='actionTopic'>reject</span> this entry?";
                    }

                    ConfirmProcess(msg, function () {
                        MyOverlayStart();
                        __doPostBack(arr[1], '');
                    }, function () {

                    });

                    e.preventDefault();
                }
            });
        });
    </script>
</asp:Content>
