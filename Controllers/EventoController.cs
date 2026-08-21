using EventPlus.WebAPI.DTO;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private readonly IEvento _evento;

        public EventoController(IEvento evento)
        {
            _evento = evento;
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            try
            {
                var eventos = await _evento.Listar();

                return Ok(eventos);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromBody] EventoDTO dto)
        {
            var evento = new Evento
            {
                NomeEvento = dto.NomeEvento,
                DataEvento = dto.DataEvento,
                Descricao = dto.Descricao,
                ImagemUrl = dto.ImagemUrl,
                IdTipoEvento = dto.IdTipoEvento,
                IdInstituicao = dto.IdInstituicao
            };

            await _evento.Cadastrar(evento);

            return StatusCode(201, evento);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> BuscarPorId(Guid id)
        {
            var eventoBuscado = await _evento.BuscarPorId(id);

            if (eventoBuscado == null)
            {
                return NotFound("Evento não encontrado");
            }

            return Ok(eventoBuscado);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Atualizar(Guid id, [FromBody] EventoDTO dto)
        {
            var evento = new Evento
            {
                NomeEvento = dto.NomeEvento,
                DataEvento = dto.DataEvento,
                Descricao = dto.Descricao,
                ImagemUrl = dto.ImagemUrl,
                IdTipoEvento = dto.IdTipoEvento,
                IdInstituicao = dto.IdInstituicao
            };

            await _evento.Atualizar(id, evento);

            return Ok(evento);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Deletar(Guid id)
        {
            await _evento.Deletar(id);

            return NoContent();
        }
    }
}
