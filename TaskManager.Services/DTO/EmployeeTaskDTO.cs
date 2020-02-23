using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.Services
{
    public class EmployeeTaskDTO
    {
        public int EmployeeTaskId { get; set; }
        public string TaskTitle { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpectedDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public int TaskStatusId { get; set; }
        public string TaskStatusName { get; set; }
        public Dictionary<int, string> Projects { get; set; } = new Dictionary<int, string> { };
        public Dictionary<int, string> TaskStatuses { get; set; } = new Dictionary<int, string> { };
    }
}
