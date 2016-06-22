﻿<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true" EnableEventValidation="false"
    CodeBehind="Create.aspx.cs" Inherits="lmxIpos.UI.SalesCenter.Create" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="false">
        <ContentTemplate>
            <div class="title-sitemap grid-12">
                <h1 class="grid-6">
                    <i>&#xf132;</i>Create Sales Center<span>Creating Sales Center</span></h1>
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
                            Create Sales Center Form</h3>
                    </header>
                    <div class="widget-body no-padding">
                        <div class="widget-separator no-padding grid-12">
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">
                                    Sales Center Name<span class="text-error">*</span></h5>
                                <asp:TextBox ID="salesCenterNameTextBox" required="required" runat="server" CssClass="form form-full"
                                    placeholder="Sales Center Name"></asp:TextBox>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">
                                    Country</h5>
                                <asp:TextBox ID="countryTextBox" runat="server" CssClass="form form-full" placeholder="Country"></asp:TextBox>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">
                                    City</h5>
                                <asp:TextBox ID="cityTextBox" runat="server" CssClass="form form-full" placeholder="City"></asp:TextBox>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">
                                    Address</h5>
                                <asp:TextBox ID="addressTextBox" required="required" runat="server" CssClass="form form-full"
                                    placeholder="Address"></asp:TextBox>
                            </div>
                            <%--  <div class="widget-separator no-border grid-3">
                                <h5 class="typo">
                                    District</h5>
                                <asp:TextBox ID="districtTextBox" runat="server" CssClass="form form-full" placeholder="District"></asp:TextBox>
                            </div>--%>
                            <%--  <div class="widget-separator no-border grid-3">
                                <h5 class="typo">
                                    Postal Code</h5>
                                <asp:TextBox ID="postalCodeTextBox" runat="server" CssClass="form form-full" placeholder="Postal Code"></asp:TextBox>
                            </div>--%>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">
                                    Phone</h5>
                                <asp:TextBox ID="phoneTextBox" runat="server" CssClass="form form-full"
                                    placeholder="Phone"></asp:TextBox>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">
                                    Mobile</h5>
                                <asp:TextBox ID="mobileTextBox" runat="server" CssClass="form form-full"
                                    placeholder="Mobile"></asp:TextBox>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">
                                    Fax</h5>
                                <asp:TextBox ID="faxTextBox" runat="server" CssClass="form form-full" placeholder="Fax"></asp:TextBox>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">
                                    Warehouse Name</h5>
                                <asp:DropDownList ID="warehouseDropDownList" runat="server" CssClass="form form-full" required="required">
                                </asp:DropDownList>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">
                                    Email</h5>
                                <asp:TextBox ID="emailTextBox" runat="server" CssClass="form form-full"
                                    placeholder="Email"></asp:TextBox>
                            </div>
                        </div>
                        <div class="widget-separator no-border grid-12">
                            <asp:Button ID="saveButton" runat="server" Text="Save" CssClass="btn btn-submit btn-3d"
                                OnClick="saveButton_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="saveButton" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="scriptContent" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        function pageLoad(sender, args) {
            $("#saveButton").click(function (e) {

                if (Page_ClientValidate("")) {
                    if (haveOverlay == 0) {
                        MyOverlayStart();
                    }
                }
            });
        }
    </script>
</asp:Content>
