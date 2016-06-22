<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true" EnableEventValidation="false"
    CodeBehind="ApprovalRequisitionList.aspx.cs" Inherits="lmxIpos.UI.PurchaseRequisition.ApprovalRequisitionList" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
    <link href="/Content/Style/CSSPages/PurchaseRequisitionApprovalList.css" rel="stylesheet"
        type="text/css" />
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <div id="body_content">
        <fieldset>
            <legend>Purchase Requisition Approval List</legend>
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
                        <asp:DropDownList ID="warehouseDropDownList" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Button ID="approvalListButton" runat="server" Text="Get Approval List" CssClass="btn btn-info"
                            OnClick="approvalListButton_Click" />
                    </td>
                </tr>
            </table>
            <hr />
            <div id="purchaseRequisitionApprovalListGridContainer" class="container">
                <asp:GridView ID="purchaseRequisitionApprovalListGridView" runat="server" AutoGenerateColumns="false"
                    CssClass="table table-hover gridView">
                    <Columns>
                        <asp:BoundField DataField="PurchaseRequisitionId" HeaderText="PR ID" />
                        <asp:BoundField DataField="RequsitionDate" HeaderText="Requsition Date" />
                        <asp:BoundField DataField="WarehouseName" HeaderText="Warehouse Name" />
                        <asp:BoundField DataField="Narration" HeaderText="Narration" />
                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:LinkButton ID="viewToApproveLinkButton" runat="server" CssClass="btn btn-mini btn-success"
                                    OnClick="viewToApproveLinkButton_Click">View to Approve</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </fieldset>
    </div>
</asp:Content>
<asp:Content ID="scriptContent" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        $(function () {
            $("#purchaseRequisitionApprovalListGridView").dataTable({
                "bProcessing": true,
                "sPaginationType": "full_numbers",
                "aLengthMenu": [[10, 15, 20, 25, 50, -1], [10, 15, 20, 25, 50, "All"]],
                "aoColumnDefs": [{ 'bSortable': false, 'aTargets': [4]}]
            });
        });
    </script>
</asp:Content>
