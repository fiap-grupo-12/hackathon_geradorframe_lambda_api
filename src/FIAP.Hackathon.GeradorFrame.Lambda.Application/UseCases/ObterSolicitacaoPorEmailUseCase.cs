using AutoMapper;
using FIAP.Hackathon.GeradorFrame.Lambda.Application.Models.Response;
using FIAP.Hackathon.GeradorFrame.Lambda.Application.Services.Interfaces;
using FIAP.Hackathon.GeradorFrame.Lambda.Application.UseCases.Interfaces;
using FIAP.Hackathon.GeradorFrame.Lambda.Domain.Repositories;


namespace FIAP.Hackathon.GeradorFrame.Lambda.Application.UseCases
{
    public class ObterSolicitacaoPorEmailUseCase(ISolicitacaoRepository solicitacaoRepository,
        IMapper mapper
        ) : IObterSolicitacaoPorEmail
    {
        private readonly ISolicitacaoRepository _solicitacaoRepository = solicitacaoRepository;
        private readonly IMapper _mapper = mapper;


        public async Task<IList<SolicitacaoResponse>> Execute(string email)
        {
            try
            {
                var result = await _solicitacaoRepository.GetByEmail(email);

                return _mapper.Map<IList<SolicitacaoResponse>>(result);
            }
            catch (Exception e)
            {
                throw new Exception($"Erro: Ex. {e.Message}");
            }

        }
    }
}

