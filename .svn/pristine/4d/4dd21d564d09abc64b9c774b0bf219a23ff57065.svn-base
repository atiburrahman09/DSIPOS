<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true" EnableEventValidation="false"
    CodeBehind="Update.aspx.cs" Inherits="lmxIpos.UI.User.Update" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="false">
        <ContentTemplate>
            <div class="title-sitemap grid-12">
                <h1 class="grid-6">
                    <i>&#xf132;</i>Update User<span>Updating System User</span></h1>
                <div class="sitemap grid-6">
                    <%--<ul>
                        <li><span>IPOS</span><i>/</i></li>
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
                            <h3 id="H1" runat="server" class="widget-header-title">
                                Update User of <asp:Label ID="idLabel" runat="server" Text=""></asp:Label></h3>
                    </header>
                    <div class="widget-body no-padding">
                        <div class="widget-separator no-padding grid-12">
                            <div class="widget-separator grid-3">
                                <h5 class="typo">
                                    User ID</h5>
                                <asp:TextBox ID="userIdTextBox" runat="server" ReadOnly="true" class="form form-full"
                                    placeholder="User ID"></asp:TextBox>
                            </div>
                            <div class="widget-separator grid-3">
                                <h5 class="typo">
                                    User Name</h5>
                                <asp:TextBox ID="userNameTextBox" runat="server" required="required" class="form form-full" placeholder="User Name"></asp:TextBox>
                            </div>
                            <%-- <div class="widget-separator grid-3">
                                <h5 class="typo">
                                    Employee ID</h5>
                                <asp:TextBox ID="employeeIdTextBox" runat="server" class="form form-full" placeholder="Employee ID"></asp:TextBox>
                            </div>--%>
                            <div class="widget-separator grid-3">
                                <h5 class="typo">
                                    User Group</h5>
                                <asp:DropDownList ID="userGroupDropDownList" required="required" runat="server" class="form form-full"
                                    placeholder="User Group">
                                </asp:DropDownList>
                            </div>
                            <div class="widget-separator grid-3">
                                <h5 class="typo">
                                    Sales Center Name
                                </h5>
                                <asp:DropDownList ID="salesCenterDropDownList" required="required" runat="server" CssClass="form form-full">
                                </asp:DropDownList>
                            </div>
                             <div class="widget-separator grid-3">
                                <h5 class="typo">
                                    Warehouse Name</h5>
                                <asp:DropDownList ID="warehouseDropDownList" runat="server" CssClass="form form-full">
                                </asp:DropDownList>
                            </div>
                            <%-- <div class="widget-separator grid-3">
                                <h5 class="typo">
                                    Designation</h5>
                                <asp:TextBox ID="designationTextBox" runat="server" class="form form-full" placeholder="Designation"></asp:TextBox>
                            </div>--%>
                            <div class="widget-separator grid-3">
                                <h5 class="typo">
                                    Contact Number</h5>
                                <asp:TextBox ID="contactNumberTextBox" runat="server" class="form form-full" placeholder="Contact Number"></asp:TextBox>
                            </div>
                            <div class="widget-separator grid-3">
                                <h5 class="typo">
                                    Email</h5>
                                <asp:TextBox ID="emailTextBox" runat="server" class="form form-full" placeholder="Email"></asp:TextBox>
                            </div>
                           <%-- <div class="widget-separator grid-3">
                                <h5 class="typo">
                                    National ID</h5>
                                <asp:TextBox ID="nationalIdTextBox" runat="server" class="form form-full" placeholder="National ID"></asp:TextBox>
                            </div>--%>
                          <%--  <div class="widget-separator grid-3">
                                <h5 class="typo">
                                    Passport Number</h5>
                                <asp:TextBox ID="passportNumberTextBox" runat="server" class="form form-full" placeholder="Passport Number"></asp:TextBox>
                            </div>--%>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">
                                    Address</h5>
                                <asp:TextBox ID="addressTextBox" runat="server" class="form form-full"
                                    placeholder="Address"  ></asp:TextBox>
                            </div>
                           <%-- <div class="widget-separator grid-3">
                                <h5 class="typo">
                                    Password</h5>
                                <asp:TextBox ID="passwordTextBox" CssClass="form form-full" placeholder="Password"
                                    TextMode="Password" runat="server" required="required"></asp:TextBox>
                            </div>--%>
                          <%--  <div class="widget-separator grid-3">
                                <h5 class="typo">
                                    Confirm Password</h5>
                                <asp:TextBox ID="confirmPasswordTextBox" CssClass="form form-full" placeholder="Conform Password"
                                    TextMode="Password" runat="server" required="required"></asp:TextBox>
                            </div>--%>
                        </div>
                        <div class="widget-separator no-border grid-12">
                            <asp:Button ID="updateButton" runat="server" Text="Update" CssClass="btn btn-submit btn-3d"
                                OnClick="updateButton_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="userIdForUpdateHiddenField" runat="server" />
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="updateButton" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="scriptContent" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        function pageLoad(sender, args) {
            $("#updateButton").click(function (e) {
                if (Page_ClientValidate()) {
                    if (haveOverlay == 0) {
                        MyOverlayStart();
                    }
                }
                else {

                }
            });
        }
    </script>
</asp:Content>
