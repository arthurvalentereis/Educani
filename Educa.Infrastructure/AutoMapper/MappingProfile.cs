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
                .ForMember(dest => dest.Nome, src => src.MapFrom(src => src.Nome))
                .ForMember(dest => dest.Sobrenome, src => src.MapFrom(src => src.Sobrenome))
                .ForMember(dest => dest.Email, src => src.MapFrom(src => src.Email))
                .ForMember(dest => dest.DataNascimento, src => src.MapFrom(src => src.DataNascimento))
                .ForMember(dest => dest.EscolaridadeId, src => src.MapFrom(src => src.EscolaridadeId))
                .ForMember(dest => dest.HistoricoEscolar, i => i.Ignore());

            CreateMap<NovoUsuarioRequest, Usuario>()
               .ForMember(dest => dest.Nome, src => src.MapFrom(src => src.Nome))
               .ForMember(dest => dest.Sobrenome, src => src.MapFrom(src => src.Sobrenome))
               .ForMember(dest => dest.Email, src => src.MapFrom(src => src.Email))
               .ForMember(dest => dest.DataNascimento, src => src.MapFrom(src => src.DataNascimento))
               .ForMember(dest => dest.EscolaridadeId, src => src.MapFrom(src => src.EscolaridadeId))
               .ForMember(dest => dest.HistoricoEscolar, i => i.Ignore());

            CreateMap<Usuario, AtualizaUsuarioRequest>()
               .ReverseMap();

        }
    }
}