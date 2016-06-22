<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true" EnableEventValidation="false"
    CodeBehind="Create.aspx.cs" Inherits="lmxIpos.UI.AccUI.ChartOfAccount.Create" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
    <link href="/Content/Style/CSSPages/CreateChartOfAccount.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="true">
        <ContentTemplate>
            <div class="title-sitemap grid-12">
                <h1 class="grid-6">
                    <i>&#xf132;</i>Create Chart Of Account<span>Creating Chart Of Account</span></h1>
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
                            
                        </div>
                        <h3 id="Header3" runat="server" class="widget-header-title">Create Chart Of Account Form</h3>
                    </header>
                    <div class="widget-body no-padding">
                        <div class="grid-12">
                            <div class="widget-separator grid-3">
                                <h5 class="typo">Account Type
                                </h5>
                                <asp:DropDownList ID="accountTypeDropDownList" runat="server" AutoPostBack="true"
                                    CssClass="form form-full" OnSelectedIndexChanged="accountTypeDropDownList_SelectedIndexChanged">
                                    <asp:ListItem Value="A">Asset</asp:ListItem>
                                    <asp:ListItem Value="L">Liability</asp:ListItem>
                                    <asp:ListItem Value="I">Income</asp:ListItem>
                                    <asp:ListItem Value="E">Expendituer</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="widget-separator grid-3">
                                <h5 class="typo">Account Name<span class="text-error">*</span>
                                </h5>
                                <asp:TextBox ID="accountNameTextBox" runat="server" CssClass="form form-full" required="required" placeholder="Account Name"></asp:TextBox>
                            </div>
                            <div class="widget-separator grid-3">
                                <div class="grid-12">
                                    <h5 class="typo">Totalling Account Number<span class="text-error">*</span></h5>
                                </div>
                                <div class="grid-11">
                                    <div class="grid-1">
                                        <span id="selectTotallingAccount" class="add-on"><i class="icon-list"></i></span>
                                    </div>
                                    <div class="grid-11">
                                        <asp:TextBox ID="totallingAccountNumberTextBox" runat="server" CssClass="form form-full" required="required"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="widget-separator grid-3">
                                <h5 class="typo">Posted<span class="text-error">*</span>
                                </h5>
                                <asp:DropDownList ID="postedDropDownList" runat="server" CssClass="form form-full">
                                    <asp:ListItem Value="True">Yes</asp:ListItem>
                                    <asp:ListItem Value="False" Selected="True">No</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="widget-separator grid-3">
                                <h5 class="typo">Use As<span class="text-error">*</span>
                                </h5>
                                <asp:DropDownList ID="useAsDropDownList" runat="server" CssClass="form form-full">
                                    <asp:ListItem Value="BankHead">Bank Account Head</asp:ListItem>
                                    <asp:ListItem Value="CashHead">Cash Account Head</asp:ListItem>
                                    <asp:ListItem Value="Others" Selected="True">Others</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="widget-separator grid-3">
                                <h5 class="typo">Bank Account Number (if any)
                                </h5>
                                <asp:TextBox ID="bankAccountNumberTextBox" runat="server" CssClass="form form-full" placeholder="Bank Account Number"></asp:TextBox>
                            </div>
                            <div class="widget-separator grid-6">
                                <h5 class="typo">Description
                                </h5>
                                <asp:TextBox ID="descriptionTextBox" runat="server" CssClass="form form-full" placeholder="Description"></asp:TextBox>
                            </div>
                        </div>
                        <div id="totallingAccountListModal" class="modal hide fade" tabindex="-1" role="dialog"
                            aria-labelledby="myModalLabel" aria-hidden="true" style="width: 645px;">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                    &times;</button>
                                <h3>Totalling Account List
                                </h3>
                            </div>
                            <div class="modal-body">
                                <div id="totallingAccountListGridContainer">
                                    <asp:GridView ID="totallingAccountListGridView" runat="server" AutoGenerateColumns="false"
                                        CssClass="table table-hover">
                                        <Columns>
                                            <asp:BoundField DataField="AccountId" HeaderText="Acc. ID" />
                                            <asp:BoundField DataField="AccountName" HeaderText="Acc. Name" />
                                            <asp:BoundField DataField="AccountNumber" HeaderText="Acc. No." />
                                            <asp:BoundField DataField="TotallingAccountNumber" HeaderText="Totalling Acc. No." />
                                            <asp:BoundField DataField="AccountLevel" HeaderText="Acc. Level" />
                                            <asp:BoundField DataField="NextLevel" HeaderText="Next Level" />
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="selectLinkButton" runat="server" CssClass="btn btn-mini btn-success clickSelect"
                                                        OnClientClick="return false;">Select</asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <asp:Button ID="saveButton" runat="server" Text="Save" CssClass="btn btn-submit btn-3d"
                                    OnClick="saveButton_Click" />
                            </div>
                        </div>
                        <div class="widget-separator grid-12">
                            <asp:Button ID="Button1" runat="server" Text="Save" CssClass="btn btn-submit btn-3d"
                                OnClick="saveButton_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
           <Triggers>
            <asp:AsyncPostBackTrigger ControlID="accountTypeDropDownList" EventName="SelectedIndexChanged"/>
            <asp:AsyncPostBackTrigger ControlID="totallingAccountListGridView" EventName="RowDataBound" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="scriptContent" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
   <script type="text/javascript">
       function pageLoad(sender, args) {

           $("#totallingAccountNumberTextBox").attr("ReadOnly", true);

           $("#totallingAccountListGridView").dataTable({
               "bProcessing": true,
               "sPaginationType": "full_numbers",
               "aLengthMenu": [[-1], ["All"]],
               "iDisplayLength": -1,
               "aoColumnDefs": [{ 'bSortable': false, 'aTargets': [6] }],
               "bFilter": true,
               "bLengthChange": true,
               "bPaginate": false,
               "bInfo": true
           });

           $("#selectTotallingAccount").click(function () {
               $('#totallingAccountListModal').modal();
           });

           $(".clickSelect").click(function () {
               var col = $(this).parent().children().parent().index();
               var row = $(this).parent().parent().index();
               var accountNumber = $("#totallingAccountListGridView").find("tr td:nth-child(3)").eq(row).text();
               var nextLevel = $("#totallingAccountListGridView").find("tr td:nth-child(6)").eq(row).text();

               $("#totallingAccountNumberTextBox").val(accountNumber);

               if (nextLevel == '5') {
                   $('#postedDropDownList').val("True");
                   //$('#postedDropDownList').attr('disabled', 'disabled');
                   //$("#postedDropDownList").prop('selectedIndex', 0);
                   $("#postedDropDownList option[value='False']").attr("disabled", true);
               } else {
                   //$('#postedDropDownList').val("False");
                   //$('#postedDropDownList').removeAttr('disabled');
                   //$("#postedDropDownList").prop('selectedIndex', 1);
                   $("#postedDropDownList option[value='False']").attr("disabled", false);
               }

               $('#totallingAccountListModal').modal('hide');
               $("#totallingAccountNumberTextBox").focus();
               $("#totallingAccountNumberTextBox").focusout();
           });

           $(".indexChangeProcessing").live("change", function () {
               if (haveOverlay == 0) {
                   MyOverlayStart();
               }
           });

           $("#saveButton").click(function (e) {
               $("#accountNameTextBox").rules("add", {
                   required: true
               });

               $("#totallingAccountNumberTextBox").rules("add", {
                   required: true
               });

               if (haveOverlay == 0) {
                   MyOverlayStart();
               }
           });
       };
    </script>
</asp:Content>
