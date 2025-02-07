using FIAP.Hackathon.GeradorFrame.Lambda.Domain.Entities;
using System.Runtime.InteropServices;

namespace FIAP.Hackathon.GeradorFrame.Lambda.Domain.Repositories
{
    public interface ISolicitacaoRepository
    {
        Task<Solicitacao> Post(Solicitacao solicitacao);
        Task<Solicitacao> GetById(Guid id);
        Task<IList<Solicitacao>> Get();
    }
}
