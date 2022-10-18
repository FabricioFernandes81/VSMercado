namespace ClientServer.DTOs
{
    public class MunicipiosDTO
    {
        public int Id { get; set; }
        public string? nome { get; set; }
        public int estadoId { get; set; }

        public EstadoDTO? estado { get; set; }
    }
}
