<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true"
    CodeBehind="ResetUserPassword.aspx.cs" Inherits="lmxIpos.UI.User.ResetUserPassword" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
    <link href="/Content/Style/PasswordStrength.css" rel="stylesheet" type="text/css" />
    <link href="/Content/Style/CSSPages/ResetUserPassword.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server" ID="UpdatePanel1">
        <ContentTemplate>
            <div class="title-sitemap grid-12">
                <h1 class="grid-6">
                    <i>&#xf132;</i>Reset User Password<span>Reseting User Password of System</span></h1>
                <div class="sitemap grid-6">
                    <%--<ul>
                        <li><span>Acura</span><i>/</i></li>
                        <li><a href="Default.aspx">Dashboard</a></li>
                    </ul>--%>
                </div>
            </div>
            <div class="data">
                <div class="grid-12">
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
                            <h3 id="H1" runat="server" class="widget-header-title">
                                System User Password Reset</h3>
                        </header>
                        <div class="widget-body no-padding">
                            <div class="widget-separator grid-12">
                                <div class="widget-separator no-border grid-3">
                                    <div class="grid-12">
                                        <h5 class="typo">
                                            User ID</h5>
                                    </div>
                                    <asp:TextBox ID="userIdTextBox" runat="server" CssClass="form form-full" placeholder="User ID"></asp:TextBox>
                                </div>
                                <div class="widget-separator no-border grid-3">
                                    <div class="grid-12">
                                    </div>
                                    <div style="padding-top: 30px;" class="grid-2">
                                        <asp:Button ID="getUserInfoButton" runat="server" Text="Get User Info" CssClass="btn btn-info"
                                            OnClick="getUserInfoButton_Click" />
                                    </div>
                                </div>
                            </div>
                            <div id="actionPane" visible="false" runat="server" class="grid-12">
                                <div class="widget-separator grid-3">
                                    <h5 class="typo">
                                        User ID:</h5>
                                    <asp:Label ID="userIdLabel" CssClass="infoLabel" runat="server" Text=""></asp:Label>
                                </div>
                                <div class="widget-separator grid-3">
                                    <h5 class="typo">
                                        User Name:</h5>
                                    <asp:Label ID="userNameLabel" CssClass="infoLabel" runat="server" Text=""></asp:Label>
                                </div>
                                <div class="widget-separator grid-3">
                                    <h5 class="typo">
                                        User Group:</h5>
                                    <asp:Label ID="userGroupLabel" CssClass="infoLabel" runat="server" Text=""></asp:Label>
                                </div>
                                <div class="widget-separator grid-3">
                                    <h5 class="typo">
                                        Contact Number:</h5>
                                    <asp:Label ID="contactNumberLabel" CssClass="infoLabel" runat="server" Text=""></asp:Label>
                                </div>
                            
                            <div class="widget-separator grid-12">
                                <div class="widget-separator no-border  grid-3">
                                    <h5 class="typo">
                                        New Password</h5>
                                    <asp:TextBox ID="newPasswordTextBox" CssClass="form form-full" runat="server" TextMode="Password"
                                        placeholder="New Password"></asp:TextBox>
                                         <asp:RequiredFieldValidator ID="rqrvalidpass" ControlToValidate="newPasswordTextBox" ValidationGroup="2"
                                    ErrorMessage="*" Display="Dynamic" ForeColor="red" runat="server" /><br />
                                <asp:RegularExpressionValidator ID="revChPassword" runat="server" Display="dynamic"
                                    ControlToValidate="newPasswordTextBox" Font-Size="11px" ErrorMessage="Password must be 6-16 nonblank characters."
                                    ValidationExpression="[^\s]{6,16}" ForeColor="Red" />
                                </div>
                                <div class="widget-separator no-border  grid-3">
                                    <h5 class="typo">
                                        Confirm New Password</h5>
                                    <asp:TextBox ID="confirmNewPasswordTextBox" CssClass="form form-full" runat="server"
                                        TextMode="Password" placeholder="Confirm New Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvConPassword" ControlToValidate="confirmNewPasswordTextBox" ValidationGroup="2"
                                    ErrorMessage="*" Display="Dynamic" ForeColor="red" runat="server" /><br />
                                <asp:CompareValidator ID="cmvPasswordRpt" Font-Size="11px" runat="server" Display="Dynamic"
                                    EnableClientScript="true" ValidationGroup="edit" ControlToValidate="confirmNewPasswordTextBox"
                                    ValidateEmptyText="true" ErrorMessage="Your passwords do not match." ControlToCompare="newPasswordTextBox"
                                    ForeColor="Red" />
                                </div>
                                <div class=" widget-separator no-border  grid-3">
                                    <h5 class="typo" id="strengthlbl">
                                        &nbsp;</h5>
                                    <div class="grid-11">
                                        <asp:Label ID="passwordStrengthLabel" CssClass="form form-full" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="widget-separator no-border grid-12">
                                <asp:Button ID="passwordResetButton" runat="server" ValidationGroup="2" Text="Reset Password" CssClass="btn btn-submit btn-3d"
                                    OnClick="passwordResetButton_Click" />
                            </div>
                            </div>
                            
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="getUserInfoButton" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="passwordResetButton" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="scriptContent" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script src="/Scripts/PasswordStrength.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {

        });
    </script>
    <script type="text/javascript">
        function pageLoad(sender, args) {
            $("#getUserInfoButton").click(function () {
                $('input, select, textarea').each(function () {
                    $(this).rules('remove');
                    $(this).removeClass('error');
                });

                $("#userIdTextBox").rules("add", {
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

            $("#passwordResetButton").click(function () {
                $('input, select, textarea').each(function () {
                    $(this).rules('remove');
                    $(this).removeClass('error');
                });

                $("#newPasswordTextBox").rules("add", {
                    required: true,
                    minlength: 6
                });

                $("#confirmNewPasswordTextBox").rules("add", {
                    equalTo: "#newPasswordTextBox"
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

            $('#newPasswordTextBox').keyup(function () {
                $('#passwordStrengthLabel').text(checkStrength($('#newPasswordTextBox').val()));
            });
        }
    </script>
</asp:Content>
