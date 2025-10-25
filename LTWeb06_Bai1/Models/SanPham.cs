using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace LTWeb06_Bai1.Models
{
    public class SanPham
    {
        public int MaSanPham {  get; set; }
        public string TenSanPham { get; set;}
        public int MaLoai { get; set; }
        public int MaSanXuat { get; set; }
        public double Gia { get; set; }
        public string GhiChu { get; set; }
        public string Hinh { get; set; }
    }
}