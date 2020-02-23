using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Services;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace TaskManager.Web.Controllers
{
    [Authorize]
    public class EmployeeTaskListController : Controller
    {
        public IEmployeeTaskService EmployeeTaskService { get; }

        public EmployeeTaskListController(IEmployeeTaskService employeeTaskService)
        {
            EmployeeTaskService = employeeTaskService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            int employeeId = int.Parse(User.Claims.FirstOrDefault(a => a.Type == ClaimTypes.NameIdentifier).Value);
            var employeeTaskList = await EmployeeTaskService.GetEmployeeTasksByEmployeeIdAsync(employeeId);
            return View(employeeTaskList);
        }

        public async Task<IActionResult> CreateAsync()
        {
            EmployeeTaskDTO employeeTaskDTO = new EmployeeTaskDTO
            {
                Projects = (await EmployeeTaskService.GetProjectsAsync()).ToDictionary(a => a.ProjectId, a => a.Name),
                TaskStatuses = (await EmployeeTaskService.GetTaskStatusesAsync()).ToDictionary(a => a.TaskStatusId, a => a.Name)
            };
            return View(employeeTaskDTO);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployeeTaskAsync([FromForm]EmployeeTaskDTO employeeTaskDTO)
        {
            await EmployeeTaskService.AddEmployeeTask(employeeTaskDTO);
            return RedirectToAction("Index");
        }
    }
}
