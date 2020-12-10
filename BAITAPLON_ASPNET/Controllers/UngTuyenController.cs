using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BAITAPLON_ASPNET.Controllers
{
    public class UngTuyenController
    {
        SqlConnection conn = null;
        public UngTuyenController()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DVVIECLAMConnectionString2"].ConnectionString);
        }
        public string addUngTuyen(int macv, int mabd, DateTime date)
        {
            try
            {
                conn.Open();
                string path = "INSERT INTO UngTuyen VALUES(@macv,@mabd,@ngayut)";
                var cmd = new SqlCommand(path, conn);
                cmd.Parameters.AddWithValue("macv", macv);
                cmd.Parameters.AddWithValue("mabd", mabd);
                cmd.Parameters.AddWithValue("ngayut", date);
                cmd.ExecuteNonQuery();
                conn.Close();
                return "Thành công";
            }
            catch (Exception)
            {
                return "Thất bại";
            }
        }
        public string delUngTuyen(int macv, int mabd)
        {
            try
            {
                conn.Open();
                string path = "DELETE FROM UngTuyen WHERE maCV = @macv AND maBaiDang = @mabd";
                var cmd = new SqlCommand(path, conn);
                cmd.Parameters.AddWithValue("macv", macv);
                cmd.Parameters.AddWithValue("mabd", mabd);
                cmd.ExecuteNonQuery();
                conn.Close();
                return "Thành công";
            }
            catch (Exception)
            {
                return "Thất bại";
            }
        }
        public int checker(int macv, int mabd)
        {
            int flag = 0;
            conn.Open();
            string path = "SELECT * FROM UngTuyen WHERE maCV = "+macv+" AND maBaiDang = "+mabd+"";
            var cmd = new SqlCommand(path,conn);
            var rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                flag = 1;
            }
            conn.Close();
            return flag;
        }
    }
}