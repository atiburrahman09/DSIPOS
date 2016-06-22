<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true"
    CodeBehind="PrivilegeUserList.aspx.cs" Inherits="lmxIpos.UI.UserPrivilege.PrivilegeUserList" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
    <%--  <link href="/Content/Style/CSSPages/PrivilegeUserList.css" rel="stylesheet" type="text/css" />--%>
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="true">
        <ContentTemplate>
            <div class="title-sitemap grid-12">
                <h1 class="grid-6">
                    <i>&#xf132;</i>Privilege User List<span>Setting User Privilege</span></h1>
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
                            System Privilege User List</h3>
                    </header>
                    <div class="widget-body no-padding">
                        <div class="widget-separator no-border grid-12">
                            <div id="userListGridContainer">
                                <asp:GridView ID="userListGridView" runat="server" AutoGenerateColumns="false" CssClass="table table-hover gridView dataTable">
                                    <Columns>
                                        <asp:BoundField DataField="UserId" HeaderText="User ID" />
                                        <asp:BoundField DataField="UserName" HeaderText="User Name" />
                                        <asp:BoundField DataField="UserGroupName" HeaderText="User Group Name" />
                                        <asp:BoundField DataField="IsActive" HeaderText="Active" />
                                        <asp:TemplateField HeaderText="Menu Access">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="setMenuLinkButton" runat="server" CssClass="btn btn-mini btn-info clickProcessing"
                                                    OnClick="setMenuLinkButton_Click">Set Menu</asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="setWarehouseLinkButton" runat="server" CssClass="btn btn-mini btn-success clickProcessing"
                                                    OnClick="setWarehouseLinkButton_Click">Set Warehouse</asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Sales Center">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="setSalesCenterLinkButton" runat="server" CssClass="btn btn-mini btn-info clickProcessing"
                                                    OnClick="setSalesCenterLinkButton_Click">Set Sales Center</asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="userListGridView" EventName="RowDataBound" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="scriptContent" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        function pageLoad(sender, args) {
            $("#userListGridView").dataTable({
                "bProcessing": true,
                "bStateSave": true,
                "sPaginationType": "full_numbers"
                //                "aLengthMenu": [[10, 15, 20, 25, 50, 100, -1], [10, 15, 20, 25, 50, 100, "All"]],
                //                "aoColumnDefs": [{ 'bSortable': false, 'aTargets': [5, 6, 7]}]
            });

            $(".clickProcessing").live("click", function () {
                if (haveOverlay == 0) {
                    MyOverlayStart();
                }
            });
        };
    </script>
</asp:Content>
