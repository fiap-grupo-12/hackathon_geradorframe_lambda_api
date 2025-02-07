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
        ICriarUrlUploadS3UseCase criarUrlUploadS3,
        ISolicitacaoRepository solicitacaoRepository,
        IMapper mapper
        ) : ICriarSolicitacaoUseCase
    {
        private readonly ICriarUrlUploadS3UseCase _criarUrlUploadS3 = criarUrlUploadS3;
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

            result.Url = await _criarUrlUploadS3.Execute(result.Id);

            return _mapper.Map<SolicitacaoResponse>(result);
        }
    }
}
