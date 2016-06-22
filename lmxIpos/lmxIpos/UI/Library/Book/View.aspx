﻿<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="View.aspx.cs" Inherits="lmxIpos.UI.Book.View" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
    <link href="../../../content/css/fontForView.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="Conditional" ChildrenAsTriggers="true">
        <ContentTemplate>
            <div class="title-sitemap grid-12">
                <h1 class="grid-6">
                    <i>&#xf132;</i>Book List<span>Book List View</span></h1>
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
                        <h3 id="Header3" runat="server" class="widget-header-title">List Of Book</h3>
                    </header>
                    <div class="widget-body no-padding">
                        <div class="widget-separator no-padding grid-12">
                            <div class="widget-separator no-border grid-3">
                                <h5 class="typo">Search For Book
                                </h5>
                                <asp:DropDownList ID="ddlSearch" runat="server" CssClass="form form-full chosen-select">
                                </asp:DropDownList>
                            </div>
                            <div class="widget-separator no-border grid-3" class="form form-full" style="margin-top: 29px;">
                                <asp:Button ID="btnSearch" runat="server" Text="Search"
                                    CssClass="btn btn-info" OnClick="btnSearch_OnClick" />
                            </div>



                            <div class="widget-body no-padding" style="line-height: 30px; font-size: 17px;">

                                <div class="grid-12">
                                    <%--       <div class="widget-separator grid-4">--%>
                                    <div class="grid-4 widget-separator">
                                        <div class="pull-left">
                                            <asp:Label ID="Label20" runat="server" BackColor="#0ABFBC" Text=" নং"></asp:Label>
                                        </div>
                                        <div class="pull-right modifyfont">
                                            <asp:Label ID="lblNo" CssClass="  form-control" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="grid-4" runat="server" visible="False">
                                        <div class="grid-4">
                                            <asp:Label ID="Label18" runat="server" BackColor="#0ABFBC" Text=" কিতাবের সিরিয়াল নং"></asp:Label>
                                        </div>
                                        <div class="pull-right modifyfont">
                                            <asp:Label ID="lblKitaberSerialNo" CssClass="  form-control" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="grid-4 widget-separator">
                                        <div class="grid-4">
                                            <asp:Label ID="Label19" runat="server" BackColor="#0ABFBC" Text=" আলমারি নং"></asp:Label>
                                        </div>
                                        <div class="pull-right modifyfont">
                                            <asp:Label ID="lblAlmariNo" CssClass="  form-control" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="grid-4 widget-separator">
                                        <div class="grid-4">
                                            <asp:Label ID="Label4" runat="server" BackColor="#0ABFBC" Text="তাক নং"></asp:Label>
                                        </div>
                                        <div class="pull-right modifyfont">
                                            <asp:Label ID="lblTakNo" CssClass="  form-control" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="grid-4 widget-separator">
                                        <div class="grid-4">
                                            <asp:Label ID="Label5" runat="server" BackColor="#0ABFBC" Text="কলাম নং"></asp:Label>
                                        </div>
                                        <div class="pull-right modifyfont">
                                            <asp:Label ID="lblKolamNo" CssClass="  form-control" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="grid-4 widget-separator">
                                        <div class="grid-4">
                                            <asp:Label ID="Label6" runat="server" BackColor="#0ABFBC" Text="কিতাব নং"></asp:Label>
                                        </div>
                                        <div class="pull-right modifyfont">
                                            <asp:Label ID="lblKitabNo" CssClass="  form-control" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="grid-4 widget-separator">
                                        <div class="grid-4">
                                            <asp:Label ID="Label7" runat="server" BackColor="#0ABFBC" Text="কপি সংখ্যা"></asp:Label>
                                        </div>
                                        <div class="pull-right modifyfont">
                                            <asp:Label ID="lblCopyNumber" CssClass="  form-control" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="grid-4 widget-separator">
                                        <div class="grid-4">
                                            <asp:Label ID="Label8" runat="server" BackColor="#0ABFBC" Text="মোট ভলিউম নং"></asp:Label>
                                        </div>
                                        <div class="pull-right modifyfont">
                                            <asp:Label ID="lblTotalVolume" CssClass="  form-control" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="grid-4 widget-separator">
                                        <div class="pull-left">
                                            <asp:Label ID="Label1" runat="server" BackColor="#0ABFBC" Text="ভলিউম নং"></asp:Label>
                                        </div>
                                        <div class="pull-right modifyfont">
                                            <asp:Label ID="lblVolumeNo" CssClass="  form-control" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="grid-4 widget-separator">
                                        <div class="pull-left">
                                            <asp:Label ID="Label9" runat="server" BackColor="#0ABFBC" Text="খণ্ড নং"></asp:Label>
                                        </div>
                                        <div class="pull-right modifyfont">
                                            <asp:Label ID="lblKhondoNo" CssClass="  form-control" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="grid-4 widget-separator">
                                        <div class="pull-left">
                                            <asp:Label ID="Label10" runat="server" BackColor="#0ABFBC" Text="পৃষ্ঠা সংখ্যা"></asp:Label>
                                        </div>
                                        <div class="pull-right modifyfont">
                                            <asp:Label ID="lblPageNo" CssClass="  form-control" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="grid-4 widget-separator">
                                        <div class="pull-left">
                                            <asp:Label ID="Label11" runat="server" BackColor="#0ABFBC" Text="মূল্য"></asp:Label>
                                        </div>
                                        <div class="pull-right modifyfont">
                                            <asp:Label ID="lblPrice" CssClass="  form-control" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="grid-4 widget-separator">
                                        <div class="pull-left">
                                            <asp:Label ID="Label25" runat="server" BackColor="#0ABFBC" Text="বিষয়"></asp:Label>
                                        </div>
                                        <div class="pull-right modifyfont">
                                            <asp:Label ID="lblSubject" CssClass="  form-control" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <%-- <div class="clearfix"></div>--%>

                                    <%-- </div>--%>

                                    <%--<div class="widget-separator grid-4">--%>
                                    <div class="grid-6 widget-separator">
                                        <div class="pull-left">
                                            <asp:Label ID="Label17" runat="server" BackColor="#0ABFBC" Text="কিতাবের মুল নাম"></asp:Label>
                                        </div>
                                        <div class="text-center modifyfont">
                                            <asp:Label ID="lblKitaberMainName" TextMode="MultiLine" CssClass="  form-control" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="grid-6 widget-separator ">
                                        <div class="pull-left">
                                            <asp:Label ID="Label2" runat="server" BackColor="#0ABFBC" Text="কিতাবের মাশহুর নাম"></asp:Label>
                                        </div>
                                        <div class="text-center modifyfont">
                                            <asp:Label ID="lblKitaberSpecialName" TextMode="MultiLine" CssClass="  form-control" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="grid-8 widget-separator">
                                        <div class="pull-left">
                                            <asp:Label ID="Label3" runat="server" BackColor="#0ABFBC" Text="লিখক"></asp:Label>
                                        </div>
                                        <div class="text-center modifyfont">
                                            <asp:Label ID="lblWritter" TextMode="MultiLine" CssClass="  form-control" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="grid-4 widget-separator">
                                        <div class="pull-left">
                                            <asp:Label ID="Label12" runat="server" BackColor="#0ABFBC" Text="লিখকের জন্ম সন"></asp:Label>
                                        </div>
                                        <div class="pull-right modifyfont">
                                            <asp:Label ID="lblWritterBornDate" CssClass="  form-control" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="grid-4 widget-separator">
                                        <div class="pull-left">
                                            <asp:Label ID="Label13" runat="server" BackColor="#0ABFBC" Text="লিখকের ইন্তিকাল"></asp:Label>
                                        </div>
                                        <div class="pull-right modifyfont">
                                            <asp:Label ID="lblWritterDeathDate" CssClass="  form-control" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="grid-4 widget-separator">
                                        <div class="pull-left">
                                            <asp:Label ID="Label14" runat="server" BackColor="#0ABFBC" Text="লিখকের মাজহাব"></asp:Label>
                                        </div>
                                        <div class="pull-right modifyfont">
                                            <asp:Label ID="lblWritterMajhab" CssClass="  form-control" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="grid-4 widget-separator">
                                        <div class="pull-left">
                                            <asp:Label ID="Label15" runat="server" BackColor="#0ABFBC" Text="সংকলক"></asp:Label>
                                        </div>
                                        <div class="pull-right modifyfont">
                                            <asp:Label ID="lblSongkolp" CssClass="  form-control" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="grid-4 widget-separator">
                                        <div class="pull-left">
                                            <asp:Label ID="Label16" runat="server" BackColor="#0ABFBC" Text="অনুবাদক"></asp:Label>
                                        </div>
                                        <div class="pull-right modifyfont">
                                            <asp:Label ID="lblTranslator" CssClass="  form-control" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="grid-4 widget-separator">
                                        <div class="pull-left">
                                            <asp:Label ID="Label21" runat="server" BackColor="#0ABFBC" Text="অনুবাদকের জন্ম ও ইন্তেকাল"></asp:Label>
                                        </div>
                                        <div class="pull-right modifyfont">
                                            <asp:Label ID="lblTranslatorsDate" CssClass="  form-control" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="grid-4 widget-separator">
                                        <div class="pull-left">
                                            <asp:Label ID="Label22" runat="server" BackColor="#0ABFBC" Text="অনুবাদকের মাজহাব"></asp:Label>
                                        </div>
                                        <div class="pull-right modifyfont">
                                            <asp:Label ID="lblTranslatorMajhab" CssClass="  form-control" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="grid-4 widget-separator">
                                        <div class="pull-left">
                                            <asp:Label ID="Label23" runat="server" BackColor="#0ABFBC" Text="কিতাবের মুল ভাষা "></asp:Label>
                                        </div>
                                        <div class="pull-right modifyfont">
                                            <asp:Label ID="lblMainLanguage" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                    <div class="grid-4 widget-separator">

                                        <div class="pull-left">
                                            <asp:Label ID="Label24" runat="server" BackColor="#0ABFBC" Text=" অনুদিত ভাষা"></asp:Label>
                                        </div>
                                        <div class="pull-right modifyfont">
                                            <asp:Label ID="lblTranslatedLanguage" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                    <%--   </div>--%>

                                    <%--          <div class="widget-separator grid-4" style="border-bottom: none;">--%>



                                    <div class="grid-4 widget-separator">
                                        <div class="pull-left">
                                            <asp:Label ID="Label26" runat="server" BackColor="#0ABFBC" Text="অদ্ধায়/পরিচ্ছেদ"></asp:Label>
                                        </div>
                                        <div class="pull-right modifyfont">
                                            <asp:Label ID="lblChapter" CssClass="  form-control" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="grid-8 widget-separator">
                                        <div class="pull-left">
                                            <asp:Label ID="Label27" runat="server" BackColor="#0ABFBC" Text="প্রকাশক"></asp:Label>
                                        </div>
                                        <div class="text-center modifyfont">
                                            <asp:Label ID="lblProkashok" CssClass="  form-control" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="grid-4 widget-separator">
                                        <div class="pull-left">
                                            <asp:Label ID="Label28" runat="server" BackColor="#0ABFBC" Text="প্রকাশকাল"></asp:Label>
                                        </div>
                                        <div class="pull-right modifyfont">
                                            <asp:Label ID="lblProkashkal" CssClass="  form-control" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="grid-4 widget-separator">
                                        <div class="pull-left">
                                            <asp:Label ID="Label29" runat="server" BackColor="#0ABFBC" Text="প্রকাশনী"></asp:Label>
                                        </div>
                                        <div class="pull-right modifyfont">
                                            <asp:Label ID="lblProkashoni" CssClass="  form-control" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="grid-4 widget-separator">
                                        <div class="pull-left">
                                            <asp:Label ID="Label30" runat="server" BackColor="#0ABFBC" Text="প্রকাশ স্থান"></asp:Label>
                                        </div>
                                        <div class="pull-right modifyfont">
                                            <asp:Label ID="lblProkashsthan" CssClass="  form-control" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="grid-4 widget-separator">
                                        <div class="pull-left">
                                            <asp:Label ID="Label31" runat="server" BackColor="#0ABFBC" Text="সম্পাদনা"></asp:Label>
                                        </div>
                                        <div class="pull-right modifyfont">
                                            <asp:Label ID="lblSompadona" CssClass="  form-control" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="grid-4 widget-separator">
                                        <div class="pull-left">
                                            <asp:Label ID="Label32" runat="server" BackColor="#0ABFBC" Text="সংস্করণ"></asp:Label>
                                        </div>
                                        <div class="pull-right modifyfont">
                                            <asp:Label ID="lblSongokoron" CssClass="  form-control" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="grid-4 widget-separator">
                                        <div class="pull-left">
                                            <asp:Label ID="Label33" runat="server" BackColor="#0ABFBC" Text="সার সংখেপ/সূচী"></asp:Label>
                                        </div>
                                        <div class="pull-right modifyfont">
                                            <asp:Label ID="lblSarSonkhep" TextMode="MultiLine" CssClass="  form-control" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="grid-4 widget-separator">
                                        <div class="pull-left">
                                            <asp:Label ID="Label34" runat="server" BackColor="#0ABFBC" Text="মন্তব্য"></asp:Label>
                                        </div>
                                        <div class="pull-right modifyfont">
                                            <asp:Label ID="lblComment" TextMode="MultiLine" CssClass="  form-control" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
            <%--</div>
            </div>--%>
        </ContentTemplate>

    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script>
        function pageLoad(sender, args) {
            $("#saveButton").click(function (e) {
                $("#ddlSearch").rules("add", {
                    required: true
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
            });
        }
    </script>
</asp:Content>
