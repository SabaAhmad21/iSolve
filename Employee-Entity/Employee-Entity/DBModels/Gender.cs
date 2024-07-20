namespace Employee_Entity.DBModels
{
    public class Gender
    {
        public int Id { get; set; }

        public string GenderName { get; set; }

        public ICollection<Employee> Employees { get; set; }


    }
}
