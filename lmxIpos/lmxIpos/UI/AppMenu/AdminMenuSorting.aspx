<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true" EnableEventValidation="false"
    CodeBehind="AdminMenuSorting.aspx.cs" Inherits="IPOSSystem.UI.AppMenu.AdminMenuSorting" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
    <link href="/Content/Style/CSSPages/AdminMenuSorting.css" rel="stylesheet" type="text/css" />
    <link href="/Content/Style/CSSPages/AppMenuTest.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <div id="body_content">
        <fieldset>
            <legend>Sorting Menu List</legend>
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
                    <asp:ImageButton ID="allMenuImageButton" runat="server" AlternateText="All Menu" Height="40"
                        ToolTip="Get All Menu" ImageUrl="~/Content/Images/database-icon.png" OnClick="allMenuImageButton_Click" />
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
                        <asp:DropDownList ID="menuLevelDropDownList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="menuLevelDropDownList_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
            <hr id="hrList" />
            <div id="menuSortingPane" runat="server" visible="false">
                <table id="listPane">
                    <tr>
                        <td>
                            <h4>
                                Parent Menu List
                            </h4>
                            <asp:ImageButton ID="refreshImageButton" ToolTip="Refresh" runat="server" Enabled="false"
                                ImageUrl="~/Content/Images/refresh1.png" OnClick="refreshImageButton_Click" />
                            <asp:ListBox ID="groupWiseMenuListListBox" runat="server"></asp:ListBox>
                            <asp:Label ID="countSubParentMenuLabel" runat="server" Text="Total: 0"></asp:Label>
                        </td>
                        <td>
                            <label>
                                &nbsp
                            </label>
                            <label>
                                ------------------------------
                            </label>
                            <asp:Button ID="getChildsButton" CssClass="btn btn-info" runat="server" Enabled="false"
                                Text=">>" OnClick="getChildsButton_Click" />
                            <label>
                                ------------------------------
                            </label>
                        </td>
                        <td>
                            <h4>
                                Child Menu List
                            </h4>
                            <asp:ImageButton ID="upImageButton" ToolTip="Up" runat="server" Enabled="false" ImageUrl="~/Content/Images/uparrow.png"
                                OnClick="upImageButton_Click" />
                            <asp:ImageButton ID="downImageButton" ToolTip="Down" runat="server" Enabled="false"
                                ImageUrl="~/Content/Images/downarrow.png" OnClick="downImageButton_Click" />
                            <asp:ListBox ID="groupWiseUserMenuListListBox" runat="server"></asp:ListBox>
                            <asp:Label ID="countChildMenuLabel" runat="server" Text="Total: 0"></asp:Label>
                        </td>
                    </tr>
                </table>
                <hr />
                <asp:Button ID="saveButton" CssClass="btn btn-primary" runat="server" Text="Save"
                    Enabled="false" OnClick="saveButton_Click" />
            </div>
        </fieldset>
    </div>
    <asp:HiddenField ID="parentMenuIdHiddenField" runat="server" />
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

            $("#refreshMenuImageButton, #allMenuImageButton").click(function () {
                $("#menuGroupDropDownList").rules("remove");
                $("#menuLevelDropDownList").rules("remove");
            });

            //$(".navigation ul ul").css({ display: "none" });
            $(".navigation ul li").click(function () {
                $(this).find('ul:first').fadeToggle(500);
            });
        });
    </script>
</asp:Content>
