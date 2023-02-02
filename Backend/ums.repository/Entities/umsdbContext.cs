using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace UniversityApp.Entities
{
    public partial class umsdbContext : DbContext
    {
        public umsdbContext()
        {
        }

        public umsdbContext(DbContextOptions<umsdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<StudEntity> StudInfos { get; set; } = null!;
        public virtual DbSet<FacultyEntity> TeacherInfos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=password;database=umsdb");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudEntity>(entity =>
            {
                entity.HasKey(e => e.StudRoll)
                    .HasName("PRIMARY");

                entity.ToTable("stud_info");

                entity.Property(e => e.StudRoll).HasColumnName("studRoll");

                entity.Property(e => e.Address).HasMaxLength(45);

                entity.Property(e => e.Branch)
                    .HasMaxLength(45)
                    .HasColumnName("branch");

                entity.Property(e => e.Course)
                    .HasMaxLength(45)
                    .HasColumnName("course");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB");

                entity.Property(e => e.Email).HasMaxLength(45);

                entity.Property(e => e.StudFname)
                    .HasMaxLength(45)
                    .HasColumnName("studFName");

                entity.Property(e => e.StudName)
                    .HasMaxLength(45)
                    .HasColumnName("studName");
            });

            modelBuilder.Entity<FacultyEntity>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("PRIMARY");

                entity.ToTable("teacher_info");

                entity.Property(e => e.Address).HasMaxLength(45);

                entity.Property(e => e.Department).HasMaxLength(45);

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB");

                entity.Property(e => e.Education).HasMaxLength(45);

                entity.Property(e => e.Email).HasMaxLength(45);

                entity.Property(e => e.FacultyFname)
                    .HasMaxLength(45)
                    .HasColumnName("FacultyFName");

                entity.Property(e => e.FacultyName).HasMaxLength(45);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
