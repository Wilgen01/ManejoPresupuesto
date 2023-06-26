using System.ComponentModel.DataAnnotations;

namespace ManejoPresupuesto.Models
{
    public class Transaccion
    {
        public int Id { get; set; }
        public int usuarioId { get; set; }
        public DateTime FechaTransaccion { get; set; } = DateTime.Today;
        public decimal Monto { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Debe seleccionar una categoría")]
        public int CategoriaId { get; set; }

        public string Nota { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Debe seleccionar una categoría")]
        public int CuentaId { get; set; }
    }
}
