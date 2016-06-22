<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true"
    CodeBehind="PurchaseApprovalList.aspx.cs" Inherits="lmxIpos.UI.PurchaseRecord.PurchaseApprovalList" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
    <link href="/Content/Style/CSSPages/PurchaseApprovalList.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <div class="title-sitemap grid-12">
        <h1 class="grid-6">
            <i>&#xf132;</i>Purchase Approval List<span>Creating Purchase Record Approval</span></h1>
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
                            Purchase Record Approval List</h3>
                    </header>
            <div class="widget-body no-padding">
                <div class="widget-separator grid-12">
                    <div class="widget-separator no-border grid-3">
                        <h5 class="typo">
                            Warehouse Name
                        </h5>
                        <asp:DropDownList ID="warehouseDropDownList" runat="server" CssClass="form form-full">
                        </asp:DropDownList>
                    </div>
                    <div class="widget-separator no-border grid-3">
                        <asp:Button ID="approvalListButton" runat="server" Text="Get Approval List" CssClass="btn btn-info"
                            OnClick="approvalListButton_Click" />
                    </div>
                </div>
                <div class="widget-separator no-border grid-12">
                    <div id="purchaseRecordListGridContainer" >
                        <asp:GridView ID="purchaseRecordListGridView" runat="server" AutoGenerateColumns="false"
                            CssClass="table table-hover gridView">
                            <Columns>
                                <asp:BoundField DataField="PurchaseRecordId" HeaderText="PRec ID" />
                                <asp:BoundField DataField="RecordDate" HeaderText="Record Date" />
                                <asp:BoundField DataField="VendorName" HeaderText="Vendor Name" />
                                <asp:BoundField DataField="WarehouseName" HeaderText="Warehouse Name" />
                                <asp:BoundField DataField="PurchaseRequisitionId" HeaderText="PR ID" />
                                <asp:BoundField DataField="PurchaseOrderId" HeaderText="PO ID" />
                                <asp:BoundField DataField="Narration" HeaderText="Narration" />
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="viewToApproveLinkButton" runat="server" CssClass="btn btn-mini btn-success"
                                            OnClick="viewToApproveLinkButton_Click">View to Approve</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="scriptContent" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        $(function () {
            $("#purchaseRecordListGridView").dataTable({
                "bProcessing": true,
                "sPaginationType": "full_numbers",
                "aLengthMenu": [[10, 15, 20, 25, 50, -1], [10, 15, 20, 25, 50, "All"]],
                "aoColumnDefs": [{ 'bSortable': false, 'aTargets': [7]}]
            });
        });
    </script>
</asp:Content>
