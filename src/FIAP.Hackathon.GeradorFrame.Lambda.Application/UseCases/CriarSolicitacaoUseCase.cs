using AutoMapper;
using FIAP.Hackathon.GeradorFrame.Lambda.Application.Models.Response;
using FIAP.Hackathon.GeradorFrame.Lambda.Application.Services;
using FIAP.Hackathon.GeradorFrame.Lambda.Application.Services.Interfaces;
using FIAP.Hackathon.GeradorFrame.Lambda.Application.UseCases.Interfaces;
using FIAP.Hackathon.GeradorFrame.Lambda.Domain.Entities;
using FIAP.Hackathon.GeradorFrame.Lambda.Domain.Entities.Enum;
using FIAP.Hackathon.GeradorFrame.Lambda.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAP.Hackathon.GeradorFrame.Lambda.Application.UseCases
{
    public class CriarSolicitacaoUseCase(
        IS3Service s3Service,
        IJwtService jwtService,
        ISolicitacaoRepository solicitacaoRepository,
        IMapper mapper
        ) : ICriarSolicitacaoUseCase
    {
        private readonly IS3Service _s3Service = s3Service;
        private readonly IJwtService _jwtService = jwtService;
        private readonly ISolicitacaoRepository _solicitacaoRepository = solicitacaoRepository;
        private readonly IMapper _mapper = mapper;

        async Task<SolicitacaoResponse> IUseCaseAsync<string, SolicitacaoResponse>.Execute(string jwt)
        {
            var solicitacao = new Solicitacao()
            {
                Id = Guid.NewGuid(),
                Email = _jwtService.GetEmail(jwt),
                DataCriacao = DateTime.Now,
                StatusSolicitacao = StatusSolicitacao.Pendente,
            };

            var result = await _solicitacaoRepository.Post(solicitacao);

            result.Url = await _s3Service.CreateUrlToUpload(result.Id);

            return _mapper.Map<SolicitacaoResponse>(result);
        }
    }
}
