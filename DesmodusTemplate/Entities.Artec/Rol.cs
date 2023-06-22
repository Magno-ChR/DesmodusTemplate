using System;
using System.Collections.Generic;

namespace DesmodusTemplate.Entities.Artec;

public partial class Rol
{
    public int IdRol { get; set; }

    public string Nombre { get; set; }

    public string Descripcion { get; set; }

    public int IdEstado { get; set; }

    public virtual Estado IdEstadoNavigation { get; set; }

    public virtual ICollection<Usuario> Usuario { get; } = new List<Usuario>();
}
