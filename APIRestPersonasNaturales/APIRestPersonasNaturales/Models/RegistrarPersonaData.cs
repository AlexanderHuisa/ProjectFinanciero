namespace APIRestPersonasNaturales.Models
{
    public class RegistrarPersonaData
    {
        public int? idTipoDocumento { get; set; }
        public string? numeroDocumento { get; set; }
        public string? apellidos { get; set; }
        public string? nombres { get; set; }
        public string? fechaNacimiento { get; set; }
        public string? lugarNacimiento { get; set; }
        public string? paisResidencia { get; set; }
    }
}
