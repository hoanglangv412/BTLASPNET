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
            var da = new SqlDataAdapter(path, conn);
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
        public NganhNghe get1NN(int mnn)
        {
            conn.Open();
            string path = "SELECT * FROM NganhNghe WHERE maNganhNghe = " + mnn + "";
            SqlCommand cmd = new SqlCommand(path, conn);
            NganhNghe ngN = null;
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                ngN = new NganhNghe();

               ngN.maNganhNghe = (int)rd["maNganhNghe"];
               ngN.TenNganhNghe = (string)rd["TenNganhNghe"];

            }
            conn.Close();
            return ngN;

        }
        public bool checkForeign(int nn)
        {
            conn.Open();

            bool flag = false;
            string path = "SELECT * FROM BaiDang WHERE maNganhNghe = " + nn + "";
            var cmd = new SqlCommand(path, conn);
            var rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                flag = true;
            }
            conn.Close();
            return flag;

        }
        public void delNganhNghe(int maNN)
        {
            conn.Open();
            string path = "DELETE from NganhNghe where maNganhNghe = " + maNN + "";
            var cmd = new SqlCommand(path, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void EditNganhNghe(NganhNghe NN)
        {
            conn.Open();
            string sql = "update NganhNghe set TenNganhNghe= @tnn where maNganhNghe= @mann";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("mnn", NN.maNganhNghe);
            cmd.Parameters.AddWithValue("tnn", NN.TenNganhNghe);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}