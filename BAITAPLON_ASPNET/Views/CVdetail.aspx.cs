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
    public partial class WebForm1 : System.Web.UI.Page
    {
        CVController cvc = new CVController();
        UngTuyenController utc = new UngTuyenController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
                hienthi();
            string duyet = Request.QueryString["duyet"];
            btnduyet.Visible = false;
            btnhuy.Visible = false;
            if (duyet == "False")
            {
                btnduyet.Visible = true;
            }
            if(duyet == "True")
            {
                btnhuy.Visible = true;
            }
        }

        private void hienthi()
        {
            int id = Convert.ToInt32(Request.QueryString["macv"]);
            CV cv = new CV();
            cv = cvc.get1CV(id);
            imganhthe.ImageUrl = "~/Photos/" + cv.anhThe;
            lblhoten.Text = cv.hoTen;
            lbldiaChi.Text = cv.diaChi;
            lblgioiTinh.Text = cv.gioiTinh;
            soDienthoai.Text = cv.dienThoai;
            email.Text = cv.email;
            lblngaysinh.Text = cv.ngaySinh.ToShortDateString();
            lbltieude.Text = cv.tieuDe;
            lblkinhnghiem.Text = cv.kinhNghiem;
            lblthongtin.Text = cv.thongTinThem;
            lblhocvan.Text = cv.hocVan;
            lblkinang.Text = cv.kyNang;
        }

        protected void btnduyet_Click(object sender, EventArgs e)
        {
            int macv = Convert.ToInt32(Request.QueryString["macv"]);
            int mabd = Convert.ToInt32(Request.QueryString["mabd"]);

            utc.updUngTuyen(macv,mabd,1);
            Response.Redirect("PostManagement.aspx");
        }
        protected void btnhuy_Click(object sender, EventArgs e)
        {
            int macv = Convert.ToInt32(Request.QueryString["macv"]);
            int mabd = Convert.ToInt32(Request.QueryString["mabd"]);

            utc.updUngTuyen(macv, mabd, 0);
            Response.Redirect("PostManagement.aspx");
        }
    }
}