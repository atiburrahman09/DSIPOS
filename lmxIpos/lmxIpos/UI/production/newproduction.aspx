<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true" CodeBehind="newproduction.aspx.cs" Inherits="lmxIpos.UI.production.newproduction" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel ID="updatePanel" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="title-sitemap grid-12">
                <h1 class="grid-8">

                    <i></i>Production<span>Creating production Record</span></h1>
                <div class="sitemap grid-6">
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
                        <h3 class="widget-header-title" id="Header3">Create production Record Form</h3>
                    </header>
                    <div class="widget-body no-padding">
                        <div class="widget-separator no-padding grid-12">
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Warehouse Name
                                </h5>

                                <asp:DropDownList ID="warehouseDropDownList" required="required" runat="server" CssClass="form form-full" AutoPostBack="True" OnSelectedIndexChanged="warehouseDropDownList_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                            <%--   <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Product By [Barcode, ID, Name]
                                </h5>
                                <asp:TextBox ID="productTextBox" runat="server" CssClass="form form-full" placeholder="Product By [Barcode, ID, Name]"></asp:TextBox>
                            </div>--%>
                            <%-- <div class="widget-separator no-border grid-3" style="margin-top: 28px;">
                                <asp:Button ID="addProductButton" CssClass="btn btn-info" runat="server" Text="Add Product"
                                    OnClick="addProductButton_Click" />
                                <asp:Button ID="addFromListButton" CssClass="btn btn-success" runat="server" Text="Add from List"
                                    OnClientClick="return false;" />
                            </div>--%>
                        </div>
                        <div class="widget-separator no-border grid-12">
                        </div>
                        <div class="widget-separator">
                            <h4>Raw Materials Information   
                                <asp:Button ID="addFromListButton" CssClass="btn btn-success" runat="server" Text="Add from List"
                                    OnClientClick="return false;" />
                            </h4>

                        </div>
                        <div class="grid-12">
                            <div id="purchaseProductListGridContainer">
                                <asp:GridView ID="purchaseProductListGridView" runat="server" AutoGenerateColumns="false"
                                    CssClass="table table-hover dataTable gridView">
                                    <Columns>
                                        <asp:BoundField DataField="Barcode" HeaderText="Barcode" />
                                        <asp:BoundField DataField="ProductId" HeaderText="Product ID" />
                                        <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                                        <asp:BoundField DataField="Unit" HeaderText="Unit" />
                                        <asp:TemplateField HeaderText="Quantity">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtQuantity" Text="1" runat="server" Width="80" CssClass="pQty-rpu-amt-cal"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Rate Per Unit">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtRate" runat="server" Width="80" CssClass="pQty-rpu-amt-cal"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Cost">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtPrice" runat="server" Width="80" CssClass="pQty-rpu-amt-cal"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Remove">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="removeLinkButton" runat="server"
                                                    CssClass="btn btn-mini btn-inverse" Style="align: center;" OnClick="removeLinkButton_Click"><i class="icon icon-trash icon-2x" style="color:#f00;"></i></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                        <div class="widget-separator no-border grid-3">
                            <h5 class="typo">Total Quantity
                            </h5>
                            <asp:TextBox ID="txtTotQuantity" runat="server" CssClass="form form-full" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div class="widget-separator no-border grid-3">
                            <h5 class="typo">Raw Material Cost
                            </h5>
                            <asp:TextBox ID="txtTotAmmount" runat="server" CssClass="form form-full" Text="0" placeholder="Total Amount" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div class="widget-separator no-border grid-3">
                            <h5 class="typo">Other Amount
                            </h5>
                            <asp:TextBox ID="txtOtherAmmount" runat="server" CssClass="form form-full" placeholder="Other Amount"></asp:TextBox>
                        </div>
                        <div class="widget-separator no-border grid-3">
                            <h5 class="typo">working Cost
                            </h5>
                            <asp:TextBox ID="txtWorkingCost" runat="server" CssClass="form form-full" placeholder="Working Cost"></asp:TextBox>
                        </div>
                        <div class="widget-separator no-border grid-3">
                            <h5 class="typo">Cost Amount
                            </h5>
                            <asp:TextBox ID="txtPayableAmmount" runat="server" CssClass="form form-full" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div class="widget-separator no-border grid-6">
                            <h5 class="typo">Description
                            </h5>
                            <asp:TextBox ID="txtDescription" runat="server" CssClass="form form-full" autocomplete="off" placeholder="Description"></asp:TextBox>
                        </div>
                        <div class="widget-separator no-padding grid-12">
                        </div>
                        <div class="widget-separator no-padding grid-12">
                            <div class="widget-separator no-border grid-6">
                                <div class="data">
                                    <div class="widget">
                                        <header class="widget-header">
                                            <div class="widget-header-icon">
                                                
                       
                                            </div>
                                            <h3 id="H1" class="widget-header-title">Production Analysis </h3>
                                        </header>
                                        <div class="widget-body no-padding">
                                            <div class="grid-12" style="padding-top: 15px;">
                                                <div class="grid-6" style="padding-left: 15px;">
                                                    <h5 class="typo">Total Amount :</h5>
                                                </div>
                                                <div class="grid-6">
                                                    <asp:Label ID="lblTotAmmount" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="grid-12">
                                                <div class="grid-6" style="padding-left: 15px;">
                                                    <h5 class="typo">Total Weight :</h5>
                                                </div>
                                                <div class="grid-6">
                                                    <asp:Label ID="lblTotoWeight" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="grid-12">
                                                <div class="grid-6" style="padding-left: 15px;">
                                                    <h5 class="typo">Decrease Weight :</h5>
                                                </div>
                                                <div class="grid-6">
                                                    <asp:Label ID="lblWestedWeight" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="grid-12">
                                                <div class="grid-6" style="padding-left: 15px;">
                                                    <h5 class="typo">Decrease rate [%] :</h5>
                                                </div>
                                                <div class="grid-6">
                                                    <asp:Label ID="lblDecreaseRate" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="widget-separator no-border grid-6">
                                <div class="data">
                                    <div class="widget">
                                        <header class="widget-header">
                                            <div class="widget-header-icon">
                                                
                       
                                            </div>
                                            <h3 id="H2" class="widget-header-title">Final Goods</h3>
                                        </header>
                                        <div class="widget-body no-padding">
                                            <div class="grid-12" style="padding-top: 20px;">
                                                <div class="grid-4" style="padding-left: 20px;">
                                                    <h5 class="typo">Date :</h5>
                                                </div>
                                                <div class="grid-6">
                                                    <asp:TextBox ID="txtDate" runat="server" autocomplete="off" CssClass="date-textbox"></asp:TextBox>
                                                </div>
                                            </div>
                                             <div class="grid-12" style="padding-top: 20px;">
                                                <div class="grid-4" style="padding-left: 20px;">
                                                    <h5 class="typo">Stock On :</h5>
                                                </div>
                                                <div class="grid-6">
                                                    <asp:RadioButtonList ID="stockOnRadioBtn" runat="server" RepeatDirection="Horizontal" style="width: 100%;">
                                                        <asp:ListItem Text="Weight" Value="Weight" Selected="True"></asp:ListItem>
                                                        <asp:ListItem Text="Bundle" Value="Bundle"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </div>
                                            </div>
                                            <div class="grid-12" style="padding-top: 20px;">
                                                <div class="grid-4" style="padding-left: 20px;">
                                                    <h5 class="typo">Goods Weight :</h5>
                                                </div>
                                                <div class="grid-6">
                                                    <asp:TextBox ID="txtGoodsWeights" runat="server" Text="0" autocomplete="off"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="grid-12" style="padding-top: 20px;">
                                                <div class="grid-4" style="padding-left: 20px;">
                                                    <h5 class="typo">Goods Bundle :</h5>
                                                </div>
                                                <div class="grid-6">
                                                    <asp:TextBox ID="txtGoodsBundle" runat="server" Text="0" autocomplete="off"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="grid-12" style="padding-top: 20px; padding-bottom: 10px;">
                                                <div class="grid-4" style="padding-left: 20px;">
                                                    <h5 class="typo">Product :</h5>
                                                </div>
                                                <div class="grid-7">
                                                    <asp:DropDownList ID="ddlProduct" runat="server" CssClass="form form-full" OnSelectedIndexChanged="ddlProduct_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="widget-separator no-border grid-12">
                            <div class="grid-12">
                                <div id="finalGoodsGrid">
                                    <asp:GridView ID="GridfinalGoodsReport" runat="server" AutoGenerateColumns="false"
                                        CssClass="table table-hover dataTable gridView">
                                        <Columns>
                                            <asp:BoundField DataField="ProductId" HeaderText="Product ID" />
                                            <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                                            <asp:BoundField DataField="Quantity" HeaderText="Quantity [K.G]" />
                                            <asp:BoundField DataField="Costing" HeaderText="Unit cost" />

                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                        <div class="widget-separator text-center no-border grid-12">
                            <asp:Button ID="saveButton" CssClass="btn btn-submit btn-large btn-3d" Enabled="false" runat="server"
                                Text="Save" OnClick="saveButton_Click" />
                        </div>
                    </div>
                    <div id="productListModal" class="modal hide fade" tabindex="-1" role="dialog" style="width: 780px;" aria-labelledby="myModalLabel"
                        aria-hidden="true">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                &times;</button>
                            <h3>Product List
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
                                        <asp:BoundField DataField="FreeQuantity" HeaderText="Free Quantity" />
                                        <asp:BoundField DataField="LastUnitPrice" HeaderText="Unit Price" />
                                        <asp:BoundField DataField="VATPercentage" HeaderText="VATPercentage" Visible="false" />

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
                </div>

            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddlProduct" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="warehouseDropDownList" EventName="SelectedIndexChanged" />
            <%--    <asp:AsyncPostBackTrigger ControlID="addSelectedProductButton" EventName="Click" />--%>
            <asp:AsyncPostBackTrigger ControlID="addSelectedProductButton" EventName="Click" />
            <%-- <asp:AsyncPostBackTrigger ControlID="saveButton" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="saveButton" EventName="Click" />--%>
            <%--  <asp:AsyncPostBackTrigger ControlID="addProductButton" EventName="Click" />--%>
            <asp:AsyncPostBackTrigger ControlID="purchaseProductListGridView" EventName="RowDataBound" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:HiddenField ID="checkedRowCountHiddenField" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">

        function pageLoad(sender, args) {
            $('#ddlProduct').chosen();

            $(".pQty-rpu-amt-cal").on('change keyup paste', function () {
                var qty = $(this).closest('tr').find("[id*=txtQuantity]").val();
                var rate = $(this).closest('tr').find("[id*=txtRate]").val();
                var amt = parseFloat(qty) * parseFloat(rate);

                $(this).parent().parent().find("[id*=txtPrice]").val(amt.toFixed(2));
                totalQuantity();
                TotalAmountCalculation();

            });


            //Final Goods Textbox Changing
            $('#txtGoodsWeights').on('change keyup', function () {
                var totWeight = $('#lblTotoWeight').text();
                var goodsWeight = $('#txtGoodsWeights').val();
                if (!isNaN(goodsWeight) && goodsWeight != "") {
                    var decreseWeight = totWeight - goodsWeight;
                    $('#lblWestedWeight').text(decreseWeight.toFixed(2));
                }
                if (goodsWeight == "") {

                    var decreseWeight = totWeight - totWeight;
                    $('#lblWestedWeight').text(decreseWeight.toFixed(2));
                }
                calculateDecreaseRate();
            })
            //Other ammount textbox Changing
            $("#txtOtherAmmount").on('change keyup', function () {
                var otherAmmount = 0;
                var totAmmunt = 0;

                if (!isNaN($('#txtOtherAmmount').val()) && $('#txtOtherAmmount').val() != "" && $('#txtWorkingCost').val() != "") {
                    otherAmmount = $('#txtOtherAmmount').val();
                    totAmmunt = $('#txtTotAmmount').val();
                    var sum = parseFloat($('#txtOtherAmmount').val()) + parseFloat($('#txtTotAmmount').val()) + parseFloat($('#txtWorkingCost').val());
                    $('#txtPayableAmmount').val(sum.toFixed(2));
                }
                else {
                    if ($('#txtWorkingCost').val() == "") {
                        $('#txtPayableAmmount').val(parseFloat($('#txtOtherAmmount').val()) + parseFloat($('#txtTotAmmount').val()));
                    }
                    else {
                        $('#txtPayableAmmount').val($('#txtOtherAmmount').val());
                    }
                }
                if ($('#txtOtherAmmount').val() == "") {
                    $('#txtPayableAmmount').val(parseFloat($('#txtTotAmmount').val()) + parseFloat($('#txtWorkingCost').val()));
                }
                if ($('#txtWorkingCost').val() == "" && $('#txtOtherAmmount').val() == "") {
                    $('#txtPayableAmmount').val($('#txtTotAmmount').val());
                }
                $('#lblTotAmmount').text($('#txtPayableAmmount').val());
            });
            //working cost text box Changing
            $("#txtWorkingCost").on('change keyup', function () {
                var workingCost = 0;
                var totAmmunt = 0;
                var otheramt = 0;
                if (!isNaN($('#txtWorkingCost').val()) && $('#txtWorkingCost').val() != "" && $('#txtOtherAmmount').val() != "") {
                    workingCost = $('#txtWorkingCost').val();
                    totAmmunt = $('#txtTotAmmount').val();
                    otheramt = $('#txtOtherAmmount').val();

                    var sum = parseFloat($('#txtTotAmmount').val()) + parseFloat($('#txtOtherAmmount').val()) + parseFloat($('#txtWorkingCost').val());
                    $('#txtPayableAmmount').val(sum.toFixed(2));
                }
                else {
                    otheramt = parseFloat($('#txtOtherAmmount').val());
                    totAmmunt = parseFloat($('#txtTotAmmount').val());
                    if ($('#txtOtherAmmount').val() == "") {
                        var sum = parseFloat($('#txtWorkingCost').val()) + totAmmunt;
                    }
                    else {
                        var sum = parseFloat($('#txtWorkingCost').val());
                    }

                    $('#txtPayableAmmount').val(sum.toFixed(2));
                }
                if ($('#txtWorkingCost').val() == "") {
                    $('#txtPayableAmmount').val(parseFloat($('#txtTotAmmount').val()) + parseFloat($('#txtOtherAmmount').val()));
                }
                if ($('#txtWorkingCost').val() == "" && $('#txtOtherAmmount').val() == "") {
                    $('#txtPayableAmmount').val($('#txtTotAmmount').val());
                }
                $('#lblTotAmmount').text($('#txtPayableAmmount').val());
            });
            function calculateCosting() {
                var totAmnt = $('#lblTotAmmount').text();
                var totWeight = $('#lblTotoWeight').text();

                var costing = (totAmnt / totWeight);
                $('#lblCosting').text(costing.toFixed(2));
            }
            function calculateDecreaseRate() {
                var westedWeight = $('#lblWestedWeight').text();
                var totWeight = $('#lblTotoWeight').text();

                if (!isNaN(westedWeight) && !isNaN(totWeight)) {
                    var decreaserate = 0;
                    decreaserate = (westedWeight * 100) / totWeight;
                    $('#lblDecreaseRate').text(decreaserate.toFixed(2) + " %");
                }
            }
            //date time picker
            var dateFormat = '<%= Session["DateFormatForDatePicker"] %>';

            $(".date-textbox").datepicker({ format: dateFormat, autoclose: true });

            $("#GridfinalGoodsReport").dataTable({
                "bProcessing": true,
                "sPaginationType": "full_numbers",
                "aLengthMenu": [[10, 15, 20, -1], [10, 15, 20, "All"]],
                "iDisplayLength": -1,
                "bSort": false,
                //"aoColumnDefs": [{ 'bSortable': false, 'aTargets': [0, 1, 2, 3, 4, 5, 6, 7]}],
                "bFilter": false,
                "bLengthChange": true,
                "bPaginate": false,
                "bInfo": true,
                "bDestroy": true
            });
            $("#purchaseProductListGridView").dataTable({
                "bProcessing": true,
                "sPaginationType": "full_numbers",
                "aLengthMenu": [[10, 15, 20, -1], [10, 15, 20, "All"]],
                "iDisplayLength": -1,
                "bSort": false,
                //"aoColumnDefs": [{ 'bSortable': false, 'aTargets': [0, 1, 2, 3, 4, 5, 6, 7]}],
                "bFilter": false,
                "bLengthChange": true,
                "bPaginate": false,
                "bInfo": true,
                "bDestroy": true
            });

            $("#productListGridView").dataTable({
                "bProcessing": true,
                "sPaginationType": "full_numbers",
                "aLengthMenu": [[-1], ["All"]],
                "iDisplayLength": -1,
                "aoColumnDefs": [{ 'bSortable': false, 'aTargets': [5] }],
                "bFilter": true,
                "bLengthChange": true,
                "bPaginate": false,
                "bInfo": true,
                "bDestroy": true
            });
            function totalQuantity() {
                var tAmt = 0;
                $("#purchaseProductListGridView tr").each(function () {
                    if (!isNaN($(this).find("[id*=txtQuantity]").val())) {
                        tAmt = parseFloat(tAmt) + parseFloat($(this).find("[id*=txtQuantity]").val());
                    }
                    //tAmt = tAmt + +$(this).find("[id*=amountTextBox]").val();
                    //alert($(this).find("[id*=amountTextBox]").val());
                });
                $('#txtTotQuantity').val(tAmt);
                $("#lblTotoWeight").text(tAmt);
                //$("#lblTotPrice").val(tAmt);
                //Total Payble Calculation

            }
            function TotalAmountCalculation() {
                var tAmt = 0;
                var otherAmt = 0;
                var workingCost = 0;
                $("#purchaseProductListGridView tr").each(function () {
                    if (!isNaN($(this).find("[id*=txtPrice]").val())) {
                        tAmt = tAmt + parseFloat($(this).find("[id*=txtPrice]").val());

                    }

                    //tAmt = tAmt + +$(this).find("[id*=amountTextBox]").val();
                    //alert($(this).find("[id*=amountTextBox]").val());
                });

                $("#txtTotAmmount").val(tAmt);

                $('#txtPayableAmmount').val(tAmt);

                //$("#lblTotPrice").val(tAmt);
                //Total Payble Calculation
                otherAmt = $('#txtOtherAmmount').val();
                workingCost = $('#txtWorkingCost').val();
                if (!isNaN(otherAmt) && otherAmt != "" && workingCost != "") {

                    var sum = parseFloat(otherAmt) + tAmt + parseFloat(workingCost);
                    $('#txtPayableAmmount').val(sum);
                }
                else {
                    if (workingCost == "") {
                        $('#txtPayableAmmount').val(tAmt + parseFloat(otherAmt));
                    }
                    if (otherAmt == "") {
                        $('#txtPayableAmmount').val(tAmt + parseFloat(workingCost));
                    }
                    if (workingCost == "" && otherAmt == "") {
                        $('#txtPayableAmmount').val(tAmt);
                    }

                }
                $("#lblTotAmmount").text($('#txtPayableAmmount').val());
            }
            $('.modal-backdrop').remove();
            var checkedRowCount = $("#checkedRowCountHiddenField").val();

            $("#addSelectedProductButton").click(function () {
                $("#checkedRowCountHiddenField").val(checkedRowCount);
                //$('#productListModal').modal({ show: false });
                if (haveOverlay == 1) {
                    MyOverlayStop();
                }
            });
            $("#addFromListButton").click(function () {
                $('#productListModal').modal();
            });

            $.ajax({
                type: "POST",
                url: "/Services/ProductSearchByWH.ashx?id=" + $('#warehouseDropDownList').val(),
                success: function (d) {
                    var array = [];
                    d.split(';').forEach(function (value) {
                        array.push(value);
                    });
                    $('#productTextBox').typeahead({ source: array });
                    //                    $('#txtbxfineBy').typeahead({ source: array });
                }
            });
        }
    </script>
</asp:Content>
