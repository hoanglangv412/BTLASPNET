using BAITAPLON_ASPNET.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BAITAPLON_ASPNET.Views
{
    public partial class TypeManagement : System.Web.UI.Page
    {
        NganhNgheController nnc = new NganhNgheController();
        string alert = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            txttennn.Visible = false;
            btnxacnhan.Visible = false;
            if (!IsPostBack)
            {
                hienthi();
            }
        }

        private void hienthi()
        {
            grdtype.DataSource = nnc.getNganhNghe();
            DataBind();
        }

        protected void btnthem_Click(object sender, EventArgs e)
        {
            txttennn.Visible = true;
            btnxacnhan.Visible = true;
        }
        protected void btnxoa_Click(object sender, CommandEventArgs e)
        {
            if(e.CommandName == "xoa")
            {
                if (!nnc.checkForeign(Convert.ToInt32(e.CommandArgument))){
                    alert = nnc.delNganhNghe();
                    //hienthi();
                }
                else
                {
                    alert = "Vẫn còn bài đăng sử dụng ngành nghề này.";
                }
            }
            Response.Write("<script>alert('" + alert + "')</script>");
        }
        protected void btnxacnhan_Click(object sender, EventArgs e)
        {
            if(txttennn.Text != "")
            {
               alert = nnc.addNganhNghe(txttennn.Text);
               hienthi();
            }
            else
            {
                alert = "Hãy nhập vào tên ngành nghề";
            }
            //Response.Write("<script>alert('" + alert + "')</script>");
        }
    }
}