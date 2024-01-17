using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhieuThuEFC.Entities
{
    public class AppDbContext : DbContext
    {
        public virtual DbSet<LoaiNguyenLieu> LoaiNguyenLieu { get; set; }
        public virtual DbSet<NguyenLieu> NguyenLieu { get; set; }
        public virtual DbSet<PhieuThu> PhieuThu { get; set; }
        public virtual DbSet<ChiTietPhieuThu> ChiTietPhieu { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer($"Server = LAPTOP-1600EKM7\\SQLEXPRESS; Database = QLPhieuThu; Trusted_Connection = True; TrustServerCertificate = True");
        }
    }
}
