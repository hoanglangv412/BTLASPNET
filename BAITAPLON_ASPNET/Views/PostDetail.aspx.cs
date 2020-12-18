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
        CVController cvc = new CVController();
        BaiDangController bdc = new BaiDangController();
        UngTuyenController utc = new UngTuyenController();
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
            DataList1.Visible = false;
            TaiKhoan tk = (TaiKhoan)Session["tk"];
            if(tk.loaiTaiKhoan == 1)
            {
                btnApply.Visible = false;
            }
        }
        protected void btnApply_Click(object sender, EventArgs e)
        {
            if(Session["tk"] == null)
            {
                Response.Write("<script>alert('Bạn chưa đăng nhập.')</script>");
            }
            else
            {
                TaiKhoan tk = (TaiKhoan)Session["tk"];
                List<CV> listcv = cvc.getCV(tk.maTaiKhoan);
                if (listcv.Count == 0)
                {
                    Response.Write("<script>alert('Bạn chưa tạo CV')</script>");
                }
                else
                {
                    DataList1.Visible = true;
                    DataList1.DataSource = cvc.getCV(tk.maTaiKhoan);
                    DataBind();
                }
            }
        }
        protected void btnSelect_Click(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "select")
            {
                int macv = Convert.ToInt32(e.CommandArgument.ToString());
                int id = Convert.ToInt32(Request.QueryString["maBaiDang"]);
                DateTime dt = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy"));
                if(utc.checker(macv,id) == 0)
                {
                    string text = utc.addUngTuyen(macv, id, dt);
                    Response.Write("<script>alert('" + text + "')</script>");
                }
                else if (utc.checker(macv, id) == 1)
                {
                    Response.Write("<script>alert('CV này bạn đã apply rồi.')</script>");
                }
            }
        }
    }
}