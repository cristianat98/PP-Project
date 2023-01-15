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
    public partial class Cerrar : Form
    {
        //Variable del Formulario de Cerrar
        int num = 0;

        public Cerrar()
        {
            InitializeComponent();
        }

        //Botón que cierra el programa
        private void button1_Click(object sender, EventArgs e)
        {

            num = -1; 
            Close();
        }

        //Botón que te mantiene en el programa
        private void button2_Click(object sender, EventArgs e)
        {
            num = 0;
            Close();
        }

        //Método que devuelve el número actual
        public int GetNum()
        {
            return this.num;
        }
    }
}
