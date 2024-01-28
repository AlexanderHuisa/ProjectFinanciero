using APIRestPersonasNaturales.Infraestructura.EntityFrameworkContext;
using APIRestPersonasNaturales.Models;
using Microsoft.EntityFrameworkCore;

namespace APIRestPersonasNaturales.Dominio.UseCases;

public class RegistrarPersona
{
    private readonly MicrofinanzaContext db;
    public RegistrarPersona(MicrofinanzaContext _db)
    {
        db = _db;
    }

    public string RegistrarPersonaNatural(RegistrarPersonaData datosPersona)
    {
        try
        {
            var nuevoCliente = new TbPersonaNatural
            {
                IdTipoDocumento = datosPersona.idTipoDocumento,
                NumeroDocumento = datosPersona.numeroDocumento,
                NombreCompleto = datosPersona.nombres + " " + datosPersona.apellidos,
                Nombres = datosPersona.nombres,
                Apellidos = datosPersona.apellidos,
                FechaNacimiento = DateTime.Parse(datosPersona.fechaNacimiento),
                LugarNacimiento = datosPersona.lugarNacimiento,
                PaisResidencia = datosPersona.paisResidencia
            };

            db.TbPersonaNaturals.Add(nuevoCliente);
            db.SaveChanges();

            return "Persona registrado correctamente";
        }
        catch (Exception e)
        {
            return ("Error interno en base de datos" + e);
        }
    }

}
