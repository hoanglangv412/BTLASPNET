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
                linganhnghe.Visible = false;
                btnlogin.Visible = true;
                btnsignin.Visible = true;
                btnlogout.Visible = false;
                litaikhoan.Visible = false;
                licv.Visible = false;
                litindang.Visible = false;
                linguoidung.Visible = false;
                licongty.Visible = true;
            }
            else
            {
                btnlogin.Visible = false;
                btnsignin.Visible = false;
                btnlogout.Visible = true;
                TaiKhoan tk = (TaiKhoan)Session["tk"];
                if (tk.loaiTaiKhoan == 0)
                {
                    linganhnghe.Visible = true;
                    litaikhoan.Visible = true;
                    linguoidung.Visible = true;
                    litindang.Visible = false;
                    licv.Visible = false;
                    licongty.Visible = false;
                }
                if (tk.loaiTaiKhoan == 1)
                {
                    linganhnghe.Visible = false;
                    litaikhoan.Visible = true;
                    litindang.Visible = true;
                    linguoidung.Visible = false;
                    licv.Visible = false;
                    licongty.Visible = true;
                }
                if (tk.loaiTaiKhoan == 2)
                {
                    linganhnghe.Visible = false;
                    litaikhoan.Visible = true;
                    licv.Visible = true;
                    litindang.Visible = false;
                    linguoidung.Visible = false;
                    licongty.Visible = true;
                }
            }
            if (!IsPostBack)
            {
                if (btnlogin.Visible == true && btnsignin.Visible == true)
                {
                    Session.Abandon();
                }
            }
        }
        protected void btnmodallogin_Click(object sender, EventArgs e)
        {
            string TaiKhoan = txttaikhoan.Text;
            string MatKhau = txtmatkhau.Text;
            string alert = "";
            TaiKhoan tk = new TaiKhoan();
            if(TaiKhoan == "" && MatKhau == "")
            {
                alert = "Bạn chưa nhập tài khoản hoặc mật khẩu.";   
            }
            else
            {
                if (tkc.checkTaiKhoan(TaiKhoan, MatKhau) == 3)
                {
                    alert = "Sai tài khoản, mật khẩu.";
                }
                if (tkc.checkTaiKhoan(TaiKhoan, MatKhau) == 0)
                {
                    tk = tkc.getTaiKhoan(TaiKhoan);
                    Session["tk"] = tk;
                    Response.Redirect("HomePage.aspx");
                }
                if (tkc.checkTaiKhoan(TaiKhoan, MatKhau) == 1)
                {
                    tk = tkc.getTaiKhoan(TaiKhoan);
                    Session["tk"] = tk;
                    //Page_Load(sender, e);
                    Response.Redirect("HomePage.aspx");
                }
                if (tkc.checkTaiKhoan(TaiKhoan, MatKhau) == 2)
                {
                    tk = tkc.getTaiKhoan(TaiKhoan);
                    Session["tk"] = tk;
                    Response.Redirect("HomePage.aspx");
                }
            }
            Response.Write("<script>alert('"+alert+"')</script>");
        }
        protected void btnmodalsignin_Click(object sender, EventArgs e)
        {
            string alert = "";
            string taikhoan = txttaikhoandk.Text;
            string matkhau = txtmatkhaudk.Text;
            string anh = txtanhdk.Text;
            int loaitaikhoan = 3;
            if (taikhoan == "" && matkhau == "")
            {
                alert = "Bạn chưa nhập tài khoản hoặc mật khẩu.";
            }
            else {
               
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
                if (!taikhoan.Equals(tkc.getTaiKhoan(taikhoan).tenTaiKhoan, StringComparison.InvariantCultureIgnoreCase))
                {
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
                            if (ntdc.getCongTy(txttennhatuyendung.Text) == 0)
                            {
                                ntd.tenNhaTuyenDung = txttennhatuyendung.Text;
                                ntd.maTaiKhoan = tklast.maTaiKhoan;
                                ntd.logo = tklast.anh;
                                ntd.gioithieu = txtgioithieu.Text;
                                alert = ntdc.addNhaTuyenDung(ntd);
                            }
                            else
                            {
                                alert = "Tên nhà tuyển dụng đã tồn tại.";
                            }
                        }
                    }
                    else
                    {
                        alert = "Tài khoản, mật khẩu không hợp lệ";
                    }
                }
                else
                {
                    alert = "Tài khoản đã tồn tại.";
                }
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