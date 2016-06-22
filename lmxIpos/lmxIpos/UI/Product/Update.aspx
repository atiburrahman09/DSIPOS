﻿<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true" EnableEventValidation="false"
    CodeBehind="Update.aspx.cs" Inherits="lmxIpos.UI.Product.Update" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="false">
        <ContentTemplate>
            <div class="title-sitemap grid-12">
                <h1 class="grid-6">
                    <i>&#xf132;</i>Update Product<span>Updating Product</span></h1>
                <div class="sitemap grid-6">
                    <%--<ul>
                        <li><span>Acura</span><i>/</i></li>
                        <li><a href="Default.aspx">Dashboard</a></li>
                    </ul>--%>
                </div>
            </div>
            <div class="data">

                <div class="widget">
                    <header class="widget-header">
                        <div class="widget-header-icon">
                            
                        </div>
                        <h3 id="Header3" runat="server" class="widget-header-title">Update Product of
                            <asp:Label ID="idLabel" runat="server" Text=""></asp:Label></h3>
                    </header>
                    <div class="widget-body no-padding">
                        <div id="msgbox" runat="server" visible="false" class="alert alert-error">
                            <button type="button" class="close" data-dismiss="alert">
                                &times;</button>
                            <h4>
                                <asp:Label ID="msgTitleLabel" runat="server" Text=""></asp:Label>
                            </h4>
                            <asp:Label ID="msgDetailLabel" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="widget-separator grid-12">
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Barcode/Code</h5>
                                <asp:TextBox ID="barcodeTextBox" onfocus="this.select()" runat="server" OnTextChanged="barcode_TextChanged" AutoPostBack="true" CssClass="form form-full" placeholder="Barcode"></asp:TextBox>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Product Name (Only)</h5>
                                <asp:TextBox ID="productNameOnlyTextBox" runat="server" CssClass="form form-full" placeholder="Product Name" required="required"></asp:TextBox>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Product Volume</h5>
                                <asp:TextBox ID="productVolumeTextBox" runat="server" CssClass="form form-full" placeholder="Product Volume" required="required"></asp:TextBox>
                            </div>
                            <%--   <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Per Unit Volume Quantity</h5>
                                <asp:TextBox ID="volumeQuantityTextBox" runat="server" CssClass="form form-full" placeholder="Per Unit Volume Quantity" required="required"></asp:TextBox>
                            </div>--%>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Unit</h5>
                                <asp:TextBox ID="unitTextBox" runat="server" CssClass="form form-full" placeholder="Unit" required="required"></asp:TextBox>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Product Group</h5>
                                <asp:DropDownList ID="productGroupDropDownList" runat="server" CssClass="form form-full chosen-select" required="required">
                                </asp:DropDownList>
                            </div>

                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Narretion <span class="text-error">*</span></h5>
                                <asp:TextBox ID="txtbxNarretion" runat="server" CssClass="form form-full" placeholder="Narretion"
                                    required="required"></asp:TextBox>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Product Description <span class="text-error">*</span></h5>
                                <asp:TextBox ID="txtbxDescription" runat="server" CssClass="form form-full" placeholder="Description"
                                    required="required"></asp:TextBox>
                            </div>


                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Product Vendor</h5>
                                <asp:DropDownList ID="vendorDropDownList" runat="server"
                                    CssClass="form form-full chosen-select" required="required">
                                </asp:DropDownList>
                            </div>
                            <div class="clearfix"></div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Warehouse</h5>
                                <asp:DropDownList ID="warehouseDropDownList" required="required" runat="server" CssClass="form form-full">
                                </asp:DropDownList>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Sales Center</h5>
                                <asp:DropDownList ID="salescenterDropDownList" required="required" runat="server" CssClass="form form-full">
                                </asp:DropDownList>
                            </div>
                            <%-- <div class="widget-separator no-border grid-3">
                                <h5 class="typo">
                                    Product Rate</h5>
                                <asp:TextBox ID="productRateTextBox" runat="server" CssClass="form form-full" placeholder="Product Rate" required="required"></asp:TextBox>
                            </div>--%>
                            <%-- <div class="widget-separator no-border grid-3">
                                <h5 class="typo">
                                    VAT(%)</h5>
                                <asp:TextBox ID="vatPercentageTextBox" runat="server" CssClass="form form-full" placeholder="VAT(%)" required="required"></asp:TextBox>
                            </div>--%>
                        </div>
                        <div class="widget-separator grid-12">
                            <asp:Button ID="updateButton" runat="server" Text="Update" CssClass="btn btn-submit btn-3d"
                                OnClick="updateButton_Click" />
                            <a class="btn btn-error btn-3d" href="/UI/Product/List.aspx">Cancel</a>
                        </div>
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="productIdForUpdateHiddenField" runat="server" />
            <asp:HiddenField ID="productNameForUpdateHiddenField" runat="server" />
            <asp:HiddenField ID="barcodeForUpdateHiddenField" runat="server" />
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="barcodeTextBox" EventName="TextChanged" />
            <asp:AsyncPostBackTrigger ControlID="updateButton" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="productGroupDropDownList" EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="scriptContent" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        $(function () {
            //            $.ajax({
            //                type: "POST",
            //                url: "/AutoCompletePage.aspx/GetProductBarcodes",
            //                data: "{}",
            //                contentType: "application/json; charset=utf-8",
            //                dataType: "json",
            //                success: function (data) {
            //                    $("#barcodeTextBox").autocomplete(data.d.toString().split("\r\n"));
            //                }
            //            });

            //            $.ajax({
            //                type: "POST",
            //                url: "/AutoCompletePage.aspx/GetProductNamesOnly",
            //                data: "{}",
            //                contentType: "application/json; charset=utf-8",
            //                dataType: "json",
            //                success: function (data) {
            //                    $("#productNameOnlyTextBox").autocomplete(data.d.toString().split("\r\n"));
            //                }
            //            });

            //            $.ajax({
            //                type: "POST",
            //                url: "/AutoCompletePage.aspx/GetProductVolumes",
            //                data: "{}",
            //                contentType: "application/json; charset=utf-8",
            //                dataType: "json",
            //                success: function (data) {
            //                    $("#productVolumeTextBox").autocomplete(data.d.toString().split("\r\n"));
            //                }
            //            });

            //            $.ajax({
            //                type: "POST",
            //                url: "/AutoCompletePage.aspx/GetProductUnits",
            //                data: "{}",
            //                contentType: "application/json; charset=utf-8",
            //                dataType: "json",
            //                success: function (data) {
            //                    $("#unitTextBox").autocomplete(data.d.toString().split("\r\n"));
            //                }
            //            });
        });
    </script>
    <script type="text/javascript">
        function pageLoad(sender, args) {
            $.ajax({
                type: "POST",
                url: "/Services/ProductNameOnly.ashx",
                success: function (d) {
                    var array = [];
                    d.split(';').forEach(function (value) {
                        array.push(value);
                    });
                    $('#productNameOnlyTextBox').typeahead({ source: array });

                }
            });

            $.ajax({
                type: "POST",
                url: "/Services/ProductVolumes.ashx",
                success: function (d) {
                    var array = [];
                    d.split(';').forEach(function (value) {
                        array.push(value);
                    });
                    $('#productVolumeTextBox').typeahead({ source: array });

                }
            });

            $.ajax({
                type: "POST",
                url: "/Services/ProductsUnits.ashx",
                success: function (d) {
                    var array = [];
                    d.split(';').forEach(function (value) {
                        array.push(value);
                    });
                    $('#unitTextBox').typeahead({ source: array });

                }
            });
            var config = {
                '.chosen-select': {},
                '.chosen-select-deselect': { allow_single_deselect: true },
                '.chosen-select-no-single': { disable_search_threshold: 20 },
                '.chosen-select-no-results': { no_results_text: 'Oops, nothing found!' },
                '.chosen-select-width': { width: "96%" }
            }
            for (var selector in config) {
                $(selector).chosen(config[selector]);
            }
            //$("#updateButton").click(function (e) {
            //    if (Page_ClientValidate("")) {
            //        if (haveOverlay == 0) {
            //            MyOverlayStart();
            //        }
            //    }
            //});
        }
    </script>
</asp:Content>