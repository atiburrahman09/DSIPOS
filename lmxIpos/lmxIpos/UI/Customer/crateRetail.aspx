<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true" EnableEventValidation="false"
    CodeBehind="crateRetail.aspx.cs" Inherits="lmxIpos.UI.Customer.crateRetail" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="true">
        <ContentTemplate>
            <div class="title-sitemap grid-12">
                <h1 class="grid-6">
                    <i>&#xf132;</i>Create Customer Retail<span>Creating Customer Retail</span></h1>
                <div class="sitemap grid-6">
                    <%--<ul>
                        <li><span>Acura</span><i>/</i></li>
                        <li><a href="Default.aspx">Dashboard</a></li>
                    </ul>--%>
                </div>
            </div>
            <div class="data">

                <div class="widget">

                    <header class="widget-header">
                        <div class="widget-header-icon">
                            
                        </div>
                        <h3 id="Header3" runat="server" class="widget-header-title">Create Customer Retail Form</h3>
                    </header>
                    <div id="msgbox" runat="server" visible="false" class="alert alert-error">
                        <button type="button" class="close" data-dismiss="alert">
                            &times;</button>
                        <h4>
                            <asp:Label ID="msgTitleLabel" runat="server" Text=""></asp:Label>
                        </h4>
                        <asp:Label ID="msgDetailLabel" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="widget-body no-padding">
                        <div class="widget-separator grid-12">
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Customer Name <span class="text-error">*</span> </h5>
                                <asp:TextBox ID="customerNameTextBox" runat="server" CssClass="form form-full" required="required"
                                    placeholder="Customer Name"></asp:TextBox>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Contact Number <span class="text-error">*</span> </h5>
                                <asp:TextBox ID="contactNumberTextBox" required="required" runat="server" CssClass="form form-full"
                                    placeholder="Contact Number"></asp:TextBox>
                            </div>
                            <%--  <div class="widget-separator no-border grid-3">
                                <h5 class="typo">
                                    National ID</h5>
                                <asp:TextBox ID="nationalIdTextBox" runat="server" CssClass="form form-full" placeholder="National ID"></asp:TextBox>
                            </div>--%>
                            <%--<div class="widget-separator no-border grid-3">
                                <h5 class="typo">
                                    Passport Number</h5>
                                <asp:TextBox ID="passportNumberTextBox" runat="server" CssClass="form form-full" placeholder="Passport Number"></asp:TextBox>
                            </div>--%>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Email</h5>
                                <asp:TextBox ID="emailTextBox" runat="server" CssClass="form form-full" placeholder="Email"></asp:TextBox>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Joining Sales Center<span class="text-error">*</span></h5>
                                <asp:DropDownList ID="joiningSalesCenterDropDownList" runat="server"
                                    CssClass="form form-full">
                                </asp:DropDownList>
                            </div>
                            <div class="widget-separator no-border grid-12">
                                <h5 class="typo">Address <span class="text-error">*</span> </h5>
                                <asp:TextBox ID="addressTextBox" runat="server" CssClass="form form-full" required="required"
                                    placeholder="Address"></asp:TextBox>
                                <%--Width="448"--%>
                            </div>
                        </div>
                        <div class="widget-separator no-border grid-12">
                            <asp:Button ID="saveButton" CommandArgument="1" runat="server" Text="Save" CssClass="btn btn-submit btn-3d"
                                OnClick="saveButton_Click" />
                            <asp:Button ID="savemore" runat="server" CommandArgument="2" Text="Save and Add More" CssClass="btn btn-3d"
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
        function pageLoad(sender, args) {
            //$("#saveButton").click(function (e) {

            //    if (Page_ClientValidate("")) {
            //        if (haveOverlay == 0) {
            //            MyOverlayStart();
            //        }
            //    }
            //});
        }
    </script>
</asp:Content>
