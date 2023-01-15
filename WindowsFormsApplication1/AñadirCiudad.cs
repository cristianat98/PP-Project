using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FormsProjecte
{
    public partial class AñadirCiudad : Form
    {
        //Variables del Formulario Añadir Ciudad
        string nombre;
        bool enc = false;

        public AñadirCiudad()
        {
            InitializeComponent();
        }

        //Botón que permite asignar el nombre de la nueva ciudad
        private void button1_Click(object sender, EventArgs e)
        {
            nombre = textBoxNombre.Text;
            if (nombre == "")
                MessageBox.Show("No ha introducido ningún nombre");
            else
            {
                enc = true;
                Close();
            }
        }

        //Método que permite devolver el nombre de la ciudad
        public string GetCiudad()
        {
            if (enc)
                return nombre;
            else
                return null;
        }
    }
}
