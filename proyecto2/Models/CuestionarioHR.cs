using MessagePack;
using Microsoft.AspNetCore.Mvc.Rendering;
using proyecto2.Models.dbModels;
using proyecto2.Models.DTO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace proyecto2.Models
{
   
    public class CuestionarioHR
    {
        //Tabla Cuestionario
        [Required]
        public int IdCuestionario { get; set; }
        [Required]
     
        public int IdUsuario { get; set; }
        [Required]

        public int IdCategoria { get; set; }

        public bool Estado { get; set; } = false;
        [StringLength(50)]
        public string? Titulo { get; set; }
     
        public bool Publico { get; set; }
    
     public List<RespuestaDTO> Respuestas { get; set; } = new List<RespuestaDTO>();
        public List<preguntaDTO> Preguntas { get; set; } = new List<preguntaDTO>();
        public CuestionarioHR()
        {
            Respuestas = new List<RespuestaDTO>();
            Preguntas = new List<preguntaDTO>();
        }
        [Required]
        public int IdPregunta { get; set; }

        public bool EstadoPregunta { get; set; } = false!;
        public string preguntatexto { get; set; } = null!;

        /*/
     public int IdRespuesta { get; set; }

     [StringLength(200)]

     public string respuesta { get; set; } = null!;

     public bool RCorrecta { get; set; }
     /*/
    }



}
