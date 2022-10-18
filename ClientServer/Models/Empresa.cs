using System.ComponentModel.DataAnnotations;

namespace ClientServer.Models
{
    public class Empresa
    {
        public int Id { get; set; }
        [MaxLength(14)]
        public string? CNPJ { get; set; }
        public string? Nome { get; set; }
        
        public string? Email { get; set; }
        public string? Fone { get; set; }
        public string? Celular { get; set; }
        public string? Imagens { get; set; }

        public int EstadosId { get; set; }
        public Estados Estados { get; set; }
        
        public int CidadesId { get; set; }
        public Cidades? Cidades { get; set; }
        public string? Endereco { get; set; }
        
        public string? Numero { get; set; }
        
    }
}
