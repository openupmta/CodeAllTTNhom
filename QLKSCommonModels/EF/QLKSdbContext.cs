namespace QLKSCommonModels.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QLKSdbContext : DbContext
    {
        public QLKSdbContext()
            : base("name=QLKSdbContext")
        {
        }

        public virtual DbSet<DichVu> DichVus { get; set; }
        public virtual DbSet<DichVuChung> DichVuChungs { get; set; }
        public virtual DbSet<GiaPhong> GiaPhongs { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<PhieuChi> PhieuChis { get; set; }
        public virtual DbSet<PhieuThu> PhieuThus { get; set; }
        public virtual DbSet<PhieuThu_DichVuChung> PhieuThu_DichVuChung { get; set; }
        public virtual DbSet<Phong> Phongs { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DichVu>()
                .HasMany(e => e.GiaPhongs)
                .WithRequired(e => e.DichVu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DichVu>()
                .HasMany(e => e.PhieuThus)
                .WithRequired(e => e.DichVu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DichVuChung>()
                .Property(e => e.giaDVC)
                .HasPrecision(10, 3);

            modelBuilder.Entity<DichVuChung>()
                .HasMany(e => e.PhieuThu_DichVuChung)
                .WithRequired(e => e.DichVuChung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GiaPhong>()
                .Property(e => e.gia)
                .HasPrecision(10, 3);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.cmt)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.taikhoan)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.matkhau)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.sdt)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .HasMany(e => e.PhieuThus)
                .WithRequired(e => e.KhachHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.taikhoan)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.matkhau)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.ca)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.luong)
                .HasPrecision(12, 3);

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.PhieuChis)
                .WithRequired(e => e.NhanVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.PhieuThus)
                .WithRequired(e => e.NhanVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhieuChi>()
                .Property(e => e.tongtien)
                .HasPrecision(15, 3);

            modelBuilder.Entity<PhieuThu>()
                .Property(e => e.khuyenmai)
                .HasPrecision(15, 3);

            modelBuilder.Entity<PhieuThu>()
                .Property(e => e.tratruoc)
                .HasPrecision(15, 3);

            modelBuilder.Entity<PhieuThu>()
                .Property(e => e.tongtien)
                .HasPrecision(15, 3);

            modelBuilder.Entity<PhieuThu>()
                .Property(e => e.cmt)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuThu>()
                .HasMany(e => e.PhieuThu_DichVuChung)
                .WithRequired(e => e.PhieuThu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhieuThu_DichVuChung>()
                .Property(e => e.tongtienDVC)
                .HasPrecision(15, 3);

            modelBuilder.Entity<Phong>()
                .HasMany(e => e.GiaPhongs)
                .WithRequired(e => e.Phong)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Phong>()
                .HasMany(e => e.PhieuThus)
                .WithRequired(e => e.Phong)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Phone)
                .IsFixedLength();
        }
    }
}
