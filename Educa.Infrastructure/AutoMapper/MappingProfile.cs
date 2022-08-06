using AutoMapper;
using Educa.Domain.Dto.Usuario.Request;
using Educa.Domain.Entities;

namespace Educa.Infrastructure.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Usuario, NovoUsuarioRequest>()
               .ReverseMap();
            CreateMap<Usuario, AtualizaUsuarioRequest>()
               .ReverseMap();

        }
    }
}