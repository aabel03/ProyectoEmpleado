using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace proyecto_empleado
{
    public class consultas
    {
        conexion _cone = new conexion();
        public bool insert_empleados(int clave,string nombre,string apellido_p,string apellido_m,string fecha_nacimiento,int departamento,string sueldo)
        {
            
            try
            {               
                string insert = "insert into Empleados (Clave_Emp,Nombre,ApPaterno,ApMaterno,FecNac,Departamento,Sueldo) " +
                                " Values("+ clave + ", '"+ nombre + "', '"+apellido_p+"', '"+ apellido_m + "', '"+fecha_nacimiento+"', "+departamento+", '"+sueldo+"'); ";
                SqlCommand sql = new SqlCommand(insert, _cone.conecta());
                int x = sql.ExecuteNonQuery();
                
                return x>0 ;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        public bool elimina_empleado(int clave)
        {

            try
            {               
                string insert = "DELETE FROM Empleados where Clave_Emp=" + clave+" ";
                SqlCommand sql = new SqlCommand(insert, _cone.conecta());
                int x = sql.ExecuteNonQuery();

                return x > 0;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        public DataTable departamentos()
        {

            string select = "Select * from Departamentos;";
            DataTable data = new DataTable();
            SqlDataAdapter sql = new SqlDataAdapter(select,_cone.conecta());
            sql.Fill(data);
            return data;
        }
        public DataTable llena_grid_empleados()
        {

            string select = " Select e.Clave_Emp,concat(e.Nombre,' ',e.ApPaterno,' ',e.ApMaterno)as nombre,Convert(varchar,FecNac,103)as fecha_nacimiento,d.Descripcion,concat('$',e.Sueldo)as sueldo from  Empleados as e " +
                            " inner join Departamentos as d on e.Departamento = d.Departamento; ; ";
            DataTable data = new DataTable();
            SqlDataAdapter sql = new SqlDataAdapter(select, _cone.conecta());
            sql.Fill(data);
            return data;
        }
        public DataTable busca_empleado(string clave )
        {

            string select = "Select d.Clave_Emp,d.Nombre,d.ApPaterno,d.ApMaterno,cast(round(d.Sueldo,2)as char) as Sueldo,d.Departamento,d.FecNac from Empleados as d where d.Clave_Emp =" + clave+"  ;";
            DataTable data = new DataTable();
            SqlDataAdapter sql = new SqlDataAdapter(select, _cone.conecta());
            sql.Fill(data);
            return data;
        }
        public bool actualiza(int clave, string nombre, string apellido_p, string apellido_m, string fecha_nacimiento, int departamento, string sueldo)
        {

            try
            {
                string insert = "update Empleados set Nombre ='" + nombre + "',ApPaterno='" + apellido_p + "',ApMaterno= '" + apellido_m + "',FecNac='" + fecha_nacimiento + "',Departamento=" + departamento + ",Sueldo='" + sueldo + "' " +
                                " where Clave_Emp = " + clave + ";  ";
                SqlCommand sql = new SqlCommand(insert, _cone.conecta());
                int x = sql.ExecuteNonQuery();

                return x > 0;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }



    }
}