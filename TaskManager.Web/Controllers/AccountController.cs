using TaskManager.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace TaskManager.Web.Controllers
{
    public class AccountController : Controller
    {
        public AccountController(IEmployeeTaskService employeeTaskService)
        {
            EmployeeTaskService = employeeTaskService;
        }

        public IEmployeeTaskService EmployeeTaskService { get; }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> LoginAsync([Bind]EmployeeDTO employeeDTO)
        {
            employeeDTO = await EmployeeTaskService.GetEmployee(employeeDTO.UserName, employeeDTO.Password);
            if (employeeDTO != null)
            {
                var userClaims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, employeeDTO.Name),
                    new Claim(ClaimTypes.NameIdentifier, employeeDTO.EmployeeId.ToString())
                 };
                var grandmaIdentity = new ClaimsIdentity(userClaims, "User Identity");
                var userPrincipal = new ClaimsPrincipal(new[] { grandmaIdentity });
                await HttpContext.SignInAsync(userPrincipal);
                return RedirectToAction("Index", "EmployeeTaskList");
            }
            return View(employeeDTO);
        }

        public async Task<ActionResult> LogoutAsync()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }
    }
}