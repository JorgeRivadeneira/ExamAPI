using System.ComponentModel.DataAnnotations;

namespace ExamAPI.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string? Nombre{ get; set; }
        [Required(ErrorMessage = "El email es obligatorio.")]
        [EmailAddress(ErrorMessage = "El formato del email no es válido.")]
        public string Email { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
    }
}
