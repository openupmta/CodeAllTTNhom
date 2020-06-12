namespace coderush.Areas.TTNhom_QLKHO.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBQLKHOContext : DbContext
    {
        public DBQLKHOContext()
            : base("name=DBQLKHOContext")
        {
        }

        public virtual DbSet<DONVI> DONVIs { get; set; }
        public virtual DbSet<HANGHOA> HANGHOAs { get; set; }
        public virtual DbSet<KHACHHANG> KHACHHANGs { get; set; }
        public virtual DbSet<NHACC> NHACCs { get; set; }
        public virtual DbSet<PHIEUNHAP> PHIEUNHAPs { get; set; }
        public virtual DbSet<PHIEUXUAT> PHIEUXUATs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TTPHIEUNHAP> TTPHIEUNHAPs { get; set; }
        public virtual DbSet<TTPHIEUXUAT> TTPHIEUXUATs { get; set; }
        public virtual DbSet<USEROLE> USEROLEs { get; set; }
        public virtual DbSet<USER> USERS { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DONVI>()
                .HasMany(e => e.HANGHOAs)
                .WithRequired(e => e.DONVI)
                .HasForeignKey(e => e.IDDV)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HANGHOA>()
                .HasMany(e => e.TTPHIEUNHAPs)
                .WithRequired(e => e.HANGHOA)
                .HasForeignKey(e => e.IDHH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HANGHOA>()
                .HasMany(e => e.TTPHIEUXUATs)
                .WithRequired(e => e.HANGHOA)
                .HasForeignKey(e => e.IDHH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.TEN)
                .IsFixedLength();

            modelBuilder.Entity<KHACHHANG>()
                .HasMany(e => e.TTPHIEUXUATs)
                .WithRequired(e => e.KHACHHANG)
                .HasForeignKey(e => e.IDKH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KHACHHANG>()
                .HasMany(e => e.TTPHIEUNHAPs)
                .WithOptional(e => e.KHACHHANG)
                .HasForeignKey(e => e.IDKH);

            modelBuilder.Entity<NHACC>()
                .HasMany(e => e.HANGHOAs)
                .WithRequired(e => e.NHACC)
                .HasForeignKey(e => e.IDNCC)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PHIEUNHAP>()
                .HasMany(e => e.TTPHIEUNHAPs)
                .WithRequired(e => e.PHIEUNHAP)
                .HasForeignKey(e => e.IDPHIEUNHAP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TTPHIEUXUAT>()
                .HasMany(e => e.PHIEUXUATs)
                .WithOptional(e => e.TTPHIEUXUAT)
                .HasForeignKey(e => e.IDTTPHIEUXUAT);

            modelBuilder.Entity<USEROLE>()
                .HasMany(e => e.USERS)
                .WithRequired(e => e.USEROLE)
                .HasForeignKey(e => e.IDROLE)
                .WillCascadeOnDelete(false);
        }
    }
}
