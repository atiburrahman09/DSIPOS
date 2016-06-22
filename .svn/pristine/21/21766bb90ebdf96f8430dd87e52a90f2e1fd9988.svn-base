<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true"
    CodeBehind="View.aspx.cs" Inherits="lmxIpos.UI.SalesCenter.View" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
    <link href="/Content/Style/CSSPages/ViewDetail.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="false">
        <ContentTemplate>
            <div class="title-sitemap grid-12">
                <h1 class="grid-6">
                    <i>&#xf132;</i>View Sales Center<span>Created Sales Center View</span></h1>
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
                                View Sales Center of <asp:Label ID="idLabel" runat="server" Text=""></asp:Label></h3>
                    </header>
                    <div class="widget-body no-padding">
                        <div class="widget-separator grid-6">
                            <div class="grid-4">
                                Sales Center Name:
                            </div>
                            <div class="grid-8">
                                <asp:Label ID="salesCenterNameLabel" CssClass="infoLabel" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        <div class="widget-separator grid-6">
                            <div class="grid-4">
                                Country:
                            </div>
                            <div class="grid-8">
                                <asp:Label ID="countryLabel" CssClass="infoLabel" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        <div class="widget-separator grid-6">
                            <div class="grid-4">
                                City:
                            </div>
                            <div class="grid-8">
                                <asp:Label ID="cityLabel" CssClass="infoLabel" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        <div class="widget-separator grid-6">
                            <div class="grid-4">
                                District:
                            </div>
                            <div class="grid-8">
                                <asp:Label ID="districtLabel" CssClass="infoLabel" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        <div class="widget-separator grid-6">
                            <div class="grid-4">
                                Postal Code:
                            </div>
                            <div class="grid-8">
                                <asp:Label ID="postalCodeLabel" CssClass="infoLabel" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        <div class="widget-separator grid-6">
                            <div class="grid-4">
                                Phone:
                            </div>
                            <div class="grid-8">
                                <asp:Label ID="phoneLabel" CssClass="infoLabel" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        <div class="widget-separator grid-6">
                            <div class="grid-4">
                                Mobile:
                            </div>
                            <div class="grid-8">
                                <asp:Label ID="mobileLabel" CssClass="infoLabel" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        <div class="widget-separator grid-6">
                            <div class="grid-4">
                                Fax:
                            </div>
                            <div class="grid-8">
                                <asp:Label ID="faxLabel" CssClass="infoLabel" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        <div class="widget-separator grid-6">
                            <div class="grid-4">
                                Warehouse Name:
                            </div>
                            <div class="grid-8">
                                <asp:Label ID="warehouseLabel" CssClass="infoLabel" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        <div class="widget-separator grid-6">
                            <div class="grid-4">
                                Email:
                            </div>
                            <div class="grid-8">
                                <asp:Label ID="emailLabel" CssClass="infoLabel" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        <div class="widget-separator no-border grid-12">
                            <div class="grid-2">
                                Address:
                            </div>
                            <div class="grid-10">
                                <asp:Label ID="addressLabel" CssClass="infoLabel" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="salesCenterIdForViewHiddenField" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="scriptContent" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
</asp:Content>
