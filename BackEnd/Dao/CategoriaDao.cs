using BackEnd.Models;
using BackEnd.Settings.Globals;
using System.Data;
using System.Data.SqlClient;

namespace BackEnd.Dao
{
    public class CategoriaDao: ConnectionDB
    {
        private StructureResponse _struct = new();

        public async Task<StructureResponse> CategoriaGetAll()
        {
            List<CategoriaModel> data = new();
            try
            {
                using (SqlCommand cmd = new SqlCommand("uspCategoriaList", con))
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
                                CategoriaModel item = new();
                                item.idCategoria = readerAsync.GetInt32(3);
                                item.code = readerAsync.GetInt32(4);
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

        public async Task<StructureResponse> CategoriaPost(CategoriaModel data)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("uspCategoriaPost", con))
                {
                    cmd.Parameters.AddWithValue("code", data.code);
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

        public async Task<StructureResponse> CategoriaPut(CategoriaModel data)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("uspCategoriaPut", con))
                {
                    cmd.Parameters.AddWithValue("idCategoria", data.idCategoria);
                    cmd.Parameters.AddWithValue("idProvincia", data.code);
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

        public async Task<StructureResponse> CategoriaDelete(int idCategoria)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("uspCategoriaDelete", con))
                {
                    cmd.Parameters.AddWithValue("idCategoria", idCategoria);
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
