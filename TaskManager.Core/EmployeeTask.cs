using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.Core
{
    public class EmployeeTask
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeTaskId { get; private set; }
        [StringLength(100)]
        public string TaskTitle { get; private set; }
        [StringLength(1000)]
        public string Description { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime ExpectedDate { get; private set; }
        public DateTime EndDate { get; private set; }

        [ForeignKey(nameof(Project))]
        public int? ProjectId { get; private set; }
        public Project Project { get; private set; }

        [ForeignKey(nameof(TaskStatus))]
        public int? TaskStatusId { get; private set; }
        public EmployeeTaskStatus TaskStatus { get; private set; }

        [ForeignKey(nameof(Employee))]
        public int? EmployeeId { get; private set; }
        public Employee Employee { get; private set; }

        public EmployeeTask()
        { }

        public EmployeeTask(string title, string description, int employeeId, int projectId, DateTime startDate, DateTime expectedDate, int taskStatusId, DateTime endDate)
        {
            TaskTitle = title;
            Description = description;
            EmployeeId = employeeId;
            ProjectId = projectId;
            StartDate = startDate;
            ExpectedDate = expectedDate;
            TaskStatusId = taskStatusId;
            EndDate = endDate;
        }
    }
}
