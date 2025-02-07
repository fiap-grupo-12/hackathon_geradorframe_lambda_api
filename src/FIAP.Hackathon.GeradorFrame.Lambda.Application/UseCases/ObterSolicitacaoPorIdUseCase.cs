using AutoMapper;
using FIAP.Hackathon.GeradorFrame.Lambda.Application.Models.Response;
using FIAP.Hackathon.GeradorFrame.Lambda.Application.UseCases.Interfaces;
using FIAP.Hackathon.GeradorFrame.Lambda.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAP.Hackathon.GeradorFrame.Lambda.Application.UseCases
{
    public class ObterSolicitacaoPorIdUseCase : IObterSolicitacaoPorIdUseCase
    {
        private readonly ISolicitacaoRepository _solicitacaoRepository;
        private readonly IMapper _mapper;

        public ObterSolicitacaoPorIdUseCase(
            ISolicitacaoRepository solicitacaoRepository,
            IMapper mapper
            )
        {
            _solicitacaoRepository = solicitacaoRepository;
            _mapper = mapper;
        }

        public async Task<SolicitacaoResponse> Execute(Guid request)
        {
            try
            {
                var result = await _solicitacaoRepository.GetById(request);

                return _mapper.Map<SolicitacaoResponse>(result);
            }
            catch (Exception e)
            {
                throw new Exception($"Erro: Ex. {e.Message}");
            }
            
        }
    }
}
