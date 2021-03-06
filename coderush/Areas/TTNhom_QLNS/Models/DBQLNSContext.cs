namespace coderush.Areas.TTNhom_QLNS.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBQLNSContext : DbContext
    {
        public DBQLNSContext()
            : base("name=Model1")
        {
        }

        public virtual DbSet<address> addresses { get; set; }
        public virtual DbSet<customer> customers { get; set; }
        public virtual DbSet<department> departments { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<group_role> group_role { get; set; }
        public virtual DbSet<position> positions { get; set; }
        public virtual DbSet<Province> Provinces { get; set; }
        public virtual DbSet<staff> staffs { get; set; }
        public virtual DbSet<Ward> Wards { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<customer>()
                .Property(e => e.cu_code)
                .IsUnicode(false);

            modelBuilder.Entity<customer>()
                .Property(e => e.cu_mobile)
                .IsUnicode(false);

            modelBuilder.Entity<customer>()
                .Property(e => e.cu_email)
                .IsUnicode(false);

            modelBuilder.Entity<customer>()
                .HasMany(e => e.addresses)
                .WithOptional(e => e.customer)
                .HasForeignKey(e => e.customer_id)
                .WillCascadeOnDelete();

            modelBuilder.Entity<department>()
                .HasMany(e => e.staffs)
                .WithOptional(e => e.department)
                .HasForeignKey(e => e.department_id);

            modelBuilder.Entity<District>()
                .HasMany(e => e.Wards)
                .WithRequired(e => e.District)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<group_role>()
                .HasMany(e => e.staffs)
                .WithOptional(e => e.group_role)
                .HasForeignKey(e => e.group_role_id);

            modelBuilder.Entity<position>()
                .HasMany(e => e.staffs)
                .WithOptional(e => e.position)
                .HasForeignKey(e => e.position_id);

            modelBuilder.Entity<Province>()
                .HasMany(e => e.Districts)
                .WithRequired(e => e.Province)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<staff>()
                .Property(e => e.sta_code)
                .IsUnicode(false);

            modelBuilder.Entity<staff>()
                .Property(e => e.sta_thumbnai)
                .IsUnicode(false);

            modelBuilder.Entity<staff>()
                .Property(e => e.sta_username)
                .IsUnicode(false);

            modelBuilder.Entity<staff>()
                .Property(e => e.sta_password)
                .IsUnicode(false);

            modelBuilder.Entity<staff>()
                .Property(e => e.sta_email)
                .IsUnicode(false);

            modelBuilder.Entity<staff>()
                .Property(e => e.sta_mobile)
                .IsUnicode(false);

            modelBuilder.Entity<staff>()
                .Property(e => e.sta_identity_card)
                .IsUnicode(false);

            modelBuilder.Entity<staff>()
                .HasMany(e => e.addresses)
                .WithOptional(e => e.staff)
                .HasForeignKey(e => e.staff_id)
                .WillCascadeOnDelete();
        }
    }
}

