using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace proyecto_empleado
{
    public partial class frm_empleados : System.Web.UI.Page
    {
        controlador _cn = new controlador();
        
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {                
                _cn.lleno_grid_empleados(GridView1);                           
            }

        }

      
        protected void btn_nuevo_empleado_Click(object sender, EventArgs e)
        {
            Response.Redirect("frm_captura_empleados.aspx");
        }

      

        protected void GridView1_RowCommand1(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("Edit"))
                {
                    GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);

                    int index_clave = Convert.ToInt32(((Label)row.FindControl("Clave_Emp")).Text.ToString());                 
                    Response.Redirect("frm_captura_empleados.aspx?clave='"+ index_clave + "' ");
                }
                else if(e.CommandName.Equals("Delete"))
                {
                    GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
                    int index_clave = Convert.ToInt32(((Label)row.FindControl("Clave_Emp")).Text.ToString());                    
                    _cn.elimina(index_clave, GridView1);
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
    }
}