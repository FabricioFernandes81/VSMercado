using ClientServer.DTOs;
using ClientServer.Utils;

namespace ClientServer.Services
{
    public interface IAccountService
    {
        Task<TokenResponse> ResgistrarLoja(RegistroDTO registroDto);

        void InitializeSeedRoles();


    }
}