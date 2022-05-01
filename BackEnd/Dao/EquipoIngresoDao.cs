using BackEnd.Models;
using BackEnd.Settings.Globals;
using System.Data;
using System.Data.SqlClient;

namespace BackEnd.Dao
{
    public class EquipoIngresoDao : ConnectionDB
    {
        private StructureResponse _struct = new();

        public async Task<StructureResponse> EquipoIngresoGetAll()
        {
            var data = new List<EquipoIngresoModel>();
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
                                EquipoIngresoModel item = new();
                                item.persona.idPersona = readerAsync.GetInt32(3);
                                item.usuario = new();
                                item.usuario.idUsuario = readerAsync.GetInt32(4);
                                item.ordenConfiguracion = new();
                                item.ordenConfiguracion.idOrdenConfiguracion = readerAsync.GetInt32(5);
                                item.ordenConfiguracion.descripcion = readerAsync.GetString(6);
                                item.equipo = new();
                                item.equipo.idEquipo = readerAsync.GetInt32(7);
                                item.equipo.descripcion = readerAsync.GetString(8);
                                item.serie = readerAsync.GetString(9);
                                item.observacion = readerAsync.GetString(10);
                                item.detalle = readerAsync.GetString(11);
                                item.valor = readerAsync.GetDecimal(12);
                                item.fechaIngreso = readerAsync.GetString(13);
                                item.fechaEgreso = readerAsync.GetString(14);
                                data.Add(item);
                            }
                        }
                    }
                    con.Close();
                }
                _struct.data = data;
            }
            catch (Exception ex)
            {
                _struct.response("0", ex.Message, "Error catch");
            }
            return _struct;
        }

        public async Task<StructureResponse> EquipoIngresoPost(EquipoIngresoModel data)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("uspEquipoIngresoPost", con))
                {
                    cmd.Parameters.AddWithValue("idOrdenConfiguracion", data.ordenConfiguracion.idOrdenConfiguracion);
                    cmd.Parameters.AddWithValue("idEquipo", data.equipo.idEquipo);
                    cmd.Parameters.AddWithValue("serie", data.serie);
                    cmd.Parameters.AddWithValue("observacion", data.observacion);
                    cmd.Parameters.AddWithValue("detalle", data.detalle);
                    cmd.Parameters.AddWithValue("valor", data.valor);
                    cmd.Parameters.AddWithValue("fechaIngreso", data.fechaIngreso);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    using (SqlDataReader readerAsync = await cmd.ExecuteReaderAsync())
                    {
                        while (await readerAsync.ReadAsync())
                        {
                            _struct.response(readerAsync.GetString(0), readerAsync.GetString(1), readerAsync.GetString(2));

                        }
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                _struct.response("0", ex.Message, "Error catch");
            }
            return _struct;
        }

        public async Task<StructureResponse> EquipoIngresoUpdate(EquipoIngresoModel data)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("uspEquipoIngresoUpdate", con))
                {
                    cmd.Parameters.AddWithValue("idEquipoIngreso", data.idEquipoIngreso);
                    cmd.Parameters.AddWithValue("idOrdenConfiguracion", data.ordenConfiguracion.idOrdenConfiguracion);
                    cmd.Parameters.AddWithValue("idEquipo", data.equipo.idEquipo);
                    cmd.Parameters.AddWithValue("serie", data.serie);
                    cmd.Parameters.AddWithValue("observacion", data.observacion);
                    cmd.Parameters.AddWithValue("detalle", data.detalle);
                    cmd.Parameters.AddWithValue("valor", data.valor);
                    cmd.Parameters.AddWithValue("fechaIngreso", data.fechaIngreso);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    using (SqlDataReader readerAsync = await cmd.ExecuteReaderAsync())
                    {
                        while (await readerAsync.ReadAsync())
                        {
                            _struct.response(readerAsync.GetString(0), readerAsync.GetString(1), readerAsync.GetString(2));

                        }
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                _struct.response("0", ex.Message, "Error catch");
            }
            return _struct;
        }

        public async Task<StructureResponse> EquipoIngresoDelete(int idEquipoIngreso)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("uspEquipoIngresoUpdate", con))
                {
                    cmd.Parameters.AddWithValue("idEquipoIngreso", idEquipoIngreso);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    using (SqlDataReader readerAsync = await cmd.ExecuteReaderAsync())
                    {
                        while (await readerAsync.ReadAsync())
                        {
                            _struct.response(readerAsync.GetString(0), readerAsync.GetString(1), readerAsync.GetString(2));

                        }
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                _struct.response("0", ex.Message, "Error catch");
            }
            return _struct;
        }
    }
}
