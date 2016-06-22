<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true" EnableEventValidation="false"
    CodeBehind="MenuList.aspx.cs" Inherits="IPOSSystem.UI.AppMenu.MenuList" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
    <link href="/Content/Style/CSSPages/AppMenuList.css" rel="stylesheet" type="text/css" />
    <link href="/Content/Style/CSSPages/AppMenuTest.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <div id="body_content">
        <fieldset>
            <legend>App. Menu List</legend>
            <div id="msgbox" runat="server" visible="false" class="alert alert-error">
                <button type="button" class="close" data-dismiss="alert">
                    &times;</button>
                <h4>
                    <asp:Label ID="msgTitleLabel" runat="server" Text=""></asp:Label>
                </h4>
                <asp:Label ID="msgDetailLabel" runat="server" Text=""></asp:Label>
            </div>
            <div id="MenuContent">
                <div id="allMenuList">
                    <asp:Menu ID="testAllMenu" runat="server" Orientation="Horizontal" StaticEnableDefaultPopOutImage="false"
                        DynamicEnableDefaultPopOutImage="false" MaximumDynamicDisplayLevels="9" CssClass="navigation">
                    </asp:Menu>
                </div>
                <div id="allMenuImg">
                    <asp:ImageButton ID="refreshMenuImageButton" runat="server" AlternateText="All Menu"
                        ToolTip="Refresh Menu" ImageUrl="~/Content/Images/Refresh-icon.png" OnClick="refreshMenuImageButton_Click" />
                    <asp:ImageButton ID="allMenuImageButton" runat="server" AlternateText="All Menu" Height="40px"
                        ToolTip="Get All Menu" ImageUrl="~/content/images/database-icon.png" OnClick="allMenuImageButton_Click" />
                </div>
                <div class="empty">
                </div>
            </div>
            <hr />
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
                        <asp:DropDownList ID="menuTypeDropDownList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="menuTypeDropDownList_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <label>
                            Menu Group
                        </label>
                        <asp:DropDownList ID="menuGroupDropDownList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="menuGroupDropDownList_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <label>
                            Parent Menu Level
                        </label>
                        <asp:DropDownList ID="menuLevelDropDownList" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
            <asp:Button ID="getMenuListButton" runat="server" Text="Get Menu List" CssClass="btn btn-info"
                OnClick="getMenuListButton_Click" />
            <asp:Button ID="getAllMenuListButton" runat="server" Text="Get All List" CssClass="btn btn-info"
                OnClick="getAllMenuListButton_Click" />
            <br />
            <br />
            <hr />
            <div id="menuListGridContainer">
                <asp:GridView ID="menuListGridView" runat="server" AutoGenerateColumns="false" CssClass="table table-hover gridView">
                    <Columns>
                        <asp:BoundField DataField="MenuId" HeaderText="ID" />
                        <asp:BoundField DataField="MenuName" HeaderText="Name" />
                        <asp:BoundField DataField="ParentMenuName" HeaderText="Parent Menu" />
                        <asp:BoundField DataField="MenuGroupName" HeaderText="Group" />
                        <asp:BoundField DataField="IsSubParent" HeaderText="Parent" />
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
                                    OnClick="activateLinkButton_Click" OnClientClick="return confirm('Are you sure you want to activate this Menu?');">Activate</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:LinkButton ID="deactivateLinkButton" runat="server" CssClass="btn btn-mini btn-inverse"
                                    OnClick="deactivateLinkButton_Click" OnClientClick="return confirm('Are you sure you want to deactivate this Menu?');">Deactivate</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:LinkButton ID="deleteLinkButton" runat="server" CssClass="btn btn-mini btn-danger"
                                    OnClick="deleteLinkButton_Click" OnClientClick="return confirm('Are you sure you want to delete this Menu?');">Delete</asp:LinkButton>
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

            $("#menuGroupDropDownList").rules("add", {
                required: true
            });

            $("#menuLevelDropDownList").rules("add", {
                required: true
            });

            $("#getAllMenuListButton").click(function () {
                $("#form1").validate().currentForm = "";
            });

            $("#refreshMenuImageButton, #allMenuImageButton").click(function () {
                $("#menuGroupDropDownList").rules("remove");
                $("#menuLevelDropDownList").rules("remove");
            });

            //$(".navigation ul ul").css({ display: "none" });
            $(".navigation ul li").click(function () {
                $(this).find('ul:first').fadeToggle(500);
            });

            $("#menuListGridView").dataTable({
                "bProcessing": true,
                "sPaginationType": "full_numbers",
                "aLengthMenu": [[10, 15, 20, 25, 50, 100, -1], [10, 15, 20, 25, 50, 100, "All"]],
                "aoColumnDefs": [{ 'bSortable': false, 'aTargets': [8, 9, 10, 11]}]
            });
        });
    </script>
</asp:Content>
