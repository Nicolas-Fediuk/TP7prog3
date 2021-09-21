﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP7_Grupo1
{
    public partial class ListadoSucursalesSeleccionados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable Seleccionados = (DataTable)Session["SucuSeleccionadas"];
            grdSucuSeleccionadas.DataSource = Seleccionados;
            grdSucuSeleccionadas.DataBind();
        }
    }
}