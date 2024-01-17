using PhieuThuEFC.Entities;
using PhieuThuEFC.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhieuThuEFC.Services
{
    public class ChiTietPhieuThuServices : IChiTietPhieuThuServices
    {
        private readonly AppDbContext dbContext;

        public ChiTietPhieuThuServices()
        {
            this.dbContext = new AppDbContext();
        }

        public void ThemChiTietPhieu(ChiTietPhieuThu chiTietPhieu)
        {
            if(dbContext.PhieuThu.Any(x => x.PhieuThuId == chiTietPhieu.PhieuThuId))
            {
                if(dbContext.NguyenLieu.Any(x => x.NguyenLieuId == chiTietPhieu.NguyenLieuId))
                {
                    chiTietPhieu.NhapThongTIn(chiTietPhieu.PhieuThuId, chiTietPhieu.NguyenLieuId);
                    dbContext.Add(chiTietPhieu);
                    dbContext.SaveChanges();
                    Console.WriteLine("Them chi tiet phieu thu thanh cong!");
                }
                else
                {
                    Console.WriteLine("Nguyen lieu khong ton tai");
                }
            }
            else
            {
                Console.WriteLine("Phieu thu khong ton tai!");
            }
        }
    }
}
