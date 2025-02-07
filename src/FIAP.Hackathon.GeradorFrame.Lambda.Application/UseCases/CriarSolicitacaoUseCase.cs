using AutoMapper;
using FIAP.Hackathon.GeradorFrame.Lambda.Application.Models.Response;
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
        ISolicitacaoRepository solicitacaoRepository,
        IMapper mapper
        ) : ICriarSolicitacaoUseCase
    {
        private readonly ISolicitacaoRepository _solicitacaoRepository = solicitacaoRepository;
        private readonly IMapper _mapper = mapper;

        async Task<SolicitacaoResponse> IUseCaseAsync<SolicitacaoResponse>.Execute()
        {
            var solicitacao = new Solicitacao()
            {
                Id = Guid.NewGuid(),
                DataCriacao = DateTime.Now,
                StatusSolicitacao = StatusSolicitacao.Pendente
            }; 


            var result = await _solicitacaoRepository.Post(solicitacao);

            return _mapper.Map<SolicitacaoResponse>(result);
        }
    }
}
