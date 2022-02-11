namespace ProCli.Models
{
    public class ContactosCliente
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public string Nombre { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }

        public Cliente Cliente { get; set; }
    }
}
