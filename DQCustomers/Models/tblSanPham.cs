//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DQCustomers.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblSanPham
    {
        public long ID { get; set; }
        public string QRCode { get; set; }
        public Nullable<int> SoYeuCau { get; set; }
        public string MaLBT { get; set; }
        public string NhaMay { get; set; }
        public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public string Model { get; set; }
        public string SoLot { get; set; }
        public string TrangThai { get; set; }
        public string NguoiTao { get; set; }
        public Nullable<System.DateTime> NgayTao { get; set; }
        public Nullable<System.DateTime> NgayDuyet { get; set; }
        public string CongSuat { get; set; }
        public string MoTa { get; set; }
        public Nullable<int> NamBaoHanh { get; set; }
        public string LinkSanPham { get; set; }
        public string HinhAnh { get; set; }
        public string NguoiCapNhat { get; set; }
        public Nullable<System.DateTime> NgayDownload { get; set; }
    }
}