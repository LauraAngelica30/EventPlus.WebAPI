using EventPlus.WebAPI.Models;

namespace EventPlus.WebAPI.Interfaces
{
    public interface IComentario
    {
        Task Cadastrar(Comentario comentario);

        Task<List<Comentario>> Listar();

        Task<List<Comentario>> ListarPorEvento(Guid IdEvento);

        Task Deletar(Guid id);

        Task<Comentario?> BuscarPorId(Guid id);
    }
}
