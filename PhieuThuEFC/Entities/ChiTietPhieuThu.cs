using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhieuThuEFC.Entities
{
    public class ChiTietPhieuThu
    {
        public int ChiTietPhieuThuId { get; set; }
        public int NguyenLieuId { get; set; }
        public int PhieuThuId { get; set; }
        public int SoLuongBan { get; set; }
        public NguyenLieu NguyenLieu { get; set; }
        public PhieuThu PhieuThu { get; set; }
        public void NhapThongTIn(int phieuId, int nlId)
        {
            ChiTietPhieuThuId = 0;
            NguyenLieuId = nlId;
            PhieuThuId = phieuId;
            Console.WriteLine("Nhap so luong ban: ");
            SoLuongBan = int.Parse(Console.ReadLine());
        }
    }
}
