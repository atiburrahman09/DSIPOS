<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true"
    CodeBehind="View.aspx.cs" Inherits="lmxIpos.UI.Product.View" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
    <link href="/Content/Style/CSSPages/ViewDetail.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="false">
        <ContentTemplate>
            <div class="title-sitemap grid-12">
                <h1 class="grid-6">
                    <i>&#xf132;</i>Product View<span>Created Product View</span></h1>
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
                            View Product of <asp:Label ID="idLabel" runat="server" Text=""></asp:Label></h3>
                    </header>
                    <div class="clearfix"></div>
                    <div class="widget-body no-padding">
                        <div class="widget-separator grid-6">
                            <div class="grid-4">
                                Barcode/Code:
                            </div>
                            <div class="grid-8">
                                <asp:Label ID="barcodeLabel" CssClass="infoLabel form form-full" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        <div class="widget-separator grid-6">
                            <div class="grid-4">
                                Product Name (Only):
                            </div>
                            <div class="grid-8">
                                <asp:Label ID="productNameOnlyLabel" CssClass="infoLabel form form-full" runat="server"
                                    Text=""></asp:Label>
                            </div>
                        </div>
                        <div class="widget-separator grid-6">
                            <div class="grid-4">
                                Product Volume:
                            </div>
                            <div class="grid-8">
                                <asp:Label ID="productVolumeLabel" CssClass="infoLabel form form-full" runat="server"
                                    Text=""></asp:Label>
                            </div>
                        </div>
                        <div class="widget-separator grid-6">
                            <div class="grid-4">
                                Per Unit Volume Quantity:
                            </div>
                            <div class="grid-8">
                                <asp:Label ID="volumeQuantityLabel" CssClass="infoLabel form form-full" runat="server"
                                    Text=""></asp:Label>
                            </div>
                        </div>
                        <div class="widget-separator grid-6">
                            <div class="grid-4">
                                Unit:
                            </div>
                            <div class="grid-8">
                                <asp:Label ID="unitLabel" CssClass="infoLabel form form-full" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        <div class="widget-separator grid-6">
                            <div class="grid-4">
                                Product Group:
                            </div>
                            <div class="grid-8">
                                <asp:Label ID="productGroupLabel" CssClass="infoLabel form form-full" runat="server"
                                    Text=""></asp:Label>
                            </div>
                        </div>
                        <div class="widget-separator no-border grid-6">
                            <div class="grid-4">
                                Product Rate:
                            </div>
                            <div class="grid-8">
                                <asp:Label ID="productRateLabel" CssClass="infoLabel form form-full" runat="server"
                                    Text=""></asp:Label>
                            </div>
                        </div>
                        <div class="widget-separator no-border grid-6">
                            <div class="grid-4">
                                Warehouse:
                            </div>
                            <div class="grid-8">
                                <asp:Label ID="lblWarehouse" CssClass="infoLabel form form-full" runat="server"
                                    Text=""></asp:Label>
                            </div>
                        </div>
                        <div class="widget-separator no-border grid-6">
                            <div class="grid-4">
                                Sales Center:
                            </div>
                            <div class="grid-8">
                                <asp:Label ID="lblSalesCenter" CssClass="infoLabel form form-full" runat="server"
                                    Text=""></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="productIdForViewHiddenField" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="scriptContent" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
</asp:Content>
