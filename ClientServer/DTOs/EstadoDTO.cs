using ClientServer.Models;

namespace ClientServer.DTOs
{
    public class EstadoDTO
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? uf { get; set; }
       // public IEnumerable<Cidades> City { get; set; }
        //public ICollection<Cidades>? Cidades { get; set; }
         public List<Cidades> City { get; set; } = new List<Cidades>();
    }
}
