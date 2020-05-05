namespace coderush.Areas.TTNhom_QLTTHPT.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QuanLyTTHPTConText : DbContext
    {
        public QuanLyTTHPTConText()
            : base("name=QuanLyTTHPTConText")
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
                .Property(e => e.HocKy)
                .IsUnicode(false);

            modelBuilder.Entity<DIEM>()
                .Property(e => e.NamHoc)
                .IsUnicode(false);

            modelBuilder.Entity<GIAOVIEN>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<GIAOVIEN>()
                .Property(e => e.MaHT)
                .IsUnicode(false);

            modelBuilder.Entity<GIAOVIEN>()
                .HasMany(e => e.PHANCONGs)
                .WithRequired(e => e.GIAOVIEN)
                .WillCascadeOnDelete(false);

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

            modelBuilder.Entity<LOP>()
                .HasMany(e => e.PHANCONGs)
                .WithRequired(e => e.LOP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PHANCONG>()
                .Property(e => e.NamHoc)
                .IsUnicode(false);
        }
    }
}
