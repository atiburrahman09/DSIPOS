﻿<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true" EnableEventValidation="false"
    CodeBehind="UpdateDebitVoucherCash.aspx.cs" Inherits="lmxIpos.UI.AccUI.DebitVoucher.UpdateDebitVoucherCash" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="True">
        <ContentTemplate>
            <div class="title-sitemap grid-12">
                <h1 class="grid-6">
                    <i>&#xf132;</i>Update D.V. Cash<span>Updating D.V. Cash</span></h1>
                <div class="sitemap grid-6">
                    <%--<ul>
                        <li><span>IPOS</span><i>/</i></li>
                        <li><a href="/Default.aspx">Dashboard</a></li>
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
                        <h3 id="Header3" runat="server" class="widget-header-title">Update Debit Voucher Cash of
                            <asp:Label ID="numberLabel" runat="server" Text=""></asp:Label></h3>
                    </header>
                    <div class="widget-body no-padding">
                        <div class="grid-12">
                            <div class="widget-separator grid-3">
                                <h5 class="typo">Account Head
                                </h5>
                                <asp:DropDownList ID="accountHeadDropDownList" runat="server" CssClass="form form-full">
                                </asp:DropDownList>
                            </div>
                            <div class="widget-separator grid-3">
                                <h5 class="typo">Amount
                                </h5>
                                <asp:TextBox ID="amountTextBox" runat="server" CssClass="form form-full"></asp:TextBox>
                            </div>
                            <div class="widget-separator grid-3">
                                <h5 class="typo">Cash Account Head
                                </h5>
                                <asp:DropDownList ID="cashAccountHeadDropDownList" runat="server" CssClass="form form-full">
                                </asp:DropDownList>
                            </div>
                            <div class="widget-separator grid-3">
                                <h5 class="typo">Voucher Number
                                </h5>
                                <asp:TextBox ID="voucherNumberTextBox" runat="server" CssClass="form form-full"></asp:TextBox>
                            </div>
                            <div class="widget-separator grid-3">
                                <h5 class="typo">Pay To/From
                                </h5>
                                <asp:DropDownList ID="payToFromTypeDropDownList" AutoPostBack="True" runat="server" CssClass="form form-full"
                                    required="required" OnSelectedIndexChanged="payToFromTypeDropDownList_SelectedIndexChanged">
                                    <asp:ListItem Value="">Select Please</asp:ListItem>
                                    <asp:ListItem Value="com">Company</asp:ListItem>
                                    <asp:ListItem Value="ven">Vendor</asp:ListItem>
                                    <asp:ListItem Value="cus">Customer</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="widget-separator grid-3">
                                <h5 class="typo">
                                    <asp:Label ID="lblPaytoFromType" runat="server" Text=""></asp:Label>
                                    &nbsp;
                                </h5>
                                <asp:DropDownList ID="payToFromCompanyDropDownList" runat="server" CssClass="form form-full"
                                    required="required">
                                </asp:DropDownList>
                            </div>
                            <div class="widget-separator grid-9">
                                <h5 class="typo">Narration
                                </h5>
                                <asp:TextBox ID="narrationTextBox" runat="server" CssClass="form form-full"></asp:TextBox>
                            </div>
                        </div>
                        <div class="widget-separator grid-12">
                            <div class="grid-2">
                                Amount in Word:
                            </div>
                            <div class="grid-10">
                                <asp:Label ID="Label1" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                            </div>
                        </div>
                         <div class="widget-separator grid-3">
                                <div class="grid-12">
                                    <h5 class="typo">Account On</h5>
                                </div>
                                <div class="grid-11">
                                    <asp:DropDownList ID="drpdwnAccountOn" runat="server" OnSelectedIndexChanged="drpdwnAccountOn_SelectedIndexChanged"
                                        AutoPostBack="true">
                                        <asp:ListItem>Sales Center</asp:ListItem>
                                        <asp:ListItem>Warehouse</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="widget-separator grid-3">
                                <div class="grid-12">
                                    <h5 class="typo">
                                        <asp:Label runat="server" Text="Sales Center Name" ID="titleSalesCenterOrWarehouse"></asp:Label>
                                    </h5>
                                </div>
                                <div class="grid-11">
                                    <asp:DropDownList ID="drpdwnSalesCenterOrWarehouse" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        <div class="widget-separator no-border grid-12">
                            <asp:Button ID="updateButton" runat="server" Text="Update" CssClass="btn btn-submit btn-3d"
                                OnClick="updateButton_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="journalNumberForUpdateHiddenField" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="scriptContent" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        function pageLoad(sender, args) {
            $("#updateButton").click(function (e) {
                $("#accountHeadDropDownList").rules("add", {
                    required: true
                });

                $("#amountTextBox").rules("add", {
                    required: true,
                    number: true
                });

                $("#cashAccountHeadDropDownList").rules("add", {
                    required: true
                });

                $("#voucherNumberTextBox").rules("add", {
                    required: true
                });

                $("#payToFromCompanyDropDownList").rules("add", {
                    required: true
                });

                $("#narrationTextBox").rules("add", {
                    required: true
                });

                if (haveOverlay == 0) {
                    MyOverlayStart();
                }
            });
        }
    </script>
</asp:Content>
