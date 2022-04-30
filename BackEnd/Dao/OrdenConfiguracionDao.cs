using BackEnd.Models;
using BackEnd.Settings.Globals;
using System.Data;
using System.Data.SqlClient;

namespace BackEnd.Dao
{
    public class OrdenConfiguracionDao : ConnectionDB
    {
        private StructureResponse _struct = new();

        public async Task<StructureResponse> OrdenConfiguracionGetAll()
        {
            List<OrdenConfiguracionModel> data = new();
            try
            {
                using (SqlCommand cmd = new SqlCommand("uspOrdenConfiguracionList", con))
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
                                OrdenConfiguracionModel item = new();
                                item.idOrdenConfiguracion = readerAsync.GetInt32(3);
                                item.codigo = readerAsync.GetInt32(4);
                                item.descripcion = readerAsync.GetString(5);
                                item.rango = readerAsync.GetInt32(6);
                                item.estado = readerAsync.GetBoolean(7);
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

        public async Task<StructureResponse> OrdenConfiguracionPost(OrdenConfiguracionModel data)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("uspOrdenConfiguracionInsert", con))
                {
                    cmd.Parameters.AddWithValue("rango", data.rango);
                    cmd.Parameters.AddWithValue("descripcion", data.descripcion);
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
                _struct.data = data;
            }
            catch (Exception ex)
            {
                _struct.response("0", ex.Message, "Error");
            }
            return _struct;
        }

        public async Task<StructureResponse> OrdenConfiguracionPut(OrdenConfiguracionModel data)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("uspOrdenConfiguracionUpdate", con))
                {
                    cmd.Parameters.AddWithValue("idOrdenConfiguracion", data.idOrdenConfiguracion);
                    cmd.Parameters.AddWithValue("rango", data.rango);
                    cmd.Parameters.AddWithValue("descripcion", data.descripcion);
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
                _struct.data = data;
            }
            catch (Exception ex)
            {
                _struct.response("0", ex.Message, "Error");
            }
            return _struct;
        }

        public async Task<StructureResponse> OrdenConfiguracionDelete(int idOrdenConfiguracion)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("uspOrdenConfiguracionDelete", con))
                {
                    cmd.Parameters.AddWithValue("idOrdenConfiguracion", idOrdenConfiguracion);
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
