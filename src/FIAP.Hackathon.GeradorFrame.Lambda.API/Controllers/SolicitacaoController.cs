using FIAP.Hackathon.GeradorFrame.Lambda.Application.UseCases.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FIAP.Hackathon.GeradorFrame.Lambda.API.Controllers
{

    [Route("api/")]
    public class SolicitacaoController(
            ICriarSolicitacaoUseCase criarSolicitacao,
            IObterSolicitacaoUseCase obterSolicitacao,
            IObterSolicitacaoPorIdUseCase obterSolicitacaoPorId,
            ICriarUrlUploadS3UseCase criarUrlUploadS3UseCase,
            ICriarUrlDownloadS3UseCase criarUrlDownloadS3
        ) : ControllerBase
    {
        private readonly ICriarSolicitacaoUseCase _criarSolicitacao = criarSolicitacao;
        private readonly IObterSolicitacaoUseCase _obterSolicitacao = obterSolicitacao;
        private readonly IObterSolicitacaoPorIdUseCase _obterSolicitacaoPorId = obterSolicitacaoPorId;
        private readonly ICriarUrlUploadS3UseCase _criarUrlUploadS3 = criarUrlUploadS3UseCase;
        private readonly ICriarUrlDownloadS3UseCase _criarUrlDownloadS3 = criarUrlDownloadS3;


        // GET api/Solicitacao
        [HttpGet("Solicitacao")]
        public async Task<IActionResult> Get([FromHeader] string Authorization)
        {
            try
            {
                var result = await _criarSolicitacao.Execute();

                result.Url = await _criarUrlUploadS3.Execute(result.Id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // GET api/Solicitacao/{id}
        [HttpGet("Solicitacao/{Id}")]
        public async Task<IActionResult> GetSolicitacaoPorId(Guid id)
        {
            try
            {
                var result = await _obterSolicitacaoPorId.Execute(id);

                result.Url = await _criarUrlDownloadS3.Execute(result.Id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        // GET api/Solicitacao/{id}
        [HttpGet("Solicitacoes")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _obterSolicitacao.Execute();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
