using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BAITAPLON_ASPNET.Models
{
    public class TaiKhoan
    {
        public TaiKhoan(int maTaiKhoan, string tenTaiKhoan, string matKhau, int loaiTaiKhoan,string anh)
        {
            this.maTaiKhoan = maTaiKhoan;
            this.tenTaiKhoan = tenTaiKhoan;
            this.matKhau = matKhau;
            this.loaiTaiKhoan = loaiTaiKhoan;
            this.anh = anh;
        }
        public TaiKhoan() { }
        public int maTaiKhoan { get;set;}
        public string tenTaiKhoan { get;set;}
        public string matKhau { get; set; }
        public int loaiTaiKhoan { get; set; }
        public string anh { get; set; }

    }
}