using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BAITAPLON_ASPNET.Models
{
    public class NganhNghe
    {
        public int maNganhNghe { get; set; }
        public string TenNganhNghe { get; set; }
        public NganhNghe() { }

        public NganhNghe(int maNganhNghe, string tenNganhNghe)
        {
            this.maNganhNghe = maNganhNghe;
            TenNganhNghe = tenNganhNghe;
        }
    }
}