﻿<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Search.aspx.cs" Inherits="lmxIpos.UI.Library.Book.Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1" ChildrenAsTriggers="true">
        <ContentTemplate>
            <div class="title-sitemap grid-12">
                <h1 class="grid-6">
                    <i>&#xf132;</i>Search Book<span>Book Searching</span></h1>
                <div class="sitemap grid-6">
                    <%--<ul>
                        <li><span>Acura</span><i>/</i></li>
                        <li><a href="Default.aspx">Dashboard</a></li>
                    </ul>--%>
                </div>
            </div>
            <div class="data">
                <div id="msgbox" runat="server" visible="false" class="alert alert-block alert-success">
                    <button data-dismiss="alert" class="close" type="button">
                        <i class="icon icon-times"></i>
                    </button>
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
                        <h3 id="Header3" runat="server" class="widget-header-title">Advance Search For Books</h3>
                    </header>
                    <div class="widget-body no-padding">

                        <div class="grid-12 padding10">
                            <asp:TextBox ID="txtbxSearch" runat="server" CssClass="padding15"></asp:TextBox>
                            <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-info " Text="Search" OnClick="btnSearch_OnClick" />
                        </div>
                        <div class="grid-12">
                            <asp:CheckBoxList ID="bookCheckBoxList" CssClass="form-control" runat="server" RepeatLayout="flow" RepeatDirection="Horizontal" required="required">
                                <asp:ListItem Text="Book Name" Value="BN"></asp:ListItem>
                                <asp:ListItem Text="Writter Name" Value="WN"></asp:ListItem>
                                <asp:ListItem Text="Publisher Name" Value="PN"></asp:ListItem>
                                <asp:ListItem Text="Book Language" Value="BL"></asp:ListItem>
                                <asp:ListItem Text="Almari No" Value="AN"></asp:ListItem>
                                <asp:ListItem Text="Library Name" Value="LN"></asp:ListItem>
                            </asp:CheckBoxList>
                            <div class="clearfix"></div>
                            <div class="grid-12">
                                <div class="row-fluid dtresponsive">
                                    <asp:GridView ID="bookListGridView" runat="server" AutoGenerateColumns="false" CssClass="table table-hover table-condensed" AllowPaging="true">
                                        <Columns>
                                            <asp:BoundField DataField="BookId" HeaderText="BookId" />
                                            <asp:BoundField DataField="BookSerial" HeaderText="Book Serial" Visible="False" />
                                        <%--    <asp:BoundField DataField="AlmariNo" HeaderText="Almari No" />--%>
                                             <asp:TemplateField HeaderText="Almari No">
                                                <ItemTemplate>
                                                   <asp:Label ID="lvlAlmariNo" Text='<%# HighlightText(Eval("AlmariNo").ToString()) %>' runat="server"/>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Price" HeaderText=" Price" />
                                            <%--<asp:BoundField DataField="BookName" HeaderText="Book Name" />--%>
                                             <asp:TemplateField HeaderText="Book Name">
                                                <ItemTemplate>
                                                   <asp:Label ID="lvlBookName" Text='<%# HighlightText(Eval("BookName").ToString()) %>' runat="server"/>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:BoundField DataField="WriterName" HeaderText="Writer Name" />--%>
                                            <asp:TemplateField HeaderText="Writter Name">
                                                <ItemTemplate>
                                                   <asp:Label ID="lvlWriterName" Text='<%# HighlightText(Eval("WriterName").ToString()) %>' runat="server"/>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Songkolok" HeaderText="Songkolok" />
                                            <asp:BoundField DataField="Onubadok" HeaderText="Translator" />
                                            <asp:BoundField DataField="BookLanguage" HeaderText="Book Language" />
                                            <asp:TemplateField HeaderText="Book Language">
                                                <ItemTemplate>
                                                   <asp:Label ID="lvlBookLanguage" Text='<%# HighlightText(Eval("BookLanguage").ToString()) %>' runat="server"/>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Bishoy" HeaderText="Subject" />
                                            <asp:BoundField DataField="Publisher" HeaderText="Publisher" />
                                            <asp:TemplateField HeaderText="Publisher">
                                                <ItemTemplate>
                                                   <asp:Label ID="lvlPublisher" Text='<%# HighlightText(Eval("Publisher").ToString()) %>' runat="server"/>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Edit">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="EditLinkButton" CssClass="btn btn-success" runat="server" OnClick="EditLinkButton_OnClick">Edit</asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="View">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="viewLinkButton" CssClass="btn btn-info" runat="server" OnClick="viewLinkButton_Click">View</asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>

                                </div>
                            </div>
                            <div class="widget" id="infoBody" runat="server" visible="False">
                                <div class="widget-body no-padding" style="line-height: 30px; font-size: 17px;">

                                    <div class="grid-12">
                                        <div class="widget-separator grid-4">
                                            <div class="grid-12 ">
                                                <div class="pull-left">
                                                    <asp:Label ID="Label20" runat="server" BackColor="#0ABFBC" Text=" নং"></asp:Label>
                                                </div>
                                                <div class="pull-right">
                                                    <asp:Label ID="lblNo" CssClass="  form-control" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="grid-12">
                                                <div class="pull-left">
                                                    <asp:Label ID="Label18" runat="server" BackColor="#0ABFBC" Text=" কিতাবের সিরিয়াল নং"></asp:Label>
                                                </div>
                                                <div class="pull-right">
                                                    <asp:Label ID="lblKitaberSerialNo" CssClass="  form-control" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="grid-12">
                                                <div class="pull-left">
                                                    <asp:Label ID="Label19" runat="server" BackColor="#0ABFBC" Text=" আলমারি নং"></asp:Label>
                                                </div>
                                                <div class="pull-right">
                                                    <asp:Label ID="lblAlmariNo" CssClass="  form-control" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="grid-12">
                                                <div class="pull-left">
                                                    <asp:Label ID="Label4" runat="server" BackColor="#0ABFBC" Text="তাক নং"></asp:Label>
                                                </div>
                                                <div class="pull-right">
                                                    <asp:Label ID="lblTakNo" CssClass="  form-control" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="grid-12">
                                                <div class="pull-left">
                                                    <asp:Label ID="Label5" runat="server" BackColor="#0ABFBC" Text="কলাম নং"></asp:Label>
                                                </div>
                                                <div class="pull-right">
                                                    <asp:Label ID="lblKolamNo" CssClass="  form-control" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="grid-12">
                                                <div class="pull-left">
                                                    <asp:Label ID="Label6" runat="server" BackColor="#0ABFBC" Text="কিতাব নং"></asp:Label>
                                                </div>
                                                <div class="pull-right">
                                                    <asp:Label ID="lblKitabNo" CssClass="  form-control" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="grid-12">
                                                <div class="pull-left">
                                                    <asp:Label ID="Label7" runat="server" BackColor="#0ABFBC" Text="কপি সংখ্যা"></asp:Label>
                                                </div>
                                                <div class="pull-right">
                                                    <asp:Label ID="lblCopyNumber" CssClass="  form-control" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="grid-12">
                                                <div class="pull-left">
                                                    <asp:Label ID="Label8" runat="server" BackColor="#0ABFBC" Text="মোট ভলিউম নং"></asp:Label>
                                                </div>
                                                <div class="pull-right">
                                                    <asp:Label ID="lblTotalVolume" CssClass="  form-control" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="grid-12">
                                                <div class="pull-left">
                                                    <asp:Label ID="Label1" runat="server" BackColor="#0ABFBC" Text="ভলিউম নং"></asp:Label>
                                                </div>
                                                <div class="pull-right">
                                                    <asp:Label ID="lblVolumeNo" CssClass="  form-control" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="grid-12">
                                                <div class="pull-left">
                                                    <asp:Label ID="Label9" runat="server" BackColor="#0ABFBC" Text="খণ্ড নং"></asp:Label>
                                                </div>
                                                <div class="pull-right">
                                                    <asp:Label ID="lblKhondoNo" CssClass="  form-control" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="grid-12">
                                                <div class="pull-left">
                                                    <asp:Label ID="Label10" runat="server" BackColor="#0ABFBC" Text="পৃষ্ঠা সংখ্যা"></asp:Label>
                                                </div>
                                                <div class="pull-right">
                                                    <asp:Label ID="lblPageNo" CssClass="  form-control" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="grid-12">
                                                <div class="pull-left">
                                                    <asp:Label ID="Label11" runat="server" BackColor="#0ABFBC" Text="মূল্য"></asp:Label>
                                                </div>
                                                <div class="pull-right">
                                                    <asp:Label ID="lblPrice" CssClass="  form-control" runat="server"></asp:Label>
                                                </div>
                                            </div>

                                        </div>

                                        <div class="widget-separator grid-4">
                                            <div class="grid-12">
                                                <div class="pull-left">
                                                    <asp:Label ID="Label17" runat="server" BackColor="#0ABFBC" Text="কিতাবের মুল নাম"></asp:Label>
                                                </div>
                                                <div class="pull-right">
                                                    <asp:Label ID="lblKitaberMainName" TextMode="MultiLine" CssClass="  form-control" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="grid-12">
                                                <div class="pull-left">
                                                    <asp:Label ID="Label2" runat="server" BackColor="#0ABFBC" Text="কিতাবের মাশহুর নাম"></asp:Label>
                                                </div>
                                                <div class="pull-right">
                                                    <asp:Label ID="lblKitaberSpecialName" TextMode="MultiLine" CssClass="  form-control" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="grid-12">
                                                <div class="pull-left">
                                                    <asp:Label ID="Label3" runat="server" BackColor="#0ABFBC" Text="লিখক"></asp:Label>
                                                </div>
                                                <div class="pull-right">
                                                    <asp:Label ID="lblWritter" TextMode="MultiLine" CssClass="  form-control" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="grid-12">
                                                <div class="pull-left">
                                                    <asp:Label ID="Label12" runat="server" BackColor="#0ABFBC" Text="লিখকের জন্ম সন"></asp:Label>
                                                </div>
                                                <div class="pull-right">
                                                    <asp:Label ID="lblWritterBornDate" CssClass="  form-control" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="grid-12">
                                                <div class="pull-left">
                                                    <asp:Label ID="Label13" runat="server" BackColor="#0ABFBC" Text="লিখকের ইন্তিকাল"></asp:Label>
                                                </div>
                                                <div class="pull-right">
                                                    <asp:Label ID="lblWritterDeathDate" CssClass="  form-control" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="grid-12">
                                                <div class="pull-left">
                                                    <asp:Label ID="Label14" runat="server" BackColor="#0ABFBC" Text="লিখকের মাজহাব"></asp:Label>
                                                </div>
                                                <div class="pull-right">
                                                    <asp:Label ID="lblWritterMajhab" CssClass="  form-control" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="grid-12">
                                                <div class="pull-left">
                                                    <asp:Label ID="Label15" runat="server" BackColor="#0ABFBC" Text="সংকলক"></asp:Label>
                                                </div>
                                                <div class="pull-right">
                                                    <asp:Label ID="lblSongkolp" CssClass="  form-control" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="grid-12">
                                                <div class="pull-left">
                                                    <asp:Label ID="Label16" runat="server" BackColor="#0ABFBC" Text="অনুবাদক"></asp:Label>
                                                </div>
                                                <div class="pull-right">
                                                    <asp:Label ID="lblTranslator" CssClass="  form-control" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="grid-12">
                                                <div class="pull-left">
                                                    <asp:Label ID="Label21" runat="server" BackColor="#0ABFBC" Text="অনুবাদকের জন্ম ও ইন্তেকাল"></asp:Label>
                                                </div>
                                                <div class="pull-right">
                                                    <asp:Label ID="lblTranslatorsDate" CssClass="  form-control" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="grid-12">
                                                <div class="pull-left">
                                                    <asp:Label ID="Label22" runat="server" BackColor="#0ABFBC" Text="অনুবাদকের মাজহাব"></asp:Label>
                                                </div>
                                                <div class="pull-right">
                                                    <asp:Label ID="lblTranslatorMajhab" CssClass="  form-control" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="grid-12">
                                                <div class="pull-left">
                                                    <asp:Label ID="Label23" runat="server" BackColor="#0ABFBC" Text="কিতাবের মুল ভাষা "></asp:Label>
                                                </div>
                                                <div class="pull-right col-lg-7">
                                                    <asp:Label ID="lblMainLanguage" runat="server" Text=""></asp:Label>
                                                </div>
                                            </div>
                                            <div class="grid-12">

                                                <div class="pull-left">
                                                    <asp:Label ID="Label24" runat="server" BackColor="#0ABFBC" Text=" অনুদিত ভাষা"></asp:Label>
                                                </div>
                                                <div class="pull-right col-lg-7">
                                                    <asp:Label ID="lblTranslatedLanguage" runat="server" Text=""></asp:Label>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="widget-separator grid-4" style="border-bottom: none;">

                                            <div class="grid-12">
                                                <div class="pull-left">
                                                    <asp:Label ID="Label25" runat="server" BackColor="#0ABFBC" Text="বিষয়"></asp:Label>
                                                </div>
                                                <div class="pull-right">
                                                    <asp:Label ID="lblSubject" CssClass="  form-control" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="grid-12">
                                                <div class="pull-left">
                                                    <asp:Label ID="Label26" runat="server" BackColor="#0ABFBC" Text="অদ্ধায়/পরিচ্ছেদ"></asp:Label>
                                                </div>
                                                <div class="pull-right">
                                                    <asp:Label ID="lblChapter" CssClass="  form-control" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="grid-12">
                                                <div class="pull-left">
                                                    <asp:Label ID="Label27" runat="server" BackColor="#0ABFBC" Text="প্রকাশক"></asp:Label>
                                                </div>
                                                <div class="pull-right">
                                                    <asp:Label ID="lblProkashok" CssClass="  form-control" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="grid-12">
                                                <div class="pull-left">
                                                    <asp:Label ID="Label28" runat="server" BackColor="#0ABFBC" Text="প্রকাশকাল"></asp:Label>
                                                </div>
                                                <div class="pull-right">
                                                    <asp:Label ID="lblProkashkal" CssClass="  form-control" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="grid-12">
                                                <div class="pull-left">
                                                    <asp:Label ID="Label29" runat="server" BackColor="#0ABFBC" Text="প্রকাশনী"></asp:Label>
                                                </div>
                                                <div class="pull-right">
                                                    <asp:Label ID="lblProkashoni" CssClass="  form-control" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="grid-12">
                                                <div class="pull-left">
                                                    <asp:Label ID="Label30" runat="server" BackColor="#0ABFBC" Text="প্রকাশ স্থান"></asp:Label>
                                                </div>
                                                <div class="pull-right">
                                                    <asp:Label ID="lblProkashsthan" CssClass="  form-control" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="grid-12">
                                                <div class="pull-left">
                                                    <asp:Label ID="Label31" runat="server" BackColor="#0ABFBC" Text="সম্পাদনা"></asp:Label>
                                                </div>
                                                <div class="pull-right">
                                                    <asp:Label ID="lblSompadona" CssClass="  form-control" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="grid-12">
                                                <div class="pull-left">
                                                    <asp:Label ID="Label32" runat="server" BackColor="#0ABFBC" Text="সংস্করণ"></asp:Label>
                                                </div>
                                                <div class="pull-right">
                                                    <asp:Label ID="lblSongokoron" CssClass="  form-control" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="grid-12">
                                                <div class="pull-left">
                                                    <asp:Label ID="Label33" runat="server" BackColor="#0ABFBC" Text="সার সংখেপ/সূচী"></asp:Label>
                                                </div>
                                                <div class="pull-right">
                                                    <asp:Label ID="lblSarSonkhep" TextMode="MultiLine" CssClass="  form-control" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="grid-12">
                                                <div class="pull-left">
                                                    <asp:Label ID="Label34" runat="server" BackColor="#0ABFBC" Text="মন্তব্য"></asp:Label>
                                                </div>
                                                <div class="pull-right">
                                                    <asp:Label ID="lblComment" TextMode="MultiLine" CssClass="  form-control" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        function pageLoad(sender, args) {
            //$.ajax({
            //    type: "POST",
            //    url: "/Services/BookName.ashx",
            //    success: function (d) {
            //        var array = [];
            //        d.split(';').forEach(function (value) {
            //            array.push(value);
            //        });
            //        $('#txtbxSearch').typeahead({ source: array });

            //    }
            //});
            $("#bookListGridView").dataTable({
                "bProcessing": true,
                "bStateSave": true,
                "sPaginationType": "full_numbers",
                "aLengthMenu": [[10, 15, 20, 25, 50, 100, -1], [10, 15, 20, 25, 50, 100, "All"]],
                "Scrollx": true,
                "aoColumnDefs": [{ 'bSortable': false, 'aTargets': [6, 7, 8, 9] }]
            });
            //var searchedText = $("#txtbxSearch").val();
            //console.log(searchedText);
            //var myHilitor; // global variable
            //document.addEventListener("DOMContentLoaded", function () {
            //    myHilitor = new Hilitor("#bookListGridView");
            //    myHilitor.apply(searchedText);
            //}, false);

            //var myHilitor = new Hilitor("#bookListGridView");
            //console.log(myHilitor);
            //myHilitor.apply(searchedText);
            //$('#txtbxSearch').highlight(searchedText);


        }
    </script>
</asp:Content>
