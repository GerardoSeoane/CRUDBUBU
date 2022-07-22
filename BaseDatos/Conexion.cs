using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDatos
{
    public class Conexion
    {

        private SqlConnection con = new SqlConnection("Server=localhost;Database=Curso;User id = sa;Password=12345");
        public void Conectar()
        {
            con.Open();
        }
        public void Desconectar()
        {
            con.Close();
        }

        public DataTable Mostrar()
        {
            try
            {
                Conectar();
                DataTable Tabla = new DataTable();
                string query = "select * from persona";
                SqlDataAdapter comando = new SqlDataAdapter(query, con);
                comando.Fill(Tabla);
                Desconectar();
                return Tabla;
            }
            catch (Exception)
            {

                return new DataTable();
            }
        }

        public int Agregar(string Nombre,String Nacionalidad,string Fecha)
        {
            int FilasAfectadas = 0;
            try
            {
                Conectar();
                string Query = $"insert into persona  values ('{Nombre}', '{Nacionalidad}','{Fecha}')";
                SqlCommand comando = new SqlCommand(Query, con);
                FilasAfectadas = comando.ExecuteNonQuery();
                Desconectar();
                return FilasAfectadas;
            }
            catch (Exception)
            {

                return FilasAfectadas; ;
            }
        }
    }
}
