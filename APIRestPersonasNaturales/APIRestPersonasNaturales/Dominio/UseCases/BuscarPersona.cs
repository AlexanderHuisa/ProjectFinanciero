using APIRestPersonasNaturales.Infraestructura.EntityFrameworkContext;

namespace APIRestPersonasNaturales.Dominio.UseCases;

public class BuscarPersona
{
    private readonly MicrofinanzaContext db;
    public BuscarPersona(MicrofinanzaContext _db)
    {
        db = _db;
    }

    public TbPersonaNatural BuscarPersonaNatural(int idTipoDocumento, string cDocumento)
    {
        TbPersonaNatural tbPersonaNatural = new TbPersonaNatural();
        tbPersonaNatural = db.TbPersonaNaturals.Where(x => x.IdTipoDocumento == idTipoDocumento && x.NumeroDocumento == cDocumento).FirstOrDefault();
        return tbPersonaNatural;
    }

}
