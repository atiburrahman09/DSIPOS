<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true" EnableEventValidation="false"
    CodeBehind="Create.aspx.cs" Inherits="lmxIpos.UI.User.Create" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
    <link href="/Content/Style/PasswordStrength.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="false">
        <ContentTemplate>
            <div class="title-sitemap grid-12">
                <h1 class="grid-6">
                    <i>&#xf132;</i>Create User<span>Creating System Users</span></h1>
                <div class="sitemap grid-6">
                    <ul>
                        <li><span>IPOS</span><i>/</i></li>
                        <li><a href="/Default.aspx">Dashboard</a></li>
                    </ul>
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
                            User Create Form</h3>
                    </header>
                    <div class="widget-body no-padding">
                        <div class="widget-separator no-border no-padding grid-12">
                            <div class="widget-separator grid-3">
                                <h5 class="typo">
                                    User ID</h5>
                                <asp:TextBox ID="userIdTextBox" placeholder="User Id" CssClass="form form-full" runat="server"
                                    required="required"></asp:TextBox>
                            </div>
                            <div class="widget-separator grid-3">
                                <h5 class="typo">
                                    Full Name</h5>
                                <asp:TextBox ID="userNameTextBox" placeholder="User Name" CssClass="form form-full"
                                    runat="server" required="required"></asp:TextBox>
                            </div>
                            <%-- <div class="widget-separator grid-3">
                                <h5 class="typo">
                                    Employee Id ID</h5>
                                <asp:TextBox ID="employeeIdTextBox" placeholder="Employee Id" CssClass="form form-full"
                                    runat="server"></asp:TextBox>
                            </div>--%>
                            <div class="widget-separator grid-3">
                                <h5 class="typo">
                                    User Group</h5>
                                <asp:DropDownList ID="userGroupDropDownList" CssClass="form form-full" runat="server"
                                    required="required">
                                </asp:DropDownList>
                            </div>
                            <div class="widget-separator grid-3">
                                <h5 class="typo">
                                    Sales Center Name
                                </h5>
                                <asp:DropDownList ID="salesCenterDropDownList" runat="server" CssClass="form form-full">
                                </asp:DropDownList>
                            </div>
                            <%--<div class="widget-separator grid-3">
                                <h5 class="typo">
                                    Designation</h5>
                                <asp:TextBox ID="designationTextBox" CssClass="form form-full" placeholder="Designation"
                                    runat="server"></asp:TextBox>
                            </div>--%>
                            <div class="widget-separator grid-3">
                                <h5 class="typo">
                                    Warehouse Name</h5>
                                <asp:DropDownList ID="warehouseDropDownList" runat="server" CssClass="form form-full">
                                </asp:DropDownList>
                            </div>
                            <div class="widget-separator grid-3">
                                <h5 class="typo">
                                    Contact Number</h5>
                                <asp:TextBox ID="contactNumberTextBox" CssClass="form form-full" placeholder="Contact Number"
                                    runat="server"></asp:TextBox>
                            </div>
                            <div class="widget-separator grid-3">
                                <h5 class="typo">
                                    Email</h5>
                                <asp:TextBox ID="emailTextBox" CssClass="form form-full" placeholder="Email" runat="server"></asp:TextBox>
                            </div>
                            <%--  <div class="widget-separator grid-3">
                                <h5 class="typo">
                                    Passport Number</h5>
                                <asp:TextBox ID="passportNumberTextBox" CssClass="form form-full" placeholder="Passport Number"
                                    runat="server"></asp:TextBox>
                            </div>--%>
                            <div class="widget-separator grid-3">
                                <h5 class="typo">
                                    Address</h5>
                                <asp:TextBox ID="addressTextBox" CssClass="form form-full" placeholder="Address"
                                    runat="server"></asp:TextBox>
                            </div>
                            <div class="widget-separator grid-3">
                                <h5 class="typo">
                                    Password</h5>
                                <asp:TextBox ID="passwordTextBox" CssClass="form form-full" placeholder="Password"
                                    TextMode="Password" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rqrvalidpass" ControlToValidate="passwordTextBox"
                                  ValidationGroup="2"  ErrorMessage="*" Display="Dynamic" ForeColor="red" runat="server" /><br />
                                <asp:RegularExpressionValidator ID="revChPassword" runat="server" Display="dynamic"
                                    ControlToValidate="passwordTextBox" Font-Size="11px" ErrorMessage="Password must be 6-16 nonblank characters."
                                    ValidationExpression="[^\s]{6,16}" ForeColor="Red" />
                            </div>
                            <div class="widget-separator grid-3">
                                <h5 class="typo">
                                    Confirm Password</h5>
                                <asp:TextBox ID="confirmPasswordTextBox" CssClass="form form-full" placeholder="Conform Password"
                                    TextMode="Password" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvConPassword" ControlToValidate="confirmPasswordTextBox"
                                   ValidationGroup="2" ErrorMessage="*" Display="Dynamic" ForeColor="red" runat="server" /><br />
                                <asp:CompareValidator ID="cmvPasswordRpt" Font-Size="11px" runat="server" Display="Dynamic"
                                    EnableClientScript="true" ValidationGroup="edit" ControlToValidate="confirmPasswordTextBox"
                                    ValidateEmptyText="true" ErrorMessage="Your passwords do not match." ControlToCompare="passwordTextBox"
                                    ForeColor="Red" />
                            </div>
                            <%--   <div class="widget-separator grid-6">
                                <h5 class="typo">
                                    Strength
                                </h5>
                                <h5>  &nbsp;</h5>
                                <asp:Label ID="passwordStrengthLabel" CssClass="form form-full" runat="server" Text=""></asp:Label>
                               
                            </div>--%>
                        </div>
                        <div class="widget-separator no-border grid-12">
                            <asp:Button ID="saveButton" ValidationGroup="2" runat="server" Text="Save" CssClass="btn btn-submit btn-3d"
                                OnClick="saveButton_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="saveButton" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        function pageLoad(sender, args) {
            $("#saveButton").click(function (e) {
                if (Page_ClientValidate()){
                    if (haveOverlay == 0) {
                        MyOverlayStart();
                    }
                }
            });
        }
    </script>
</asp:Content>
