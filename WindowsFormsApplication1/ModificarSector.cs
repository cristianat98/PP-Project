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
    public partial class ModificarSector : Form
    {
        //Variables del Formulario
        Sectors sector;

        public ModificarSector()
        {
            InitializeComponent();
        }

        //Método que permite devolver el sector actual
        public Sectors devolversector()
        {
            return this.sector;
        }

        //Método que asigna un valor al sector
        public void SetSector(Sectors sec)
        {
            this.sector = sec;
        }

        //Botón que permite cerrar el Formulario
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        //Botón que permite asignar valores al sector
        private void button1_Click(object sender, EventArgs e)
        {
            string nombre = nom.Text;
            if (nombre == "")
                nombre = sector.GetNombre();

            double ox;
            try
            {
                ox = Convert.ToDouble(OX.Text);
            }
            catch (FormatException)
            {
                ox = sector.GetNO().GetX();
            }

            double oy;
            try
            {
                oy = Convert.ToDouble(OY.Text);
            }
            catch (FormatException)
            {
                oy = sector.GetNO().GetY();
            }

            double dx;
            try
            {
                dx = Convert.ToDouble(DX.Text);
            }
            catch (FormatException)
            {
                dx = sector.GetSE().GetX();
            }

            double dy;
            try
            {
                dy = Convert.ToDouble(DY.Text);
            }

            catch (FormatException)
            {
                dy = sector.GetSE().GetY();
            }

            if (ox > 700)
                ox = 700;
            if (oy > 600)
                oy = 600;
            if (dx > 700)
                dx = 700;
            if (dy > 600)
                dy = 600;

            if (ox == dx)
                MessageBox.Show("Este sector no se puede modificar, las coordenadas X son las mismas");
            else if (oy == dy)
                MessageBox.Show("Este sector no se puede modificar, las coordenadas Y son las mismas");
            else
            {
                if (ox > dx)
                {
                    double ox2 = ox;
                    ox = dx;
                    dx = ox2;
                }

                if (oy > dy)
                {
                    double oy2 = oy;
                    oy = dy;
                    dy = oy2;
                }
 
                sector = new Sectors(new Coordenades(ox, oy), new Coordenades(dx, dy), nombre);
                Close();
            }
        }
    }
}
