<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true" EnableEventValidation="false"
    CodeBehind="SetUserWarehouse.aspx.cs" Inherits="lmxIpos.UI.UserPrivilege.SetUserWarehouse" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
    <link href="/Content/Style/CSSPages/SetUserPrivilige.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server" ID="UpdatePanel1">
        <ContentTemplate>
            <div class="title-sitemap grid-12">
                <h1 class="grid-6">
                    <i>&#xf132;</i>User Warehouse<span>Setting User Warehouse</span></h1>
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
                            Set User Warehouse</h3>
                    </header>
                    <div class="widget-body no-padding">
                        <div id="userPriviligePane" runat="server" visible="false">
                            <div id="userInfoPane">
                                <div class="grid-12">
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
                                <div id="listPane" class="widget-separator grid-12">
                                    <div class="widget-separator no-border grid-5">
                                        <h4>
                                            Warehouse List</h4>
                                        <asp:ListBox ID="warehouseListListBox" runat="server" CssClass="form form-full">
                                        </asp:ListBox>
                                        <asp:Label ID="countWarehouseLabel" runat="server" Text="Total: 0"></asp:Label>
                                    </div>
                                    <div class="widget-separator no-border grid-2">
                                        <div class="widget-separator grid-12">
                                            <div class="grid-12">
                                                <asp:Button ID="addButton" CssClass="btn btn-submit btn-border clickProcessing form form-full"
                                                    runat="server" Text="Add" OnClick="addButton_Click" /></div>
                                            <div class="grid-12">
                                                <asp:Button ID="removeButton" CssClass="btn btn-warning btn-border clickProcessing form form-full"
                                                    runat="server" Text="Remove" OnClick="removeButton_Click" /></div>
                                        </div>
                                        <div class="widget-separator no-border grid-12">
                                            <div class="grid-12">
                                                <asp:Button ID="addAllButton" CssClass="btn btn-submit btn-border clickProcessing form form-full"
                                                    runat="server" Text="Add All" OnClick="addAllButton_Click" /></div>
                                            <div class="grid-12">
                                                <asp:Button ID="removeAllButton" CssClass="btn btn-warning btn-border clickProcessing form form-full"
                                                    runat="server" Text="Remove All" OnClick="removeAllButton_Click" /></div>
                                        </div>
                                    </div>
                                    <div class="widget-separator no-border grid-5">
                                        <h4>
                                            User's Warehouse List</h4>
                                        <asp:ListBox ID="userWarehouseListListBox" runat="server" CssClass="form form-full"></asp:ListBox>
                                        <asp:Label ID="countUserWarehouseLabel" runat="server" Text="Total: 0"></asp:Label>
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
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="scriptContent" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        function pageLoad(sender, args) {
            $("#saveButton").click(function () {
                if (haveOverlay == 0) {
                    MyOverlayStart();
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
        });
    </script>
</asp:Content>
