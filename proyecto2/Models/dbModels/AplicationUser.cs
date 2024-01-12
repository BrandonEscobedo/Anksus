using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace proyecto2.Models.dbModels
{
    public class AplicationUser : IdentityUser<int>
    {
        public AplicationUser()
        {
            Cuestionarios = new HashSet<Cuestionario>();
        }
        
        [Column("id_imagen_perfil")]
        public int IdImagenPerfil { get; set; }
    

        [ForeignKey("IdImagenPerfil")]
        [InverseProperty("Usuarios")]
        
        public virtual ImagenesPerfil IdImagenPerfilNavigation { get; set; } = null!;
        [InverseProperty("IdUsuarioNavigation")]
        
        public virtual CuestionarioActivo? CuestionarioActivo { get; set; }
        [InverseProperty("IdUsuarioNavigation")]
        public virtual ICollection<Cuestionario> Cuestionarios { get; set; }
    }
}
