<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DQCustomers.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
         <div class="alert-messages text-center">
        </div>
        <div class="row">
            <div class="col-lg-4">
                <div class="hero__categories">
                    <img src="img/product/product-1.jpg" />
                </div>
            </div>
            <div class="col-lg-8 col-md-8">
                <div class="input-group col-lg-8 mb-3">
                    <div class="input-group-prepend">
                        <span class="input-group-text bg-white px-4 border-md border-right-0">
                            <i class="fa fa-user text-danger"></i>
                        </span>
                    </div>
                    <asp:TextBox ID="txtHoTen" runat="server" ValidationGroup="cn" placeholder="Tên sản phẩm" CssClass="form-control bg-white border-left-0 border-md"></asp:TextBox>
                </div>
                <div class="input-group col-lg-8 mb-3">
                    <div class="input-group-prepend">
                        <span class="input-group-text bg-white px-4 border-md border-right-0">
                            <i class="fa fa-phone text-danger"></i>
                        </span>
                    </div>
                    <asp:TextBox ID="txtDienThoai" runat="server" ValidationGroup="cn" placeholder="Ngày sản xuất" CssClass="form-control bg-white border-left-0 border-md"></asp:TextBox>
                </div>
                <div class="input-group col-lg-8 mb-3">
                    <div class="input-group-prepend">
                        <span class="input-group-text bg-white px-4 border-md border-right-0">
                            <i class="fa fa-envelope-open text-danger"></i>
                        </span>
                    </div>
                    <asp:TextBox ID="txtEmail" runat="server" ValidationGroup="cn" placeholder="Ngày hết hạn" CssClass="form-control bg-white border-left-0 border-md"></asp:TextBox>
                </div>
                <div class="input-group col-lg-8 mb-3">
                    <div class="input-group-prepend">
                        <span class="input-group-text bg-white px-4 border-md border-right-0">
                            <i class="fa fa-map-marker text-danger"></i>
                        </span>
                    </div>
                    <asp:TextBox ID="txtDiaChi" runat="server" ValidationGroup="cn" placeholder="Thời gian còn bảo hành" CssClass="form-control bg-white border-left-0 border-md"></asp:TextBox>
                </div>
                <div class="input-group col-lg-8 mt-4">
                    <div class="row" style="width: 100%; padding: 0px !important; margin: 0px !important;">
                            <asp:Button ID="btnLuu" runat="server" CssClass="btn btn-danger button-width100" Text="Lưu sản phẩm" />
                    </div>
                </div>

            </div>
        </div>
    </div>

    <!-- Hero Section End -->
</asp:Content>
