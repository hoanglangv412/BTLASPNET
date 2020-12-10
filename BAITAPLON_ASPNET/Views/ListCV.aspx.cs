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
    public partial class ListCV : System.Web.UI.Page
    {
        CVController dataCV = new CVController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
                HienThi();
        }

        private void HienThi()
        {
            TaiKhoan tk = (TaiKhoan)Session["tk"];
            grdCV.DataSource = dataCV.getCV(tk.maTaiKhoan);
            DataBind();
        }
        protected void Xoa_Click(object sender, CommandEventArgs e)
        {
            if(e.CommandName=="xoa")
            {
                dataCV.DelCV(Convert.ToInt32(e.CommandArgument));
                HienThi();
            }
        }

        protected void Sua_Click(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "sua")
            {
                CV c= dataCV.get1CV(Convert.ToInt32(e.CommandArgument));
                Session["CV"] = c;
                Response.Redirect("EditCV.aspx");
            }
        }

    }
}