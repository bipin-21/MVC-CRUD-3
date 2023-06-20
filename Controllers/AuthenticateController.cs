using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCCRUD2.Data;
using MVCCRUD2.Models;

namespace MVCCRUD2.Controllers
{
    public class AuthenticateController : Controller
    {
        private readonly ApplicationContext context;

        public AuthenticateController(ApplicationContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public IActionResult Login()
        {
            // var employees = await mvcDemoDbContext.Employees.Where(x => x.RecStatus == 'A').OrderBy(x => x.Username).ToListAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Employee emp)
        {
            if (emp.Username == "Bipin" && emp.Password == "123")
            {
                // Authentication successful
                var employees = await context.Employees.Where(x => x.Username == emp.Username && x.Password == emp.Password).ToListAsync();
                return RedirectToAction("Index", "Employees", employees);
            }

            ModelState.AddModelError("", "Invalid username or password.");

            TempData["ErrorMessage"] = "Invalid username or password.";
            return View();
        }
    }
}
