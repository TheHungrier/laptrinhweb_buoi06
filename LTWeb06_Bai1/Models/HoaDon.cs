using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LTWeb06_Bai1.Models
{
    public class HoaDon
    {
        public int MaHoaDon { get; set; }
        public DateTime NgayTao { get; set; }
        public int MaKhachHang { get; set; }
        public List<ChiTietHoaDon> ChiTietList { get; set; }
    }
}