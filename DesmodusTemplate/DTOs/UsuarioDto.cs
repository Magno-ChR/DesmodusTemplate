using DesmodusTemplate.Entities.Artec;
using System.ComponentModel.DataAnnotations;

namespace DesmodusTemplate.DTOs
{
    public class UsuarioDto : UsuarioEditDto 
    {
        public int IdUsuario { get; set; }
        public string Salt { get; set; }

        public virtual EstadoDto IdEstadoNavigation { get; set; }

        public virtual PersonaDto IdPersonaNavigation { get; set; }

        public virtual RolDto IdRolNavigation { get; set; }
    }
    public class UsuarioEditDto : UsuarioLoginDto
    {
        [Required]
        public int IdPersona { get; set; }
        [Required]
        public int IdRol { get; set; }

        public int IdEstado { get; set; } = 1;
    }
    public class UsuarioLoginDto
    {
        [Required]
        public string Correo { get; set; }
        [Required]
        public string Clave { get; set; }
    }
}
