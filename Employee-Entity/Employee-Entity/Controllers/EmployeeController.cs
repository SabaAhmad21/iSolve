using Employee_Entity.Infrastructure.Implementation;
using Employee_Entity.Infrastructure.Interfaces;
using Employee_Entity.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Entity.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IGenderRepository _genderRepository;
        public EmployeeController(IEmployeeRepository employeeRepository, IGenderRepository genderRepository) 
        { 
            _employeeRepository = employeeRepository;
            _genderRepository = genderRepository;
        }
       
        public IActionResult Index()
        {
            return View();
        }

        //[Route("Employees")]
        public IActionResult Employees() 
        {
        return View(_employeeRepository.EmployeeGetAll());
        }

        public IActionResult EmployeeCreate()
        {
            return View( new EmployeeCreateVM() 
            {
                Genders =_genderRepository.GenderGetAll()
            });
        }
        [HttpPost]
        public IActionResult EmployeeCreate(EmployeeCreateVM model) 
        {
            if (ModelState.IsValid)
            {
                if (_employeeRepository.EmployeeCreate(model))
                {
                    ModelState.AddModelError("", "Employee created succeessfully!");
                } 
                else
                {
                    ModelState.AddModelError("", "Something went wrong!");
                }
                return View(new EmployeeCreateVM()
                {
                    Genders=_genderRepository.GenderGetAll()
                });

                }
            return View( new EmployeeCreateVM()
            {
                Genders=_genderRepository.GenderGetAll()
            });

            }
        public IActionResult IsRegistrationNumberExists(string registrationNumber)
        {
            return Json(!_employeeRepository.IsRegistrationNumberExist(registrationNumber));
        }
        public IActionResult EmployeeDelete(int id)
        {
            _employeeRepository.EmployeeDelete(id);
            return RedirectToAction("Employees", new { controller = "Employee" });
        }
        
        public IActionResult EmployeeUpdate(int id)
        {
           return View (_employeeRepository.EmployeeGetById(id));
           
        }
        [HttpPost]
        public IActionResult EmployeeUpdate(EmployeeUpdateVM model)
        {
            _employeeRepository.EmployeeUpdate(model);
            return RedirectToAction("Employees", new { Controller = "Employee" });
        }
        }
    }

