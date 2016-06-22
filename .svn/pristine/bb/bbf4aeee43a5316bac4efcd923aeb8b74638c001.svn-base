<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="lmxIpos.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login | IPOS System</title>
    <link rel="icon" type="image/png" href="/content/images/lmx-favicon.png">
    <link rel="Stylesheet" type="text/css" href="/content/css/AppStyle.css" />
    <link rel="stylesheet" type="text/css" href="/content/css/style-min.css">
    <link rel="stylesheet" type="text/css" href="/content/css/bootstrap.min.css">
    <link rel="stylesheet" type="text/css" href="/content/css/bootstrap-responsive.min.css">
    <link href="/content/css/bootstrap-datepicker.min.css" rel="stylesheet" type="text/css" />
    <link href="/content/theme/css/fonts.css" rel="stylesheet" type="text/css" />
    <link href="/content/theme/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="/scripts/highlight.js/styles/github.css" type="text/css">
    <link href="/content/css/AlertBox.css" rel="stylesheet" type="text/css" />
    <script src="/scripts/jquery-2.0.3.min.js" type="text/javascript"></script>
    <script src="/scripts/jquery-migrate/jquery-migrate-1.0.0.js" type="text/javascript"></script>
    <script src="/scripts/acura.js" type="text/javascript"></script>
    <script src="/scripts/tipsy/jquery.tipsy.js" type="text/javascript"></script>
    <link href="/scripts/tipsy/tipsy.css" rel="stylesheet" type="text/css">
    <script src="/scripts/maskedinput/jquery.maskedinput.min.js" type="text/javascript"></script>
    <script src="/scripts/autosize/jquery.autosize.min.js" type="text/javascript"></script>
    <script src="/scripts/nobleCount/jquery.NobleCount.min.js" type="text/javascript"></script>
    <link rel="stylesheet" href="/scripts/uniform/theme/css/uniform.default.min.css">
    <script src="/scripts/uniform/jquery.uniform.min.js" type="text/javascript"></script>
    <script src="/scripts/jquery-ui-1.10.3/js/jquery-ui-1.10.3.custom.min.js" type="text/javascript"></script>
    <link rel="stylesheet" href="/Scripts/jquery-ui-1.10.3/css/no-theme/jquery-ui-1.10.3.custom.css">
    <script src="/scripts/tagsinput/jquery.tagsinput.min.js"></script>
    <link rel="stylesheet" href="/Scripts/tagsinput/jquery.tagsinput.css">
    <script src="/scripts/colResizable/colResizable-1.3.js"></script>
    <link href="/Content/DataTables-1.9.4/media/css/jquery.dataTables.css" rel="stylesheet"
        type="text/css" />
    <script src="/scripts/DataTables-1.9.4/media/js/jquery.dataTables.min.js" type="text/javascript"></script>
    <script src="/scripts/fullcalendar/fullcalendar.min.js"></script>
    <link rel="stylesheet" href="/Scripts/fullcalendar/fullcalendar.css">
    <script src="/scripts/jquery-knob/jquery.knob.js"></script>
    <script src="/scripts/bxSlider/jquery.bxslider.min.js"></script>
    <link href="/scripts/bxSlider/jquery.bxslider.css" rel="stylesheet">
    <link rel="stylesheet" href="/scripts/circleSlider/css/website.css" />
    <script src="/scripts/circleSlider/js/jquery.tinycircleslider.min.js"></script>
    <script src="/Scripts/bootstrap.min.js" type="text/javascript"></script>
    <script src="/Scripts/bootstrap-datepicker.min.js" type="text/javascript"></script>
    <%--<script src="/Scripts/JSLib.js" type="text/javascript"></script>--%>
    <script src="/Scripts/PasswordStrength.js" type="text/javascript"></script>
