namespace Employee_Entity.DBModels
{
    public class Employee
    {
        public int Id { get; set; }

        public string EmployeeName { get; set; }

        public string Department { get; set; }

        public string PhoneNumber { get; set; }

        public string RegistrationNumber { get; set; }

        public int GenderID { get; set; }

        public virtual Gender Gender { get; set; }
    }
}

