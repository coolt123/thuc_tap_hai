using Identity.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Thuc_tap_tuan2.Entities;

namespace Thuc_tap_tuan2.DbContexts
{
    public class Data : IdentityDbContext<ApplicationUser>
    {
        public Data(DbContextOptions <Data> options) : base(options)
        { 
        }

        public DbSet<SanPham> SanPhams { get; set; }
        public DbSet<DoanhNghiep> DoanhNghieps { get; set; }
        public DbSet<DoanhNghiepSanPham> DoanhNghiepSanPhams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SanPham>(e =>
            {
                e.ToTable("sanpham");
                e.HasKey(a => a.IdSP);
                e.Property(a => a.IdSP)
                    .ValueGeneratedOnAdd();
                e.HasIndex(a => a.MaSp).IsUnique();
                e.HasIndex(a => a.TenSp).IsUnique();
            });

            modelBuilder.Entity<DoanhNghiep>(e =>
            {
                e.ToTable("doanhnghiep");
                e.HasKey(dn => dn.IdDN);
                e.Property(a => a.IdDN)
                    .ValueGeneratedOnAdd();
                e.HasIndex(dn => dn.TenDN).IsUnique();
                e.HasIndex(dn => dn.MST).IsUnique();
            });

            modelBuilder.Entity<DoanhNghiepSanPham>(e =>
            {
                e.ToTable("doanhnghiepsanpham");
                e.HasKey(a => new { a.IdSP, a.IdDN });

                e.HasOne(a => a.SanPham)
                    .WithMany(sp => sp.DoanhNghiepSanPhams)
                    .HasForeignKey(a => a.IdSP)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("Fk_sanpham");

                e.HasOne(a => a.DoanhNghiep)
                    .WithMany(dn => dn.DoanhNghiepSanPhams)
                    .HasForeignKey(a => a.IdDN)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("Fk_doanhnghiep");
            });
        }
    }
}
