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
    public partial class Error : Form
    {
        //Variables del Formulario Error
        int a = 0;

        public Error()
        {
            InitializeComponent();
        }

        //Botón que permite cerrar el Formulario
        private void Aceptar_Click(object sender, EventArgs e)
        {
            Close();
        }

        //Botón que abre un texto para ayudar a solucionar el problema
        private void Ayuda_Click(object sender, EventArgs e)
        {
            Solucion sol = new Solucion();
            sol.escribir(a);
            sol.ShowDialog();
            Close();
        }

        //Función que escribe en el Formulario el error correspondiente
        public void escribirerror(int a)
        {
            this.a = a;

            if (a == -1)
                label.Text = "Fichero no encontrado";
            else if (a == -2)
                label.Text = "Error en cargar la lista de aviones";
            else if (a == -3)
                label.Text = "Error cargar la lista de sectores";
            else if (a == -4)
                label.Text = "Error: Debe introducir un tiempo de ciclo";
            else if (a == -5)
                label.Text = "Error: Debe introducir un tiempo total";
        }
    }
}
