<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true" EnableEventValidation="false"
    CodeBehind="CreateRequisition.aspx.cs" Inherits="lmxIpos.UI.PurchaseRequisition.CreateRequisition" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
    <link href="/Content/Style/CSSPages/CreatePurchaseRequisition.css" rel="stylesheet"
        type="text/css" />
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <div id="body_content">
        <fieldset>
            <legend>Create Purchase Requisition</legend>
            <div id="msgbox" runat="server" visible="false" class="alert alert-error">
                <button type="button" class="close" data-dismiss="alert">
                    &times;</button>
                <h4>
                    <asp:Label ID="msgTitleLabel" runat="server" Text=""></asp:Label>
                </h4>
                <asp:Label ID="msgDetailLabel" runat="server" Text=""></asp:Label>
            </div>
            <table class="inputControlContainer">
                <tr>
                    <td>
                        <label>
                            Warehouse Name
                        </label>
                        <asp:DropDownList ID="warehouseDropDownList" runat="server" OnSelectedIndexChanged="warehouseDropDownList_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <label>
                            Narration
                        </label>
                        <asp:TextBox ID="narrationTextBox" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <label>
                            Product By [Barcode, ID, Name]
                        </label>
                        <asp:TextBox ID="productTextBox" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="addProductButton" CssClass="btn btn-info" runat="server" Text="Add Product"
                            OnClick="addProductButton_Click" />
                        <asp:Button ID="addFromListButton" CssClass="btn btn-success" runat="server" Text="Add from List"
                            OnClientClick="return false;" />
                    </td>
                </tr>
            </table>
        </fieldset>
        <fieldset>
            <legend>Selected Product List </legend>
            <div id="selectedProductListGridContainer" class="container">
                <asp:GridView ID="selectedProductListGridView" runat="server" AutoGenerateColumns="false"
                    CssClass="table table-hover gridView">
                    <Columns>
                        <asp:BoundField DataField="Barcode" HeaderText="Barcode" />
                        <asp:BoundField DataField="ProductId" HeaderText="Product ID" />
                        <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                        <asp:BoundField DataField="Unit" HeaderText="Unit" />
                        <asp:TemplateField HeaderText="Quantity">
                            <ItemTemplate>
                                <asp:TextBox ID="requisitionQuantityTextBox" runat="server"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Required Date">
                            <ItemTemplate>
                                <i class="icon-calendar"></i>
                                <asp:TextBox ID="requiredDateTextBox" runat="server" CssClass="date-textbox"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Narration">
                            <ItemTemplate>
                                <asp:TextBox ID="productNarrationTextBox" runat="server"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:LinkButton ID="removeLinkButton" runat="server" CssClass="btn btn-mini btn-inverse"
                                    OnClick="removeLinkButton_Click">Remove</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <hr />
            <asp:Button ID="saveButton" CssClass="btn btn-primary" Enabled="false" runat="server"
                Text="Save" OnClick="saveButton_Click" />
        </fieldset>
        <div id="productListModal" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
            aria-hidden="true">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                    &times;</button>
                <h3>
                    Product List
                </h3>
            </div>
            <div class="modal-body">
                <div id="productListGridContainer" class="">
                    <asp:GridView ID="productListGridView" runat="server" AutoGenerateColumns="false"
                        CssClass="table table-hover">
                        <Columns>
                            <asp:BoundField DataField="Barcode" HeaderText="Barcode" />
                            <asp:BoundField DataField="ProductId" HeaderText="Product ID" />
                            <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                            <asp:BoundField DataField="Unit" HeaderText="Unit" />
                            <asp:BoundField DataField="ProductGroupName" HeaderText="Product Group" />
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
    <asp:HiddenField ID="checkedRowCountHiddenField" runat="server" />
</asp:Content>
<asp:Content ID="scriptContent" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        $(function () {
            var checkedRowCount = $("#checkedRowCountHiddenField").val();

            $("#addSelectedProductButton").click(function () {
                $("#checkedRowCountHiddenField").val(checkedRowCount);
            });

            $("#addProductButton").click(function () {
                
            });

            $("#saveButton").click(function () {
                
            });

            var dateFormat = '<%= Session["DateFormatForDatePicker"] %>';
            $(".date-textbox").datepicker({ format: dateFormat });
            $(".date-textbox, .icon-calendar").click(function () {
                $(this).parent().find(".date-textbox").focus();
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
                    //                    $('#txtbxfineBy').typeahead({ source: array });
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
                "aoColumnDefs": [{ 'bSortable': false, 'aTargets': [5]}],
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
        });
    </script>
</asp:Content>
