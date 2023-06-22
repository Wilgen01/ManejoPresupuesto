using System.ComponentModel.DataAnnotations;

namespace ManejoPresupuesto.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="El campo {0} es requerido")]
        [MaxLength(50, ErrorMessage ="No pude ser mayor a {1} caracteres")]
        public string Nombre { get; set; }
        [Display(Name = "Categoria")]
        public TipoOperacion TipoOperacionId { get; set; }
        public int usuarioId { get; set; }
    }
}
