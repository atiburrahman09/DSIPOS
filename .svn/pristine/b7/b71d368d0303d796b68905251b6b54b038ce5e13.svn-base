<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true" EnableEventValidation="false"
    CodeBehind="ManageProductPrice.aspx.cs" Inherits="lmxIpos.UI.Product.ManageProductPrice" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
    
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional" ChildrenAsTriggers="true">
        <ContentTemplate>
            <div class="title-sitemap grid-12">
                <h1 class="grid-6">
                    <i>&#xf132;</i>Manage Product Price<span>Managing Product Price</span></h1>
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
                        <h3 id="Header3" runat="server" class="widget-header-title">System of Manage Product Price</h3>
                    </header>
                    <div class="widget-body no-padding">
                        <div class="widget-separator no-padding grid-12">
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Product By [Barcode, ID, Name]</h5>
                                <asp:TextBox ID="productTextBox" runat="server" CssClass="form form-full" placeholder="Product By [Barcode, ID, Name]"></asp:TextBox>
                            </div>
                            <div class="widget-separator no-border grid-4" style="margin-top: 29px;">
                                <asp:Button ID="searchProductButton" runat="server" Text="Search Product" CssClass="btn btn-info"
                                    OnClick="searchProductButton_Click" />
                                <asp:Button ID="allProductListButton" runat="server" Text="Get All Product List" Visible="true"
                                    CssClass="btn btn-info" OnClick="allProductListButton_Click" />
                            </div>
                            <div class="widget-separator no-border grid-2">
                                &nbsp;
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Filter By Product Group Name / All</h5>
                                <asp:DropDownList ID="productGroupDropDownList" runat="server" AutoPostBack="true"
                                    OnSelectedIndexChanged="productGroupDropDownList_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="grid-12">
                            <div id="productPriceListGridContainer">
                                <asp:GridView ID="productPriceListGridView" runat="server" AutoGenerateColumns="false"
                                    CssClass="table table-hover gridView">
                                    <Columns>
                                        <asp:BoundField DataField="ProductId" HeaderText="Product ID" />
                                        <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                                        <asp:BoundField DataField="Barcode" HeaderText="Barcode" />
                                        <asp:BoundField DataField="ProductGroupName" HeaderText="Product Group" />
                                        <%--<asp:BoundField DataField="LastUnitPrice" HeaderText="Unit Cost" />--%>
                                        <asp:TemplateField HeaderText="Buy Price">
                                            <ItemTemplate>
                                                <asp:TextBox ID="buyPriceTextBox" Width="60" runat="server" CssClass="buyPriceTextBox validQty" Text='<%#Eval("LastUnitPrice").ToString() %>'></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Sale Price">
                                            <ItemTemplate>
                                                <asp:TextBox ID="newPriceTextBox" Width="60" runat="server" CssClass="newPriceTextBox validQty" Text='<%#Eval("RatePerUnit").ToString() %>'></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Discount(%)">
                                            <ItemTemplate>
                                                <asp:TextBox ID="newVATPercentageTextBox" Width="60" runat="server" CssClass="" Text='<%#Eval("VATPercentage").ToString() %>'></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
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
                        <div class="widget-separator text-center grid-12">
                            <asp:Button ID="updateButton" CssClass="btn btn-submit btn-large btn-3d" runat="server" Text="Update Price(s)" Enabled="false"
                                OnClick="updateButton_Click" />
                        </div>
                        <div class="widget-separator no-border grid-12">
                            Overall Discount(%):
                            <asp:TextBox ID="overallVATTextBox" runat="server"></asp:TextBox>
                            <asp:CompareValidator ID="CompareValidator3" runat="server" ErrorMessage="*" ControlToValidate="overallVATTextBox"
                                ValidationGroup="2" Type="Currency" Operator="DataTypeCheck" ForeColor="Red"
                                Visible="true"> </asp:CompareValidator>
                            <asp:Button ID="updateAVGvatButton" CssClass="btn btn-submit btn-3d" runat="server"
                                Text="Update Overall Discount" OnClick="updateAVGvatButton_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="updateButton" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="updateAVGvatButton" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="productPriceListGridView" EventName="RowDataBound" />
            <asp:AsyncPostBackTrigger ControlID="searchProductButton" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="allProductListButton" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="productGroupDropDownList" EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="scriptContent" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        function pageLoad(sender, args) {
            var checkedRowCount = 0;
            $(":checkbox").prop("autocomplete", "off");
            $(".newPriceTextBox").prop("autocomplete", "off");
            $(".buyPriceTextBox").prop("autocomplete", "off");

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

            $("#productPriceListGridView").dataTable({
                "bProcessing": true,
                "sPaginationType": "full_numbers",
                "aLengthMenu": [[10, 15, 20, 25, 50, 100, -1], [10, 15, 20, 25, 50, 100, "All"]],
                "iDisplayLength": 10,

                "bInfo": true
            });

            $("#productPriceListGridView_wrapper .row-fluid:nth-child(1)").css("display", "none");

            $("#allProductListButton").click(function () {
                if (haveOverlay == 0) {
                    MyOverlayStart();
                }
            });

            $("#searchProductButton").click(function (e) {
                if (haveOverlay == 0) {
                    MyOverlayStart();
                }
            });

            $("#updateAVGvatButton").click(function (e) {
                if (haveOverlay == 0) {
                    MyOverlayStart();
                }
            });

            $("#productGroupDropDownList").on("change", function () {
                if (haveOverlay == 0) {
                    MyOverlayStart();
                }
            });

            $(".validQty").on("change keyup", function () {
                if ($(this).val() != "" && !isNaN($(this).val()) && ($(this).val() == parseInt($(this).val())) && $(this).val() > 0) {
                    $(this).removeClass("validGridControl");
                } else {
                    $(this).addClass("validGridControl");
                }
            });

            $("#updateButton").click(function (e) {
                var countGridValid = 0;

                $(".validQty").each(function () {
                    if ($(this).parent().parent().find("#selectCheckBox").is(":checked") && ($(this).val() == "" || isNaN($(this).val()) || ($(this).val() != parseFloat($(this).val())) || $(this).val() < 0)) {
                        $(this).addClass("validGridControl");
                        countGridValid++;
                    } else {
                        $(this).removeClass("validGridControl");
                    }
                });

                if (checkedRowCount < 1) {
                    e.preventDefault();
                    ValidationAlert("No Product is selected to update product price.");
                }

                if (countGridValid > 0) {
                    //return false;
                    e.preventDefault();
                    //$("#form1").valid();
                    ValidationAlert("Some required field(s) are left blank or invalid inside the Product Price List table, please follow the field(s).");

                    $("html, body").animate({
                        scrollTop: $("#productPriceListGridContainer").offset().top - 110
                    }, 500);
                }

                if (haveOverlay == 0) {
                    MyOverlayStart();
                }
            });
        }
    </script>
</asp:Content>
