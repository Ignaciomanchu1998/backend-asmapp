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
        public PaisModel? pais { get; set; }
        public ProvinciaModel? provincia { get; set; }
        public ParroquiaModel? parroquia { get; set; }
        public string direccion { get; set; }
        public string fechaRegistro { get; set; }
        public bool estado { get; set; }
    }
}
