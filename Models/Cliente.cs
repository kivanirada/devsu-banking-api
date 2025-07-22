namespace Devsu.Models
{
    public class Cliente : Persona
    {
        public ICollection<Cuenta> Cuentas { get; set; }
    }
}
