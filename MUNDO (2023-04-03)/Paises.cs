using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.OleDb;
using System.Data;


namespace MUNDO__2023_04_03_
{
    class Paises
    {
        private string cadena = "";
        private OleDbConnection conector;
        private OleDbCommand comando;
        private OleDbDataAdapter adaptador;
        private DataTable tabla;

        
        private int pais;
        private string nombre;
        private string capital;

        public int Pais
        {
            get { return pais; }
            set { pais = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public string Capital
        {
            get { return capital; }
            set { capital = value; }
        }
        public Paises()
        {
            cadena = "provider=microsoft.jet.oledb.4.0;data source=MUNDO.mdb";
            conector = new OleDbConnection(cadena);
            comando = new OleDbCommand();
            comando.Connection = conector;
            comando.CommandType = CommandType.TableDirect;
            comando.CommandText = "Paises";
            adaptador = new OleDbDataAdapter(comando);
            tabla = new DataTable();
            adaptador.Fill(tabla);

            DataColumn[] vector = new DataColumn[1];
            vector[0] = tabla.Columns["pais"];
            tabla.PrimaryKey = vector;

        }
        public void grabar()
        {
            DataRow filaBusca = tabla.Rows.Find(pais);

            if(filaBusca is null)
            {
                DataRow fila = tabla.NewRow();
                fila["pais"] = pais;
                fila["nombre"] = nombre;
                fila["capital"] = capital;
                tabla.Rows.Add(fila);
                OleDbCommandBuilder cb = new OleDbCommandBuilder(adaptador);
                adaptador.Update(tabla);

            } else
            {
                pais = 0;
                nombre = "";
                capital = "";
            }
        }
        public void eliminar()
        {
            DataRow fila = tabla.Rows.Find(pais);
            fila.Delete();
            OleDbCommandBuilder cb = new OleDbCommandBuilder(adaptador);
            adaptador.Update(tabla);

        }
        public void modificar()
        {
            DataRow fila = tabla.Rows.Find(pais);
            fila.BeginEdit();
            fila["nombre"] = nombre;
            fila["capital"] = capital;
            fila.EndEdit();
            OleDbCommandBuilder cb = new OleDbCommandBuilder(adaptador);
            adaptador.Update(tabla);

        }
        public void buscar()
        {
            DataRow fila = tabla.Rows.Find(pais);
            if(fila is null)
            {
                pais = 0;
                nombre = "";
                capital = "";
            }else
            {
                pais = Convert.ToInt32(fila["pais"]);
                nombre = fila["nombre"].ToString();
                capital = fila["capital"].ToString();

            }

        }
        public DataTable getAll()
        {
            return tabla;
        }




    }
}
