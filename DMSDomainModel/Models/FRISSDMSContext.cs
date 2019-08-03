using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace DMSDomainModel.Models
{
    public partial class FRISSDMSContext : DbContext
    {
        public FRISSDMSContext()
        {
        }

        public FRISSDMSContext(DbContextOptions<FRISSDMSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Document> Document { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Transaction> Transaction { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("FRISS-DMSDatabase"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.DateTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<Document>(entity =>
            {
                entity.Property(e => e.DateTimeStamp).HasColumnType("datetime");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Document)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Document_Category");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.DateTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.Property(e => e.DateTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.TransDate).HasColumnType("datetime");

                entity.HasOne(d => d.Document)
                    .WithMany(p => p.Transaction)
                    .HasForeignKey(d => d.DocumentId)
                    .HasConstraintName("FK_Transaction_Document");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Transaction)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Transaction_User");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.DateTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.FullName).HasMaxLength(100);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Username).HasMaxLength(50);

                entity.HasOne(d => d.RoleNavigation)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.Role)
                    .HasConstraintName("FK_User_Role");
            });
        }
    }
}
