using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseDatos;

namespace Validaciones
{
    public class Validar
    {
        Conexion conexion = new Conexion();

        public List<EntPersonas> Mostrar()
        {
            try
            {
                List<EntPersonas> Lista = new List<EntPersonas>();
                DataTable tabla = conexion.Mostrar();
                foreach (DataRow valor in tabla.Rows)
                {
                    EntPersonas x = new EntPersonas();
                    x.id = Convert.ToInt32(valor["Id"]);
                    x.Nombre = valor["Nombre"].ToString();
                    x.Nacionalidad = valor["Nacionalidad"].ToString();
                    x.Fecha = valor["fecha"].ToString();
                    Lista.Add(x);
                }
                return Lista;
            }
            catch (Exception)
            {

                return new List<EntPersonas>();
            }
        }

        public string Agregar(string Nombre, String Nacionalidad, string Fecha)
        {
            int Respuesta = conexion.Agregar(Nombre, Nacionalidad, Fecha);
            if (Respuesta == 1)
            {
                return "Persona Agregada";
            }
            else
                return "Error al agregar";
        }
    }
}
