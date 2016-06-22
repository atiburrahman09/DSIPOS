<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true" EnableEventValidation="false"
    CodeBehind="DamageRecord.aspx.cs" Inherits="lmxIpos.UI.DamageRecord.DamageRecord" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="true">
        <ContentTemplate>
            <div class="title-sitemap grid-12">
                <h1 class="grid-6">
                    <i>&#xf132;</i>Damage Record<span>Creating Damage Record</span></h1>
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
                        <h3 id="Header3" runat="server" class="widget-header-title">Create Damage Record Form</h3>
                    </header>
                    <div class="widget-body no-padding">
                        <div class="widget-separator no-padding grid-12">
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Check at
                                </h5>
                                <asp:DropDownList ID="chkatDropdownList" runat="server" CssClass="form form-full" OnSelectedIndexChanged="chkatDropdownList_SelectedIndexChanged" AutoPostBack="true"
                                    required="required">
                                    <asp:ListItem Text="--select--" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="Warehouse" Value="WH"></asp:ListItem>
                                    <asp:ListItem Text="Sales Center" Value="SC"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">
                                    <asp:Label ID="wareHouseorSCLabel" runat="server" Text="Warehouse"></asp:Label>
                                </h5>
                                <asp:DropDownList ID="salesCenterDropDownList" runat="server" CssClass="form form-full"
                                    AutoPostBack="true" OnSelectedIndexChanged="salesCenterDropDownList_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Product By [Barcode, ID, Name]</h5>
                                <asp:TextBox ID="productTextBox" runat="server" CssClass="form form-full"></asp:TextBox>
                            </div>
                            <div class="widget-separator no-border grid-3" style="margin-top: 29px;">
                                <asp:Button ID="addProductButton" CssClass="btn btn-info" runat="server" Text="Add Product"
                                    OnClick="addProductButton_Click" />
                                <asp:Button ID="addFromListButton" CssClass="btn btn-success" runat="server" Text="Add from List"
                                    OnClientClick="return false;" />
                            </div>
                        </div>
                        <div class="widget-separator grid-12" style="margin-top: 10px;">
                            <h4>Selected Product List</h4>
                        </div>
                        <div class="grid-12">
                            <div id="selectedProductListGridContainer">
                                <asp:GridView ID="selectedProductListGridView" runat="server" AutoGenerateColumns="false"
                                    CssClass="table table-hover gridView">
                                    <Columns>
                                        <asp:BoundField DataField="Barcode" HeaderText="Barcode" />
                                        <asp:BoundField DataField="ProductId" HeaderText="Product ID" />
                                        <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                                        <asp:BoundField DataField="FreeQuantity" HeaderText="Available" />
                                        <asp:BoundField DataField="Unit" HeaderText="Unit" />
                                        <asp:TemplateField HeaderText="Quantity">
                                            <ItemTemplate>
                                                <asp:TextBox ID="orderQuantityTextBox" runat="server" Width="40" CssClass="oQty-rpu-amt-cal validQty autoCompeleteOff"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Rate">
                                            <ItemTemplate>
                                                <asp:TextBox ID="ratePerUnitTextBox" onfocus="this.select()" runat="server" Width="50" CssClass="oQty-rpu-amt-cal autoCompeleteOff read-only"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="LastUnitPrice" HeaderText="Unit Price" />
                                        <asp:TemplateField HeaderText="Amount">
                                            <ItemTemplate>
                                                <asp:TextBox ID="amountTextBox" runat="server" Width="80" CssClass="read-only autoCompeleteOff"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="removeLinkButton" runat="server" ToolTip="Remove"
                                                    CssClass="btn btn-mini btn-inverse" OnClick="removeLinkButton_Click" Style="align: center;"><i class="icon icon-trash icon-2x" style="color:#f00;"></i></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                        <div class="widget-separator no-padding grid-12">
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Total Amount (As Sale Price)
                                </h5>
                                <asp:TextBox ID="totalAmountTextBox" CssClass="read-only form form-full" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="widget-separator grid-12">
                            <asp:Button ID="saveButton" CssClass="btn btn-submit btn-3d" Enabled="false" runat="server"
                                Text="Save" OnClick="saveButton_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <div id="productListModal" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
                aria-hidden="true" style="width: 760px;">
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
                                <asp:BoundField DataField="Price" HeaderText="Rate" />
                                <asp:BoundField DataField="LastUnitPrice" HeaderText="Unit Price" />
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
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="salesCenterDropDownList" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="addProductButton" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="selectedProductListGridView" EventName="RowDataBound" />
            <asp:AsyncPostBackTrigger ControlID="saveButton" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="productListGridView" EventName="RowDataBound" />
            <asp:AsyncPostBackTrigger ControlID="addSelectedProductButton" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:HiddenField ID="checkedRowCountHiddenField" runat="server" />
</asp:Content>
<asp:Content ID="scriptContent" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        function pageLoad(sender, args) {
            $('.modal-backdrop').remove();
            var checkedRowCount = $("#checkedRowCountHiddenField").val();

            $.ajax({
                type: "POST",
                url: "/Services/ProductSearch.ashx?id=" + $('#salesCenterDropDownList').val(),
                success: function (d) {
                    var array = [];
                    d.split(';').forEach(function (value) {
                        array.push(value);
                    });
                    $('#productTextBox').typeahead({ source: array });
                }
            });

            $(".read-only").attr("ReadOnly", true);
            $(".autoCompeleteOff").attr('autocomplete', 'off');

            $("#addSelectedProductButton").click(function () {
                $("#checkedRowCountHiddenField").val(checkedRowCount);
            });

            $("#addProductButton").click(function () {

            });

            $(".validQty").on("change keyup", function () {
                if ($(this).val() != "" && !isNaN($(this).val()) && ($(this).val() == parseFloat($(this).val())) && $(this).val() > 0) {
                    $(this).removeClass("validGridControl");
                } else {
                    $(this).addClass("validGridControl");
                }
            });

            $("#saveButton").click(function (e) {
                var countGridValid = 0;

                $(".validQty").each(function () {
                    if ($(this).val() == "" || isNaN($(this).val()) || ($(this).val() != parseFloat($(this).val())) || $(this).val() < 1) {
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
                "bInfo": true
            });

            $("#selectedProductListGridView_wrapper .row-fluid:nth-child(1)").css("display", "none");

            $("#addFromListButton").click(function () {
                $('#productListModal').modal();
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

            function TotalAmountCalculation() {
                var tAmt = 0;
                $("#selectedProductListGridView tr").each(function () {
                    if (!isNaN(+$(this).find("[id*=amountTextBox]").val())) {
                        tAmt = tAmt + +$(this).find("[id*=amountTextBox]").val();
                    }
                });

                $("#totalAmountTextBox").val(tAmt);
            }

            $(".oQty-rpu-amt-cal").on("change keyup", function () {
                var qty = +$(this).closest('tr').find("[id*=orderQuantityTextBox]").val();
                var rate = +$(this).closest('tr').find("[id*=ratePerUnitTextBox]").val();
                var amt = qty * rate;

                $(this).parent().parent().find("[id*=amountTextBox]").val(amt);
                TotalAmountCalculation();
            });
        }
    </script>
</asp:Content>
