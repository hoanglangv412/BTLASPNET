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
    public partial class TaiKhoanDetailView : System.Web.UI.Page
    {
        TaiKhoanController tkc = new TaiKhoanController();
        TaiKhoan tk = new TaiKhoan();
        protected void Page_Load(object sender, EventArgs e)
        {
            tk = (TaiKhoan)Session["tk"];
            imgavatar.ImageUrl = "~/Photos/" + tk.anh;
            lblmataikhoan.Text = (tk.maTaiKhoan).ToString();
            lblmatkhau.Text = "**********";
            lbltentaikhoan.Text = tk.tenTaiKhoan;
            iduploadphotos.Visible = false;
            btnok.Visible = false;
        }
        protected void btnagree_Click(object sender, EventArgs e)
        {
            if(txtoldpassword.Text == tk.matKhau && txtnewmatkhau2.Text == txtnewmatkhau.Text)
            {
                TaiKhoan tkn = new TaiKhoan();
                tkn.maTaiKhoan = tk.maTaiKhoan;
                tkn.tenTaiKhoan = tk.tenTaiKhoan;
                tkn.matKhau = txtnewmatkhau.Text;
                tkn.loaiTaiKhoan = tk.loaiTaiKhoan;
                tkn.anh = tk.anh;
                lblalert.Text = tkc.editTaiKhoan(tkn);
                Session["tk"] = tkn;
                Response.Redirect("AccountDetailView.aspx");
            }
            else
            {
                lblalert.Text = "Sai mật khẩu";
            }
        }
        protected void btnchangephoto_Click(object sender, EventArgs e)
        {
            iduploadphotos.Visible = true;
            btnok.Visible = true;
            btnchangephoto.Visible = false;
        }
        protected void btnok_Click(object sender, EventArgs e)
        {
            iduploadphotos.Visible = true;
            string path = Server.MapPath("~/Photos/");
            iduploadphotos.PostedFile.SaveAs(path + iduploadphotos.FileName);
            //update
            TaiKhoan tkn = new TaiKhoan();
            tkn.maTaiKhoan = tk.maTaiKhoan;
            tkn.tenTaiKhoan = tk.tenTaiKhoan;
            tkn.matKhau = tk.matKhau;
            tkn.loaiTaiKhoan = tk.loaiTaiKhoan;
            tkn.anh = iduploadphotos.FileName;
            lblalert.Text = tkc.editTaiKhoan(tkn);
            Session["tk"] = tkn;
            Response.Redirect("AccountDetailView.aspx");
        }
    }
}