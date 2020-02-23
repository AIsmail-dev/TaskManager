using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManager.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskManager.Web.Controllers
{
    [Route("api/EmployeeTask")]
    public class EmployeeTaskController : Controller
    {
        public IEmployeeTaskService EmployeeTaskService { get; }

        public EmployeeTaskController(IEmployeeTaskService employeeTaskService)
        {
            EmployeeTaskService = employeeTaskService;
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<IEnumerable<EmployeeTaskDTO>> Get()
        {
            return await EmployeeTaskService.GetEmployeeTasksByEmployeeIdAsync(1);
        }

        // GET: api/<controller>/GetProjects
        [HttpGet("GetProjects")]
        public async Task<IEnumerable<ProjectDTO>> GetProjects()
        {
            return await EmployeeTaskService.GetProjectsAsync();
        }

        // GET: api/<controller>/GetProjects
        [HttpGet("GetTaskStatuses")]
        public async Task<IEnumerable<TaskStatusDTO>> GetTaskStatuses()
        {
            return await EmployeeTaskService.GetTaskStatusesAsync();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<EmployeeTaskDTO> GetAsync(int id)
        {
            return await EmployeeTaskService.GetEmployeeTaskById(id);
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<EmployeeTaskDTO> Post()
        {
            EmployeeTaskDTO employeeTaskDTO = new EmployeeTaskDTO();
            return await EmployeeTaskService.AddEmployeeTask(employeeTaskDTO);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
