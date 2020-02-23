using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.Core
{
    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProjectId { get; private set; }
        [StringLength(500)]
        public string Name { get; private set; }
        public Project(string name)
        {
            Name = name;
        }
    }
}
