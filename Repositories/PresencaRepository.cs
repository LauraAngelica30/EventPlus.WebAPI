using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.WebAPI.Repositories
{
    public class PresencaRepository : IPresenca
    {
        private readonly EventContext _context;

        public PresencaRepository(EventContext context)
        {
            _context = context;
        }
        public async Task AtualizarSituacao(Guid id, bool situacao)
        {
            var presencaBuscada = await _context.Presenca.FindAsync(id);

            if (presencaBuscada != null)
            {
                presencaBuscada.Situacao = situacao;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Presenca?> BuscarPorId(Guid id)
        {
            return await _context.Presenca.FirstOrDefaultAsync(t => t.IdPresenca == id);
        }

        public async Task Deletar(Guid id)
        {
            var presencaBuscada = await _context.Presenca.FindAsync(id);

            if (presencaBuscada != null)
            {
                _context.Presenca.Remove(presencaBuscada);
                await _context.SaveChangesAsync();
            }
        }

        public Task Increver(Presenca presenca)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Presenca>> Listar()
        {
            return await _context.Presenca.AsNoTracking().ToListAsync();
        }

        public async Task<List<Presenca>> ListarMinhas(Guid idUsuario)
        {
            return await _context.Presenca.Where(x => x.IdUsuario == idUsuario).ToListAsync();
        }
    }
}
