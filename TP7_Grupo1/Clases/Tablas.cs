using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TP7_Grupo1
{
    public class Tablas
    {

        public Tablas()
        {

        }

        private DataTable ObtenerTabla(string NombreTabla, string sql)
        {
            DataSet ds = new DataSet();
            AccesoDatos datos = new AccesoDatos();
            SqlDataAdapter adp = datos.Obteneradaptador(sql);
            adp.Fill(ds, NombreTabla);
            return ds.Tables[NombreTabla];
        }

        public DataTable CrearTablaSucursales()
        {
            DataTable dt = new DataTable();
            DataColumn Columna = new DataColumn("ID Sucursal", Type.GetType("System.Int"));
            dt.Columns.Add(Columna);

            Columna = new DataColumn("Nombre Sucursal", Type.GetType("System.String"));
            dt.Columns.Add(Columna);

            Columna = new DataColumn("Descripcion Sucursal", Type.GetType("System.Int")); //Hay que comprobar si son tipo INT o String
            dt.Columns.Add(Columna);

         
            return dt;
        }

        private void AgregarFila(DataTable tabla, String IDSucu, string NombreSucu, string DescSucu)
        {
            DataRow dr = tabla.NewRow();
            dr["ID Sucursal"] = IDSucu;
            dr["Nombre Sucursal"] = NombreSucu;
            dr["Descripcion Sucursal"] = DescSucu;
            
            tabla.Rows.Add(dr);
        }


    }

   
}