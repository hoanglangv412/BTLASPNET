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
                int macv = Convert.ToInt32(e.CommandArgument);
                if (!dataCV.CheckCVPostedIsNull(macv))
                {
                    Response.Write("<script> alert('Bạn đã ứng tuyển CV này rồi !') </script>");
                }
                else
                {
                    dataCV.DelCV(macv);
                    HienThi();
                }
                
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

        protected void btSearch_Click(object sender, EventArgs e)
        {
            TaiKhoan tk = (TaiKhoan)Session["tk"];
            if (txtSearch.Text != "")
            {
                grdCV.DataSource = dataCV.SearchCV(tk.maTaiKhoan, txtSearch.Text);
                DataBind();
               
            }
            else
            {
                txtSearch.Attributes.Add("placeholder", "Hãy điền thông tin tìm ...");
            }
        }
    }
}