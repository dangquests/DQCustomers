<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="DQCustomers.List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Hero Section Begin -->

    <div class="container">
        <div class="row">
            <div class="col-lg-3">
                <div class="hero__categories">
                    <div class="hero__categories__all">
                        <i class="fa fa-bars"></i>
                        <span>Danh mục</span>
                    </div>
                    <ul>
                        <li class=""><a href="Profile">Thông tin khách hàng</a></li>
                        <li>
                            <a href="List" class="active1">Sản phẩm đã scan</a>
                        </li>
                        <li>
                            <asp:LinkButton ID="lbtThoat" OnClick="lbtThoat_Click" runat="server">Thoát</asp:LinkButton>
                        </li>
                    </ul>
                </div>
            </div>
            <div class="col-lg-9 col-md-9">
                <div class="row featured__filter">


                    <div class="col-lg-3 col-md-4 col-sm-6 mix vegetables fastfood">
                        <div class="featured__item">
                            <div class="featured__item__pic set-bg" data-setbg="img/featured/2.png">
                            </div>
                            <div class="featured__item__text">
                                <h6><a href="#">Bộ đèn LED pha OLYMPUS 100</a></h6>
                                <div>
                                    <span class="text-danger float-left font-weight-bold">14/10/2021</span>
                                    <div class="product__details__rating float-right">
                                        <i class="fa fa-star"></i>
                                        <i class="fa fa-star"></i>
                                        <i class="fa fa-star"></i>
                                        <i class="fa fa-star"></i>
                                        <i class="fa fa-star-half-o"></i>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-4 col-sm-6 mix vegetables fresh-meat">
                        <div class="featured__item">
                            <div class="featured__item__pic set-bg" data-setbg="img/featured/3.png">
                            </div>
                            <div class="featured__item__text">
                                <h6><a href="#">Bộ đèn LED pha NEPTUNE 50</a></h6>
                                <div>
                                    <span class="text-danger float-left font-weight-bold">14/10/2021</span>
                                    <div class="product__details__rating float-right">
                                        <i class="fa fa-star"></i>
                                        <i class="fa fa-star"></i>
                                        <i class="fa fa-star"></i>
                                        <i class="fa fa-star"></i>
                                        <i class="fa fa-star-half-o"></i>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-4 col-sm-6 mix fastfood oranges">
                        <div class="featured__item">
                            <div class="featured__item__pic set-bg" data-setbg="img/featured/4.png">
                            </div>
                            <div class="featured__item__text">
                                <h6><a href="#">Bộ đèn LED pha OLYMPUS 200</a></h6>
                                <div>
                                    <span class="text-danger float-left font-weight-bold">14/10/2021</span>
                                    <div class="product__details__rating float-right">
                                        <i class="fa fa-star"></i>
                                        <i class="fa fa-star"></i>
                                        <i class="fa fa-star"></i>
                                        <i class="fa fa-star"></i>
                                        <i class="fa fa-star-half-o"></i>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-4 col-sm-6 mix oranges fastfood">
                        <div class="featured__item">
                            <div class="featured__item__pic set-bg" data-setbg="img/featured/4.png">
                            </div>
                            <div class="featured__item__text">
                                <h6><a href="#">Bộ đèn LED pha NEPTUNE 200</a></h6>
                                <div>
                                    <span class="text-danger float-left font-weight-bold">14/10/2021</span>
                                    <div class="product__details__rating float-right">
                                        <i class="fa fa-star"></i>
                                        <i class="fa fa-star"></i>
                                        <i class="fa fa-star"></i>
                                        <i class="fa fa-star"></i>
                                        <i class="fa fa-star-half-o"></i>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-4 col-sm-6 mix oranges fastfood">
                        <div class="featured__item">
                            <div class="featured__item__pic set-bg" data-setbg="img/featured/6.png">
                            </div>
                            <div class="featured__item__text">
                                <h6><a href="#">Bộ đèn LED pha NEPTUNE 200</a></h6>
                                <div>
                                    <span class="text-danger float-left font-weight-bold">14/10/2021</span>
                                    <div class="product__details__rating float-right">
                                        <i class="fa fa-star"></i>
                                        <i class="fa fa-star"></i>
                                        <i class="fa fa-star"></i>
                                        <i class="fa fa-star"></i>
                                        <i class="fa fa-star-half-o"></i>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-4 col-sm-6 mix fresh-meat vegetables">
                        <div class="featured__item">
                            <div class="featured__item__pic set-bg" data-setbg="img/featured/7.png">
                            </div>
                            <div class="featured__item__text">
                                <h6><a href="#">Bộ đèn LED Chống thấm Điện Quang ĐQ WP04 600</a></h6>
                                <div>
                                    <span class="text-danger float-left font-weight-bold">14/10/2021</span>
                                    <div class="product__details__rating float-right">
                                        <i class="fa fa-star"></i>
                                        <i class="fa fa-star"></i>
                                        <i class="fa fa-star"></i>
                                        <i class="fa fa-star"></i>
                                        <i class="fa fa-star-half-o"></i>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-4 col-sm-6 mix fastfood vegetables">
                        <div class="featured__item">
                            <div class="featured__item__pic set-bg" data-setbg="img/featured/8.png">
                            </div>
                            <div class="featured__item__text">
                                <h6><a href="#">Máng LED chống thấm Điện Quang ĐQ LWP02 218P2</a></h6>
                                <div>
                                    <span class="text-danger float-left font-weight-bold">14/10/2021</span>
                                    <div class="product__details__rating float-right">
                                        <i class="fa fa-star"></i>
                                        <i class="fa fa-star"></i>
                                        <i class="fa fa-star"></i>
                                        <i class="fa fa-star"></i>
                                        <i class="fa fa-star-half-o"></i>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>

            <div class="col-md-9">
                <div class="row">
                    <div class="col-md-9 offset-md-1">
                        <div class="row box-profile">
                            <asp:Repeater runat="server" ID="rptList">
                                <ItemTemplate>
                                    <div class="col-lg-3 col-md-4 col-sm-6 mix oranges fresh-meat">
                                        <div class="featured__item">
                                            <div class="featured__item__pic set-bg" data-setbg="img/featured/1.png">
                                            </div>
                                            <div class="featured__item__text">
                                                <h6><a href="#">Bộ đèn LED High bay HERA 1 - 100</a></h6>
                                                <span class="text-danger float-left font-weight-bold">14/10/2021</span>
                                                <div class="product__details__rating float-right">
                                                    <i class="fa fa-star"></i>
                                                    <i class="fa fa-star"></i>
                                                    <i class="fa fa-star"></i>
                                                    <i class="fa fa-star"></i>
                                                    <i class="fa fa-star-half-o"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- Hero Section End -->
</asp:Content>
