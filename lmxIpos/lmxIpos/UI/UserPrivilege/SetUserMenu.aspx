<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true" EnableEventValidation="false"
    CodeBehind="SetUserMenu.aspx.cs" Inherits="lmxIpos.UI.UserPrivilege.SetUserMenu" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
   
    <link href="/content/css/SetUserPrivilige.css" rel="stylesheet" type="text/css" />
    <link href="/content/css/AppMenuTest.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="false">
        <ContentTemplate>
            <div class="title-sitemap grid-12">
                <h1 class="grid-6">
                    <i>&#xf132;</i>User Menu<span>Setting User Menu</span></h1>
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
                            Set User Menu</h3>
                    </header>
                    <div class="widget-body no-padding">
                        <div class="widget-separator grid-12">
                            <div id="MenuContent">
                                <div id="allMenuList">
                                    <asp:Menu ID="testAllMenu" runat="server" Orientation="Horizontal" MaximumDynamicDisplayLevels="9"
                                        StaticEnableDefaultPopOutImage="true" StaticPopOutImageUrl="~/content/images/arrow_a.gif"
                                        DynamicEnableDefaultPopOutImage="true" DynamicPopOutImageUrl="~/content/images/arrow_a.gif"
                                        CssClass="navigation">
                                    </asp:Menu>
                                </div>
                                <div id="allMenuImg">
                                    <asp:ImageButton ID="refreshMenuImageButton" runat="server" AlternateText="All Menu"
                                        CssClass="menuProcessing" ToolTip="Refresh Menu" ImageUrl="~/content/images/Refresh-icon.png"
                                        OnClick="refreshMenuImageButton_Click" />
                                    <asp:ImageButton ID="allMenuImageButton" runat="server" AlternateText="All Menu"
                                        CssClass="menuProcessing" ToolTip="Get All Menu" ImageUrl="~/content/images/database-icon.png"
                                        OnClick="allMenuImageButton_Click" />
                                </div>
                            </div>
                        </div>
                        <div id="userPriviligePane" runat="server" visible="false">
                            <div id="userInfoPane">
                                <div class="widget-separator no-padding grid-12">
                                    <div class="widget-separator grid-6">
                                        <div class="grid-4">
                                            User ID:
                                        </div>
                                        <div class="grid-8">
                                            <asp:Label ID="userIdLabel" runat="server" CssClass="infoLabel" Text=""></asp:Label>
                                        </div>
                                    </div>
                                    <div class="widget-separator grid-6">
                                        <div class="grid-4">
                                            User Name:
                                        </div>
                                        <div class="grid-8">
                                            <asp:Label ID="userNameLabel" runat="server" CssClass="infoLabel" Text=""></asp:Label>
                                        </div>
                                    </div>
                                    <div class="widget-separator grid-6">
                                        <div class="grid-4">
                                            User Group:
                                        </div>
                                        <div class="grid-8">
                                            <asp:Label ID="userGroupNameLabel" runat="server" CssClass="infoLabel" Text=""></asp:Label>
                                        </div>
                                    </div>
                                    <div class="widget-separator grid-6">
                                        <div class="grid-4">
                                            Employee ID:
                                        </div>
                                        <div class="grid-8">
                                            <asp:Label ID="employeeIdLabel" runat="server" CssClass="infoLabel" Text=""></asp:Label>
                                        </div>
                                    </div>
                                    <div class="widget-separator no-border grid-6">
                                        <div class="grid-4">
                                            Activation Status:
                                        </div>
                                        <div class="grid-8">
                                            <asp:Label ID="activeStatusLabel" runat="server" CssClass="infoLabel" Text=""></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="widget-separator">
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
                                                        runat="server" Text="Add" OnClick="addButton_Click" /></div>
                                                <div class="grid-12">
                                                    <asp:Button ID="removeButton" CssClass="btn btn-error clickProcessing form form-full"
                                                        runat="server" Text="Remove" OnClick="removeButton_Click" /></div>
                                            </div>
                                            <div class="widget-separator no-border grid-12">
                                                <div class="grid-12">
                                                    <asp:Button ID="addAllButton" CssClass="btn btn-warning clickProcessing form form-full"
                                                        runat="server" Text="Add All" OnClick="addAllButton_Click" /></div>
                                                <div class="grid-12">
                                                    <asp:Button ID="removeAllButton" CssClass="btn btn-error clickProcessing form form-full"
                                                        runat="server" Text="Remove All" OnClick="removeAllButton_Click" /></div>
                                            </div>
                                        </div>
                                        <div class="widget-separator no-border grid-5">
                                            <h4>
                                                Group Wise User's Menu List</h4>
                                            <asp:ListBox ID="groupWiseUserMenuListListBox" runat="server" CssClass="form form-full">
                                            </asp:ListBox>
                                            <asp:Label ID="countUserMenuLabel" runat="server" Text="Total: 0"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="widget-separator no-border grid-3">
                                    <asp:Button ID="saveButton" CssClass="btn btn-success btn-3d" runat="server" Text="Save"
                                        OnClick="saveButton_Click" />
                                    <asp:Button ID="cancelButton" CssClass="btn btn-default btn-3d clickProcessing" runat="server"
                                        Text="Cancel" OnClick="cancelButton_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="saveButton" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="cancelButton" EventName="Click" />
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
            //            $(".navigation ul li").click(function () {
            //                $(this).find('ul:first').fadeToggle(500);
            //            });

            $("#saveButton").click(function () {


                if (haveOverlay == 0) {
                    MyOverlayStart();
                }
            });


            $(".menuProcessing").click(function () {
                //                $("#menuForAppDropDownList").rules("add", {
                //                    required: true
                //                });

                //                $("#menuTypeDropDownList").rules("add", {
                //                    required: true
                //                });

                if (haveOverlay == 0) {
                    // $("#form1").valid();

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
