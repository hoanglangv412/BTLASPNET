using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BAITAPLON_ASPNET.Models
{
    public class CV
    {
        
        public int maCV { get; set; }
        public string tieuDe { get; set; }
        public int maTaiKhoan { get; set; }
        public string hoTen { get; set; }
        public DateTime ngaySinh { get; set; }
        public string gioiTinh { get; set; }
        public string diaChi { get; set; }
        public string dienThoai { get; set; }
        public string email { get; set; }
        public string hocVan { get; set; }
        public string kinhNghiem { get; set; }

        public string kyNang { get; set; }
        public string thongTinThem { get; set; }
        public string anhThe { get; set; }
        public DateTime ngayTao { get; set; }

        public CV()
        {

        }

        public CV(int maCV,string tieuDe, int maTaiKhoan, string hoTen, DateTime ngaySinh, string gioiTinh, string diaChi, string dienThoai, string email, string hocVan, string kinhNghiem, string kyNang, string thongTinThem, string anhThe, DateTime ngayTao)
        {
            this.maCV = maCV;
            this.tieuDe = tieuDe;
            this.maTaiKhoan = maTaiKhoan;
            this.hoTen = hoTen;
            this.ngaySinh = ngaySinh;
            this.gioiTinh = gioiTinh;
            this.diaChi = diaChi;
            this.dienThoai = dienThoai;
            this.email = email;
            this.hocVan = hocVan;
            this.kinhNghiem = kinhNghiem;
            this.kyNang = kyNang;
            this.thongTinThem = thongTinThem;
            this.anhThe = anhThe;
            this.ngayTao = ngayTao;
        }
    }
}