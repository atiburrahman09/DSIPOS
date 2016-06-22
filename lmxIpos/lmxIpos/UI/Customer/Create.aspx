<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true"
    CodeBehind="Create.aspx.cs" Inherits="lmxIpos.UI.Customer.Create" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="false">
        <ContentTemplate>
            <div class="title-sitemap grid-12">
                <h1 class="grid-6">
                    <i>&#xf132;</i>Create Customer<span>Creating Customer</span></h1>
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
                        <h3 id="Header3" runat="server" class="widget-header-title">Customer Create Form</h3>
                    </header>
                    <div class="widget-body no-padding">
                        <div class="widget-separator grid-12">
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Customer Name</h5>
                                <asp:TextBox ID="customerNameTextBox" runat="server" CssClass="form form-full" placeholder="Customer Name" required="required"></asp:TextBox>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Country</h5>
                                <asp:TextBox ID="countryTextBox" runat="server" CssClass="form form-full" placeholder="Country"></asp:TextBox>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">City</h5>
                                <asp:TextBox ID="cityTextBox" runat="server" CssClass="form form-full" placeholder="City"></asp:TextBox>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">District</h5>
                                <asp:TextBox ID="districtTextBox" runat="server" CssClass="form form-full" placeholder="District"></asp:TextBox>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Postal Code</h5>
                                <asp:TextBox ID="postalCodeTextBox" runat="server" CssClass="form form-full" placeholder="Postal Code"></asp:TextBox>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">National ID</h5>
                                <asp:TextBox ID="nationalIdTextBox" runat="server" CssClass="form form-full" placeholder="National ID"></asp:TextBox>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Passport Number</h5>
                                <asp:TextBox ID="passportNumberTextBox" runat="server" CssClass="form form-full" placeholder="Passport Number"></asp:TextBox>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Contact Number</h5>
                                <asp:TextBox ID="contactNumberTextBox" runat="server" CssClass="form form-full" placeholder="Contact Number"></asp:TextBox>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Joining Sales Center</h5>
                                <asp:DropDownList ID="joiningSalesCenterDropDownList" runat="server" CssClass="form form-full" required="required">
                                </asp:DropDownList>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Email</h5>
                                <asp:TextBox ID="emailTextBox" runat="server" CssClass="form form-full" placeholder="Email"></asp:TextBox>
                            </div>
                            <div class="widget-separator no-border grid-6">
                                <h5 class="typo">Address</h5>
                                <asp:TextBox ID="addressTextBox" runat="server" CssClass="form form-full" required="required" placeholder="Address"></asp:TextBox>
                            </div>
                        </div>
                        <div class="widget-separator no-border grid-12">
                            <asp:Button ID="saveButton" runat="server" CommandArgument="1" Text="Save" CssClass="btn btn-submit btn-3d"
                                OnClick="saveButton_Click" />
                             <asp:Button ID="savemoreButton"  CommandArgument="2" runat="server" Text="Save and Add More" CssClass="btn btn-submit btn-3d"
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
            //            $("#saveButton").on("click", function (e) {
            //                if ($('#joiningSalesCenterDropDownList option:selected').text() == '----------Select----------') {
            //                    alert('Joining Sales Center field is required.');
            //                    $('#joiningSalesCenterDropDownList').focus();
            //                    e.preventDefault();
            //                    $("#form1").valid();
            //                    //return false;
            //                }
            //            });
        });
    </script>
    <script type="text/javascript">
        function pageLoad(sender, args) {
           
            //$("#saveButton").click(function (e) {
            //    $("#joiningSalesCenterDropDownList").rules("add", {
            //        required: true
            //    });

            //    $("#customerNameTextBox").rules("add", {
            //        required: true
            //    });

            //    $("#emailTextBox").rules("add", {
            //        required: true,
            //        email: true
            //    });

            //    $("#addressTextBox").rules("add", {
            //        required: true
            //    });

            //    if (haveOverlay == 0) {
            //        MyOverlayStart();
            //    }
            //});
        }
    </script>
</asp:Content>
