namespace BackEnd.Models
{
    public class PersonaModel
    {
        public int idPersona { get; set; }
        public TipoDocumentoModel? tipoDocumento { get; set; }
        public string? nroDocumento { get; set; }
        public string? primerNombre { get; set; }
        public string? segundoNombre { get; set; }
        public string? primerApellido { get; set; }
        public string? segundoApellido { get; set; }
        public string? nombreCompleto { get; set; }
        public string? fechaNacimiento { get; set; }
        public string? email { get; set; }
        public string? telefono { get; set; }
        public int idPais { get; set; }
        public int idProvincia { get; set; }
        public int idParroquia { get; set; }
        public int direccion { get; set; }
        public int fechaRegistro { get; set; }
        public int estado { get; set; }
    }
}
