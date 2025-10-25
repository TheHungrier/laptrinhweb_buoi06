using LTWeb06_Bai1.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.Mvc;

namespace LTWeb06_Bai1.Controllers
{
    public class HomeController : Controller
    {
        Data csdl = new Data();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult HienThiDanhSachSP(int maloai = 0, string tensp = "", float giaTu = 0, float giaDen = 0)
        {
            List<SanPham> sp = csdl.spList;
            if (maloai > 0)
            {
                sp = sp.Where(x => x.MaLoai == maloai).ToList();
                var loaiObj = csdl.loaiList.FirstOrDefault(l => l.MaLoai == maloai);
                ViewBag.TenLoai = loaiObj != null ? loaiObj.TenLoai : "Tất cả sản phẩm";
            }
            else
            {
                ViewBag.TenLoai = "Tất cả sản phẩm";
            }
            if (!string.IsNullOrEmpty(tensp))
            {
                sp = sp.Where(x => x.TenSanPham != null &&
                                   x.TenSanPham.ToLower().Contains(tensp.ToLower())).ToList();
            }
            if (giaTu > 0)
                sp = sp.Where(x => x.Gia >= giaTu).ToList();
            if (giaDen > 0)
                sp = sp.Where(x => x.Gia <= giaDen).ToList();
            ViewBag.LoaiList = csdl.loaiList;
            return View(sp);
        }

        public ActionResult HienThiChiTietSP(int id)
        {
            SanPham sp = csdl.spList.FirstOrDefault(x => x.MaSanPham == id);
            if (sp == null)
            {
                return HttpNotFound();
            }
            return View(sp);
        }

        public ActionResult HienThiDangKy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string telephone, string password)
        {
            KhachHang kh = csdl.khList.FirstOrDefault(u => u.SoDienThoai == telephone && u.MatKhau == password);

            if (kh != null)
            {
                Session["SoDienThoai"] = kh.SoDienThoai;
                return RedirectToAction("HienThiDanhSachSP", "Home");
            }
            else
            {
                ViewBag.Error = "Tên đăng nhập hoặc mật khẩu không đúng!";
                return View("Index");
            }
        }
        public ActionResult DangXuat()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }
        public ActionResult LichSuGiaoDich()
        {
            var soDienThoai = Session["SoDienThoai"] as string;
            if (string.IsNullOrEmpty(soDienThoai))
            {
                return RedirectToAction("Index", "Home");
            }
            var user = csdl.khList.FirstOrDefault(k => k.SoDienThoai == soDienThoai);
            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var hoaDonCuaToi = csdl.hdList.Where(h => h.MaKhachHang == user.MaKhachHang).ToList();
            foreach (var hd in hoaDonCuaToi)
            {
                hd.ChiTietList = csdl.cthdList.Where(ct => ct.MaHoaDon == hd.MaHoaDon).ToList();
            }
            return View(hoaDonCuaToi);
        }
    }
}