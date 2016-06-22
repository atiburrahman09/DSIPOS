<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true"
    CodeBehind="ApprovedSalesReturn.aspx.cs" Inherits="lmxIpos.UI.SalesReturn.ApprovedSalesReturn" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="false">
        <ContentTemplate>
            <div class="title-sitemap grid-12">
                <h1 class="grid-8">
                    <i>&#xf132;</i>Sales Return Record<span>Approved Sales Return Record</span></h1>
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
                        <h3 id="Header3" runat="server" class="widget-header-title">Sales Return Record of
                            <asp:Label ID="idLabel" runat="server" Text=""></asp:Label></h3>
                    </header>
                    <div class="widget-body no-padding">
                        <div id="orderInfoContainer">
                            <div class="grid-12">
                                <div class="widget-separator grid-6">
                                    <div class="grid-4">
                                        Return ID:
                                    </div>
                                    <div class="grid-8">
                                        <asp:Label ID="returnIdLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                    </div>
                                </div>
                                <div class="widget-separator grid-6">
                                    <div class="grid-4">
                                        Return Date:
                                    </div>
                                    <div class="grid-8">
                                        <asp:Label ID="returnDateLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                    </div>
                                </div>
                                <div class="widget-separator grid-6">
                                    <div class="grid-4">
                                        Sales Record ID:
                                    </div>
                                    <div class="grid-8">
                                        <asp:Label ID="salesRecordIdLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
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
                                        WH/SC Name [ID]:
                                    </div>
                                    <div class="grid-8">
                                            <asp:Label ID="salesCenterNameLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                        [<asp:Label ID="salesCenterIdLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>]
                                    
                                    </div>
                                </div>

                                <div class="widget-separator grid-6">
                                    <div class="grid-4">
                                        Return Amount:
                                    </div>
                                    <div class="grid-8">
                                        <asp:Label ID="returnAmountLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                    </div>
                                </div>
                                <div class="widget-separator grid-6">
                                    <div class="grid-4">
                                        Sales Due Amount Was:
                                    </div>
                                    <div class="grid-8">
                                        <asp:Label ID="dueAmountLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                    </div>
                                </div>
                                <div class="widget-separator grid-6">
                                    <div class="grid-4">
                                        Return Service Charge:
                                    </div>
                                    <div class="grid-8 text-info bolder">
                                        <asp:Label ID="returnVATAmountLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                    </div>
                                </div>
                                <div class="widget-separator grid-6">
                                    <div class="grid-4">
                                        Adjusted Amount:
                                    </div>
                                    <div class="grid-8 text-success bolder">
                                        <asp:Label ID="AdjustedAmountLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
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
                            <div class="grid-12">
                                <div id="salesReturnProductListGridContainer">
                                    <asp:GridView ID="salesReturnProductListGridView" runat="server" AutoGenerateColumns="false"
                                        CssClass="table table-hover gridView">
                                        <Columns>
                                            <asp:BoundField DataField="ProductId" HeaderText="Product ID" />
                                            <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                                            <asp:BoundField DataField="ReturnQuantity" HeaderText="Quantity" />
                                            <asp:BoundField DataField="RatePerUnit" HeaderText="Rate Per Unit" />
                                            <asp:BoundField DataField="ReturnAmount" HeaderText="Amount" />
                                            <asp:BoundField DataField="ReturnVATAmount" HeaderText="Service Charge" />
                                            <%--<asp:BoundField DataField="PurchaseRecordId" HeaderText="PR ID" />--%>
                                            <asp:BoundField DataField="PurchaseRate" HeaderText="P Rate" />
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="salesReturnIdForViewHiddenField" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="scriptContent" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        $(function () {
            $("#salesReturnProductListGridView").dataTable({
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

            $("#salesReturnProductListGridView_wrapper .row-fluid:nth-child(1)").css("display", "none");
        });
    </script>
</asp:Content>
