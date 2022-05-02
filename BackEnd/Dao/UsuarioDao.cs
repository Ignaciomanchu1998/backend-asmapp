using BackEnd.Models;
using BackEnd.Settings.Globals;
using System.Data;
using System.Data.SqlClient;

namespace BackEnd.Dao
{
    public class UsuarioDao: ConnectionDB
    {
        private StructureResponse _struct = new();

        public async Task<StructureResponse> UsuarioGetAll()
        {
            List<UsuarioModel> data = new();
            try
            {
                using (SqlCommand cmd = new SqlCommand("uspUsuarioList", con))
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
                                UsuarioModel item = new();
                                item.idUsuario = readerAsync.GetInt32(3);
                                item.persona = new();
                                item.persona.nroDocumento = readerAsync.GetString(4);
                                item.persona.nombreCompleto = readerAsync.GetString(5);
                                item.usuario = readerAsync.GetString(6);
                                item.fechaRegistro = readerAsync.GetString(7);
                                item.estado = readerAsync.GetBoolean(8);
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

        public async Task<StructureResponse> UsuarioGetById(int idUsuario)
        {
            List<UsuarioModel> data = new();
            try
            {
                using (SqlCommand cmd = new SqlCommand("uspUsuarioListById", con))
                {
                    cmd.Parameters.AddWithValue("idUsuario", idUsuario);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    using (SqlDataReader readerAsync = await cmd.ExecuteReaderAsync())
                    {
                        while (await readerAsync.ReadAsync())
                        {
                            _struct.response(readerAsync.GetString(0), readerAsync.GetString(1), readerAsync.GetString(2));
                            if (_struct.code == "1")
                            {
                                UsuarioModel item = new();
                                item.idUsuario = readerAsync.GetInt32(3);
                                item.persona = new();
                                item.persona.nroDocumento = readerAsync.GetString(4);
                                item.persona.nombreCompleto  = readerAsync.GetString(5);
                                item.usuario = readerAsync.GetString(6);
                                item.fechaRegistro = readerAsync.GetString(7);
                                item.estado = readerAsync.GetBoolean(8);
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

        public async Task<StructureResponse> UsuarioPost(UsuarioModel data)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("uspUsuarioInsert", con))
                {
                    cmd.Parameters.AddWithValue("idPersona", data.persona.idPersona);
                    cmd.Parameters.AddWithValue("usuario", data.usuario);
                    cmd.Parameters.AddWithValue("contrasenia", data.contrasenia);
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

        public async Task<StructureResponse> UsuarioPut(UsuarioModel data)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("uspUsuarioUpdate", con))
                {
                    cmd.Parameters.AddWithValue("idUsuario", data.idUsuario);
                    cmd.Parameters.AddWithValue("idPersona", data.persona.idPersona);
                    cmd.Parameters.AddWithValue("usuario", data.usuario);
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

        public async Task<StructureResponse> UsuarioDelete(int idUsuario)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("uspUsuarioDelete", con))
                {
                    cmd.Parameters.AddWithValue("idUsuario", idUsuario);
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
