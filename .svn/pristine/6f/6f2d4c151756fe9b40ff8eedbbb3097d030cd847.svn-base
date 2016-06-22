<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true" EnableEventValidation="false"
    CodeBehind="RequisitionList.aspx.cs" Inherits="lmxIpos.UI.PurchaseRequisition.RequisitionList" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
    <link href="/Content/Style/CSSPages/PurchaseRequisitionList.css" rel="stylesheet"
        type="text/css" />
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <div id="body_content">
        <fieldset>
            <legend>Purchase Requisition List</legend>
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
                        <label>
                            Date From
                        </label>
                        <i class="icon-calendar"></i>
                        <asp:TextBox ID="fromDateTextBox" CssClass="date-textbox" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <label>
                            Date To
                        </label>
                        <i class="icon-calendar"></i>
                        <asp:TextBox ID="toDateTextBox" CssClass="date-textbox" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <label>
                            Status
                        </label>
                        <asp:DropDownList ID="statusDropDownList" runat="server">
                            <asp:ListItem Value="All">All</asp:ListItem>
                            <asp:ListItem Value="A">Approved</asp:ListItem>
                            <asp:ListItem Value="PA">Partially Approved</asp:ListItem>
                            <asp:ListItem Value="P">Pending</asp:ListItem>
                            <asp:ListItem Value="R">Rejected</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
            <asp:Button ID="requisitionListButton" runat="server" Text="Get Requisition List"
                CssClass="btn btn-info" OnClick="requisitionListButton_Click" />
            <br />
            <br />
            <hr />
            <div id="purchaseRequisitionListGridContainer" class="container">
                <asp:GridView ID="purchaseRequisitionListGridView" runat="server" AutoGenerateColumns="false"
                    CssClass="table table-hover gridView">
                    <Columns>
                        <asp:BoundField DataField="PurchaseRequisitionId" HeaderText="PR ID" />
                        <asp:BoundField DataField="RequisitionDate" HeaderText="Requisition Date" />
                        <asp:BoundField DataField="WarehouseName" HeaderText="Warehouse Name" />
                        <asp:BoundField DataField="Narration" HeaderText="Narration" />
                        <asp:BoundField DataField="Status" HeaderText="Status" />
                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:LinkButton ID="viewLinkButton" runat="server" CssClass="btn btn-mini btn-info"
                                    OnClick="viewLinkButton_Click">View</asp:LinkButton>
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
            var dateFormat = '<%= Session["DateFormatForDatePicker"] %>';
            $(".date-textbox").datepicker({ format: dateFormat });
            $(".date-textbox, .icon-calendar").click(function () {
                $(this).parent().find(".date-textbox").focus();
            });

            $("#warehouseDropDownList").rules("add", {
                required: true
            });

            $("#fromDateTextBox").rules("add", {
                required: true
            });

            $("#toDateTextBox").rules("add", {
                required: true
            });

            $("#purchaseRequisitionListGridView").dataTable({
                "bProcessing": true,
                "sPaginationType": "full_numbers",
                "aLengthMenu": [[10, 15, 20, 25, 50, -1], [10, 15, 20, 25, 50, "All"]],
                "aoColumnDefs": [{ 'bSortable': false, 'aTargets': [5]}]
            });
        });
    </script>
</asp:Content>
