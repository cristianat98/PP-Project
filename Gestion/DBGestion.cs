using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.IO;

namespace Gestion
{
    public class DBGestion
    {
        OleDbConnection cnx;
        string providerStr = "Provider=Microsoft.SQLSERVER.CE.OLEDB.3.5;";
        string cnxStr;

        //Constructor que permite obtener conexión con la base de datos
        public DBGestion()
        {
            string dbFileName = "..\\..\\..\\Gestion\\MyDataBase.sdf";
            cnxStr = providerStr + "Data Source=" + dbFileName + ";Persist Security Info=False;";
        }

        //Método que abre la base de datos
        public int OpenDB()
        {
            try
            {
                cnx = new OleDbConnection(cnxStr);
                cnx.Open();
                return 0;
            }
            catch (OleDbException)
            {
                 return -1;
            }
        }

        //Método que devuelve toda la información de la base de datos en un DataTable
        public DataTable GetAll()
        {
            DataTable dtable = new DataTable();
            string query = "SELECT * FROM InformacionCompañias";
            OleDbDataAdapter adapter = new OleDbDataAdapter(query, cnx);
            adapter.Fill(dtable);
            return dtable;
        }

        //Método que devuelve toda la información de una aerolínea en un DataTable
        public DataTable GetAerolinea(string nombre)
        {
            DataTable dtable = new DataTable();
            string query = "SELECT * FROM InformacionCompañias WHERE Nombre= '" + nombre + "'";
            OleDbDataAdapter adapter = new OleDbDataAdapter(query, cnx);
            adapter.Fill(dtable);
            return dtable;
        }
        //Método que devuelve el teléfono de la compañía recibida como parámetro
        public string GetTelefono(string aerolinea)
        {
            DataTable resultado = new DataTable();
            OleDbDataAdapter adapter = new OleDbDataAdapter ("SELECT Teléfono FROM InformacionCompañias WHERE Nombre = '" + aerolinea + "'", cnx);
            adapter.Fill(resultado);
            if (resultado.Rows.Count == 1)
                return Convert.ToString(resultado.Rows[0]["Teléfono"]);

            else
                return "No disponible";
        }

        //Método que devuelve el correo electrónico de la compañía recibida como parámetro
        public string GetEmail(string filter)
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM InformacionCompañias WHERE Nombre = '" + filter + "'";
            OleDbDataAdapter adp = new OleDbDataAdapter(query, cnx);
            adp.Fill(dt);
            if (dt.Rows.Count == 1)
                return Convert.ToString(dt.Rows[0]["Correo Electrónico"]);
            else
                return "No disponible";
        }

        //Método que añade un nuevo registro a la base de datos
        public int AñadirDB(string nombre, int telefono, string correo, int numa, int vd, int numdes)
        {
            string query = "INSERT INTO InformacionCompañias Values('" + nombre + "', " + telefono + ", '" + correo + "', " + numa + ", " + vd + ", " + numdes + ")";
            OleDbCommand command = new OleDbCommand(query, cnx);
            int res = command.ExecuteNonQuery();

            if (res != 1)
                return -1;

            else
                return 0;
        }

        //Método que elimina una aerolínea de la base de datos
        public int BorrarDB(string nombre)
        {
            string query = "DELETE FROM InformacionCompañias WHERE Nombre= '" + nombre + "'";
            OleDbCommand command = new OleDbCommand(query, cnx);
            int res = command.ExecuteNonQuery();

            if (res != 1)
                return -1;

            else
                return 0;
        }

        //Método que modifica los datos de una aerolínea en la base de datos
        public int ModificarDB(string nombre, string nnombre, int telefono, string correo, int numa, int vd, int numdes)
        {
            string query = "UPDATE InformacionCompañias SET Nombre= '" + nnombre + "', Teléfono= " + telefono + ", [Correo Electrónico]= '" + correo + "', [Número de Aviones]= " + numa + ", [Vuelos Diarios]= " + vd + ", [Número de Destinos]= " + numdes + " WHERE Nombre= '" + nombre + "'";
            OleDbCommand command = new OleDbCommand(query, cnx);
            int res = command.ExecuteNonQuery();

            if (res != 1)
                return -1;
            else
                return 0;
        }

        //Método que cierra la base de datos       
        public void CloseDB()
        {
            if (cnx != null)
            {
                cnx.Close();
                cnx = null;
            }
        }
    }
}
