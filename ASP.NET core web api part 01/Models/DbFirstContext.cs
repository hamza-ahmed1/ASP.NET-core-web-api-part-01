using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ASP.NET_core_web_api_part_01.Models
{
    public partial class DbFirstContext : DbContext
    {
        public DbFirstContext()
        {
        }

        public DbFirstContext(DbContextOptions<DbFirstContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<TblEmp> TblEmps { get; set; } = null!;
        public virtual DbSet<TblStudent> TblStudents { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.StudentGender)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Student_Gender");

                entity.Property(e => e.StudentName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Student_Name");
            });

            modelBuilder.Entity<TblEmp>(entity =>
            {
                entity.HasKey(e => e.EmpId);

                entity.ToTable("tblEmp");

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<TblStudent>(entity =>
            {
                entity.ToTable("tblStudent");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Gender).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
