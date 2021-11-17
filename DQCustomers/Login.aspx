<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" ValidateRequest="false" Inherits="DQCustomers.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Đăng nhập-Đăng ký</title>
    <!-- Google Font -->
    <link href="https://fonts.googleapis.com/css2?family=Cairo:wght@200;300;400;600;900&display=swap" rel="stylesheet" />

    <!-- Css Styles -->
    <link rel="stylesheet" href="Content/css/bootstrap.min.css" type="text/css" />
    <link rel="stylesheet" href="Content/css/font-awesome.min.css" type="text/css" />
    <link rel="stylesheet" href="Content/css/elegant-icons.css" type="text/css" />
    <link rel="stylesheet" href="Content/css/nice-select.css" type="text/css" />
    <link rel="stylesheet" href="Content/css/jquery-ui.min.css" type="text/css" />
    <link rel="stylesheet" href="Content/css/owl.carousel.min.css" type="text/css" />
    <link rel="stylesheet" href="Content/css/slicknav.min.css" type="text/css" />
    <link rel="stylesheet" href="Content/css/style.css" type="text/css" />
    <link href="Content/css/custom.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
       <div class="demo-wrap">
        <img class="demo-bg" src="Content/img/bgDienQuang.png" alt="" />

        <!-- Hero Section Begin -->
        <section class="hero">
            <div class="container">

                <div class="row">
                    <div class="col-md-5 offset-md-6 bg-formDK">
                        <ul class="nav nav-pills mb-3 row" id="pills-tab" role="tablist">
                            <li class="nav-item col-md-6 text-right">
                                <a class="nav-link active" id="pills-home-tab" data-toggle="pill" href="#pills-home" role="tab" aria-controls="pills-home" aria-selected="true">Đăng nhập</a>
                            </li>
                            <li class="nav-item col-md-6">
                                <a class="nav-link" id="pills-profile-tab" data-toggle="pill" href="#pills-profile" role="tab" aria-controls="pills-profile" aria-selected="false">Đăng ký</a>
                            </li>
                        </ul>
                        <div class="tab-content" id="pills-tabContent">
                            <!--Đăng nhập-->
                            <div class="tab-pane fade show active" id="pills-home" role="tabpanel" aria-labelledby="pills-home-tab">
                                <div class="input-group col-lg-12 mb-3">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text bg-white px-4 border-md border-right-0">
                                            <i class="fa fa-envelope text-danger"></i>
                                        </span>
                                    </div>
                                    <asp:TextBox ID="txtEmailDN" ValidationGroup="dn" placeholder="Email" CssClass="form-control bg-white border-left-0 border-md" runat="server"></asp:TextBox>
                                </div>

                                <div class="input-group col-lg-12 mb-3">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text bg-white px-4 border-md border-right-0">
                                            <i class="fa fa-unlock-alt text-danger"></i>
                                        </span>
                                    </div>
                                    <asp:TextBox ID="txtMatKhauDN" ValidationGroup="dn" runat="server" TextMode="Password" placeholder="Mật khẩu" CssClass="form-control bg-white border-left-0 border-md"></asp:TextBox>
                                    <button type="button" class="fa fa-eye" style="margin-left: -30px;border:0px;z-index:100;height:30px; background-color: transparent;" id="togglePassword" onclick="myFunction()" cursor: pointer;"></button>
                                </div>
                                <div class="input-group col-lg-12 mb-3">
                                    <div class="row" style=" width: 100%; padding: 0px !important; margin: 0px !important;">
                                        <div class="col-md-6 text-left button-register" style="padding:0px!important;">
                                            <div class="checkout__input__checkbox">
                                                <label for="acc-or">
                                                    Ghi nhớ đăng nhập
                                                    <input type="checkbox" id="acc-or" />
                                                    <span class="checkmark"></span>
                                                </label>
                                            </div>
                                        </div>
                                        <div class="col-md-6 text-right button-register" style="padding:0px!important;">
                                            <a href="#">Quên mật khẩu?</a>
                                        </div>
                                    </div>
                                </div>

                                <div class="input-group col-lg-12 mt-4">
                                    <div class="row" style=" width: 100%; padding: 0px !important; margin: 0px !important;">
                                        <asp:Label ID="lblMessDN" runat="server" CssClass="text-danger" Text=""></asp:Label>
                                        <asp:Button ID="btnLogin" ValidationGroup="dn" OnClick="btnLogin_Click" CssClass="btn btn-danger button-width100" runat="server" Text="ĐĂNG NHẬP" />

                                        <asp:RequiredFieldValidator ID="rqdn1" ControlToValidate="txtEmailDN" ValidationGroup="dn" SetFocusOnError="true" runat="server" ErrorMessage="Vui lòng nhập Email" Display="None"></asp:RequiredFieldValidator>
                                        <asp:RequiredFieldValidator ID="rqdn2" ControlToValidate="txtMatKhauDN" ValidationGroup="dn" SetFocusOnError="true" runat="server" ErrorMessage="Vui lòng nhập Mật khẩu" Display="None"></asp:RequiredFieldValidator>
                                        <asp:ValidationSummary ID="ValidationSummary1" ValidationGroup="dn" ShowMessageBox="true" ShowSummary="false" runat="server" />
                                    </div>
                                </div>
                            </div>

                            <!--END Đăng nhập-->
                            <!--Đăng ký-->
                            <div class="tab-pane fade" id="pills-profile" role="tabpanel" aria-labelledby="pills-profile-tab">

                                <div class="input-group col-lg-12 mb-3">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text bg-white px-4 border-md border-right-0">
                                            <i class="fa fa-envelope text-danger"></i>
                                        </span>
                                    </div>
                                    <asp:TextBox ID="txtEmailDK" ValidationGroup="dk" runat="server" placeholder="Email" CssClass="form-control bg-white border-left-0 border-md"></asp:TextBox>
                                </div>
                                <div class="input-group col-lg-12 mb-3">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text bg-white px-4 border-md border-right-0">
                                            <i class="fa fa-user text-danger"></i>
                                        </span>
                                    </div>
                                     <asp:TextBox ID="txtHoTenDK" ValidationGroup="dk" runat="server" placeholder="Họ và tên" CssClass="form-control bg-white border-left-0 border-md"></asp:TextBox>
                                </div>
                                <div class="input-group col-lg-12 mb-3">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text bg-white px-4 border-md border-right-0">
                                            <i class="fa fa-phone text-danger"></i>
                                        </span>
                                    </div>
                                    <asp:TextBox ID="txtDienThoaiDK" ValidationGroup="dk" runat="server" placeholder="Điện thoại" CssClass="form-control bg-white border-left-0 border-md"></asp:TextBox>
                                </div>
                                <div class="input-group col-lg-12 mb-3">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text bg-white px-4 border-md border-right-0">
                                            <i class="fa fa-unlock-alt text-danger"></i>
                                        </span>
                                    </div>
                                    <asp:TextBox ID="txtMatKhauDK" ValidationGroup="dk" runat="server" TextMode="Password" placeholder="Mật khẩu" CssClass="form-control bg-white border-left-0 border-md"></asp:TextBox>
                                </div>
                                <div class="input-group col-lg-12 mb-4">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text bg-white px-4 border-md border-right-0">
                                            <i class="fa fa-unlock-alt text-danger"></i>
                                        </span>
                                    </div>
                                     <asp:TextBox ID="txtNhapLaiMKDK" ValidationGroup="dk" runat="server" TextMode="Password" placeholder="Nhập lại mật khẩu" CssClass="form-control bg-white border-left-0 border-md"></asp:TextBox>
                                </div>

                                <div class="input-group col-lg-12">
                                    <div class="text-left button-register" style="padding:0px!important;">
                                        <div class="checkout__input__checkbox">
                                            <label for="chkNhanTin">
                                                Đừng bỏ lỡ thông tin và chương trình khuyến mãi của chúng tôi
                                                <asp:CheckBox ID="chkNhanTin" runat="server"/>
                                                <span class="checkmark"></span>
                                            </label>
                                        </div>
                                    </div>
                                </div>
                                <div class="input-group col-lg-12 mb-5">
                                    <div class="text-left button-register" style="padding:0px!important;">
                                        Khi bạn nhấn Đăng ký, bạn đã đồng ý thực hiện mọi giao dịch mua bán theo
                                        <a href="#" data-toggle="modal" data-target="#exampleModalLong"> điều kiện sử dụng và chính sách của Điện Quang</a>
                                    </div>
                                </div>

                                <div class="input-group col-lg-12">
                                    <div class="row" style=" width: 100%; padding: 0px !important; margin: 0px !important;">
                                        <div class="col-md-12 text-right button-register" style="padding:0px!important;">
                                            <asp:Button ID="btnDangKy" OnClick="btnDangKy_Click" runat="server" ValidationGroup="dk" CssClass="btn btn-danger button-width100" Text="ĐĂNG KÝ" />

                                            <asp:RequiredFieldValidator ID="rq1" ControlToValidate="txtEmailDK" SetFocusOnError="true" runat="server" ValidationGroup="dk" ErrorMessage="Vui lòng nhập Email" Display="None"></asp:RequiredFieldValidator>
                                             <asp:RequiredFieldValidator ID="rq2" ControlToValidate="txtHoTenDK" SetFocusOnError="true" runat="server" ValidationGroup="dk" ErrorMessage="Vui lòng nhập Họ và tên" Display="None"></asp:RequiredFieldValidator>
                                             <asp:RequiredFieldValidator ID="rq3" ControlToValidate="txtDienThoaiDK" SetFocusOnError="true" runat="server" ValidationGroup="dk" ErrorMessage="Vui lòng nhập Điện thoại" Display="None"></asp:RequiredFieldValidator>
                                             <asp:RequiredFieldValidator ID="rq4" ControlToValidate="txtMatKhauDK" SetFocusOnError="true" runat="server" ValidationGroup="dk" ErrorMessage="Vui lòng nhập Mật khẩu" Display="None"></asp:RequiredFieldValidator>
                                            <asp:CompareValidator ID="cp1" runat="server" ValidationGroup="dk" ControlToValidate="txtMatKhauDK" ControlToCompare="txtNhapLaiMKDK" ErrorMessage="Nhập lại mật khẩu chưa đúng" Display="None"></asp:CompareValidator>
                                            <asp:ValidationSummary ID="svd" ValidationGroup="dk" ShowMessageBox="true" ShowSummary="false" runat="server" />
                                        
                                        </div>
                                    </div>
                                </div>

                            </div>
                            <!--END Đăng ký-->
                        </div>


                    </div>
                </div>
            </div>
        </section>
        <!-- Hero Section End -->
    </div>

         <script type="text/javascript">

             function ShowPopupMess() {
                 $("#modalMess").modal("show");
             }

         </script>

    <script type="text/javascript">
        function myFunction() {
            var x = document.getElementById("txtMatKhauDN");
            if (x.type === "password") {
                x.type = "text";
            } else {
                x.type = "password";
            }
        }
    </script>

    <!-- Modal -->
    <div class="modal fade" id="exampleModalLong" tabindex="-1" role="dialog" aria-labelledby="exampleModalLongTitle" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLongTitle">Điều khoản sử dụng</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    Jennifer Gates đăng ảnh chụp cùng bố trong đám cưới của cô và gửi lời cảm ơn tới ông nhân dịp tỷ phú Mỹ bước sang tuổi 66.

                    "Mừng sinh nhật tuổi 66 của bố. Con luôn biết ơn vì được học hỏi từ tấm gương<br />
                    của bố về sự tò mò vô tận, không ngừng khám phá và mong muốn góp sức cho nhân loại.<br />
                    Cảm ơn bố vì luôn ủng hộ tình cảm và mơ ước của chúng con. Đó là những kỷ niệm sẽ theo con suốt cuộc đời",<br />
                    Jennifer Gates đăng lên Instagram hôm 28/10.

                    Trong ảnh là khoảnh khắc Bill Gates ngồi trên bức tường đá, cười rạng rỡ nhìn con gái Jennifer<br />
                    đang khoác lên mình chiếc váy cưới lộng lẫy trong hôn lễ hôm 17/10. Bức ảnh nhận được<br />
                    hàng nghìn lượt thích và bình luận trên Instagram
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Đóng</button>
                </div>
            </div>
        </div>
    </div>

         <!-- Modal Message -->
            <div class="col-12 text-center">
                <div class="modal fade" id="modalMess" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h6 class="modal-title text-uppercase text-center" style="width: 100%;" id="">Thông báo</h6>
                                <button type="button" class="close" data-dismiss="modal" aria-label="close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>
                            <div class="modal-body">
                                <div class="form-group">
                                    <div class="input-group has-validation">
                                        <span class="" style="width: 100%;font-size: 18px; height: 60px;">
                                            <asp:Label ID="lblmess" runat="server" Text=""></asp:Label></span>
                                    </div>
                                </div>

                                <div class="col-12 input-group text-center">
                                    <div style="width: 100%;">
                                        <button type="button" runat="server" id="divClose" class="btn btn-outline-danger text-center" data-dismiss="modal">Đóng</button>
                                        <a href="Profile.html" class="btn btn-outline-danger" runat="server" id="divOK" visible="false">OK</a>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- END Mess -->

    <!-- Js Plugins -->
    <script src="Content/js/jquery-3.3.1.min.js"></script>
    <script src="Content/js/bootstrap.min.js"></script>
    <script src="Content/js/jquery.nice-select.min.js"></script>
    <script src="Content/js/jquery-ui.min.js"></script>
    <script src="Content/js/jquery.slicknav.js"></script>
    <script src="Content/js/mixitup.min.js"></script>
    <script src="Content/js/owl.carousel.min.js"></script>
    <script src="Content/js/main.js"></script>
    </form>
</body>
</html>
