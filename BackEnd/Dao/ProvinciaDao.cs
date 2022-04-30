using BackEnd.Models;
using BackEnd.Settings.Globals;
using System.Data;
using System.Data.SqlClient;

namespace BackEnd.Dao
{
    public class ProvinciaDao: ConnectionDB
    {
        private StructureResponse _struct = new();

        public async Task<StructureResponse> ProvinciaGetById(int idPais)
        {
            List<ProvinciaModel> data = new();
            try
            {
                using (SqlCommand cmd = new SqlCommand("uspProvinciaListById", con))
                {
                    cmd.Parameters.AddWithValue("idPais", idPais);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    using (SqlDataReader readerAsync = await cmd.ExecuteReaderAsync())
                    {
                        while (await readerAsync.ReadAsync())
                        {
                            _struct.response(readerAsync.GetString(0), readerAsync.GetString(1), readerAsync.GetString(2));
                            if (_struct.code == "1")
                            {
                                ProvinciaModel item = new();
                                item.idProvincia = readerAsync.GetInt32(3);
                                item.pais = new();
                                item.pais.idPais= readerAsync.GetInt32(4);
                                item.descripcion = readerAsync.GetString(5);
                                item.estado = readerAsync.GetBoolean(6);
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

        public async Task<StructureResponse> ProvinciaPost(ProvinciaModel data)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("uspProvinciaPost", con))
                {
                    cmd.Parameters.AddWithValue("idPais", data.pais?.idPais);
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
            }
            catch (Exception ex)
            {
                _struct.response("0", ex.Message, "Error");
            }
            return _struct;
        }

        public async Task<StructureResponse> ProvinciaPut(ProvinciaModel data)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("uspProvinciaPut", con))
                {
                    cmd.Parameters.AddWithValue("idProvincia", data.idProvincia);
                    cmd.Parameters.AddWithValue("idPais", data.pais?.idPais);
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
            }
            catch (Exception ex)
            {
                _struct.response("0", ex.Message, "Error");
            }
            return _struct;
        }

        public async Task<StructureResponse> ProvinciaDelete(int idProvincia)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("uspProvinciaDelete", con))
                {
                    cmd.Parameters.AddWithValue("idProvincia", idProvincia);
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
