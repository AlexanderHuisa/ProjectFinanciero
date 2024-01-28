using System;
using System.Collections.Generic;

namespace APIRestPersonasNaturales.Infraestructura.EntityFrameworkContext;

public partial class TbPersonaNatural
{
    public int? IdPersona { get; set; }

    public int? IdTipoDocumento { get; set; }

    public string? NumeroDocumento { get; set; }

    public string? NombreCompleto { get; set; }

    public string? Nombres { get; set; }

    public string? Apellidos { get; set; }

    public DateTime? FechaNacimiento { get; set; }

    public string? LugarNacimiento { get; set; }

    public string? PaisResidencia { get; set; }
}
