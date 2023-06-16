using System;
using System.Collections.Generic;

namespace DesmodusTemplate.Entities.Artec;

public partial class Estado
{
    public int IdEstado { get; set; }

    public string Nombre { get; set; }

    public string Descripcion { get; set; }

    public virtual ICollection<Persona> Persona { get; } = new List<Persona>();
}
