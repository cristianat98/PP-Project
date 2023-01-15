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
    public partial class ModificarAvion : Form
    {
        //Variables del Formulario Modificar Avión
        Avio av;
        List<Ciudades> lc = new List<Ciudades>();

        public ModificarAvion()
        {
            InitializeComponent();
        }

        //Método que rellena el combo Box con las ciudades
        public void SetCiudades(List<Ciudades> listaciudades, Avio avion)
        {
            this.av = avion;
            this.lc = listaciudades;
            for (int i = 0; i < listaciudades.Count; i++)
            {
                comboBox1.Items.Add(lc[i].GetNombre());
            }
        }

        //Botón que cierra el formulario
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        //Botón que permite modificar el avión
        private void button1_Click(object sender, EventArgs e)
        {
            string id = textBoxID.Text;
            if (id == "")
                id = av.GetID();

            string compañia = textBoxC.Text;
            if (compañia == "")
                compañia = av.GetCompañia();

            string cd;
            Coordenades des;
            if (comboBox1.SelectedIndex != -1)
            {
                cd = lc[comboBox1.SelectedIndex].GetNombre();
                des = lc[comboBox1.SelectedIndex].GetCoordenadas();
            }
            else
            {
                cd = av.GetCDestino();
                des = av.GetD();
            }

            double v;
            try
            {
                v = Convert.ToDouble(textBoxV.Text);
            }
            catch (FormatException)
            {
                v = av.GetVelocidad(); 
            }

            av = new Avio(id, compañia, "COrigen", cd, v, new Coordenades(0, 0), des);
            Close();
        }

        //Método que permite devolver el avión
        public Avio devolveravion()
        {
            return this.av;
        }
    }
}
