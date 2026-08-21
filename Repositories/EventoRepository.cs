using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.WebAPI.Repositories
{
    public class EventoRepository : IEvento
    {
        private readonly EventContext _context;

        public EventoRepository(EventContext context)
        {
            _context = context;
        }

        public async Task Atualizar(Guid id, Evento evento)
        {
            var eventoBuscado = await _context.Evento.FindAsync(id);

            if (eventoBuscado != null)
            {
                eventoBuscado.NomeEvento = evento.NomeEvento;
                eventoBuscado.DataEvento = evento.DataEvento;
                eventoBuscado.Descricao = evento.Descricao;
                eventoBuscado.ImagemUrl = evento.ImagemUrl;
                eventoBuscado.IdTipoEvento = evento.IdTipoEvento;
                eventoBuscado.IdInstituicao = evento.IdInstituicao;

                _context.Evento.Update(eventoBuscado);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Evento?> BuscarPorId(Guid id)
        {
            return await _context.Evento.FirstOrDefaultAsync(t => t.IdEvento == id);
        }

        public async Task Cadastrar(Evento evento)
        {
            await _context.Evento.AddAsync(evento);

            await _context.SaveChangesAsync();
        }

        public async Task Deletar(Guid id)
        {
            var eventoBuscado = await _context.Evento.FindAsync(id);

            if (eventoBuscado != null)
            {
                _context.Evento.Remove(eventoBuscado);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Evento>> Listar()
        {
            return await _context.Evento.AsNoTracking().ToListAsync();
        }

        public Task<List<Evento>> ListarPorInscrito(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Evento>> ListarPorInstituicao(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Evento>> ListarProximosEventos(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
