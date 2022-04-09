namespace BackEnd.Models
{
    public class ProvinciaModel
    {
        public int idProvincia { get; set; }
        public PaisModel? pais { get; set; }
        public string? descripcion { get; set; }
        public bool estado { get; set; }
    }
}
