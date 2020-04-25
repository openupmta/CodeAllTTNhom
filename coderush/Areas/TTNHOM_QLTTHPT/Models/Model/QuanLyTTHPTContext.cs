namespace coderush.Areas.TTNHOM_QLTTHPT.Models.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QuanLyTTHPTContext : DbContext
    {
        public QuanLyTTHPTContext()
            : base("name=QuanLyTTHPTContext")
        {
        }

        public virtual DbSet<DIEM> DIEMs { get; set; }
        public virtual DbSet<DIEMCHITIETMONHOC> DIEMCHITIETMONHOCs { get; set; }
        public virtual DbSet<DIENUUTIEN> DIENUUTIENs { get; set; }
        public virtual DbSet<GIAOVIEN> GIAOVIENs { get; set; }
        public virtual DbSet<HOCSINH> HOCSINHs { get; set; }
        public virtual DbSet<KHOILOP> KHOILOPs { get; set; }
        public virtual DbSet<LOP> LOPs { get; set; }
        public virtual DbSet<MONHOC> MONHOCs { get; set; }
        public virtual DbSet<PHANCONG> PHANCONGs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DIEM>()
                .Property(e => e.MaDiem)
                .IsUnicode(false);

            modelBuilder.Entity<DIEM>()
                .Property(e => e.HocKy)
                .IsUnicode(false);

            modelBuilder.Entity<DIEM>()
                .Property(e => e.NamHoc)
                .IsUnicode(false);

            modelBuilder.Entity<DIEM>()
                .Property(e => e.MaHS)
                .IsUnicode(false);

            modelBuilder.Entity<DIEMCHITIETMONHOC>()
                .Property(e => e.MaDiemCTMH)
                .IsUnicode(false);

            modelBuilder.Entity<DIEMCHITIETMONHOC>()
                .Property(e => e.MaMH)
                .IsUnicode(false);

            modelBuilder.Entity<DIEMCHITIETMONHOC>()
                .Property(e => e.MaDiem)
                .IsUnicode(false);

            modelBuilder.Entity<DIENUUTIEN>()
                .Property(e => e.MaDUT)
                .IsUnicode(false);

            modelBuilder.Entity<GIAOVIEN>()
                .Property(e => e.MaGV)
                .IsUnicode(false);

            modelBuilder.Entity<GIAOVIEN>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<GIAOVIEN>()
                .Property(e => e.MaHT)
                .IsUnicode(false);

            modelBuilder.Entity<GIAOVIEN>()
                .Property(e => e.MaMH)
                .IsUnicode(false);

            modelBuilder.Entity<GIAOVIEN>()
                .HasMany(e => e.PHANCONGs)
                .WithRequired(e => e.GIAOVIEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HOCSINH>()
                .Property(e => e.MaHS)
                .IsUnicode(false);

            modelBuilder.Entity<HOCSINH>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<HOCSINH>()
                .Property(e => e.MaLT)
                .IsUnicode(false);

            modelBuilder.Entity<HOCSINH>()
                .Property(e => e.MaBT)
                .IsUnicode(false);

            modelBuilder.Entity<HOCSINH>()
                .Property(e => e.NienKhoa)
                .IsUnicode(false);

            modelBuilder.Entity<HOCSINH>()
                .Property(e => e.MaLop)
                .IsUnicode(false);

            modelBuilder.Entity<HOCSINH>()
                .Property(e => e.MaDUT)
                .IsUnicode(false);

            modelBuilder.Entity<KHOILOP>()
                .Property(e => e.MaKhoi)
                .IsUnicode(false);

            modelBuilder.Entity<LOP>()
                .Property(e => e.MaLop)
                .IsUnicode(false);

            modelBuilder.Entity<LOP>()
                .Property(e => e.MaKhoi)
                .IsUnicode(false);

            modelBuilder.Entity<LOP>()
                .HasMany(e => e.PHANCONGs)
                .WithRequired(e => e.LOP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MONHOC>()
                .Property(e => e.MaMH)
                .IsUnicode(false);

            modelBuilder.Entity<PHANCONG>()
                .Property(e => e.MaLop)
                .IsUnicode(false);

            modelBuilder.Entity<PHANCONG>()
                .Property(e => e.MaGV)
                .IsUnicode(false);

            modelBuilder.Entity<PHANCONG>()
                .Property(e => e.NamHoc)
                .IsUnicode(false);
        }
    }
}
