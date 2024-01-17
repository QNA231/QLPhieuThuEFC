using PhieuThuEFC.Entities;
using PhieuThuEFC.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhieuThuEFC.Services
{
    public class PhieuThuServices : IPhieuThuServices
    {
        private readonly AppDbContext dbContext;

        public PhieuThuServices( )
        {
            this.dbContext = new AppDbContext();
        }

        public void HienThiThongTIn(PhieuThu thu)
        {
            LayThongTIn();
        }

        private void LayThongTIn()
        {
            var result = dbContext.PhieuThu
                .Join(dbContext.ChiTietPhieu, pt => pt.PhieuThuId, ct => ct.PhieuThuId, (pt, ct) => new { PhieuThu = pt, ChiTietPhieuThu = ct })
                .Join(dbContext.NguyenLieu, ct => ct.ChiTietPhieuThu.NguyenLieuId, nl => nl.NguyenLieuId, (ct, nl) => new { ChiTietPhieuThu = ct, NguyenLieu = nl })
                .Select(x => new { x.NguyenLieu.TenNguyenLieu, x.ChiTietPhieuThu.PhieuThu.NgayLap, x.ChiTietPhieuThu.PhieuThu.NhanVienLap, x.ChiTietPhieuThu.PhieuThu.ThanhTien, x.ChiTietPhieuThu.ChiTietPhieuThu.SoLuongBan })
                .ToList();
            result.Sort((x, y) => DateTime.Compare(x.NgayLap, y.NgayLap));
            foreach(var s in result)
            {
                Console.WriteLine($"Ten nguyen lieu: {s.TenNguyenLieu} \nNgay lap phieu: {s.NgayLap} \nNhan vien lap: {s.NhanVienLap} \nThanh tien: {s.ThanhTien} \nSo luong ban: {s.SoLuongBan}");
            }
        }

        public void ThemPhieuThu(PhieuThu phieu)
        {
            phieu.NhapThongTIn();
            dbContext.Add(phieu);
            dbContext.SaveChanges();
            Console.WriteLine("Thanh cong!");
        }

        public void CapNhatDuLieu(List<ChiTietPhieuThu> phieu)
        {
            //var lstChiTiet = phieu.ChiTietPhieus.ToList();
            foreach (var chiTiet in phieu)
            {
                if (dbContext.NguyenLieu.Any(x => x.NguyenLieuId == chiTiet.NguyenLieuId))
                {
                    var nguyenLieu = dbContext.NguyenLieu.Find(chiTiet.NguyenLieuId);
                    nguyenLieu.SoLuongKho = nguyenLieu.SoLuongKho - chiTiet.SoLuongBan;
                    dbContext.Update(nguyenLieu);
                    dbContext.SaveChanges();

                    var phieuThu = dbContext.PhieuThu.Find(chiTiet.PhieuThuId);
                    phieuThu.ThanhTien += nguyenLieu.GiaBan * chiTiet.SoLuongBan;
                    dbContext.Update(phieuThu);
                    dbContext.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Them chi tiet phieu thu that bai!");
                }
            }
        }

        public void XoaPhieuThu(int phieuId)
        {
            if(dbContext.PhieuThu.Any(x => x.PhieuThuId == phieuId))
            {
                var lstChiTiet = dbContext.ChiTietPhieu.Where(x => x.PhieuThuId == phieuId);
                dbContext.RemoveRange(lstChiTiet);
                dbContext.SaveChanges();

                var phieu = dbContext.PhieuThu.Find(phieuId);
                dbContext.Remove(phieu);
                dbContext.SaveChanges();
                Console.WriteLine("Xoa phieu thu thanh cong!");
            }
            else
            {
                Console.WriteLine("Phieu thu khong ton tai!");
            }
        }
    }
}
