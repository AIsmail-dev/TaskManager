using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskManager.Services
{
    public interface IEmployeeTaskService
    {
        Task<List<ProjectDTO>> GetProjectsAsync();
        Task<List<TaskStatusDTO>> GetTaskStatusesAsync();
        Task<List<EmployeeTaskDTO>> GetEmployeeTasksByEmployeeIdAsync(int employeeId);
        Task<EmployeeDTO> GetEmployee(string userName, string password);
        Task<EmployeeTaskDTO> GetEmployeeTaskById(int employeeTaskId);
        Task<EmployeeTaskDTO> AddEmployeeTask(EmployeeTaskDTO employeeTaskDTO);
    }
}
