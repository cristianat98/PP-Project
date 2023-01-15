using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FormsProjecte
{
    public partial class Solucion : Form
    {
        public Solucion()
        {
            InitializeComponent();
        }

        //Función que cargar en el formulario el texto necesario
        public void escribir(int a)
        {
            StreamReader F;
            string nombre = "";
            int numlin = 0;
            if (a == -2)
            {
                nombre = "Cargar Avion.txt";
                numlin = 16;
            }

            else if (a == -3)
            {
                nombre = "Cargar Sector.txt";
                numlin = 12;
            }

            else if (a == -4)
            {
                nombre = "Tiempo de Ciclo.txt";
                numlin = 5;
            }

            else if (a == -5)
            {
                nombre = "Simulacion Automatica.txt";
                numlin = 10;
            }

            F = new StreamReader(nombre);
            string linea;
            int b = -1;
            for (int i = 0; i < numlin; i++)
            {
                linea = F.ReadLine();
                Label label = new Label();
                label.Text = linea;
                label.AutoSize = true;
                b = b + 15;
                label.Location = new Point(12, b);
                Controls.Add(label);
            }
            F.Close();
            button1.Location = new Point(103, b + 20);
        }
        
        //Botón que permite cerrar el Formulario
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}