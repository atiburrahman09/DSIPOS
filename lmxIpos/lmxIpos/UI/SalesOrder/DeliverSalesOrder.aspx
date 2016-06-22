<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true"
    CodeBehind="DeliverSalesOrder.aspx.cs" Inherits="lmxIpos.UI.SalesOrder.DeliverSalesOrder" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
    <link href="/Content/Style/CSSPages/SalesOrderDetail.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
     <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="true">
        <ContentTemplate>
            <div class="title-sitemap grid-12">
                <h1 class="grid-6">
                    <i>&#xf132;</i>Deliver Sales Order [<asp:Label ID="idLabel" runat="server" Text=""></asp:Label>]</span></h1>
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
                        <h3 id="Header3" runat="server" class="widget-header-title">Deliver Sales Order
                        </h3>
                    </header>
                    <div class="widget-body no-padding">
                        <div class="widget-separator grid-12">
                            <div class="grid-12">
                             <div class="widget-separator no-border grid-6">
                                <div class="grid-12">
                                    <div class="grid-6"> Order ID :</div>
                                    <div class="grid-6">
                                        <asp:Label ID="orderIdLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                    </div>
                                </div>
                                 </div>
                            <div class="widget-separator no-border grid-6">
                                <div class="grid-12">
                                    <div class="grid-6"> Order Date :</div>
                                    <div class="grid-6">
                                        <asp:Label ID="orderDateLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                    </div>
                                </div>
                                 </div>
                            </div>
                            <div class="grid-12">
                             <div class="widget-separator no-border grid-6">
                                <div class="grid-12">
                                    <div class="grid-6"> Sales Center ID & Name :</div>
                                    <div class="grid-6">
                                        <div class="grid-12">
                                            <div class="grid-6">
                                                <asp:Label ID="salesCenterIdLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                            </div>
                                            <div class="grid-6">
                                                <asp:Label ID="salesCenterNameLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                            </div>
                                        </div>                                        
                                    </div>
                                </div>
                                 </div>
                            <div class="widget-separator no-border grid-6">
                                <div class="grid-12">
                                    <div class="grid-6">Sales Person ID & Name :</div>
                                    <div class="grid-6">
                                        <div class="grid-12">
                                            <div class="grid-6">
                                                <asp:Label ID="salesPersonIdLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                            </div>
                                            <div class="grid-6">
                                                <asp:Label ID="salesPersonNameLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                            </div>
                                        </div> 
                                    </div>
                                </div>
                                 </div>

                            </div>
                            <div class="grid-12">
                             <div class="widget-separator no-border grid-6">
                                <div class="grid-12">
                                    <div class="grid-6"> Narration :</div>
                                    <div class="grid-6">
                                        <asp:Label ID="narrationLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                    </div>
                                </div>
                                 </div>
                            <div class="widget-separator no-border grid-6">
                                <div class="grid-12">
                                    <div class="grid-6"> Status:
                             </div>
                                    <div class="grid-6">
                                       <asp:Label ID="statusLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label> 
                                    </div>
                                </div>
                                 </div>
                            </div>
                            <div class="grid-12">
                             <div class="widget-separator no-border grid-6">
                                <div class="grid-12">
                                    <div class="grid-6">  Customer ID :</div>
                                    <div class="grid-6">
                                        <asp:Label ID="customerIdLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                    </div>
                                </div>
                                 </div>
                            <div class="widget-separator no-border grid-6">
                                <div class="grid-12">
                                    <div class="grid-6"> Customer Name :
                             </div>
                                    <div class="grid-6">
                                       <asp:Label ID="customerNameLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                    </div>
                                </div>
                                 </div>
                            </div>

                             <div class="grid-12">
                             <div class="widget-separator no-border grid-6">
                                <div class="grid-12">
                                    <div class="grid-6">  Customer Contact Number :</div>
                                    <div class="grid-6">
                                        <asp:Label ID="customerContactNumberLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                    </div>
                                </div>
                                 </div>
                            <div class="widget-separator no-border grid-6">
                                <div class="grid-12">
                                    <div class="grid-6"> Customer Address :
                             </div>
                                    <div class="grid-6">
                                      <asp:Label ID="customerAddressLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                    </div>
                                </div>
                                 </div>
                            </div>

                            <div class="grid-12">
                             <div class="widget-separator no-border grid-6">
                                <div class="grid-12">
                                    <div class="grid-6"> Transport Type: :</div>
                                    <div class="grid-6">
                                        <asp:Label ID="transportTypeLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                    </div>
                                </div>
                                 </div>
                            <div class="widget-separator no-border grid-6">
                                <div class="grid-12">
                                    <div class="grid-6"> Shipping Address :
                             </div>
                                    <div class="grid-6">
                                       <asp:Label ID="shippingAddressLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label> 
                                    </div>
                                </div>
                                 </div>
                            </div>

                            <div class="grid-12">
                             <div class="widget-separator no-border grid-6">
                                <div class="grid-12">
                                    <div class="grid-6">  Billing Address :</div>
                                    <div class="grid-6">
                                        <asp:Label ID="billingAddressLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                    </div>
                                </div>
                                 </div>
                            <div class="widget-separator no-border grid-6">
                                <div class="grid-12">
                                    <div class="grid-6"> Payment Mode :
                             </div>
                                    <div class="grid-6">
                                       <asp:Label ID="paymentModeLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                    </div>
                                </div>
                                 </div>
                            </div>

                            <div class="grid-12">
                             <div class="widget-separator no-border grid-6">
                                <div class="grid-12">
                                    <div class="grid-6"> Cheque Number :</div>
                                    <div class="grid-6">
                                        <asp:Label ID="chequeNumberLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                    </div>
                                </div>
                                 </div>
                            <div class="widget-separator no-border grid-6">
                                <div class="grid-12">
                                    <div class="grid-6"> Cheque Date :
                             </div>
                                    <div class="grid-6">
                                       <asp:Label ID="chequeDateLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label> 
                                    </div>
                                </div>
                                 </div>
                            </div>

                            <div class="grid-12">
                             <div class="widget-separator no-border grid-6">
                                <div class="grid-12">
                                    <div class="grid-6">Bank :</div>
                                    <div class="grid-6">
                                        <asp:Label ID="bankLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                    </div>
                                </div>
                                 </div>
                            <div class="widget-separator no-border grid-6">
                                <div class="grid-12">
                                    <div class="grid-6">Bank Branch :
                             </div>
                                    <div class="grid-6">
                                       <asp:Label ID="bankBranchLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label> 
                                    </div>
                                </div>
                                 </div>
                            </div>

                            <div class="grid-12">
                             <div class="widget-separator no-border grid-6">
                                <div class="grid-12">
                                    <div class="grid-6"> Delivery Date :</div>
                                    <div class="grid-6">
                                        <asp:Label ID="deliveryDateLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                    </div>
                                </div>
                                 </div>
                            <div class="widget-separator no-border grid-6">
                                <div class="grid-12">
                                    <div class="grid-6">LC Number :
                             </div>
                                    <div class="grid-6">
                                       <asp:Label ID="lcNumberLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label> 
                                    </div>
                                </div>
                                 </div>
                            </div>

                            <div class="grid-12">
                             <div class="widget-separator no-border grid-6">
                                <div class="grid-12">
                                    <div class="grid-6"> Transport Date :</div>
                                    <div class="grid-6">
                                        <asp:Label ID="transportDateLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                    </div>
                                </div>
                                 </div>
                            <div class="widget-separator no-border grid-6">
                                <div class="grid-12">
                                    <div class="grid-6">
                             </div>
                                    <div class="grid-6">
                                       
                                    </div>
                                </div>
                                 </div>
                            </div>
                            </div>
                        <div class="widget-separator no-padding grid-12">
                            <div id="salesOrderProductListGridContainer">
                <asp:GridView ID="salesOrderProductListGridView" runat="server" AutoGenerateColumns="false"
                    CssClass="table table-hover gridView">
                    <Columns>
                        <asp:BoundField DataField="ProductId" HeaderText="Product ID" />
                        <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                        <asp:BoundField DataField="FreeQuantityWasUnit" HeaderText="Free Quantity Was" />
                        <asp:BoundField DataField="QuantityUnit" HeaderText="Quantity" />
                        <asp:BoundField DataField="RatePerUnit" HeaderText="Rate Per Unit" />
                        <asp:BoundField DataField="Amount" HeaderText="Amount" />
                    </Columns>
                </asp:GridView>
            </div>
                        </div>

                        <div class="widget-separator grid-12">
                            <div class="grid-12">
                             <div class="widget-separator no-border grid-6">
                                <div class="grid-12">
                                    <div class="grid-6"> Total Amount :</div>
                                    <div class="grid-6">
                                        <asp:Label ID="totalAmountLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                    </div>
                                </div>
                                 </div>
                            <div class="widget-separator no-border grid-6">
                                <div class="grid-12">
                                    <div class="grid-6">  VAT (%) :</div>
                                    <div class="grid-6">
                                        <asp:Label ID="vatLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                    </div>
                                </div>
                                 </div>
                            </div>

                             <div class="grid-12">
                             <div class="widget-separator no-border grid-6">
                                <div class="grid-12">
                                    <div class="grid-6"> Total Receivable :</div>
                                    <div class="grid-6">
                                        <asp:Label ID="totalReceivableLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                    </div>
                                </div>
                                 </div>
                            <div class="widget-separator no-border grid-6">
                                <div class="grid-12">
                                    <div class="grid-6">  Received Amount :</div>
                                    <div class="grid-6">
                                        <asp:Label ID="receivedAmountLabel" runat="server" Text="" CssClass="infoLabel"></asp:Label>
                                    </div>
                                </div>
                                 </div>
                            </div>

                        </div>

                        <div class="widget-separator grid-12">
                            <div class="grid-4">
                                <asp:Button ID="deliveredButton" runat="server" Enabled="false" CssClass="btn btn-primary"
                Text="Sales Order Delivered" OnClick="deliveredButton_Click" />
                            </div>
                        </div>

                        </div>
                    </div>
                <asp:HiddenField ID="salesOrderIdForViewHiddenField" runat="server" />
                </div>
                            </ContentTemplate>
         </asp:UpdatePanel>
    
</asp:Content>
<asp:Content ID="scriptContent" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        $(function () {
            $("#salesOrderProductListGridView").dataTable({
                "bProcessing": true,
                "sPaginationType": "full_numbers",
                "aLengthMenu": [[10, 15, 20, 25, 50, -1], [10, 15, 20, 25, 50, "All"]],
                "iDisplayLength": -1,
                "bSort": true,
                //"aoColumnDefs": [{ 'bSortable': false, 'aTargets': []}],
                "bFilter": false,
                "bLengthChange": true,
                "bPaginate": false,
                "bInfo": true
            });

            $("#salesOrderProductListGridView_wrapper .row-fluid:nth-child(1)").css("display", "none");
        });
    </script>
</asp:Content>
