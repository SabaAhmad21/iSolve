
using Employee_Entity.Infrastructure.Interfaces;
using Employee_Entity.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Employee_Entity.Infrastructure.Implementation
{
    public class EmployeeRepository:IEmployeeRepository
    {
        private readonly Employee_Entity.DBModels.EmployeeManagementContext _context;
        private readonly IGenderRepository _genderRepository;

        private readonly List<Employee> _employees;

        public EmployeeRepository(IGenderRepository genderRepository, Employee_Entity.DBModels.EmployeeManagementContext context) 
        
        { 
            _context = context;
            _genderRepository = genderRepository;
            //    _employees = new List<Employee>();
            //    _employees.Add(new Employee()
            //    {
            //        Id = 1,
            //        EmployeeName = "Ahmad",
            //        RegistrationNumber ="SE-1245",
            //        PhoneNumber ="333-178967",
            //        Department= "Machenical Engineering"
            //    });
            //    _employees.Add(new Employee()
            //    {
            //        Id = 2,
            //        EmployeeName = "Omer",
            //        Department = "Physics",
            //        PhoneNumber = "334768954",
            //        RegistrationNumber = "RS-1246"
            //    });
            //    _employees.Add(new Employee()
            //    {

            //        Id = 3,
            //        EmployeeName = "Ahmad",
            //        Department = "General",
            //        PhoneNumber = "3367665643",
            //        RegistrationNumber = "RS-1247"
            //    });


        }
        public IEnumerable<Employee> EmployeeGetAll()
        {
            var employees = new List<Employee>();   
            var employee = _context.Employees.Include(p => p.Gender).OrderByDescending(p=>p.Id).ToList();
            if(employee != null && employee.Count()>0)
            {
                foreach(var item in employee)
                {
                    
                    employees.Add(new Employee()
                    {
                        Id= item.Id,
                        EmployeeName = item.EmployeeName,
                        Department= item.Department,
                        PhoneNumber= item.PhoneNumber,
                        RegistrationNumber = item.RegistrationNumber,
                        Gender = item.Gender.GenderName
                    });

                }
            }
            return employees;
        }
        public bool EmployeeCreate(EmployeeCreateVM employee)
        {
            var Entity = new Employee_Entity.DBModels.Employee()
            {
                EmployeeName = employee.EmployeeName,
                Department = employee.Department,
                PhoneNumber = employee.PhoneNumber,
                RegistrationNumber = employee.RegiastrationNumber,
                GenderID = employee.GenderId,

            };  
            _context.Add(Entity);
            _context.SaveChanges();

            return true;
        }
        public bool IsRegistrationNumberExist(string registrationNumber)
        {
            if(_context.Employees.Where(p => p.RegistrationNumber.Equals(registrationNumber)).Any())
            {
                return true;
            }
            else 
            { 
                return false; 
            }
        }
        public bool EmployeeDelete(int id)
        {

            var employee = _context.Employees.Where(p=>p.Id == id).FirstOrDefault();
            _context.Remove(employee);
            _context.SaveChanges();
            return true;

        }
        public EmployeeUpdateVM EmployeeGetById(int Id)
        {

            var employee = _context.Employees.Where(p => p.Id == Id).FirstOrDefault();
            if(employee != null)
            {
                return new EmployeeUpdateVM
                {
                    EmployeeName=employee.EmployeeName,
                    Department = employee.Department,
                    PhoneNumber = employee.PhoneNumber,
                    RegiastrationNumber=employee.RegistrationNumber,
                    GenderId=employee.GenderID,
                    Genders=_genderRepository.GenderGetAll(),
                };
            }
            else
            {
                return null;
            }
        }

        public EmployeeVM GetEmployeeById(int Id)
        {

            var employee = _context.Employees.Where(p => p.Id == Id).FirstOrDefault();
            if (employee != null)
            {
                return new EmployeeVM
                {
                    EmployeeName = employee.EmployeeName,
                    Department = employee.Department,
                    PhoneNumber = employee.PhoneNumber,
                    RegiastrationNumber = employee.RegistrationNumber                    
                };
            }
            else
            {
                return null;
            }
        }

        public bool EmployeeUpdate(EmployeeUpdateVM model)
        {
            var employee= _context.Employees.Where(p => p.Id ==model.EmployeeId).FirstOrDefault();
            if(employee != null)
            {
                employee.EmployeeName = model.EmployeeName;
                employee.Department = model.Department;
                employee.PhoneNumber = model.PhoneNumber;
                employee.RegistrationNumber = model.RegiastrationNumber;
                employee.GenderID = model.GenderId;
               
                
                _context.Update(employee);
                _context.SaveChanges();

            }
          
            return true;
        }
    }


}
