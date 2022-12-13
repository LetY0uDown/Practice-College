using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PracticeCollege.Models
{
    public partial class user12Context : DbContext
    {
        public user12Context()
        {
        }

        public user12Context(DbContextOptions<user12Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Group> Groups { get; set; } = null!;
        public virtual DbSet<Leaving> Leavings { get; set; } = null!;
        public virtual DbSet<Lesson> Lessons { get; set; } = null!;
        public virtual DbSet<LessonTeacher> LessonTeachers { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<Teacher> Teachers { get; set; } = null!;

        private static user12Context _instance;
        public static user12Context GetInstance()
        {
            _instance ??= new();

            return _instance;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("server=192.168.200.35;database=user12;user=user12;password=75352");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>(entity =>
            {
                entity.Property(e => e.GroupId).ValueGeneratedNever();

                entity.Property(e => e.GroupNumber)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Leaving>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.LeavingDate).HasColumnType("datetime");

                entity.HasOne(d => d.Lesson)
                    .WithMany(p => p.Leavings)
                    .HasForeignKey(d => d.LessonId)
                    .HasConstraintName("FK_Leavings_Lessons");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Leavings)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_Leavings_Students1");
            });

            modelBuilder.Entity<Lesson>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.LessonName)
                    .HasMaxLength(50)
                    .IsFixedLength();
            });

            modelBuilder.Entity<LessonTeacher>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Lesson_Teacher");

                entity.Property(e => e.LessonId).HasColumnName("LessonID");

                entity.Property(e => e.TeacherId).HasColumnName("TeacherID");

                entity.HasOne(d => d.Lesson)
                    .WithMany()
                    .HasForeignKey(d => d.LessonId)
                    .HasConstraintName("FK_Lesson_Teacher_Lessons");

                entity.HasOne(d => d.Teacher)
                    .WithMany()
                    .HasForeignKey(d => d.TeacherId)
                    .HasConstraintName("FK_Lesson_Teacher_Teachers");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.PatronomicName)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.SurName)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Students_Groups");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.PatronomicName)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.SurName)
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Teachers)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_Curators_Groups1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
