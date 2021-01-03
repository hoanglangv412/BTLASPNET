using BAITAPLON_ASPNET.Models;
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
        public string addNganhNghe(string nn)
        {
            try
            {
                conn.Open();
                string path = "INSERT INTO NganhNghe VALUES('" + nn + "')";
                var cmd = new SqlCommand(path, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                return "Thành công";
            }
            catch (Exception)
            {

                return "Thất bại";
            }
        }
        public string editNganhNghe(NganhNghe nn)
        {
            try
            {
                conn.Open();
                string path = "UPDATE NganhNghe SET tenNganhNghe = "+nn.TenNganhNghe+" WHERE maNganhNghe = "+nn.maNganhNghe+"";
                var cmd = new SqlCommand(path, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                return "Thành công";
            }
            catch (Exception)
            {
                return "Thất bại";
            }
        }
        public bool checkForeign(int nn)
        {
            conn.Open();
            bool flag = false;
            string path = "SELECT * FROM BaiDang WHERE maNganhNghe = @nn";
            var cmd = new SqlCommand(path,conn);
            cmd.Parameters.AddWithValue("nn",nn);
            var rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                flag = true;
            }
            return flag;
        }
        public string delNganhNghe()
        {
            try
            {
                conn.Open();
                string path = "DELETE from NganhNghe where maNganhNghe = 8";
                var cmd = new SqlCommand(path,conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                return "Thành công";
            }
            catch (Exception)
            {
                return "Thất bại";
            }
        }

    }
}