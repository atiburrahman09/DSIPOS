<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true" EnableEventValidation="false"
    CodeBehind="ManageProductVendor.aspx.cs" Inherits="lmxIpos.UI.Product.ManageProductVendor" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">

    <%-- <link href="/Content/Style/CSSPages/ManageProductVendor.css" rel="stylesheet" type="text/css" />--%>
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional" ChildrenAsTriggers="False">
        <ContentTemplate>
            <div class="title-sitemap grid-12">
                <h1 class="grid-6">
                    <i>&#xf132;</i>Manage Product Vendor<span>Managing Product Vendor</span></h1>
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
                            
                        </div>
                        <h3 id="Header3" runat="server" class="widget-header-title">System of Manage Product Vendor</h3>
                    </header>
                    <div class="widget-body no-padding">
                        <div class="widget-separator no-padding grid-12">
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Product By [Barcode, ID, Name]</h5>
                                <asp:TextBox ID="productTextBox" onfocus="this.select()" runat="server" CssClass="form form-full" placeholder="Product By [Barcode, ID, Name]"></asp:TextBox>
                            </div>
                            <div class="widget-separator no-border grid-3" style="margin-top: 29px;">
                                <asp:Button ID="productVendorButton" CssClass="btn btn-info" runat="server" Text="Get Product's Vendor List"
                                    OnClick="productVendorButton_Click" />
                            </div>
                        </div>
                        <div id="productVendorPane" runat="server" visible="false">
                            <div id="productInfoPane">
                                <div class="grid-12">
                                    <div class="widget-separator grid-6">
                                        <div class="grid-4">
                                            Barcode:
                                        </div>
                                        <div class="grid-8">
                                            <asp:Label ID="barcodeLabel" runat="server" CssClass="infoLabel" Text=""></asp:Label>
                                        </div>
                                    </div>
                                    <div class="widget-separator grid-6">
                                        <div class="grid-4">
                                            Product ID:
                                        </div>
                                        <div class="grid-8">
                                            <asp:Label ID="productIdLabel" runat="server" CssClass="infoLabel" Text=""></asp:Label>
                                        </div>
                                    </div>
                                    <div class="widget-separator grid-6">
                                        <div class="grid-4">
                                            Product Name:
                                        </div>
                                        <div class="grid-8">
                                            <asp:Label ID="productNameLabel" runat="server" CssClass="infoLabel" Text=""></asp:Label>
                                        </div>
                                    </div>
                                    <div class="widget-separator grid-6">
                                        <div class="grid-4">
                                            Product Group Name:
                                        </div>
                                        <div class="grid-8">
                                            <asp:Label ID="productGroupNameLabel" runat="server" CssClass="infoLabel" Text=""></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div id="Div1" class="widget-separator grid-12">
                                    <div class="widget-separator no-border grid-5">
                                        <h4>Vendor List</h4>
                                        <asp:ListBox ID="vendorListListBox" runat="server" CssClass="form form-full"></asp:ListBox>
                                        <asp:Label ID="countVendorLabel" runat="server" Text="Total: 0"></asp:Label>
                                    </div>
                                    <div class="widget-separator no-border grid-2">
                                        <div class="widget-separator grid-12">
                                            <div class="grid-12">
                                                <asp:Button ID="addButton" CssClass="btn btn-submit clickProcessing form form-full"
                                                    runat="server" Text="Add" OnClick="addButton_Click" />
                                            </div>
                                            <div class="grid-12">
                                                <asp:Button ID="removeButton" CssClass="btn btn-warning clickProcessing form form-full"
                                                    runat="server" Text="Remove" OnClick="removeButton_Click" />
                                            </div>
                                        </div>
                                        <div class="widget-separator no-border grid-12">
                                            <div class="grid-12">
                                                <asp:Button ID="addAllButton" CssClass="btn btn-submit clickProcessing form form-full"
                                                    runat="server" Text="Add All" OnClick="addAllButton_Click" />
                                            </div>
                                            <div class="grid-12">
                                                <asp:Button ID="removeAllButton" CssClass="btn btn-warning clickProcessing form form-full"
                                                    runat="server" Text="Remove All" OnClick="removeAllButton_Click" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="widget-separator no-border grid-5">
                                        <h4>Product's Vendor List</h4>
                                        <asp:ListBox ID="productVendorListListBox" runat="server" CssClass="form form-full"></asp:ListBox>
                                        <asp:Label ID="countProductVendorLabel" runat="server" Text="Total: 0"></asp:Label>
                                    </div>
                                </div>
                                <div class="widget-separator no-border grid-3">
                                    <asp:Button ID="saveButton" CssClass="btn btn-success btn-3d clickProcessing" runat="server"
                                        Text="Save" OnClick="saveButton_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="addButton" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="removeButton" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="addAllButton" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="removeAllButton" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="saveButton" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="productVendorButton" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="scriptContent" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">

    <script type="text/javascript">
        
        
        function pageLoad(sender, args) {
            $("#productVendorButton").click(function (e) {
                if (haveOverlay == 0) {
                    MyOverlayStart();
                }
            });

            $.ajax({
                type: "POST",
                url: "/Services/ProductSearch.ashx",
                success: function (d) {
                    var array = [];
                    d.split(';').forEach(function (value) {
                        array.push(value);
                    });
                    $('#productTextBox').typeahead({ source: array });
                }
            });
        }

        $(function () {
            $(".clickProcessing").live("click", function () {
                if (haveOverlay == 0) {
                    MyOverlayStart();
                }
            });
        });
    </script>
</asp:Content>
