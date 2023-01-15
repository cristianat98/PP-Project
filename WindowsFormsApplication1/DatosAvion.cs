using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClasesProyecto;
using System.Data.OleDb;
using Gestion;
namespace FormsProjecte
{
    public partial class DatosAvion : Form
    {
        //Variables del Formulario de los Datos del Avión
        Avio av;
        bool enc = false;
        bool enc2 = false;
        DBGestion db = new DBGestion();
        List<Ciudades> lc = new List<Ciudades>();

        public DatosAvion()
        {
            InitializeComponent();
        }
        
        //Método que permite mostrar en pantalla los datos del avión
        public void EscribirAvion(Avio a, List<Ciudades> listaciudades)
        {
            MisDatos dat = new MisDatos();
            this.lc = listaciudades;
            db.OpenDB();
            av = a;
            ID.Text = Convert.ToString("ID: " + av.GetID());
            Compañia.Text = Convert.ToString("Compañía; " + av.GetCompañia());
            PA.Text = Convert.ToString("Posición Actual X: " + Convert.ToInt32(av.GetA().GetX()) + " Y: " + Convert.ToInt32(av.GetA().GetY()));
            Email.Text = Convert.ToString("Email: " + db.GetEmail(av.GetCompañia()));
            Telefono.Text = Convert.ToString("Teléfono: " + db.GetTelefono(av.GetCompañia()));
            PO.Text = Convert.ToString("Origen: " + av.GetCOrigen() + " (X= " + Convert.ToInt32(av.GetO().GetX()) + " Y= " + Convert.ToInt32(av.GetO().GetY()) + " )");
            PD.Text = Convert.ToString("Destino: " + av.GetCDestino() + " (X= " + Convert.ToInt32(av.GetD().GetX()) + " Y= " + Convert.ToInt32(av.GetD().GetY()) + " )");
            Velocidad.Text = Convert.ToString("Velocidad: " + av.GetVelocidad());

        }

        //Método que permite saber si se quiere borrar el avión
        public bool borrar()
        {
            return enc;
        }

        //Método que permite saber si se quiere modificar el avión
        public bool modificar()
        {
            return enc2;
        }

        //Método que devuelve el avión actual
        public Avio devolveravion()
        {
            return this.av;
        }

        //Botón que cierra el Formulario
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        //Botón que permite la devolución del avión actual
        private void button2_Click(object sender, EventArgs e)
        {
            enc = true;
            Close();
        }

        //Botón que permite modificar el avión
        private void button3_Click(object sender, EventArgs e)
        {
            ModificarAvion MA = new ModificarAvion();
            MA.SetCiudades(lc, av);
            MA.ShowDialog();
            Avio a = MA.devolveravion();
            if (a != null)
            {
                av.SetID(a.GetID());
                av.SetCompañia(a.GetCompañia());
                av.SetVelocidad(a.GetVelocidad());
                av.SetCDestino(a.GetCDestino());
                av.SetD(a.GetD());
                enc2 = true;
            }
            Close();
        }
    }
}
