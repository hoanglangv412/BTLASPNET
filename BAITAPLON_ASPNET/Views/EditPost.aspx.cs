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
    public partial class EditPost : System.Web.UI.Page
    {
        BaiDangController bdc = new BaiDangController();
        NganhNgheController nnc = new NganhNgheController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BaiDang bd = (BaiDang)Session["baidang"];
                lblmabaidang.Text = (bd.maBaiDang).ToString();
                lblmantd.Text = (bd.maNhaTuyenDung).ToString();
                txttieude.Text = bd.tieuDe;
                txtvitri.Text = bd.viTriCongViec;
                ddlnganhnghe.SelectedValue = (bd.maNganhNghe).ToString();
                txtmota.Text = bd.moTa;
                txtsoluongtuyen.Text = (bd.soLuongTuyen).ToString();
                txtmucluong.Text = (bd.mucLuong).ToString();
                txtsodienthoai.Text = bd.soDienThoai;
                txtdiachi.Text = bd.diaChi;
                //dropdownlist
                    ddlnganhnghe.DataSource = nnc.getNganhNghe();
                    ddlnganhnghe.DataTextField = "TenNganhNghe";
                    ddlnganhnghe.DataValueField = "maNganhNghe";
                    ddlnganhnghe.DataBind();
            }
        }
        protected void btnedit_Click(object sender, EventArgs e)
        {
            BaiDang bdn = new BaiDang();
            bdn.maBaiDang = Convert.ToInt32(lblmabaidang.Text);
            bdn.maNhaTuyenDung = Convert.ToInt32(lblmantd.Text);
            bdn.tieuDe = txttieude.Text;
            bdn.viTriCongViec = txtvitri.Text;
            bdn.maNganhNghe = Convert.ToInt32(ddlnganhnghe.SelectedValue);
            bdn.moTa = txtmota.Text;
            bdn.soLuongTuyen = Convert.ToInt32(txtsoluongtuyen.Text);
            bdn.mucLuong = Convert.ToInt32(txtmucluong.Text);
            bdn.soDienThoai = txtsodienthoai.Text;
            bdn.diaChi = txtdiachi.Text;
            lblalert.Text = bdc.editBaidang(bdn);
        }
    }
}