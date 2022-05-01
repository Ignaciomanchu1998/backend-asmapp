using System.Data;
using System.Data.SqlClient;
using BackEnd.Models;
using BackEnd.Settings.Globals;

namespace BackEnd.Dao
{
   public class EuipoIngresoComponenteDao : ConnectionDB
   {
      private StructureResponse _struct = new();

      public async Task<StructureResponse> EquipoIngresoComponenteGetAll()
      {
         List<EquipoIngresoComponenteModel> list = new();
         try
         {
            using (SqlCommand cmd = new SqlCommand("uspEquipoIngresoList", con))
            {
               cmd.CommandType = CommandType.StoredProcedure;
               con.Open();
               using (SqlDataReader readerAsync = await cmd.ExecuteReaderAsync())
               {
                  while (await readerAsync.ReadAsync())
                  {
                     _struct.response(readerAsync.GetString(0), readerAsync.GetString(1), readerAsync.GetString(2));
                     if (_struct.code == "1")
                     {
                        EquipoIngresoComponenteModel item = new();
                        item.equipoIngreso = new();
                        item.equipoIngreso.idEquipoIngreso = readerAsync.GetInt32(3);
                        item.cantidad = readerAsync.GetInt32(4);
                        item.nombre = readerAsync.GetString(5);
                        item.modelo = readerAsync.GetString(6);
                        item.nroSerie = readerAsync.GetString(7);
                        item.valor = readerAsync.GetDecimal(8);
                        item.fechaRegistro = readerAsync.GetString(9);
                        item.estado = readerAsync.GetBoolean(10);
                        list.Add(item);
                     }
                  }
               }
               con.Close();
            }
            _struct.data = list;
         }
         catch (Exception ex)
         {
            // TODO
            _struct.response("0", ex.Message, "Error");
         }
         return _struct;
      }

   }
}