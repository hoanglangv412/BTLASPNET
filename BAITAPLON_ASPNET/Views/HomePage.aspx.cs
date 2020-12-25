using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;
using BAITAPLON_ASPNET.Controllers;
using BAITAPLON_ASPNET.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Windows;
//using Syncfusion.Pdf;
//using Syncfusion.Pdf.Parsing;
//using Syncfusion.Pdf.Graphics;
//using Syncfusion.GridHelperClasses;
//using System.Drawing;

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
                loadChart();
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
                tblreport.Visible = false;
            }
            if (tk != null)
            {
                if (tk.loaiTaiKhoan == 1)
                {
                    dtlcv.Visible = true;
                    dtlbaidang.Visible = false;
                    ddlnganhnghe.Visible = false;
                    tblreport.Visible = false;
                }
                if(tk.loaiTaiKhoan == 0)
                {
                    dtlbaidang.Visible = false;
                    dtlcv.Visible = false;
                    tblreport.Visible = true;
                }
                if (tk.loaiTaiKhoan == 2)
                {
                    dtlbaidang.Visible = true;
                    dtlcv.Visible = false;
                    ddlnganhnghe.Visible = true;
                    tblreport.Visible = false;
                }
            }
        }
        protected void DDLpositionDataBound(object sender, EventArgs e)
        {
            if (!IsPostBack)
                ddlnganhnghe.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Tất cả ngành nghề", "0"));
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

        protected void loadChart()
        {
            online.Text = (Application["Online"]).ToString();
            accesscount.Text = (Application["Access"]).ToString();
            grd.DataSource = bdc.CountPost();
            gridCV.DataSource = cvc.CountCV();
            grd.Visible = false;
            gridCV.Visible = false;
            DataBind();
            Chart1.Titles.Add("Số lượng bài đăng của các nhà tuyển dụng");
            Chart1.Legends.Add("Số lượng bài đăng");
            foreach (GridViewRow row in grd.Rows)
            {
                Chart1.Series["Số lượng bài đăng"].Points.AddXY(row.Cells[0].Text, row.Cells[1].Text);
                Chart1.Series["Số lượng bài đăng"].Points[row.RowIndex].Label = row.Cells[1].Text;
            }
            Chart2.Titles.Add("Số lượng CV của các tài khoản");
            Chart2.Legends.Add("Số lượng CV");
            foreach (GridViewRow row in gridCV.Rows)
            {
                Chart2.Series["Số lượng CV"].Points.AddXY(row.Cells[0].Text, row.Cells[1].Text);
                Chart2.Series["Số lượng CV"].Points[row.RowIndex].Label = row.Cells[1].Text;
            }
        }
    }
}