using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Project_PRN211_SE1729.Models
{
    public partial class Project_PRN211Context : DbContext
    {
        public Project_PRN211Context()
        {
        }

        public Project_PRN211Context(DbContextOptions<Project_PRN211Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Class> Classes { get; set; } = null!;
        public virtual DbSet<Mark> Marks { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<Subject> Subjects { get; set; } = null!;
        public virtual DbSet<Teacher> Teachers { get; set; } = null!;
        public virtual DbSet<TypePoint> TypePoints { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=(local);database=Project_PRN211;Trusted_Connection=True;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.Property(e => e.AccountId)
                    .ValueGeneratedNever()
                    .HasColumnName("AccountID");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Tearcher)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.TearcherId)
                    .HasConstraintName("FK__Account__Tearche__300424B4");
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.ToTable("Class");

                entity.Property(e => e.ClassId).HasColumnName("ClassID");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.TeacherId).HasColumnName("TeacherID");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.TeacherId)
                    .HasConstraintName("FK_Class_Teacher");
            });

            modelBuilder.Entity<Mark>(entity =>
            {
                entity.HasKey(e => new { e.StudentId, e.TypeId, e.SubId })
                    .HasName("PK__Mark__F1C255FFD2931B3A");

                entity.ToTable("Mark");

                entity.Property(e => e.StudentId)
                    .HasMaxLength(8)
                    .HasColumnName("Student_ID")
                    .IsFixedLength();

                entity.Property(e => e.TypeId).HasColumnName("Type_ID");

                entity.Property(e => e.SubId).HasColumnName("Sub_ID");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Marks)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Mark_Students");

                entity.HasOne(d => d.Sub)
                    .WithMany(p => p.Marks)
                    .HasForeignKey(d => d.SubId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Mark_Subject");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Marks)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Mark_Type Point");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.StudentId)
                    .HasMaxLength(8)
                    .HasColumnName("StudentID")
                    .IsFixedLength();

                entity.Property(e => e.ClassId).HasColumnName("ClassID");

                entity.Property(e => e.Dob).HasColumnType("date");

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK_Students_Class");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.HasKey(e => e.SId);

                entity.ToTable("Subject");

                entity.Property(e => e.SId).HasColumnName("S_ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.TeacherId).HasColumnName("TeacherID");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Subjects)
                    .HasForeignKey(d => d.TeacherId)
                    .HasConstraintName("FK__Subject__Teacher__35BCFE0A");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.HasKey(e => e.TeachId);

                entity.ToTable("Teacher");

                entity.Property(e => e.TeachId).HasColumnName("TeachID");
            });

            modelBuilder.Entity<TypePoint>(entity =>
            {
                entity.HasKey(e => e.TId);

                entity.ToTable("Type Point");

                entity.Property(e => e.TId).HasColumnName("T_ID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
