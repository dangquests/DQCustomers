<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="DQCustomers.Test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title></title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script type="text/javascript" src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <script type="text/javascript">
        function ShowMessage(message, messagetype) {
            var cssclass;
            switch (messagetype) {
                case 'Success':
                    cssclass = 'alert-success'
                    break;
                case 'Error':
                    cssclass = 'alert-danger'
                    break;
                case 'Warning':
                    cssclass = 'alert-warning'
                    break;
                default:
                    cssclass = 'alert-info'
            }
            $('body').append('<div id="alert_div" style="margin: 0;position: absolute;top: 50px;left: 10%;-ms-transform: translateY(-50%);transform: translateY(-50%);display: none;width: 80%" class="alert fade in ' + cssclass + ' text-center"><a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a><strong>' + messagetype + '!</strong> <span>' + message + '</span></div>');
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
         <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpPanel" runat="server">
        <ContentTemplate>
            &nbsp;&nbsp;<asp:Button ID="btnSucess" runat="server" Text="Sucess" CssClass="btn btn-success" />
            &nbsp;&nbsp;<asp:Button ID="btnError" runat="server" Text="Error" CssClass="btn btn-danger" />
            &nbsp;&nbsp;<asp:Button ID="btnWarning" runat="server" Text="Warning" CssClass="btn btn-warning" />
            &nbsp;&nbsp;<asp:Button ID="btnInfo" runat="server" Text="Info" CssClass="btn btn-info" />
            <br />
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">
        $(function () {
            ButtonclickEvent();
        });
        function ButtonclickEvent() {
            $('#alert_div').show()
            $("[id*=btnSucess]").on("click", function () {
                ShowMessage("Record submitted successfully", "Success");
            });
            $("[id*=btnError]").on("click", function () {
                ShowMessage("A problem has occurred while submitting data", "Error");
            });

            $("[id*=btnWarning]").on("click", function () {
                ShowMessage("A problem has occurred while submitting data", "Warning");
            });

            $("[id*=btnInfo]").on("click", function () {
                ShowMessage("Please verify your data before submitting", "Info");
            });
        }
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        if (prm != null) {
            prm.add_endRequest(function (sender, e) {
                if (sender._postBackSettings.panelsToUpdate != null) {
                    ButtonclickEvent();
                }
            });
        };
    </script>
    </form>
</body>
</html>
