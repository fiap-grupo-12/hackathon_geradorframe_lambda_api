using AutoMapper;
using FIAP.Hackathon.GeradorFrame.Lambda.Application.Models.Response;
using FIAP.Hackathon.GeradorFrame.Lambda.Domain.Entities;
using FIAP.Hackathon.GeradorFrame.Lambda.Domain.Entities.Enum;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace FIAP.Hackathon.GeradorFrame.Lambda.Infra.Data.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            //Response
            CreateMap<Solicitacao, SolicitacaoResponse>()
                .ForMember(dest => dest.StatusSolicitacao, opt => opt.MapFrom(src => src.StatusSolicitacao.GetDescription()))
                .ReverseMap();

            //Response
            CreateMap<SolicitacaoResponse, Solicitacao>().ReverseMap();

        }
    }
}
