using FIAP.Hackathon.GeradorFrame.Lambda.Application.UseCases.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FIAP.Hackathon.GeradorFrame.Lambda.API.Controllers
{

    [Route("api/")]
    public class SolicitacaoController(
            ICriarSolicitacaoUseCase criarSolicitacao,
            IObterSolicitacaoUseCase obterSolicitacao,
            IObterSolicitacaoPorIdUseCase obterSolicitacaoPorId,
            IObterSolicitacaoPorEmail obterSolicitacaoPorEmail
        ) : ControllerBase
    {
        private readonly ICriarSolicitacaoUseCase _criarSolicitacao = criarSolicitacao;
        private readonly IObterSolicitacaoUseCase _obterSolicitacao = obterSolicitacao;
        private readonly IObterSolicitacaoPorIdUseCase _obterSolicitacaoPorId = obterSolicitacaoPorId;
        private readonly IObterSolicitacaoPorEmail _obterSolicitacaoPorEmail = obterSolicitacaoPorEmail;


        // GET api/Solicitacao
        [HttpGet("Solicitacao")]
        public async Task<IActionResult> Get([FromHeader] string Authorization)
        {
            try
            {
                var result = await _criarSolicitacao.Execute(Authorization);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // GET api/Solicitacao/{id}
        [HttpGet("Solicitacao/Id/{Id}")]
        public async Task<IActionResult> GetSolicitacaoPorId(Guid id)
        {
            try
            {
                var result = await _obterSolicitacaoPorId.Execute(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // GET api/Solicitacao/{id}
        [HttpGet("Solicitacao/Email/{Email}")]
        public async Task<IActionResult> GetSolicitacaoPorEMail(string email)
        {
            try
            {
                var result = await _obterSolicitacaoPorEmail.Execute(email);

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
