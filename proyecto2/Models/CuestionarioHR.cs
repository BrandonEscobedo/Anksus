﻿using MessagePack;
using Microsoft.AspNetCore.Mvc.Rendering;
using proyecto2.Models.dbModels;
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
     
        public bool Estado { get; set; }
        [StringLength(50)]
        public string? Titulo { get; set; }
     
        public bool Publico { get; set; }

      
        //tabla Preguntas
      public class pregunta
        {
            public int IdPregunta { get; set; }

            public string Respuesta { get; set; } = null!;

            public bool Estado_Pregunta { get; set; }
        }
    }
}
