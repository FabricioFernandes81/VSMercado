using WebAdmin.Models;

namespace WebAdmin.Services
{
    public interface ILocalidadeService
    {
        Task<IEnumerable<Estado>> GetEstados();
    }
}