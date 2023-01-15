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
    public partial class DatosSector : Form
    {
        //Variables del Formulario Datos Sector
        Sectors sector;
        bool enc = false;
        bool enc2 = false;
        LlistaAvions lista = new LlistaAvions();

        public DatosSector()
        {
            InitializeComponent();
        }

        //Método que escribe los datos del sector en el formulario
        public void Escribirsector(Sectors sect, LlistaAvions lista)
        {
            this.lista = lista;
            this.sector = sect;
            sector = sect;
            int suma = 0;
            for (int i = 0; i < lista.GetNum(); i++)
            {
                Avio av = lista.ConsultarLista(i);
                suma = suma + sector.ComprobarSector(av.GetA().GetX(), av.GetA().GetY());
            }
            Nombre.Text = Convert.ToString("Nombre: " + sector.GetNombre());
            PO.Text = Convert.ToString("Posición Origen X: " + Convert.ToInt32(sector.GetNO().GetX()) + " Y: " + Convert.ToInt32(sector.GetNO().GetY()));
            PD.Text = Convert.ToString("Posición Destino X: " + Convert.ToInt32(sector.GetSE().GetX()) + " Y: " + Convert.ToInt32(sector.GetSE().GetY()));
            Congestion.Text = Convert.ToString("Congestion: " + suma + "/" + sector.GetCongestion());
        }

        //Método que permite saber si se quiere eliminar el sector
        public bool borrar()
        {
            return this.enc;
        }

        //Método que permite saber si se quiere modificar el sector
        public bool modificar()
        {
            return this.enc2;
        }

        //Método que devuelve el sector actual
        public Sectors devolversector()
        {
            return this.sector;
        }

        //Botón que cierra el formulario
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        //Botón que permite eliminar el sector
        private void button2_Click(object sender, EventArgs e)
        {
            enc = true;
            Close();
        }

        //Botón que permite modificar el sector
        private void button3_Click(object sender, EventArgs e)
        {
            ModificarSector MS = new ModificarSector();
            MS.SetSector(sector);
            MS.ShowDialog();
            sector = MS.devolversector();
            if (sector != null)
            {
                sector.SetNombre(sector.GetNombre());
                sector.SetNO(sector.GetNO());
                sector.SetSE(sector.GetSE());
                enc2 = true;
            }
            Close();
        }

        //Botón que muestra la lista de aviones que están dentro de este sector
        private void button4_Click(object sender, EventArgs e)
        {
            LlistaAvions lista2 = new LlistaAvions();
            for (int i = 0; i < lista.GetNum(); i++)
            {
                Avio av = lista.ConsultarLista(i);
                if (sector.ComprobarSector(av.GetA().GetX(), av.GetA().GetY()) == 1)
                    lista2.AñadirAvion(av);
            }

            if (lista2.GetNum() == 0)
                MessageBox.Show("No hay ningún avión en este sector");

            else
            {
                MostrarVuelos F4 = new MostrarVuelos();
                F4.listaaviones(lista2);
                F4.ShowDialog();
            }
        }
    }
}
