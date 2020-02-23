using TaskManager.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskManager.Data
{
    public class MainDataContext : DbContext, IMainDataContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<EmployeeTaskStatus> TaskStatuses { get; set; }
        public DbSet<EmployeeTask> EmployeeTasks { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public MainDataContext(DbContextOptions<MainDataContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<EmployeeTaskStatus>().HasData(
                new EmployeeTaskStatus(1, "In Progress"),
                new EmployeeTaskStatus(2, "Completed")
                );
            modelBuilder.Entity<Project>().HasData(
                new { ProjectId = 1, Name = "Testing Project 1" },
                new { ProjectId = 2, Name = "Testing Project 2" },
                new { ProjectId = 3, Name = "Testing Project 3" }
                );
            modelBuilder.Entity<Employee>().HasData(
                new { EmployeeId = 1, Name = "Employee 1", UserName = "user1", Password = "1234" },
                new { EmployeeId = 2, Name = "Employee 2", UserName = "user2", Password = "1234" },
                new { EmployeeId = 3, Name = "Employee 3", UserName = "user3", Password = "1234" }
                );
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var result = base.SaveChangesAsync(cancellationToken);
            return result;
        }
    }
}
