using System;
using System.Collections.Generic;
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlnganhnghe.DataSource = nnc.getNganhNghe();
                ddlnganhnghe.DataTextField = "TenNganhNghe";
                ddlnganhnghe.DataValueField = "maNganhNghe";
                ddlnganhnghe.DataBind();
            }
            dtlbaidang.DataSource = bdc.getBaidang();
            DataBind();
        }
        protected void DDLpositionDataBound(object sender, EventArgs e)
        {
            if (!IsPostBack)
                ddlnganhnghe.Items.Insert(0, new ListItem("Tất cả ngành nghề", "0"));
        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            if (txtsearch.Text != "")
            {
                txtsearch.BorderColor = System.Drawing.Color.Black;
                string diachi = ddldiachi.SelectedValue;
                int manganhnghe = Convert.ToInt32(ddlnganhnghe.SelectedValue);
                string vitri = txtsearch.Text;
                if(diachi == "Tất cả")
                {
                    dtlbaidang.DataSource = bdc.getthroughDiachiandNganhNghe("",manganhnghe, vitri);
                    DataBind();
                }
                if(manganhnghe == 0)
                {
                    dtlbaidang.DataSource = bdc.getthroughDiachiandNganhNghe(diachi,0, vitri);
                    DataBind();
                }
                if(diachi == "Tất cả" && manganhnghe == 0)
                {
                    dtlbaidang.DataSource = bdc.getthroughDiachiandNganhNghe("", 0, vitri);
                    DataBind();
                }
                dtlbaidang.DataSource = bdc.getthroughDiachiandNganhNghe(diachi,manganhnghe, vitri);
                DataBind();
            }
            else
            {
                txtsearch.Attributes.Add("placeholder", "Hãy điền tên công việc cần tìm.");
                txtsearch.BorderColor = System.Drawing.Color.Red;
            }
        }
    }
}