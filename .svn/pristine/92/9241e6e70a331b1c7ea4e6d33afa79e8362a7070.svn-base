<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true" CodeBehind="newproductionDetails.aspx.cs" Inherits="lmxIpos.UI.production.newproductionDetails" EnableEventValidation="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
     <div class="title-sitemap grid-12">
        <h1 class="grid-8">
            <i>&#xf132;</i>Production Details<span>Production Record Details</span></h1>
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
                <h3 id="Header3" runat="server" class="widget-header-title">Production Record of
                     [<asp:Label ID="lblProductionID" runat="server" Text=""></asp:Label>]</h3>
            </header>
            <div class="widget-body no-padding">

                <div class="widget-separator no-border grid-12">
                </div>
                <div class="widget-separator">
                    <h4>Production Information</h4>
                </div>
                <div id="orderInfoContainer">
                    <div class="grid-12">
                        <div class="widget-separator grid-6">
                            <div class="grid-4">
                                Produce Date :
                                </div>
                            <div class="grid-8">
                                <asp:Label ID="lblProduceDate" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                            </div>
                            </div>
                        <div class="widget-separator grid-6">
                            <div class="grid-4">
                                Product Created By :
                            </div>
                            <div class="grid-8">
                                <asp:Label ID="lblProductCreatedBy" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                            </div>
                        </div>
                        </div>
                      <div class="grid-12">
                        <div class="widget-separator grid-6">
                            <div class="grid-4">
                                Production Name :
                                </div>
                            <div class="grid-8">
                                <asp:Label ID="lblProductionName" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                            </div>
                            </div>
                        <div class="widget-separator grid-6">
                            <div class="grid-4">
                                Produce Bundle (Coil):
                            </div>
                            <div class="grid-8">
                                <asp:Label ID="lblProductBundle" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                            </div>
                        </div>
                        </div>
                    <div class="grid-12">
                        <div class="widget-separator grid-6">
                            <div class="grid-4">
                                Produce Goods Weight :
                                </div>
                            <div class="grid-8">
                                <asp:Label ID="lblProduceWeight" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                            </div>
                            </div>
                        <div class="widget-separator grid-6">
                            <div class="grid-4">
                                Unit Cost :
                            </div>
                            <div class="grid-8">
                                <asp:Label ID="lblUnitCost" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                            </div>
                        </div>
                        </div>
                    <div class="grid-12">
                        
                        <div class="widget-separator grid-6">
                            <div class="grid-4">
                               Raw Metarial Total Quantity :
                            </div>
                            <div class="grid-8">
                                <asp:Label ID="lblTotQuantity" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                            </div>
                        </div>
                         <div class="widget-separator grid-6">
                            <div class="grid-4">
                                Raw Metarial Cost :
                                </div>
                            <div class="grid-8">
                                <asp:Label ID="lblRawMetarialCost" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                            </div>
                            </div>
                        </div>
                    <div class="grid-12">
                       
                        <div class="widget-separator grid-6">
                            <div class="grid-4">
                                Other Amount :
                            </div>
                            <div class="grid-8">
                                <asp:Label ID="lblOtherAmmount" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                            </div>
                        </div>
                        <div class="widget-separator grid-6">
                            <div class="grid-4">
                                Working Cost :
                                </div>
                            <div class="grid-8">
                                <asp:Label ID="lblWorkingCost" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                            </div>
                            </div>
                        </div>
                    <div class="grid-12">
                        <div class="widget-separator grid-6">
                            <div class="grid-4">
                               <b> Production Cost :</b>
                                </div>
                            <div class="grid-8">
                               <b style="color: green;"> <asp:Label ID="lblProductionCost" runat="server" Text="" CssClass="infoLabel"></asp:Label></b>
                            </div>
                            </div>
                        
                        <div class="widget-separator grid-6">
                            <div class="grid-4">
                                Decrease Weight :
                            </div>
                            <div class="grid-8">
                                <asp:Label ID="lblDecreaseWeight" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                            </div>
                        </div>
                        </div>
                    <div class="grid-12">
                        <div class="widget-separator grid-6">
                            <div class="grid-4">
                                Decrease Rate [%] :
                                </div>
                            <div class="grid-8">
                                <asp:Label ID="lblDecreaseRate" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                            </div>
                            </div>
                        <div class="widget-separator grid-6">
                            <div class="grid-4">
                                Description :
                            </div>
                            <div class="grid-8">
                                <asp:Label ID="lblDescription" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                            </div>
                        </div>
                        </div>
                     <div class="grid-12" style="padding:20px;">
                    <div id="gridRawMetarialss">
                            <asp:GridView ID="gridRawMetarials" runat="server" AutoGenerateColumns="false"
                                CssClass="table table-hover dataTable">
                                <Columns>
                                    <asp:BoundField DataField="Serial" HeaderText="Serial" Visible="false" />
                                    <asp:BoundField DataField="ProductionId" HeaderText="Production ID" />
                                    <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                                    <asp:BoundField DataField="ProductQuantity" HeaderText="Product Quantity" />
                                    <asp:BoundField DataField="ProductRate" HeaderText="Product Rate" />
                                    <asp:BoundField DataField="TotalCost" HeaderText="Total Cost" />
                                </Columns>
                                </asp:GridView>
                        </div>
                         </div>
                    <asp:HiddenField ID="lblStatus" runat="server" />
                    <div class="widget-separator grid-12">
                        <div class="grid-6">
                            <asp:Button ID="btnAccept" runat="server" Text="Approve & Confirm New Production" CssClass="pull-right grid-3 btn btn-submit btn-3d" style="margin-right:10px;" OnClick="btnAccept_Click" />
                        </div>
                        <div class="grid-6">
                            <asp:Button ID="btnReject" runat="server" Text="Reject" CssClass="pull-left grid-3 btn btn-error btn-3d" style="margin-left:10px;" OnClick="btnReject_Click" OnClientClick="return confirm('Do you want to cancel the order?')" />
                        </div>
                    </div>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        function pageLoad(sender, args) {
            $("#gridRawMetarials").dataTable({
                //"bProcessing": true,
                //"sPaginationType": "full_numbers",
                //"aLengthMenu": [[10, 25, 50, -1], [10, 25, 50, "All"]],
                //"iDisplayLength": -1,
                //"bSort": true,
                //"aoColumnDefs": [{ 'bSortable': false, 'aTargets': [5, 6, 7] }],
                //"bFilter": true,
                //"bLengthChange": true,
                //"bPaginate": true,
                //"bInfo": false,
                //"bState": true
            });
        }
        </script>
</asp:Content>
