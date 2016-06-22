<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true"
    CodeBehind="BackupDB.aspx.cs" Inherits="lmxIpos.UI.Backup.BackupDB" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headContentPlaceHolder" runat="server">
    <link href="/Content/Style/CSSPages/BackupDB.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <div id="body_content">
        <fieldset>
            <legend>Backup & Restore Database File</legend>
            <div id="msgbox" runat="server" visible="false" class="alert alert-error">
                <button type="button" class="close" data-dismiss="alert">
                    &times;</button>
                <h4>
                    <asp:Label ID="msgTitleLabel" runat="server" Text=""></asp:Label>
                </h4>
                <asp:Label ID="msgDetailLabel" runat="server" Text=""></asp:Label>
            </div>
            <div class="accordion" id="accordion2">
                <div class="accordion-group">
                    <div class="accordion-heading">
                        <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion2" href="#collapse1">
                            Backup Database File </a>
                    </div>
                    <div id="collapse1" class="accordion-body collapse">
                        <div class="accordion-inner">
                            <table id="collapse1Table1" class="inputControlContainer-accordion">
                                <tr>
                                    <td>
                                        <label>
                                            Database Name
                                        </label>
                                        <asp:DropDownList ID="dbNameDropDownList1" runat="server">
                                            <asp:ListItem Value="LumexDBConString">IPOS System</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td colspan="2">
                                        <asp:Button ID="backupButton" runat="server" CssClass="btn btn-primary" Text="Backup Database File"
                                            OnClick="backupButton_Click" />
                                        <asp:Button ID="clearBackupDirectoryButton" runat="server" CssClass="btn btn-danger clickProcessing"
                                            Text="Clear Backup Directory" OnClick="clearBackupDirectoryButton_Click" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
                <div class="accordion-group">
                    <div class="accordion-heading">
                        <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion2" href="#collapse2">
                            Restore Database File </a>
                    </div>
                    <div id="collapse2" class="accordion-body collapse">
                        <div class="accordion-inner">
                            <table id="collapse2Table1" class="inputControlContainer-accordion">
                                <tr>
                                    <td>
                                        <label>
                                            Database Name
                                        </label>
                                        <asp:DropDownList ID="dbNameDropDownList2" runat="server">
                                            <asp:ListItem Value="LumexDBConString">IPOS System</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td colspan="3">
                                        <asp:FileUpload ID="dbFileUpload" CssClass="btn" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" class="HRtd">
                                        &nbsp;
                                        <hr class="HRtr" />
                                    </td>
                                </tr>
                            </table>
                            <div>
                                <asp:Button ID="restoreButton" runat="server" CssClass="btn btn-primary" Text="Restore Database File"
                                    OnClick="restoreButton_Click" />
                                <asp:Button ID="clearRestoreDirectoryButton" runat="server" CssClass="btn btn-danger clickProcessing"
                                    Text="Clear Restore Directory" OnClick="clearRestoreDirectoryButton_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </fieldset>
    </div>
    <asp:HiddenField ID="selectedAccordionIdHiddenField" runat="server" />
</asp:Content>
<asp:Content ID="scriptContent" ContentPlaceHolderID="scriptContentPlaceHolder" runat="server">
    <script src="/Scripts/bootstrap.file-input.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $('#dbFileUpload').bootstrapFileInput();

            $(".accordion-toggle").click(function () {
                $("#selectedAccordionIdHiddenField").val($(this).attr("href"));
                $(".accordion-toggle").each(function () {
                    $(this).removeClass("in");
                });
            });

            $($("#selectedAccordionIdHiddenField").val()).addClass("in");

            $("#restoreButton").click(function () {
                $("#dbFileUpload").rules("add", {
                    required: true
                });
            });

            $("#clearRestoreDirectoryButton, #clearBackupDirectoryButton, #backupButton").click(function () {
                $("#dbFileUpload").rules("remove");
            });

            $(".clickProcessing").live("click", function () {
                if (haveOverlay == 0) {
                    MyOverlayStart();
                }
            });
        });
    </script>
</asp:Content>
