﻿<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true" EnableEventValidation="false"
    CodeBehind="PurchaseList.aspx.cs" Inherits="lmxIpos.UI.PurchaseToSC.PurchaseList" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="true">
        <ContentTemplate>
            <div class="title-sitemap grid-12">
                <h1 class="grid-8">
                    <i>&#xf132;</i>Sales Center Purchase Record List<span>Recorded Sales Center Purchase
                        List</span></h1>
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
                            System Recorded Sales Center Purchase List</h3>
                    </header>
                    <div class="widget-body no-padding">
                        <div class="widget-separator no-padding grid-12">
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">
                                    Sales Center Name
                                </h5>
                                <asp:DropDownList ID="salesCenterDropDownList" runat="server" CssClass="form form-full"
                                    required="required">
                                </asp:DropDownList>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">
                                    Date From</h5>
                                <div class="grid-12">
                                    <div class="grid-1">
                                        <i class="icon-calendar"></i>
                                    </div>
                                    <div class="grid-11">
                                        <asp:TextBox ID="fromDateTextBox" CssClass="date-textbox form form-full" runat="server"
                                            required="required"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">
                                    Date To</h5>
                                <div class="grid-12">
                                    <div class="grid-1">
                                        <i class="icon-calendar"></i>
                                    </div>
                                    <div class="grid-11">
                                        <asp:TextBox ID="toDateTextBox" CssClass="date-textbox form form-full" runat="server"
                                            required="required"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="widget-separator no-border grid-3" cssclass="form form-full">
                                <h5 class="typo">
                                    Status
                                </h5>
                                <asp:DropDownList ID="statusDropDownList" runat="server">
                                    <asp:ListItem Value="All">All</asp:ListItem>
                                    <asp:ListItem Value="A">Approved</asp:ListItem>
                                    <asp:ListItem Value="P">Pending</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="widget-separator no-border grid-3" cssclass="form form-full">
                                <asp:Button ID="recordListButton" runat="server" Text="Get Purchase Record List"
                                    CssClass="btn btn-info" OnClick="requisitionListButton_Click" />
                            </div>
                        </div>
                        <div class="grid-12">
                            <div id="purchaseRecordListGridContainer">
                                <asp:GridView ID="purchaseRecordListGridView" runat="server" AutoGenerateColumns="false"
                                    CssClass="table table-hover gridView">
                                    <Columns>
                                        <asp:BoundField DataField="PurchaseRecordId" HeaderText="PRec ID" />
                                        <asp:BoundField DataField="RecordDate" HeaderText="Record Date" />
                                        <asp:BoundField DataField="VendorName" HeaderText="Vendor Name" />
                                        <asp:BoundField DataField="SalesCenterName" HeaderText="Sales Center Name" />
                                        <asp:BoundField DataField="Narration" HeaderText="Narration" />
                                        <asp:BoundField DataField="Status" HeaderText="Status" />
                                        <asp:TemplateField HeaderText="View">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="viewLinkButton" runat="server" CssClass="btn btn-mini btn-info"
                                                    OnClick="viewLinkButton_Click">View</asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
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
            <asp:AsyncPostBackTrigger ControlID="purchaseRecordListGridView" EventName="RowDataBound" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="scriptContent" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        function pageLoad(sender, args) {
            $(".datepicker").remove();
            var dateFormat = '<%= Session["DateFormatForDatePicker"] %>';
            $(".date-textbox").datepicker({ format: dateFormat });
            $(".date-textbox, .icon-calendar").click(function () {
                $(this).parent().find(".date-textbox").focus();
            });

            $("#purchaseRecordListGridView").dataTable({
                "bProcessing": true,
                "sPaginationType": "full_numbers",
                "aLengthMenu": [[10, 15, 20, -1], [10, 15, 20, "All"]],
                "iDisplayLength": -1,
                "bSort": true,
                //"aoColumnDefs": [{ 'bSortable': false, 'aTargets': [0, 1, 2, 3, 4, 5, 6, 7]}],
                "bFilter": true,
                "bLengthChange": true,
                "bPaginate": true,
                "bInfo": false
            });
        };
    </script>
</asp:Content>
