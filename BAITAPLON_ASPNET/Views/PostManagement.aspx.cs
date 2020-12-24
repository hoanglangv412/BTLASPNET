using BAITAPLON_ASPNET.Controllers;
using BAITAPLON_ASPNET.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BAITAPLON_ASPNET.Views
{
    public partial class PostManagement : System.Web.UI.Page
    {
        BaiDangController bdc = new BaiDangController();
        UngTuyenController utc = new UngTuyenController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hienthi();
            }
        }
        private void hienthi()
        {
            TaiKhoan tk = (TaiKhoan)Session["tk"];
            int id = bdc.getMantd(tk.maTaiKhoan);
            grdpost.DataSource = bdc.getAllBaidang(id);
            DataBind();
        }

        protected void btndelete_Click(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "delete")
            {
                bdc.delBaidang(Convert.ToInt32(e.CommandArgument));
                hienthi();
            }
        }
        protected void btnedit_Click(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "edit")
            {
                BaiDang bd = bdc.getMotBaidang(Convert.ToInt32(e.CommandArgument));
                Session["baidang"] = bd;
                Response.Redirect("EditPost.aspx");
            }
        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            TaiKhoan tk = (TaiKhoan)Session["tk"];
            int id = bdc.getMantd(tk.maTaiKhoan);
            if (txtsearch.Text != null)
            {       
                grdpost.DataSource = bdc.SearchPost(id,txtsearch.Text);
                DataBind();
            }
            else
            {
                grdpost.DataSource = bdc.SearchPost(id,"");
                DataBind();
            }
            if(grdpost.Rows.Count == 0)
            {
                lblalert.Text = "Không tìm thấy bài đăng phù hợp.";
            }
            else
            {
                lblalert.Text = "";
            }
        }
    }
}