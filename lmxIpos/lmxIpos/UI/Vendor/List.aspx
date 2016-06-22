﻿<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true"
    CodeBehind="List.aspx.cs" Inherits="lmxIpos.UI.Vendor.List" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
    <link href="/Content/Style/CSSPages/VendorList.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server"  ID="UpdatePanel1">
        <ContentTemplate>
            <div class="title-sitemap grid-12">
                <h1 class="grid-6">
                    <i>&#xf132;</i>Vendor List<span>Created Vendor List</span></h1>
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
                            System Vendor List</h3>
                    </header>
                    <div class="widget-body no-padding">
                        <div class="grid-12">
                            <div id="vendorListGridContainer">
                                <asp:GridView ID="vendorListGridView" runat="server" AutoGenerateColumns="false"
                                    CssClass="table table-hover gridView">
                                    <Columns>
                                        <asp:BoundField DataField="VendorId" HeaderText="Vendor ID" />
                                        <asp:BoundField DataField="VendorName" HeaderText="Vendor Name" />
                                          <asp:BoundField DataField="Phone" HeaderText="Phone" />
                                         <asp:BoundField DataField="WarehouseName" HeaderText="WH" />
                                        <asp:BoundField DataField="SalesCenterName" HeaderText="SC" />
                                       
                                        <asp:BoundField DataField="IsActive" HeaderText="Active" />
                                        <asp:TemplateField HeaderText="Edit">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="editLinkButton" runat="server" 
                                                    OnClick="editLinkButton_Click"><span class="icon icon-2x icon-edit-sign ui-button-text-icon-primary"></span></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Activate">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="activateLinkButton" runat="server" CssClass="clickProcessing"
                                                    OnClick="activateLinkButton_Click"><span class="icon icon-2x icon-ok-circle text-success"></span></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="De-Activate">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="deactivateLinkButton" runat="server" CssClass="clickProcessing"
                                                    OnClick="deactivateLinkButton_Click"><span class="icon icon-2x icon-ban-circle text-warning"></span></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Delete" Visible="false">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="deleteLinkButton" runat="server" CssClass="clickProcessing"
                                                    OnClick="deleteLinkButton_Click"><span class="icon icon-2x icon-trash text-error"></span></asp:LinkButton>
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
          <%--  <asp:AsyncPostBackTrigger ControlID="vendorListGridView" EventName="RowDataBound" />--%>
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="scriptContent" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        function pageLoad(sender, args) {
            $("#vendorListGridView").dataTable({
                "bProcessing": true,
                "bStateSave": true,
                "sPaginationType": "full_numbers",
                "aLengthMenu": [[10, 15, 20, 25, 50, 100, -1], [10, 15, 20, 25, 50, 100, "All"]],
                "aoColumnDefs": [{ 'bSortable': false, 'aTargets': [4, 5, 6]}]
            });
        }
    </script>
    <script type="text/javascript">
        $(function () {
            $("#editLinkButton").live("click", function (e) {
                MyOverlayStart();
            });

            $(".clickProcessing").live("click", function (e) {
                if (haveOverlay == 0) {

                    var col = $(this).parent().children().parent().index();
                    var row = $(this).parent().parent().index();
                    salesCenterId = $("#vendorListGridView").find("tr td:nth-child(1)").eq(row).text();
                    isActive = $("#vendorListGridView").find("tr td:nth-child(6)").eq(row).text();

                    var id = $(this).attr("id");
                    var str = $(this).attr("href");
                    var arr = str.split("'");
                    var msg = "";

                    if (isActive == "True" && id == "activateLinkButton") {
                        WarningAlert("Process Redundant", "This Vendor <span class='actionTopic'>already activated</span>.", "");
                    }
                    else if (isActive == "False" && id == "deactivateLinkButton") {
                        WarningAlert("Process Redundant", "This Vendor <span class='actionTopic'>already deactivated</span>.", "");
                    }
                    else {
                        if (id == "activateLinkButton") {
                            msg = "Are you sure you want to <span class='actionTopic'>activate</span> this Vendor?";
                        }
                        else if (id == "deactivateLinkButton") {
                            msg = "Are you sure you want to <span class='actionTopic'>deactivate</span> this Vendor?";
                        }
                        else if (id == "deleteLinkButton") {
                            msg = "Are you sure you want to <span class='actionTopic'>delete</span> this Vendor?";
                        }

                        ConfirmProcess(msg, function () {
                            MyOverlayStart();
                            __doPostBack(arr[1], '');
                        }, function () {

                        });
                    }

                    e.preventDefault();
                }
            });
        });
    </script>
</asp:Content>
