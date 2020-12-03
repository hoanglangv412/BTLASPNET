using BAITAPLON_ASPNET.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BAITAPLON_ASPNET.Controllers
{
    public class TaiKhoanController
    {
        SqlConnection conn = null;
        public TaiKhoanController()
        {
            string path = @"Data Source=DAICAKIEU\SQLEXPRESS;Initial Catalog=DVVIECLAM;Integrated Security=True";
            conn = new SqlConnection(path);
        }
        public TaiKhoan getTaiKhoan(string tenTaiKhoan)
        {
            conn.Open();
            string path = "SELECT * FROM TaiKhoan WHERE tenTaiKhoan = '"+tenTaiKhoan+"'";
            var cmd = new SqlCommand(path,conn);
            var rd = cmd.ExecuteReader();
            TaiKhoan tk = new TaiKhoan();
            if (rd.Read())
            {
                tk.maTaiKhoan = (int)rd["maTaiKhoan"];
                tk.tenTaiKhoan = (string)rd["tenTaiKhoan"];
                tk.matKhau = (string)rd["matKhau"];
                tk.loaiTaiKhoan = (int)rd["loaiTaiKhoan"];
                tk.anh = (string)rd["anh"];
            }
            conn.Close();
            return tk;
        }
        public int checkTaiKhoan(string TaiKhoan, string MatKhau)
        {
            conn.Open();
            int checker;
            string path = "SELECT * FROM TaiKhoan WHERE tenTaiKhoan = '"+TaiKhoan+"' AND matKhau = '"+MatKhau+"'";
            var cmd = new SqlCommand(path,conn);
            var rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                checker = (int)rd["loaiTaiKhoan"];
            }
            else
            {
                checker = 3;
            }
            conn.Close();
            return checker;
        }
        public string addTaiKhoan(TaiKhoan tk)
        {
            try
            {
                conn.Open();
                string path = "INSERT INTO TaiKhoan VALUES(@ttk,@mk,@ltk,@anh)";
                var cmd = new SqlCommand(path, conn);
                cmd.Parameters.AddWithValue("ttk", tk.tenTaiKhoan);
                cmd.Parameters.AddWithValue("mk", tk.matKhau);
                cmd.Parameters.AddWithValue("ltk", tk.loaiTaiKhoan);
                cmd.Parameters.AddWithValue("anh",tk.anh);
                cmd.ExecuteNonQuery();
                conn.Close();
                return "Thành công";
            }
            catch (Exception)
            {

                return "Không thành công";
            }
        }
        public string editTaiKhoan(TaiKhoan tk)
        {
            try
            {
                conn.Open();
                string path = "UPDATE TaiKhoan SET matKhau = @mk, anh = @anh WHERE maTaiKhoan = @mtk";
                var cmd = new SqlCommand(path, conn);
                cmd.Parameters.AddWithValue("mk", tk.matKhau);
                cmd.Parameters.AddWithValue("anh", tk.anh);
                cmd.Parameters.AddWithValue("mtk", tk.maTaiKhoan);
                cmd.ExecuteNonQuery();
                conn.Close();
                return "Thành công";
            }
            catch (Exception)
            {

                return "Không thành công";
            }
        }
    }
}