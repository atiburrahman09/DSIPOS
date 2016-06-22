<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true"
    CodeBehind="ApproveRequisition.aspx.cs" Inherits="lmxIpos.UI.PurchaseRequisition.ApproveRequisition" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
    <link href="/Content/Style/CSSPages/ApprovePurchaseRequisition.css" rel="stylesheet"
        type="text/css" />
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <div id="body_content">
        <fieldset>
            <legend>Approve Purchase Requisition [<asp:Label ID="idLabel" runat="server" Text=""></asp:Label>]</legend>
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
                            Requisition Date:
                        </label>
                        <label>
                            <asp:Label ID="requisitionDateLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                        </label>
                    </td>
                    <td>
                        <label>
                            Warehouse ID & Name:
                            <asp:Label ID="warehouseIdLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                        </label>
                        <label>
                            <asp:Label ID="warehouseNameLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                        </label>
                    </td>
                    <td>
                        <label>
                            Narration:
                        </label>
                        <label>
                            <asp:Label ID="narrationLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                        </label>
                    </td>
                    <td>
                        <label>
                            Status:
                        </label>
                        <label>
                            <asp:Label ID="statusLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                        </label>
                    </td>
                </tr>
            </table>
            <hr />
            <div id="purchaseRequisitionProductListGridContainer" class="container">
                <asp:GridView ID="purchaseRequisitionProductListGridView" runat="server" AutoGenerateColumns="false"
                    CssClass="table table-hover gridView">
                    <Columns>
                        <asp:BoundField DataField="ProductId" HeaderText="Product ID" />
                        <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                        <asp:BoundField DataField="RequiredDate" HeaderText="Required Date" />
                        <asp:BoundField DataField="RequisitionQuantityUnit" HeaderText="Reqi. Qty" />
                        <asp:TemplateField HeaderText="Aprv. Qty">
                            <ItemTemplate>
                                <asp:TextBox ID="approveQuantityTextBox" runat="server"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Vendor Name">
                            <ItemTemplate>
                                <asp:DropDownList ID="vendorDropDownList" runat="server">
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Narration">
                            <ItemTemplate>
                                <asp:TextBox ID="narrationTextBox" runat="server"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                <asp:DropDownList ID="statusDropDownList" runat="server">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem Value="A">Approve</asp:ListItem>
                                    <asp:ListItem Value="R">Reject</asp:ListItem>
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <hr />
            <asp:Button ID="approveButton" runat="server" Enabled="false" CssClass="btn btn-primary"
                Text="Approve & Create Purchase Order" OnClick="approveButton_Click" />
        </fieldset>
    </div>
    <asp:HiddenField ID="purchaseRequisitionIdForApproveHiddenField" runat="server" />
</asp:Content>
<asp:Content ID="scriptContent" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        $(function () {
            $("#purchaseRequisitionProductListGridView").dataTable({
                "bProcessing": true,
                "sPaginationType": "full_numbers",
                "aLengthMenu": [[10, 15, 20, 25, 50, -1], [10, 15, 20, 25, 50, "All"]],
                "iDisplayLength": -1,
                "bSort": false,
                //"aoColumnDefs": [{ 'bSortable': false, 'aTargets': [4, 5, 6, 7]}],
                "bFilter": false,
                "bLengthChange": true,
                "bPaginate": false,
                "bInfo": true
            });

            $("#purchaseRequisitionProductListGridView_wrapper .row-fluid:nth-child(1)").css("display", "none");
        });
    </script>
</asp:Content>
