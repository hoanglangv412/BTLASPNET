﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BAITAPLON_ASPNET.Models
{
    public class NhaTuyenDung
    {
        public NhaTuyenDung(int maNhaTuyenDung, string tenNhaTuyenDung, int maTaiKhoan, string logo,string gioithieu)
        {
            this.maNhaTuyenDung = maNhaTuyenDung;
            this.tenNhaTuyenDung = tenNhaTuyenDung;
            this.maTaiKhoan = maTaiKhoan;
            this.gioithieu = gioithieu;
            this.logo = logo;
        }
        public NhaTuyenDung() { }
        public int maNhaTuyenDung { get; set; }
        public string tenNhaTuyenDung { get; set; }
        public int maTaiKhoan { get; set; }
        public string logo { get; set; }
        public string gioithieu { get; set; }
    }
}