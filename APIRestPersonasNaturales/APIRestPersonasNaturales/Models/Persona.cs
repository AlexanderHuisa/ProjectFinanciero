namespace APIRestPersonasNaturales.Models
{
    public class Persona
    {
        public int idPersona { get; set; }
        public int? idTipoDocumento { get; set; }  
        public string? numeroDocumento { get; set; }
        public string? nombreCompleto { get; set; }
        public string? apellidos { get; set; }
        public string? nombres {  get; set; }    
        public string? fechaNacimiento {  get; set; }
        public string? lugarNacimiento { get; set; } 
        public string? paisResidencia { get; set; }  

    }
}
