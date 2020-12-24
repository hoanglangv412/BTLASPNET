using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAITAPLON_ASPNET.Controllers;
using BAITAPLON_ASPNET.Models;

namespace BTL_ASPNET_WEBGTVL.Views.BaiDang
{
    public partial class Show_DeleteBaiDangView : System.Web.UI.Page
    {
        BaiDangController bdc = new BaiDangController();
        NganhNgheController nnc = new NganhNgheController();
        CVController cvc = new CVController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlnganhnghe.DataSource = nnc.getNganhNghe();
                ddlnganhnghe.DataTextField = "TenNganhNghe";
                ddlnganhnghe.DataValueField = "maNganhNghe";
                ddlnganhnghe.DataBind();
                dtlbaidang.DataSource = bdc.getBaidang();
                dtlcv.DataSource = cvc.getCV();
                DataBind();
            }
            TaiKhoan tk = (TaiKhoan)Session["tk"];
            if (tk == null)
            {
                dtlbaidang.Visible = true;
                dtlcv.Visible = false;
                ddlnganhnghe.Visible = true;
            }
            if (tk != null)
            {
                if (tk.loaiTaiKhoan == 1)
                {
                    dtlcv.Visible = true;
                    dtlbaidang.Visible = false;
                    ddlnganhnghe.Visible = false;
                }
                if (tk.loaiTaiKhoan == 2)
                {
                    dtlbaidang.Visible = true;
                    dtlcv.Visible = false;
                    ddlnganhnghe.Visible = true;
                }
            }
        }
        protected void DDLpositionDataBound(object sender, EventArgs e)
        {
            if (!IsPostBack)
                ddlnganhnghe.Items.Insert(0, new ListItem("Tất cả ngành nghề", "0"));
        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            TaiKhoan tk = (TaiKhoan)Session["tk"];
            if (tk != null)
            {
                if(tk.loaiTaiKhoan == 1)
                {
                    string diachi = ddldiachi.SelectedValue;
                    string vitri = txtsearch.Text;
                    if (txtsearch.Text != "")
                    {
                        if (diachi == "Tất cả")
                        {
                            dtlcv.DataSource = cvc.getthroughDiachiAndVitri("", vitri);
                        }
                        if (diachi != "Tất cả")
                        {
                            dtlcv.DataSource = cvc.getthroughDiachiAndVitri(diachi, vitri);
                        }
                    }
                    else
                    {
                        if (diachi == "Tất cả")
                        {
                            dtlcv.DataSource = cvc.getthroughDiachiAndVitri("", "");
                        }
                        if (diachi != "Tất cả")
                        {
                            dtlcv.DataSource = cvc.getthroughDiachiAndVitri(diachi, "");
                        }
                    }
                }
                else
                {
                    if (txtsearch.Text != "")
                    {
                        txtsearch.BorderColor = System.Drawing.Color.Black;
                        string diachi = ddldiachi.SelectedValue;
                        string manganhnghe = ddlnganhnghe.SelectedValue;
                        string vitri = txtsearch.Text;
                        if (diachi == "Tất cả")
                        {
                            dtlbaidang.DataSource = bdc.getthroughDiachiandNganhNghe("", manganhnghe + ")", vitri);
                            DataBind();
                        }
                        if (manganhnghe == "0")
                        {
                            dtlbaidang.DataSource = bdc.getthroughDiachiandNganhNghe(diachi, "0 OR maNganhNghe > 0)", vitri);
                            DataBind();
                        }
                        if (diachi == "Tất cả" && manganhnghe == "0")
                        {
                            dtlbaidang.DataSource = bdc.getthroughDiachiandNganhNghe("", "0 OR maNganhNghe > 0)", vitri);
                            DataBind();
                        }
                        if (diachi != "Tất cả" && manganhnghe != "0")
                        {
                            dtlbaidang.DataSource = bdc.getthroughDiachiandNganhNghe(diachi, manganhnghe + ")", vitri);
                            DataBind();
                        }
                    }
                    else
                    {
                        string diachi = ddldiachi.SelectedValue;
                        string manganhnghe = ddlnganhnghe.SelectedValue;
                        if (diachi == "Tất cả")
                        {
                            dtlbaidang.DataSource = bdc.getthroughDiachiandNganhNghe("", manganhnghe + ")", "");
                            DataBind();
                        }
                        if (manganhnghe == "0")
                        {
                            dtlbaidang.DataSource = bdc.getthroughDiachiandNganhNghe(diachi, "0 OR maNganhNghe > 0)", "");
                            DataBind();
                        }
                        if (diachi == "Tất cả" && manganhnghe == "0")
                        {
                            dtlbaidang.DataSource = bdc.getthroughDiachiandNganhNghe("", "0 OR maNganhNghe > 0)", "");
                            DataBind();
                        }
                        if (diachi != "Tất cả" && manganhnghe != "0")
                        {
                            dtlbaidang.DataSource = bdc.getthroughDiachiandNganhNghe(diachi, manganhnghe + ")", "");
                            DataBind();
                        }
                    }
                    lblalert.Visible = false;
                    if (dtlbaidang.Items.Count == 0)
                    {
                        lblalert.Visible = true;
                        lblalert.Text = "Không có công việc cần tìm";
                    }
                }
            }
            else
            {
                if (txtsearch.Text != "")
                {
                    txtsearch.BorderColor = System.Drawing.Color.Black;
                    string diachi = ddldiachi.SelectedValue;
                    string manganhnghe = ddlnganhnghe.SelectedValue;
                    string vitri = txtsearch.Text;
                    if (diachi == "Tất cả")
                    {
                        dtlbaidang.DataSource = bdc.getthroughDiachiandNganhNghe("", manganhnghe + ")", vitri);
                        DataBind();
                    }
                    if (manganhnghe == "0")
                    {
                        dtlbaidang.DataSource = bdc.getthroughDiachiandNganhNghe(diachi, "0 OR maNganhNghe > 0)", vitri);
                        DataBind();
                    }
                    if (diachi == "Tất cả" && manganhnghe == "0")
                    {
                        dtlbaidang.DataSource = bdc.getthroughDiachiandNganhNghe("", "0 OR maNganhNghe > 0)", vitri);
                        DataBind();
                    }
                    if (diachi != "Tất cả" && manganhnghe != "0")
                    {
                        dtlbaidang.DataSource = bdc.getthroughDiachiandNganhNghe(diachi, manganhnghe + ")", vitri);
                        DataBind();
                    }
                }
                else
                {
                    string diachi = ddldiachi.SelectedValue;
                    string manganhnghe = ddlnganhnghe.SelectedValue;
                    if (diachi == "Tất cả")
                    {
                        dtlbaidang.DataSource = bdc.getthroughDiachiandNganhNghe("", manganhnghe + ")", "");
                        DataBind();
                    }
                    if (manganhnghe == "0")
                    {
                        dtlbaidang.DataSource = bdc.getthroughDiachiandNganhNghe(diachi, "0 OR maNganhNghe > 0)", "");
                        DataBind();
                    }
                    if (diachi == "Tất cả" && manganhnghe == "0")
                    {
                        dtlbaidang.DataSource = bdc.getthroughDiachiandNganhNghe("", "0 OR maNganhNghe > 0)", "");
                        DataBind();
                    }
                    if (diachi != "Tất cả" && manganhnghe != "0")
                    {
                        dtlbaidang.DataSource = bdc.getthroughDiachiandNganhNghe(diachi, manganhnghe + ")", "");
                        DataBind();
                    }
                }
                lblalert.Visible = false;
                if (dtlbaidang.Items.Count == 0)
                {
                    lblalert.Visible = true;
                    lblalert.Text = "Không có công việc cần tìm";
                }
            }
            DataBind();
        }
    }
}