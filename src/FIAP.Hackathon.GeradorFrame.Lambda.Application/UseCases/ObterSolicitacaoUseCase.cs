using AutoMapper;
using FIAP.Hackathon.GeradorFrame.Lambda.Application.Models.Response;
using FIAP.Hackathon.GeradorFrame.Lambda.Application.UseCases.Interfaces;
using FIAP.Hackathon.GeradorFrame.Lambda.Domain.Entities;
using FIAP.Hackathon.GeradorFrame.Lambda.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAP.Hackathon.GeradorFrame.Lambda.Application.UseCases
{
    public class ObterSolicitacaoUseCase(
        ISolicitacaoRepository solicitacaoRepository,
        IMapper mapper
        ) : IObterSolicitacaoUseCase
    {
        private readonly ISolicitacaoRepository _solicitacaoRepository = solicitacaoRepository;
        private readonly IMapper _mapper = mapper;


        public async Task<IList<SolicitacaoResponse>> Execute()
        {
            var result = await _solicitacaoRepository.Get();

            return _mapper.Map<IList<SolicitacaoResponse>>(result);
        }
    }
}
