<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true" CodeBehind="PaymentSchedule.aspx.cs" Inherits="lmxIpos.UI.PaymentSchedule.PaymentSchedule" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="true">
        <ContentTemplate>
            <div class="title-sitemap grid-12">
                <h1 class="grid-12">
                    <i>&#xf132;</i>Create & Update Payment Schedule<span>Creating/Updating Payment Schedule</span></h1>

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
                        <h3 id="Header3" runat="server" class="widget-header-title">Create Payment Schedule Form</h3>
                    </header>
                    <div class="widget-body no-padding">
                        <div id="msgbox" runat="server" visible="false" class="alert alert-warning">
                            <button type="button" class="close" data-dismiss="alert">
                                &times;</button>
                            <h4>
                                <asp:Label ID="msgTitleLabel" runat="server" Text=""></asp:Label>
                            </h4>
                            <asp:Label ID="msgDetailLabel" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="widget-separator grid-12">
                            <div class="widget-separator no-border grid-3">
                                <div class="grid-12">
                                    <h5 class="typo">Type</h5>
                                </div>
                                <asp:DropDownList ID="ddlWHorSC" runat="server" CssClass="form form-full" required="required" OnSelectedIndexChanged="ddlWHorSC_SelectedIndexChanged" AutoPostBack="true">
                                    <asp:ListItem Text="Sales Center" Value="SC"></asp:ListItem>
                                    <asp:ListItem Text="WareHouse" Value="WH"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <div class="grid-12">
                                    <h5 class="typo">SC / WH</h5>
                                </div>
                                <asp:DropDownList ID="ddlSelectWareHouseOrSalesCenter" AutoPostBack="True" OnSelectedIndexChanged="ddlSelectWareHouseOrSalesCenter_SelectedIndexChanged" runat="server" CssClass="form form-full" required="required">
                                </asp:DropDownList>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <div class="grid-12">
                                    <h5 class="typo">Customer ID</h5>
                                </div>
                                <div class="grid-11">
                                    <asp:DropDownList ID="customerIdDropDownList" runat="server" CssClass="form form-full chosen-select">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <div class="grid-12">
                                    <h5 class="typo">Service</h5>
                                </div>
                                <div class="grid-11">
                                    <asp:TextBox ID="txtbxService" runat="server" TabIndex="6" CssClass="form form-full" placeholder="Service Amount"></asp:TextBox>
                                </div>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <div class="grid-12">
                                    <h5 class="typo">Schedule Date</h5>
                                </div>
                                <div class="grid-11">
                                    <div class="grid-1">
                                        <i class="icon-calendar"></i>
                                    </div>
                                    <div class="grid-11">
                                        <asp:TextBox ID="scheduleDateTextBox" CssClass="date-textbox" runat="server" autocomplete="off"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="grid-12 text-center">
                                <asp:Button ID="saveButton" CssClass="btn btn-success btn-3d btn-large"
                                    runat="server" Text="Create Schedule" OnClick="saveButton_OnClick" ValidationGroup="2" />
                            </div>
                        </div>


                        <div class="grid-12">
                            <div id="paymentScheduleListGridContainer">
                                <asp:GridView ID="paymentScheduleListGridView" runat="server" AutoGenerateColumns="false"
                                    CssClass="table table-hover gridView">
                                    <Columns>
                                        <asp:BoundField DataField="CustomerId" HeaderText="Customer ID" />
                                        <asp:BoundField DataField="CustomerName" HeaderText="Customer Name" />
                                        <asp:BoundField DataField="SCWHId" HeaderText="SC / WH" />

                                        <%--<asp:BoundField DataField="LastUnitPrice" HeaderText="Unit Cost" />--%>
                                        <asp:TemplateField HeaderText="Service">
                                            <ItemTemplate>
                                                <asp:TextBox ID="serviceTextBox" Width="60" runat="server" CssClass="serviceTextBox validQty" Text='<%#Eval("ServiceCharge").ToString() %>'></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Schedule Date">
                                            <ItemTemplate>
                                                <i class="icon-calendar"></i>
                                                <asp:TextBox ID="scheduleDateTextBox" runat="server" CssClass="date-textbox" Text='<%#Eval("ScheduleDate").ToString() %>'></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Last Checked Date">
                                            <ItemTemplate>
                                                <asp:TextBox ID="lastCheckedDateTextBox" runat="server" Text='<%#Eval("LastCheckedDate").ToString() %>' ReadOnly="True"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="allCheckBox" runat="server" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="selectCheckBox" runat="server" CssClass="clickCheckBox" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                        <div class="widget-separator text-center grid-12">
                            <asp:Button ID="updateButton" CssClass="btn btn-submit btn-large btn-3d" runat="server" Text="Update Schedule(s)"
                                OnClick="updateButton_OnClick" />
                        </div>

                    </div>

                </div>
            </div>

        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="saveButton" EventName="Click" />
             <asp:AsyncPostBackTrigger ControlID="ddlSelectWareHouseOrSalesCenter" EventName="SelectedIndexChanged" />
             <asp:AsyncPostBackTrigger ControlID="ddlWHorSC" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="updateButton" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        function pageLoad(sender, args) {
            var checkedRowCount = 0;
            $(":checkbox").prop("autocomplete", "off");
            $(".newPriceTextBox").prop("autocomplete", "off");
            $(".buyPriceTextBox").prop("autocomplete", "off");

            $("#allCheckBox").click(function () {
                if ($(this).is(":checked")) {
                    $(".clickCheckBox>#selectCheckBox").prop('checked', true);
                    checkedRowCount = $(".clickCheckBox").length;
                } else {
                    $(".clickCheckBox>#selectCheckBox").prop('checked', false);
                    checkedRowCount = 0;
                }
            });

            $(".clickCheckBox").click(function () {
                if ($(this).find("#selectCheckBox").is(":checked")) {
                    checkedRowCount++;
                    if (checkedRowCount == $(".clickCheckBox").length) {
                        $("#allCheckBox").prop('checked', true);
                    }
                } else {
                    checkedRowCount--;
                    $("#allCheckBox").prop('checked', false);
                }
            });
            $("#paymentScheduleListGridView").dataTable({
                "bProcessing": true,
                "sPaginationType": "full_numbers",
                "aLengthMenu": [[10, 15, 20, 25, 50, 100, -1], [10, 15, 20, 25, 50, 100, "All"]],
                "iDisplayLength": 10,

                "bInfo": true
            });

            $("#paymentScheduleListGridView_wrapper .row-fluid:nth-child(1)").css("display", "none");

            $("#allProductListButton").click(function () {
                if (haveOverlay == 0) {
                    MyOverlayStart();
                }
            });
            $(".datepicker").remove();
            var dateFormat = '<%= Session["DateFormatForDatePicker"] %>';
            $(".date-textbox").datepicker({ format: dateFormat });
            $(".date-textbox, .icon-calendar").click(function () {
                $(this).parent().find(".date-textbox").focus();
            });

            $(".validQty").each(function () {
                if ($(this).parent().parent().find("#selectCheckBox").is(":checked") && ($(this).val() == "" || isNaN($(this).val()) || ($(this).val() != parseFloat($(this).val())) || $(this).val() < 0)) {
                    $(this).addClass("validGridControl");
                    countGridValid++;
                } else {
                    $(this).removeClass("validGridControl");
                }
            });

            var config = {
                '.chosen-select': {},
                '.chosen-select-deselect': { allow_single_deselect: true },
                '.chosen-select-no-single': { disable_search_threshold: 20 },
                '.chosen-select-no-results': { no_results_text: 'Oops, nothing found!' },
                '.chosen-select-width': { width: "96%" }
            };
            for (var selector in config) {
                $(selector).chosen(config[selector]);
            }
        }
    </script>
</asp:Content>
