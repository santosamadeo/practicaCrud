using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Runtime.InteropServices.ObjectiveC;

namespace practicaCrud1.Clases
{
    internal class Transacciones
    {
        string sql = "";
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        Estudiantes estudiante = new Estudiantes();

        public Transacciones()
        {
            this.con.ConnectionString=
                "Data Source=AMADEO;Initial Catalog=estudiante; Integrated Security=true";
        }
        public DataTable consultar(string nombreTabla)
        {
            DataTable datos= new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();

            switch(nombreTabla)
            {
                case "Estudiante": this.sql = "select * from Estudiante";
                break;
                case "Direccion": this.sql = "select * from Direccion";
                break;
                default: MessageBox.Show("no existe esta tabla");
                break;
            }
            try
            {
                this.con.Open();
                adapter = new SqlDataAdapter(this.sql, con.ConnectionString);
                adapter.Fill(datos);
            }
            catch (Exception ex)
            {
                MessageBox.Show("no se hizo la conexion con la base de datos");
            }
            return datos;
        }

        public bool insertar(string nombreTabla, Object obj)
        {
            switch (nombreTabla)
            {
                case "Estudiante":
                    this.estudiante = (Estudiantes)obj;
                    this.sql="Insert into estudiante value("
                        +this.estudiante.matricula+","
                        +this.estudiante.nombre+","
                        +this.estudiante.apellidos+","
                        +this.estudiante.direccion+")";
                    break;

                default: MessageBox.Show("No existe la tabla para registrar");
                break;
            }
            try
            {
                this.cmd.CommandText = this.sql;
                this.cmd.Connection = this.con;
                this.cmd.Connection.Open();
                this.cmd.ExecuteNonQuery();
                return true;

            }catch(Exception ex)
            {
                return false;
            }
        }

        public bool ejecutar(string sql)
        {
            try {
                this.cmd.CommandText = this.sql;
                this.cmd.Connection = this.con;
                this.cmd.Connection.Open();
                this.cmd.ExecuteNonQuery();
                return true;
            }
            catch(Exception ex){
                return false;
            }
        }
         public bool eliminar(string tabla, string campoId,string valor)
        {
            this.sql = "delete from " + tabla + " where " + campoId + "=" + valor;
            if (ejecutar(this.sql))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        

    }
}
