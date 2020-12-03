using System;
using System.Collections.Generic;
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
            string path = @"Data Source=DAICAKIEU\SQLEXPRESS;Initial Catalog=DVVIECLAM;Integrated Security=True";
            conn = new SqlConnection(path);
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