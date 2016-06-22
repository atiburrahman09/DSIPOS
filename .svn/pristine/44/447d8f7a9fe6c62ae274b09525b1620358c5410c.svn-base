<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true" EnableEventValidation="false"
    CodeBehind="ApproveRequisition.aspx.cs" Inherits="lmxIpos.UI.ProductRequisition.ApproveRequisition" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="True">
        <ContentTemplate>
            <div class="title-sitemap grid-12">
                <h1 class="grid-9">
                    <i>&#xf132;</i>Approve Product Requisition<span>Approve Product Requisition System</span></h1>
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
                            Approve Product Requisition of
                            <asp:Label ID="idLabel" runat="server" Text=""></asp:Label></h3>
                    </header>
                    <div class="widget-body no-padding">
                        <div class="widget-separator no-padding grid-12">
                            <div class="widget-separator grid-6">
                                <div class="grid-6">
                                    Requisition Date:
                                </div>
                                <div class="grid-6">
                                    <asp:Label ID="requisitionDateLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label> &nbsp;&nbsp;
                                     <asp:Label ID="reqTypelabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                </div>
                            </div>
                            <div class="widget-separator grid-6">
                                <div class="grid-6">
                                    Sales Center ID & Name:
                                </div>
                                <div class="grid-6">
                                    <asp:Label ID="salesCenterIdLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                    <asp:Label ID="salesCenterNameLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                    <span id="spanreqsc" runat="server" class=""></span>
                                </div>
                            </div>
                            <div class="widget-separator grid-6">
                                <div class="grid-6">
                                    Warehouse ID & Name:
                                </div>
                                <div class="grid-6">
                                    <asp:Label ID="warehouseIdLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                    <asp:Label ID="warehouseNameLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                    <span id="spanreqwh" runat="server" class="icon icon-adjust"></span>
                                </div>
                            </div>
                            <div class="widget-separator grid-6">
                                <div class="grid-6">
                                    Narration:
                                </div>
                                <div class="grid-6">
                                    <asp:Label ID="narrationLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                </div>
                            </div>
                            <div class="widget-separator no-border grid-6">
                                <div class="grid-6">
                                    Status:
                                </div>
                                <div class="grid-6">
                                    <asp:Label ID="statusLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                </div>
                            </div>
                              <div class="widget-separator no-border grid-6">
                                <div class="grid-6">
                                    Created By:
                                </div>
                                <div class="grid-6">
                                   <asp:Label ID="lblCreatedBy" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="grid-12">
                            <div id="productRequisitionProductListGridContainer">
                                <asp:GridView ID="productRequisitionProductListGridView" runat="server" AutoGenerateColumns="false"
                                    CssClass="table table-hover gridView">
                                    <Columns>
                                        <asp:BoundField DataField="ProductId" HeaderText="Product ID" />
                                        <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                                        <asp:BoundField DataField="RequiredDate" HeaderText="Required Date" />
                                        <asp:BoundField DataField="RequisitionQuantityUnit" HeaderText="Reqi. Qty" />
                                        <asp:BoundField DataField="FreeQuantity" HeaderText="Free Qty" />
                                        <asp:TemplateField HeaderText="Aprv. Qty">
                                            <ItemTemplate>
                                                <asp:TextBox ID="approveQuantityTextBox" runat="server" Width="80"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Narration">
                                            <ItemTemplate>
                                                <asp:TextBox ID="narrationTextBox" runat="server" Width="80"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Status">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="statusDropDownList" runat="server" Width="100">
                                                    <asp:ListItem></asp:ListItem>
                                                    <asp:ListItem Value="A">Approve</asp:ListItem>
                                                    <asp:ListItem Value="R">Reject</asp:ListItem>
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                        <div class="widget-separator grid-12">
                            <asp:Button ID="approveButton" runat="server" Enabled="false" CssClass="btn btn-submit btn-3d"
                                Text="Approve & Create Transfer Order" OnClick="approveButton_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="productRequisitionProductListGridView" EventName="RowDataBound" />
            <asp:AsyncPostBackTrigger ControlID="approveButton" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:HiddenField ID="productRequisitionIdForApproveHiddenField" runat="server" />
</asp:Content>
<asp:Content ID="scriptContent" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        $(function () {
            $("#productRequisitionProductListGridView").dataTable({
                "bProcessing": true,
                "sPaginationType": "full_numbers",
                "aLengthMenu": [[10, 15, 20, 25, 50, -1], [10, 15, 20, 25, 50, "All"]],
                "iDisplayLength": -1,
                "bSort": false,
                //"aoColumnDefs": [{ 'bSortable': false, 'aTargets': [4, 5, 6, 7]}],
                "bFilter": false,
                "bLengthChange": true,
                "bPaginate": false,
                "bInfo": true
            });

            $("#productRequisitionProductListGridView_wrapper .row-fluid:nth-child(1)").css("display", "none");
        });
    </script>
</asp:Content>
