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
    public class BaiDangController
    {
        SqlConnection conn = null;
        public BaiDangController()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DVVIECLAMConnectionString2"].ConnectionString);
        }
        public DataTable getBaidang()
        {
            conn.Open();
            string sql = "SELECT maBaiDang,tenNhaTuyenDung,tieuDe,viTriCongViec,anh,mucLuong,BaiDang.maNhaTuyenDung,NhaTuyenDung.maTaiKhoan FROM NhaTuyenDung " +
                "inner join BaiDang on NhaTuyenDung.maNhaTuyenDung = BaiDang.maNhaTuyenDung " +
                "inner join TaiKhoan on NhaTuyenDung.maTaiKhoan = TaiKhoan.maTaiKhoan";
            var da = new SqlDataAdapter(sql, conn);
            var dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            return dt;
        }
        public int getMantd(int mtk)
        {
                conn.Open();
                int id = 0;
                string sql = "SELECT maNhaTuyenDung FROM NhaTuyenDung " +
                "WHERE maTaiKhoan = " + mtk + "";
                var cmd = new SqlCommand(sql, conn);
                var rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    id = (int)rd["maNhaTuyenDung"];
                }
                conn.Close();
                return id;
        }
        public DataTable getAllBaidang(int maNhaTuyenDung)
        {
            conn.Open();
            string sql = "SELECT * FROM NhaTuyenDung " +
                "inner join BaiDang on NhaTuyenDung.maNhaTuyenDung = BaiDang.maNhaTuyenDung " +
                "inner join TaiKhoan on NhaTuyenDung.maTaiKhoan = TaiKhoan.maTaiKhoan " +
                "WHERE BaiDang.maNhaTuyenDung = " +maNhaTuyenDung+"";
            var da = new SqlDataAdapter(sql, conn);
            var dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            return dt;
        }
        public BaiDang getMotBaidang(int maBaiDang)
        {
            conn.Open();
            string sql = "SELECT * FROM BaiDang WHERE maBaiDang = " + maBaiDang + "";
            var cmd = new SqlCommand(sql,conn);
            var rd = cmd.ExecuteReader();
            BaiDang bd = new BaiDang();
            if (rd.Read())
            {
                bd.maBaiDang = (int)rd["maBaiDang"];
                bd.maNhaTuyenDung = (int)rd["maNhaTuyenDung"];
                bd.tieuDe = (string)rd["tieuDe"];
                bd.viTriCongViec = (string)rd["viTriCongViec"];
                bd.maNganhNghe = (int)rd["maNganhNghe"];
                bd.moTa = (string)rd["moTa"];
                bd.soLuongTuyen = (int)rd["soLuongTuyen"];
                bd.mucLuong = (int)rd["mucLuong"];
                bd.soDienThoai = (string)rd["soDienThoai"];
                bd.diaChi = (string)rd["diaChi"];
            }
            conn.Close();
            return bd;
        }
        public DataTable getthroughDiachiandNganhNghe(string diachi,string maNganhNghe,string vitri)
        {
            conn.Open();
            String sql = "SELECT * FROM NhaTuyenDung " +
                "inner join BaiDang on NhaTuyenDung.maNhaTuyenDung = BaiDang.maNhaTuyenDung " +
                "inner join TaiKhoan on TaiKhoan.maTaiKhoan = NhaTuyenDung.maTaiKhoan WHERE diaChi LIKE N'%" + diachi + "%' AND (maNganhNghe = " + maNganhNghe + " AND viTriCongViec LIKE N'%" + vitri + "%'";
            var da = new SqlDataAdapter(sql, conn);
            var dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            return dt;
        }
        public string addBaidang(BaiDang bd)
        {
            try
            {
                conn.Open();
                string sql = "INSERT INTO BaiDang VALUES(@mntd,@td,@vtcv,@mnn,@mt,@slt,@ml,@sdt,@dc)";
                var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("mntd", bd.maNhaTuyenDung);
                cmd.Parameters.AddWithValue("td", bd.tieuDe);
                cmd.Parameters.AddWithValue("vtcv", bd.viTriCongViec);
                cmd.Parameters.AddWithValue("mnn", bd.maNganhNghe);
                cmd.Parameters.AddWithValue("mt", bd.moTa);
                cmd.Parameters.AddWithValue("slt", bd.soLuongTuyen);
                cmd.Parameters.AddWithValue("ml", bd.mucLuong);
                cmd.Parameters.AddWithValue("sdt", bd.soDienThoai);
                cmd.Parameters.AddWithValue("dc", bd.diaChi);
                cmd.ExecuteNonQuery();
                conn.Close();
                return "Thêm thành công";
            }
            catch (Exception)
            {
                return "Xảy ra lỗi";
            }
        }
        public string delBaidang(int maBaiDang)
        {
            try
            {
                conn.Open();
                string sql = "DELETE FROM BaiDang WHERE maBaiDang = "+maBaiDang+"";
                var cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                return "Xóa thành công";
            }
            catch (Exception)
            {
                return "Xảy ra lỗi";
            }
        }
        public string editBaidang(BaiDang bd)
        {
            try
            {
                conn.Open();
                string sql = "UPDATE BaiDang SET maNhaTuyenDung = @mntd,tieuDe = @td, viTriCongViec = @vtcv,maNganhNghe = @mnn,moTa = @mt,soLuongTuyen = @slt,mucLuong = @ml,soDienThoai = @sdt,diaChi = @dc WHERE maBaiDang = @mbd";
                var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("mntd", bd.maNhaTuyenDung);
                cmd.Parameters.AddWithValue("td", bd.tieuDe);
                cmd.Parameters.AddWithValue("vtcv", bd.viTriCongViec);
                cmd.Parameters.AddWithValue("mnn", bd.maNganhNghe);
                cmd.Parameters.AddWithValue("mt", bd.moTa);
                cmd.Parameters.AddWithValue("slt", bd.soLuongTuyen);
                cmd.Parameters.AddWithValue("ml", bd.mucLuong);
                cmd.Parameters.AddWithValue("sdt", bd.soDienThoai);
                cmd.Parameters.AddWithValue("dc", bd.diaChi);
                cmd.Parameters.AddWithValue("mbd", bd.maBaiDang);
                cmd.ExecuteNonQuery();
                conn.Close();
                return "Sửa thành công";
            }
            catch (Exception)
            {
                return "Xảy ra lỗi";
            }
        }
        public DataTable SearchPost(int mantd, string vitri)
        {
            conn.Open();
            string sql = "select * from BaiDang where maNhaTuyenDung=" + mantd + " and viTriCongVIec like N'%" + vitri + "%' ";
            var dtCV = new SqlDataAdapter(sql, conn);
            var tbCV = new DataTable();
            dtCV.Fill(tbCV);
            conn.Close();
            return tbCV;
        }
        public DataTable CountPost()
        {
            conn.Open();
            string sql = "SELECT tenNhaTuyenDung,COUNT(maBaiDang) AS soluongbaidang FROM BaiDang " +
                "inner join NhaTuyenDung ON BaiDang.maNhaTuyenDung = NhaTuyenDung.maNhaTuyenDung " +
                "GROUP BY tenNhaTuyenDung";
            var da = new SqlDataAdapter(sql, conn);
            var dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            return dt;
        }
    }
}