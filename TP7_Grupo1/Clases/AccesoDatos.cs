using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TP7_Grupo1
{
    public class AccesoDatos
    {
        string RutaDBSucursales = "Data Source=localhost\\sqlexpress;Initial Catalog=BDSucursales;Integrated Security=True";

        public AccesoDatos()
        {

        }

        public SqlConnection Obtenerconexion()
        {
            SqlConnection cn = new SqlConnection(RutaDBSucursales);
            try
            {
                cn.Open();
                return cn;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public SqlDataAdapter Obteneradaptador(string consultaSQL)
        {
            SqlDataAdapter adaptador;
            try
            {
                adaptador = new SqlDataAdapter(consultaSQL, Obtenerconexion());
                return adaptador;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public int EjecutarProcedimientoAlamcenado(SqlCommand comando, string NombreSP)
        {
            int filasCambiadas;
            SqlConnection Conexion = Obtenerconexion();
            SqlCommand cmd = new SqlCommand();
            cmd = comando;
            cmd.Connection = Conexion;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = NombreSP;
            filasCambiadas = cmd.ExecuteNonQuery();
            Conexion.Close();
            return filasCambiadas;
        }







    }

   


}