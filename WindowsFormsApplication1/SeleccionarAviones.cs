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
    public partial class SeleccionarAviones : Form
    {
        //Variables del Formulario Seleccionar Aviones
        LlistaAvions lista = new LlistaAvions();
        List<CheckBox> listcheck = new List<CheckBox>();
        CheckBox check;

        public SeleccionarAviones()
        {
            InitializeComponent();
        }

        //Método que añade al Formulario los aviones de la lista
        public void SetLista(LlistaAvions lista2)
        {
            this.lista = lista2;
            int a = 49;
            check = new CheckBox();
            check.AutoSize = true;
            check.Text = "Seleccionar Todo";
            check.Location = new Point(25, a);
            Controls.Add(check);
            listcheck.Add(check);
            a = a + 23;

            for (int i = 0; i < lista2.GetNum(); i++)
            {
                check = new CheckBox();
                check.Text = lista.ConsultarLista(i).GetID();
                check.Location = new Point(25, a);
                Controls.Add(check);
                a = a + 23;
                listcheck.Add(check);
            }
        }

        //Botón que cambia a true el Mover de los Aviones seleccionados
        private void button1_Click(object sender, EventArgs e)
        {
            if (listcheck[0].Checked)
            {
                MessageBox.Show("Todos los aviones se han seleccionado");
                for (int i = 0; i < lista.GetNum(); i++)
                {
                    lista.ConsultarLista(i).SetMover(true);
                }
            }

            else
            {
                for (int i = 0; i < lista.GetNum(); i++)
                {
                    if (listcheck[i + 1].Checked)
                        lista.ConsultarLista(i).SetMover(true);
                    else
                        lista.ConsultarLista(i).SetMover(false);
                }
            }
            Close();
        }
    }
}
