using CRUDWebForms.Modelo;
using System;
using System.Collections.Generic;
using System.Web.UI;
using static CRUDWebForms.Modelo.Conexion;

namespace CRUDWebForms
{
    public partial class Listar_productos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarProductos();
            }
        }

        private void CargarProductos()
        {
            Conexion db = new Conexion();
            List<Producto> productos = db.ObtenerTodosLosProductos();

            // Asignar la lista de productos al GridView
            gvProductos.DataSource = productos;
            gvProductos.DataBind();
        }


    }
}
