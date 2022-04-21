namespace BackEnd.Models
{
    public class EntidadLogoModel
    {
        public int idEntidadLogo { get; set; }
        public EntidadModel entidad { get; set; }
        public int gestion { get; set; }
        public string imagen { get; set; }
        public string fechaRegsitro { get; set; }
        public bool estado { get; set; }
    }
}
