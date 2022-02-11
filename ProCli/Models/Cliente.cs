using System.ComponentModel.DataAnnotations;

namespace ProCli.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string? Domicilio { get; set; }
        public string? CodigoPostal { get; set; }
        public string? Poblacion { get; set; }

        public virtual ICollection<ContactosCliente> ContactosClientes { get; set; }

    }
}
