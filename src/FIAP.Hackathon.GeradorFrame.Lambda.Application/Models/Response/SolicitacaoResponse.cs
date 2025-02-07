using System.Text.Json.Serialization;

namespace FIAP.Hackathon.GeradorFrame.Lambda.Application.Models.Response
{
    public class SolicitacaoResponse
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
        [JsonPropertyName("idUsuario")]
        public int IdUsuario { get; set; }
        [JsonPropertyName("arquivoOrigem")]
        public string ArquivoOrigem { get; set; }
        [JsonPropertyName("arquivoDestino")]
        public string ArquivoDestino { get; set; }
        [JsonPropertyName("url")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Url { get; set; }
        [JsonPropertyName("dataCriacao")]
        public DateTime DataCriacao { get; set; }
        [JsonPropertyName("dataInicioProcessamento")]
        public DateTime? DataInicioProcessamento { get; set; }
        [JsonPropertyName("dataFimProcessamento")]
        public DateTime? DataFimProcessamento { get; set; }
        [JsonPropertyName("statusSolicitacao")]
        public string StatusSolicitacao { get; set; }
    }
}
