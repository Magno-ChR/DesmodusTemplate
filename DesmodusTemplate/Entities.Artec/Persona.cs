using System;
using System.Collections.Generic;

namespace DesmodusTemplate.Entities.Artec;

public partial class Persona
{
    public int IdPersona { get; set; }

    public string Nombre { get; set; }

    public string PrimerApellido { get; set; }

    public string SegundoApellido { get; set; }

    public string NroDocumento { get; set; }

    public DateTime FechaNacimiento { get; set; }

    public string CorreoPersonal { get; set; }

    public string Celular { get; set; }

    public string DireccionResidencia { get; set; }

    public int? IdPais { get; set; }

    public int? IdEstado { get; set; }

    public virtual Estado IdEstadoNavigation { get; set; }

    public virtual Pais IdPaisNavigation { get; set; }
}
