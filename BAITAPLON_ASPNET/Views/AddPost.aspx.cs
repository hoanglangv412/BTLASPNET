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
    
    public partial class AddPost : System.Web.UI.Page
    {
        BaiDangController bdc = new BaiDangController();
        NganhNgheController nnc = new NganhNgheController();
        protected void Page_Load(object sender, EventArgs e)
        {
            TaiKhoan tk = (TaiKhoan)Session["tk"];
            lblmantd.Text = (bdc.getMantd(tk.maTaiKhoan)).ToString();
            if (!IsPostBack)
            {
                ddlnganhnghe.DataSource = nnc.getNganhNghe();
                ddlnganhnghe.DataTextField = "TenNganhNghe";
                ddlnganhnghe.DataValueField = "maNganhNghe";
                ddlnganhnghe.DataBind();
            }
        }
        protected void btnadd_Click(object sender, EventArgs e)
        {
            BaiDang bdn = new BaiDang();
            bdn.maNhaTuyenDung = Convert.ToInt32(lblmantd.Text);
            bdn.tieuDe = txttieude.Text;
            bdn.viTriCongViec = txtvitri.Text;
            bdn.maNganhNghe = Convert.ToInt32(ddlnganhnghe.SelectedValue);
            bdn.moTa = txtmota.Text;
            bdn.soLuongTuyen = Convert.ToInt32(txtsoluongtuyen.Text);
            bdn.mucLuong = Convert.ToInt32(txtmucluong.Text);
            bdn.soDienThoai = txtsodienthoai.Text;
            bdn.diaChi = txtdiachi.Text;
            lblalert.Text = bdc.addBaidang(bdn);
        }     
    }
}