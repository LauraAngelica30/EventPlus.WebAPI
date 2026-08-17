using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.WebAPI.Repositories
{
    public class InstituicaoRepository : IInstituicao
    {
        private readonly EventContext _context;

        public InstituicaoRepository(EventContext context)
        {
            _context = context;
        }

        public Task Atualizar(Guid id, Instituicao instituicao)
        {
            throw new NotImplementedException();
        }

        public async Task<Instituicao?> BuscarPorId(Guid id)
        {
            return await _context.Instituicao.FirstOrDefaultAsync(t => t.IdInstituicao == id);
        }

        public async Task Cadastrar(Instituicao instituicao)
        {
            await _context.Instituicao.AddAsync(instituicao);

            await _context.SaveChangesAsync();
        }

        public Task Cadastrar(IInstituicao instituicao)
        {
            throw new NotImplementedException();
        }

        public Task Deletar(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Instituicao>> Listar()
        {
            return await _context.Instituicao.AsNoTracking().ToListAsync();
        }
    }
}
