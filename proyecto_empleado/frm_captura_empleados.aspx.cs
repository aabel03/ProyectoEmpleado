using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
namespace proyecto_empleado
{
    public partial class frm_captura_empleados : System.Web.UI.Page
    {
        controlador _con = new controlador();
        protected void Page_Load(object sender, EventArgs e)
        {
            string clave = string.Empty;
            
            if (!Page.IsPostBack)
            {
                _con.llena_combo(cmb_departamentos);
                if (Request.QueryString["clave"] != "" && Request.QueryString["clave"] != null)
                {
                    clave = Request.QueryString["clave"];
                    _con.busca_la_clave(txt_clave, txt_nombre, txt_apellido_p, txt_apellido_m, cmb_departamentos, txt_sueldo, dtp_fecha_nacimiento, clave);

                }
            }
        }
       
        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                
                var confirmacion= _con.valida_campos(txt_clave, txt_nombre, txt_apellido_p, txt_apellido_m, cmb_departamentos, txt_sueldo,dtp_fecha_nacimiento);
                if(!confirmacion.Item1)
                {
                    string scriptConfirmacion = "<script type='text/javascript'>alert('" + confirmacion.Item2.ToString() + "');</script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Confirmación", scriptConfirmacion, false);

                }
                else
                {
                    string scriptConfirmacion = "<script type='text/javascript'>alert('" + confirmacion.Item2.ToString() + "'');</script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Confirmación", scriptConfirmacion, false);
                    Response.Redirect("frm_empleados.aspx");
                }                
            }
            catch (Exception xd)
            {

                throw;
            }
           
        }

        protected void dtp_fecha_nacimiento_SelectionChanged(object sender, EventArgs e)
        {
           
        }

        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("frm_empleados.aspx");
        }

        protected void cmb_departamentos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}