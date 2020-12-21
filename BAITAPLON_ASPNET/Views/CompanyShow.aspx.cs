using BAITAPLON_ASPNET.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BAITAPLON_ASPNET.Views
{
    public partial class CongTyShow : System.Web.UI.Page
    {
        NhaTuyenDungController ntdc = new NhaTuyenDungController();
        protected void Page_Load(object sender, EventArgs e)
        {
            ddlcongty.DataSource = ntdc.getCongTy();
            DataBind();
        }
    }
}