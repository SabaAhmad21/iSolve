using Employee_Entity.ViewModels;

namespace Employee_Entity.Infrastructure.Interfaces
{
    public interface IGenderRepository
    {
        IEnumerable<GenderVM> GenderGetAll();
    }
}
