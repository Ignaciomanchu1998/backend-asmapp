using BackEnd.Models;
using BackEnd.Settings.Globals;
using System.Data;
using System.Data.SqlClient;

namespace BackEnd.Dao
{
    public class PaisDao: ConnectionDB
    {
        private StructureResponse _struct = new();

        public async Task<StructureResponse> PaisGetAll()
        {
            List<PaisModel> data = new();
            try
            {
                using (SqlCommand cmd = new SqlCommand("uspPaisList", con))
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
                                PaisModel item = new();
                                item.idPais = readerAsync.GetInt32(3);
                                item.codigo = readerAsync.GetInt32(4);
                                item.descripcion = readerAsync.GetString(5);
                                item.nacionalidad = readerAsync.GetString(6);
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

        public async Task<StructureResponse> PaisPost(PaisModel data)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("uspPaisInsert", con))
                {
                    cmd.Parameters.AddWithValue("idPais", data.codigo);
                    cmd.Parameters.AddWithValue("descripcion", data.descripcion);
                    cmd.Parameters.AddWithValue("nacionalidad", data.nacionalidad ?? "");
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

        public async Task<StructureResponse> PaisPut(PaisModel data)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("uspPaisUpdate", con))
                {
                    cmd.Parameters.AddWithValue("idPais", data.idPais);
                    cmd.Parameters.AddWithValue("codigo", data.codigo);
                    cmd.Parameters.AddWithValue("descripcion", data.descripcion);
                    cmd.Parameters.AddWithValue("nacionalidad", data.nacionalidad);
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

        public async Task<StructureResponse> PaisDelete(int idPais)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("uspPaisDelete", con))
                {
                    cmd.Parameters.AddWithValue("idPais", idPais);
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
