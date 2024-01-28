using APIRestPersonasNaturales.Dominio.UseCases;
using APIRestPersonasNaturales.Infraestructura.EntityFrameworkContext;
using APIRestPersonasNaturales.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIRestPersonasNaturales.Controllers
{
    [ApiController]
    [Route("persona")]
    public class UserController : Controller
    {
        private readonly BuscarPersona Buscar;
        private readonly ActualizarDatosPersona Actualizar;
        private readonly RegistrarPersona Registrar;

        //private readonly MicrofinanzaContext db;

        public UserController(MicrofinanzaContext db)
        {
            Buscar = new BuscarPersona(db);
            Actualizar = new ActualizarDatosPersona(db);
            Registrar = new RegistrarPersona(db);
        }

        [HttpPost("/registrarPersona")]
        public ActionResult RegistrarPerson(RegistrarPersonaData personaRegistrar)
        {
            int[] tipoDocumentoValido = { 1, 2 };
            bool lerror = false;
            if (tipoDocumentoValido.Contains(personaRegistrar.idTipoDocumento??0))
            {
                if (personaRegistrar.idTipoDocumento == 1)
                {
                    if (personaRegistrar.numeroDocumento.Length == 8)
                        return StatusCode(200, Registrar.RegistrarPersonaNatural(personaRegistrar));

                    else
                        return StatusCode(400, "DNI invalido, debe contener 8 caracteres");
                }
                else if (personaRegistrar.idTipoDocumento == 2)
                {
                    if (personaRegistrar.numeroDocumento.Length == 12)
                        return StatusCode(200, Registrar.RegistrarPersonaNatural(personaRegistrar));
                    else
                        return StatusCode(400, "Carnet de extranjeria invalido, debe contener 12 caracteres");
                }
            }
            else
            {
                return StatusCode(400, "Tipo de documento invalido");
            }
            return StatusCode(200, Registrar.RegistrarPersonaNatural(personaRegistrar));
        }
        [HttpGet("/buscarPersona")]
        public IActionResult BuscarPersona(int idTipoDocumento, string numeroDocumento) 
        {
            int[] tipoDocumentoValido = { 1, 2 };
            if (tipoDocumentoValido.Contains(idTipoDocumento))
            {
                if (idTipoDocumento == 1) {
                    if(numeroDocumento.Length == 8)
                        return StatusCode(200,Buscar.BuscarPersonaNatural(idTipoDocumento, numeroDocumento));
                    else
                        return StatusCode(400, "DNI invalido, debe contener 8 caracteres");
                }
                else if (idTipoDocumento == 2)
                { 
                    if(numeroDocumento.Length == 12)
                        return StatusCode(200, Buscar.BuscarPersonaNatural(idTipoDocumento, numeroDocumento));
                    else
                        return StatusCode(400, "Carnet de extranjeria invalido, debe contener 12 caracteres");
                }
            }
            else {
                return StatusCode(400, "Tipo de documento invalido");            
            }
            return StatusCode(200, "Igrese tipo documento valido y numero de documento valido");            
        }
        [HttpPut("/actualizarPersona")]
        public ActionResult ActualizarPersona(int numeroDocumento, ActualizarPersona datos) 
        {
            return StatusCode(200, Actualizar.ActualizarPersonaNatural(numeroDocumento, datos));
        }


    }
}
