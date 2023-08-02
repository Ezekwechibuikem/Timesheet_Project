using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Timesheet_Project.Models
{
    public partial class TimesheetDBContext : DbContext
    {
        public TimesheetDBContext()
        {
        }

        public TimesheetDBContext(DbContextOptions<TimesheetDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Project> Projects { get; set; } = null!;
        public virtual DbSet<Timesheet> Timesheets { get; set; } = null!;
        public virtual DbSet<TimesheetItem> TimesheetItems { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Department)
                    .HasMaxLength(50)
                    .HasColumnName("department");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(50)
                    .HasColumnName("firstname");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("Project");

                entity.Property(e => e.ProjectId).HasColumnName("project_id");

                entity.Property(e => e.ProjectName)
                    .HasMaxLength(50)
                    .HasColumnName("project_name");
            });

            modelBuilder.Entity<Timesheet>(entity =>
            {
                entity.ToTable("Timesheet");

                entity.Property(e => e.TimesheetId).HasColumnName("timesheet_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.EmpId).HasColumnName("emp_id");

                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasColumnName("end_date");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("start_date");

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .HasColumnName("state");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.Timesheets)
                    .HasForeignKey(d => d.EmpId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Timesheet__emp_i__17F790F9");
            });

            modelBuilder.Entity<TimesheetItem>(entity =>
            {
                entity.ToTable("TimesheetItem");

                entity.Property(e => e.TimesheetItemId).HasColumnName("timesheet_item_id");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.EmpId).HasColumnName("emp_id");

                entity.Property(e => e.ProjectId).HasColumnName("project_id");

                entity.Property(e => e.Signature).HasColumnName("signature");

                entity.Property(e => e.Summary)
                    .HasMaxLength(500)
                    .HasColumnName("summary");

                entity.Property(e => e.TimesheetId).HasColumnName("timesheet_id");

                entity.Property(e => e.WkDuration).HasColumnName("wk_duration");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.TimesheetItems)
                    .HasForeignKey(d => d.EmpId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Timesheet__emp_i__3C34F16F");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.TimesheetItems)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Timesheet__proje__3D2915A8");

                entity.HasOne(d => d.Timesheet)
                    .WithMany(p => p.TimesheetItems)
                    .HasForeignKey(d => d.TimesheetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Timesheet__times__3E1D39E1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
