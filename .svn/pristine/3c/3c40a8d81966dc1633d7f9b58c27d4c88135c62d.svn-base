<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true"
    CodeBehind="DeletedList.aspx.cs" Inherits="lmxIpos.UI.UserGroup.DeletedList" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
    <link href="/Content/Style/CSSPages/DeletedList.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional" ChildrenAsTriggers="false">
        <ContentTemplate>
            <div class="title-sitemap grid-12">
                <h1 class="grid-6">
                    <i>&#xf132;</i>Deleted User Group<span>Deleted User Group of System</span></h1>
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
                            Deleted User List</h3>
                    </header>
                    <div class="widget-body no-padding">
                        <div class="widget-separator grid-12">
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">
                                    Date From</h5>
                                <div class="grid-12">
                                    <div class="grid-2">
                                        <i class="icon-calendar"></i>
                                    </div>
                                    <div class="grid-10">
                                        <asp:TextBox ID="fromDateTextBox" CssClass="date-textbox form form-full" runat="server"></asp:TextBox></div>
                                </div>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">
                                    Date To</h5>
                                <div class="grid-12">
                                    <div class="grid-2">
                                        <i class="icon-calendar"></i>
                                    </div>
                                    <div class="grid-10">
                                        <asp:TextBox ID="toDateTextBox" CssClass="date-textbox form form-full" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="widget-separator no-border grid-6" style="margin-top: 29px;">
                                <asp:Button ID="deletedListButton" runat="server" Text="Get Deleted List" CssClass="btn btn-info"
                                    OnClick="deletedListButton_Click" />
                                <asp:Button ID="allDeletedListButton" runat="server" Text="Get All Deleted List"
                                    CssClass="btn btn-info" OnClick="allDeletedListButton_Click" />
                            </div>
                        </div>
                        <div class="grid-12">
                            <div id="deletedListGridContainer">
                                <asp:GridView ID="deletedListGridView" runat="server" AutoGenerateColumns="false"
                                    CssClass="table table-hover gridView">
                                    <Columns>
                                        <asp:BoundField DataField="UserGroupId" HeaderText="User Group ID" />
                                        <asp:BoundField DataField="UserGroupName" HeaderText="Name" />
                                        <asp:BoundField DataField="Description" HeaderText="Description" />
                                        <asp:BoundField DataField="CreatedDateTime" HeaderText="Created Date" />
                                        <asp:BoundField DataField="DeletedDateTime" HeaderText="Deleted Date" />
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="viewLinkButton" runat="server" CssClass="btn btn-mini btn-info clickProcessing"
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
            <asp:AsyncPostBackTrigger ControlID="deletedListButton" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="allDeletedListButton" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="deletedListGridView" EventName="RowDataBound" />
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

            $("#deletedListGridView").dataTable({
                "bProcessing": true,
                "bStateSave": true,
                //"bRetrieve": true,
                //"bDestroy": true,
                "sPaginationType": "full_numbers",
                "aLengthMenu": [[10, 15, 20, 25, 50, -1], [10, 15, 20, 25, 50, "All"]],
                "aoColumnDefs": [{ 'bSortable': false, 'aTargets': [5]}]
            });

            $("#allDeletedListButton").click(function () {
                $("#form1").validate().currentForm = "";
                if (haveOverlay == 0) {
                    MyOverlayStart();
                }
            });

            $("#deletedListButton").click(function (e) {
                $("#form1").validate().currentForm = $("#form1")[0];
                $("#fromDateTextBox").rules("add", {
                    required: true
                });

                $("#toDateTextBox").rules("add", {
                    required: true
                });

                if (haveOverlay == 0) {
                    $("#form1").valid();

                    if (haveOverlay == 1) {
                        return false;
                    } else {
                        MyOverlayStart();
                    }
                }
            });
        }
    </script>
    <script type="text/javascript">
        $(function () {
            $(".clickProcessing").live("click", function () {
                if (haveOverlay == 0) {
                    MyOverlayStart();
                }
            });
        });
    </script>
</asp:Content>
