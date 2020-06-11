namespace coderush.Areas.TTNhom_QLThuVien.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBQLTVContext : DbContext
    {
        internal readonly object Links;

        public DBQLTVContext()
            : base("name=DBQLTVContext1")
        {
        }

        public virtual DbSet<DocGia> DocGias { get; set; }
        public virtual DbSet<MuonTraSach> MuonTraSaches { get; set; }
        public virtual DbSet<NhaXuatBan> NhaXuatBans { get; set; }
        public virtual DbSet<Sach> Saches { get; set; }
        public virtual DbSet<TacGia> TacGias { get; set; }
        public virtual DbSet<TheLoai> TheLoais { get; set; }
        public virtual DbSet<TheThuVien> TheThuViens { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DocGia>()
                .Property(e => e.MaDocGia)
                .IsUnicode(false);

            modelBuilder.Entity<DocGia>()
                .Property(e => e.MaSoThe)
                .IsUnicode(false);

            modelBuilder.Entity<DocGia>()
                .Property(e => e.SoDT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DocGia>()
                .Property(e => e.CMT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MuonTraSach>()
                .Property(e => e.MaMuonTra)
                .IsUnicode(false);

            modelBuilder.Entity<MuonTraSach>()
                .Property(e => e.MaSoThe)
                .IsUnicode(false);

            modelBuilder.Entity<MuonTraSach>()
                .Property(e => e.MaSach)
                .IsUnicode(false);

            modelBuilder.Entity<NhaXuatBan>()
                .Property(e => e.MaNXB)
                .IsUnicode(false);

            modelBuilder.Entity<NhaXuatBan>()
                .Property(e => e.Email)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NhaXuatBan>()
                .Property(e => e.SoDT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Sach>()
                .Property(e => e.MaSach)
                .IsUnicode(false);

            modelBuilder.Entity<Sach>()
                .Property(e => e.MaTacGia)
                .IsUnicode(false);

            modelBuilder.Entity<Sach>()
                .Property(e => e.MaTheLoai)
                .IsUnicode(false);

            modelBuilder.Entity<Sach>()
                .Property(e => e.MaNXB)
                .IsUnicode(false);

            modelBuilder.Entity<TacGia>()
                .Property(e => e.MaTacGia)
                .IsUnicode(false);

            modelBuilder.Entity<TheLoai>()
                .Property(e => e.MaTheLoai)
                .IsUnicode(false);

            modelBuilder.Entity<TheThuVien>()
                .Property(e => e.MaSoThe)
                .IsUnicode(false);
        }
    }
}