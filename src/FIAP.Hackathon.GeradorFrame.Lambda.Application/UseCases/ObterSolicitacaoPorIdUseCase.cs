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
    public class ObterSolicitacaoPorIdUseCase(
        ICriarUrlDownloadS3UseCase criarUrlDownloadS3,
        ISolicitacaoRepository solicitacaoRepository,
        IMapper mapper
        ) : IObterSolicitacaoPorIdUseCase
    {
        private readonly ICriarUrlDownloadS3UseCase _criarUrlDownloadS3 = criarUrlDownloadS3;
        private readonly ISolicitacaoRepository _solicitacaoRepository = solicitacaoRepository;
        private readonly IMapper _mapper = mapper;


        public async Task<SolicitacaoResponse> Execute(Guid request)
        {
            try
            {
                var result = await _solicitacaoRepository.GetById(request);

                result.Url = await _criarUrlDownloadS3.Execute(result.Id);

                return _mapper.Map<SolicitacaoResponse>(result);
            }
            catch (Exception e)
            {
                throw new Exception($"Erro: Ex. {e.Message}");
            }

        }
    }
}
