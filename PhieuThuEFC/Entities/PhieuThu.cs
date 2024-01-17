using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhieuThuEFC.Entities
{
    public class PhieuThu
    {
        public int PhieuThuId { get; set; }
        public DateTime NgayLap { get; set; }
        public string NhanVienLap { get; set; }
        public string GhiChu { get; set; }
        public double ThanhTien { get; set; }
        public virtual IEnumerable<ChiTietPhieuThu> ChiTietPhieus { get; set; }
        public void NhapThongTIn()
        {
            PhieuThuId = 0;
            Console.WriteLine("Nhap ngay lap: ");
            NgayLap = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Nhap nhan vien lap: ");
            NhanVienLap = Console.ReadLine();
            Console.WriteLine("Nhap ghi chu: ");
            GhiChu = Console.ReadLine();
            ThanhTien = 0;
        }
    }
}
