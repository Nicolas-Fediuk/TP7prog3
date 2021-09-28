using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;


namespace TP7_Grupo1
{
    public partial class SeleccionarSucursales : System.Web.UI.Page
    {
        //NO SÉ CÓMO HACER QUE USE LA CLASE PARA ESTO, ASÍ QUE LO MANDO COMO FUNCION DIRECTAMENTE

        public DataTable CrearTablaSucursales()
        {
            DataTable dt = new DataTable();
            DataColumn Columna = new DataColumn("ID Sucursal", Type.GetType("System.String"));
            dt.Columns.Add(Columna);

            Columna = new DataColumn("Nombre Sucursal", Type.GetType("System.String"));
            dt.Columns.Add(Columna);

            Columna = new DataColumn("Descripcion Sucursal", Type.GetType("System.String")); //Hay que comprobar si son tipo INT o String
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





        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnSeleccionar_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "eventoSeleccionar") //Envia ID, nombre y descipcion de la sucursal, separados por '/'
            {
                string InfoSucu = e.CommandArgument.ToString();
                string[] Argumentos = InfoSucu.Split('/'); // Divide cada parte en un vector

                string SucuID = Argumentos[0];
                string SucuNombre = Argumentos[1];
                string SucuDesc = Argumentos[2];




                if (Session["SucuSeleccionadas"] == null)
                {
                    DataTable TablaSeleccionados = CrearTablaSucursales();
                    AgregarFila(TablaSeleccionados, SucuID, SucuNombre, SucuDesc);
                    Session["SucuSeleccionadas"] = TablaSeleccionados;
                }
                else
                {
                    DataTable TablaSeleccionados = (DataTable)Session["SucuSeleccionadas"];

                    bool Existe = false;

                    foreach (DataRow row in TablaSeleccionados.Rows) //Revisa cada fila de la tabla
                    {
                        if (SucuID == row["ID Sucursal"].ToString()) // revisa si SucuID ya existe en la tabla
                        {
                            Existe = true;
                        }


                    }

                    if (Existe == false) // En el caso de que no exista, añade la seleccion a la tabla
                    {
                        AgregarFila(TablaSeleccionados, SucuID, SucuNombre, SucuDesc);
                        Session["SucuSeleccionadas"] = TablaSeleccionados;
                    }

                }


            }
        }

        protected void btnProvincias_Command(object sender, CommandEventArgs e)
        {
            if(e.CommandName == "SeleccionarProvincia")
            {
                string id_provincia = e.CommandArgument.ToString();
                DSsucursales.SelectCommand = "SELECT [NombreSucursal], [URL_Imagen_Sucursal], [DescripcionSucursal], [Id_Sucursal] FROM [Sucursal] WHERE ([Id_ProvinciaSucursal] =" + id_provincia + " )";
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if(txtNombre.Text == "")
            {
                DSsucursales.SelectCommand = "SELECT [NombreSucursal], [URL_Imagen_Sucursal], [DescripcionSucursal], [Id_Sucursal] FROM [Sucursal]";
            }
            else
            {
                DSsucursales.SelectCommand = "SELECT [NombreSucursal], [URL_Imagen_Sucursal], [DescripcionSucursal], [Id_Sucursal] FROM [Sucursal] where [NombreSucursal] LIKE '%" + txtNombre.Text + "%'";
            }
        }
    }
}