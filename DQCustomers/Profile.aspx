<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" ValidateRequest="false" CodeBehind="Profile.aspx.cs" Inherits="DQCustomers.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <%--<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />--%>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script type="text/javascript" src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    
    <script type="text/javascript">
        function showAndDismissAlert(type, message) {
            var htmlAlert = '<div class="alert alert-' + type + '">' + message + '</div>';
            $(".alert-messages").prepend(htmlAlert);
            $(".alert-messages .alert").first().hide().fadeIn(200).delay(2000).fadeOut(1000, function () { $(this).remove(); });
        }
    </script>
    <!-- Hero Section Begin -->
    <style type="text/css">
        .messagealert {
            width: 100%;
            position: fixed;
             top:0px;
            z-index: 100000;
            padding: 0;
            font-size: 15px;
        }
    </style>

    <div class="container">
         <div class="alert-messages text-center">
        </div>
        <div class="row">
            <div class="col-lg-3">
                <div class="hero__categories">
                    <div class="hero__categories__all">
                        <i class="fa fa-bars"></i>
                        <span>Danh mục</span>
                    </div>
                    <ul>
                        <li class="active1"><a href="Profile">Thông tin khách hàng</a></li>
                        <li>
                            <a href="List" class="">Sản phẩm đã scan</a>
                        </li>
                       <%-- <li>
                            <a href="List" class="cssChild"><i class="fa fa-barcode"></i>&nbsp;&nbsp;Đã scan</a>
                        </li>--%>
                        <%--<li>
                            <a href="#" class="cssChild"><i class="fa fa-gg"></i>&nbsp;&nbsp;Đã yêu cầu bảo hành</a>
                        </li>--%>
                    </ul>
                </div>
            </div>
            <div class="col-lg-9 col-md-9">
                <div class="input-group col-lg-8 mb-3">
                    <div class="input-group-prepend">
                        <span class="input-group-text bg-white px-4 border-md border-right-0">
                            <i class="fa fa-user text-danger"></i>
                        </span>
                    </div>
                    <asp:TextBox ID="txtHoTen" runat="server" ValidationGroup="cn" placeholder="Họ và tên" CssClass="form-control bg-white border-left-0 border-md"></asp:TextBox>
                </div>
                <div class="input-group col-lg-8 mb-3">
                    <div class="input-group-prepend">
                        <span class="input-group-text bg-white px-4 border-md border-right-0">
                            <i class="fa fa-phone text-danger"></i>
                        </span>
                    </div>
                    <asp:TextBox ID="txtDienThoai" runat="server" ValidationGroup="cn" placeholder="Điện thoại" CssClass="form-control bg-white border-left-0 border-md"></asp:TextBox>
                </div>
                <div class="input-group col-lg-8 mb-3">
                    <div class="input-group-prepend">
                        <span class="input-group-text bg-white px-4 border-md border-right-0">
                            <i class="fa fa-envelope-open text-danger"></i>
                        </span>
                    </div>
                    <asp:TextBox ID="txtEmail" runat="server" ValidationGroup="cn" placeholder="Email" CssClass="form-control bg-white border-left-0 border-md"></asp:TextBox>
                </div>
                <div class="input-group col-lg-8 mb-3">
                    <div class="input-group-prepend">
                        <span class="input-group-text bg-white px-4 border-md border-right-0">
                            <i class="fa fa-map-marker text-danger"></i>
                        </span>
                    </div>
                    <asp:TextBox ID="txtDiaChi" runat="server" ValidationGroup="cn" placeholder="Địa chỉ" CssClass="form-control bg-white border-left-0 border-md"></asp:TextBox>
                </div>
                <div class="input-group col-lg-8 mb-3">
                    <div class="input-group-prepend">
                        <span class="input-group-text bg-white px-4 border-md border-right-0">
                            <i class="fa fa-unlock-alt text-danger"></i>
                        </span>
                    </div>
                    <asp:TextBox ID="txtMatKhau1" runat="server" ValidationGroup="cn" TextMode="Password"  placeholder="Mật khẩu" CssClass="form-control bg-white border-left-0 border-md"></asp:TextBox>
                </div>
                <div class="input-group col-lg-8 mb-3">
                    <div class="input-group-prepend">
                        <span class="input-group-text bg-white px-4 border-md border-right-0">
                            <i class="fa fa-unlock-alt text-danger"></i>
                        </span>
                    </div>
                    <asp:TextBox ID="txtNhapLaiMK" runat="server" ValidationGroup="cn" TextMode="Password" placeholder="Nhập lại mật khẩu" CssClass="form-control bg-white border-left-0 border-md"></asp:TextBox>
                </div>
                <div class="input-group col-lg-8 mt-4">
                    <div class="row" style="width: 100%; padding: 0px !important; margin: 0px !important;">
                        <asp:Label ID="lblMess" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div class="input-group col-lg-8 mt-4">
                    <div class="row" style="width: 100%; padding: 0px !important; margin: 0px !important;">

                        <div class="col-md-6 text-left button-register" style="padding: 0px!important;">
                            <button type="button" style="width: 95%" class="btn btn-outline-secondary bg-white text-dark button-width100">Hủy</button>
                        </div>
                        <div class="col-md-6 text-right button-register" style="padding: 0px!important;">
                            <asp:Button ID="btnLuu" OnClick="btnLuu_Click" ValidationGroup="cn" runat="server" CssClass="btn btn-danger button-width100" Text="Lưu" />

                            <asp:RequiredFieldValidator ID="rq1" runat="server" ControlToValidate="txtHoTen" ValidationGroup="cn" ErrorMessage="Vui lòng nhập Họ và tên" SetFocusOnError="true" Display="None"></asp:RequiredFieldValidator>
                            <asp:RequiredFieldValidator ID="rq2" runat="server" ControlToValidate="txtDienThoai" ValidationGroup="cn" ErrorMessage="Vui lòng nhận Điện thoại" SetFocusOnError="true" Display="None"></asp:RequiredFieldValidator>
                            <asp:RequiredFieldValidator ID="rq3" runat="server" ControlToValidate="txtEmail" ValidationGroup="cn" ErrorMessage="Vui lòng nhập Email" SetFocusOnError="true" Display="None"></asp:RequiredFieldValidator>
                            <asp:RequiredFieldValidator ID="rq4" runat="server" ControlToValidate="txtDiaChi" ValidationGroup="cn" ErrorMessage="Vui lòng nhập Địa chỉ" SetFocusOnError="true" Display="None"></asp:RequiredFieldValidator>

                            <asp:CompareValidator ID="cp1" runat="server" ControlToCompare="txtMatKhau1" ControlToValidate="txtNhapLaiMK" ValidationGroup="cn" ErrorMessage="Nhập lại mật khẩu chưa đúng" Display="None"></asp:CompareValidator>
                            <asp:ValidationSummary ID="ValidationSummary1" ValidationGroup="cn" ShowMessageBox="true" ShowSummary="false" runat="server" />


                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>

    <!-- Hero Section End -->
   
</asp:Content>
