<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true" CodeBehind="languageentry.aspx.cs" EnableEventValidation="false" Inherits="lmxIpos.UI.Library.Book.languageentry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="true">
        <ContentTemplate>
            <div class="title-sitemap grid-12">
                <h1 class="grid-6">
                    <i>&#xf132;</i>Create Language <span>Creating Language</span></h1>
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
                
                <asp:HiddenField ID="serialHiddenField" runat="server" />
                <div class="widget">
                    <header class="widget-header">
                        <div class="widget-header-icon">
                            
                        </div>
                        <h3 id="Header3" runat="server" class="widget-header-title">Create Language Form</h3>
                    </header>
                    <div class="widget-body no-padding">
                        <div class="widget-separator grid-12">
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Language Name <span class="text-error">*</span> </h5>
                                <asp:TextBox ID="languageNameTextBox" runat="server" CssClass="form form-full" required="required"
                                    placeholder="Language Name"></asp:TextBox>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Country <span class="text-error">*</span> </h5>
                                <asp:TextBox ID="countryTextBox" required="required" runat="server" CssClass="form form-full"
                                    placeholder="Country"></asp:TextBox>
                            </div>

                            <div class="widget-separator no-border grid-12">
                                <asp:Button ID="saveButton" runat="server" Text="Save" CssClass="btn btn-submit btn-3d"
                                    OnClick="saveButton_OnClick" />
                            </div>
                            <div class="widget-body no-padding">
                                <div class="grid-12">
                                    <div id="languageListGridContainer">
                                        <asp:GridView ID="languageListGridView" runat="server" AutoGenerateColumns="false" 
                                            CssClass="table table-hover gridView dataTable">
                                            <Columns>
                                                <asp:BoundField DataField="Serial" HeaderText="Serial" />
                                                <asp:BoundField DataField="LanguageName" HeaderText="Language Name" />
                                                <asp:BoundField DataField="Country" HeaderText="Country" />
                                                
                                                <asp:TemplateField HeaderText="">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="EditLinkButton" CssClass="btn btn-success" runat="server" OnClick="EditLinkButton_OnClick">Edit</asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="saveButton" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="languageListGridView" EventName="RowDataBound" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
     <script type="text/javascript">
        function pageLoad(sender, args) {
            $("#languageListGridView").dataTable({
                "bProcessing": true,
                "bStateSave": true,
                "sPaginationType": "full_numbers",
                "aLengthMenu": [[10, 15, 20, 25, 50, 100, -1], [10, 15, 20, 25, 50, 100, "All"]],
                "aoColumnDefs": [{ 'bSortable': false, 'aTargets': [0, 1, 2,3] }]
                
            });
        }
    </script>
</asp:Content>
