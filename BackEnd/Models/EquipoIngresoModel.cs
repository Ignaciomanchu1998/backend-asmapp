namespace BackEnd.Models
{
    public class EquipoIngresoModel
    {
        public int idEquipoIngreso { get; set; }
        public PersonaModel persona { get; set; }
        public UsuarioModel usuario { get; set; }
        public OrdenConfiguracionModel ordenConfiguracion { get; set; }
        public EquipoModel equipo { get; set; }
        public string serie { get; set; }
        public string observacion { get; set; }
        public string detalle { get; set; }
        public decimal valor { get; set; }
        public string fechaIngreso { get; set; }
        public string fechaEgreso { get; set; }
        public string fechaRegistro { get; set; }
    }
}
