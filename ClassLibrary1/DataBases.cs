using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.OleDb;
using System.Data;

namespace ClassLibrary1
{
    public class DataBases
    {
        OleDbConnection cnx;

        string providerStr = "Provider=Microsoft.SQLSERVER.CE.OLEDB.3.5;";
        string cnxStr;
        private string p;

        public DataBases(string p)
        {
            // TODO: Complete member initialization
            this.p = p;
        }

        public void DBGestion(string dbFileName)
        {
            cnxStr = providerStr + "Data Source=" + dbFileName + ";Persist Security Info=False;";
        }

        // Open the connection with the database
        public int openDB()
        {
            try
            {
                cnx = new OleDbConnection(cnxStr);
                cnx.Open();
            }
            catch (OleDbException)
            {
                // Error abriendo la base de datos
                return -1;
            }
            return 0;
        }
        public int AddDB(string id, int compañia, double latitud, double longitud)
        {
            try
           {
                string str_latitud = Convert.ToString(latitud);
                string str_longitud = Convert.ToString(longitud);
                string filename = Path.GetFileName(id);
                string query = "INSERT INTO FILE Values('" + filename + "', " + str_latitud + ", " + str_longitud + ",'" + id + "')";
                //string query = "INSERT INTO IMG Values('prova.ppm', " + ancho + ", " + alto + ") ";
                OleDbCommand command = new OleDbCommand(query, cnx);
                int res = command.ExecuteNonQuery(); 
                
                if (res != 1)
                {
                    
                    return -2;
                }
                
           }
            catch (OleDbException)
            {
                // Error abriendo la base de datos
                return -1;
            }
            return 0;
        }
        public int UpdateDb(string id, int compañia, double latitud, double longitud)
        {
            try
            {
                string str_latitud = Convert.ToString(latitud);
                string str_longitud = Convert.ToString(longitud);
                string filename = Path.GetFileName(id);
                string query = "UPDATE FILE SET Latitud='"+str_latitud+"'AND Longitud='"+str_longitud+"' AND Data='" + id + "' WHERE Nombre =‘"+filename+"’";
                //string query = "INSERT INTO IMG Values('prova.ppm', " + ancho + ", " + alto + ") ";
                OleDbCommand command = new OleDbCommand(query, cnx);
                int res = command.ExecuteNonQuery();

                if (res != 1)
                {

                    return -2;
                }

            }
            catch (OleDbException)
            {
                // Error abriendo la base de datos
                return -1;
            }
            return 0;
        }

        
        public void closeDB()//Tanca la base de dades
        {
            if (cnx != null)
            {
                cnx.Close();
                cnx = null;
            }
        }
        public DataTable getAll()//Dona tots les dades del projecte
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM FILE";
            OleDbDataAdapter adp = new OleDbDataAdapter(query, cnx);
            adp.Fill(dt);
            return dt;
        }

        public DataTable getByName(string filter)
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM FILE WHERE nombre LIKE '" + filter + "%'";
            OleDbDataAdapter adp = new OleDbDataAdapter(query, cnx);
            adp.Fill(dt);
            return dt;
        }
        public int eliminar(string nombre)
        {
            if (nombre==null)
            {
                return 0;
            }
            else
            {
                string query = "DELETE FROM FILE WHERE Nombre='" + nombre + "'";
                OleDbCommand command = new OleDbCommand(query, cnx);
                int res = command.ExecuteNonQuery();
                if (res != 1)
                {
                
                    return -1;
                }
                else
                {
                
                    return 0;
                }
            }
        }
    }
}
