using Employee_Entity.ViewModels;
using Employee_Entity.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Employee_Entity.Controllers
{



    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IGenderRepository _genderRepository;
        public EmployeesController(IEmployeeRepository employeeRepository, IGenderRepository genderRepository)
        {
            _employeeRepository = employeeRepository;
            _genderRepository = genderRepository;
        }



        // GET: api/<EmployeesController>
        [HttpGet]
       
        public IEnumerable<ViewModels.Employee> Get()
        {
            return _employeeRepository.EmployeeGetAll();
            //return new string[] { "value1", "value2" };
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var employee = _employeeRepository.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(employee);
            }
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public IActionResult Post([FromBody] EmployeeCreateVM model)
        {
            if (_employeeRepository.EmployeeCreate(model))
                return Ok();
            else
            {
                return BadRequest();
            }
        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
