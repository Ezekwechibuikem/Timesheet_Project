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

        public virtual DbSet<EmpProject> EmpProjects { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Timesheet> Timesheets { get; set; } = null!;
        public virtual DbSet<TimesheetActionLog> TimesheetActionLogs { get; set; } = null!;
        public virtual DbSet<TimesheetItem> TimesheetItems { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmpProject>(entity =>
            {
                entity.HasKey(e => e.ProjectId)
                    .HasName("PK__EmpProje__BC799E1F5ADE9DCA");

                entity.ToTable("EmpProject");

                entity.Property(e => e.ProjectId).HasColumnName("project_id");

                entity.Property(e => e.EmpId).HasColumnName("emp_id");

                entity.Property(e => e.ProjectName)
                    .HasMaxLength(50)
                    .HasColumnName("project_name");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.EmpProjects)
                    .HasForeignKey(d => d.EmpId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmpProjec__emp_i__3F466844");
            });

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
                    .HasConstraintName("FK__Timesheet__emp_i__398D8EEE");
            });

            modelBuilder.Entity<TimesheetActionLog>(entity =>
            {
                entity.ToTable("TimesheetActionLog");

                entity.Property(e => e.TimesheetActionLogId).HasColumnName("timesheet_action_log_id");

                entity.Property(e => e.Action)
                    .HasMaxLength(50)
                    .HasColumnName("action");

                entity.Property(e => e.Comment)
                    .HasMaxLength(255)
                    .HasColumnName("comment");

                entity.Property(e => e.DateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("date_time");

                entity.Property(e => e.PerformedBy).HasColumnName("performed_by");

                entity.Property(e => e.TimesheetId).HasColumnName("timesheet_id");

                entity.HasOne(d => d.Timesheet)
                    .WithMany(p => p.TimesheetActionLogs)
                    .HasForeignKey(d => d.TimesheetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Timesheet__times__3C69FB99");
            });

            modelBuilder.Entity<TimesheetItem>(entity =>
            {
                entity.ToTable("TimesheetItem");

                entity.Property(e => e.TimesheetItemId).HasColumnName("timesheet_item_id");

                entity.Property(e => e.AbsenceId).HasColumnName("absence_id");

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
                    .HasConstraintName("FK__Timesheet__emp_i__4222D4EF");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.TimesheetItems)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Timesheet__proje__4316F928");

                entity.HasOne(d => d.Timesheet)
                    .WithMany(p => p.TimesheetItems)
                    .HasForeignKey(d => d.TimesheetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Timesheet__times__440B1D61");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
