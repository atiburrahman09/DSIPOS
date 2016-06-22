<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true"
    CodeBehind="View.aspx.cs" Inherits="lmxIpos.UI.User.View" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
    <link href="/Content/Style/CSSPages/ViewDetail.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <div class="title-sitemap grid-12">
        <h1 class="grid-6">
            <i>&#xf132;</i>Profile View<span>Created User Profile View</span></h1>
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
                            View Profile of <asp:Label ID="idLabel" runat="server" Text=""></asp:Label></h3>
                    </header>
            <div class="widget-body no-padding">
                <div class="widget-separator grid-6">
                    <div class="grid-4">
                        User ID:
                    </div>
                    <div class="grid-8">
                        <asp:Label ID="userIdLabel" CssClass="infoLabel" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div class="widget-separator grid-6">
                    <div class="grid-4">
                        User Name:
                    </div>
                    <div class="grid-8">
                        <asp:Label ID="userNameLabel" CssClass="infoLabel" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div class="widget-separator grid-6">
                    <div class="grid-4">
                        User Group:
                    </div>
                    <div class="grid-8">
                        <asp:Label ID="userGroupLabel" CssClass="infoLabel" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div class="widget-separator grid-6">
                    <div class="grid-4">
                        Employee ID:
                    </div>
                    <div class="grid-8">
                        <asp:Label ID="employeeIdLabel" CssClass="infoLabel" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                
                <div class="widget-separator grid-6">
                    <div class="grid-4">
                        Department:
                    </div>
                    <div class="grid-8">
                        <asp:Label ID="departmentLabel" CssClass="infoLabel" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div class="widget-separator grid-6">
                    <div class="grid-4">
                        Designation:
                    </div>
                    <div class="grid-8">
                        <asp:Label ID="designationLabel" CssClass="infoLabel" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div class="widget-separator grid-6">
                    <div class="grid-4">
                        Contact Number:
                    </div>
                    <div class="grid-8">
                        <asp:Label ID="contactNumberLabel" CssClass="infoLabel" runat="server" Text=""></asp:Label>
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
                <div class="widget-separator grid-6">
                    <div class="grid-4">
                        National ID:
                    </div>
                    <div class="grid-8">
                        <asp:Label ID="nationalIdLabel" CssClass="infoLabel" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div class="widget-separator grid-6">
                    <div class="grid-4">
                        Passport Number:
                    </div>
                    <div class="grid-8">
                        <asp:Label ID="passportNumberLabel" CssClass="infoLabel" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div class="widget-separator grid-12">
                    <div class="grid-4">
                        Address:
                    </div>
                    <div class="grid-8">
                        <asp:Label ID="addressLabel" CssClass="infoLabel" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="userIdForViewHiddenField" runat="server" />
</asp:Content>
<asp:Content ID="scriptContent" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
</asp:Content>
