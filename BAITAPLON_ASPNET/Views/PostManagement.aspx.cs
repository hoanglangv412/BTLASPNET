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
    public partial class PostManagement : System.Web.UI.Page
    {
        BaiDangController bdc = new BaiDangController();
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
    }
}