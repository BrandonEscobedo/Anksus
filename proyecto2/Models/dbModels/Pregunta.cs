using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace proyecto2.Models.dbModels
{
    [Table("preguntas")]
    public partial class Pregunta
    {
        public Pregunta()
        {
            RespuestaNavigation = new HashSet<Respuesta>();
        }

        [Key]
        [Column("id_pregunta")]
        public int IdPregunta { get; set; }
        [Column("id_cuestionario")]
        public int IdCuestionario { get; set; }
        [Column("respuesta")]
        [StringLength(400)]
        [Unicode(false)]
        public string Respuesta { get; set; } = null!;
        [Column("estado")]
        public bool Estado { get; set; }

        [ForeignKey("IdCuestionario")]
        [InverseProperty("Pregunta")]
        public virtual Cuestionario IdCuestionarioNavigation { get; set; } = null!;
        [InverseProperty("IdPreguntaNavigation")]
        public virtual ICollection<Respuesta> RespuestaNavigation { get; set; }
    }
}
