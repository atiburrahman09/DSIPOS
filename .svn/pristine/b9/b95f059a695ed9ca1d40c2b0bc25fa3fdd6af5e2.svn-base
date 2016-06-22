<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true"
    CodeBehind="Create.aspx.cs" Inherits="lmxIpos.UI.SalesPerson.Create" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="false">
        <ContentTemplate>
            <div class="title-sitemap grid-12">
                <h1 class="grid-6">
                    <i>&#xf132;</i>Create Sales Person<span>Creating Sales Person</span></h1>
                <div class="sitemap grid-6">
                    <%--  <ul>
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
                            Create Sales Person Form</h3>
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
                            <asp:Button ID="saveButton" runat="server" Text="Save" CssClass="btn btn-submit btn-3d"
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
            $("#saveButton").click(function (e) {
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
