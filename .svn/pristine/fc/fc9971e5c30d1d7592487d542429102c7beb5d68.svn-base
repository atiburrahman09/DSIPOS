<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true" EnableEventValidation="false"
    CodeBehind="CreateRequisition.aspx.cs" Inherits="lmxIpos.UI.ProductRequisition.CreateRequisition" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="true">
        <ContentTemplate>
            <div class="title-sitemap grid-12">
                <h1 class="grid-6">
                    <i>&#xf132;</i>Product Requisition<span>Creating Product Requisition</span></h1>
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
                        <h3 id="Header3" runat="server" class="widget-header-title">Product Requisition Form</h3>
                    </header>
                    <div class="widget-body no-padding">
                        <div class="widget-separator no-padding grid-12">
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Requisition Type</h5>
                                <asp:DropDownList ID="drpdwnRequisationTo" runat="server" required="required"
                                    CssClass="form form-full">
                                    <%-- <asp:ListItem Value="WH-WH">Warehouse to Warehouse</asp:ListItem>--%>
                                    <asp:ListItem Value="WH-SC">Warehouse to Salse Center</asp:ListItem>
                                    <%--<asp:ListItem Value="SC-SC">Salse Center to Salse Center</asp:ListItem>--%>
                                    <asp:ListItem Value="SC-WH">Salse Center to Warehouse</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Warehouse Name</h5>
                                <asp:DropDownList ID="WarehouesDropDownList" runat="server"
                                    CssClass="form form-full">
                                </asp:DropDownList>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Sales Center Name</h5>
                                <asp:DropDownList ID="salesCenterDropDownList" runat="server" required="required" AutoPostBack="True"
                                    CssClass="form form-full" OnSelectedIndexChanged="salesCenterDropDownList_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Narration
                                </h5>
                                <asp:TextBox ID="narrationTextBox" runat="server" CssClass="form form-full" placeholder="Narration"></asp:TextBox>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Product By [Barcode, ID, Name]
                                </h5>
                                <asp:TextBox ID="productTextBox" onfocus="this.select()" runat="server" CssClass="form form-full" placeholder="Product By [Barcode, ID, Name]"
                                    autocomplete="off"></asp:TextBox>
                            </div>
                            <div class="widget-separator no-border grid-5" style="margin-top: 29px;">
                                <asp:Button ID="addProductButton" CssClass="btn btn-info" runat="server" Text="Add Product"
                                    OnClick="addProductButton_Click" />
                                <asp:Button ID="addFromListButton" CssClass="btn btn-success" runat="server" Text="Add from List"
                                    OnClientClick="return false;" />
                            </div>
                        </div>
                        <div class="widget-separator grid-12">
                            <h4 class="typo">Selected Product List
                            </h4>
                        </div>
                        <div class="grid-12">
                            <div id="selectedProductListGridContainer">
                                <asp:GridView ID="selectedProductListGridView" runat="server" AutoGenerateColumns="false"
                                    CssClass="table table-hover gridView dataTable">
                                    <Columns>
                                        <asp:BoundField DataField="Barcode" HeaderText="Barcode" />
                                        <asp:BoundField DataField="ProductId" HeaderText="Product ID" />
                                        <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                                        <asp:BoundField DataField="Unit" HeaderText="Unit" />
                                        <asp:TemplateField HeaderText="Quantity">
                                            <ItemTemplate>
                                                <asp:TextBox ID="requisitionQuantityTextBox" runat="server" Width="80"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Required Date">
                                            <ItemTemplate>
                                                <i class="icon-calendar"></i>
                                                <asp:TextBox ID="requiredDateTextBox" runat="server" CssClass="date-textbox" Width="80"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Narration">
                                            <ItemTemplate>
                                                <asp:TextBox ID="productNarrationTextBox" runat="server" Width="80"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <%-- <asp:LinkButton ID="removeLinkButton" runat="server" CssClass="btn btn-mini btn-inverse"
                                                    OnClick="removeLinkButton_Click">Remove</asp:LinkButton>--%>
                                                <asp:LinkButton ID="removeLinkButton" runat="server"
                                                    CssClass="btn" OnClick="removeLinkButton_Click" ToolTip="Remove"><i class="icon icon-trash icon-2x" style="color:#f00;"></i></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                        <div class="widget-separator grid-12">
                            <asp:Button ID="saveButton" CssClass="btn btn-submit btn-3d" Enabled="false" runat="server"
                                Text="Submit Requisition" OnClick="saveButton_Click" />
                        </div>
                        <asp:HiddenField ID="checkedRowCountHiddenField" runat="server" />
                        <div class="grid-12">
                            <div id="productListModal" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
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
                                            CssClass="table table-hover dataTable">
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
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="salesCenterDropDownList" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="addProductButton" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="addFromListButton" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="saveButton" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="addSelectedProductButton" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="selectedProductListGridView" EventName="RowDataBound" />
            <asp:AsyncPostBackTrigger ControlID="productListGridView" EventName="RowDataBound" />
        </Triggers>
    </asp:UpdatePanel>
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
                    //alert($('#salesCenterDropDownList').val());
                }
            });


            $("#addSelectedProductButton").click(function () {
                $("#checkedRowCountHiddenField").val(checkedRowCount);
            });

            var dateFormat = '<%= Session["DateFormatForDatePicker"] %>';
            $(".date-textbox").datepicker({ format: dateFormat });
            $(".date-textbox, .icon-calendar").click(function () {
                $(this).parent().find(".date-textbox").focus();
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
                "aoColumnDefs": [{ 'bSortable': false, 'aTargets': [5] }],
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
        };
    </script>
</asp:Content>
