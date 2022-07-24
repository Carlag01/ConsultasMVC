using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsultasMVC.Models.Dto;
using ConsultasMVC.Models.Dao;

namespace ConsultasMVC.Models.Dao
{
    class ClienteDao: DbContext
    {
        SqlDataReader LeerFilas;
        SqlCommand Comando = new SqlCommand();
        //METODOS CRUD
        public List<Cliente> VerRegistros(string Condicion)
        {
            Comando.Connection = Conexion;
            //PROCEDIMIENTO CREADO EN BD
            Comando.CommandText = "VerRegistros";
            //EL TIPO DE COMANDO ES PROCEDIMIENTO ALMACENADO
            Comando.CommandType = CommandType.StoredProcedure;
            //LUEGO ENVIAMOS UN PARAMETRO AL VALOR DEL PROCEDIMIENTO
            Comando.Parameters.AddWithValue("@Condicion", Condicion);
            //ABRIMOS LA CONEXION 
            Conexion.Open();
            //ESTO SERA = A LA EXECUCION DEL COMANDO 
            LeerFilas = Comando.ExecuteReader();

            //SE CREA UNA LISTA GENERICA DONDE SE GUARDA EL PARAMETRO LEERFILAS 
            List<Cliente> ListaGenerica = new List<Cliente>();
            while (LeerFilas.Read())
            {
                //CARGAMOS LA LISTA CON SUS PROPIEDADES
                ListaGenerica.Add(new Cliente
                {
                    ID = LeerFilas.GetInt32(0),
                    Nombre = LeerFilas.GetString(1),
                    Apellido = LeerFilas.GetString(2),
                    Direccion = LeerFilas.GetString(3),
                    Ciudad = LeerFilas.GetString(4),
                    Email = LeerFilas.GetString(5),
                    Telefono = LeerFilas.GetString(6),
                    Ocupacion = LeerFilas.GetString(7),
                });
            }
            //UNA VEZ QUE SE LEAN LOS ATRIBUTOS RETONAMOS EN NUESTRA LISTA 
            LeerFilas.Close();
            Conexion.Close();
            return ListaGenerica;
        }
        public void Insert() { }
        public void Edit() { }
        public void Delete() { }

    }
}