</head>
<body class="login-bg">
    <form id="form1" runat="server">
        <div class="login-widget login-login">
            <header class="login-header">
            <a href="/Login.aspx">
                <img src="/Content/Images/lmx-logo.png" alt="LumexTech IPOS System">
            </a>
        </header>
            <h4 class="typo login-title">Login
            </h4>
            <div class="form-separator form-field">
                <div class="field-icon field-icon-left">
                    <i class="i">&#xf011;</i>
                    <asp:TextBox ID="txtbxUserName" required="required" placeholder="Username" class="form form-full"
                        runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="form-separator form-field">
                <div class="field-icon field-icon-left">
                    <%--<i class="i">&#xf023;</i>--%>
                    <i class="icon-key"></i>
                    <asp:TextBox ID="txtbxPass" required="required" TextMode="Password" placeholder="Password"
                        class="form form-full" runat="server"></asp:TextBox>
                </div>
            </div>
            <div style="margin-left: 20px;">
                <asp:Label ID="lblnotify" runat="server" ForeColor="Red" Font-Size="Small" Text=""></asp:Label>
            </div>
            <div class="login-submit">
                <asp:Button ID="btnlogin" runat="server" class="btn btn-submit" Text="Login" OnClick="btnlogin_Click" />
            </div>
            <footer class="login-footer">
      © 2014. Developed by <a href="http://www.lumextech.com" target="_blank">LumexTech Solutions Ltd.</a>
    </footer>
            <%--<div class="row-fluid text-center">
                <a id="btndemo" href="#currentdetail" role="button" class="btn-large btn btn-warning"
                    data-toggle="modal">Request to Get Your Access!!</a>
            </div>--%>
        </div>
        <%--<div class="row-fluid">
            <div id="currentdetail" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
                aria-hidden="true">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        ×</button>
                    <h3>Get Accessibility</h3>
                </div>
                <div class="modal-body">
                    <div class="container-fluid">
                        <div class="span6 text-left">
                            <div id="ModalSideBar" class="row-fluid">
                                <h4>Inventory Management System Project consist all information about Sales and inventory.
                                </h4>
                                <br />
                                <a href="http://lumextech.com/page/25/ipos" target="_blank" role="button" class="btn-large tn btn-info">How Manage your Business?</a>
                            </div>
                        </div>
                        <div class="span6">
                            <div id="loadingImg">
                            </div>
                            <div id="processSuccess">
                                <p class="text-success text-center labltext">
                                    <asp:Label ID="successMessageLabel" runat="server" Text="Success"></asp:Label>
                                </p>
                            </div>
                            <div id="divMessageBody">
                                <div class="row-fluid">
                                    <div>
                                        Name
                                    </div>
                                    <div>
                                        <asp:TextBox ID="txtbxName" runat="server" placeholder="Name" ValidationGroup="v1"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row-fluid">
                                    <div>
                                        Company Name
                                    </div>
                                    <div>
                                        <asp:TextBox ID="txtbxCompanyName" runat="server" placeholder="Company Name" ValidationGroup="v1"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row-fluid">
                                    <div>
                                        Contact
                                    </div>
                                    <div>
                                        <asp:TextBox ID="txtbxContact" runat="server" placeholder="Email,Cell and Address"
                                            ValidationGroup="v1"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row-fluid">
                                    <div>
                                        Messeage
                                    </div>
                                    <div>
                                        <asp:TextBox ID="txtbxMassage" runat="server" TextMode="MultiLine" ValidationGroup="v1"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row-fluid">
                                    <asp:Button ID="btnSend" runat="server" Text="Send Please.." CssClass="btn btn-success"
                                        ValidationGroup="v1" OnClientClick="return false;" />
                                    
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">
                        Close</button>
                </div>
            </div>
        </div>--%>
    </form>
    <script type="text/javascript">
        $(function () {

            $("#loadingImg").hide();
            $("#processSuccess").hide();
            //            blink('#btndemo');
            $("#btnSend").click(function () {
                var name = $("#txtbxName").val();
                var companyName = $("#txtbxCompanyName").val();
                var contact = $("#txtbxContact").val();
                var message = $("#txtbxMassage").val();

                $("#divMessageBody").hide();
                $("#loadingImg").show();

                $.ajax({
                    type: "POST",
                    url: "/Login.aspx/GetDemoAccessibility",
                    data: "{'name':'" + name + "','companyName':'" + companyName + "','contact':'" + contact + "','message':'" + message + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        var val = data.d;
                        $("#loadingImg").hide();

                        if (val == "Done") {
                            $("#processSuccess").show();
                            $("#successMessageLabel").text("Request Send Succesfully...");
                        } else if (val == "Not Done") {
                            $("#divMessageBody").show();
                            alert("failed");
                        }
                        else if (val == "Please Fill all TextBox..") {
                            $("#divMessageBody").show();
                            alert(val);
                        }

                    }
                });
            });
        });
        //        function blink(e) {
        //            $(e).fadeOut('slow', function () {
        //                $(this).fadeIn('slow', function () {
        //                    blink(this);
        //                });
        //            });
        //        }
    </script>
</body>
</html>
