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
    public class CVController
    {
        SqlConnection conn = null;
        public CVController()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DVVIECLAMConnectionString2"].ConnectionString);
        }
        //Lấy danh sách CV
        public List<CV> getCV(int maTaiKhoan)
        {
            conn.Open();
            string sql = "select * from CV where maTaiKhoan="+maTaiKhoan+"";
            List<CV> dsCV = new List<CV>();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                CV c = new CV();
                c.maCV =(int)rd["maCV"];
                c.tieuDe = (string)rd["tieuDe"];
                c.maTaiKhoan = (int)rd["maTaiKhoan"];
                c.hoTen = (string)rd["hoTen"];
                c.ngaySinh = (DateTime)rd["ngaySinh"];
                c.gioiTinh = (string)rd["gioiTinh"];
                c.diaChi = (string)rd["diaChi"];
                c.dienThoai = (string)rd["soDienThoai"];
                c.email = (string)rd["email"];
                c.hocVan = (string)rd["hocVan"];
                c.kinhNghiem = (string)rd["kinhNghiem"];
                c.kyNang = (string)rd["kyNang"];
                c.thongTinThem = (string)rd["thongtinThem"];
                c.anhThe = (string)rd["anhThe"];
                c.ngayTao = (DateTime)rd["ngayTao"];
                dsCV.Add(c);
            }
            conn.Close();
            return dsCV;
        }
        public DataTable getCV()
        {
            conn.Open();
            string sql = "select * from CV";
            var da = new SqlDataAdapter(sql, conn);
            var dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            return dt;
        }
        //Sửa CV
        public void SuaCV(CV c)
        {
            conn.Open();
            string sql = "update CV set tieuDe=@tieude," +
                " hoTen=@hoten," +
                " ngaySinh=@ngaysinh," +
                " gioiTinh=@gioitinh," +
                " diaChi=@diachi," +
                " soDienThoai=@sodienthoai," +
                " email=@email," +
                " hocVan=@hocvan," +
                " kinhNghiem=@kinhnghiem," +
                " kyNang=@kynang," +
                " thongTinThem=@thongtinThem," +
                " anhThe=@anhthe," +
                " ngayTao=@ngayTao" +
                " where maCV=@maCV ";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("maCV", c.maCV);
            cmd.Parameters.AddWithValue("tieude", c.tieuDe);
            cmd.Parameters.AddWithValue("hoten", c.hoTen);
            cmd.Parameters.AddWithValue("ngaysinh", c.ngaySinh);
            cmd.Parameters.AddWithValue("gioitinh", c.gioiTinh);
            cmd.Parameters.AddWithValue("diachi", c.diaChi);
            cmd.Parameters.AddWithValue("sodienthoai", c.dienThoai);
            cmd.Parameters.AddWithValue("email", c.email);
            cmd.Parameters.AddWithValue("hocvan", c.hocVan);
            cmd.Parameters.AddWithValue("kinhnghiem", c.kinhNghiem);
            cmd.Parameters.AddWithValue("kynang", c.kyNang);
            cmd.Parameters.AddWithValue("thongtinthem", c.thongTinThem);
            cmd.Parameters.AddWithValue("anhthe", c.anhThe);
            cmd.Parameters.AddWithValue("ngaytao", c.ngayTao);
            cmd.ExecuteNonQuery();
            conn.Close();

        }


        //Thêm CV
        public void ThemCV(CV c)
        {
            conn.Open();
            string sql = "insert into CV values (@tieude, @mataikhoan, @hoten," +
                " @ngaysinh, @gioitinh, @diachi," +
                " @sodienthoai, @email, @hocvan," +
                " @kinhnghiem, @kynang, @thongtinthem," +
                " @anhthe, @ngaytao)"; 
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("tieude", c.tieuDe);
            cmd.Parameters.AddWithValue("mataikhoan", c.maTaiKhoan);
            cmd.Parameters.AddWithValue("hoten", c.hoTen);
            cmd.Parameters.AddWithValue("ngaysinh", c.ngaySinh);
            cmd.Parameters.AddWithValue("gioitinh", c.gioiTinh);
            cmd.Parameters.AddWithValue("diachi", c.diaChi);
            cmd.Parameters.AddWithValue("sodienthoai", c.dienThoai);
            cmd.Parameters.AddWithValue("email", c.email);
            cmd.Parameters.AddWithValue("hocvan", c.hocVan);
            cmd.Parameters.AddWithValue("kinhnghiem", c.kinhNghiem);
            cmd.Parameters.AddWithValue("kynang", c.kyNang);
            cmd.Parameters.AddWithValue("thongtinthem", c.thongTinThem);
            cmd.Parameters.AddWithValue("anhthe", c.anhThe);
            cmd.Parameters.AddWithValue("ngaytao", c.ngayTao);
            cmd.ExecuteNonQuery();
            conn.Close();

        }



        //Lấy 1 CV
        public CV get1CV(int maCV)
        {
            conn.Open();
            string sql = "select * from CV where maCV=" + maCV + "";
            SqlCommand cmd = new SqlCommand(sql, conn);
            CV c = null;
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                c = new CV();

                c.maCV = (int)rd["maCV"];
                c.tieuDe = (string)rd["tieuDe"];
                c.maTaiKhoan = (int)rd["maTaiKhoan"];
                c.hoTen = (string)rd["hoTen"];
                c.ngaySinh = (DateTime)rd["ngaySinh"];
                c.gioiTinh = (string)rd["gioiTinh"];
                c.diaChi = (string)rd["diaChi"];
                c.dienThoai = (string)rd["soDienThoai"];
                c.email = (string)rd["email"];
                c.hocVan = (string)rd["hocVan"];
                c.kinhNghiem = (string)rd["kinhNghiem"];
                c.kyNang = (string)rd["kyNang"];
                c.thongTinThem = (string)rd["thongTinThem"];
                c.ngayTao = (DateTime)rd["ngayTao"];
                c.anhThe = (string)rd["anhThe"];
            }
            conn.Close();
            return c;

        }





        //Xóa CV
        public void DelCV(int maCV)
        {
            conn.Open();
            string sql= "delete from CV where maCV="+maCV+"";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        
    }
}