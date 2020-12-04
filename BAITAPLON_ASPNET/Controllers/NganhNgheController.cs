using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BAITAPLON_ASPNET.Controllers
{
    public class NganhNgheController
    {
        SqlConnection conn = null;
        public NganhNgheController()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DVVIECLAMConnectionString2"].ConnectionString);
        }
        public DataTable getNganhNghe()
        {
            conn.Open();
            string path = "SELECT * FROM NganhNghe";
            var da = new SqlDataAdapter(path,conn);
            var dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            return dt;
        }
    }
}