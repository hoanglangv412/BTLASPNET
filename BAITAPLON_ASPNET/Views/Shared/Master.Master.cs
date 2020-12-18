using BAITAPLON_ASPNET.Controllers;
using BAITAPLON_ASPNET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTL_ASPNET_WEBGTVL.Views.Shared
{
    public partial class Master : System.Web.UI.MasterPage
    {
        TaiKhoanController tkc = new TaiKhoanController();
        NhaTuyenDungController ntdc = new NhaTuyenDungController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["tk"] == null)
            {
                btnlogin.Visible = true;
                btnsignin.Visible = true;
                btnlogout.Visible = false;
                litaikhoan.Visible = false;
                licv.Visible = false;
                litindang.Visible = false;
                linguoidung.Visible = false;
            }
            else
            {
                btnlogin.Visible = false;
                btnsignin.Visible = false;
                btnlogout.Visible = true;
                TaiKhoan tk = (TaiKhoan)Session["tk"];
                if (tk.loaiTaiKhoan == 0)
                {
                    litaikhoan.Visible = true;
                    linguoidung.Visible = true;
                    litindang.Visible = false;
                    licv.Visible = false;
                }
                if (tk.loaiTaiKhoan == 1)
                {
                    litaikhoan.Visible = true;
                    litindang.Visible = true;
                    linguoidung.Visible = false;
                    licv.Visible = false;
                }
                if (tk.loaiTaiKhoan == 2)
                {
                    litaikhoan.Visible = true;
                    licv.Visible = true;
                    litindang.Visible = false;
                    linguoidung.Visible = false;
                }
            }
        }
        protected void btnmodallogin_Click(object sender, EventArgs e)
        {
            string TaiKhoan = txttaikhoan.Text;
            string MatKhau = txtmatkhau.Text;
            TaiKhoan tk = new TaiKhoan();
            if (tkc.checkTaiKhoan(TaiKhoan, MatKhau) == 0)
            {
                tk = tkc.getTaiKhoan(TaiKhoan);
                Session["tk"] = tk;
                Page_Load(sender, e);
            }
            if (tkc.checkTaiKhoan(TaiKhoan, MatKhau) == 1)
            {
                tk = tkc.getTaiKhoan(TaiKhoan);
                Session["tk"] = tk;
                Page_Load(sender, e);
            }
            if (tkc.checkTaiKhoan(TaiKhoan, MatKhau) == 2)
            {
                tk = tkc.getTaiKhoan(TaiKhoan);
                Session["tk"] = tk;
                Page_Load(sender, e);
            }
            if (tkc.checkTaiKhoan(TaiKhoan, MatKhau) == 3)
            {
                Response.Write("<script>alert('Sai tài khoản, mật khẩu.')</script>");
            }
        }
        protected void btnmodalsignin_Click(object sender, EventArgs e)
        {
            string alert = "";
            string taikhoan = txttaikhoandk.Text;
            string matkhau = txtmatkhaudk.Text;
            string anh = txtanhdk.Text;
            int loaitaikhoan = 3;
            if (rbadmin.Checked)
            {
                loaitaikhoan = 0;
            }
            if (rbntd.Checked)
            {
                loaitaikhoan = 1;
                txttennhatuyendung.Visible = true;
                txtgioithieu.Visible = true;
            }
            if (rbnd.Checked)
            {
                loaitaikhoan = 2;
                
            }
            TaiKhoan tk = new TaiKhoan();
            tk.tenTaiKhoan = taikhoan;
            tk.matKhau = matkhau;
            tk.loaiTaiKhoan = loaitaikhoan;
            tk.anh = anh;
            if (txtmatkhaudk.Text == txtxnmatkhau.Text && loaitaikhoan != 3)
            {
                alert = tkc.addTaiKhoan(tk) + ",mời đăng nhập lại.";
                if (loaitaikhoan == 1)
                {
                    List<TaiKhoan> lsttk = tkc.getTaiKhoan();
                    TaiKhoan tklast = lsttk.LastOrDefault();
                    NhaTuyenDung ntd = new NhaTuyenDung();
                    ntd.tenNhaTuyenDung = txttennhatuyendung.Text;
                    ntd.maTaiKhoan = tklast.maTaiKhoan;
                    ntd.logo = tklast.anh;
                    ntd.gioithieu = txtgioithieu.Text;
                    alert = ntdc.addNhaTuyenDung(ntd);
                }
            }
            else
            {
                alert = "Tài khoản, mật khẩu không hợp lệ";
            }
            Response.Write("<script>alert('" + alert + "')</script>");
        }
        protected void btnlogout_Click1(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("HomePage.aspx");
        }
    }
}