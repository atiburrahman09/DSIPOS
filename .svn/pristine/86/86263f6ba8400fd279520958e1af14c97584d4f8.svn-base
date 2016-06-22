<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true"
    CodeBehind="Update.aspx.cs" Inherits="lmxIpos.UI.SalesPerson.Update" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="false">
        <ContentTemplate>
            <div class="title-sitemap grid-12">
                <h1 class="grid-6">
                    <i>&#xf132;</i>Update Sales Person<span>Updating Sales Person</span></h1>
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
                        <h3 id="H1" runat="server" class="widget-header-title">
                            Update Sales Person of
                            <asp:Label ID="idLabel" runat="server" Text=""></asp:Label></h3>
                    </header>
                    <div class="widget-body no-padding">
                        <div class="widget-separator grid-3">
                            <h5 class="typo">
                                Sales Person Name
                            </h5>
                            <asp:TextBox ID="salesPersonNameTextBox" required="required" runat="server" CssClass="form form-full"></asp:TextBox>
                        </div>
                        <div class="widget-separator grid-3">
                            <h5 class="typo">
                                Country
                            </h5>
                            <asp:TextBox ID="countryTextBox" runat="server" CssClass="form form-full"></asp:TextBox>
                        </div>
                        <div class="widget-separator grid-3">
                            <h5 class="typo">
                                City
                            </h5>
                            <asp:TextBox ID="cityTextBox" runat="server" CssClass="form form-full"></asp:TextBox>
                        </div>
                        <div class="widget-separator grid-3">
                            <h5 class="typo">
                                District
                            </h5>
                            <asp:TextBox ID="districtTextBox" runat="server" CssClass="form form-full"></asp:TextBox>
                        </div>
                        <div class="widget-separator grid-3">
                            <h5 class="typo">
                                Postal Code
                            </h5>
                            <asp:TextBox ID="postalCodeTextBox" runat="server" CssClass="form form-full"></asp:TextBox>
                        </div>
                        <div class="widget-separator grid-3">
                            <h5 class="typo">
                                National ID
                            </h5>
                            <asp:TextBox ID="nationalIdTextBox" runat="server" CssClass="form form-full"></asp:TextBox>
                        </div>
                        <div class="widget-separator grid-3">
                            <h5 class="typo">
                                Passport Number
                            </h5>
                            <asp:TextBox ID="passportNumberTextBox" runat="server" CssClass="form form-full"></asp:TextBox>
                        </div>
                        <div class="widget-separator grid-3">
                            <h5 class="typo">
                                Contact Number
                            </h5>
                            <asp:TextBox ID="contactNumberTextBox" runat="server" CssClass="form form-full"></asp:TextBox>
                        </div>
                        <div class="widget-separator grid-3">
                            <div class="grid-12">
                                <h5 class="typo">
                                    Join Date</h5>
                            </div>
                            <div class="grid-11">
                                <div class="grid-1">
                                    <i class="icon-calendar"></i>
                                </div>
                                <div class="grid-11">
                                    <asp:TextBox ID="joinDateTextBox" required="required" CssClass="date-textbox form form-full" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="widget-separator grid-3">
                            <h5 class="typo">
                                Joining Sales Center
                            </h5>
                            <asp:DropDownList ID="joiningSalesCenterDropDownList" required="required" runat="server" CssClass="form form-full">
                            </asp:DropDownList>
                        </div>
                        <div class="widget-separator grid-3">
                            <h5 class="typo">
                                Working Sales Center
                            </h5>
                            <asp:DropDownList ID="workingSalesCenterDropDownList" required="required" runat="server" CssClass="form form-full">
                            </asp:DropDownList>
                        </div>
                        <div class="widget-separator grid-3">
                            <h5 class="typo">
                                Email
                            </h5>
                            <asp:TextBox ID="emailTextBox" required="required" runat="server" CssClass="form form-full"></asp:TextBox>
                        </div>
                        <div class="widget-separator grid-12">
                            <h5 class="typo">
                                Address
                            </h5>
                            <asp:TextBox ID="addressTextBox" required="required" runat="server" CssClass="form form-full"></asp:TextBox>
                        </div>
                        <div class="widget-separator grid-12">
                            <asp:Button ID="updateButton" runat="server" Text="Update" CssClass="btn btn-submit btn-3d"
                                OnClick="updateButton_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="salesPersonIdForUpdateHiddenField" runat="server" />
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="updateButton" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="scriptContent" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        $(function () {
            //$(".datepicker").remove();
            var dateFormat = '<%= Session["DateFormatForDatePicker"] %>';
            $(".date-textbox").datepicker({ format: dateFormat });
            $(".date-textbox, .icon-calendar").click(function () {
                $(this).parent().find(".date-textbox").focus();
            });
        });
    </script>
    <script type="text/javascript">
        function pageLoad(sender, args) {
            $("#updateButton").click(function (e) {
                $("#joiningSalesCenterDropDownList").rules("add", {
                    required: true
                });

                $("#workingSalesCenterDropDownList").rules("add", {
                    required: true
                });

                $("#salesPersonNameTextBox").rules("add", {
                    required: true
                });

                $("#emailTextBox").rules("add", {
                    required: true,
                    email: true
                });

                $("#addressTextBox").rules("add", {
                    required: true
                });

                $("#joinDateTextBox").rules("add", {
                    required: true
                });

                if (haveOverlay == 0) {
                    MyOverlayStart();
                }
            });
        }
    </script>
</asp:Content>
