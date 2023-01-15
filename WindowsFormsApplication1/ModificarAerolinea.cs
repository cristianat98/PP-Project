using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Gestion;

namespace FormsProjecte
{
    public partial class ModificarAerolinea : Form
    {
        //Variables del Formulario Modificar Aerolinea
        string aerolinea;

        public ModificarAerolinea()
        {
            InitializeComponent();
        }

        //Función que permite asignar un valor al nombre de la aerolinea
        public void SetAerolinea(string nombre)
        {
            this.aerolinea = nombre;
        }

        //Botón que permite modificar los datos de la Aerolínea en la Base de Datos
        private void button1_Click(object sender, EventArgs e)
        {
            DBGestion db = new DBGestion();
            db.OpenDB();
            DataTable compañia = db.GetAerolinea(aerolinea);
            string nombre = nombre = textNombre.Text;
            if (nombre == "")
                nombre = aerolinea; 

            int telefono;
            try
            {
                telefono = Convert.ToInt32(textTelefono.Text);
            }
            catch (FormatException)
            {
                telefono = Convert.ToInt32(compañia.Rows[0][1]);
            }

            string correo = textCorreo.Text;
            if (correo == "")
                correo = Convert.ToString(compañia.Rows[0][2]);

            int aviones;
            try
            {
                aviones = Convert.ToInt32(textAviones.Text);
            }
            catch (FormatException)
            {
                aviones = Convert.ToInt32(compañia.Rows[0][3]);
            }

            int vuelos;
            try
            {
                vuelos = Convert.ToInt32(textVuelos.Text);
            }
            catch(FormatException)
            {
                vuelos = Convert.ToInt32(compañia.Rows[0][4]);
            }

            int destinos;
            try
            {
                destinos = Convert.ToInt32(textDestinos.Text);
            }
            catch (FormatException)
            {
                destinos = Convert.ToInt32(compañia.Rows[0][5]);
            }
            
            if (db.ModificarDB(aerolinea, nombre, telefono, correo, aviones, vuelos, destinos) == 0)
                MessageBox.Show("Aerolínea modificada");
            db.CloseDB();

            Close();
        }
    }
}
