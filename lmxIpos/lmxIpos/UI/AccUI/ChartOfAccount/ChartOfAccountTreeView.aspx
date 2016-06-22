<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true" EnableEventValidation="false"
    CodeBehind="ChartOfAccountTreeView.aspx.cs" Inherits="lmxIpos.UI.AccUI.ChartOfAccount.ChartOfAccountTreeView" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
    <link href="/Content/Style/CSSPages/ChartOfAccountTreeView.css" rel="stylesheet"
        type="text/css" />
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="true">
        <ContentTemplate>
            <div class="title-sitemap grid-12">
                <h1 class="grid-6">
                    <i>&#xf132;</i>Chart Of Account Tree View<span>Tree Viewing Chart Of Account</span></h1>
                <div class="sitemap grid-6">
                    <%--<ul>
                        <li><span>IPOS</span><i>/</i></li>
                        <li><a href="/Default.aspx">Dashboard</a></li>
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
                            System Chart Of Account Tree View</h3>
                    </header>
                    <div class="widget-body no-padding">
                        <div class="widget-separator  grid-12">
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">
                                    Account Type
                                </h5>
                                <asp:DropDownList ID="accountTypeDropDownList" runat="server" CssClass="form form-full">
                                    <asp:ListItem Value="All">All</asp:ListItem>
                                    <asp:ListItem Value="A">Asset</asp:ListItem>
                                    <asp:ListItem Value="L">Liability</asp:ListItem>
                                    <asp:ListItem Value="I">Income</asp:ListItem>
                                    <asp:ListItem Value="E">Expendituer</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="widget-separator no-border grid-3" style="margin-top: 29px;">
                                <asp:Button ID="accountListButton" runat="server" Text="Get Chart Of Account Tree"
                                    CssClass="btn btn-info clickProcessing" OnClick="accountListButton_Click" />
                            </div>
                        </div>
                        <div class="widget-separator no-border grid-12">
                            <asp:LinkButton ID="expandAllLinkButton" runat="server" CssClass="btn btn-mini btn-success clickProcessing"
                                OnClick="expandAllLinkButton_Click">(-) Expand All</asp:LinkButton>
                            <asp:LinkButton ID="collapseAllLinkButton" runat="server" CssClass="btn btn-mini btn-success clickProcessing"
                                OnClick="collapseAllLinkButton_Click">(+) Collapse All</asp:LinkButton>
                        </div>
                        <div class="widget-separator no-border grid-12">
                            <div id="treeView">
                                <asp:TreeView ID="chartOfAccountTreeView" runat="server" ShowLines="true">
                                </asp:TreeView>
                            </div>
                        </div>
                    </div>
                </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="scriptContent" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
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
