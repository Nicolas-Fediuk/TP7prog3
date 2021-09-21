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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                DataSet ds = new DataSet();

                SqlConnection cn = new SqlConnection("Data Source=laptop-d5dkhvl7\\sqlexpress01;Initial Catalog=BDSucursales;Integrated Security=True");
                cn.Open();
                SqlDataAdapter adaptador = new SqlDataAdapter("select NombreSucursal,URL_Imagen_Sucursal,DescripcionSucursal from Sucursal", cn);

                adaptador.Fill(ds, "Sucursales");

                lvSucursales.DataSource = ds.Tables["Sucursales"];
                lvSucursales.DataBind();

                dlSucursales.DataSource = ds.Tables["Sucursales"];
                dlSucursales.DataBind();
            }
        }
    }
}