using BackEnd.Models;
using BackEnd.Settings.Globals;
using System.Data;
using System.Data.SqlClient;

namespace BackEnd.Dao
{
    public class EquipoDao: ConnectionDB
    {
        private StructureResponse _struct = new StructureResponse();

        public async Task<StructureResponse> ProductoGetAll()
        {
            var em = new List<EquipoModel>();
            try
            {
                using (SqlCommand cmd = new SqlCommand("uspEquipoList", con))
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
                                EquipoModel item = new();
                                item.idEquipo = readerAsync.GetInt32(3);
                                item.categoria = new();
                                item.categoria.descripcion = readerAsync.GetString(4);
                                item.descripcion = readerAsync.GetString(5);
                                item.estado  = readerAsync.GetBoolean(6);
                                em.Add(item);
                            }
                        }
                    }
                    con.Close();
                }
                _struct.data = em;
            }
            catch (Exception ex)
            {
                _struct.response("0", ex.Message, "Error");
            }
            return _struct;
        }

        public async Task<StructureResponse> EquipoPost(EquipoModel data)
        {           
            try
            {
                using (SqlCommand cmd = new SqlCommand("uspEquipoInsert", con))
                {
                    cmd.Parameters.AddWithValue("descripcion", data.categoria.descripcion);
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

        public async Task<StructureResponse> EquipoUpdate(EquipoModel data)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("uspEquipoUpdate", con))
                {
                    cmd.Parameters.AddWithValue("idEquipo", data.idEquipo);
                    cmd.Parameters.AddWithValue("descripcion", data.categoria.descripcion);
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

        public async Task<StructureResponse> EquipoDelete(int idEquipo)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("uspEquipoDelete", con))
                {
                    cmd.Parameters.AddWithValue("idEquipo", idEquipo);
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
