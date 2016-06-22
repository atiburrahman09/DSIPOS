<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true" EnableEventValidation="false"
    CodeBehind="SetUserGroupMenu.aspx.cs" Inherits="lmxIpos.UI.UserPrivilege.SetUserGroupMenu" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
    <link href="/content/css/AppMenuTest.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="false">
        <ContentTemplate>
            <div class="title-sitemap grid-12">
                <h1 class="grid-6">
                    <i>&#xf132;</i>User Group Menu<span>Setting User Group Menu</span></h1>
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
                            Set User Group Menu</h3>
                    </header>
                    <div class="widget-body no-padding">
                        <div class="widget-separator no-padding grid-12">
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">
                                    User Group</h5>
                                <asp:DropDownList ID="userGroupDropDownList" runat="server" CssClass="form form-full"
                                    placeholder="User Group" required="required">
                                </asp:DropDownList>
                            </div>
                            <div class="widget-separator no-border grid-3" style="margin-top: 29px;">
                                <asp:Button ID="userGroupMenuListButton" runat="server" Text="Get User Group Menu List"
                                    CssClass="btn btn-info" OnClick="userGroupMenuListButton_Click" />
                            </div>
                        </div>
                        <div id="userPriviligePane" runat="server" visible="false">
                            <div class="widget-separator grid-12">
                                <div id="MenuContent">
                                    <div id="allMenuList">
                                        <asp:Menu ID="testAllMenu" runat="server" Orientation="Horizontal" MaximumDynamicDisplayLevels="9"
                                            StaticEnableDefaultPopOutImage="true" StaticPopOutImageUrl="~/Content/Images/arrow_a.gif"
                                            DynamicEnableDefaultPopOutImage="true" DynamicPopOutImageUrl="~/Content/Images/arrow_a.gif"
                                            CssClass="navigation">
                                        </asp:Menu>
                                    </div>
                                    <div id="allMenuImg">
                                        <asp:ImageButton ID="refreshMenuImageButton" runat="server" AlternateText="Refresh"
                                            CssClass="menuProcessing" ToolTip="Refresh Menu" ImageUrl="~/content/images/Refresh-icon.png"
                                            OnClick="refreshMenuImageButton_Click" />
                                        <asp:ImageButton ID="allMenuImageButton" runat="server" AlternateText="All Menu"
                                            Visible="false" CssClass="menuProcessing" ToolTip="Get All Menu" ImageUrl="~/Content/Images/database-icon.png"
                                            OnClick="allMenuImageButton_Click" />
                                    </div>
                                    <div class="empty">
                                    </div>
                                </div>
                            </div>
                            <div class="widget-separator no-padding grid-12">
                                <div id="userMenuSearch">
                                    <div class="grid-2">
                                        &nbsp;</div>
                                    <div class="grid-8">
                                        <div class="grid-12">
                                            <div class="widget-separator no-border grid-4">
                                                <h5 class="typo">
                                                    Menu For App.</h5>
                                                <asp:DropDownList ID="menuForAppDropDownList" runat="server" AutoPostBack="true"
                                                    CssClass="indexChangeProcessing form form-full" OnSelectedIndexChanged="menuForAppDropDownList_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                            <div class="widget-separator no-border grid-4">
                                                <h5 class="typo">
                                                    Menu Type</h5>
                                                <asp:DropDownList ID="menuTypeDropDownList" runat="server" AutoPostBack="true" CssClass="indexChangeProcessing form form-full"
                                                    OnSelectedIndexChanged="menuTypeDropDownList_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                            <div class="widget-separator no-border grid-4">
                                                <h5 class="typo">
                                                    Menu Group</h5>
                                                <asp:DropDownList ID="menuGroupDropDownList" runat="server" AutoPostBack="true" CssClass="indexChangeProcessing form form-full"
                                                    OnSelectedIndexChanged="menuGroupDropDownList_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div id="userMenuPane" runat="server" visible="false">
                                <div id="listPane" class="widget-separator grid-12">
                                    <div class="widget-separator no-border grid-5">
                                        <h4>
                                            Group Wise Menu List</h4>
                                        <asp:ListBox ID="groupWiseMenuListListBox" runat="server" CssClass="form form-full">
                                        </asp:ListBox>
                                        <asp:Label ID="countMenuLabel" runat="server" Text="Total: 0"></asp:Label>
                                    </div>
                                    <div class="widget-separator no-border grid-2">
                                        <div class="widget-separator grid-12">
                                            <div class="grid-12">
                                                <asp:Button ID="addButton" CssClass="btn btn-warning clickProcessing form form-full"
                                                    runat="server" Text="Add" OnClick="addButton_Click" />
                                            </div>
                                            <div class="grid-12">
                                                <asp:Button ID="removeButton" CssClass="btn btn-danger clickProcessing form form-full"
                                                    runat="server" Text="Remove" OnClick="removeButton_Click" />
                                            </div>
                                        </div>
                                        <div class="widget-separator no-border grid-12">
                                            <div class="grid-12">
                                                <asp:Button ID="addAllButton" CssClass="btn btn-warning clickProcessing form form-full"
                                                    runat="server" Text="Add All" OnClick="addAllButton_Click" />
                                            </div>
                                            <div class="grid-12">
                                                <asp:Button ID="removeAllButton" CssClass="btn btn-danger clickProcessing form form-full"
                                                    runat="server" Text="Remove All" OnClick="removeAllButton_Click" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="widget-separator no-border grid-5">
                                        <h4>
                                            Group Wise User Group's Menu List</h4>
                                        <asp:ListBox ID="groupWiseUserGroupMenuListListBox" runat="server" CssClass="form form-full">
                                        </asp:ListBox>
                                        <asp:Label ID="countUserMenuLabel" runat="server" Text="Total: 0"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="widget-separator no-border grid-12">
                                <asp:Button ID="saveButton" CssClass="btn btn-success btn-3d" runat="server" Text="Save"
                                    OnClick="saveButton_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="userGroupIdForSetMenuHiddenField" runat="server" />
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger EventName="Click" ControlID="userGroupMenuListButton" />
            <asp:AsyncPostBackTrigger ControlID="saveButton" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="addButton" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="addAllButton" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="removeAllButton" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="removeButton" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="refreshMenuImageButton" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="refreshMenuImageButton" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="menuForAppDropDownList" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="menuTypeDropDownList" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="menuGroupDropDownList" EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="scriptContent" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        function pageLoad(sender, args) {
            //$(".navigation ul ul:hover").css({ display: "none" });
            $(".navigation ul li").click(function () {
                $(this).find('ul:first').fadeToggle(500);
            });

            $('#userGroupDropDownList option:contains("Super Admin")').attr("disabled", true);

            $("#userGroupMenuListButton").click(function () {
                $("#userGroupDropDownList").rules("add", {
                    required: true
                });

                if (haveOverlay == 0) {
                    $("#form1").valid();

                    if (haveOverlay == 1) {
                        return false;
                    } else {
                        MyOverlayStart();
                    }
                }
            });

            $("#saveButton").click(function () {
                $("#menuForAppDropDownList").rules("add", {
                    required: true
                });

                $("#menuTypeDropDownList").rules("add", {
                    required: true
                });

                $("#menuGroupDropDownList").rules("add", {
                    required: true
                });

                if (haveOverlay == 0) {
                    $("#form1").valid();

                    if (haveOverlay == 1) {
                        return false;
                    } else {
                        MyOverlayStart();
                    }
                }
            });

            $(".menuProcessing").click(function () {
                $("#menuForAppDropDownList").rules("add", {
                    required: true
                });

                $("#menuTypeDropDownList").rules("add", {
                    required: true
                });

                if (haveOverlay == 0) {
                    $("#form1").valid();

                    if (haveOverlay == 1) {
                        return false;
                    } else {
                        MyOverlayStart();
                    }
                }
            });
        }
    </script>
    <script type="text/javascript">
        $(function () {
            $(".clickProcessing").live("click", function () {
                if (haveOverlay == 0) {
                    MyOverlayStart();
                }
            });

            $(".indexChangeProcessing").live("change", function () {
                if (haveOverlay == 0) {
                    MyOverlayStart();
                }
            });
        });
    </script>
</asp:Content>
