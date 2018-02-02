using System;
using System.Threading.Tasks;
using Domain.PaletesCarregamento;
using Microsoft.AspNetCore.Mvc;

namespace CassandraApp.Controllers
{
    [Route("palete-finalizado-cassandra")]
    public class PaleteCarregamentoController : Controller
    {
        public PaleteCarregamentoController(IPaleteCarregamentoSalvar paleteCarregamentoSalvar, IPaleteCarregamentoBuscar paleteCarregamentoBuscar)
        {
            _paleteCarregamentoSalvar = paleteCarregamentoSalvar;
            _paleteCarregamentoBuscar = paleteCarregamentoBuscar;
        }

        private readonly IPaleteCarregamentoSalvar _paleteCarregamentoSalvar;
        private readonly IPaleteCarregamentoBuscar _paleteCarregamentoBuscar;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PaleteCarregamentoRequisicao requisicao)
        {
            try
            {
                var result = _paleteCarregamentoSalvar.Salvar(requisicao);
                return await ResultOk(result);

            }
            catch (Exception ex)
            {
                return await ResultBad(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = _paleteCarregamentoBuscar.BuscarTodos();
                return await ResultOk(result);
            }
            catch (Exception ex)
            {
                return await ResultBad(ex.Message);
            }
        }

        private async Task<IActionResult> ResultOk(object result)
        {
            return Ok(new
            {
                success = true,
                data = result
            });
        }

        private async Task<IActionResult> ResultBad(object error)
        {
            return BadRequest(new
            {
                success = false,
                errors = error
            });
        }
    }
}