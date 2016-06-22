<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true"
    CodeBehind="Update.aspx.cs" Inherits="lmxIpos.UI.Warehouse.Update" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="false">
        <ContentTemplate>
            <div class="title-sitemap grid-12">
                <h1 class="grid-6">
                    <i>&#xf132;</i>Update Warehouse<span>Updating Warehouse</span></h1>
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
                            Update Warehouse of <asp:Label ID="idLabel" runat="server" Text=""></asp:Label></h3>
                    </header>
                    <div class="widget-body no-padding">
                        <div class="widget-separator grid-3">
                            <h5 class="typo">
                                Warehouse Name</h5>
                            <asp:TextBox ID="warehouseNameTextBox" runat="server" class="form form-full" placeholder="Warehouse Name" required="required"></asp:TextBox>
                        </div>
                        <div class="widget-separator grid-3">
                            <h5 class="typo">
                                Country</h5>
                            <asp:TextBox ID="countryTextBox" runat="server" class="form form-full" placeholder="Country"></asp:TextBox>
                        </div>
                        <div class="widget-separator grid-3">
                            <h5 class="typo">
                                City</h5>
                            <asp:TextBox ID="cityTextBox" runat="server" class="form form-full" placeholder="City"></asp:TextBox>
                        </div>
                        <div class="widget-separator grid-3">
                            <h5 class="typo">
                                District</h5>
                            <asp:TextBox ID="districtTextBox" runat="server" class="form form-full" placeholder="District"></asp:TextBox>
                        </div>
                        <div class="widget-separator grid-3">
                            <h5 class="typo">
                                Postal Code</h5>
                            <asp:TextBox ID="postalCodeTextBox" runat="server" class="form form-full" placeholder="Postal Code"></asp:TextBox>
                        </div>
                        <div class="widget-separator grid-3">
                            <h5 class="typo">
                                Phone</h5>
                            <asp:TextBox ID="phoneTextBox" runat="server" class="form form-full" placeholder="Phone"></asp:TextBox>
                        </div>
                        <div class="widget-separator grid-3">
                            <h5 class="typo">
                                Mobile</h5>
                            <asp:TextBox ID="mobileTextBox" runat="server" class="form form-full" placeholder="Mobile" required="required"></asp:TextBox>
                        </div>
                        <div class="widget-separator grid-3">
                            <h5 class="typo">
                                Fax</h5>
                            <asp:TextBox ID="faxTextBox" runat="server" class="form form-full" placeholder="Fax"></asp:TextBox>
                        </div>
                        <div class="widget-separator grid-3">
                            <h5 class="typo">
                                Email</h5>
                            <asp:TextBox ID="emailTextBox" runat="server" class="form form-full" placeholder="Email" required="required"></asp:TextBox>
                        </div>
                        <div class="widget-separator grid-9">
                            <h5 class="typo">
                                Address</h5>
                            <asp:TextBox ID="addressTextBox" runat="server" class="form form-full" placeholder="Address" required="required"></asp:TextBox>
                        </div>
                        <div class="widget-separator grid-12">
                            <asp:Button ID="updateButton" runat="server" Text="Update" CssClass="btn btn-submit btn-3d"
                                OnClick="updateButton_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="warehouseIdForUpdateHiddenField" runat="server" />
            <asp:HiddenField ID="warehouseNameForUpdateHiddenField" runat="server" />
        </ContentTemplate>
         <Triggers>
            <asp:AsyncPostBackTrigger ControlID="updateButton" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="scriptContent" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        function pageLoad(sender, args) {
            //$("#updateButton").click(function (e) {
            //    $("#warehouseNameTextBox").rules("add", {
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
