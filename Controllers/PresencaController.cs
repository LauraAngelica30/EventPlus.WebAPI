using EventPlus.WebAPI.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PresencaController : ControllerBase
    {
        private readonly IPresenca _presenca;

        public PresencaController(IPresenca presenca)
        {
            _presenca = presenca;
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            try
            {
                var presencas = await _presenca.Listar();

                return Ok(presencas);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> BucarPorId(Guid id)
        {
            var presencabuscada = await _presenca.BuscarPorId(id);

            if (presencabuscada == null)
            {
                return NotFound("Presenças não encontradas");
            }

            return Ok(presencabuscada);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Deletar(Guid id)
        {
            await _presenca.Deletar(id);
            return NoContent();
        }
    }
}
