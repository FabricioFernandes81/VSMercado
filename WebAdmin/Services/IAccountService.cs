using WebAdmin.Models;

namespace WebAdmin.Services
{
    public interface IAccountService
    {
        Task<ResponseToken> Registro(RegistroView registroView);
    }
}