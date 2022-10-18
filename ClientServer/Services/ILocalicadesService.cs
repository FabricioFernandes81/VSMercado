using ClientServer.DTOs;

namespace ClientServer.Services
{
    public interface ILocalicadesService
    {
        Task<IEnumerable<EstadoDTO>> GetEstados();
    }
}