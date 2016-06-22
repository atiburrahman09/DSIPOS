<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="VendorPaymentList.aspx.cs" Inherits="lmxIpos.UI.PaymentToVendor.VendorPaymentList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
    <script type="text/javascript">
        function ExportReportForm() {
            window.open("/ReportExport.aspx", "_blank");
        }
        function ViewReportForm() {
            window.open("/ReportView.aspx", "_blank");
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="true">
        <ContentTemplate>
            <div class="title-sitemap grid-12">
                <h1 class="grid-8">
                    <i>&#xf132;</i>Vendor Payment List<span>Vendor Payment List</span></h1>
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
                        <h3 id="Header3" runat="server" class="widget-header-title">Vendor Wise Payment List</h3>
                    </header>
                    <div class="widget-body no-padding">
                        <div class="widget-separator no-padding grid-12">

                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">
                                    <asp:Label ID="vendorLabel" runat="server" Text="Vendor"></asp:Label>
                                </h5>
                                <asp:DropDownList ID="vendorDropDownList" runat="server" CssClass="form form-full"
                                    required="required">
                                </asp:DropDownList>
                            </div>

                            <%-- <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Sales Center Name
                                </h5>
                                <asp:DropDownList ID="salesCenterDropDownList" runat="server" CssClass="form form-full"
                                    required="required">
                                </asp:DropDownList>
                            </div>--%>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Date From</h5>
                                <div class="grid-12">
                                    <div class="grid-1">
                                        <i class="icon-calendar"></i>
                                    </div>
                                    <div class="grid-11">
                                        <asp:TextBox ID="fromDateTextBox" CssClass="date-textbox form form-full" data-date-format="dd/mm/yyyy"
                                            runat="server" required="required"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Date To</h5>
                                <div class="grid-12">
                                    <div class="grid-1">
                                        <i class="icon-calendar"></i>
                                    </div>
                                    <div class="grid-11">
                                        <asp:TextBox ID="toDateTextBox" CssClass="date-textbox form form-full" runat="server"
                                            data-date-format="dd/mm/yyyy" required="required"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="widget-separator no-border grid-2">
                                <h5 class="typo">Status
                                </h5>
                                <asp:DropDownList ID="statusDropDownList" CssClass="form form-full" runat="server">
                                    <asp:ListItem Value="A">Approved</asp:ListItem>
                                    <asp:ListItem Value="P">Pending</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">&nbsp;
                                </h5>
                                <asp:Button ID="recordListButton" runat="server" Text="Get Vendor Payment List" CssClass="btn btn-info"
                                    OnClick="btnVendorPaymentList_OnClick" />
                            </div>

                        </div>

                        <div class=" widget-separator no-border grid-12">
                            <div id="salesRecordListGridContainer">
                                <asp:GridView ID="vendorPaymentListGridView" runat="server" AutoGenerateColumns="false"
                                    CssClass="table table-hover dataTable gridView">
                                    <Columns>

                                        <asp:BoundField DataField="JournalNumber" HeaderText="Journal Number" />
                                        <asp:BoundField DataField="VoucherDate" HeaderText="Record Date" />
                                        <asp:BoundField DataField="RecordId" HeaderText="PR Id" />
                                        <asp:BoundField DataField="AutoVoucherNumber" HeaderText="Vouchar No" />
                                        <%-- <asp:BoundField DataField="CustomerId" HeaderText="Customer Id" />--%>
                                        <asp:BoundField DataField="Amount" HeaderText="Amount" />
                                        <asp:BoundField DataField="DueAmount" HeaderText="Due Amount" />
                                        <%--<asp:BoundField DataField="Status" HeaderText="Status" />--%>

                                        <%--<asp:TemplateField HeaderText="Vouchar">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="printInvoiceButton" runat="server" CssClass="btn btn-mini btn-success" Text="Print"
                                                    OnClick="printInvoiceButton_OnClick"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="recordListButton" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="vendorPaymentListGridView" EventName="RowDataBound" />

        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        function pageLoad(sender, args) {

            $(".date-textbox").datepicker();

            $("#vendorPaymentListGridView").dataTable();
        }
    </script>
</asp:Content>
