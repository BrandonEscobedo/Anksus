using MessagePack;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace proyecto2.Models.DTO
{
    public class CuestionarioCrateDTO
    {
        

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

        [JsonIgnore]
        [IgnoreMember]
        [IgnoreDataMember]
        public SelectList? categoria { get; set; }


    }
}
