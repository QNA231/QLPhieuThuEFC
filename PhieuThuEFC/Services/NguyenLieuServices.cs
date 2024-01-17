using PhieuThuEFC.Entities;
using PhieuThuEFC.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhieuThuEFC.Services
{
    public class NguyenLieuServices : INguyenLieuServices
    {
        private readonly AppDbContext dbContext;

        public NguyenLieuServices()
        {
            this.dbContext = new AppDbContext();
        }

        public void ThemNguyenLieu(int LoaiId)
        {
            NguyenLieu nl = new NguyenLieu();
            if(dbContext.LoaiNguyenLieu.Any(x => x.LoaiNguyenLieuId == LoaiId))
            {
                nl.NhapThongTIn(LoaiId);
                dbContext.Add(nl);
                dbContext.SaveChanges();
                Console.WriteLine("Them nguyen lieu thanh cong!");
            }
            else
            {
                Console.WriteLine("Loai nguyen lieu khong ton tai!");
            }
        }
    }
}
