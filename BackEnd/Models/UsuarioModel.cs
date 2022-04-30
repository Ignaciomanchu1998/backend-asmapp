namespace BackEnd.Models
{
    public class UsuarioModel
    {
        public int idUsuario { get; set; }
        public PersonaModel persona { get; set; }
        public string usuario { get; set; }
        public string contrasenia { get; set; }
        public string imagen { get; set; }
        public string fechaRegistro { get; set; }
        public bool estado { get; set; }
    }
}
