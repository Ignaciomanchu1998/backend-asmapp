using BackEnd.Models;
using BackEnd.Settings.Globals;
using System.Data;
using System.Data.SqlClient;

namespace BackEnd.Dao
{
    public class ParroquiaDao: ConnectionDB
    {
        private StructureResponse _struct = new();

        public async Task<StructureResponse> ParroquiaGetById(int idCanton)
        {
            List<ParroquiaModel> data = new();
            try
            {
                using (SqlCommand cmd = new SqlCommand("uspParroquiaListById", con))
                {
                    cmd.Parameters.AddWithValue("idCanton", idCanton);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    using (SqlDataReader readerAsync = await cmd.ExecuteReaderAsync())
                    {
                        while (await readerAsync.ReadAsync())
                        {
                            _struct.response(readerAsync.GetString(0), readerAsync.GetString(1), readerAsync.GetString(2));
                            if (_struct.code == "1")
                            {
                                ParroquiaModel item = new();
                                item.idParroquia = readerAsync.GetInt32(3);
                                item.canton = new();
                                item.canton.idCanton = readerAsync.GetInt32(4);
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

        public async Task<StructureResponse> ParroquiaPost(ParroquiaModel data)
        {            
            try
            {
                using (SqlCommand cmd = new SqlCommand("uspParroquiaPost", con))
                {
                    cmd.Parameters.AddWithValue("idCanton", data.canton?.idCanton);
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

        public async Task<StructureResponse> ParroquiaPut(ParroquiaModel data)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("uspParroquiaPut", con))
                {
                    cmd.Parameters.AddWithValue("idParroquia", data.idParroquia);
                    cmd.Parameters.AddWithValue("idCanton", data.canton?.idCanton);
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

        public async Task<StructureResponse> ParroquiaDelete(int idParroquia)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("uspParroquiaDelete", con))
                {
                    cmd.Parameters.AddWithValue("idParroquia", idParroquia);
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
