<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true" EnableEventValidation="false"
    CodeBehind="List.aspx.cs" Inherits="lmxIpos.UI.AccUI.ChartOfAccount.List" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
    <link href="/Content/Style/CSSPages/ChartOfAccountList.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="true">
        <ContentTemplate>
            <div class="title-sitemap grid-12">
                <h1 class="grid-6">
                    <i>&#xf132;</i>Chart Of Account List<span>Created Chart Of Account List</span></h1>
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
                            
                        </div>
                        <h3 id="Header3" runat="server" class="widget-header-title">System Chart Of Account List</h3>
                    </header>
                    <div class="widget-body no-padding">
                        <div class="widget-separator no-padding grid-12">
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Account Type
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
                                <asp:Button ID="accountListButton" runat="server" Text="Get Chart Of Account List"
                                    CssClass="btn btn-info" OnClick="accountListButton_Click" />
                            </div>
                        </div>
                        <div class="widget-separator no-border grid-12">
                            <div id="chartOfAccountListGridContainer">
                                <asp:GridView ID="chartOfAccountListGridView" runat="server" AutoGenerateColumns="false"
                                    CssClass="table table-hover gridView">
                                    <Columns>
                                        <asp:BoundField DataField="AccountId" HeaderText="ID" />
                                        <asp:BoundField DataField="AccountName" HeaderText="Account Name" />
                                        <asp:BoundField DataField="AccountNumber" HeaderText="Acc.No." />
                                        <asp:BoundField DataField="TotallingAccountNumber" HeaderText="Totalling" />
                                        <asp:BoundField DataField="IsPosted" HeaderText="Posted" />
                                        <asp:BoundField DataField="AccountLevel" HeaderText="Level" />
                                        <asp:BoundField DataField="IsActive" HeaderText="Active" />
                                        <asp:TemplateField HeaderText="Edit">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="editLinkButton" runat="server"
                                                    OnClick="editLinkButton_Click"><span class="icon icon-2x icon-edit text-info"></span></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Activate">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="activateLinkButton" runat="server" CssClass="clickProcessing"
                                                    OnClick="activateLinkButton_Click"><span class="icon icon-2x icon-ok-circle text-success"></span></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="De-Activate">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="deactivateLinkButton" runat="server" CssClass="clickProcessing"
                                                    OnClick="deactivateLinkButton_Click"><span class="icon icon-2x icon-ban-circle text-warning"></span></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Delete">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="deleteLinkButton" runat="server" CssClass="clickProcessing"
                                                    OnClick="deleteLinkButton_Click"><span class="icon icon-2x icon-trash text-error"></span></asp:LinkButton>
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
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="scriptContent" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        function pageLoad(sender, args) {
            $("#chartOfAccountListGridView").dataTable({
                "bProcessing": true,
                "bStateSave": true,
                "sPaginationType": "full_numbers",
                "aLengthMenu": [[10, 15, 20, 25, 50, -1], [10, 15, 20, 25, 50, "All"]],
                "aoColumnDefs": [{ 'bSortable': false, 'aTargets': [7, 8, 9, 10] }]
            });
        }
    </script>
    <script type="text/javascript">
        $(function () {
            $("#accountListButton").live("click", function (e) {
                if (haveOverlay == 0) {
                    MyOverlayStart();
                }
            });

            $("#editLinkButton").live("click", function (e) {
                MyOverlayStart();
            });

            $(".clickProcessing").live("click", function (e) {
                if (haveOverlay == 0) {

                    var col = $(this).parent().children().parent().index();
                    var row = $(this).parent().parent().index();
                    accountId = $("#chartOfAccountListGridView").find("tr td:nth-child(1)").eq(row).text();
                    isActive = $("#chartOfAccountListGridView").find("tr td:nth-child(7)").eq(row).text();

                    var id = $(this).attr("id");
                    var str = $(this).attr("href");
                    var arr = str.split("'");
                    var msg = "";

                    if (isActive == "True" && id == "activateLinkButton") {
                        WarningAlert("Process Redundant", "This Chart Of Account <span class='actionTopic'>already activated</span>.", "");
                    }
                    else if (isActive == "False" && id == "deactivateLinkButton") {
                        WarningAlert("Process Redundant", "This Chart Of Account <span class='actionTopic'>already deactivated</span>.", "");
                    }
                    else {
                        if (id == "activateLinkButton") {
                            msg = "Are you sure you want to <span class='actionTopic'>activate</span> this Chart Of Account?";
                        }
                        else if (id == "deactivateLinkButton") {
                            msg = "Are you sure you want to <span class='actionTopic'>deactivate</span> this Chart Of Account?";
                        }
                        else if (id == "deleteLinkButton") {
                            msg = "Are you sure you want to <span class='actionTopic'>delete</span> this Chart Of Account?";
                        }

                        ConfirmProcess(msg, function () {
                            MyOverlayStart();
                            __doPostBack(arr[1], '');
                        }, function () {

                        });
                    }

                    e.preventDefault();
                }
            });
        });
    </script>
</asp:Content>
