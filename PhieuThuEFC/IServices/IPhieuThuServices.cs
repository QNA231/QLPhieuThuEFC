using PhieuThuEFC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhieuThuEFC.IServices
{
    public interface IPhieuThuServices
    {
        void ThemPhieuThu(PhieuThu phieu);
        void XoaPhieuThu(int phieuId);
        void HienThiThongTIn(PhieuThu thu);
        void CapNhatDuLieu(List<ChiTietPhieuThu> phieu);
    }
}
