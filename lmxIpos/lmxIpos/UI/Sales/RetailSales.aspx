﻿<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true" EnableEventValidation="false"
    CodeBehind="RetailSales.aspx.cs" Inherits="lmxIpos.UI.Sales.RetailSales" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
    <link href="/content/css/pagecss/retailsales.css" rel="stylesheet" type="text/css" />
    <style>
        #selectedProductListGridView tr td:nth-child(4) {
            font-weight: bold;
        }
    </style>
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="true">
        <ContentTemplate>
            <div class="title-sitemap grid-12">
                <h1 class="grid-9">
                    <i>&#xf132;</i>Retail Sales<span>Creating Sales Record for </span><span class="text-error">
                        <asp:Label ID="lblSalesCenterName" Font-Bold="true" ForeColor="Red" Font-Size="14px" runat="server" Text="Label"></asp:Label>[<asp:Label ID="lblSalescenterId" Font-Bold="true" ForeColor="Red" Font-Size="12px" runat="server" Text="Label"></asp:Label>]
                    </span></h1>
                <div class="sitemap grid-3">
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
                        <h3 id="Header3" runat="server" class="widget-header-title">Create Sales Order Form</h3>
                    </header>
                    <div class="widget-body no-padding">
                        <div class="widget-separator grid-12">
                            <div class="widget-separator no-border grid-3">
                                <%--<h5 class="typo">
                                    Product By [Barcode, ID, Name]</h5>--%>
                                <asp:TextBox ID="productTextBox" onfocus="this.select()" runat="server" CssClass="form form-full" placeholder="Product By [Barcode, ID, Name]"></asp:TextBox>
                            </div>
                            <div class="widget-separator no-border grid-4" style="padding-top: 3px;">
                                <asp:Button ID="addProductButton" CssClass="btn btn-info" runat="server" Text="Add Product"
                                    OnClick="addProductButton_Click" />
                                <asp:Button ID="addFromListButton" CssClass="btn btn-success" runat="server" Text="Add from List"
                                    OnClientClick="return false;" />
                            </div>
                        </div>

                        <div class="widget-separator grid-12">
                            <div id="selectedProductListGridContainer">
                                <asp:GridView ID="selectedProductListGridView" runat="server" AutoGenerateColumns="false"
                                    CssClass="table table-hover gridView ">
                                    <Columns>
                                        <asp:BoundField DataField="Barcode" HeaderText="Barcode" HtmlEncode="false" />
                                        <asp:BoundField DataField="ProductId" HeaderText="Product ID" />
                                        <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                                        <asp:BoundField DataField="FreeQuantity" HeaderText="Available" />
                                        <asp:BoundField DataField="Unit" HeaderText="Unit" />
                                        <asp:TemplateField HeaderText="Quantity">
                                            <ItemTemplate>
                                                <asp:TextBox ID="orderQuantityTextBox" onfocus="this.select()" runat="server" Width="40" CssClass="oQty-rpu-amt-cal validQty autoCompeleteOff"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Rate">
                                            <ItemTemplate>
                                                <asp:TextBox ID="ratePerUnitTextBox" onfoucs="this.select()" runat="server" Width="60" CssClass="oQty-rpu-amt-cal autoCompeleteOff"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="VATPercentage" HeaderText="Discount(%)" />
                                        <asp:TemplateField HeaderText="Amount-Bonus">
                                            <ItemTemplate>
                                                <asp:TextBox ID="amountTextBox" runat="server" Width="80" CssClass="read-only autoCompeleteOff"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="" ItemStyle-Width="10">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButton1" runat="server"
                                                    CssClass="btn btn-mini btn-inverse" OnClick="removeLinkButton_Click" Style="align: center;" ToolTip="Remove"><i class="icon icon-remove-sign icon-2x" style="color:#f00;"></i></asp:LinkButton>

                                                <%--  <asp:ImageButton src="/Content/images/remove.png" ID="removeLinkButton" runat="server"
                                                    CssClass="btn btn-mini btn-inverse" OnClick="removeLinkButton_Click" Style="align: center;" />--%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                        <div id="otherInformation" class="widget-separator no-padding grid-12" runat="server" visible="False">
                            <div class="widget-separator grid-12">
                                <div class="grid-8">
                                    <h4 class="typo">Others Sales</h4>
                                </div>
                                <div class="widget-separator no-border grid-12">
                                    <div class="widget-separator no-border grid-4">
                                        <h5 class="typo">Description</h5>
                                        <asp:TextBox ID="txtbxDescription" runat="server" CssClass="form form-full" placeholder="Description">
                                        </asp:TextBox>
                                    </div>
                                    <div class="widget-separator no-border  grid-4">
                                        <h5 class="typo">Amount</h5>
                                        <asp:TextBox ID="txtbxOthersAmount" runat="server" CssClass="form form-full" onfocus="this.select()" Text="0.00" placeholder="Amount"></asp:TextBox>
                                    </div>

                                </div>
                            </div>
                        </div>
                        <div class="widget-separator no-padding grid-12">
                            <%--<div class="widget-separator no-border grid-3">
                                <h5 class="typo">Sales Center</h5>
                               
                                <asp:DropDownList ID="salesCenterDropDownList" runat="server" CssClass="form form-full"></asp:DropDownList>
                            </div>--%>

                            <%--<div class="widget-separator no-border grid-3">
                                <h5 class="typo">LC Number</h5>
                                <asp:TextBox ID="lcNumberTextBox" runat="server" placeholder="LC Number" CssClass="form form-full autoCompeleteOff"></asp:TextBox>
                            </div>--%>
                            <%-- <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Transport Type<span class="text-error">*</span></h5>
                                <asp:DropDownList ID="transportTypeDropDownList" runat="server" CssClass="form form-full">
                                    <asp:ListItem Text="--select Transport Type--" Value=""></asp:ListItem>
                                    <asp:ListItem Text="Road" Value="Road"></asp:ListItem>
                                    <asp:ListItem Text="Ship" Value="Ship"></asp:ListItem>
                                    <asp:ListItem Text="Airplane" Value="Airplane"></asp:ListItem>

                                </asp:DropDownList>
                            </div>--%>
                            <%--<div class="widget-separator no-border grid-3">
                                <h5 class="typo">Shipping Address</h5>
                                <asp:TextBox ID="shippingAddressTextBox" runat="server" placeholder="Shipping Address" CssClass="form form-full autoCompeleteOff"></asp:TextBox>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Billing Address</h5>
                                <asp:TextBox ID="billingAddressTextBox" runat="server" placeholder="Billing Addess" CssClass="form form-full autoCompeleteOff"></asp:TextBox>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Payment Mode<span class="text-error">*</span></h5>
                                <asp:DropDownList ID="paymentModeDropDownList" runat="server" AutoPostBack="true" CssClass="form form-full" OnSelectedIndexChanged="paymentModeDropDownList_SelectedIndexChanged">
                                    <asp:ListItem Text="--select Payment Method--" Value=""></asp:ListItem>
                                    <asp:ListItem Text="Cash" Value="Cash"></asp:ListItem>
                                    <asp:ListItem Text="Cheque" Value="Cheque"></asp:ListItem>

                                </asp:DropDownList>
                            </div>--%>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Payment Mode<span class="text-error">*</span>
                                </h5>
                                <asp:DropDownList ID="paymentModeDropDownList" runat="server" AutoPostBack="True" CssClass="form form-full" OnSelectedIndexChanged="paymentModeDropDownList_SelectedIndexChanged">

                                    <asp:ListItem Value="Cash">Cash</asp:ListItem>
                                    <asp:ListItem Value="Cheque">Cheque</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Account Head<span class="text-error">*</span>
                                </h5>
                                <asp:DropDownList ID="accountHeadDropDownList" runat="server" CssClass="form form-full">
                                </asp:DropDownList>
                            </div>

                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Bank Name</h5>
                                <asp:TextBox ID="bankDropDownList" runat="server" CssClass="cash-cheque form form-full" Enabled="false" placeholder="Bank Name">
                                </asp:TextBox>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Bank Branch</h5>
                                <asp:TextBox ID="bankBranchTextBox" runat="server" placeholder="Bank Branch" CssClass="form form-full autoCompeleteOff" Enabled="false"></asp:TextBox>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Cheque Number</h5>
                                <asp:TextBox ID="chequeNumberTextBox" runat="server" placeholder="Cheque Number" CssClass="form form-full autoCompeleteOff" Enabled="false"></asp:TextBox>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Cheque Date</h5>
                                <asp:TextBox ID="chequeDateTextBox" runat="server" placeholder="Cheque Date" CssClass="date-textbox form form-full autoCompeleteOff" Enabled="false"></asp:TextBox>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Credit Status <span class="text-error">*</span>
                                </h5>
                                <asp:DropDownList ID="drpdwnCreditStatus" runat="server" AutoPostBack="True" CssClass="form form-full" OnSelectedIndexChanged="drpdwnCreditStatus_SelectedIndexChanged">

                                    <asp:ListItem Value="S#0">Short Term (Cash)</asp:ListItem>
                                    <asp:ListItem Value="P#0">Partial Dues (Cash)</asp:ListItem>
                                    <asp:ListItem Value="L#18">Long Term (Cash)</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="widget-separator no-padding grid-12">
                            <div class="grid-6" style="float: right;">
                                <div class="widget-separator" style="padding-top: 8px">
                                    <h4 class="typo">Payment Information</h4>
                                </div>
                                <div class="widget-separator no-border grid-12">
                                    <div class="grid-5">
                                        <h5 class="typo" style="float: right;">Total&nbsp;&nbsp;&nbsp;</h5>
                                    </div>
                                    <div class="grid-4">
                                        <asp:TextBox ID="totalAmountTextBox" CssClass="read-only form form-full" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="grid-3">
                                        <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="Tk. only." ControlToValidate="totalAmountTextBox"
                                            ValidationGroup="2" Type="Currency" Operator="DataTypeCheck" ForeColor="Red" Display="Dynamic" Font-Size="Small"
                                            Visible="true"> </asp:CompareValidator>
                                    </div>

                                </div>
                                <div class="widget-separator no-border grid-12">
                                    <div class="grid-5">
                                        <h5 class="typo" style="float: right;">Discount&nbsp;&nbsp;&nbsp;</h5>
                                    </div>
                                    <div class="grid-4">
                                        <asp:TextBox ID="discountTextBox" onfocus="this.select()" CssClass="form form-full autoCompeleteOff" PlaceHolder="0.00"
                                            runat="server"></asp:TextBox>
                                    </div>
                                    <div class="grid-3">
                                        <asp:CompareValidator ID="CompareValidator3" runat="server" ErrorMessage="Tk. only" ControlToValidate="discountTextBox"
                                            ValidationGroup="2" Type="Currency" Operator="DataTypeCheck" ForeColor="Red" Display="Dynamic" Font-Size="Small"
                                            Visible="true"> </asp:CompareValidator>
                                    </div>
                                </div>
                                <div class="widget-separator no-border grid-12">
                                    <div class="grid-5">
                                        <h5 class="typo" style="float: right;">Discount (%)&nbsp;<span class="text-error">*</span> </h5>
                                    </div>
                                    <div class="grid-4 control-group input-append">
                                        <asp:TextBox ID="txtbxdiscountPer" CssClass="autoCompeleteOff" Width="40%" onfocus="this.select()" PlaceHolder="Discount (%)"
                                            runat="server"></asp:TextBox>
                                        <asp:TextBox ID="txtbxTotalDiscount" CssClass="autoCompeleteOff" onfocus="this.select()" Width="44%" PlaceHolder="0.00" ReadOnly="true"
                                            runat="server"></asp:TextBox>
                                    </div>
                                    <div class="grid-3">
                                        <asp:CompareValidator ID="CompareValidator4" runat="server" ErrorMessage="*" ControlToValidate="txtbxdiscountPer"
                                            ValidationGroup="2" Type="Double" Operator="DataTypeCheck" ForeColor="Red" Display="Dynamic" Font-Size="Small"
                                            Visible="true"> </asp:CompareValidator>
                                        <%--  <asp:CompareValidator ID="CompareValidator5" runat="server" ErrorMessage="*" ControlToValidate="receivedAmountTextBox"
                                            ValidationGroup="2" Type="Currency" Operator="DataTypeCheck" ForeColor="Red"
                                            Visible="true"> </asp:CompareValidator>--%>
                                    </div>
                                </div>
                                <div class="widget-separator no-border grid-12">
                                    <div class="grid-5">
                                        <h5 class="typo" style="float: right;">Service Charge&nbsp;&nbsp;&nbsp</h5>
                                    </div>
                                    <div class="grid-4">
                                        <asp:TextBox ID="txtbxServiceCharge" onfocus="this.select()" CssClass="form form-full autoCompeleteOff" PlaceHolder="0.00"
                                            runat="server"></asp:TextBox>
                                    </div>
                                    <div class="grid-3">
                                        <asp:CompareValidator ID="CompareValidator5" runat="server" ErrorMessage="Tk. only" ControlToValidate="txtbxServiceCharge"
                                            ValidationGroup="2" Type="Currency" Operator="DataTypeCheck" ForeColor="Red" Display="Dynamic" Font-Size="Small"
                                            Visible="true"> </asp:CompareValidator>
                                    </div>
                                </div>
                                <div class="widget-separator no-border grid-12">
                                    <div class="grid-5">
                                        <h5 class="typo" style="float: right;">Service Charge(%)&nbsp;<span class="text-error">*</span></h5>
                                    </div>
                                    <div class="grid-4 control-group input-append">
                                        <asp:TextBox ID="txtbxServicePer" CssClass="autoCompeleteOff" Width="40%" onfocus="this.select()" PlaceHolder="0.00"
                                            runat="server"></asp:TextBox>
                                        <asp:TextBox ID="txtbxServiceChargePercentage" CssClass="autoCompeleteOff" onfocus="this.select()" Width="44%" PlaceHolder="0.00" ReadOnly="true"
                                            runat="server"></asp:TextBox>
                                    </div>
                                    <div class="grid-3">
                                        <asp:CompareValidator ID="CompareValidator7" runat="server" ErrorMessage="*" ControlToValidate="txtbxServicePer"
                                            ValidationGroup="2" Type="Double" Operator="DataTypeCheck" ForeColor="Red" Display="Dynamic" Font-Size="Small"
                                            Visible="true"> </asp:CompareValidator>
                                        <%--  <asp:CompareValidator ID="CompareValidator5" runat="server" ErrorMessage="*" ControlToValidate="receivedAmountTextBox"
                                            ValidationGroup="2" Type="Currency" Operator="DataTypeCheck" ForeColor="Red"
                                            Visible="true"> </asp:CompareValidator>--%>
                                    </div>
                                </div>
                                <div class="widget-separator no-border grid-12">
                                    <div class="grid-5">
                                        <h5 class="typo" style="float: right;">Receivable&nbsp;&nbsp;&nbsp;</h5>
                                    </div>
                                    <div class="grid-4">
                                        <asp:TextBox ID="receivableAmountTextBox" CssClass="form form-full read-only autoCompeleteOff"
                                            PlaceHolder="0.00" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="grid-3">
                                        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Tk. Only" ControlToValidate="receivableAmountTextBox" Display="Dynamic" Font-Size="Small"
                                            ValidationGroup="2" Type="Currency" Operator="DataTypeCheck" ForeColor="Red"
                                            Visible="true"> </asp:CompareValidator>
                                    </div>
                                </div>
                                <div class="widget-separator no-border grid-12">
                                    <div class="grid-5">
                                        <h5 class="typo" style="float: right;">Received<span class="text-error">*</span>&nbsp;&nbsp;&nbsp;</h5>
                                    </div>
                                    <div class="grid-4">
                                        <asp:TextBox ID="receivedAmountTextBox" CssClass="form form-full autoCompeleteOff"
                                            PlaceHolder="0.00" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="grid-3">
                                        <asp:CompareValidator ID="cmpVldCurrency" runat="server" ErrorMessage="Tk. Only" ControlToValidate="receivedAmountTextBox" Display="Dynamic" Font-Size="Small"
                                            ValidationGroup="2" Type="Currency" Operator="DataTypeCheck" ForeColor="Red"
                                            Visible="true"> </asp:CompareValidator>
                                    </div>
                                </div>
                                <div class="widget-separator no-border grid-12">
                                    <div class="grid-5">
                                        <h5 class="typo" style="float: right;">Dues Pay&nbsp;&nbsp;&nbsp;</h5>
                                    </div>
                                    <div class="grid-4">
                                        <asp:TextBox ID="DuesAmoutPayTextBox" ReadOnly="True" CssClass="form form-full autoCompeleteOff"
                                            PlaceHolder="0.00" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="grid-3">
                                        <asp:CompareValidator ID="CompareValidator6" runat="server" ErrorMessage="Tk. Only" ControlToValidate="DuesAmoutPayTextBox" Display="Dynamic" Font-Size="Small"
                                            ValidationGroup="2" Type="Currency" Operator="DataTypeCheck" ForeColor="Red"
                                            Visible="true"> </asp:CompareValidator>
                                    </div>
                                </div>
                                <div class="widget-separator no-border grid-12">
                                    <div class="grid-5">
                                        <h5 class="typo" style="float: right;">Change&nbsp;&nbsp;&nbsp;</h5>
                                    </div>
                                    <div class="grid-4">
                                        <asp:TextBox ID="changeAmountTextBox" ForeColor="red" Font-Size="14px" CssClass="read-only form form-full text-error bold"
                                            runat="server"></asp:TextBox>
                                    </div>
                                    <div class="grid-3">
                                        &nbsp;
                                    </div>
                                </div>
                            </div>
                            <div class="grid-6" style="float: left;">
                                <div class="widget-separator grid-12">
                                    <div class="grid-8">
                                        <h4 class="typo">Customer Information</h4>
                                    </div>
                                    <div class="grid-3">
                                        <asp:Button ID="addCustomerButton" CssClass="btn btn-info" runat="server" Text="Customer from List"
                                            OnClientClick="return false" />
                                    </div>
                                </div>
                                <div class="grid-12" style="border-right: 1px solid #ECECEC;">
                                    <div class="widget-separator grid-6">
                                        <h5 class="typo">Customer ID</h5>
                                        <asp:DropDownList ID="customerIdDropDownList" runat="server" CssClass="form form-full chosen-select"
                                            OnSelectedIndexChanged="customerIdDropDownList_SelectedIndexChanged" AutoPostBack="true">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="widget-separator grid-6">
                                        <h5 class="typo">Customer Name</h5>
                                        <asp:TextBox ID="customerNameTextBox" runat="server" CssClass="customerInfo form form-full"
                                            placeholder="Customer Name"></asp:TextBox>
                                    </div>
                                    <div class="widget-separator grid-6">
                                        <h5 class="typo">Customer Contact Number</h5>
                                        <asp:TextBox ID="customerContactNumberTextBox" runat="server" CssClass="customerInfo form form-full"
                                            placeholder="Customer Contact Number"></asp:TextBox>
                                    </div>
                                    <div class="widget-separator grid-6">
                                        <h5 class="typo">Customer Address</h5>
                                        <asp:TextBox ID="customerAddressTextBox" runat="server" CssClass="customerInfo form form-full"
                                            placeholder="Customer Address"></asp:TextBox>
                                    </div>
                                    <div class="grid-12" id="previousDueDiv" runat="server" visible="false">
                                        <div class="widget-separator grid-6">
                                            <h5 class="typo">Previous Due</h5>
                                            <asp:TextBox ID="previousDueTextBox" runat="server" CssClass="form form-full text-error bold"
                                                placeholder="Previous Due" ReadOnly="true"></asp:TextBox>
                                        </div>
                                        <div class="widget-separator grid-6" style="padding: 24px 50px;">

                                            <asp:Button ID="btnGOtoReceivePaymetn" OnClick="gotoRecievepayment" OnClientClick="window.open('/UI/ReceiveFromCustomer/PaymentByCustomer.aspx')" CssClass="btn btn-mini btn-info " runat="server" Text="Receive Due Amount" />
                                            <%--  <a href="/UI/ReceiveFromCustomer/PaymentByCustomer.aspx" target="_blank" class="label label-info text-center">Receive Payment </a>
                                            --%>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="grid-12 text-center">
                            <%--<div class="grid-5">
                                &nbsp;
                            </div>--%>
                            <%--<div class="widget-separator no-border grid-2">--%>
                            <asp:Button ID="saveButton" CssClass="btn btn-submit btn-3d btn-large" Enabled="false"
                                runat="server" Text="Confirm Sales Record" OnClick="saveButton_Click" ValidationGroup="2" />
                            <%--  </div>--%>
                            <%--<div class="grid-5">
                                &nbsp;
                            </div>--%>
                        </div>
                        <div id="productListModal" class="modal hide fade" style="width: 780px;" tabindex="-1"
                            role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                    &times;</button>
                                <h3>Available Product List
                                </h3>
                            </div>
                            <div class="modal-body">
                                <div id="productListGridContainer">
                                    <asp:GridView ID="productListGridView" runat="server" AutoGenerateColumns="false"
                                        CssClass="table table-hover">
                                        <Columns>
                                            <asp:BoundField DataField="Barcode" HeaderText="Barcode" />
                                            <asp:BoundField DataField="ProductId" HeaderText="Product ID" />
                                            <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                                            <asp:BoundField DataField="Unit" HeaderText="Unit" />
                                            <asp:BoundField DataField="ProductGroupName" HeaderText="Product Group" />
                                            <asp:BoundField DataField="FreeQuantity" HeaderText="Free Qty" />
                                            <asp:BoundField DataField="Price" HeaderText="Sale Rate" />
                                            <asp:BoundField DataField="VATPercentage" HeaderText="VAT(%)" />
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="allCheckBox" runat="server" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="selectCheckBox" runat="server" CssClass="clickCheckBox" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <asp:Button ID="addSelectedProductButton" runat="server" CssClass="btn btn-success"
                                    Text="Add Selected Product(s)" OnClick="addSelectedProductButton_Click" />
                            </div>
                        </div>
                        <div id="customerListModal" class="modal hide fade" style="width: 780px;" tabindex="-1"
                            role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                    &times;</button>
                                <h3>Customer List
                                </h3>
                            </div>
                            <div class="modal-body">
                                <div id="customerListGridContainer">
                                    <asp:GridView ID="customerListGridView" runat="server" AutoGenerateColumns="false"
                                        CssClass="table table-hover">
                                        <Columns>
                                            <asp:BoundField DataField="CustomerId" HeaderText="Customer ID" />
                                            <asp:BoundField DataField="CustomerName" HeaderText="Customer Name" />
                                            <asp:BoundField DataField="ContactNumber" HeaderText="Contact Number" />
                                            <%--<asp:BoundField DataField="Email" HeaderText="Email" />--%>
                                            <asp:BoundField DataField="Address" HeaderText="Address" />
                                            <asp:TemplateField HeaderText="">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="selectCustomerLinkButton" runat="server" CssClass="btn btn-info btn-flat-3d"
                                                        OnClick="selectCustomerLinkButton_Click">Select</asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                            <div class="modal-footer">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="checkedRowCountHiddenField" runat="server" />
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="addProductButton" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="selectedProductListGridView" EventName="RowDataBound" />
            <asp:AsyncPostBackTrigger ControlID="saveButton" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="productListGridView" EventName="RowDataBound" />
            <asp:AsyncPostBackTrigger ControlID="addSelectedProductButton" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="customerListGridView" EventName="RowDataBound" />
            <asp:AsyncPostBackTrigger ControlID="customerIdDropDownList" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="drpdwnCreditStatus" EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:HiddenField ID="totalVATAmountHiddenField" runat="server" />
    <asp:HiddenField ID="totalDiscountAmountHdnField" runat="server" />
    <asp:HiddenField ID="totalServiceChargeHdnField" runat="server" />
    <asp:HiddenField ID="totalSalesHdnFiled" runat="server" />


