using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.Core
{
    public class EmployeeTaskStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TaskStatusId { get; private set; }
        [StringLength(100)]
        public string Name { get; private set; }

        public EmployeeTaskStatus(int taskStatusId, string name)
        {
            TaskStatusId = taskStatusId;
            Name = name;
        }
    }
}
