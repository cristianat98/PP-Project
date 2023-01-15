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
    public partial class AñadirAerolinea : Form
    {
        public AñadirAerolinea()
        {
            InitializeComponent();
        }

        //Función que recoge los datos de la nueva aerolínea y los añade en la base de datos
        private void button1_Click(object sender, EventArgs e)
        {
            string nombre = textNombre.Text;
            string correo = textCorreo.Text;
            if (nombre == "" || correo == "")
                MessageBox.Show("Error en los datos de entrada");
            else
            {
                try
                {
                    int telefono = Convert.ToInt32(textTelefono.Text);
                    int aviones = Convert.ToInt32(textAviones.Text);
                    int vuelos = Convert.ToInt32(textVuelos.Text);
                    int destinos = Convert.ToInt32(textDestinos.Text);
                    DBGestion db = new DBGestion();
                    db.OpenDB();

                    if (db.AñadirDB(nombre, telefono, correo, aviones, vuelos, destinos) == 0)
                        MessageBox.Show("Aerolínea añadida correctamente");

                    db.CloseDB();
                    Close();
                }

                catch (FormatException)
                {
                    MessageBox.Show("Error en los datos de entrada");
                }
            }
        }
    }
}
