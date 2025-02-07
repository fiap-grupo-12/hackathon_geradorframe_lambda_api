using Amazon.DynamoDBv2.DataModel;
using FIAP.Hackathon.GeradorFrame.Lambda.Domain.Entities;
using FIAP.Hackathon.GeradorFrame.Lambda.Domain.Repositories;

namespace FIAP.Hackathon.GeradorFrame.Lambda.Infra.Data.Repositories
{
    public class SolicitacaoRepository : ISolicitacaoRepository
    {
        private readonly IDynamoDBContext _context;

        public SolicitacaoRepository(IDynamoDBContext context)
        {
            _context = context;
        }

        public async Task<Solicitacao> Post(Solicitacao solicitacao)
        {
            try
            {
                await _context.SaveAsync(solicitacao);

                return solicitacao;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao criar solicitação. {ex.Message}", ex);
            }
        }

        public async Task<IList<Solicitacao>> Get()
        {
            try
            {
                return await _context.ScanAsync<Solicitacao>(default).GetRemainingAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao consultar solicitações. Message: {ex}");
            }
        }

        public async Task<Solicitacao> GetById(Guid id)
        {
            try
            {
                return await _context.LoadAsync<Solicitacao>(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao consultar solicitação - Id: {id}. Message: {ex}");
            }
        }
    }
}
