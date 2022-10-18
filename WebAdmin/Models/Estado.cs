namespace WebAdmin.Models
{
    public class Estado
    {
        public int Id { get; set; }
        public string? nome { get; set; }

        public string? uf { get; set; }
     //   public IEnumerable<Cidade>? City { get; set; }
        public List<Cidade> City { get; set; } = new List<Cidade>();
    }
}