</asp:Content>
<asp:Content ID="scriptContent" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        function pageLoad(sender, args) {
            var checkedRowCount = $("#checkedRowCountHiddenField").val();
            $('.modal-backdrop').remove();

            if ($("#customerIdDropDownList option:selected").text() != "Retail") {
                $(".customerInfo").attr("disabled", true);
            }

            $(".read-only").attr("ReadOnly", true);
            $(".autoCompeleteOff").attr('autocomplete', 'off');

            $("#addSelectedProductButton").click(function () {
                $("#checkedRowCountHiddenField").val(checkedRowCount);
                $("#form1").validate().currentForm = "";
            });

            $("#addProductButton").click(function () {
                $('input, select, textarea').each(function () {
                    $(this).rules('remove');
                });
            });

            $(".validQty").on("change keyup", function () {
                if ($(this).val() != "" && !isNaN($(this).val()) && ($(this).val() == parseInt($(this).val())) && $(this).val() > 0) {
                    $(this).removeClass("validGridControl");
                } else {
                    $(this).addClass("validGridControl");
                }
            });

            $("#saveButton").click(function (e) {
                var countGridValid = 0;

                $("#productTextBox").rules("remove");

                $(".validQty").each(function () {
                    if ($(this).val() == "" || isNaN($(this).val()) || ($(this).val() != parseInt($(this).val())) || $(this).val() < 1) {
                        $(this).addClass("validGridControl");
                        countGridValid++;
                    }
                });

                if (countGridValid > 0) {
                    //return false;
                    e.preventDefault();
                    $("#form1").valid();
                    alert('Some required field(s) are left blank or invalid inside the Product List table, please follow the field(s).');

                    $("html, body").animate({
                        scrollTop: $("#selectedProductListGridContainer").offset().top - 150
                    }, 500);
                }
            });

            $("#customerIdDropDownList").on("change", function () {
                if ($("#customerIdDropDownList option:selected").text() != "Retail") {
                    $(".customerInfo").attr("disabled", true);
                } else {
                    $(".customerInfo").removeAttr("disabled");
                }
            });

            $.ajax({
                type: "POST",
                url: "/Services/ProductSearchforSale.ashx?id=" + document.getElementById("<%=lblSalescenterId.ClientID %>").innerHTML,

                success: function (d) {
                    var array = [];
                    d.split(';').forEach(function (value) {
                        array.push(value);
                    });
                    $('#productTextBox').typeahead({ source: array });

                }
            });

            $("#selectedProductListGridView").dataTable({
                "bProcessing": true,
                "sPaginationType": "full_numbers",
                "aLengthMenu": [[10, 15, 20, -1], [10, 15, 20, "All"]],
                "iDisplayLength": -1,
                "bSort": false,
                //"aoColumnDefs": [{ 'bSortable': false, 'aTargets': [0, 1, 2, 3, 4, 5, 6, 7]}],
                "bFilter": false,
                "bLengthChange": true,
                "bPaginate": false,
                "bInfo": false
            });

            $("#customerListGridView").dataTable({
                "bProcessing": true,
                "sPaginationType": "full_numbers",
                "aLengthMenu": [[10, 25, 50, -1], [10, 25, 50, "All"]],
                "iDisplayLength": -1,
                "bSort": true,
                //"aoColumnDefs": [{ 'bSortable': false, 'aTargets': [0, 1, 2, 3, 4, 5, 6, 7]}],
                "bFilter": true,
                "bLengthChange": true,
                "bPaginate": true,
                "bInfo": false,
                "bState": true
            });

            $("#selectedProductListGridView_wrapper .row-fluid:nth-child(1)").css("display", "none");

            $("#addFromListButton").click(function () {
                $('#productListModal').modal();
            });

            $("#addCustomerButton").click(function () {
                $('#customerListModal').modal();
            });

            $("#productListGridView").dataTable({
                "bProcessing": true,
                "sPaginationType": "full_numbers",
                "aLengthMenu": [[-1], ["All"]],
                "iDisplayLength": -1,
                "aoColumnDefs": [{ 'bSortable': false, 'aTargets': [5, 6, 7] }],
                "bFilter": true,
                "bLengthChange": true,
                "bPaginate": false,
                "bInfo": true
            });

            $("#allCheckBox").click(function () {
                if ($(this).is(":checked")) {
                    $(".clickCheckBox>#selectCheckBox").prop('checked', true);
                    checkedRowCount = $(".clickCheckBox").length;
                } else {
                    $(".clickCheckBox>#selectCheckBox").prop('checked', false);
                    checkedRowCount = 0;
                }
            });

            $(".clickCheckBox").click(function () {
                if ($(this).find("#selectCheckBox").is(":checked")) {
                    checkedRowCount++;
                    if (checkedRowCount == $(".clickCheckBox").length) {
                        $("#allCheckBox").prop('checked', true);
                    }
                } else {
                    checkedRowCount--;
                    $("#allCheckBox").prop('checked', false);

                    if (checkedRowCount < 1) {
                        checkedRowCount = 0;
                    }
                }
            });

            ////////////////////////// Calculation ////////////////////////////////

            function TotalAmountCalculation() {
                var tAmt = 0;
                $("#selectedProductListGridView tr").each(function () {
                    if (!isNaN(+$(this).find("[id*=amountTextBox]").val())) {
                        tAmt = tAmt + +$(this).find("[id*=amountTextBox]").val();
                    }
                });

                $("#totalSalesHdnFiled").val(tAmt);
                $("#totalAmountTextBox").val(tAmt);
            }

            function OthersCalculation() {
                var netAmt = 0;
                var totalAmt = 0;
                var discount = 0;
                var discountpar = 0;
                var vat = 0;
                var receivable = 0;
                var received = 0;
                var due = 0;
                var change = 0;
                var serviceAmount = 0;
                var ServicePer = 0;

                if (!isNaN(+$("#totalSalesHdnFiled").val())) {
                    totalAmt = $("#totalSalesHdnFiled").val();
                }

                if (!isNaN(+$("#txtbxServiceCharge").val())) {
                    serviceAmount = $("#txtbxServiceCharge").val();
                }

                if (!isNaN(+$("#txtbxOthersAmount").val())) {
                    OthersAmount = $("#txtbxOthersAmount").val();
                }

                if (!isNaN(+$("#discountTextBox").val())) {
                    discount = $("#discountTextBox").val();
                }

                if (!isNaN(+$("#txtbxdiscountPer").val())) {
                    discountpar = $("#txtbxdiscountPer").val();
                }
                if (!isNaN(+$("#txtbxServicePer").val())) {
                    ServicePer = $("#txtbxServicePer").val();
                }


                if (!isNaN(+$("#receivableAmountTextBox").val())) {
                    receivable = $("#receivableAmountTextBox").val();
                }

                if (!isNaN(+$("#receivedAmountTextBox").val())) {
                    received = $("#receivedAmountTextBox").val();
                }

                if (!isNaN(+$("#DuesAmoutPayTextBox").val())) {
                    due = $("#DuesAmoutPayTextBox").val();
                }

                if (!isNaN(+$("#changeAmountTextBox").val())) {
                    change = $("#changeAmountTextBox").val();
                }


                serviceAmount = parseFloat(serviceAmount);
                totalAmt = parseFloat(totalAmt) + parseFloat(OthersAmount);


                if (ServicePer > 0) {
                    serviceAmount = totalAmt * ServicePer / 100;
                }

                if (discountpar > 0) {
                    discount = totalAmt * discountpar / 100;
                }
                netAmt = totalAmt + serviceAmount - discount;

                receivable = netAmt;
                // receivable = netAmt - (netAmt * discountpar / 100) + (netAmt * ServicePer / 100); //for discount (-) or vat (+)
                console.log(netAmt);
                // console.log(receivable);


                $("#totalVATAmountHiddenField").val(netAmt * discountpar / 100);
                $("#receivableAmountTextBox").val(receivable);
                $("#changeAmountTextBox").val(received - receivable);

                //if (due > 0 && due <= change) {
                $("#changeAmountTextBox").val((received - receivable) - due);
                //}
                //$("#changeAmountTextBox").val(received - inTotal);

                $("#totalAmountTextBox").val(totalAmt.toFixed(2));
                $("#txtbxdiscountPer").val(discountpar);
                $("#discountTextBox").val(discount);
                $("#txtbxServiceCharge").val(serviceAmount);
                $("#txtbxServicePer").val(ServicePer);

                $("#txtbxTotalDiscount").val(totalAmt * discountpar / 100);
                $('#txtbxServiceChargePercentage').val(totalAmt * ServicePer / 100);
            }

            $("#discountTextBox").on("change", function () {
                OthersCalculation();
            });
            $("#txtbxServiceCharge").on("change", function () {
                OthersCalculation();
            });
            $("#txtbxdiscountPer").on("change", function () {
                OthersCalculation();
            });
            $("#txtbxServicePer").on("change", function () {
                OthersCalculation();
            });
            $("#receivableAmountTextBox").on("change", function () {
                OthersCalculation();
            });

            $("#receivedAmountTextBox").on("change keyup", function () {
                OthersCalculation();
            });

            $("#DuesAmoutPayTextBox").on("change", function () {
                OthersCalculation();
            });
            $("#txtbxOthersAmount").on("change keyup", function () {
                OthersCalculation();
            });

            $(".oQty-rpu-amt-cal").on("change keyup", function () {
                var qty = +$(this).closest('tr').find("[id*=orderQuantityTextBox]").val();
                var rate = +$(this).closest('tr').find("[id*=ratePerUnitTextBox]").val();
                var vat = $(this).parents().closest('tr').find('td:nth-child(8)').html();
                var amt = qty * rate;
                var amt = amt - (amt * vat / 100);

                $(this).parent().parent().find("[id*=amountTextBox]").val(amt);
                TotalAmountCalculation();
                OthersCalculation();
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
        };

    </script>
</asp:Content>
