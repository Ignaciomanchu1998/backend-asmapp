using BackEnd.Models;
using BackEnd.Settings.Globals;
using System.Data;
using System.Data.SqlClient;

namespace BackEnd.Dao
{
    public class EquipoIngresoComponenteDao: ConnectionDB
    {
        private StructureResponse _struct = new();

        public async Task<StructureResponse> EquipoIngresoConponenteGetAll()
        {
            List<EquipoIngresoComponenteModel> data = new();
            try
            {
                using (SqlCommand cmd = new SqlCommand("uspEquipoIngresoComponenteList", con))
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
                                item.idEquipoIngresoComponente = readerAsync.GetInt32(3);
                                item.equipoIngreso = new();
                                item.equipoIngreso.idEquipoIngreso = readerAsync.GetInt32(4);
                                item.equipoIngreso.serie = readerAsync.GetString(5);
                                item.cantidad = readerAsync.GetInt32(6);
                                item.nombre = readerAsync.GetString(7);
                                item.modelo = readerAsync.GetString(8);
                                item.nroSerie = readerAsync.GetString(9);
                                item.valor = readerAsync.GetDecimal(10);
                                item.usuario = new();
                                item.usuario.idUsuario = readerAsync.GetInt32(11);
                                item.usuario.usuario = readerAsync.GetString(12);
                                item.fechaRegistro = readerAsync.GetString(13);
                                item.estado = readerAsync.GetBoolean(14);
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
                _struct.response("0", ex.Message, "Error");
            }
            return _struct;
        }

        public async Task<StructureResponse> EquipoIngresoConponentePost(EquipoIngresoComponenteModel data)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("uspEquipoIngresoComponenteInsert", con))
                {
                    cmd.Parameters.AddWithValue("idEquipoIngreso", data.equipoIngreso?.idEquipoIngreso);
                    cmd.Parameters.AddWithValue("cantidad", data.cantidad);
                    cmd.Parameters.AddWithValue("nombre", data.nombre);
                    cmd.Parameters.AddWithValue("modelo", data.modelo);
                    cmd.Parameters.AddWithValue("nroSerie", data.nroSerie);
                    cmd.Parameters.AddWithValue("valor", data.valor);
                    cmd.Parameters.AddWithValue("idUsuario", data.usuario?.idUsuario);
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
                _struct.response("0", ex.Message, "Error");
            }
            return _struct;
        }

        public async Task<StructureResponse> EquipoIngresoConponenteUpdate(EquipoIngresoComponenteModel data)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("uspEquipoIngresoComponenteInsert", con))
                {
                    cmd.Parameters.AddWithValue("idEquipoIngresoComponente", data.idEquipoIngresoComponente);
                    cmd.Parameters.AddWithValue("idEquipoIngreso", data.equipoIngreso?.idEquipoIngreso);
                    cmd.Parameters.AddWithValue("cantidad", data.cantidad);
                    cmd.Parameters.AddWithValue("nombre", data.nombre);
                    cmd.Parameters.AddWithValue("modelo", data.modelo);
                    cmd.Parameters.AddWithValue("nroSerie", data.nroSerie);
                    cmd.Parameters.AddWithValue("valor", data.valor);
                    cmd.Parameters.AddWithValue("idUsuario", data.usuario?.idUsuario);
                    cmd.Parameters.AddWithValue("estado", data.estado);
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
                _struct.response("0", ex.Message, "Error");
            }
            return _struct;
        }

        public async Task<StructureResponse> EquipoIngresoConponenteDelete(int idEquipoIngresoComponente)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("uspEquipoIngresoComponenteDelete", con))
                {
                    cmd.Parameters.AddWithValue("idEquipoIngresoComponente", idEquipoIngresoComponente);
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
                _struct.response("0", ex.Message, "Error");
            }
            return _struct;
        }
    }
}
