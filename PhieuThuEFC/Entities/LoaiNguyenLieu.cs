using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhieuThuEFC.Entities
{
    public class LoaiNguyenLieu
    {
        public int LoaiNguyenLieuId { get; set; }
        [Required]
        [MaxLength(20)]
        public string TenLoai { get; set; }
        public string MoTa { get; set; }
        public virtual IEnumerable<NguyenLieu> NguyenLieus { get; set; }
        public void NhapThongTin()
        {
            LoaiNguyenLieuId = 0;
            Console.WriteLine("Nhap ten loai: ");
            TenLoai = Console.ReadLine();
            Console.WriteLine("Nhap mo ta: ");
            MoTa = Console.ReadLine();
        }
    }
}
