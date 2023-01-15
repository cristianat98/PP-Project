using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClasesProyecto;
using System.IO;

namespace FormsProjecte
{
    public partial class AñadirVuelos : Form
    {
        //Variables del Formulario Añadir Vuelo
        Avio av;
        List<Ciudades> lc = new List<Ciudades>();

        public AñadirVuelos()
        {
            InitializeComponent();
        }

        //Método que devuelve el avión actual del Formulario
        public Avio Añadiravion()
        {
            return av;
        }

        //Método que rellena los comboBox con las ciudades
        public void SetCiudades(List<Ciudades> listaciudades)
        {
            this.lc = listaciudades;
            for (int i = 0; i < lc.Count; i++)
            {
                comboBox1.Items.Add(lc[i].GetNombre());
                comboBox2.Items.Add(lc[i].GetNombre());
            }
        }

        //Botón que recoge los datos del avión que quiere añadir el usuario
        private void buttonAñadir_Click_1(object sender, EventArgs e)
        {
            string id = textBoxID.Text;
            string compañia = textBoxCompañia.Text;
            if (id == "" || compañia == "")
                MessageBox.Show("Error en los datos de entrada");
            else
            {
            try
            {
                double velocidad = Convert.ToDouble(textBoxVelocidad.Text);
                if (comboBox1.SelectedIndex == -1)
                    MessageBox.Show("No se ha seleccionado ningún origen");

                else if (comboBox2.SelectedIndex == -1)
                    MessageBox.Show("No se ha seleccionado ningún destino");

                else if (comboBox1.SelectedIndex == comboBox2.SelectedIndex)
                    MessageBox.Show("Se han seleccionado las mismas ciudades de origen y destino");

                else
                {
                    string co = lc[comboBox1.SelectedIndex].GetNombre();
                    string cd = lc[comboBox2.SelectedIndex].GetNombre();
                    av = new Avio(id, compañia, co, cd, velocidad, lc[comboBox1.SelectedIndex].GetCoordenadas(), lc[comboBox2.SelectedIndex].GetCoordenadas());
                    Close();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Error en los datos de entrada");
            }
            }
        }
    }
}
