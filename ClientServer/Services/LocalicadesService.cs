using AutoMapper;
using ClientServer.Context;
using ClientServer.DTOs;
using Microsoft.EntityFrameworkCore;

namespace ClientServer.Services
{
    public class LocalicadesService : ILocalicadesService
    {
        public readonly AppDbContext _appDbContext;
        private IMapper _mapper;

        public LocalicadesService(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EstadoDTO>> GetEstados()
        {
            var estadoEntity = await _appDbContext.estados.Include(p => p.City).ToListAsync();

            return _mapper.Map<IEnumerable<EstadoDTO>>(estadoEntity);
        }
    }
}
