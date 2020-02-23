using AutoMapper;
using TaskManager.Core;
using TaskManager.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace TaskManager.Services
{
    public class EmployeeTaskService : IEmployeeTaskService
    {
        public IMainDataContext MainDataContext { get; }
        public IMapper Mapper { get; }
        public IHttpContextAccessor HttpContextAccessor { get; }

        public EmployeeTaskService(IMainDataContext mainDataContext, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            MainDataContext = mainDataContext;
            Mapper = mapper;
            HttpContextAccessor = httpContextAccessor;
        }

        public async Task<EmployeeDTO> GetEmployee(string userName, string password)
        {
            var employee = await MainDataContext.Employees.Where(e => e.UserName == userName && e.Password == password).FirstOrDefaultAsync();
            return Mapper.Map<EmployeeDTO>(employee);
        }

        public async Task<List<EmployeeTaskDTO>> GetEmployeeTasksByEmployeeIdAsync(int employeeId)
        {
            var employeeTasks = await MainDataContext.EmployeeTasks
                                                    .Include(t => t.Project)
                                                    .Include(t => t.TaskStatus)
                                                    .Where(t => t.EmployeeId == employeeId).ToListAsync();
            return Mapper.Map<List<EmployeeTaskDTO>>(employeeTasks);
        }

        public async Task<List<ProjectDTO>> GetProjectsAsync()
        {
            var projects = await MainDataContext.Projects.ToListAsync();
            return Mapper.Map<List<ProjectDTO>>(projects);
        }

        public async Task<List<TaskStatusDTO>> GetTaskStatusesAsync()
        {
            var taskStatuses = await MainDataContext.TaskStatuses.ToListAsync();
            return Mapper.Map<List<TaskStatusDTO>>(taskStatuses);
        }

        public async Task<EmployeeTaskDTO> GetEmployeeTaskById(int employeeTaskId)
        {
            var employeeTask = await MainDataContext.EmployeeTasks.Where(e => e.EmployeeTaskId == employeeTaskId).FirstOrDefaultAsync();
            return Mapper.Map<EmployeeTaskDTO>(employeeTask);
        }

        public async Task<EmployeeTaskDTO> AddEmployeeTask(EmployeeTaskDTO employeeTaskDTO)
        {
            int employeeId = int.Parse(HttpContextAccessor.HttpContext.User.Claims.FirstOrDefault(a => a.Type == ClaimTypes.NameIdentifier).Value);
            var employeeTask = new EmployeeTask(employeeTaskDTO.TaskTitle, employeeTaskDTO.Description, employeeId, employeeTaskDTO.ProjectId, employeeTaskDTO.StartDate, employeeTaskDTO.ExpectedDate, employeeTaskDTO.TaskStatusId, employeeTaskDTO.EndDate);
            MainDataContext.EmployeeTasks.Add(employeeTask);
            await MainDataContext.SaveChangesAsync();
            return Mapper.Map<EmployeeTaskDTO>(employeeTask);
        }
    }
}
