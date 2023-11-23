using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace proyecto2.Models.dbModels
{
    [Table("cuestionarios")]
    public partial class Cuestionario
    {
        public Cuestionario()
        {
            Pregunta = new HashSet<Pregunta>();
        }

        [Key]
        [Column("id_cuestionario")]
        public int IdCuestionario { get; set; }
        [Column("id_usuario")]
        public int IdUsuario { get; set; }
        public int IdCategoria { get; set; }
        [Column("estado")]
        public bool Estado { get; set; }
        [Column("titulo")]
        [StringLength(60)]
        public string? Titulo { get; set; }
        [Column("publico")]
        public bool Publico { get; set; }

        [ForeignKey("IdCategoria")]
        [InverseProperty("Cuestionarios")]
        public virtual Categoria IdCategoriaNavigation { get; set; } = null!;
        [ForeignKey("IdUsuario")]
        [InverseProperty("Cuestionarios")]
        public virtual AplicationUser IdUsuarioNavigation { get; set; } = null!;
        [InverseProperty("IdCuestionarioNavigation")]
        public virtual CuestionarioActivo? CuestionarioActivo { get; set; }
        [InverseProperty("IdCuestionarioNavigation")]
        public virtual ICollection<Pregunta> Pregunta { get; set; }
    }
}
