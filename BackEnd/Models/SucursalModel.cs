namespace BackEnd.Models
{
    public class SucursalModel
    {
        public int idsucursal { get; set; }
        public EntidadModel entidad { get; set; }
        public string razonSocial { get; set; }
        public string nombrecomercial { get; set; }
        public string direccion { get; set; }
        public string correo { get; set; }
        public string passCorreo { get; set; }
        public string telefono { get; set; }
        public bool estado { get; set; }
    }
}
