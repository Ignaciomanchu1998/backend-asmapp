using BackEnd.Models;
using BackEnd.Settings.Globals;
using System.Data;
using System.Data.SqlClient;

namespace BackEnd.Dao
{
    public class PersonaDao: ConnectionDB
    {
        private StructureResponse _sr = new();

        public async Task<StructureResponse> GetAll(){
            var lista = new List<PersonaModel>();
            try
            {
                var cmd = new SqlCommand("uspPersonaGetAll", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                con.Open();

                await using SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read()){
                    _sr.response(reader.GetString(0), reader.GetString(1), reader.GetString(2));
                    if(_sr.code=="1"){
                        var item = new PersonaModel
                        {
                            idPersona = reader.GetInt32(3),
                            tipoDocumento = new()
                        };
                        item.tipoDocumento.descripcion = reader.GetString(4);
                        item.nroDocumento = reader.GetString(5);
                        item.primerNombre = reader.GetString(6);
                        item.segundoNombre = reader.GetString(7);
                        item.primerApellido = reader.GetString(8);
                        item.segundoApellido = reader.GetString(9);
                        item.nombreCompleto = reader.GetString(10);
                        item.fechaNacimiento = reader.GetString(11);
                        item.email = reader.GetString(12);
                        item.telefono = reader.GetString(13);
                        item.pais = new();
                        item.pais.descripcion = reader.GetString(14);
                        item.provincia = new();
                        item.provincia.descripcion = reader.GetString(15);
                        item.parroquia = new();
                        item.parroquia.descripcion = reader.GetString(16);
                        item.direccion = reader.GetString(17);
                        item.fechaRegistro = reader.GetString(18);
                        item.estado = reader.GetBoolean(19);
                        lista.Add(item);
                    }
                }
                con.Close();
                _sr.data = lista;
            }catch(Exception ex){
                _sr.response("0", ex.Message, "Error al listar Persona");
            }
            return _sr;                        
        }

        public async Task<StructureResponse> Post(string json){
            try
            {
              var cmd = new SqlCommand("uspPersonaInsert", con);
              cmd.Parameters.AddWithValue("json", json);
              cmd.CommandType = CommandType.StoredProcedure;
              con.Open();
              await using SqlDataReader reader =  cmd.ExecuteReader();
              while(reader.Read()){
                   _sr.response(reader.GetString(0), reader.GetString(1), reader.GetString(3));
              }
              con.Close();
            }catch(Exception ex){
                _sr.response("0", ex.Message, "Error al Guardar");
            }
            return _sr;
        }

        public async Task<StructureResponse> Put(string json){
            try
            {
                var cmd = new SqlCommand("uspPersonaUpdate", con);
                cmd.Parameters.AddWithValue("json", json);
                cmd.CommandType = CommandType.StoredProcedure; 
                con.Open();
                await using SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read()){
                    _sr.response(reader.GetString(0), reader.GetString(1), reader.GetString(2));
                }
                con.Close();
            }catch(Exception ex){
                _sr.response("0", ex.Message, "Error al Actualizar");
            }
            return _sr;
            
        }

        public async  Task<StructureResponse> Delete(int idPersona){
            try
            {
                var cmd = new SqlCommand("uspPersonaDelete", con);
                cmd.Parameters.AddWithValue("idPersona", idPersona);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                await using SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read()){
                    _sr.response(reader.GetString(0), reader.GetString(1), reader.GetString(2));
                }
                con.Close();
            }
            catch (Exception ex)
            {                
                _sr.response("0", ex.Message, "Error al Eliminar");
            }
            return _sr;
        }

    }
}
