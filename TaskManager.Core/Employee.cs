using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.Core
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; private set; }
        [StringLength(500)]
        public string Name { get; private set; }
        [StringLength(50)]
        public string UserName { get; private set; }
        [StringLength(50)]
        public string Password { get; private set; }
        public Employee(string name, string userName, string password)
        {
            Name = name;
            UserName = userName;
            Password = password;
        }
    }
}
