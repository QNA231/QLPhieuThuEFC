using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhieuThuEFC.Entities
{
    public class NguyenLieu
    {
        public int NguyenLieuId { get; set; }
        public int LoaiNguyenLieuId { get; set; }
        [Required]
        [MaxLength(20)]
        public string TenNguyenLieu { get; set; }
        public double GiaBan { get; set; }
        [MaxLength(10)]
        public string DonViTinh { get; set; }
        public int SoLuongKho { get; set; }
        public LoaiNguyenLieu LoaiNguyenLieu { get; set; }
        public virtual IEnumerable<ChiTietPhieuThu> ChiTietPhieus { get; set; }
        public void NhapThongTIn(int loaiId)
        {
            NguyenLieuId = 0;
            LoaiNguyenLieuId = loaiId;
            Console.WriteLine("Nhap ten nguyen lieu: ");
            TenNguyenLieu = Console.ReadLine();
            Console.WriteLine("Nhap gia ban: ");
            GiaBan = double.Parse(Console.ReadLine());
            Console.WriteLine("Nhap don vi tinh: ");
            DonViTinh = Console.ReadLine();
            Console.WriteLine("nhap so luong kho: ");
            SoLuongKho = int.Parse(Console.ReadLine());
        }
    }
}
