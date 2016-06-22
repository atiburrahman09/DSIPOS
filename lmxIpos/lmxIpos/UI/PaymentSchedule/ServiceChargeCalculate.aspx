<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true" CodeBehind="ServiceChargeCalculate.aspx.cs" Inherits="lmxIpos.UI.PaymentSchedule.ServiceChargeCalculate" EnableEventValidation="false" %>

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
                                <asp:DropDownList ID="ddlSelectWareHouseOrSalesCenter" runat="server" CssClass="form form-full" required="required">
                                </asp:DropDownList>
                            </div>
                            <div class="widget-separator no-border text-center grid-12">
                                <asp:Button ID="CalculateChargeButton" CssClass="btn btn-submit btn-large btn-3d" runat="server" Text="Calculate Today's Service Charge(s)"
                                    OnClick="CalculateChargeButton_OnClick" />
                            </div>
                            <%-- <div class="widget-separator no-border grid-3">
                                <div class="grid-12">
                                    <h5 class="typo">Customer ID</h5>
                                </div>
                                <div class="grid-11">
                                    <asp:DropDownList ID="customerIdDropDownList" runat="server" CssClass="form form-full chosen-select">
                                    </asp:DropDownList>
                                </div>
                            </div>--%>
                            <%-- <div class="widget-separator no-border grid-3">
                                <div class="grid-12">
                                    <h5 class="typo">Service</h5>
                                </div>
                                <div class="grid-11">
                                    <asp:TextBox ID="txtbxService" runat="server" TabIndex="6" CssClass="form form-full" placeholder="Service Amount"></asp:TextBox>
                                </div>
                            </div>--%>
                            <%--<div class="widget-separator no-border grid-3">
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
                            </div>--%>
                        </div>
                        <hr />
                        <div class="grid-12">
                            <div class="widget-separator no-border grid-3">
                                <div class="grid-12">
                                    <h5 class="typo">Date From</h5>
                                </div>
                                <div class="grid-11">
                                    <div class="grid-1">
                                        <i class="icon-calendar"></i>
                                    </div>
                                    <div class="grid-11">
                                        <asp:TextBox ID="fromDateTextBox" CssClass="date-textbox form form-full" runat="server"
                                            autocomplete="off"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <div class="grid-12">
                                    <h5 class="typo">Date To</h5>
                                </div>
                                <div class="grid-11">
                                    <div class="grid-1">
                                        <i class="icon-calendar"></i>
                                    </div>
                                    <div class="grid-11">
                                        <asp:TextBox ID="toDateTextBox" CssClass="date-textbox form form-full" runat="server"
                                            autocomplete="off"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="widget-separator no-border grid-3">
                                <div class="grid-12">
                                    <h5 class="typo">&nbsp;</h5>
                                </div>
                                <asp:Button ID="btnViewCalcuate" CssClass="btn btn-info" OnClick="btnViewCalcuate_OnClick" runat="server" Text="View"></asp:Button>
                            </div>
                        </div>


                        <div class="grid-12">
                            <div id="paymentScheduleCalListGridContainer">
                                <asp:GridView ID="paymentScheduleCalulateListGridView" runat="server" AutoGenerateColumns="false"
                                    CssClass="table table-hover gridView">
                                    <Columns>
                                        <asp:BoundField DataField="SalesRecordId" HeaderText="Record ID" />
                                        <asp:BoundField DataField="CustomerId" HeaderText="Customer ID" />
                                        <asp:BoundField DataField="CustomerName" HeaderText="Customer Name" />
                                        <asp:BoundField DataField="ServiceCharPar" HeaderText="Service Charge (%)" />
                                        <asp:BoundField DataField="ServiceChargeAmount" HeaderText="Amount" />
                                        <asp:BoundField DataField="DeusAmount" HeaderText="Dues Was" />
                                        <asp:BoundField DataField="CalculateDate" HeaderText="Calculate Date" />
                                        <asp:BoundField DataField="CreatedBy" HeaderText="Calculate By" />
                                        <asp:BoundField DataField="Description" HeaderText="Description" />
                                        <%--<asp:TemplateField HeaderText="Details">
                                            <ItemTemplate>
                                                <a href="#" class="btn" data-toggle="popover" data-placement="left" data-content="Vivamus sagittis lacus vel augue laoreet rutrum faucibus." title="" data-original-title="Popover on left">Popover on left</a>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>

                                        <%--<asp:BoundField DataField="LastUnitPrice" HeaderText="Unit Cost" />--%>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>


                    </div>

                </div>
            </div>

        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="CalculateChargeButton" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="ddlWHorSC" EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">

    <script type="text/javascript">
        function pageLoad(sender, args) {
            $(".datepicker").remove();
            var dateFormat = '<%= Session["DateFormatForDatePicker"] %>';
            $(".date-textbox").datepicker({ format: dateFormat });
            $(".date-textbox, .icon-calendar").click(function () {
                $(this).parent().find(".date-textbox").focus();
            })

            $("#paymentScheduleCalulateListGridView").dataTable({
                "bProcessing": true,
                "bStateSave": true,
                "bRetrieve": true,
                "bDestroy": true,
                "sPaginationType": "full_numbers",
                "aLengthMenu": [[10, 15, 20, 25, 50, -1], [10, 15, 20, 25, 50, "All"]],
                "aoColumnDefs": [{ 'bSortable': false, 'aTargets': [] }]
            });

        }
    </script>
</asp:Content>
