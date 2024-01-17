using PhieuThuEFC.Entities;
using PhieuThuEFC.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhieuThuEFC.Services
{
    public class LoaiNguyenLieuServices : ILoaiNguyenLieuServices
    {
        private readonly AppDbContext dbContext;

        public LoaiNguyenLieuServices()
        {
            this.dbContext = new AppDbContext();
        }

        public void ThemLoaiNguyenLieu(LoaiNguyenLieu loai)
        {
            loai.NhapThongTin();
            dbContext.Add(loai);
            dbContext.SaveChanges();
            Console.WriteLine("Them loai nguyen lieu thanh cong!");
        }
    }
}
