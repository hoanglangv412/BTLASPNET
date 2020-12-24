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
    public partial class CVManagement : System.Web.UI.Page
    {
        CVController dataCV = new CVController();


        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                txtNgayTao.Text = DateTime.Now.ToShortDateString();
                clDate.Visible = false;
            }
        }     

        protected void imgbtDate_Click(object sender, ImageClickEventArgs e)
        {
            if (clDate.Visible)
            {
                clDate.Visible = false;
            }
            else
            {
                clDate.Visible = true;
            }
            clDate.Attributes.Add("style", "position:absolute");   
        }

        protected void clDate_SelectionChanged(object sender, EventArgs e)
        {
            txtNgaySinh.Text = clDate.SelectedDate.ToString("MM/dd/yyyy");
            clDate.Visible = false;
        }

        protected void clDate_DayRender(object sender, DayRenderEventArgs e)
        {

            if (e.Day.IsOtherMonth)
            {
                e.Day.IsSelectable = false;
                e.Cell.BackColor = System.Drawing.Color.White;
            }
        }

        protected void btAdd_Click(object sender, EventArgs e)
        {
            try
            {
                TaiKhoan tk = (TaiKhoan)Session["tk"];

                CV c = new CV();
                c.tieuDe = txtTieuDe.Text;
                c.maTaiKhoan = tk.maTaiKhoan;
                c.hoTen = txtHoten.Text;
                c.ngaySinh = DateTime.Parse(txtNgaySinh.Text);
                c.gioiTinh = txtGioiTinh.Text;
                c.diaChi = txtDaChi.Text;
                c.dienThoai = txtSDT.Text;
                c.email = txtEmail.Text;
                c.hocVan = txtHocVan.Text;
                c.kinhNghiem = txtKinhNghiem.Text;
                c.kyNang = txtKyNang.Text;
                c.thongTinThem = txtThongtinThem.Text;

              
                    string path = Server.MapPath("~/Photos/");
                    browserAvatar.PostedFile.SaveAs(path + browserAvatar.FileName);
                    imgCV.ImageUrl = "~/Photos/" + browserAvatar.FileName;

                c.anhThe = browserAvatar.FileName;
                c.ngayTao = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy"));

                dataCV.ThemCV(c);
                EditCV.MessageBox(this, "Thêm Thanh Cong");
            }
            catch (Exception)
            {

                EditCV.MessageBox(this, "Co loi khi thêm");
            }
        }
    }
}