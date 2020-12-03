using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BAITAPLON_ASPNET.Controllers
{
    public class NhaTuyenDungController
    {
        SqlConnection conn = null;
        public NhaTuyenDungController()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DVVIECLAMConnectionString"].ConnectionString);
        }
        public DataTable getCongTy()
        {
            conn.Open();
            string path = "SELECT * FROM NhaTuyenDung";
            var da = new SqlDataAdapter(path, conn);
            var dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            return dt;
        }
    }
}