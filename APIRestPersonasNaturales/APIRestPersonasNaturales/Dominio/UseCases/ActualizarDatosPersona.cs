using APIRestPersonasNaturales.Infraestructura.EntityFrameworkContext;
using APIRestPersonasNaturales.Models;
using Microsoft.EntityFrameworkCore;

namespace APIRestPersonasNaturales.Dominio.UseCases
{
    public class ActualizarDatosPersona
    {
        private readonly MicrofinanzaContext db;
        public ActualizarDatosPersona(MicrofinanzaContext _db)
        {
            db = _db;
        }
        public string ActualizarPersonaNatural(int cDocumento, ActualizarPersona datosPersona)
        {
            try 
            {
                var clienteActualizar = db.TbPersonaNaturals.FirstOrDefault(c => c.NumeroDocumento == cDocumento.ToString());

                if (clienteActualizar != null)
                {
                    // Actualiza los campos deseados
                    clienteActualizar.Nombres = datosPersona.nombres;
                    clienteActualizar.Apellidos = datosPersona.apellidos;
                    clienteActualizar.NombreCompleto = datosPersona.nombres + " "+ datosPersona.apellidos;
                    clienteActualizar.LugarNacimiento = datosPersona.lugarNacimiento;
                    clienteActualizar.PaisResidencia = datosPersona.paisResidencia;
                    clienteActualizar.FechaNacimiento = DateTime.Parse(datosPersona.fechaNacimiento);

                    // Guarda los cambios en la base de datos
                    db.SaveChanges();
                }
                return ("Cliente con numero " + cDocumento + " se actualizo correctamente");
            }
            catch(Exception e)
            {
                return "Erro interno de servidor "+e;
            }
        }
    }
}
