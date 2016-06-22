<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true" EnableEventValidation="false"
    CodeBehind="UpdateMenuGroup.aspx.cs" Inherits="IPOSSystem.UI.AppMenu.UpdateMenuGroup" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <div id="body_content">
        <fieldset>
            <legend>Update Menu Group [<asp:Label ID="idLabel" runat="server" Text=""></asp:Label>]</legend>
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
                            Enabled="false" OnSelectedIndexChanged="menuForAppDropDownList_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <label>
                            Menu Type
                        </label>
                        <asp:DropDownList ID="menuTypeDropDownList" runat="server" Enabled="false">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <label>
                            Menu Target
                        </label>
                        <asp:DropDownList ID="menuTargetDropDownList" runat="server">
                            <asp:ListItem>_blank</asp:ListItem>
                            <asp:ListItem Selected="True">_parent</asp:ListItem>
                            <asp:ListItem>_search</asp:ListItem>
                            <asp:ListItem>_self</asp:ListItem>
                            <asp:ListItem>_top</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label>
                            Menu Group Name
                        </label>
                        <asp:TextBox ID="menuGroupNameTextBox" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <label>
                            Display Name
                        </label>
                        <asp:TextBox ID="displayNameTextBox" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2">
                        <label>
                            Description
                        </label>
                        <asp:TextBox ID="descriptionTextBox" runat="server" Width="448"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <label>
                            Menu URL
                        </label>
                        <asp:TextBox ID="urlTextBox" runat="server" Width="448"></asp:TextBox>
                    </td>
                    <td colspan="2">
                        <label>
                            Image URL
                        </label>
                        <asp:TextBox ID="imageURLTextBox" runat="server" Width="448"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <div>
                <label class="infoLabel">
                    *** URL Note: Use " javascript:void(0) " as blank URL instead of symbol ' # '
                </label>
            </div>
            <hr />
            <asp:Button ID="updateButton" runat="server" Text="Update" CssClass="btn btn-primary"
                OnClick="updateButton_Click" />
        </fieldset>
    </div>
    <asp:HiddenField ID="appMenuGroupIdForUpdateHiddenField" runat="server" />
    <asp:HiddenField ID="appMenuGroupNameHiddenField" runat="server" />
</asp:Content>
<asp:Content ID="scriptContent" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        $(function () {
            $("#menuGroupNameTextBox").rules("add", {
                required: true
            });

            $("#displayNameTextBox").rules("add", {
                required: true
            });

            $("#urlTextBox").rules("add", {
                required: true
            });
        });
    </script>
</asp:Content>
