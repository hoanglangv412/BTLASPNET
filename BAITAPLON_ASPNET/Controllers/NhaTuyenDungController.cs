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
    }
}