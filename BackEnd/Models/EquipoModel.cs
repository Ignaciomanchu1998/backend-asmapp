namespace BackEnd.Models
{
    public class EquipoModel
    {
        public int idEquipo { get; set; }
        public CategoriaModel categoria { get; set; }
        public string descripcion { get; set; }
        public bool estado { get; set; }
    }
}
