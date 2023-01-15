using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClasesProyecto;
using FormsProjecte;
using Gestion;

namespace FormsProjecte
{
    public partial class MostrarVuelos : Form
    {
        public MostrarVuelos()
        {
            InitializeComponent();
        }

        //Método que muestra en un DataGrid todos los aviones que hay en la lista
        public void listaaviones(LlistaAvions lista)
        {

            dataGV1.ColumnCount = 6;
            dataGV1.RowCount = lista.GetNum() + 1;
            int j = 0;

            dataGV1[0, 0].Value = "ID";
            dataGV1[1, 0].Value = "Compañia";
            dataGV1[2, 0].Value = "Actual";
            dataGV1[3, 0].Value = "Origen";
            dataGV1[4, 0].Value = "Destino";
            dataGV1[5, 0].Value = "Velocidad";

            while (j < lista.GetNum())
            {
                Avio av = new Avio();
                av = lista.ConsultarLista(j);
                dataGV1[0, j + 1].Value = av.GetID();
                dataGV1[1, j + 1].Value = av.GetCompañia();
                dataGV1[2, j + 1].Value = (" X : " + Convert.ToInt32(av.GetA().GetX()) + " ;  Y : " + Convert.ToInt32(av.GetA().GetY()));
                dataGV1[3, j + 1].Value = (" X : " + av.GetO().GetX() + " ;  Y : " + av.GetO().GetY());
                dataGV1[4, j + 1].Value = (" X : " + av.GetD().GetX() + " ;  Y : " + av.GetD().GetY());
                dataGV1[5, j + 1].Value = av.GetVelocidad();

                j++;
            }
        }

        //Botón que permite cerrar el Formulario
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        /*private void MostrarVuelos_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < milista.GetNum(); i++)
            {
                dataGV1.ColumnCount = 4;
                dataGV1.RowHeadersVisible = false;
                dataGV1.Columns[0].HeaderText = "ID";
                dataGV1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGV1.Columns[1].HeaderText = "Posición actual X";
                dataGV1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGV1.Columns[2].HeaderText = "Posición actual Y";
                dataGV1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGV1.Columns[3].HeaderText = "Velocidad del vuelo";
                dataGV1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                avio = milista.ConsultarLista(i);

                dataGV1.Rows.Add(avio.GetID(), string.Format("{0:00.00}", avio.GetA().GetX()), string.Format("{0:00.00}", avio.GetA().GetY()));
                dataGV1.Rows.Add(avio.GetID(), string.Format("{0:00.00}", avio.GetA().GetX()), string.Format("{0:00.00}", avio.GetA().GetY()));
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = e.RowIndex;

            dataGV1.Rows[fila].DefaultCellStyle.BackColor = Color.Gold;
            dataGV1.ClearSelection();
        }*/
    }
}
