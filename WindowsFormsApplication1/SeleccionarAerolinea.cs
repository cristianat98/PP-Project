using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Gestion;

namespace FormsProjecte
{
    public partial class SeleccionarAerolinea : Form
    {
        //Variables del Formulario Seleccionar Aerolínea
        bool eliminar = false;

        public SeleccionarAerolinea()
        {
            InitializeComponent();
        }

        private void EliminarAerolinea_Load(object sender, EventArgs e)
        {
            DBGestion db = new DBGestion();
            db.OpenDB();
            DataTable dt = db.GetAll();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                comboBox1.Items.Add(dt.Rows[i][0]);
            }
            db.CloseDB();
        }

        //Método que le hace saber al Formulario que se quiere eliminar la Aerolínea escogida
        public void Eliminar()
        {
            button1.Text = "Eliminar";
            eliminar = true;
        }

        //Método que la hace saber al Formulario que se quiere modificar la Aerolínea escogida
        public void Modificar()
        {
            button1.Text = "Modificar";
            eliminar = false;
        }

        //Botón que permite eliminar la aerolínea seleccionada
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
                MessageBox.Show("No se ha seleccionado ninguna aerolínea");

            else
            {
                if (eliminar)
                {
                    DBGestion db = new DBGestion();
                    db.OpenDB();
                    if (db.BorrarDB(Convert.ToString(comboBox1.SelectedItem)) == 0)
                        MessageBox.Show("Aerolínea eliminada");
                    eliminar = false;
                    db.CloseDB();
                }

                else
                {
                    Close();
                    ModificarAerolinea MA = new ModificarAerolinea();
                    MA.SetAerolinea(Convert.ToString(comboBox1.SelectedItem));
                    MA.ShowDialog();
                }
                    Close();
            }
        }
    }
}
