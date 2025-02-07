using FIAP.Hackathon.GeradorFrame.Lambda.Application.Models.Response;

namespace FIAP.Hackathon.GeradorFrame.Lambda.Application.UseCases.Interfaces
{
    public interface IObterSolicitacaoPorIdUseCase : IUseCaseAsync<Guid, SolicitacaoResponse>
    {
    }
}
