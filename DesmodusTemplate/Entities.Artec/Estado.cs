﻿using System;
using System.Collections.Generic;

namespace DesmodusTemplate.Entities.Artec;

public partial class Estado
{
    public int IdEstado { get; set; }

    public string Nombre { get; set; }

    public string Descripcion { get; set; }

    public virtual ICollection<Persona> Persona { get; } = new List<Persona>();

    public virtual ICollection<Rol> Rol { get; } = new List<Rol>();

    public virtual ICollection<Usuario> Usuario { get; } = new List<Usuario>();
}
