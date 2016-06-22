<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true"
    CodeBehind="View.aspx.cs" Inherits="lmxIpos.UI.AccUI.PayToFromCompany.View" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
    <link href="/Content/Style/CSSPages/ViewDetail.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <div class="title-sitemap grid-12">
        <h1 class="grid-7">
            <i>&#xf132;</i>View Pay To/From Company<span>Created Pay To/From Company View</span></h1>
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
        <div class="widget no-padding">
            <header class="widget-header">
                        <div class="widget-header-icon">
                            </div>
                        <h3 id="Header3" runat="server" class="widget-header-title">
                           View Pay To/From Company of <asp:Label ID="idLabel" runat="server" Text=""></asp:Label></h3>
                    </header>
            <div class="widget-body no-padding">
                <div class="widget-separator no-border grid-6">
                    <div class="grid-4">
                        Company Name:
                    </div>
                    <div class="grid-8">
                        <asp:Label ID="companyNameLabel" CssClass="infoLabel" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div class="widget-separator no-border grid-6">
                    <div class="grid-4">
                        Description:
                    </div>
                    <div class="grid-8">
                        <asp:Label ID="descriptionLabel" CssClass="infoLabel" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="payToFromCompanyIdForViewHiddenField" runat="server" />
</asp:Content>
<asp:Content ID="scriptContent" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
</asp:Content>
