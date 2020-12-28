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
    public partial class EditCV : System.Web.UI.Page
    {
        CVController dataCV = new CVController();
        string oldAvt = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CV c = (CV)Session["CV"];
                txtMaCV.Text = c.maCV.ToString();
                txtTieuDe.Text = c.tieuDe;
                txtHoten.Text = c.hoTen;
                //date pick?
                txtNgaySinh.Text = c.ngaySinh.ToString("MM/dd/yyyy");

                //tieptuc
                drGIoitinh.Text = c.gioiTinh;
                txtDaChi.Text = c.diaChi;
                txtSDT.Text = c.dienThoai;
                txtEmail.Text = c.email;
                txtHocVan.Text = c.hocVan;
                txtKinhNghiem.Text = c.kinhNghiem;
                txtKyNang.Text = c.kyNang;
                txtThongtinThem.Text = c.thongTinThem;

                //get anh the
                imgCV.ImageUrl = "~/Photos/" + c.anhThe;
                oldAvt = c.anhThe;
                txtNgayTao.Text = c.ngayTao.ToString("MM/dd/yyyy");
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
            if (clDate.SelectedDate.Year > DateTime.Now.Year)
            {
                e.Day.IsSelectable = false;
            }

            else if( clDate.SelectedDate.Year == DateTime.Now.Year && clDate.SelectedDate.Month > DateTime.Now.Month)
            {
                e.Day.IsSelectable = false;
            }
            else if (clDate.SelectedDate.Day > DateTime.Now.Day)
            {
                e.Day.IsSelectable = false;
            }

            if (e.Day.IsOtherMonth)
            {
                e.Day.IsSelectable = false;
                e.Cell.BackColor = System.Drawing.Color.White;
            }
        }

        protected void btEdit_Click(object sender, EventArgs e)
        {
            try
            {
                CV c = new CV();
                c.maCV = int.Parse(txtMaCV.Text);
                c.tieuDe = txtTieuDe.Text;
                c.hoTen = txtHoten.Text;
                c.ngaySinh = DateTime.Parse(txtNgaySinh.Text);
                c.gioiTinh = drGIoitinh.SelectedValue;
                c.diaChi = txtDaChi.Text;
                c.dienThoai = txtSDT.Text;
                c.email = txtEmail.Text;
                c.hocVan = txtHocVan.Text;
                c.kinhNghiem = txtKinhNghiem.Text;
                c.kyNang = txtKyNang.Text;
                c.thongTinThem = txtThongtinThem.Text;

                if (browserAvatar.FileName != oldAvt)
                {
                    string path = Server.MapPath("~/Photos/");
                    browserAvatar.PostedFile.SaveAs(path + browserAvatar.FileName);
                    imgCV.ImageUrl = "~/Photos/" + browserAvatar.FileName;
                }

                c.anhThe = browserAvatar.FileName;
                c.ngayTao = DateTime.Parse(DateTime.Now.ToShortDateString());

                dataCV.SuaCV(c);
                EditCV.MessageBox(this, "Sua Thanh Cong");
            }
            catch (Exception)
            {

                EditCV.MessageBox(this, "Co loi khi sua");
            }
        }


        public static void MessageBox(System.Web.UI.Page page, string strMsg)
        {
            //+ character added after strMsg "')"
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "alertMessage", "alert('" + strMsg + "')", true);

        }


    }
}