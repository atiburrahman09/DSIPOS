﻿<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true" EnableEventValidation="false"
    CodeBehind="Create.aspx.cs" Inherits="lmxIpos.UI.Vendor.Create" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="false">
        <ContentTemplate>
            <div class="title-sitemap grid-12">
                <h1 class="grid-6">
                    <i>&#xf132;</i>Create Vendor<span>Creating Vendor</span></h1>
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
                        <h3 id="Header3" runat="server" class="widget-header-title">Create Vendor Form</h3>
                    </header>
                    <div class="clearfix"></div>
                    <div class="widget-body no-padding">
                        <div class="widget-separator grid-3">
                            <h5 class="typo">Vendor Name<span class="text-error">*</span></h5>
                            <asp:TextBox ID="vendorNameTextBox" runat="server" CssClass="form form-full" placeholder="Vendor Name" required="required"></asp:TextBox>
                        </div>
                         <div class="widget-separator grid-3">
                            <h5 class="typo">Phone/Cell</h5>
                            <asp:TextBox ID="phoneTextBox" runat="server" CssClass="form form-full" placeholder="Phone/Cell"></asp:TextBox>
                        </div>
                        <div class="widget-separator grid-3">
                            <h5 class="typo">Email</h5>
                            <asp:TextBox ID="emailTextBox" runat="server" CssClass="form form-full" placeholder="Email"></asp:TextBox>
                        </div>
                         <div class="widget-separator grid-3">
                            <h5 class="typo">City/State</h5>
                            <asp:TextBox ID="cityTextBox" runat="server" CssClass="form form-full" placeholder="City"></asp:TextBox>
                        </div>
                        <div class="widget-separator grid-3">
                            <h5 class="typo">Country</h5>
                            <asp:TextBox ID="countryTextBox" runat="server" CssClass="form form-full" placeholder="Country"></asp:TextBox>
                        </div>
                        <div class="widget-separator grid-9">
                            <h5 class="typo">Address</h5>
                            <asp:TextBox ID="addressTextBox" runat="server" CssClass="form form-full" placeholder="Address" required="required"></asp:TextBox>
                        </div>
                        <div class="widget-separator grid-3">
                            <h5 class="typo">Warehouse</h5>
                          <asp:DropDownList ID="warehouseDropDownList" required="required" runat="server" CssClass="form form-full">
                                </asp:DropDownList>
                        </div>
                        <div class="widget-separator grid-3">
                            <h5 class="typo">Sales Center</h5>
                              <asp:DropDownList ID="salescenterDropDownList" required="required" runat="server" CssClass="form form-full">
                                </asp:DropDownList>
                          </div>
                       
                        <%--<div class="widget-separator grid-3">
                            <h5 class="typo">Mobile</h5>
                            <asp:TextBox ID="mobileTextBox" runat="server" CssClass="form form-full" placeholder="Mobile" required="required"></asp:TextBox>
                        </div>--%>
                        <%--<div class="widget-separator grid-3">
                            <h5 class="typo">Fax</h5>
                            <asp:TextBox ID="faxTextBox" runat="server" CssClass="form form-full" placeholder="Fax"></asp:TextBox>
                        </div>--%>
                        
                       
                        <div class="widget-separator no-border grid-12">
                            <asp:Button ID="saveButton" runat="server" Text="Save" CssClass="btn btn-submit btn-3d"
                                OnClick="saveButton_Click" />
                              <asp:Button ID="SaveandAddMoreButton" runat="server" Text="Save and Add more" CssClass="btn  btn-3d"
                                OnClick="saveButton_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="saveButton" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="SaveandAddMoreButton" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="scriptContent" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
  
    <script type="text/javascript">
        function pageLoad(sender, args) {
            //$("#saveButton").click(function (e) {
             
            //    if (haveOverlay == 0) {
            //        MyOverlayStart();
            //    }
            //});
        }
    </script>
</asp:Content>
