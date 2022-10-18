using Microsoft.AspNetCore.Identity;

namespace ClientServer.Models
{
    public class AppUsers : IdentityUser
    {
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
    }
}
