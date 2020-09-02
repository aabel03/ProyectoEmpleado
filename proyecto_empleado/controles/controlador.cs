using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace proyecto_empleado
{
    public class controlador
    {
        consultas _con = new consultas();
        
        public Tuple<bool, string> valida_datos(string text)
        {
            bool valido = false;
            string mensaje = "";
            if (text != "")
            {
                valido = ingresa_depa(text);

                return Tuple.Create(valido, mensaje);
            }
            else
            {
                mensaje = "Agregue los datos Correctos";
                valido = false;
                return Tuple.Create(valido, mensaje);
            }
        }
        public bool ingresa_depa(string descrip)
        {
            bool ingreso = false;
            //ingreso = _con.insert_departamentos(descrip);
            return ingreso;
        }
        public void busca_empleados()
        {
            _con.departamentos();
        }
        public void lleno_grid_empleados(GridView gv)
        {
            gv.DataSource = null;
            DataTable dgv_lleno = _con.llena_grid_empleados();
            if (dgv_lleno.Rows.Count > 0)
            {
                gv.DataSource = dgv_lleno;
                gv.DataBind();
            }
        }
        public void busca_la_clave(TextBox txt_clave, TextBox nombre, TextBox apellido_p, TextBox apellido_m, DropDownList combo, TextBox sueldo, Calendar fecha_nacimiento, string clave)
        {
            DataTable _busca_empleados = _con.busca_empleado(clave);
            if (_busca_empleados.Rows.Count == 1)
            {
                txt_clave.Text = _busca_empleados.Rows[0]["Clave_Emp"].ToString();
                nombre.Text = _busca_empleados.Rows[0]["Nombre"].ToString();
                apellido_p.Text = _busca_empleados.Rows[0]["ApPaterno"].ToString();
                apellido_m.Text = _busca_empleados.Rows[0]["ApMaterno"].ToString();
                sueldo.Text = _busca_empleados.Rows[0]["Sueldo"].ToString().Trim();
                fecha_nacimiento.SelectedDate=Convert.ToDateTime( _busca_empleados.Rows[0]["FecNac"].ToString());
                combo.SelectedValue = _busca_empleados.Rows[0]["Departamento"].ToString();
            }
        }
        public void llena_combo(DropDownList combo)
        {
            DataTable dep = _con.departamentos();
            combo.Items.Clear();
            if (dep.Rows.Count > 0)
            {
                
                foreach (DataRow m in dep.Rows)
                {
                    ListItem cm_ = new ListItem( m["Descripcion"].ToString(), m["Departamento"].ToString());                    
                    combo.Items.Add(cm_);

                }
                ListItem cm_1 = new ListItem("", "");
                combo.Items.Add(cm_1);                                
                combo.SelectedIndex = -1;
            }
        }
        public Tuple<bool, string> valida_campos(TextBox txt_clave, TextBox nombre, TextBox apellido_p, TextBox apellido_m, DropDownList combo, TextBox sueldo,Calendar calendario)
        {
            bool valida = true;
            string mensaje = "";
            if (txt_clave.Text.Trim() == "")
            {
                valida = false;
                mensaje = "Agregue una Clave Valida";
            }
            else if (nombre.Text.Trim() == "")
            {
                valida = false;
                mensaje = "Agregue Nombre";
            }
            else if (apellido_p.Text.Trim() == "")
            {
                valida = false;
                mensaje = "Agregue Apellido Paterno";
            }
            else if (apellido_m.Text.Trim() == "")
            {
                valida = false;
                mensaje = "Agregue Apellido Materno";
            }
            else if (combo.Text.Trim() == "")
            {
                valida = false;
                mensaje = "Seleccione un Combo";
            }
            else if (sueldo.Text.Trim() == "")
            {
                mensaje = "Agregue un Sueldo";
                valida = false;
            }
            else if (calendario.SelectedDate.ToString("dd-MM-yyyy") == "01-01-0001")
            {
                mensaje = "Agregue una Fecha Valida";
                valida = false;
            }
            if (valida)
            {

                string fecha_nacimiento = string.Empty;
                fecha_nacimiento = calendario.SelectedDate.ToString("dd-MM-yyyy");
                int valor = Convert.ToInt32(combo.SelectedValue.ToString());
                DataTable busca_= _con.busca_empleado(txt_clave.Text);
                if(busca_.Rows.Count>0)
                {
                    valida = _con.actualiza(Convert.ToInt32(txt_clave.Text), nombre.Text, apellido_p.Text, apellido_m.Text, fecha_nacimiento, valor, sueldo.Text);
                    if (valida)
                    {
                        mensaje = "Se actualizo Correctamente";
                    }
                    else
                    {
                        mensaje = "No se actualizo Correctamente";
                    }
                }
                else
                {

                    valida = insert(Convert.ToInt32(txt_clave.Text), nombre.Text, apellido_p.Text, apellido_m.Text, valor, fecha_nacimiento, sueldo.Text);
                    if(valida)
                    {
                        mensaje = "Se agrego Correctamente";
                    }
                    else
                    {
                        mensaje = "No se agrego Correctamente el empleado";
                    }
                }
                
            }


            return Tuple.Create(valida, mensaje);
        }
        public bool insert(int clave,string nombre,string apellido_p,string apellido_m,int id_departamento,string fecha_nacimiento,string sueldo)
        {
            bool guardo = true;
            guardo = _con.insert_empleados(clave, nombre,apellido_p,apellido_m,fecha_nacimiento,id_departamento,sueldo);
            return guardo;
        }

        public bool elimina(int clave, GridView gv)
        {
            bool elimino = true;
            elimino = _con.elimina_empleado(clave);
            if(elimino)
            {
                gv.DataSource = null;
                DataTable dgv_lleno = _con.llena_grid_empleados();
                if (dgv_lleno.Rows.Count > 0)
                {
                    gv.DataSource = dgv_lleno;
                    gv.DataBind();
                }
            }
            return elimino;
        }
    }
     
    }