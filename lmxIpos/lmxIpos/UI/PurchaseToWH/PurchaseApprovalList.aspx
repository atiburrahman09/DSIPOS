<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true" EnableEventValidation="false"
    CodeBehind="PurchaseApprovalList.aspx.cs" Inherits="lmxIpos.UI.PurchaseToWH.PurchaseApprovalList" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="true">
        <ContentTemplate>
            <div class="title-sitemap grid-12">
                <h1 class="grid-9">
                    <i>&#xf132;</i>Warehouse Purchase Record Approval List<span>Approval Warehouse Purchase
                        Record List</span></h1>
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
                            Approval Warehouse Purchase Record of
                            <asp:Label ID="idLabel" runat="server" Text=""></asp:Label></h3>
                    </header>
                    <div class="widget-body no-padding">
                        <div class="widget-separator no-padding grid-12">
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">
                                    Warehouse Name
                                </h5>
                                <asp:DropDownList ID="warehouseDropDownList" runat="server" CssClass="form form-full">
                                </asp:DropDownList>
                            </div>
                            <div class="widget-separator no-border grid-3" style="margin-top: 29px;">
                                <asp:Button ID="approvalListButton" runat="server" Text="Get Approval List" CssClass="btn btn-info"
                                    OnClick="approvalListButton_Click" />
                            </div>
                        </div>
                        <div class="grid-12">
                            <div id="purchaseRecordListGridContainer">
                                <asp:GridView ID="purchaseRecordListGridView" runat="server" AutoGenerateColumns="false"
                                    CssClass="table table-hover gridView">
                                    <Columns>
                                        <asp:BoundField DataField="PurchaseRecordId" HeaderText="PRec ID" />
                                        <asp:BoundField DataField="RecordDate" HeaderText="Record Date" />
                                        <asp:BoundField DataField="VendorName" HeaderText="Vendor Name" />
                                        <asp:BoundField DataField="WarehouseName" HeaderText="Warehouse Name" />
                                        <asp:BoundField DataField="Narration" HeaderText="Narration" />
                                        <asp:TemplateField HeaderText="View To Approve">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="viewToApproveLinkButton" runat="server" CssClass="btn btn-mini btn-success clickProcessing"
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
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="approvalListButton" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="scriptContent" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        $(function () {

        });
    </script>
    <script type="text/javascript">
        function pageLoad(sender, args) {
            $("#purchaseRecordListGridView").dataTable({
                "bProcessing": true,
                "bStateSave": true,
                "sPaginationType": "full_numbers",
                "aLengthMenu": [[10, 15, 20, 25, 50, -1], [10, 15, 20, 25, 50, "All"]],
                "aoColumnDefs": [{ 'bSortable': false, 'aTargets': [5]}]
            });

            $("#approvalListButton").click(function () {
                if (haveOverlay == 0) {
                    MyOverlayStart();
                }
            });

            $(".clickProcessing").on("click", function () {
                if (haveOverlay == 0) {
                    MyOverlayStart();
                }
            });
        }
    </script>
</asp:Content>
