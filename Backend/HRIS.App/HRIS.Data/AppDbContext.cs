using HRIS.Core.Entities;
using HRIS.Core.Entities.Leave_Entities;
using HRIS.Core.Entities.UserEntities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace HRIS.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Branch> Branches { get; set; }

        public DbSet<EmployeeDetails> Employee_Details { get; set; }

        public DbSet<EducationalBg> EducationalBackground { get; set; }

        public DbSet<EmploymentBackground> EmploymentBackgrounds { get; set; }

        public DbSet<Salary> Salaries { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Requirement> Requirements { get; set; }
        public DbSet <Paymast> Paymasts { get; set; }

        public DbSet<Benefit> Benefits { get; set; }

        public DbSet <ApexMerch> ApexMerches { get; set; }

        public DbSet<User> User { get; set; }

        public DbSet<LeaveEntities> Leaves { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EmployeeDetails>()
            .Property(e => e.BirthDate)
            .HasDefaultValueSql(null);
            modelBuilder.Entity<EmployeeDetails>()
            .Property(e => e.EmpDate)
            .HasDefaultValueSql(null);
            modelBuilder.Entity<EmployeeDetails>()
            .Property(e => e.DesigDate)
            .HasDefaultValueSql(null);
            modelBuilder.Entity<EmployeeDetails>()
            .Property(e => e.SepDate)
            .HasDefaultValueSql(null);
            modelBuilder.Entity<EmployeeDetails>()
            .Property(e => e.SalesDate)
            .HasDefaultValueSql(null);
            modelBuilder.Entity<EmployeeDetails>()
            .Property(e => e.EvalDate)
            .HasDefaultValueSql(null);
            modelBuilder.Entity<EmployeeDetails>()
            .Property(e => e.EffDate)
            .HasDefaultValueSql(null);
            modelBuilder.Entity<User>()
            .HasOne(u => u.employeeDetails)
            .WithMany()
            .HasForeignKey(u => u.EmployeeId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
