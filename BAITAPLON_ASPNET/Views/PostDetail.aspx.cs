using BAITAPLON_ASPNET.Controllers;
using BAITAPLON_ASPNET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BAITAPLON_ASPNET.Views
{
    public partial class PostDetail : System.Web.UI.Page
    {
        BaiDangController bdc = new BaiDangController();
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["maBaiDang"]);
            BaiDang bd = new BaiDang();
            bd = bdc.getMotBaidang(id);
            lblmabaidang.Text = bd.maBaiDang.ToString();
            lblmantd.Text = bd.maNhaTuyenDung.ToString();
            lbltieude.Text = bd.tieuDe;
            lblvitri.Text = bd.viTriCongViec;
            lblmann.Text = bd.maNganhNghe.ToString();
            lblslt.Text = bd.soLuongTuyen.ToString();
            lblml.Text = bd.mucLuong.ToString();
            lblsdt.Text = bd.soDienThoai;
            lbldiachi.Text = bd.diaChi;
        }
    }
}