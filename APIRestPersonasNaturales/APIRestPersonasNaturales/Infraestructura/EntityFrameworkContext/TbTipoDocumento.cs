using System;
using System.Collections.Generic;

namespace APIRestPersonasNaturales.Infraestructura.EntityFrameworkContext;

public partial class TbTipoDocumento
{
    public int IdTipoDocumento { get; set; }

    public string? CDescripcion { get; set; }
}
