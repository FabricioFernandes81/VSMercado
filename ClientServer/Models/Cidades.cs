using System.ComponentModel.DataAnnotations.Schema;
namespace ClientServer.Models
{
    public class Cidades
    {
        public int Id { get; set; }
        public string? nome { get; set; }

        [NotMapped]
        public Estados? Estados { get; set; }
        public int EstadosId { get; set; }
    }
}
