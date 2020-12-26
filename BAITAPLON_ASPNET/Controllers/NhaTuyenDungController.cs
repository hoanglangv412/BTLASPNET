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
    public class NhaTuyenDungController
    {
        SqlConnection conn = null;
        public NhaTuyenDungController()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DVVIECLAMConnectionString2"].ConnectionString);
        }
        public DataTable getCongTy()
        {
            conn.Open();
            string path = "SELECT * FROM NhaTuyenDung inner join TaiKhoan on TaiKhoan.maTaiKhoan = NhaTuyenDung.maTaiKhoan";
            var da = new SqlDataAdapter(path, conn);
            var dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            return dt;
        }
        public int getCongTy(string tenNhaTuyenDung)
        {
            conn.Open();
            int flag = 0;
            string path = "SELECT * FROM NhaTuyenDung WHERE tenNhaTuyenDung = '"+tenNhaTuyenDung+"'";
            var cmd = new SqlCommand(path, conn);
            var rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                flag = 1;
            }
            conn.Close();
            return flag;
        }
        public string addNhaTuyenDung(NhaTuyenDung ntd)
        {
            try
            {
                conn.Open();
                string path = "INSERT INTO NhaTuyenDung VALUES(@tntd,@mtk,@gt)";
                var cmd = new SqlCommand(path, conn);
                cmd.Parameters.AddWithValue("tntd", ntd.tenNhaTuyenDung);
                cmd.Parameters.AddWithValue("mtk", ntd.maTaiKhoan);
                cmd.Parameters.AddWithValue("gt", ntd.gioithieu);
                cmd.ExecuteNonQuery();
                conn.Close();
                return "Thanh cong";
            }
            catch (Exception)
            {

                return "That Bai";
            }
        }
        public int getmantd(int mtk)
        {
            conn.Open();
            string path = "SELECT maNhaTuyenDung FROM NhaTuyenDung WHERE maTaiKhoan = "+mtk+"";
            int mantd = 0;
            var cmd = new SqlCommand(path, conn);
            var rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                mantd = (int)rd["maNhaTuyenDung"];
            }
            conn.Close();
            return mantd;
        }
    }
}