<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true" CodeBehind="newproduct.aspx.cs" Inherits="lmxIpos.UI.production.newproduct" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server" ID="updatePanel1" ChildrenAsTriggers="False" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="title-sitemap grid-12">
                <h1 class="grid-8">

                    <i></i>Product<span>Creating product Record</span></h1>
                <div class="sitemap grid-6">
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
                        <h3 class="widget-header-title" id="Header3">Create product Record Form</h3>
                    </header>
                    <div class="widget-body no-padding">
                        <div class="widget-separator no-padding grid-12">
                           
                           
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Type
                                </h5>

                                <asp:DropDownList ID="TypeDrpDwn" required="required" runat="server" CssClass="form form-full" AutoPostBack="True" OnSelectedIndexChanged="TypeDrpDwn_OnSelectedIndexChanged">
                                    <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="Ware House" Value="warehouse"></asp:ListItem>
                                    <asp:ListItem Text="Sales Center" Value="SalesCenter"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">
                                    <asp:Label runat="server" ID="wareHouseOrsalesCenterLabel" Text="Ware House"></asp:Label>
                                </h5>

                                <asp:DropDownList ID="wareHouseOrSalesCenterDrpDwn" required="required" runat="server" CssClass="form form-full" AutoPostBack="True" OnSelectedIndexChanged="wareHouseOrSalesCenterDrpDwn_OnSelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                             <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Main Production
                                </h5>

                                <asp:DropDownList ID="mainProductionDrpDwnList" runat="server" CssClass="form form-full" AutoPostBack="True" OnSelectedIndexChanged="mainProductionDrpDwnList_OnSelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                           <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Used Wieght of Main Production
                                </h5>
                                <asp:TextBox runat="server" ID="weightofMainProductinTxtBx" CssClass="form form-full"></asp:TextBox>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Working Cost 
                                </h5>
                                <asp:TextBox runat="server" ID="workingCostTxtBx" CssClass="form form-full"></asp:TextBox>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Other Cost 
                                </h5>
                                <asp:TextBox runat="server" ID="otherCostTxtBx" CssClass="form form-full"></asp:TextBox>
                            </div>
                        </div>
                       
                        <div class="widget-separator no-border grid-12">
                             <div id="productDetailsDiv" runat="server" Visible="False">
                                 <div class="grid-4">
                                     <div class="grid-12">
                                         <div class="grid-6">Product Name : </div>
                                          <div class="grid-6"><b><asp:Label runat="server" ID="productNamelbl"></asp:Label></b></div>
                                     </div>
                                 </div>
                                 <div class="grid-4">
                                     <div class="grid-12">
                                         <div class="grid-6"> Unit Cost : </div>
                                          <div class="grid-6"><b><asp:Label runat="server" ID="UnitCostLabel"></asp:Label></b></div>
                                     </div>
                                 </div>
                                 <div class="grid-4">
                                     <div class="grid-12">
                                         <div class="grid-6">In Stock : </div>
                                          <div class="grid-6"><b><asp:Label runat="server" ID="instockLabel" CssClass="control-label"></asp:Label></b></div>
                                     </div>
                                 </div>
                        </div></div>
                        <div class="widget-separator no-border grid-12">
                        </div>
                        <div class="widget-separator">
                            <h4>Produce Product   
                                <asp:Button ID="addFromListButton" CssClass="btn btn-success" runat="server" Text="Add from List"
                                    OnClientClick="return false;" />
                            </h4>

                        </div>
                        <div class="grid-12">
                            <div id="purchaseProductListGridContainer">
                                <asp:GridView ID="purchaseProductListGridView" runat="server" AutoGenerateColumns="false"
                                    CssClass="table table-hover dataTable gridView">
                                    <Columns>
                                        <asp:BoundField DataField="Barcode" HeaderText="Barcode" Visible="False" />
                                        <asp:BoundField DataField="ProductId" HeaderText="Product ID" />
                                        <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                                        <asp:BoundField DataField="Unit" HeaderText="Unit" />
                                       <asp:BoundField DataField="FreeQuantity" HeaderText="Available"/>
                                        <asp:TemplateField HeaderText="Quantity">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtQuantity" Text="1" runat="server" Width="80" CssClass="pQty-rpu-amt-cal"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Unit Price">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtRate" runat="server" Width="80" CssClass="pQty-rpu-amt-cal" ReadOnly="True"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="New Unit Price">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtPrice" runat="server" Width="80" CssClass="pQty-rpu-amt-cal"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="removeLinkButton" runat="server"
                                                    CssClass="btn btn-mini btn-inverse" Style="align: center;" OnClick="removeLinkButton_Click"><i class="icon icon-trash icon-2x" style="color:#f00;"></i></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                        <asp:HiddenField ID="checkedRowCountHiddenField" runat="server" />
                        <div class="widget-separator text-center no-border grid-12">
                            <asp:Button ID="saveButton" CssClass="btn btn-submit btn-large btn-3d" Enabled="false" runat="server" OnClick="saveButton_OnClick"
                                Text="Save" />
                        </div>

                    </div>
                    <div id="productListModal" class="modal hide fade" tabindex="-1" role="dialog" style="width: 780px;" aria-labelledby="myModalLabel"
                        aria-hidden="true">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                &times;</button>
                            <h3>Product List
                            </h3>
                        </div>
                        <div class="modal-body">
                            <div id="productListGridContainer">
                                <asp:GridView ID="productListGridView" runat="server" AutoGenerateColumns="false"
                                    CssClass="table table-hover dataTable">
                                    <Columns>
                                        <asp:BoundField DataField="Barcode" HeaderText="Barcode" />
                                        <asp:BoundField DataField="ProductId" HeaderText="Product ID" />
                                        <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                                        <asp:BoundField DataField="Unit" HeaderText="Unit" />
                                        <asp:BoundField DataField="ProductGroupName" HeaderText="Product Group" />
                                        <asp:BoundField DataField="FreeQuantity" HeaderText="Free Quantity" />
                                        <asp:BoundField DataField="LastUnitPrice" HeaderText="Unit Price" />
                                        <asp:BoundField DataField="VATPercentage" HeaderText="VATPercentage" Visible="false" />

                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="allCheckBox" runat="server" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="selectCheckBox" runat="server" CssClass="clickCheckBox" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="addSelectedProductButton" runat="server" CssClass="btn btn-success"
                                Text="Add Selected Product(s)" OnClick="addSelectedProductButton_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="TypeDrpDwn" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="wareHouseOrSalesCenterDrpDwn" EventName="SelectedIndexChanged" />
             <asp:AsyncPostBackTrigger ControlID="mainProductionDrpDwnList" EventName="SelectedIndexChanged" />
            <%--  <asp:AsyncPostBackTrigger ControlID="addFromListButton" EventName="Click" />--%>
            <%--    <asp:AsyncPostBackTrigger ControlID="addSelectedProductButton" EventName="Click" />--%>
            <asp:AsyncPostBackTrigger ControlID="addSelectedProductButton" EventName="Click" />

            <%-- <asp:AsyncPostBackTrigger ControlID="saveButton" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="saveButton" EventName="Click" />--%>
            <%--  <asp:AsyncPostBackTrigger ControlID="addProductButton" EventName="Click" />--%>
            <asp:AsyncPostBackTrigger ControlID="purchaseProductListGridView" EventName="RowDataBound" />
        </Triggers>
    </asp:UpdatePanel>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">

        function pageLoad(sender, args) {
            $('#mainProductionDrpDwnList').chosen();

            $("#productListGridView").dataTable({
                "bProcessing": true,
                "sPaginationType": "full_numbers",
                "aLengthMenu": [[-1], ["All"]],
                "iDisplayLength": -1,
                "aoColumnDefs": [{ 'bSortable': false, 'aTargets': [5] }],
                "bFilter": true,
                "bLengthChange": true,
                "bPaginate": false,
                "bInfo": true,
                "bDestroy": true
            });

            $("#purchaseProductListGridView").dataTable(//{
                //"bProcessing": true,
                //"sPaginationType": "full_numbers",
                //"aLengthMenu": [[-1], ["All"]],
                //"iDisplayLength": -1,
                //"aoColumnDefs": [{ 'bSortable': false, 'aTargets': [5] }],
                //"bFilter": true,
                //"bLengthChange": true,
                //"bPaginate": false,
                //"bInfo": true,
                //"bDestroy": true
            //}
            );

            $('.modal-backdrop').remove();
            var checkedRowCount = $("#checkedRowCountHiddenField").val();

            $("#addSelectedProductButton").click(function () {
                $("#checkedRowCountHiddenField").val(checkedRowCount);
                //$('#productListModal').modal({ show: false });
                //if (haveOverlay == 1) {
                //    MyOverlayStop();
                //}
            });
            $("#addFromListButton").click(function () {
                $('#productListModal').modal();
            });
        }

 
    </script>
</asp:Content>
