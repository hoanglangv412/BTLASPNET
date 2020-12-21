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
    public partial class ListCVPosted : System.Web.UI.Page
    {
        CVController dataCV = new CVController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                hienThi();
        }

        private void hienThi()
        {
            TaiKhoan tk = (TaiKhoan)Session["tk"]; 
            grdCVPosted.DataSource = dataCV.getCVPosted(tk.maTaiKhoan);
            DataBind();
        }

        protected void btXoa_Command(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "xoa")
            {
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                int macv = Convert.ToInt32(commandArgs[0]);
                int mabd = Convert.ToInt32(commandArgs[1]);
                dataCV.delCVPosted(macv, mabd);

                hienThi();
            }
        }
    }
}