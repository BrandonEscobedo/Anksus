using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace proyecto2.Models.dbModels
{
    [Table("imagenes_perfil")]
    public partial class ImagenesPerfil
    {
        public ImagenesPerfil()
        {
            Usuarios = new HashSet<AplicationUser>();
        }

        [Key]
        [Column("id_imagen")]
        public int IdImagen { get; set; }
        [Column("imagen")]
        [StringLength(500)]
        public string Imagen { get; set; } = null!;

        [InverseProperty("IdImagenPerfilNavigation")]
        public virtual ICollection<AplicationUser> Usuarios { get; set; }
    }
}
