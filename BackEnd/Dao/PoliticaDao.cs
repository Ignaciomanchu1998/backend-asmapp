using BackEnd.Models;
using BackEnd.Settings.Globals;
using System.Data;
using System.Data.SqlClient;

namespace BackEnd.Dao
{
    public class PoliticaDao : ConnectionDB
    {
        private StructureResponse _struct = new StructureResponse();

        public async Task<StructureResponse> PoliticaGetAll()
        {
            var p = new List<PoliticaModel>();
            try
            {
                using (SqlCommand cmd = new SqlCommand("uspPoliticaList", con))
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
                                PoliticaModel item = new();
                                item.idPolitica = readerAsync.GetInt32(3);
                                item.codigo = readerAsync.GetInt32(4);
                                item.descripcion = readerAsync.GetString(5);
                                item.estado = readerAsync.GetBoolean(6);
                                p.Add(item);
                            }
                        }
                    }
                    con.Close();
                }
                _struct.data = p;
            }
            catch (Exception ex)
            {
                _struct.code = "0";
                _struct.message = ex.Message;
                _struct.title = "Error de excepción";
            }
            return _struct;
        }

        public async Task<StructureResponse> PoliticaPost(string json)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("uspPoliticaInsert", con))
                {
                    cmd.Parameters.AddWithValue("json", json);
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


        public async Task<StructureResponse> PoliticaUpdate(string json)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("uspPoliticaUpdate", con))
                {
                    cmd.Parameters.AddWithValue("json", json);
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

        public async Task<StructureResponse> PoliticaDelete(string json)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("uspPolticaDelete", con))
                {
                    cmd.Parameters.AddWithValue("json", json);
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
