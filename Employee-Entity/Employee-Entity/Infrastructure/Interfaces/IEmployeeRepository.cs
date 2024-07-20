using Employee_Entity.ViewModels;

namespace Employee_Entity.Infrastructure.Interfaces
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> EmployeeGetAll();

        bool EmployeeCreate(EmployeeCreateVM employee);

        bool IsRegistrationNumberExist(string registrationNumber);

        bool EmployeeDelete(int id);

        EmployeeUpdateVM EmployeeGetById(int Id);

        bool EmployeeUpdate(EmployeeUpdateVM model);
    }
}
