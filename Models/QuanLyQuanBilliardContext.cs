using Microsoft.EntityFrameworkCore;
using QuanLyQuanBilliard.Models.EF;

namespace QuanLyQuanBilliard.Models
{
    public class QuanLyQuanBilliardContext : DbContext
    {
        public QuanLyQuanBilliardContext(DbContextOptions<QuanLyQuanBilliardContext> options)
            : base(options)
        {
        }

        public DbSet<NhanVien> NhanViens { get; set; }
        public DbSet<Ban> Bans { get; set; }
        public DbSet<HoaDon> HoaDons { get; set; }
        public DbSet<Kho> Khos { get; set; }
        public DbSet<HoaDonChiTiet> HoaDonChiTiets { get; set; }
        public DbSet<Luong> Luongs { get; set; }
        public DbSet<TheThanhVien> TheThanhViens { get; set; }
        public DbSet<TaiKhoan> TaiKhoans { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<HoaDonChiTiet>()
                .HasOne(hdct => hdct.HoaDon)
                .WithMany(hd => hd.HoaDonChiTiets)
                .HasForeignKey(hdct => hdct.HoaDonId);

            modelBuilder.Entity<HoaDon>()
                .HasOne(hd => hd.TheThanhVien)
                .WithMany(tv => tv.HoaDons)
                .HasForeignKey(hd => hd.TheThanhVienId);
        }
    }
}
