<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true"
    CodeBehind="View.aspx.cs" Inherits="lmxIpos.UI.AccUI.ChartOfAccount.View" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
    <link href="/Content/Style/CSSPages/ViewDetail.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <div class="title-sitemap grid-12">
        <h1 class="grid-6">
            <i>&#xf132;</i>View Chart Of Account<span>Created Chart Of Account View</span></h1>
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
                            View Chart Of Account of <asp:Label ID="idLabel" runat="server" Text=""></asp:Label></h3>
                    </header>
            <div class="widget-body no-padding">
                <div class="widget-separator no-padding no-border grid-12">
                    <div class="widget-separator grid-6">
                        <div class="grid-4">
                            Account Name:
                        </div>
                        <div class="grid-8">
                            <asp:Label ID="accountNameLabel" CssClass="infoLabel" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <div class="widget-separator grid-6">
                        <div class="grid-4">
                            Account Number:
                        </div>
                        <div class="grid-8">
                            <asp:Label ID="accountNumberLabel" CssClass="infoLabel" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <div class="widget-separator grid-6">
                        <div class="grid-4">
                            Account Type:
                        </div>
                        <div class="grid-8">
                            <asp:Label ID="accountTypeLabel" CssClass="infoLabel" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <div class="widget-separator grid-6">
                        <div class="grid-5">
                            Totalling Account Number:
                        </div>
                        <div class="grid-7">
                            <asp:Label ID="totallingAccountNumberLabel" CssClass="infoLabel" runat="server" Text=""></asp:Label>
                            <asp:Label ID="totallingAccountNameLabel" CssClass="infoLabel" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <div class="widget-separator grid-6">
                        <div class="grid-4">
                            Posted:
                        </div>
                        <div class="grid-8">
                            <asp:Label ID="postedLabel" CssClass="infoLabel" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <div class="widget-separator grid-6">
                        <div class="grid-4">
                            Account Level:
                        </div>
                        <div class="grid-8">
                            <asp:Label ID="accountLevelLabel" CssClass="infoLabel" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <div class="widget-separator grid-6">
                        <div class="grid-4">
                            Use As:
                        </div>
                        <div class="grid-8">
                            <asp:Label ID="useAsLabel" CssClass="infoLabel" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <div class="widget-separator grid-6">
                        <div class="grid-4">
                            Bank Account Number:
                        </div>
                        <div class="grid-8">
                            <asp:Label ID="bankAccountNumberLabel" CssClass="infoLabel" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <div class="widget-separator grid-6">
                        <div class="grid-4">
                            Description:
                        </div>
                        <div class="grid-8">
                            <asp:Label ID="descriptionLabel" CssClass="infoLabel" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <div class="widget-separator grid-6">
                        <div class="grid-4">
                            Group 1:
                        </div>
                        <div class="grid-8">
                            <asp:Label ID="group1Label" CssClass="infoLabel" runat="server" Text=""></asp:Label>
                            <asp:Label ID="group1NameLabel" CssClass="infoLabel" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <div class="widget-separator grid-6">
                        <div class="grid-4">
                            Group 2:
                        </div>
                        <div class="grid-8">
                            <asp:Label ID="group2Label" CssClass="infoLabel" runat="server" Text=""></asp:Label>
                            <asp:Label ID="group2NameLabel" CssClass="infoLabel" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <div class="widget-separator grid-6">
                        <div class="grid-4">
                            Group 3:
                        </div>
                        <div class="grid-8">
                            <asp:Label ID="group3Label" CssClass="infoLabel" runat="server" Text=""></asp:Label>
                            <asp:Label ID="group3NameLabel" CssClass="infoLabel" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <div class="widget-separator no-border grid-6">
                        <div class="grid-4">
                            Group 4:
                        </div>
                        <div class="grid-8">
                            <asp:Label ID="group4Label" CssClass="infoLabel" runat="server" Text=""></asp:Label>
                            <asp:Label ID="group4NameLabel" CssClass="infoLabel" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <div class="widget-separator no-border grid-6">
                        <div class="grid-4">
                            Group 5:
                        </div>
                        <div class="grid-8">
                            <asp:Label ID="group5Label" CssClass="infoLabel" runat="server" Text=""></asp:Label>
                            <asp:Label ID="group5NameLabel" CssClass="infoLabel" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="chartOfAccountIdForViewHiddenField" runat="server" />
</asp:Content>
<asp:Content ID="scriptContent" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
</asp:Content>
