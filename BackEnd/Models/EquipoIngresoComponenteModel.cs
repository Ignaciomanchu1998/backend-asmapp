namespace BackEnd.Models
{
   public class EquipoIngresoComponenteModel
   {
      public int idEquipoIngresoComponente { get; set; }
      public EquipoIngresoModel? equipoIngreso { get; set; }
      public int cantidad { get; set; }
      public string? nombre { get; set; }
      public string? modelo { get; set; }
      public string? nroSerie { get; set; }
      public decimal valor { get; set; }
      public UsuarioModel? usuario { get; set; }
      public string? fechaRegistro { get; set; }
      public bool estado { get; set; }
   }
}