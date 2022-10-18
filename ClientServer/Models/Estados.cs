using System.ComponentModel.DataAnnotations;
namespace ClientServer.Models
{
    public class Estados
    {
        public int Id { get; set; }
        public string? nome { get; set; }

        [MaxLength(2)]
        public string? uf { get; set; }
        //  public ICollection<Cidades>? Cidades { get; set; }
        public List<Cidades> City { get; set; } = new List<Cidades>();
    }
}
