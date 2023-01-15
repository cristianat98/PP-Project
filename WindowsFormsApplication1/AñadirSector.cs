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
    public partial class AñadirSector : Form
    {
        //Variables del Formulario Añadir Sector
        Sectors s;

        public AñadirSector()
        {
            InitializeComponent();
        }

        //Método que permite devolver el sector actual
        public Sectors Añadirsector()
        {
            return this.s;
        }

        //Botón que permite recoger la información del sector escrita por el usuario
        private void buttonAñadir_Click(object sender, EventArgs e)
        {
            string nombre = Nombre.Text;
            if (nombre == "")
                MessageBox.Show("Error en los datos de entrada");
            else
            {
                try
                {
                    double OX = Convert.ToDouble(textBoxOX.Text);
                    double OY = Convert.ToDouble(textBoxOY.Text);
                    double DX = Convert.ToDouble(textBoxDX.Text);
                    double DY = Convert.ToDouble(textBoxDY.Text);
                    if (OX > 700)
                        OX = 700;
                    if (OY > 600)
                        OY = 600;
                    if (DX > 700)
                        DX = 700;
                    if (DY > 600)
                        DY = 600;

                    if (OX == DX)
                        MessageBox.Show("Este sector no se puede añadir, las coordenadas X son las mismas");
                    else if (OY == DY)
                        MessageBox.Show("Este sector no se puede añadir, las coordenadas Y son las mismas");
                    else
                    {
                        if (OX > DX)
                        {
                            double ox2 = OX;
                            OX = DX;
                            DX = ox2;
                        }

                        if (OY > DY)
                        {
                            double oy2 = OY;
                            OY = DY;
                            DY = oy2;
                        }

                        s = new Sectors(new Coordenades(OX, OY), new Coordenades(DX, DY), nombre);
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
