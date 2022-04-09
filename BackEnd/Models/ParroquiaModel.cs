namespace BackEnd.Models
{
    public class ParroquiaModel
    {
        public int idParroquia { get; set; }
        public CantonModel? canton { get; set; }
        public string? descripcion { get; set; }
        public bool estado { get; set; }
    }
}
