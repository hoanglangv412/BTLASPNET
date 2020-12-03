using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL_ASPNET_WEBGTVL.Models
{
    public class BaiDang
    {
        public int maBaiDang { get; set; }
        public int maNhaTuyenDung { get; set; }
        public string tieuDe { get; set; }
        public string viTriCongViec { get; set; }
        public int maNganhNghe { get; set; }
        public string moTa { get; set; }
        public int soLuongTuyen { get; set; }
        public int mucLuong { get; set; }
        public string soDienThoai { get; set; }
        public string diaChi { get; set; }
        public BaiDang(int maBaiDang, int maNhaTuyenDung, string tieuDe, string viTriCongViec, int maNganhNghe, string moTa, int soLuongTuyen, int mucLuong, string soDienThoai, string diaChi)
        {
            this.maBaiDang = maBaiDang;
            this.maNhaTuyenDung = maNhaTuyenDung;
            this.tieuDe = tieuDe;
            this.viTriCongViec = viTriCongViec;
            this.maNganhNghe = maNganhNghe;
            this.moTa = moTa;
            this.soLuongTuyen = soLuongTuyen;
            this.mucLuong = mucLuong;
            this.soDienThoai = soDienThoai;
            this.diaChi = diaChi;
        }
        public BaiDang() { }
    }
}