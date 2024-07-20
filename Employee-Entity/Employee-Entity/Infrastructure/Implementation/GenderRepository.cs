
using Employee_Entity.DBModels;
using Employee_Entity.Infrastructure.Interfaces;
using Employee_Entity.ViewModels;

namespace Employee_Entity.Infrastructure.Implementation
{
    public class GenderRepository:IGenderRepository
    {
        private EmployeeManagementContext _context;
        public GenderRepository(EmployeeManagementContext context) 
        {
            _context = context;
        
        }
        public IEnumerable<GenderVM> GenderGetAll() 
        { 
         var Result = new List<GenderVM>();
            var Genders = _context.Genders.ToList();
            if(Genders != null && Genders.Count()>0)
            {
                foreach(var gender in Genders)
                {
                    Result.Add(new GenderVM()
                    {
                        GenderName = gender.GenderName,
                        Id = gender.Id,

                    });

                }
            }
            return Result;
        }

    }
}
