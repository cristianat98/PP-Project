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
    public partial class MisDatos : Form
    {
        public MisDatos()
        {
            InitializeComponent();
        }

        //Método que permite mostrar en el Formulario los datos de las Aerolíneas
        public void escribiraerolineas()
        {
            DataTable data = new DataTable();
            DBGestion gestion = new DBGestion();
            gestion.OpenDB();
            data = gestion.GetAll();

            dataGV.DataSource = data;
            gestion.CloseDB(); 
        }

        //Botón que permite cerrar el Formulario
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        //Botón que abre otro Formulario para añadir una aerolínea
        private void button2_Click(object sender, EventArgs e)
        {
            AñadirAerolinea AA = new AñadirAerolinea();
            AA.ShowDialog();
            Close();
        }

        //Botón que abre otro formulario para borrar una aerolínea
        private void button3_Click(object sender, EventArgs e)
        {
            SeleccionarAerolinea SA = new SeleccionarAerolinea();
            SA.Text = "Eliminar Aerolínea";
            SA.Eliminar();
            SA.ShowDialog();
            Close();
        }

        //Botón que abre otro formulario para modificar una aerolínea
        private void button4_Click(object sender, EventArgs e)
        {
            SeleccionarAerolinea SA = new SeleccionarAerolinea();
            SA.Modificar();
            SA.ShowDialog();
            Close();

            Close();
        }
    }
}
