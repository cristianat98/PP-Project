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
    public partial class Ciclo : Form
    {
        //Variables del Formulario del Ciclo
        int tiempociclo;

        public Ciclo()
        {
            InitializeComponent();
        }

        //Botón que recoge el tiempo de ciclo escrito por el usuario
        private void aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                tiempociclo = Convert.ToInt32(textBox1.Text);
                Close();
            }

            catch (FormatException)
            {
                MessageBox.Show("Error en los datos de entrada, debe introducir un número");
            }
        }

        //Método que devuelve el tiempo de ciclo
        public int DameElTiempo()
        {
            return this.tiempociclo;
        }
    }
}
