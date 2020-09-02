using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;


namespace proyecto_empleado
{
    public class conexion
    {
        public SqlConnection conecta()
        {
            try
            {
                //string cadena = @"Data Source=DESKTOP-0C95HBE;Initial Catalog=proyecto_empleados;Integrated Security=True";
                string cadena = @"workstation id=DBProyectoEmpleado.mssql.somee.com;packet size=4096;user id=aabel03_SQLLogin_1;pwd=1m926krn5e;data source=DBProyectoEmpleado.mssql.somee.com;persist security info=False;initial catalog=DBProyectoEmpleado";
                SqlConnection cnn = new SqlConnection(cadena);
                cnn.Open();
                return cnn;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }
    }
}