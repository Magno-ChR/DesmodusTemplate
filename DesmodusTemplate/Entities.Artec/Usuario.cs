using System;
using System.Collections.Generic;

namespace DesmodusTemplate.Entities.Artec;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public int IdPersona { get; set; }

    public int IdRol { get; set; }

    public string Correo { get; set; }

    public string Clave { get; set; }

    public string Salt { get; set; }

    public int IdEstado { get; set; }

    public virtual Estado IdEstadoNavigation { get; set; }

    public virtual Persona IdPersonaNavigation { get; set; }

    public virtual Rol IdRolNavigation { get; set; }
}
