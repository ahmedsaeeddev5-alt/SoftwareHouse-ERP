using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Task_Management_API.Data.Models;

namespace Task_Management_API.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<TaskItem> Tasks { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<ProjectMember> ProjectMembers { get; set; }
        public DbSet<Milestone> Milestones { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Attendance> Attendances { get; set; }

        public DbSet<LeaveRequest> LeaveRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // =========================
            // TaskItem -> AppUser
            // =========================

            modelBuilder.Entity<TaskItem>()
                .HasOne(t => t.User)
                .WithMany(u => u.TaskItems)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Cascade);


            // =========================
            // Department -> Employee
            // =========================

            modelBuilder.Entity<Department>()
                .HasMany(d => d.Employees)
                .WithOne(e => e.Department)
                .HasForeignKey(e => e.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);


            // =========================
            // Employee -> AppUser
            // =========================

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.User)
                .WithOne(u => u.Employee)
                .HasForeignKey<Employee>(e => e.UserId)
                .OnDelete(DeleteBehavior.SetNull);


            // =========================
            // Client -> Project
            // =========================

            modelBuilder.Entity<Project>()
                .HasOne(p => p.Client)
                .WithMany(c => c.Projects)
                .HasForeignKey(p => p.ClientId)
                .OnDelete(DeleteBehavior.Restrict);


            // =========================
            // Project -> ProjectMember
            // =========================

            modelBuilder.Entity<ProjectMember>()
                .HasOne(pm => pm.Project)
                .WithMany(p => p.ProjectMembers)
                .HasForeignKey(pm => pm.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);


            // =========================
            // Employee -> ProjectMember
            // =========================

            modelBuilder.Entity<ProjectMember>()
                .HasOne(pm => pm.Employee)
                .WithMany(e => e.ProjectMembers)
                .HasForeignKey(pm => pm.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);


            // =========================
            // Project -> Task
            // =========================

            modelBuilder.Entity<TaskItem>()
                .HasOne(t => t.Project)
                .WithMany(p => p.Tasks)
                .HasForeignKey(t => t.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);


            // =========================
            // Employee -> Task
            // =========================

            modelBuilder.Entity<TaskItem>()
                .HasOne(t => t.Employee)
                .WithMany()
                .HasForeignKey(t => t.EmployeeId)
                .OnDelete(DeleteBehavior.SetNull);


            // =========================
            // Money Precision
            // =========================

            modelBuilder.Entity<Employee>()
                .Property(e => e.Salary)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Project>()
                .Property(p => p.Budget)
                .HasPrecision(18, 2);
            // =========================
            // Project -> Milestones
            // =========================

            modelBuilder.Entity<Milestone>()
                .HasOne(m => m.Project)
                .WithMany()
                .HasForeignKey(m => m.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Contract>()
       .Property(c => c.TotalAmount)
       .HasPrecision(18, 2);

            modelBuilder.Entity<Contract>()
                .HasOne(c => c.Client)
                .WithMany()
                .HasForeignKey(c => c.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Contract>()
                .HasOne(c => c.Project)
                .WithMany()
                .HasForeignKey(c => c.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Invoice>()
    .Property(i => i.Amount)
    .HasPrecision(18, 2);

            modelBuilder.Entity<Invoice>()
                .Property(i => i.TaxAmount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Invoice>()
                .Property(i => i.TotalAmount)
                .HasPrecision(18, 2);
            modelBuilder.Entity<Invoice>()
    .HasOne(i => i.Contract)
    .WithMany()
    .HasForeignKey(i => i.ContractId)
    .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Payment>()
    .Property(p => p.Amount)
    .HasPrecision(18, 2);

            modelBuilder.Entity<Payment>()
                .Property(p => p.PaymentNumber)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Payment>()
                .Property(p => p.PaymentMethod)
                .IsRequired()
                .HasMaxLength(30);

            modelBuilder.Entity<Payment>()
                .Property(p => p.Currency)
                .IsRequired()
                .HasMaxLength(10);

            modelBuilder.Entity<Payment>()
                .Property(p => p.Status)
                .IsRequired()
                .HasMaxLength(20);

            modelBuilder.Entity<Payment>()
                .Property(p => p.Reference)
                .HasMaxLength(100);

            modelBuilder.Entity<Payment>()
                .Property(p => p.Notes)
                .HasMaxLength(500);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Invoice)
                .WithMany()
                .HasForeignKey(p => p.InvoiceId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Expense>()
    .Property(e => e.Amount)
    .HasPrecision(18, 2);

            modelBuilder.Entity<Expense>()
                .Property(e => e.ExpenseNumber)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Expense>()
                .Property(e => e.Currency)
                .IsRequired()
                .HasMaxLength(10);

            modelBuilder.Entity<Expense>()
                .Property(e => e.Category)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Expense>()
                .Property(e => e.Status)
                .IsRequired()
                .HasMaxLength(20);

            modelBuilder.Entity<Expense>()
                .Property(e => e.Description)
                .HasMaxLength(500);

            modelBuilder.Entity<Expense>()
                .HasOne(e => e.Project)
                .WithMany()
                .HasForeignKey(e => e.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Attendance>()
    .Property(a => a.Status)
    .IsRequired()
    .HasMaxLength(20);

            modelBuilder.Entity<Attendance>()
                .Property(a => a.Notes)
                .HasMaxLength(500);

            modelBuilder.Entity<Attendance>()
                .HasOne(a => a.Employee)
                .WithMany()
                .HasForeignKey(a => a.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<LeaveRequest>()
                .Property(l => l.LeaveType)
                .IsRequired()
                .HasMaxLength(30);

            modelBuilder.Entity<LeaveRequest>()
                .Property(l => l.Status)
                .IsRequired()
                .HasMaxLength(20);

            modelBuilder.Entity<LeaveRequest>()
                .Property(l => l.Reason)
                .HasMaxLength(500);

            modelBuilder.Entity<LeaveRequest>()
                .Property(l => l.Notes)
                .HasMaxLength(500);

            modelBuilder.Entity<LeaveRequest>()
                .HasOne(l => l.Employee)
                .WithMany()
                .HasForeignKey(l => l.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);
        }


    }
}