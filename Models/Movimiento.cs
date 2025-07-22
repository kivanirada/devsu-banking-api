using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Devsu.Models
{
    public class Movimiento
    {
        [Key]
        public int MovimientoId { get; set; }

        public DateTime Fecha { get; set; }

        [Required]
        public string TipoMovimiento { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Valor { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Saldo { get; set; }

        // ?? Relación con Cuenta
        [ForeignKey("Cuenta")]
        public int NumeroCuenta { get; set; }
        public Cuenta Cuenta { get; set; }
    }
}
