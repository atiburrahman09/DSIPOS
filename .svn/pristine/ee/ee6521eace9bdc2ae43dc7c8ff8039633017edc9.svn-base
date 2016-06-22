<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true" EnableEventValidation="false"
    CodeBehind="Create.aspx.cs" Inherits="lmxIpos.UI.Product.Create" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="false">
        <ContentTemplate>
            <div class="title-sitemap grid-12">
                <h1 class="grid-6">
                    <i>&#xf132;</i>Create Product<span>Creating Product</span></h1>
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
                        <h3 id="Header3" runat="server" class="widget-header-title">Create Product Form</h3>
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
                                <asp:TextBox ID="barcodeTextBox" placeholder="Barcode" TabIndex="0" onfocus="this.select()" runat="server" OnTextChanged="barcode_TextChanged" AutoPostBack="true"
                                    CssClass="form form-full"></asp:TextBox>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Product Name (Only) <span class="text-error">*</span> </h5>
                                <asp:TextBox ID="productNameOnlyTextBox" required="required" TabIndex="1" placeholder="Product Name"
                                    runat="server" CssClass="form form-full"></asp:TextBox>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Product Volume <span class="text-error">*</span> </h5>
                                <asp:TextBox ID="productVolumeTextBox" required="required" TabIndex="2" placeholder="Ex- 10ml/ 10gm/ 1 kg/ 1st part"
                                    runat="server" CssClass="form form-full"></asp:TextBox>
                            </div>
                            <%-- <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Per Unit Volume Quantity</h5>
                                <asp:TextBox ID="volumeQuantityTextBox" runat="server" CssClass="form form-full"
                                    placeholder="Per Unit Volume Quantity" required="required"></asp:TextBox>
                            </div>--%>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Unit <span class="text-error">*</span></h5>
                                <asp:TextBox ID="unitTextBox" runat="server" TabIndex="3" CssClass="form form-full" placeholder="ex- Pcs,Kg,gm,Inch"
                                    required="required"></asp:TextBox>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Product Group<span class="text-error">*</span></h5>
                                <asp:DropDownList ID="productGroupDropDownList" TabIndex="4" runat="server" required="required"
                                    CssClass="form form-full chosen-select">
                                </asp:DropDownList>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Product Sales Rate <span class="text-error">*</span> </h5>
                                <asp:TextBox ID="productRateTextBox" runat="server" TabIndex="5" CssClass="form form-full" placeholder="0.00"
                                    required="required"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Taka only" ControlToValidate="productRateTextBox"
                                    ValidationGroup="2" Type="Currency" Operator="DataTypeCheck" ForeColor="Red"
                                    Visible="true"> </asp:CompareValidator>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Note</h5>
                                <asp:TextBox ID="txtbxNarretion" runat="server" TabIndex="6" CssClass="form form-full" placeholder="Narretion"></asp:TextBox>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Product Description <span class="text-error">*</span></h5>
                                <asp:TextBox ID="txtbxDescription" runat="server" CssClass="form form-full" placeholder="Description"
                                    required="required"></asp:TextBox>
                            </div>
                            <div class="clearfix"></div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Discount(%)</h5>
                                <asp:TextBox ID="vatPercentageTextBox" runat="server" TabIndex="7" CssClass="form form-full" Text="0" placeholder="Discount(%)"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="Number only" ControlToValidate="vatPercentageTextBox"
                                    ValidationGroup="2" Type="Currency" Operator="DataTypeCheck" ForeColor="Red"
                                    Visible="true"> </asp:CompareValidator>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Product Vendor <span class="text-error">*</span></h5>
                                <asp:DropDownList ID="vendorDropDownList" required="required" TabIndex="8" runat="server" CssClass="form form-full chosen-select">
                                </asp:DropDownList>
                            </div>
                            <div class="grid-12">
                                <div class="widget-separator no-border grid-3">
                                    <h5 class="typo">Warehouse</h5>
                                    <asp:DropDownList ID="warehouseDropDownList" required="required" TabIndex="9" runat="server" CssClass="form form-full">
                                    </asp:DropDownList>
                                </div>
                                <div class="widget-separator no-border grid-3">
                                    <h5 class="typo">Sales Center</h5>
                                    <asp:DropDownList ID="salescenterDropDownList" required="required" TabIndex="10" runat="server" CssClass="form form-full">
                                    </asp:DropDownList>
                                </div>
                            </div>

                        </div>
                        <div class="widget-separator no-border grid-12">
                            <asp:Button ID="saveButton" runat="server" TabIndex="11" Text="Save" CssClass="btn btn-submit btn-3d"
                                OnClick="saveButton_Click" />
                            <asp:Button ID="SaveandAddMoreButton" TabIndex="12" runat="server" Text="Save and Add more" CssClass="btn  btn-3d"
                                OnClick="saveButton_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="barcodeTextBox" EventName="TextChanged" />
            <asp:AsyncPostBackTrigger ControlID="saveButton" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="productGroupDropDownList" EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="scriptContent" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        function pageLoad(sender, args) {
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
            $.ajax({
                type: "POST",
                url: "/Services/ProductSearch.ashx",
                success: function (d) {
                    var array = [];
                    d.split(';').forEach(function (value) {
                        array.push(value);
                    });
                    $('#productTextBox').typeahead({ source: array });
                    //$('#txtbxfineBy').typeahead({ source: array });
                }
            });

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
            //$("#saveButton").click(function (e) {
            //    if (Page_ClientValidate("")) {
            //        if (haveOverlay == 0) {
            //            MyOverlayStart();
            //        }
            //    }
            //});
        }
    </script>
</asp:Content>
