using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace BAITAPLON_ASPNET
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            //Kiểm tra nếu chưa tồn tại file thì tạo file Count.txt
            string path = Server.MapPath("~/Views/Count.txt");
            if (!File.Exists(path))
                File.WriteAllText(path, "0");

            Application["Access"] = int.Parse(File.ReadAllText(path));
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            // Tăng số đang truy cập lên 1 nếu có khách truy cập
            string path = Server.MapPath("~/Views/Count.txt");
            if (Application["Online"] == null)
                Application["Online"] = 1;
            else

                Application["Online"] = (int)Application["Online"] + 1;
            // Tăng số đã truy cập lên 1 nếu có khách truy cập
            Application["Access"] = (int)Application["Access"] + 1;

            File.WriteAllText(path, Application["Access"].ToString());
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
            //Khi hết session hoặc người dùng thoát khỏi website thì giảm số người đang truy cập đi 1
            int i = (int)Application["Online"];

            Application["Online"] = i - 1;
        }

        protected void Application_End(object sender, EventArgs e)
        {
                   string path = Server.MapPath("~/Views/Count.txt");
            File.WriteAllText(path, Application["Access"].ToString());
        }
    }
}