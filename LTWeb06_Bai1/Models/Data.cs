using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace LTWeb06_Bai1.Models
{
    public class Data
    {
        static string con = "Data Source=LAPTOP-PA3FT87S\\SQLEXPRESS; database=QL_BANHANG; User ID=sa; Password=sas123; TrustServerCertificate=true";
        SqlConnection sqlConnection = new SqlConnection(con);
        public List<SanPham> spList = new List<SanPham>();
        public List<Loai> loaiList = new List<Loai>();
        public List<KhachHang> khList = new List<KhachHang>();
        public List<HoaDon> hdList = new List<HoaDon>();
        public List<ChiTietHoaDon> cthdList = new List<ChiTietHoaDon>();
        public Data()
        {
            ThietLap_DSSP();
            ThietLap_DSLoai();
            ThietLap_DSKH();
            ThietLap_HoaDon();
            ThietLap_ChiTietHD();
        }
        public void ThietLap_DSSP()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM SANPHAM", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                var sp = new SanPham();
                sp.MaSanPham = int.Parse(dr["MASP"].ToString());
                sp.TenSanPham = dr["TENSP"].ToString();
                sp.MaLoai = int.Parse(dr["MALOAI"].ToString());
                sp.MaSanXuat = int.Parse(dr["MANSX"].ToString());
                sp.Gia = double.Parse(dr["GIA"].ToString());
                sp.GhiChu = dr["GHICHU"].ToString();
                sp.Hinh = dr["HINH"].ToString();
                spList.Add(sp);
            }
        }
        public void ThietLap_DSLoai()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM LOAI", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                var l = new Loai();
                l.MaLoai = int.Parse(dr["MALOAI"].ToString());
                l.TenLoai = dr["TENLOAI"].ToString();
                loaiList.Add(l);
            }
        }
        public void ThietLap_DSKH()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM KHACHHANG", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                var kh = new KhachHang();
                kh.MaKhachHang = int.Parse(dr["MAKHACHHANG"].ToString());
                kh.TenKhachHang = dr["TENKHACHHANG"].ToString();
                kh.SoDienThoai = dr["SODIENTHOAI"].ToString();
                kh.MatKhau = dr["MATKHAU"].ToString();
                khList.Add(kh);
            }
        }
        public void ThietLap_HoaDon()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM HOADON", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                var hd = new HoaDon();
                hd.MaHoaDon = int.Parse(dr["MAHD"].ToString());
                hd.NgayTao = Convert.ToDateTime(dr["NGAYTAO"]);
                hd.MaKhachHang = int.Parse(dr["MAKHACHHANG"].ToString());
                hdList.Add(hd);
            }
        }
        public void ThietLap_ChiTietHD()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM CHITIETHD", con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                var ct = new ChiTietHoaDon();
                ct.MaHoaDon = int.Parse(dr["MAHD"].ToString());
                ct.MaSanPham = int.Parse(dr["MASP"].ToString());
                ct.SoLuong = int.Parse(dr["SOLUONG"].ToString());
                cthdList.Add(ct);
            }
        }
    }
}