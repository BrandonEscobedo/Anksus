using System.ComponentModel.DataAnnotations;

namespace proyecto2.Models.DTO
{
    public class RespuestaDTO
    {
        [Required]
        public int IdRespuesta { get; set; }
       
        public int IdPregunta { get; set; }
      
        [StringLength(200)]
      
        public string respuesta { get; set; } = null!;
    
        public bool RCorrecta { get; set; }
    }
}
