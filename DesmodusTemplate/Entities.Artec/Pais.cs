using System;
using System.Collections.Generic;

namespace DesmodusTemplate.Entities.Artec;

public partial class Pais
{
    public int IdPais { get; set; }

    public string Nombre { get; set; }

    public string NombreCorto { get; set; }

    public string Gentilicio { get; set; }

    public virtual ICollection<Persona> Persona { get; } = new List<Persona>();
}
