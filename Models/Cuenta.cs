using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Devsu.Models
{
    public class Cuenta
    {
        [Key]
        public int NumeroCuenta { get; set; }

        [Required]
        public string TipoCuenta { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal SaldoInicial { get; set; }

        public bool Estado { get; set; }

 
        [ForeignKey("Cliente")]
        public int ClienteId { get; set; }

        [Required(AllowEmptyStrings = true)]
        public Cliente? Cliente { get; set; } 

        public ICollection<Movimiento>? Movimientos { get; set; } 
    }
}
