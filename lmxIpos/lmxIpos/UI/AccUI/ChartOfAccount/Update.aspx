<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true" EnableEventValidation="false"
    CodeBehind="Update.aspx.cs" Inherits="lmxIpos.UI.AccUI.ChartOfAccount.Update" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="false">
        <ContentTemplate>
            <div class="title-sitemap grid-12">
                <h1 class="grid-6">
                    <i>&#xf132;</i>Update Chart Of Account<span>Updating Chart Of Account</span></h1>
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
                            Update Chart Of Account of <asp:Label ID="idLabel" runat="server" Text=""></asp:Label></h3>
                    </header>
                    <div class="widget-body no-padding">
                        <div class="grid-12">
                            <div class="widget-separator grid-3">
                                <h5 class="typo">
                                    Account Type
                                </h5>
                                <asp:DropDownList ID="accountTypeDropDownList" runat="server" Enabled="false" CssClass="form form-full">
                                    <asp:ListItem Value="A">Asset</asp:ListItem>
                                    <asp:ListItem Value="L">Liability</asp:ListItem>
                                    <asp:ListItem Value="I">Income</asp:ListItem>
                                    <asp:ListItem Value="E">Expendituer</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="widget-separator grid-3">
                                <h5 class="typo">
                                    Account Name
                                </h5>
                                <asp:TextBox ID="accountNameTextBox" runat="server" CssClass="form form-full" required="required" placeholder="Account Name"></asp:TextBox>
                            </div>
                            <div class="widget-separator grid-3">
                                <div class="grid-12">
                                    <h5 class="typo">
                                        Totalling Account Number</h5>
                                </div>
                                <div class="grid-11">
                                    <div class="grid-1">
                                        <span id="selectTotallingAccount" class="add-on"><i class="icon-list"></i></span>
                                    </div>
                                    <div class="grid-11">
                                        <asp:TextBox ID="totallingAccountNumberTextBox" runat="server" CssClass="form form-full" required="required"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="widget-separator grid-3">
                                <h5 class="typo">
                                    Posted
                                </h5>
                                <asp:DropDownList ID="postedDropDownList" runat="server" Enabled="false" CssClass="form form-full">
                                    <asp:ListItem Value="True">Yes</asp:ListItem>
                                    <asp:ListItem Value="False" Selected="True">No</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="widget-separator grid-3">
                                <h5 class="typo">
                                    Use As
                                </h5>
                                <asp:DropDownList ID="useAsDropDownList" runat="server" CssClass="form form-full">
                                    <asp:ListItem Value="BankHead">Bank Account Head</asp:ListItem>
                                    <asp:ListItem Value="CashHead">Cash Account Head</asp:ListItem>
                                    <asp:ListItem Value="Others" Selected="True">Others</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="widget-separator grid-3">
                                <h5 class="typo">
                                    Bank Account Number (if any)
                                </h5>
                                <asp:TextBox ID="bankAccountNumberTextBox" runat="server" CssClass="form form-full" placeholder="Bank Account Number"></asp:TextBox>
                            </div>
                            <div class="widget-separator grid-6">
                                <h5 class="typo">
                                    Description
                                </h5>
                                <asp:TextBox ID="descriptionTextBox" runat="server" CssClass="form form-full" placeholder="Description"></asp:TextBox>
                            </div>
                        </div>
                        <div class="widget-separator no-border grid-12">
                            <asp:Button ID="updateButton" runat="server" Text="Update" CssClass="btn btn-submit btn-3d"
                                OnClick="updateButton_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="chartOfAccountIdForUpdateHiddenField" runat="server" />
            <asp:HiddenField ID="chartOfAccountNameForUpdateHiddenField" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="scriptContent" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        $(function () {
            $(".add-on").css("cursor", "not-allowed");
            $("#totallingAccountNumberTextBox").attr("ReadOnly", true);
        });
    </script>
    <script type="text/javascript">
        function pageLoad(sender, args) {
            $("#updateButton").click(function (e) {
                $("#accountNameTextBox").rules("add", {
                    required: true
                });

                $("#totallingAccountNumberTextBox").rules("add", {
                    required: true
                });

                if (haveOverlay == 0) {
                    MyOverlayStart();
                }
            });
        }
    </script>
</asp:Content>
