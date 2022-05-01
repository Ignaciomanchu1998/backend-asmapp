using BackEnd.Models;
using BackEnd.Settings.Globals;
using System.Data;
using System.Data.SqlClient;

namespace BackEnd.Dao
{
    public class CantonDao: ConnectionDB
    {
        private StructureResponse _struct = new();

        public async Task<StructureResponse> CantonGetById(int idProvincia)
        {
            List<CantonModel> data = new();
            try
            {
                using (SqlCommand cmd = new SqlCommand("uspCantonListById", con))
                {
                    cmd.Parameters.AddWithValue("idProvincia", idProvincia);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    using (SqlDataReader readerAsync = await cmd.ExecuteReaderAsync())
                    {
                        while (await readerAsync.ReadAsync())
                        {
                            _struct.response(readerAsync.GetString(0), readerAsync.GetString(1), readerAsync.GetString(2));
                            if (_struct.code == "1")
                            {
                                CantonModel item = new();
                                item.idCanton = readerAsync.GetInt32(3);
                                item.provincia = new();
                                item.provincia.idProvincia= readerAsync.GetInt32(4);
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

        public async Task<StructureResponse> CantonPost(CantonModel data)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("uspCantonPost", con))
                {
                    cmd.Parameters.AddWithValue("idProvincia", data.provincia?.idProvincia);
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

        public async Task<StructureResponse> CantonPut(CantonModel data)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("uspCantonPut", con))
                {
                    cmd.Parameters.AddWithValue("idCanton", data.idCanton);
                    cmd.Parameters.AddWithValue("idProvincia", data.provincia?.idProvincia);
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

        public async Task<StructureResponse> CantonDelete(int idCanton)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("uspCantonDelete", con))
                {
                    cmd.Parameters.AddWithValue("idCanton", idCanton);
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
