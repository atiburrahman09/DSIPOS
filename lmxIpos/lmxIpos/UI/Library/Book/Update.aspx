﻿<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true" CodeBehind="Update.aspx.cs" EnableEventValidation="false" Inherits="lmxIpos.UI.Book.Update" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="Conditional" ChildrenAsTriggers="true">
        <ContentTemplate>
            <div class="data">
                <div class="grid-12">
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
                    <h3 id="Header3" runat="server" class="widget-header-title">Add New Book</h3>
                </header>

                <div class="widget-body no-padding">



                    <div class="widget-separator no-border grid-3">
                        <h5 class="typo"><span>কিতাবের সিরিয়াল নং</span><span class="text-error">*</span></h5>
                        <asp:TextBox ID="txtbxKitaberSerialNo" CssClass="  form form-full" runat="server" required="required"></asp:TextBox>
                    </div>
                    <div class="widget-separator no-border grid-3">
                        <h5 class="typo"><span>আলমারি নং</span></h5>
                        <asp:TextBox ID="txtbxAlmariNo" CssClass="  form form-full" runat="server"></asp:TextBox>
                    </div>
                    <div class="widget-separator no-border grid-3">
                        <h5 class="typo"><span>তাক নং</span></h5>
                        <asp:TextBox ID="txtbxTakNo" CssClass="  form form-full" runat="server"></asp:TextBox>
                    </div>


                    <div class="widget-separator no-border grid-3">
                        <h5 class="typo"><span>কলাম নং</span></h5>
                        <asp:TextBox ID="txtbxKolamNo" CssClass="  form form-full" runat="server"></asp:TextBox>
                    </div>
                    <div class="widget-separator no-border grid-3">
                        <h5 class="typo"><span>কিতাব নং</span></h5>
                        <asp:TextBox ID="txtbxKitabNo" CssClass="  form form-full" runat="server"></asp:TextBox>
                    </div>
                    <div class="widget-separator no-border grid-3">
                        <h5 class="typo"><span>কপি সংখ্যা</span></h5>
                        <asp:TextBox ID="txtbxCopyNumber" CssClass="  form form-full" runat="server"></asp:TextBox>
                    </div>
                    <div class="widget-separator no-border grid-3">
                        <h5 class="typo"><span>মোট ভলিউম নং</span></h5>
                        <asp:TextBox ID="txtbxTotalVolume" CssClass="  form form-full" runat="server"></asp:TextBox>
                    </div>
                    <div class="widget-separator no-border grid-3">
                        <h5 class="typo"><span>ভলিউম নং</span></h5>
                        <asp:TextBox ID="txtbxVolumeNo" CssClass="  form form-full" runat="server"></asp:TextBox>
                    </div>
                    <div class="widget-separator no-border grid-3">
                        <h5 class="typo"><span>খণ্ড নং</span></h5>
                        <asp:TextBox ID="txtbxKhondoNo" CssClass="  form form-full" runat="server"></asp:TextBox>
                    </div>
                    <div class="widget-separator no-border grid-3">
                        <h5 class="typo"><span>পৃষ্ঠা সংখ্যা</span></h5>
                        <asp:TextBox ID="txtbxPageNo" CssClass="  form form-full" runat="server"></asp:TextBox>
                    </div>
                    <div class="widget-separator no-border grid-3">
                        <h5 class="typo"><span>অদ্ধায়/পরিচ্ছেদ</span></h5>
                        <asp:TextBox ID="txtbxChapter" CssClass="  form form-full" runat="server"></asp:TextBox>
                    </div>
                    <div class="widget-separator no-border grid-3">
                        <h5 class="typo"><span>মূল্য</span></h5>
                        <asp:TextBox ID="txtbxPrice" CssClass="  form form-full" runat="server"></asp:TextBox>
                    </div>
                    <div class="widget-separator no-border grid-3">
                        <h5 class="typo"><span>বিষয়</span></h5>
                        <asp:TextBox ID="txtbxSubject" CssClass="  form form-full" runat="server"></asp:TextBox>
                    </div>
                    <div class="widget-separator no-border grid-6">
                        <h5 class="typo"><span>কিতাবের মুল নাম</span><span class="text-error">*</span></h5>
                        <asp:TextBox ID="txtbxKitaberMainName" CssClass="form form-full" runat="server" required="required"></asp:TextBox>
                    </div>

                    <div class="widget-separator no-border grid-6">
                        <h5 class="typo"><span>কিতাবের মাশহুর নাম</span></h5>
                        <asp:TextBox ID="txtbxKitaberSpecialName" CssClass="  form form-full" runat="server"></asp:TextBox>
                    </div>

                    <div class="widget-separator no-border grid-3">
                        <h5 class="typo"><span>কিতাবের মুল ভাষা </span></h5>
                        <asp:DropDownList ID="mainLanguageDropDownList" required="required" runat="server" CssClass="form form-full">
                        </asp:DropDownList>
                    </div>

                    <div class="widget-separator no-border grid-3">
                        <h5 class="typo"><span>অনুদিত ভাষা</span></h5>
                        <asp:DropDownList ID="translatedLanguageDropDownList" required="required" runat="server" CssClass="form form-full">
                        </asp:DropDownList>
                    </div>

                    <div class="widget-separator no-border grid-3">
                        <h5 class="typo"><span>লিখক</span><span class="text-error">*</span></h5>
                        <asp:TextBox ID="txtbxWritter" CssClass="  form form-full" runat="server" required="required"></asp:TextBox>
                    </div>

                    <div class="widget-separator no-border grid-3">
                        <h5 class="typo"><span>লিখকের জন্ম সন</span></h5>
                        <asp:TextBox ID="txtbxWritterBornDate" CssClass="  form form-full" runat="server"></asp:TextBox>
                    </div>
                    <div class="widget-separator no-border grid-3">
                        <h5 class="typo"><span>লিখকের ইন্তিকাল</span></h5>
                        <asp:TextBox ID="txtbxWritterDeathDate" CssClass="  form form-full" runat="server"></asp:TextBox>
                    </div>
                    <div class="widget-separator no-border grid-3">
                        <h5 class="typo"><span>লিখকের মাজহাব</span></h5>
                        <asp:TextBox ID="txtbxWritterMajhab" CssClass="  form form-full" runat="server"></asp:TextBox>
                    </div>
                    <div class="widget-separator no-border grid-3">
                        <h5 class="typo"><span>অনুবাদক</span></h5>
                        <asp:TextBox ID="txtbxTranslator" CssClass="  form form-full" runat="server"></asp:TextBox>
                    </div>


                    <div class="widget-separator no-border grid-3">
                        <h5 class="typo"><span>অনুবাদকের জন্ম ও ইন্তেকাল</span></h5>
                        <asp:TextBox ID="txtbxTranslatorsDate" CssClass="  form form-full" runat="server"></asp:TextBox>
                    </div>
                    <div class="widget-separator no-border grid-3">
                        <h5 class="typo"><span>অনুবাদকের মাজহাব</span></h5>
                        <asp:TextBox ID="txtbxTranslatorMajhab" CssClass="  form form-full" runat="server"></asp:TextBox>
                    </div>
                    <div class="widget-separator no-border grid-3">
                        <h5 class="typo"><span>প্রকাশক</span></h5>
                        <asp:TextBox ID="txtbxProkashok" CssClass="  form form-full" runat="server"></asp:TextBox>

                    </div>
                    <div class="widget-separator no-border grid-3">
                        <h5 class="typo"><span>প্রকাশকাল</span></h5>
                        <asp:TextBox ID="txtbxProkashkal" CssClass="  form form-full" runat="server"></asp:TextBox>
                    </div>
                    <div class="widget-separator no-border grid-3">
                        <h5 class="typo"><span>প্রকাশনী</span></h5>
                        <asp:TextBox ID="txtbxProkashoni" CssClass="  form form-full" runat="server"></asp:TextBox>
                    </div>


                    <div class="widget-separator no-border grid-3">
                        <h5 class="typo"><span>প্রকাশ স্থান</span></h5>
                        <asp:TextBox ID="txtbxProkashsthan" CssClass="  form form-full" runat="server"></asp:TextBox>
                    </div>
                    <div class="widget-separator no-border grid-3">
                        <h5 class="typo"><span>সংকলক</span></h5>
                        <asp:TextBox ID="txtbxSongkolp" CssClass="  form form-full" runat="server"></asp:TextBox>
                    </div>



                    <div class="widget-separator no-border grid-3">
                        <h5 class="typo"><span>সম্পাদনা</span></h5>
                        <asp:TextBox ID="txtbxSompadona" CssClass="  form form-full" runat="server"></asp:TextBox>
                    </div>



                    <div class="widget-separator no-border grid-3">
                        <h5 class="typo"><span>সংস্করণ</span></h5>
                        <asp:TextBox ID="txtbxSongokoron" CssClass="  form form-full" runat="server"></asp:TextBox>
                    </div>


                    <div class="widget-separator no-border grid-6">
                        <h5 class="typo"><span>সার সংখেপ/সূচী</span></h5>
                        <asp:TextBox ID="txtbxSarSonkhep" CssClass="  form form-full" runat="server"></asp:TextBox>
                    </div>
                    <div class="widget-separator no-border grid-6">
                        <h5 class="typo"><span>মন্তব্য</span></h5>
                        <asp:TextBox ID="txtbxComment" CssClass="  form form-full" runat="server"></asp:TextBox>
                    </div>

                </div>
                <div class="row form form-full text-center">
                    <asp:Button ID="btnSave" CssClass="btn btn-info" runat="server" Text="Save" OnClick="btnSave_OnClick" />
                </div>
            </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
</asp:Content>
