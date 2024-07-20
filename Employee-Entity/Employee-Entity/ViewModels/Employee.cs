using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Employee_Entity.ViewModels;

namespace Employee_Entity.ViewModels
{
    public class Employee
    {
        public int Id { get; set; }

        public string EmployeeName { get; set; }

        public string Department { get; set; }

        public string PhoneNumber { get; set; }

        public string RegistrationNumber { get; set; }

        public string Gender { get; set; }
    }
    public class EmployeeCreateVM
    {
        public EmployeeCreateVM()
        {
            Genders = new List<GenderVM>();
        }

        [Required(ErrorMessage = "Employee Name is required!")]
        [DisplayName("Employee Name")]
        public string EmployeeName { get; set; } = null!;

        [Required(ErrorMessage = "Employee Department is required!")]
        [DisplayName("Department Name")]
        public string Department { get; set; } = null!;

        [Required(ErrorMessage = "Registration Number is required!")]
        [DisplayName("Registration Number")]
        public string RegiastrationNumber { get; set; } = null!;

        [Required(ErrorMessage = "Phone Number is required!")]
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; } = null!;

        [Required(ErrorMessage = "Select Gender")]
        [Range(1, int.MaxValue)]
        public int GenderId { get; set; }

        public IEnumerable<GenderVM> Genders { get; set; }
    }

    public class EmployeeUpdateVM
    {
    public EmployeeUpdateVM()
    {
        Genders = new List<GenderVM>();
    }

    [Required]
    [Range(1, int.MaxValue)]
    public int EmployeeId { get; set; }

    [Required(ErrorMessage = "Employee Name is required!")]
    [DisplayName("Employee Name")]
    public string EmployeeName { get; set; } = null!;

    [Required(ErrorMessage = "Employee Department is required!")]
    [DisplayName("Department Name")]
    public string Department { get; set; } = null!;

    [Required(ErrorMessage = "Registration Number is required!")]
    [DisplayName("Registration Number")]
    public string RegiastrationNumber { get; set; } = null!;

    [Required(ErrorMessage = "Phone Number is required!")]
    [DisplayName("Phone Number")]
    public string PhoneNumber { get; set; } = null!;

    [Required(ErrorMessage = "Select Gender")]
    [Range(1, int.MaxValue)]
    public int GenderId { get; set; }

    public IEnumerable<GenderVM> Genders { get; set; }

}

    public class EmployeeVM
    {
        public EmployeeVM()
        {
        }

        [Required]
        [Range(1, int.MaxValue)]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Employee Name is required!")]
        [DisplayName("Employee Name")]
        public string EmployeeName { get; set; } = null!;

        [Required(ErrorMessage = "Employee Department is required!")]
        [DisplayName("Department Name")]
        public string Department { get; set; } = null!;

        [Required(ErrorMessage = "Registration Number is required!")]
        [DisplayName("Registration Number")]
        public string RegiastrationNumber { get; set; } = null!;

        [Required(ErrorMessage = "Phone Number is required!")]
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; } = null!;


    }


}
