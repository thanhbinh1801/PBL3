using PBL3.DAL;
using System;
using System.Data.Entity;
using System.Linq;

namespace PBL3
{
    public class QLNHDB : DbContext
    {
        public QLNHDB()
            : base("name=QLNHDB")
        {
        }
        public DbSet<BanAn> BanAns { get; set; }
        public DbSet<MonAn> MonAns { get; set; }
        public DbSet<Nguoidung> nguoidungs { get; set; }
        public DbSet<NguyenLieu> nguyenLieu { get; set; }
        public DbSet<DonHang> donHang { get; set; }
        public DbSet<DonHangChiTiet> donHangChiTiet { get; set; }
        public DbSet<KhoNguyenLieu> khoNguyenLieu { get; set; }
        public DbSet<MonAnNguyenLieu> monAnNguyenLieu { get; set; }
    }
}