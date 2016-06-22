<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true"
    CodeBehind="ChangePassword.aspx.cs" Inherits="lmxIpos.UI.User.ChangePassword" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
    <link href="/Content/Style/PasswordStrength.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="false">
        <ContentTemplate>
            <div class="title-sitemap grid-12">
                <h1 class="grid-6">
                    <i>&#xf132;</i>Change User Password<span>Changing User Password</span></h1>
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
                            Change User Password Form</h3>
                    </header>
                    <div class="widget-body no-padding">
                        <div class="widget-separator no-padding grid-12">
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">
                                    Current Password</h5>
                                <asp:TextBox ID="currentPasswordTextBox" runat="server" TextMode="Password" required="required"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="2" ControlToValidate="currentPasswordTextBox"
                                    ErrorMessage="*" Display="Dynamic" ForeColor="red" runat="server" />
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">
                                    New Password</h5>
                                <asp:TextBox ID="newPasswordTextBox" runat="server" TextMode="Password" required="required"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rqrvalidpass" ValidationGroup="2" ControlToValidate="newPasswordTextBox"
                                    ErrorMessage="*" Display="Dynamic" ForeColor="red" runat="server" /><br />
                                <asp:RegularExpressionValidator ID="revChPassword" runat="server" Display="dynamic"
                                    ControlToValidate="newPasswordTextBox" Font-Size="11px" ErrorMessage="Password must be 6-16 nonblank characters."
                                    ValidationExpression="[^\s]{6,16}" ForeColor="Red" />
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">
                                    Confirm New Password</h5>
                                <asp:TextBox ID="confirmNewPasswordTextBox" runat="server" TextMode="Password" required="required"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvConPassword" ValidationGroup="2" ControlToValidate="confirmNewPasswordTextBox"
                                    ErrorMessage="*" Display="Dynamic" ForeColor="red" runat="server" /><br />
                                <asp:CompareValidator ID="cmvPasswordRpt" Font-Size="11px" runat="server" Display="Dynamic"
                                    EnableClientScript="true" ValidationGroup="edit" ControlToValidate="confirmNewPasswordTextBox"
                                    ValidateEmptyText="true" ErrorMessage="Your passwords do not match." ControlToCompare="newPasswordTextBox"
                                    ForeColor="Red" />
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">
                                    &nbsp;</h5>
                                <asp:Label ID="passwordStrengthLabel" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        <div class="widget-separator no-border grid-12">
                            <asp:Button ID="passwordUpdateButton" ValidationGroup="2" runat="server" Text="Update Password" CssClass="btn btn-submit btn-3d"
                                OnClick="passwordUpdateButton_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="passwordUpdateButton" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="scriptContent" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script src="/Scripts/PasswordStrength.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $('#newPasswordTextBox').keyup(function () {
                $('#passwordStrengthLabel').text(checkStrength($('#newPasswordTextBox').val()));
            });
        });
    </script>
    <script type="text/javascript">
        function pageLoad(sender, args) {
            $("#passwordUpdateButton").click(function (e) {
                $("#currentPasswordTextBox").rules("add", {
                    required: true
                });

                $("#newPasswordTextBox").rules("add", {
                    required: true,
                    minlength: 6
                });

                $("#confirmNewPasswordTextBox").rules("add", {
                    equalTo: "#newPasswordTextBox"
                });

                if (haveOverlay == 0) {
                    MyOverlayStart();
                }
            });
        }
    </script>
</asp:Content>
