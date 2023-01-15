using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClasesProyecto;

namespace FormsProjecte
{
    public partial class ElegirSector : Form
    {
        //Variables del Formulario
        ListaSectores lista = new ListaSectores();
        Sectors sector;
        bool enc = false;

        public ElegirSector()
        {
            InitializeComponent();
        }

        //Botón que permite cerrar el Formulario
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        //Botón que permite devolver el sector escogido
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
                MessageBox.Show("No se ha seleccionado ninguna opción");

            else
            {
                sector = lista.ConsultarLista(comboBox1.SelectedIndex);
                enc = true;
                Close();
            }
        }

        //Método que devuelve el sector escogido
        public Sectors devsector()
        {
            return sector;
        }

        //Método que permite devolver el sector escogido
        public bool escogido()
        {
            return enc;
        }

        //Método que escribe los sectores
        public void escribirsector(ListaSectores milista)
        {
            int a;
            lista = milista;
            for (int i = 0; i < lista.GetNum(); i++)
            {
                sector = lista.ConsultarLista(i);
                a = i + 1;
                comboBox1.Items.Add(sector.GetNombre());
            }
        }
    }
}
