<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true"
    CodeBehind="TransferRecordApprovalListAll.aspx.cs" Inherits="lmxIpos.UI.ProductTransferRecord.TransferRecordApprovalListAll" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
    <link href="/Content/Style/CSSPages/ProductTransferRecordList.css" rel="stylesheet"
        type="text/css" />
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="true">
        <ContentTemplate>
            <div class="title-sitemap grid-12">
                <h1 class="grid-10">
                    <i>&#xf132;</i>Product Transfer Record Approval List All<span>System Product Transfer
                        Record Approval List All</span></h1>
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
                            Product Transfer Record Approval List All of System</h3>
                    </header>
                    <div class="widget-body no-padding">
                        <div class="widget-separator grid-12">
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">
                                    Transfer Description
                                </h5>
                                <asp:DropDownList ID="transferDescriptionDropDownList" runat="server" CssClass="form form-full">
                                    <asp:ListItem>All</asp:ListItem>
                                    <asp:ListItem>Product Requisition</asp:ListItem>
                                    <asp:ListItem>Transfer Requisition</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">
                                    Transfer Type (WH/SC~WH/SC)</h5>
                                <asp:DropDownList ID="transferTypeDropDownList" runat="server" AutoPostBack="true"
                                    OnSelectedIndexChanged="transferTypeDropDownList_SelectedIndexChanged" CssClass="form form-full">
                                    <asp:ListItem Value="All">All</asp:ListItem>
                                    <asp:ListItem Value="WH-WH">Warehouse to Warehouse</asp:ListItem>
                                    <asp:ListItem Value="WH-SC">Warehouse to Salse Center</asp:ListItem>
                                    <asp:ListItem Value="SC-SC">Salse Center to Salse Center</asp:ListItem>
                                    <asp:ListItem Value="SC-WH">Salse Center to Warehouse</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">
                                    Transfer From (WH/SC)</h5>
                                <asp:DropDownList ID="transferFromDropDownList" runat="server" CssClass="form form-full">
                                </asp:DropDownList>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">
                                    Transfer To (WH/SC)
                                </h5>
                                <asp:DropDownList ID="transferToDropDownList" runat="server" CssClass="form form-full">
                                </asp:DropDownList>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <asp:Button ID="approvalListButton" runat="server" Text="Get Approval List" CssClass="btn btn-info"
                                    OnClick="approvalListButton_Click" />
                            </div>
                        </div>
                        <div class="widget-separator grid-12">
                            <div id="transferRecordListGridContainer">
                                <asp:GridView ID="transferRecordListGridView" runat="server" AutoGenerateColumns="false"
                                    CssClass="table table-hover gridView">
                                    <Columns>
                                        <asp:BoundField DataField="TransferRecordId" HeaderText="Record ID" />
                                        <asp:BoundField DataField="ReceivedDate" HeaderText="Received Date" />
                                        <asp:BoundField DataField="TransferOrderId" HeaderText="Transfer Order ID" />
                                        <asp:BoundField DataField="OrderDate" HeaderText="Transfer Order Date" />
                                        <asp:BoundField DataField="TransferType" HeaderText="Transfer Type" />
                                        <asp:BoundField DataField="TransferFromName" HeaderText="Transfer From (WH/SC)" />
                                        <asp:BoundField DataField="TransferToName" HeaderText="Transfer To (WH/SC)" />
                                        <asp:BoundField DataField="Description" HeaderText="Transfer Description" />
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
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="approvalListButton" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="transferRecordListGridView" EventName="RowDataBound" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="scriptContent" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        $(function () {
            $("#transferDescriptionDropDownList").rules("add", {
                required: true
            });

            $("#transferTypeDropDownList").rules("add", {
                required: true
            });

            $("#transferFromDropDownList").rules("add", {
                required: true
            });

            $("#transferToDropDownList").rules("add", {
                required: true
            });

            $("#transferRecordListGridView").dataTable({
                "bProcessing": true,
                "sPaginationType": "full_numbers",
                "aLengthMenu": [[10, 15, 20, 25, 50, -1], [10, 15, 20, 25, 50, "All"]],
                "aoColumnDefs": [{ 'bSortable': false, 'aTargets': [8]}]
            });
        });
    </script>
</asp:Content>
