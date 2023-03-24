using System;
using System.Collections.Generic;

namespace DesmodusTemplate.Entities.Artec;

public partial class Pai
{
    public int IdPais { get; set; }

    public string Nombre { get; set; }

    public string NombreCorto { get; set; }

    public virtual ICollection<Persona> Personas { get; } = new List<Persona>();
}
