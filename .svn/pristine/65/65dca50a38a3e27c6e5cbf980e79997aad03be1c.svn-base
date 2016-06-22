<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true"
    CodeBehind="CreateTransferRecord.aspx.cs" Inherits="lmxIpos.UI.ProductTransferRecord.CreateTransferRecord" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
    <link href="/Content/Style/CSSPages/CreateTransferRecord.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="false">
        <ContentTemplate>
            <div class="title-sitemap grid-12">
                <h1 class="grid-8">
                    <i>&#xf132;</i>Create Product Transfer Record<span>Creating Product Transfer Record</span></h1>
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
                            Create Product Transfer Record Form</h3>
                    </header>
                    <div class="widget-body no-padding">
                        <div class="widget-separator grid-12">
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">
                                    Transfer Destination
                                </h5>
                                <asp:DropDownList ID="transferDestinationDropDownList" runat="server" AutoPostBack="true"
                                    OnSelectedIndexChanged="transferDestinationDropDownList_SelectedIndexChanged"
                                    CssClass="form form-full">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem Value="SC">Sales Center</asp:ListItem>
                                    <asp:ListItem Value="WH">Warehouse</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">
                                    Transfer To (WH/SC)
                                </h5>
                                <asp:DropDownList ID="transferToDropDownList" runat="server" CssClass="form form-full">
                                </asp:DropDownList>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">
                                    Transfer Order ID
                                </h5>
                                <asp:TextBox ID="transferOrderIdTextBox" runat="server" CssClass="form form-full"
                                    placeholder="Transfer Order ID"></asp:TextBox>
                            </div>
                            <div class="widget-separator no-border grid-3" style="margin-top: 29px;">
                                <asp:Button ID="transferOrderDetailsButton" runat="server" Text="Get Transfer Order Details"
                                    CssClass="btn btn-info" OnClick="transferOrderDetailsButton_Click" />
                            </div>
                        </div>
                        <div class="widget-separator no-border grid-12">
                            <h4 class="typo">
                                Transfer Order Information</h4>
                        </div>
                        <div class="widget-separator no-padding grid-12">
                            <div id="orderInfoContainer" runat="server" visible="false">
                                <div class="widget-separator grid-6">
                                    <div class="grid-4">
                                        Order ID:
                                    </div>
                                    <div class="grid-8">
                                        <asp:Label ID="orderIdLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                        ,
                                        <asp:Label ID="orderDateLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                    </div>
                                </div>
                                <div class="widget-separator grid-6">
                                    <div class="grid-4">
                                        Transfer Type:
                                    </div>
                                    <div class="grid-8">
                                        <asp:Label ID="transferTypeLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                    </div>
                                </div>
                                <div class="widget-separator grid-6">
                                    <div class="grid-4">
                                        Transfer From ID & Name:
                                    </div>
                                    <div class="grid-8">
                                        <asp:Label ID="transferFromIdLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                        ,
                                        <asp:Label ID="transferFromNameLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                    </div>
                                </div>
                                <div class="widget-separator grid-6">
                                    <div class="grid-4">
                                        Transfer To ID & Name:
                                    </div>
                                    <div class="grid-8">
                                        <asp:Label ID="transferToIdLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                        ,
                                        <asp:Label ID="transferToNameLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                    </div>
                                </div>
                                <div class="widget-separator grid-6">
                                    <div class="grid-4">
                                        Narration:
                                    </div>
                                    <div class="grid-8">
                                        <asp:Label ID="narrationLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                    </div>
                                </div>
                                <div class="widget-separator grid-6">
                                    <div class="grid-4">
                                        Status:
                                    </div>
                                    <div class="grid-8">
                                        <asp:Label ID="statusLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                    </div>
                                </div>
                                <div class="widget-separator grid-6">
                                    <div class="grid-4">
                                        Requisition ID:
                                    </div>
                                    <div class="grid-8">
                                        <asp:Label ID="requisitionIdLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                    </div>
                                </div>
                                <div class="widget-separator grid-6">
                                    <div class="grid-4">
                                        Requisition Date:
                                    </div>
                                    <div class="grid-8">
                                        <asp:Label ID="requisitionDateLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                    </div>
                                </div>
                                <div class="widget-separator grid-6">
                                    <div class="grid-4">
                                        Transport Date:
                                    </div>
                                    <div class="grid-8">
                                        <asp:Label ID="transportDateLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                    </div>
                                </div>
                                <div class="widget-separator grid-6">
                                    <div class="grid-4">
                                        Description:
                                    </div>
                                    <div class="grid-8">
                                        <asp:Label ID="descriptionLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="widget-separator grid-12">
                            <div id="productTransferOrderProductListGridContainer">
                                <asp:GridView ID="productTransferOrderProductListGridView" runat="server" AutoGenerateColumns="false"
                                    CssClass="table table-hover gridView">
                                    <Columns>
                                        <asp:BoundField DataField="ProductId" HeaderText="Product ID" />
                                        <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                                        <asp:BoundField DataField="ApprovedQuantityUnit" HeaderText="Order Qty" />
                                        <asp:TemplateField HeaderText="Received Qty">
                                            <ItemTemplate>
                                                <asp:TextBox ID="receivedQuantityTextBox" runat="server" Height="15" Width="75" CssClass="pQty-cal read-only"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Disappeared Qty">
                                            <ItemTemplate>
                                                <asp:TextBox ID="disappearedQuantityTextBox" runat="server" Height="15" Width="95"
                                                    Text="0"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Narration">
                                            <ItemTemplate>
                                                <asp:TextBox ID="narrationTextBox" runat="server" Height="15" Width="200"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                        <div class="widget-separator grid-12">
                            <asp:Button ID="saveButton" CssClass="btn btn-submit btn-3d" runat="server" Enabled="false"
                                Text="Save" OnClick="saveButton_Click" />
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
        $(function () {
            $(".read-only").attr("ReadOnly", true);

            $("#transferDestinationDropDownList").rules("add", {
                required: true
            });

            $("#transferToDropDownList").rules("add", {
                required: true
            });

            $("#transferOrderIdTextBox").rules("add", {
                required: true
            });

            $("#productTransferOrderProductListGridView").dataTable({
                "bProcessing": true,
                "sPaginationType": "full_numbers",
                "aLengthMenu": [[10, 15, 20, 25, 50, -1], [10, 15, 20, 25, 50, "All"]],
                "iDisplayLength": -1,
                "bSort": false,
                //"aoColumnDefs": [{ 'bSortable': false, 'aTargets': []}],
                "bFilter": false,
                "bLengthChange": true,
                "bPaginate": false,
                "bInfo": true
            });

            $("#productTransferOrderProductListGridView_wrapper .row-fluid:nth-child(1)").css("display", "none");

            $(".pQty-cal").on("keyup", function () {
                var row = +$(this).closest('tr').index();
                var oQty = $("#productTransferOrderProductListGridView").find("tr td:nth-child(3)").eq(row).text();
                var rQty = +$(this).closest('tr').find("[id*=receivedQuantityTextBox]").val();
                $(this).closest('tr').find("[id*=disappearedQuantityTextBox]").val(oQty - rQty);
            });
        });
    </script>
</asp:Content>
