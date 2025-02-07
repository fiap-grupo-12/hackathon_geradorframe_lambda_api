using Amazon.DynamoDBv2.DataModel;
using FIAP.Hackathon.GeradorFrame.Lambda.Domain.Entities.Enum;
using System.Diagnostics.CodeAnalysis;

namespace FIAP.Hackathon.GeradorFrame.Lambda.Domain.Entities
{
    [ExcludeFromCodeCoverage]
    [DynamoDBTable("GerenciadorTable")]
    public class Solicitacao
    {
        [DynamoDBHashKey("id")]
        public Guid Id { get; set; }
        [DynamoDBProperty("idUsuario")]
        public int IdUsuario { get; set; }
        [DynamoDBProperty("arquivoOrigem")]
        public string ArquivoOrigem { get; set; }
        [DynamoDBProperty("arquivoDestino")]
        public string ArquivoDestino { get; set; }
        [DynamoDBProperty("dataCriacao")]
        public DateTime DataCriacao { get; set; }
        [DynamoDBProperty("dataInicioProcessamento")]
        public DateTime? DataInicioProcessamento { get; set; }
        [DynamoDBProperty("dataFimProcessamento")]
        public DateTime? DataFimProcessamento { get; set; }
        [DynamoDBProperty("statusSolicitacao")]
        public StatusSolicitacao StatusSolicitacao { get; set; }
    }
}
