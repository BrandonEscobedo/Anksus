using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace proyecto2.Models.dbModels
{
    [Table("respuestas")]
    public partial class Respuesta
    {
        [Key]
        [Column("id_respuesta")]
        public int IdRespuesta { get; set; }
        [Column("id_pregunta")]
        public int IdPregunta { get; set; }
        [Column("respuesta")]
        [StringLength(200)]
        [Unicode(false)]
        public string respuesta { get; set; } = null!;
        [Column("R_correcta")]
        public bool RCorrecta { get; set; }

        [ForeignKey("IdPregunta")]
        [InverseProperty("RespuestaNavigation")]
        public virtual Pregunta IdPreguntaNavigation { get; set; } = null!;
    }
}
