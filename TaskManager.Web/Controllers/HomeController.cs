using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TaskManager.Web.Models;
using TaskManager.Services;

namespace TaskManager.Web.Controllers
{
    public class HomeController : Controller
    {
        public IEmployeeTaskService EmployeeTaskService { get; }

        //private readonly ILogger<HomeController> _logger;

        public HomeController(/*ILogger<HomeController> logger*/IEmployeeTaskService employeeTaskService)
        {
            EmployeeTaskService = employeeTaskService;
            //_logger = logger;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var employeeTaskList = await EmployeeTaskService.GetEmployeeTasksByEmployeeIdAsync(1);
            return View(/*employeeTaskList*/);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
