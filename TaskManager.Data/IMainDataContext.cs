using TaskManager.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskManager.Data
{
    public interface IMainDataContext
    {
        DbSet<Project> Projects { get; set; }
        DbSet<EmployeeTaskStatus> TaskStatuses { get; set; }
        DbSet<EmployeeTask> EmployeeTasks { get; set; }
        DbSet<Employee> Employees { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}
