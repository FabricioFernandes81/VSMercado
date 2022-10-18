using AutoMapper;
using ClientServer.DTOs;
using ClientServer.Models;

namespace ClientServer.Utils
{
    public class Mapping:Profile
    {
        public Mapping()
        {
            CreateMap<Estados, EstadoDTO>().ReverseMap();
            CreateMap<Cidades,MunicipiosDTO>().ReverseMap();
            CreateMap<Empresa, RegistroDTO>().ReverseMap();
        }
    }
}
