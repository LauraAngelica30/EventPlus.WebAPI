using EventPlus.WebAPI.Interfaces;

namespace EventPlus.WebAPI.Services
{
    public class SightengineModerationService : IModerationService
    {
        //Para sexta - implementar aqui a lógica de moderar texto 

        //Pendências:
        // 1. Cadastro na plataforma
        // 2. Usar Secrets das credenciais (ApiUser e ApiSecret)
        // 3. Cadastrar uma presença para o usuário (Cadastrar)
        // 4. Cadastrar um comentário (Cadastrar)
        // 5. Terminar todos od CRUDS
        public Task<bool> ModerarTexto(string texto)
        {
            throw new NotImplementedException();
        }
    }
}

