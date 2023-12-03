using System.ComponentModel.DataAnnotations;

namespace proyecto2.Models.DTO
{
    public class preguntaDTO
    {
        [Required]
        public int IdPregunta { get; set; }
        [Required]
        public int IdCuestionario { get; set; }
        [StringLength(400)]
        public string pregunta { get; set; } = null!;
      
        public bool Estado { get; set; }=false;

     
    }
}
