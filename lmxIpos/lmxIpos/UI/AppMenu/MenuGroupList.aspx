<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true"
    CodeBehind="MenuGroupList.aspx.cs" Inherits="IPOSSystem.UI.AppMenu.MenuGroupList" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
    <link href="/Content/Style/CSSPages/AppMenuGroupList.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <div id="body_content">
        <fieldset>
            <legend>App. Menu Group List</legend>
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
                            Menu For App.
                        </label>
                        <asp:DropDownList ID="menuForAppDropDownList" runat="server" AutoPostBack="true"
                            OnSelectedIndexChanged="menuForAppDropDownList_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <label>
                            Menu Type
                        </label>
                        <asp:DropDownList ID="menuTypeDropDownList" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td colspan="2">
                        <asp:Button ID="getGroupListButton" runat="server" Text="Get Group List" CssClass="btn btn-info"
                            OnClick="getGroupListButton_Click" />
                        <asp:Button ID="getAllGroupListButton" runat="server" Text="Get All Group List" CssClass="btn btn-info"
                            OnClick="getAllGroupListButton_Click" />
                    </td>
                </tr>
            </table>
            <hr />
            <div id="menuGroupListGridContainer">
                <asp:GridView ID="menuGroupListGridView" runat="server" AutoGenerateColumns="false"
                    CssClass="table table-hover gridView">
                    <Columns>
                        <asp:BoundField DataField="MenuGroupId" HeaderText="ID" />
                        <asp:BoundField DataField="MenuGroupName" HeaderText="Group Name" />
                        <asp:BoundField DataField="ToolTipDescription" HeaderText="Description" />
                        <asp:BoundField DataField="IsActive" HeaderText="Active" />
                        <asp:BoundField DataField="MenuType" HeaderText="Type" />
                        <asp:BoundField DataField="MenuForApp" HeaderText="For" />
                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:LinkButton ID="editLinkButton" runat="server" CssClass="btn btn-mini btn-warning"
                                    OnClick="editLinkButton_Click">Edit</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:LinkButton ID="activateLinkButton" runat="server" CssClass="btn btn-mini btn-success"
                                    OnClick="activateLinkButton_Click" OnClientClick="return confirm('Are you sure you want to activate this Menu Group?');">Activate</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:LinkButton ID="deactivateLinkButton" runat="server" CssClass="btn btn-mini btn-inverse"
                                    OnClick="deactivateLinkButton_Click" OnClientClick="return confirm('Are you sure you want to deactivate this Menu Group?');">Deactivate</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:LinkButton ID="deleteLinkButton" runat="server" CssClass="btn btn-mini btn-danger"
                                    OnClick="deleteLinkButton_Click" OnClientClick="return confirm('Are you sure you want to delete this Menu Group?');">Delete</asp:LinkButton>
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
            $("#menuForAppDropDownList").rules("add", {
                required: true
            });

            $("#menuTypeDropDownList").rules("add", {
                required: true
            });

            $("#getAllGroupListButton").click(function () {
                $("#form1").validate().currentForm = "";
            });

            $("#menuGroupListGridView").dataTable({
                "bProcessing": true,
                "sPaginationType": "full_numbers",
                "aLengthMenu": [[10, 15, 20, 25, 50, 100, -1], [10, 15, 20, 25, 50, 100, "All"]],
                "aoColumnDefs": [{ 'bSortable': false, 'aTargets': [6, 7, 8, 9]}]
            });
        });
    </script>
</asp:Content>
