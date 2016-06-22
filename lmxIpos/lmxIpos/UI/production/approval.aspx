<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="approval.aspx.cs" Inherits="lmxIpos.UI.production.approval" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel ID="updatePanel" runat="server"  UpdateMode="Conditional" ChildrenAsTriggers="true">
        <ContentTemplate>
    <div class="title-sitemap grid-12">
                <h1 class="grid-8">
 
                    <i></i>Approval<span>Production Approval Record list</span></h1>
                <div class="sitemap grid-6">   
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
                        <h3 class="widget-header-title" id="Header3">Approval List</h3>
                    </header>
            <div class="widget-body no-padding">
                <div class="widget-separator no-padding grid-12">
                    <div class="widget-separator no-border grid-3">
                         <h5 class="typo">Warehouse Name
                           </h5>
                        <asp:DropDownList ID="ddlWareHouseList" runat="server" CssClass="form form-full"
                                    required="required"></asp:DropDownList>
                    </div>
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
                                <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Status
                                </h5>
                                <asp:DropDownList ID="ddlstatus" runat="server">
                                    <asp:ListItem Value="All">All</asp:ListItem>
                                    <asp:ListItem Value="A">Approved</asp:ListItem>
                                    <asp:ListItem Value="P">Pending</asp:ListItem>
                                    <asp:ListItem Value="R">Rejected</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        <div class="widget-separator no-border grid-3">
                            <asp:Button ID="btnProducktionRL" runat="server" Text="Get Production Record List" CssClass="btn btn-info" OnClick="btnProducktionRL_Click" />
                   
                            </div>
                  </div>
                  
                <div class="widget-separator no-padding grid-12">
                    <div class="grid-12" style="padding:20px;">
                        <asp:GridView ID="gridProductionList" runat="server" AutoGenerateColumns="false" CssClass="table table-hover dataTable">
                            <Columns>
                               <asp:BoundField DataField="ProductionId" HeaderText="Production ID" />
                                <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                                <asp:BoundField DataField="ProduceDate" HeaderText="Produce Date" DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="false" />
                                <asp:BoundField DataField="UnitCost" HeaderText="Unit Cost" />
                                <asp:BoundField DataField="ProductionCost" HeaderText="Production Cost" />
                                <asp:BoundField DataField="TotalQualnity" HeaderText="Quantity" />
                                 <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="viewLinkButton" runat="server" CssClass="btn btn-mini btn-info" OnClick="viewLinkButton_Click"
                                                   >View</asp:LinkButton>
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
            <asp:AsyncPostBackTrigger ControlID="btnProducktionRL" EventName="Click" />
             <%--<asp:AsyncPostBackTrigger ControlID="viewLinkButton" EventName="Click" />--%>
            </Triggers>
        </asp:UpdatePanel>
   
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        function pageLoad(sender, args) {
            $(".date-textbox").datepicker(
                {
                    autoclose: true
                });
            
            $("#gridProductionList").dataTable(//{
                //"bProcessing": true,
                //"sPaginationType": "full_numbers",
                //"aLengthMenu": [[10, 25, 50, -1], [10, 25, 50, "All"]],
                //"iDisplayLength": -1,
                //"bSort": true,
                //"aoColumnDefs": [{ 'bSortable': false, 'aTargets': [5, 6, 7] }],
                //"bFilter": true,
                //"bLengthChange": true,
                //"bPaginate": true,
                //"bInfo": false,
                //"bState": true
           // }
        );
        }
    </script>
</asp:Content>
