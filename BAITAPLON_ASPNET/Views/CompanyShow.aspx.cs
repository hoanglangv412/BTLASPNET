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
        BaiDangController bdc = new BaiDangController();
        NhaTuyenDungController ntdc = new NhaTuyenDungController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlcongty.DataSource = ntdc.getCongTy();
                DataBind();
            }
        }

        protected void btnshowpost_Click(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "ShowDanhSach")
            {
                dtlbaidang.DataSource = bdc.getAllBaidang(Convert.ToInt32(e.CommandArgument));
                DataBind();
                if (dtlbaidang.Items.Count == 0)
                {
                    lblalert.Text = "Không có bài đăng nào.";
                }
            }
        }
    }
}