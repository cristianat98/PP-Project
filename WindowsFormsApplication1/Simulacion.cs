using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ClasesProyecto;

namespace FormsProjecte
{
    public partial class Simulacion : Form
    {
        //Variables del Formulario Principal
        LlistaAvions milista = new LlistaAvions();
        Sectors misector;
        ListaSectores sectores = new ListaSectores();
        Ciudades ciudad = new Ciudades();
        List<Ciudades> listaciudades = new List<Ciudades>();
        Avio av;
        PictureBox vuelo;
        List<PictureBox> listapicture = new List<PictureBox>();
        Bitmap img;
        Label lab;
        List<Label> listalabel = new List<Label>();
        Label sector;
        List<Label> listasector = new List<Label>();
        Deshacer deshacer = new Deshacer();
        Deshacer rehacer = new Deshacer();
        Boolean automatico = false;
        int ciclo;
        int ttotal;
        bool añadirciudad = false;
        bool tutorial = false;
        int fasetutorial = 0;

        public Simulacion()
        {
            InitializeComponent();
        }

        //Función que carga la lista de las ciudades al inicializar el Formulario
        private void Simulacion_Load(object sender, EventArgs e)
        {
            StreamReader F = new StreamReader("Ciudades.txt");
            string linea = F.ReadLine();
            while (linea != null)
            {
                ciudad = new Ciudades();
                string[] lin = linea.Split();
                ciudad.SetNombre(lin[0]);
                ciudad.SetCordenadas(Convert.ToInt32(lin[1]), Convert.ToInt32(lin[2]));
                listaciudades.Add(ciudad);
                linea = F.ReadLine();
            }
            F.Close();
        }

        //Botón que permite empezar o cancelar el tutorial
        private void button2_Click(object sender, EventArgs e)
        {
            if (tutorial)
            {
                button2.Text = "Empezar Tutorial";
                tutorial = false;
                fasetutorial = 0;
            }

            else
            {
                button2.Text = "Cancelar Tutorial";
                tutorial = true;
                MessageBox.Show("Para empezar a usar el programa, primero cargaremos una lista de aviones en Archivo/Cargar Aviones");
            }

        }

        //Botón que permite seleccionar los aviones que quieras que se muevan
        private void button5_Click(object sender, EventArgs e)
        {
            if (tutorial && fasetutorial == 0)
                MessageBox.Show("ERROR. Ahora toca cargar una lista de aviones en Archivo/Cargar Aviones");
            else if (tutorial && fasetutorial == 1)
                MessageBox.Show("ERROR. Ahora toca cargar una lista de sectores en Archivo/Cargar Sectores");
            else if (tutorial && fasetutorial == 2)
                MessageBox.Show("ERROR. Ahora toca introducir un tiempo de ciclo en Funciones/Introduce Tiempo Ciclo");
            else if (tutorial && fasetutorial == 3)
                MessageBox.Show("ERROR. Ahora toca mover los aviones dándole al botón Mover Vuelos");
            else if (tutorial && fasetutorial == 4)
                MessageBox.Show("ERROR. Ahora toca mover los aviones automáticamente en Simulación Automática");
            else if (tutorial && fasetutorial == 5)
                MessageBox.Show("ERROR. Ahora toca añadir un avión en Funciones/Añadir Vuelo");
            else if (tutorial && fasetutorial == 6)
                MessageBox.Show("ERROR. Ahora toca añadir un sector en Funciones/Añadir Sector");
            else if (tutorial && fasetutorial == 7)
                MessageBox.Show("ERROR. Ahora deshacer un movimiento de los aviones en Deshacer Aviones");
            else if (tutorial && fasetutorial == 8)
                MessageBox.Show("ERROR. Ahora toca deshacer un movimiento de los sectores en Deshacer Sectores");
            else if (tutorial && fasetutorial == 9)
                MessageBox.Show("ERROR. Ahora toca rehacer un movimiento de los aviones en Rehacer Aviones");
            else if (tutorial && fasetutorial == 10)
                MessageBox.Show("ERROR. Ahora toca rehacer un movimiento de los sectores en Rehacer Sectores");
            else if (tutorial && fasetutorial == 11)
                MessageBox.Show("ERROR. Ahora toca reiniciar la simulación de los aviones en Reiniciar Simulación");
            else if (tutorial && fasetutorial == 13)
                MessageBox.Show("ERROR. Ahora toca mover los aviones que has seleccionado en Mover Vuelos");
            else if (tutorial && fasetutorial == 14)
                MessageBox.Show("ERROR. Ahora toca ver la lista de aviones que hay en Funciones/Mostrar Lista de Vuelos");
            else if (tutorial && fasetutorial == 15)
                MessageBox.Show("ERROR. Ahora toca ver la lista de aerolíneas que hay en Mostrar Lista Aerolíneas");
            else if (tutorial && fasetutorial == 16)
                MessageBox.Show("ERROR. Ahora toca añadir una ciudad en Funciones/Añadir Ciudad");
            else if (tutorial && fasetutorial == 17)
                MessageBox.Show("ERROR. Ahora toca ver cuantos aviones tienen una velocidad mayor a una determinada en Comprobar Velocidad");
            else if (tutorial && fasetutorial == 18)
                MessageBox.Show("ERROR. Ahora toca borrar o eliminar un avión seleccionándolo en el mapa");
            else if (tutorial && fasetutorial == 19)
                MessageBox.Show("ERROR. Ahora toca borrar o eliminar un sector seleccionándolo en el mapa");
            else if (tutorial && fasetutorial == 20)
                MessageBox.Show("ERROR. Ahora toca guardar los aviones en Archivo/Guardar Aviones");
            else if (tutorial && fasetutorial == 21)
                MessageBox.Show("ERROR. Ahora toca guardar los sectores en Archivo/Guardar Sectores");

            else
            {
                if (milista.GetNum() == 0)
                    MessageBox.Show("No hay ninguna lista cargada");
                else
                {
                    SeleccionarAviones SA = new SeleccionarAviones();
                    SA.SetLista(milista);
                    SA.ShowDialog();
                    if (tutorial && fasetutorial == 12)
                    {
                        MessageBox.Show("Ahora solo los aviones que hayas seleccionado se moverán por el mapa cuando le des a Mover Vuelos o Simulación Automática");
                        MessageBox.Show("Dale a Mover Vuelos para comprobar que solo se mueven los aviones que has seleccionado");
                        fasetutorial = 13;
                    }
                }
            }
        }

        //Botón que permite al usuario cargar una lista de aviones.txt que a su vez de los mostrará en el mapa
        private void cargarBoton_Click(object sender, EventArgs e)
        {
            if (tutorial && fasetutorial == 1)
                MessageBox.Show("ERROR. Ahora toca cargar una lista de sectores en Archivo/Cargar Sectores");
            else if (tutorial && fasetutorial == 2)
                MessageBox.Show("ERROR. Ahora toca introducir un tiempo de ciclo en Funciones/Introduce Tiempo Ciclo");
            else if (tutorial && fasetutorial == 3)
                MessageBox.Show("ERROR. Ahora toca mover los aviones dándole al botón Mover Vuelos");
            else if (tutorial && fasetutorial == 4)
                MessageBox.Show("ERROR. Ahora toca mover los aviones automáticamente en Simulación Automática");
            else if (tutorial && fasetutorial == 5)
                MessageBox.Show("ERROR. Ahora toca añadir un avión en Funciones/Añadir Vuelo");
            else if (tutorial && fasetutorial == 6)
                MessageBox.Show("ERROR. Ahora toca añadir un sector en Funciones/Añadir Sector");
            else if (tutorial && fasetutorial == 7)
                MessageBox.Show("ERROR. Ahora deshacer un movimiento de los aviones en Deshacer Aviones");
            else if (tutorial && fasetutorial == 8)
                MessageBox.Show("ERROR. Ahora toca deshacer un movimiento de los sectores en Deshacer Sectores");
            else if (tutorial && fasetutorial == 9)
                MessageBox.Show("ERROR. Ahora toca rehacer un movimiento de los aviones en Rehacer Aviones");
            else if (tutorial && fasetutorial == 10)
                MessageBox.Show("ERROR. Ahora toca rehacer un movimiento de los sectores en Rehacer Sectores");
            else if (tutorial && fasetutorial == 11)
                MessageBox.Show("ERROR. Ahora toca reiniciar la simulación de los aviones en Reiniciar Simulación");
            else if (tutorial && fasetutorial == 12)
                MessageBox.Show("ERROR. Ahora toca seleccionar los aviones que quieres mover en Seleccionar Aviones");
            else if (tutorial && fasetutorial == 13)
                MessageBox.Show("ERROR. Ahora toca mover los aviones que has seleccionado en Mover Vuelos");
            else if (tutorial && fasetutorial == 14)
                MessageBox.Show("ERROR. Ahora toca ver la lista de aviones que hay en Funciones/Mostrar Lista de Vuelos");
            else if (tutorial && fasetutorial == 15)
                MessageBox.Show("ERROR. Ahora toca ver la lista de aerolíneas que hay en Mostrar Lista Aerolíneas");
            else if (tutorial && fasetutorial == 16)
                MessageBox.Show("ERROR. Ahora toca añadir una ciudad en Funciones/Añadir Ciudad");
            else if (tutorial && fasetutorial == 17)
                MessageBox.Show("ERROR. Ahora toca ver cuantos aviones tienen una velocidad mayor a una determinada en Comprobar Velocidad");
            else if (tutorial && fasetutorial == 18)
                MessageBox.Show("ERROR. Ahora toca borrar o eliminar un avión seleccionándolo en el mapa");
            else if (tutorial && fasetutorial == 19)
                MessageBox.Show("ERROR. Ahora toca borrar o eliminar un sector seleccionándolo en el mapa");
            else if (tutorial && fasetutorial == 20)
                MessageBox.Show("ERROR. Ahora toca guardar los aviones en Archivo/Guardar Aviones");
            else if (tutorial && fasetutorial == 21)
                MessageBox.Show("ERROR. Ahora toca guardar los sectores en Archivo/Guardar Sectores");

            else
            {
                MessageBox.Show("Recuerda que la lista que tengas cargada anteriormente se borrará");
                openFileDialog1.Filter = "txt files (*.txt)|*.txt";
                openFileDialog1.FilterIndex = 1;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string fname = openFileDialog1.FileName;
                    int m;
                    bool enc = false;
                    deshacer.GuardarCopia(milista.copia());

                    if (milista.GetNum() != 0)
                    {
                        milista.Borrarlista();
                        enc = true;
                    }

                    m = milista.CargarLista(fname, listaciudades);

                    if (m == 0)
                    {
                        if (milista.GetNum() == 0)
                        {
                            MessageBox.Show("No había aviones en el fichero");
                            if (deshacer.Copias() != 0)
                            {
                                milista = deshacer.RecuperarCopia();
                                DibujarVuelo(0);
                                Dibujarsector(0);
                            }
                        }

                        else
                        {
                            MessageBox.Show("Lista cargada correctamente.");
                            DibujarVuelo(0);
                            Dibujarsector(0);
                            if (tutorial && fasetutorial == 0)
                            {
                                fasetutorial = 1;
                                MessageBox.Show("Ya tenemos la lista cargada. Como verás los aviones aparecen en el mapa con su origen de color verde y su destino de color rojo y una línea que une el avión y el destino.");
                                MessageBox.Show("Ahora cargaremos una lista de sectores en Archivo/Cargar Sectores");
                            }
                        }
                    }

                    else if (m == -1)
                    {
                        if (enc)
                            milista = deshacer.RecuperarCopia();

                        Error Error = new Error();
                        Error.escribirerror(-1);
                        Error.ShowDialog();
                    }

                    else if (m == -2)
                    {
                        if (enc)
                            milista = deshacer.RecuperarCopia();

                        Error Error = new Error();
                        Error.escribirerror(-2);
                        Error.ShowDialog();
                    }
                }
            }
        }

        //Botón que permite cargar la lista de sectores y los dibujará en el mapa, por lo que le permitirá controlar los vuelos por distintos sectores
        private void cargarSectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tutorial && fasetutorial == 0)
                MessageBox.Show("ERROR. Ahora toca cargar una lista de aviones en Archivo/Cargar Aviones");
            else if (tutorial && fasetutorial == 2)
                MessageBox.Show("ERROR. Ahora toca introducir un tiempo de ciclo en Funciones/Introduce Tiempo Ciclo");
            else if (tutorial && fasetutorial == 3)
                MessageBox.Show("ERROR. Ahora toca mover los aviones dándole al botón Mover Vuelos");
            else if (tutorial && fasetutorial == 4)
                MessageBox.Show("ERROR. Ahora toca mover los aviones automáticamente en Simulación Automática");
            else if (tutorial && fasetutorial == 5)
                MessageBox.Show("ERROR. Ahora toca añadir un avión en Funciones/Añadir Vuelo");
            else if (tutorial && fasetutorial == 6)
                MessageBox.Show("ERROR. Ahora toca añadir un sector en Funciones/Añadir Sector");
            else if (tutorial && fasetutorial == 7)
                MessageBox.Show("ERROR. Ahora deshacer un movimiento de los aviones en Deshacer Aviones");
            else if (tutorial && fasetutorial == 8)
                MessageBox.Show("ERROR. Ahora toca deshacer un movimiento de los sectores en Deshacer Sectores");
            else if (tutorial && fasetutorial == 9)
                MessageBox.Show("ERROR. Ahora toca rehacer un movimiento de los aviones en Rehacer Aviones");
            else if (tutorial && fasetutorial == 10)
                MessageBox.Show("ERROR. Ahora toca rehacer un movimiento de los sectores en Rehacer Sectores");
            else if (tutorial && fasetutorial == 11)
                MessageBox.Show("ERROR. Ahora toca reiniciar la simulación de los aviones en Reiniciar Simulación");
            else if (tutorial && fasetutorial == 12)
                MessageBox.Show("ERROR. Ahora toca seleccionar los aviones que quieres mover en Seleccionar Aviones");
            else if (tutorial && fasetutorial == 13)
                MessageBox.Show("ERROR. Ahora toca mover los aviones que has seleccionado en Mover Vuelos");
            else if (tutorial && fasetutorial == 14)
                MessageBox.Show("ERROR. Ahora toca ver la lista de aviones que hay en Funciones/Mostrar Lista de Vuelos");
            else if (tutorial && fasetutorial == 15)
                MessageBox.Show("ERROR. Ahora toca ver la lista de aerolíneas que hay en Mostrar Lista Aerolíneas");
            else if (tutorial && fasetutorial == 16)
                MessageBox.Show("ERROR. Ahora toca añadir una ciudad en Funciones/Añadir Ciudad");
            else if (tutorial && fasetutorial == 17)
                MessageBox.Show("ERROR. Ahora toca ver cuantos aviones tienen una velocidad mayor a una determinada en Comprobar Velocidad");
            else if (tutorial && fasetutorial == 18)
                MessageBox.Show("ERROR. Ahora toca borrar o eliminar un avión seleccionándolo en el mapa");
            else if (tutorial && fasetutorial == 19)
                MessageBox.Show("ERROR. Ahora toca borrar o eliminar un sector seleccionándolo en el mapa");
            else if (tutorial && fasetutorial == 20)
                MessageBox.Show("ERROR. Ahora toca guardar los aviones en Archivo/Guardar Aviones");
            else if (tutorial && fasetutorial == 21)
                MessageBox.Show("ERROR. Ahora toca guardar los sectores en Archivo/Guardar Sectores");

            else
            {
                MessageBox.Show("Recuerda que la lista que tengas cargada anteriormente se borrará");
                openFileDialog1.Title = "Busca Lista Sectores"; //Nom de la pestanya
                openFileDialog1.Filter = "txt files (*.txt)|*.txt";
                openFileDialog1.FilterIndex = 1;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string fname = openFileDialog1.FileName;
                    int m;
                    bool enc = false;
                    deshacer.GuardarCopiaSec(sectores.copia());

                    if (sectores.GetNum() != 0)
                    {
                        sectores.Borrarlista();
                        enc = true;
                    }

                    m = sectores.cargarsector(fname);

                    if (m == 0)
                    {
                        if (sectores.GetNum() == 0)
                        {
                            MessageBox.Show("No había ningún sector en el fichero");
                            if (deshacer.CopiasSec() != 0)
                            {
                                sectores = deshacer.RecuperarCopiaSec();
                                DibujarVuelo(0);
                                Dibujarsector(0);
                            }
                        }

                        else
                        {
                            MessageBox.Show("Lista cargada correctamente.");
                            DibujarVuelo(0);
                            Dibujarsector(0);
                            if (tutorial && fasetutorial == 1)
                            {
                                MessageBox.Show("Como puedes comprobar los sectores también salen dibujados en el mapa con un recuadro y su nombre al lado. Si no está muy congestionado el recuadro estará de color verde, si está bastante congestionado saldrá de color amarillo y si está a tope estará de color rojo.");
                                MessageBox.Show("Ahora probaremos a mover un avión. Primero hay que introducir un tiempo de ciclo en Funciones/Introduce Tiempo Ciclo");
                                fasetutorial = 2;
                            }
                        }
                    }

                    else if (m == -1)
                    {
                        if (enc)
                            sectores = deshacer.RecuperarCopiaSec();

                        Error Error = new Error();
                        Error.escribirerror(-1);
                        Error.ShowDialog();
                    }

                    else if (m == -2)
                    {
                        if (enc)
                            sectores = deshacer.RecuperarCopiaSec();

                        Error Error = new Error();
                        Error.escribirerror(-3);
                        Error.ShowDialog();
                    }
                }
            }
        }

        //Función que permite visualizar los datos de cada vuelo al darle click a la foto del avión
        private void evento(object sender, EventArgs e)
        {
            PictureBox vuelo = (PictureBox)sender;
            int tag = (int)vuelo.Tag;
            DatosAvion F2 = new DatosAvion();
            F2.EscribirAvion(milista.ConsultarLista(tag).Copia(), listaciudades);
            F2.ShowDialog();
            Avio a = F2.devolveravion();

            if (F2.borrar())
            {
                deshacer.GuardarCopia(milista.copia());
                MessageBox.Show("Avión eliminado del espacio aéreo.");
                milista.eliminar(tag);
                listapicture.RemoveAt(tag);
                listalabel.RemoveAt(tag);
                if (tutorial && fasetutorial == 18)
                {
                    MessageBox.Show("Hemos eliminado el avión seleccionado y ya no aparece en el mapa. También has podido comprobar que al hacer click sobre el avión salen todos sus datos");
                    MessageBox.Show("Ahora probaremos a hacer los mismo con los sectores. Para ello toca el sector que quieras modificar o eliminar. Basta con tocar dentro del recuadro o el nombre del sector");
                    fasetutorial = 19;
                }
                DibujarVuelo(0);
                Dibujarsector(0);
            }

            else if (F2.modificar())
            {
                deshacer.GuardarCopia(milista.copia());
                MessageBox.Show("Avión modificado");
                av = milista.ConsultarLista(tag);
                av.SetID(a.GetID());
                av.SetCompañia(a.GetCompañia());
                av.SetVelocidad(a.GetVelocidad());
                av.SetD(a.GetD());
                av.SetCDestino(a.GetCDestino());
                listalabel[tag].Text = av.GetID();
                DibujarVuelo(0);
                Dibujarsector(0);
                if (tutorial && fasetutorial == 18)
                {
                    MessageBox.Show("Hemos modificado el avión seleccionado y ahora tiene otros datos. También has podido comprobar que al hacer click sobre el avión salen todos sus datos");
                    MessageBox.Show("Ahora probaremos a hacer los mismo con los sectores. Para ello toca el sector que quieras modificar o eliminar. Basta con tocar dentro del recuadro o el nombre del sector");
                    fasetutorial = 19;
                }
            }
        }

        //Función que permite visualizar los datos de cada vuelo al darle click a la ID de cada avión
        private void evento2(object sender, EventArgs e)
        {
            Label lab = (Label)sender;
            int tag = (int)lab.Tag;
            DatosAvion F2 = new DatosAvion();
            F2.EscribirAvion(milista.ConsultarLista(tag).Copia(), listaciudades);
            F2.ShowDialog();
            Avio a = F2.devolveravion();

            if (F2.borrar())
            {
                deshacer.GuardarCopia(milista.copia());
                MessageBox.Show("Avión eliminado del espacio aéreo.");
                milista.eliminar(tag);
                listapicture.RemoveAt(tag);
                listalabel.RemoveAt(tag);
                if (tutorial && fasetutorial == 18)
                {
                    MessageBox.Show("Hemos eliminado el avión seleccionado y ya no aparece en el mapa. También has podido comprobar que al hacer click sobre el avión salen todos sus datos");
                    MessageBox.Show("Ahora probaremos a hacer los mismo con los sectores. Para ello toca el sector que quieras modificar o eliminar. Basta con tocar dentro del recuadro o el nombre del sector");
                    fasetutorial = 19;
                }
                DibujarVuelo(0);
                Dibujarsector(0);
            }

            else if (F2.modificar())
            {
                deshacer.GuardarCopia(milista.copia());
                av = milista.ConsultarLista(tag);
                MessageBox.Show("Avión modificado");
                av.SetID(a.GetID());
                av.SetCompañia(a.GetCompañia());
                av.SetVelocidad(a.GetVelocidad());
                av.SetD(a.GetD());
                av.SetCDestino(a.GetCDestino());
                listalabel[tag].Text = av.GetID();
                if (tutorial && fasetutorial == 18)
                {
                    MessageBox.Show("Hemos modificado el avión seleccionado y ahora tiene otros datos. También has podido comprobar que al hacer click sobre el avión salen todos sus datos");
                    MessageBox.Show("Ahora probaremos a hacer los mismo con los sectores. Para ello toca el sector que quieras modificar o eliminar. Basta con tocar dentro del recuadro o el nombre del sector");
                    fasetutorial = 19;
                }
                DibujarVuelo(0);
                Dibujarsector(0);
            }
        }

        //Función que permite visualizar los datos de cada secor al darle click al nombre de cada sector
        private void evento3(object sender, EventArgs e)
        {
            DatosSector F2 = new DatosSector();
            sector = (Label)sender;
            int tag = (int)sector.Tag;
            F2.Escribirsector(sectores.ConsultarLista(tag).copia(), milista);
            F2.ShowDialog();
            Sectors s = F2.devolversector();

            if (F2.borrar())
            {
                deshacer.GuardarCopiaSec(sectores.copia());
                MessageBox.Show("Sector eliminado del espacio aéreo.");
                sectores.eliminar(tag);
                listasector.RemoveAt(tag);
                DibujarVuelo(0);
                Dibujarsector(0);
                if (tutorial && fasetutorial == 19)
                {
                    MessageBox.Show("Hemos eliminado el sector seleccionado y ya no aparece en el mapa. También has podido comprobar que al hacer click sobre el sector salen todos sus datos");
                    MessageBox.Show("Para finalizar este tutorial aprenderemos a guardar los aviones y sectores. Primero guardaremos los aviones en Archivo/Guardar Aviones");
                    fasetutorial = 20;
                }
            }

            else if (F2.modificar())
            {
                deshacer.GuardarCopiaSec(sectores.copia());
                MessageBox.Show("Sector modificado");
                misector = sectores.ConsultarLista(tag);
                misector.SetNombre(s.GetNombre());
                misector.SetNO(s.GetNO());
                misector.SetSE(s.GetSE());
                listasector[tag].Text = misector.GetNombre();
                DibujarVuelo(0);
                Dibujarsector(0);
                if (tutorial && fasetutorial == 19)
                {
                    MessageBox.Show("Hemos modificado el sector seleccionado y ahora tiene otros datos. También has podido comprobar que al hacer click sobre el sector salen todos sus datos");
                    MessageBox.Show("Para finalizar este tutorial aprenderemos a guardar los aviones y sectores. Primero guardaremos los aviones en Archiv/Guardar Aviones");
                    fasetutorial = 20;
                }
            }
                
        }

        //Botón que permite guardar la lista de aviones en un fichero .txt
        private void guardarAvion_Click_1(object sender, EventArgs e)
        {
            if (tutorial && fasetutorial == 0)
                MessageBox.Show("ERROR. Ahora toca cargar una lista de aviones en Archivo/Cargar Aviones");
            else if (tutorial && fasetutorial == 1)
                MessageBox.Show("ERROR. Ahora toca cargar una lista de sectores en Archivo/Cargar Sectores");
            else if (tutorial && fasetutorial == 2)
                MessageBox.Show("ERROR. Ahora toca introducir un tiempo de ciclo en Funciones/Introduce Tiempo Ciclo");
            else if (tutorial && fasetutorial == 3)
                MessageBox.Show("ERROR. Ahora toca mover los aviones dándole al botón Mover Vuelos");
            else if (tutorial && fasetutorial == 4)
                MessageBox.Show("ERROR. Ahora toca mover los aviones automáticamente en Simulación Automática");
            else if (tutorial && fasetutorial == 5)
                MessageBox.Show("ERROR. Ahora toca añadir un avión en Funciones/Añadir Vuelo");
            else if (tutorial && fasetutorial == 6)
                MessageBox.Show("ERROR. Ahora toca añadir un sector en Funciones/Añadir Sector");
            else if (tutorial && fasetutorial == 7)
                MessageBox.Show("ERROR. Ahora deshacer un movimiento de los aviones en Deshacer Aviones");
            else if (tutorial && fasetutorial == 8)
                MessageBox.Show("ERROR. Ahora toca deshacer un movimiento de los sectores en Deshacer Sectores");
            else if (tutorial && fasetutorial == 9)
                MessageBox.Show("ERROR. Ahora toca rehacer un movimiento de los aviones en Rehacer Aviones");
            else if (tutorial && fasetutorial == 10)
                MessageBox.Show("ERROR. Ahora toca rehacer un movimiento de los sectores en Rehacer Sectores");
            else if (tutorial && fasetutorial == 11)
                MessageBox.Show("ERROR. Ahora toca reiniciar la simulación de los aviones en Reiniciar Simulación");
            else if (tutorial && fasetutorial == 12)
                MessageBox.Show("ERROR. Ahora toca seleccionar los aviones que quieres mover en Seleccionar Aviones");
            else if (tutorial && fasetutorial == 13)
                MessageBox.Show("ERROR. Ahora toca mover los aviones que has seleccionado en Mover Vuelos");
            else if (tutorial && fasetutorial == 14)
                MessageBox.Show("ERROR. Ahora toca ver la lista de aviones que hay en Funciones/Mostrar Lista de Vuelos");
            else if (tutorial && fasetutorial == 15)
                MessageBox.Show("ERROR. Ahora toca ver la lista de aerolíneas que hay en Mostrar Lista Aerolíneas");
            else if (tutorial && fasetutorial == 16)
                MessageBox.Show("ERROR. Ahora toca añadir una ciudad en Funciones/Añadir Ciudad");
            else if (tutorial && fasetutorial == 17)
                MessageBox.Show("ERROR. Ahora toca ver cuantos aviones tienen una velocidad mayor a una determinada en Comprobar Velocidad");
            else if (tutorial && fasetutorial == 18)
                MessageBox.Show("ERROR. Ahora toca borrar o eliminar un avión seleccionándolo en el mapa");
            else if (tutorial && fasetutorial == 19)
                MessageBox.Show("ERROR. Ahora toca borrar o eliminar un sector seleccionándolo en el mapa");
            else if (tutorial && fasetutorial == 21)
                MessageBox.Show("ERROR. Ahora toca guardar los sectores en Archivo/Guardar Sectores");
            
            else
            {
                if (milista.GetNum() == 0)
                {
                    MessageBox.Show("No hay aviones en el espacio aéreo. Cárgalos en Archivo/Cargar Aviones");
                }

                else
                {
                    saveFileDialog1.Title = "Busca Lista Aviones"; //Nom de la pestanya
                    saveFileDialog1.Filter = "txt files (*.txt)|*.txt";
                    saveFileDialog1.FilterIndex = 1;

                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        string fname = saveFileDialog1.FileName;
                        milista.GuardarLista(fname);
                        MessageBox.Show("Lista guardada correctamente");
                        if (tutorial && fasetutorial == 20)
                        {
                            MessageBox.Show("Ya hemos guardado los aviones en un fichero .txt");
                            MessageBox.Show("Ahora guardaremos los sectores en Archivo/Guardar Sectores");
                            fasetutorial = 21;
                        }
                    }
                }
            }
        }

        //Botón que permite guardar la lista de sectores en un fichero .txt
        private void guardarSectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tutorial && fasetutorial == 0)
                MessageBox.Show("ERROR. Ahora toca cargar una lista de aviones en Archivo/Cargar Aviones");
            else if (tutorial && fasetutorial == 1)
                MessageBox.Show("ERROR. Ahora toca cargar una lista de sectores en Archivo/Cargar Sectores");
            else if (tutorial && fasetutorial == 2)
                MessageBox.Show("ERROR. Ahora toca introducir un tiempo de ciclo en Funciones/Introduce Tiempo Ciclo");
            else if (tutorial && fasetutorial == 3)
                MessageBox.Show("ERROR. Ahora toca mover los aviones dándole al botón Mover Vuelos");
            else if (tutorial && fasetutorial == 4)
                MessageBox.Show("ERROR. Ahora toca mover los aviones automáticamente en Simulación Automática");
            else if (tutorial && fasetutorial == 5)
                MessageBox.Show("ERROR. Ahora toca añadir un avión en Funciones/Añadir Vuelo");
            else if (tutorial && fasetutorial == 6)
                MessageBox.Show("ERROR. Ahora toca añadir un sector en Funciones/Añadir Sector");
            else if (tutorial && fasetutorial == 7)
                MessageBox.Show("ERROR. Ahora deshacer un movimiento de los aviones en Deshacer Aviones");
            else if (tutorial && fasetutorial == 8)
                MessageBox.Show("ERROR. Ahora toca deshacer un movimiento de los sectores en Deshacer Sectores");
            else if (tutorial && fasetutorial == 9)
                MessageBox.Show("ERROR. Ahora toca rehacer un movimiento de los aviones en Rehacer Aviones");
            else if (tutorial && fasetutorial == 10)
                MessageBox.Show("ERROR. Ahora toca rehacer un movimiento de los sectores en Rehacer Sectores");
            else if (tutorial && fasetutorial == 11)
                MessageBox.Show("ERROR. Ahora toca reiniciar la simulación de los aviones en Reiniciar Simulación");
            else if (tutorial && fasetutorial == 12)
                MessageBox.Show("ERROR. Ahora toca seleccionar los aviones que quieres mover en Seleccionar Aviones");
            else if (tutorial && fasetutorial == 13)
                MessageBox.Show("ERROR. Ahora toca mover los aviones que has seleccionado en Mover Vuelos");
            else if (tutorial && fasetutorial == 14)
                MessageBox.Show("ERROR. Ahora toca ver la lista de aviones que hay en Funciones/Mostrar Lista de Vuelos");
            else if (tutorial && fasetutorial == 15)
                MessageBox.Show("ERROR. Ahora toca ver la lista de aerolíneas que hay en Mostrar Lista Aerolíneas");
            else if (tutorial && fasetutorial == 16)
                MessageBox.Show("ERROR. Ahora toca añadir una ciudad en Funciones/Añadir Ciudad");
            else if (tutorial && fasetutorial == 17)
                MessageBox.Show("ERROR. Ahora toca ver cuantos aviones tienen una velocidad mayor a una determinada en Comprobar Velocidad");
            else if (tutorial && fasetutorial == 18)
                MessageBox.Show("ERROR. Ahora toca borrar o eliminar un avión seleccionándolo en el mapa");
            else if (tutorial && fasetutorial == 19)
                MessageBox.Show("ERROR. Ahora toca borrar o eliminar un sector seleccionándolo en el mapa");
            else if (tutorial && fasetutorial == 18)
                MessageBox.Show("ERROR. Ahora toca borrar o eliminar un avión seleccionándolo en el mapa");
            else if (tutorial && fasetutorial == 19)
                MessageBox.Show("ERROR. Ahora toca borrar o eliminar un sector seleccionándolo en el mapa");
            else if (tutorial && fasetutorial == 20)
                MessageBox.Show("ERROR. Ahora toca guardar los aviones en Archivo/Guardar Aviones");

            else
            {
                if (sectores.GetNum() == 0)
                {
                    MessageBox.Show("No hay sectores en el espacio aéreo. Cárgalos en Archivo/Cargar Sectores");
                }

                else
                {
                    saveFileDialog1.Title = "Busca Lista Aviones"; //Nom de la pestanya
                    saveFileDialog1.Filter = "txt files (*.txt)|*.txt";
                    saveFileDialog1.FilterIndex = 1;

                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        string fname = saveFileDialog1.FileName;
                        sectores.GuardarLista(fname);
                        MessageBox.Show("Lista guardada correctamente");
                        if (tutorial && fasetutorial == 21)
                        {
                            MessageBox.Show("Ya hemos podido guardar los sectores en un fichero .txt");
                            MessageBox.Show("Aquí finaliza el tutorial. Si te ha quedado alguna duda y lo quieres volver a hacer le puedes dar a Empezar Tutorial de nuevo. Si tienes algún problema con el programa no dudes en ponerte en contacto con nosotros. Nuestros datos aparecen en Información/Autores");
                            fasetutorial = 0;
                            tutorial = false;
                            button2.Text = "Empezar Tutorial";
                        }
                    }
                }
            }
        }

        //Función que permite dibujar en el panel una línea ruta del vuelo que va de origen a destino
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics grafics;
            for (int i = 0; i < sectores.GetNum(); i++)
            {
                grafics = panel1.CreateGraphics();
                misector = sectores.ConsultarLista(i);
                Point po = new Point(Convert.ToInt32(misector.GetNO().GetX()), Convert.ToInt32(misector.GetNO().GetY()));
                Size si = new Size(Convert.ToInt32(misector.GetSE().GetX() - misector.GetNO().GetX()), Convert.ToInt32(misector.GetSE().GetY() - misector.GetNO().GetY()));
                Rectangle rec = new Rectangle(po, si);
                int suma = 0;
                for (int a = 0; a < milista.GetNum(); a++)
                {
                    suma = suma + misector.ComprobarSector(milista.ConsultarLista(a).GetA().GetX(), milista.ConsultarLista(a).GetA().GetY());
                    if (suma == misector.GetCongestion())
                    {
                        MessageBox.Show("El " + misector.GetNombre() + " está congestionado");
                        a = milista.GetNum();
                    }
                }

                if (suma < misector.GetCongestion() / 2)
                    grafics.DrawRectangle(Pens.Green, rec);

                else if (suma < misector.GetCongestion())
                    grafics.DrawRectangle(Pens.Yellow, rec);
                else
                    grafics.DrawRectangle(Pens.Red, rec);

                grafics.Dispose();
            }

            for (int i = 0; i < milista.GetNum(); i++)
            {
                grafics = panel1.CreateGraphics();
                av = milista.ConsultarLista(i);
                grafics.DrawLine(Pens.Black, Convert.ToInt32(av.GetA().GetX()), Convert.ToInt32(av.GetA().GetY()), Convert.ToInt32(av.GetD().GetX()), Convert.ToInt32(av.GetD().GetY()));
                grafics.Dispose();
            }
        }

        //Función que guarda la posición donde hacemos click en el panel
        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            if (añadirciudad == false)
            {
                if (tutorial && fasetutorial < 19)
                {
                }
                else
                {
                    for (int i = 0; i < sectores.GetNum(); i++)
                    {
                        misector = sectores.ConsultarLista(i);
                        if (misector.ComprobarSector(e.X, e.Y) == 1)
                        {
                            DatosSector F2 = new DatosSector();
                            F2.Escribirsector(misector.copia(), milista);
                            F2.ShowDialog();
                            misector = F2.devolversector();

                            if (F2.borrar())
                            {
                                deshacer.GuardarCopiaSec(sectores.copia());
                                MessageBox.Show("Sector eliminado del espacio aéreo.");
                                sectores.eliminar(i);
                                listasector.RemoveAt(i);
                                DibujarVuelo(0);
                                Dibujarsector(0);
                                if (tutorial && fasetutorial == 19)
                                {
                                    MessageBox.Show("Hemos eliminado el sector seleccionado y ya no aparece en el mapa. También has podido comprobar que al hacer click sobre el sector salen todos sus datos");
                                    MessageBox.Show("Para finalizar este tutorial aprenderemos a guardar los aviones y sectores. Primero guardaremos los aviones en Archiv/Guardar Aviones");
                                    fasetutorial = 20;
                                }
                            }

                            else if (F2.modificar())
                            {
                                deshacer.GuardarCopiaSec(sectores.copia());
                                MessageBox.Show("Sector modificado");
                                Sectors sec = sectores.ConsultarLista(i);
                                sec.SetNombre(misector.GetNombre());
                                sec.SetNO(misector.GetNO());
                                sec.SetSE(misector.GetSE());
                                listasector[i].Text = sec.GetNombre();
                                DibujarVuelo(0);
                                Dibujarsector(0);
                                if (tutorial && fasetutorial == 19)
                                {
                                    MessageBox.Show("Hemos modificado el sector seleccionado y ahora tiene otros datos. También has podido comprobar que al hacer click sobre el sector salen todos sus datos");
                                    MessageBox.Show("Para finalizar este tutorial aprenderemos a guardar los aviones y sectores. Primero guardaremos los aviones en Archivo/Guardar Aviones");
                                    fasetutorial = 20;
                                }
                            }
                        }
                    }
                }
            }

            else
            {
                int X = e.X;
                int Y = e.Y;
                bool enc = false;
                for (int i = 0; i < listaciudades.Count; i++)
                {
                    if (listaciudades[i].GetCoordenadas().GetX() == X && listaciudades[i].GetCoordenadas().GetY() == Y)
                    {
                        enc = true;
                        i = listaciudades.Count;
                    }
                }
                if (enc)
                    MessageBox.Show("Esta ciudad ya está en la aplicación");

                else
                {
                    ciudad = new Ciudades();
                    ciudad.SetCordenadas(e.X, e.Y);
                    AñadirCiudad AC = new AñadirCiudad();
                    AC.ShowDialog();
                    string nombre = AC.GetCiudad();
                    if (nombre != null)
                    {
                        MessageBox.Show("Ciudad añadida");
                        ciudad.SetNombre(nombre);
                        listaciudades.Add(ciudad);
                        listaciudades.Sort(delegate(Ciudades x, Ciudades y)
                        {
                            if (x.GetNombre() == null && y.GetNombre() == null)
                                return 0;
                            else if (x.GetNombre() == null)
                                return -1;
                            else if (y.GetNombre() == null)
                                return 1;
                            else
                                return x.GetNombre().CompareTo(y.GetNombre());
                        });
                        GuardarCiudad GC = new GuardarCiudad();
                        GC.ShowDialog();
                        if (GC.GetGuardar())
                        {
                            StreamWriter F = new StreamWriter("Ciudades.txt");
                            for (int i = 0; i < listaciudades.Count; i++)
                            {
                                string[] linea = listaciudades[i].GetNombre().Split();
                                int a = 0;
                                while (a < linea.Length - 1)
                                {
                                    linea[0] = linea[0] + linea[a + 1];
                                    a++;
                                }
                                F.WriteLine(linea[0] + " " + listaciudades[i].GetCoordenadas().GetX() + " " + listaciudades[i].GetCoordenadas().GetY());
                            }
                            F.Close();
                        }
                        if (tutorial && fasetutorial == 16)
                        {
                            MessageBox.Show("Ya hemos podido añadir la ciudad. Ahora la podrás elegir en los orígenes y destinos de los aviones cuando quieras añadir uno o modificarlo. También tienes la opción de guardar la ciudad para siempre, es decir que siempre que habrás la apliación ya te salga esa ciudad disponible");
                            MessageBox.Show("Ahora probaremos a comprobar cuantos aviones vuelan a una velocidad superior a la indicada. Para eso escribe una velocidad en el cuadro que hay al lado de Comprobar Velocidad y dale a ese botón.");
                            fasetutorial = 17;
                        }
                    }
                }
                añadirciudad = false;
            }
        }

        //Función que permite dibujar los label de los sectores en el mapa
        private void Dibujarsector(int a)
        {
            if (a == 0)
                listasector.Clear();

            for (int i = 0; i < sectores.GetNum(); i++)
            {
                misector = sectores.ConsultarLista(i);
                sector = new Label();
                sector.Text = misector.GetNombre();
                sector.Location = new Point(Convert.ToInt32(misector.GetSE().GetX() + 2), Convert.ToInt32(misector.GetNO().GetY()));
                sector.AutoSize = true;
                sector.Tag = i;
                listasector.Add(sector);
                panel1.Controls.Add(sector);
                if (tutorial && fasetutorial < 19)
                {
                }
                else
                    sector.Click += new System.EventHandler(this.evento3);
            }
            panel1.Invalidate();
        }

        //Función que permite dibujar los vuelos en el mapa indicando el origen y el destino
        private void DibujarVuelo(int a)
        {
            if (a == 0)
            {
                listapicture.Clear();
                listalabel.Clear();
                panel1.Controls.Clear();
            }

            for (int i = a; i < milista.GetNum(); i++)
            {
                av = milista.ConsultarLista(i);
                vuelo = new PictureBox();
                vuelo.Size = new Size(10, 10);
                vuelo.Location = new Point(Convert.ToInt32(av.GetA().GetX()), Convert.ToInt32(av.GetA().GetY()));
                vuelo.SizeMode = PictureBoxSizeMode.StretchImage;
                vuelo.Tag = i;
                img = new Bitmap("avion.ico");
                vuelo.Image = (Image)img;
                listapicture.Add(vuelo);

                lab = new Label();
                lab.Text = av.GetID();
                lab.Location = new Point(Convert.ToInt32(av.GetA().GetX() + 10), Convert.ToInt32(av.GetA().GetY()));
                lab.AutoSize = true;
                lab.Tag = i;
                listalabel.Add(lab);

                PictureBox origen = new PictureBox();
                origen.Size = new Size(10, 10);
                origen.BackColor = Color.Green;
                origen.Location = new Point(Convert.ToInt32(av.GetO().GetX()), Convert.ToInt32(av.GetO().GetY()));
                origen.SizeMode = PictureBoxSizeMode.StretchImage;

                PictureBox destino = new PictureBox();
                destino.Size = new Size(10, 10);
                destino.BackColor = Color.Red;
                destino.Location = new Point(Convert.ToInt32(av.GetD().GetX()), Convert.ToInt32(av.GetD().GetY()));
                destino.SizeMode = PictureBoxSizeMode.StretchImage;

                panel1.Controls.Add(vuelo);
                panel1.Controls.Add(lab);
                panel1.Controls.Add(origen);
                panel1.Controls.Add(destino);
                if (tutorial && fasetutorial < 18)
                {
                }
                else
                {
                    vuelo.Click += new System.EventHandler(this.evento);
                    lab.Click += new System.EventHandler(this.evento2);
                }
            }
            panel1.Invalidate();
        }

        //Método que dibuja el movimiento de cada avión en el mapa
        private void Dibujarmov()
        {
            for (int i = 0; i < listapicture.Count; i++)
            {
                av = milista.ConsultarLista(i);
                listapicture[i].Location = new Point(Convert.ToInt32(av.GetA().GetX()), Convert.ToInt32(av.GetA().GetY()));
                listalabel[i].Text = av.GetID();
                listalabel[i].Location = new Point(Convert.ToInt32(av.GetA().GetX() + 10), Convert.ToInt32(av.GetA().GetY()));
            }
            panel1.Invalidate();
        }

        //Función que devuelve otro formulario con los datos de las compañías registradas en la Base de Datos
        private void listaAerolineasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tutorial && fasetutorial == 0)
                MessageBox.Show("ERROR. Ahora toca cargar una lista de aviones en Archivo/Cargar Aviones");
            else if (tutorial && fasetutorial == 1)
                MessageBox.Show("ERROR. Ahora toca cargar una lista de sectores en Archivo/Cargar Sectores");
            else if (tutorial && fasetutorial == 2)
                MessageBox.Show("ERROR. Ahora toca introducir un tiempo de ciclo en Funciones/Introduce Tiempo Ciclo");
            else if (tutorial && fasetutorial == 3)
                MessageBox.Show("ERROR. Ahora toca mover los aviones dándole al botón Mover Vuelos");
            else if (tutorial && fasetutorial == 4)
                MessageBox.Show("ERROR. Ahora toca mover los aviones automáticamente en Simulación Automática");
            else if (tutorial && fasetutorial == 5)
                MessageBox.Show("ERROR. Ahora toca añadir un avión en Funciones/Añadir Vuelo");
            else if (tutorial && fasetutorial == 6)
                MessageBox.Show("ERROR. Ahora toca añadir un sector en Funciones/Añadir Sector");
            else if (tutorial && fasetutorial == 7)
                MessageBox.Show("ERROR. Ahora deshacer un movimiento de los aviones en Deshacer Aviones");
            else if (tutorial && fasetutorial == 8)
                MessageBox.Show("ERROR. Ahora toca deshacer un movimiento de los sectores en Deshacer Sectores");
            else if (tutorial && fasetutorial == 9)
                MessageBox.Show("ERROR. Ahora toca rehacer un movimiento de los aviones en Rehacer Aviones");
            else if (tutorial && fasetutorial == 10)
                MessageBox.Show("ERROR. Ahora toca rehacer un movimiento de los sectores en Rehacer Sectores");
            else if (tutorial && fasetutorial == 11)
                MessageBox.Show("ERROR. Ahora toca reiniciar la simulación de los aviones en Reiniciar Simulación");
            else if (tutorial && fasetutorial == 12)
                MessageBox.Show("ERROR. Ahora toca seleccionar los aviones que quieres mover en Seleccionar Aviones");
            else if (tutorial && fasetutorial == 13)
                MessageBox.Show("ERROR. Ahora toca mover los aviones que has seleccionado en Mover Vuelos");
            else if (tutorial && fasetutorial == 14)
                MessageBox.Show("ERROR. Ahora toca ver la lista de aviones que hay en Funciones/Mostrar Lista de Vuelos");
            else if (tutorial && fasetutorial == 16)
                MessageBox.Show("ERROR. Ahora toca añadir una ciudad en Funciones/Añadir Ciudad");
            else if (tutorial && fasetutorial == 17)
                MessageBox.Show("ERROR. Ahora toca ver cuantos aviones tienen una velocidad mayor a una determinada en Comprobar Velocidad");
            else if (tutorial && fasetutorial == 18)
                MessageBox.Show("ERROR. Ahora toca borrar o eliminar un avión seleccionándolo en el mapa");
            else if (tutorial && fasetutorial == 19)
                MessageBox.Show("ERROR. Ahora toca borrar o eliminar un sector seleccionándolo en el mapa");
            else if (tutorial && fasetutorial == 20)
                MessageBox.Show("ERROR. Ahora toca guardar los aviones en Archivo/Guardar Aviones");
            else if (tutorial && fasetutorial == 21)
                MessageBox.Show("ERROR. Ahora toca guardar los sectores en Archivo/Guardar Sectores");

            else
            {
                MisDatos F3 = new MisDatos();
                F3.escribiraerolineas();
                F3.ShowDialog();

                if (tutorial && fasetutorial == 15)
                {
                    MessageBox.Show("Como puedes comprobar aparecen todas las aerolíneas que están registradas. Pero como has podido comprobar tu puedes añadir más aerolíneas, eliminarlas o modificarlas");
                    MessageBox.Show("Ahora aprenderemos a añadir una ciudad para poder elegirla después como origen o destino de los aviones. Para ellos hay que ir a Funciones/Añadir Ciudad");
                    fasetutorial = 16;
                }
            }
        }

        //Función que te lleva a un Formulario donde debes escribir el tiempo de ciclo
        private void introduceTiempoDeCicloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tutorial && fasetutorial == 0)
                MessageBox.Show("ERROR. Ahora toca cargar una lista de aviones en Archivo/Cargar Aviones");
            else if (tutorial && fasetutorial == 1)
                MessageBox.Show("ERROR. Ahora toca cargar una lista de sectores en Archivo/Cargar Sectores");
            else if (tutorial && fasetutorial == 3)
                MessageBox.Show("ERROR. Ahora toca mover los aviones dándole al botón Mover Vuelos");
            else if (tutorial && fasetutorial == 4)
                MessageBox.Show("ERROR. Ahora toca mover los aviones automáticamente en Simulación Automática");
            else if (tutorial && fasetutorial == 5)
                MessageBox.Show("ERROR. Ahora toca añadir un avión en Funciones/Añadir Vuelo");
            else if (tutorial && fasetutorial == 6)
                MessageBox.Show("ERROR. Ahora toca añadir un sector en Funciones/Añadir Sector");
            else if (tutorial && fasetutorial == 7)
                MessageBox.Show("ERROR. Ahora deshacer un movimiento de los aviones en Deshacer Aviones");
            else if (tutorial && fasetutorial == 8)
                MessageBox.Show("ERROR. Ahora toca deshacer un movimiento de los sectores en Deshacer Sectores");
            else if (tutorial && fasetutorial == 9)
                MessageBox.Show("ERROR. Ahora toca rehacer un movimiento de los aviones en Rehacer Aviones");
            else if (tutorial && fasetutorial == 10)
                MessageBox.Show("ERROR. Ahora toca rehacer un movimiento de los sectores en Rehacer Sectores");
            else if (tutorial && fasetutorial == 11)
                MessageBox.Show("ERROR. Ahora toca reiniciar la simulación de los aviones en Reiniciar Simulación");
            else if (tutorial && fasetutorial == 12)
                MessageBox.Show("ERROR. Ahora toca seleccionar los aviones que quieres mover en Seleccionar Aviones");
            else if (tutorial && fasetutorial == 13)
                MessageBox.Show("ERROR. Ahora toca mover los aviones que has seleccionado en Mover Vuelos");
            else if (tutorial && fasetutorial == 14)
                MessageBox.Show("ERROR. Ahora toca ver la lista de aviones que hay en Funciones/Mostrar Lista de Vuelos");
            else if (tutorial && fasetutorial == 15)
                MessageBox.Show("ERROR. Ahora toca ver la lista de aerolíneas que hay en Mostrar Lista Aerolíneas");
            else if (tutorial && fasetutorial == 16)
                MessageBox.Show("ERROR. Ahora toca añadir una ciudad en Funciones/Añadir Ciudad");
            else if (tutorial && fasetutorial == 17)
                MessageBox.Show("ERROR. Ahora toca ver cuantos aviones tienen una velocidad mayor a una determinada en Comprobar Velocidad");
            else if (tutorial && fasetutorial == 18)
                MessageBox.Show("ERROR. Ahora toca borrar o eliminar un avión seleccionándolo en el mapa");
            else if (tutorial && fasetutorial == 19)
                MessageBox.Show("ERROR. Ahora toca borrar o eliminar un sector seleccionándolo en el mapa");
            else if (tutorial && fasetutorial == 20)
                MessageBox.Show("ERROR. Ahora toca guardar los aviones en Archivo/Guardar Aviones");
            else if (tutorial && fasetutorial == 21)
                MessageBox.Show("ERROR. Ahora toca guardar los sectores en Archivo/Guardar Sectores");
            
            else
            {
                Ciclo form = new Ciclo();
                form.ShowDialog();
                ciclo = form.DameElTiempo();
                if (ciclo != 0 && tutorial)
                {
                    MessageBox.Show("Cada vez que le des a Mover Vuelos, el avión se moverá la distancia que se habría movido durante ese tiempo de ciclo");
                    MessageBox.Show("Ahora le daremos al botón Mover Vuelos para que los aviones se muevan");
                    fasetutorial = 3;
                }
            }
        }

        //Función que permite saber cuantos aviones vuelan a una velocidad superior a la indicada por el usuario
        private void AceptarBoton_Click(object sender, EventArgs e)
        {
            if (tutorial && fasetutorial == 0)
                MessageBox.Show("ERROR. Ahora toca cargar una lista de aviones en Archivo/Cargar Aviones");
            else if (tutorial && fasetutorial == 1)
                MessageBox.Show("ERROR. Ahora toca cargar una lista de sectores en Archivo/Cargar Sectores");
            else if (tutorial && fasetutorial == 2)
                MessageBox.Show("ERROR. Ahora toca introducir un tiempo de ciclo en Funciones/Introduce Tiempo Ciclo");
            else if (tutorial && fasetutorial == 3)
                MessageBox.Show("ERROR. Ahora toca mover los aviones dándole al botón Mover Vuelos");
            else if (tutorial && fasetutorial == 4)
                MessageBox.Show("ERROR. Ahora toca mover los aviones automáticamente en Simulación Automática");
            else if (tutorial && fasetutorial == 5)
                MessageBox.Show("ERROR. Ahora toca añadir un avión en Funciones/Añadir Vuelo");
            else if (tutorial && fasetutorial == 6)
                MessageBox.Show("ERROR. Ahora toca añadir un sector en Funciones/Añadir Sector");
            else if (tutorial && fasetutorial == 7)
                MessageBox.Show("ERROR. Ahora deshacer un movimiento de los aviones en Deshacer Aviones");
            else if (tutorial && fasetutorial == 8)
                MessageBox.Show("ERROR. Ahora toca deshacer un movimiento de los sectores en Deshacer Sectores");
            else if (tutorial && fasetutorial == 9)
                MessageBox.Show("ERROR. Ahora toca rehacer un movimiento de los aviones en Rehacer Aviones");
            else if (tutorial && fasetutorial == 10)
                MessageBox.Show("ERROR. Ahora toca rehacer un movimiento de los sectores en Rehacer Sectores");
            else if (tutorial && fasetutorial == 11)
                MessageBox.Show("ERROR. Ahora toca reiniciar la simulación de los aviones en Reiniciar Simulación");
            else if (tutorial && fasetutorial == 12)
                MessageBox.Show("ERROR. Ahora toca seleccionar los aviones que quieres mover en Seleccionar Aviones");
            else if (tutorial && fasetutorial == 13)
                MessageBox.Show("ERROR. Ahora toca mover los aviones que has seleccionado en Mover Vuelos");
            else if (tutorial && fasetutorial == 14)
                MessageBox.Show("ERROR. Ahora toca ver la lista de aviones que hay en Funciones/Mostrar Lista de Vuelos");
            else if (tutorial && fasetutorial == 15)
                MessageBox.Show("ERROR. Ahora toca ver la lista de aerolíneas que hay en Mostrar Lista Aerolíneas");
            else if (tutorial && fasetutorial == 16)
                MessageBox.Show("ERROR. Ahora toca añadir una ciudad en Funciones/Añadir Ciudad");
            else if (tutorial && fasetutorial == 18)
                MessageBox.Show("ERROR. Ahora toca borrar o eliminar un avión seleccionándolo en el mapa");
            else if (tutorial && fasetutorial == 19)
                MessageBox.Show("ERROR. Ahora toca borrar o eliminar un sector seleccionándolo en el mapa");
            else if (tutorial && fasetutorial == 20)
                MessageBox.Show("ERROR. Ahora toca guardar los aviones en Archivo/Guardar Aviones");
            else if (tutorial && fasetutorial == 21)
                MessageBox.Show("ERROR. Ahora toca guardar los sectores en Archivo/Guardar Sectores");

            else
            {
                if (milista.GetNum() == 0)
                    MessageBox.Show("No hay aviones en el espacio aéreo. Cárgalos en Archivo/Cargar Aviones");
                else
                {
                    try
                    {
                        double v = Convert.ToDouble(TextBoxV.Text);
                        MessageBox.Show("Número de aviones que vuelan a una velocidad superior: " + milista.mostrarv(v));
                        if (tutorial && fasetutorial == 17)
                        {
                            MessageBox.Show("Como puedes comprobar nos han aparecido el número de aviones que vuelan a una velocidad superior a la escrita");
                            MessageBox.Show("Ahora aprenderemos a eliminar o modificar un avión. Para ello toca el avión que quieras en el mapa y elimínalo o modifícalo");
                            fasetutorial = 18;
                            DibujarVuelo(0);
                            Dibujarsector(0);
                        }
                    }

                    catch (FormatException)
                    {
                        MessageBox.Show("Error en los datos de entrada. Debe introducir un número");
                    }
                }
            }
        }

        //Botón que permite inicializar el movimiento automático de los aviones ciclo a ciclo
        private void buttonsimulacion_Click(object sender, EventArgs e)
        {
            if (tutorial && fasetutorial == 0)
                MessageBox.Show("ERROR. Ahora toca cargar una lista de aviones en Archivo/Cargar Aviones");
            else if (tutorial && fasetutorial == 1)
                MessageBox.Show("ERROR. Ahora toca cargar una lista de sectores en Archivo/Cargar Sectores");
            else if (tutorial && fasetutorial == 2)
                MessageBox.Show("ERROR. Ahora toca introducir un tiempo de ciclo en Funciones/Introduce Tiempo Ciclo");
            else if (tutorial && fasetutorial == 3)
                MessageBox.Show("ERROR. Ahora toca mover los aviones dándole al botón Mover Vuelos");
            else if (tutorial && fasetutorial == 5)
                MessageBox.Show("ERROR. Ahora toca añadir un avión en Funciones/Añadir Vuelo");
            else if (tutorial && fasetutorial == 6)
                MessageBox.Show("ERROR. Ahora toca añadir un sector en Funciones/Añadir Sector");
            else if (tutorial && fasetutorial == 7)
                MessageBox.Show("ERROR. Ahora deshacer un movimiento de los aviones en Deshacer Aviones");
            else if (tutorial && fasetutorial == 8)
                MessageBox.Show("ERROR. Ahora toca deshacer un movimiento de los sectores en Deshacer Sectores");
            else if (tutorial && fasetutorial == 9)
                MessageBox.Show("ERROR. Ahora toca rehacer un movimiento de los aviones en Rehacer Aviones");
            else if (tutorial && fasetutorial == 10)
                MessageBox.Show("ERROR. Ahora toca rehacer un movimiento de los sectores en Rehacer Sectores");
            else if (tutorial && fasetutorial == 11)
                MessageBox.Show("ERROR. Ahora toca reiniciar la simulación de los aviones en Reiniciar Simulación");
            else if (tutorial && fasetutorial == 12)
                MessageBox.Show("ERROR. Ahora toca seleccionar los aviones que quieres mover en Seleccionar Aviones");
            else if (tutorial && fasetutorial == 13)
                MessageBox.Show("ERROR. Ahora toca mover los aviones que has seleccionado en Mover Vuelos");
            else if (tutorial && fasetutorial == 14)
                MessageBox.Show("ERROR. Ahora toca ver la lista de aviones que hay en Funciones/Mostrar Lista de Vuelos");
            else if (tutorial && fasetutorial == 15)
                MessageBox.Show("ERROR. Ahora toca ver la lista de aerolíneas que hay en Mostrar Lista Aerolíneas");
            else if (tutorial && fasetutorial == 16)
                MessageBox.Show("ERROR. Ahora toca añadir una ciudad en Funciones/Añadir Ciudad");
            else if (tutorial && fasetutorial == 17)
                MessageBox.Show("ERROR. Ahora toca ver cuantos aviones tienen una velocidad mayor a una determinada en Comprobar Velocidad");
            else if (tutorial && fasetutorial == 18)
                MessageBox.Show("ERROR. Ahora toca borrar o eliminar un avión seleccionándolo en el mapa");
            else if (tutorial && fasetutorial == 19)
                MessageBox.Show("ERROR. Ahora toca borrar o eliminar un sector seleccionándolo en el mapa");
            else if (tutorial && fasetutorial == 20)
                MessageBox.Show("ERROR. Ahora toca guardar los aviones en Archivo/Guardar Aviones");
            else if (tutorial && fasetutorial == 21)
                MessageBox.Show("ERROR. Ahora toca guardar los sectores en Archivo/Guardar Sectores");

            else
            {
                if (milista.GetNum() == 0)
                    MessageBox.Show("No hay aviones en el espacio aéreo. Cárgalos en Archivo/Cargar Aviones");

                else if (sectores.GetNum() == 0)
                    MessageBox.Show("No hay sectores en el espacio aéreo. Cárgalos en Archivo/Cargar Sectores");

                else
                {
                    if (ciclo == 0)
                    {
                        Error error = new Error();
                        error.escribirerror(-5);
                        error.ShowDialog();
                    }

                    else
                    {
                        try
                        {
                            ttotal = Convert.ToInt32(textBox1.Text);
                            int min = ttotal / 60;
                            int seg = ttotal % 60;
                            if (seg < 10)
                                Time.Text = min + ":0" + seg;
                            else
                                Time.Text = min + ":" + seg;

                            if (automatico)
                            {
                                buttonsimulacion.Text = "Empezar la simulación automática";
                                timer1.Stop();
                                automatico = false;
                                if (tutorial && fasetutorial == 4)
                                {
                                    MessageBox.Show("Debajo de Simulación Automática ha aparecido el tiempo total que has introducido y ha ido bajando según el tiempo de ciclo. Cada segundo baja el tiempo de ciclo introducido y los aviones se van moviendo. Cuando el tiempo total llegue a 0 los aviones se pararán. También puedes pararlo tu manualmente");
                                    MessageBox.Show("Ahora añadiremos un avión al mapa en Funciones/Añadir Vuelo");
                                    fasetutorial = 5;
                                }
                            }
                            else
                            {
                                timer1.Interval = 1000;
                                timer1.Start();
                                buttonsimulacion.Text = "Parar la simulación";
                                automatico = true;
                            }
                        }
                        catch (FormatException)
                        {
                            Error error = new Error();
                            error.escribirerror(-5);
                            error.ShowDialog();
                        }
                    }
                }
            }
        }

        //Función que mueve el avión ciclo a ciclo automáticamente
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            int suma = 0;

            for (int i = 0; i < milista.GetNum(); i++)
            {
                if (milista.ConsultarLista(i).GetD() == milista.ConsultarLista(i).GetA())
                    suma++;
            }

            if (milista.GetNum() == suma)
            {
                Time.Text = "00:00";
                timer1.Stop();
                automatico = false;
                buttonsimulacion.Text = "Simulación automática";
                MessageBox.Show("Los aviones han llegado a los destinos");
                if (tutorial && fasetutorial == 4)
                {
                    MessageBox.Show("Debajo de Simulación Automática ha aparecido el tiempo total que has introducido y ha ido bajando según el tiempo de ciclo. Cada segundo baja el tiempo de ciclo introducido y los aviones se van moviendo. Cuando el tiempo total llegue a 0 los aviones se pararán. También puedes pararlo tu manualmente");
                    MessageBox.Show("Ahora añadiremos un avión al mapa en Funciones/Añadir Vuelo");
                    fasetutorial = 5;
                }
            }

            else
            {
                deshacer.GuardarCopia(milista.copia());
                ttotal = ttotal - ciclo;
                if (ttotal > 0)
                {
                    for (int i = 0; i < milista.GetNum(); i++)
                    {
                        av = milista.ConsultarLista(i);
                        if (av.GetMover())
                            av.MoverAvion(ciclo);
                    }
                    Dibujarmov();

                    int min = ttotal / 60;
                    int seg = ttotal % 60;
                    if (seg < 10)
                        Time.Text = Convert.ToString(min + ":0" + seg);

                    else
                        Time.Text = Convert.ToString(min + ":" + seg);
                }
                else
                {
                    ciclo = ciclo + ttotal;
                    for (int i = 0; i < milista.GetNum(); i++)
                    {
                        av = milista.ConsultarLista(i);
                        if (av.GetMover())
                            av.MoverAvion(ciclo);
                        buttonsimulacion.Text = "Simulación automática";
                        automatico = false;
                        timer1.Stop();
                    }
                    Dibujarmov();
                    Time.Text = "00:00";
                    if (tutorial && fasetutorial == 4)
                    {
                        MessageBox.Show("Debajo de Simulación Automática ha aparecido el tiempo total que has introducido y ha ido bajando según el tiempo de ciclo. Cada segundo baja el tiempo de ciclo introducido y los aviones se van moviendo. Cuando el tiempo total llegue a 0 los aviones se pararán. También puedes pararlo tu manualmente");
                        MessageBox.Show("Ahora añadiremos un avión al mapa en Funciones/Añadir Vuelo");
                        fasetutorial = 5;
                    }
                }
            }
        }

        //Función que permite mover los aviones dentro del espacio aéreo según el tiempo de ciclo indicado por el usuario
        private void mover_Click_1(object sender, EventArgs e)
        {
            if (tutorial && fasetutorial == 0)
                MessageBox.Show("ERROR. Ahora toca cargar una lista de aviones en Archivo/Cargar Aviones");
            else if (tutorial && fasetutorial == 1)
                MessageBox.Show("ERROR. Ahora toca cargar una lista de sectores en Archivo/Cargar Sectores");
            else if (tutorial && fasetutorial == 2)
                MessageBox.Show("ERROR. Ahora toca introducir un tiempo de ciclo en Funciones/Introduce Tiempo Ciclo");
            else if (tutorial && fasetutorial == 4)
                MessageBox.Show("ERROR. Ahora toca mover los aviones automáticamente en Simulación Automática");
            else if (tutorial && fasetutorial == 5)
                MessageBox.Show("ERROR. Ahora toca añadir un avión en Funciones/Añadir Vuelo");
            else if (tutorial && fasetutorial == 6)
                MessageBox.Show("ERROR. Ahora toca añadir un sector en Funciones/Añadir Sector");
            else if (tutorial && fasetutorial == 7)
                MessageBox.Show("ERROR. Ahora deshacer un movimiento de los aviones en Deshacer Aviones");
            else if (tutorial && fasetutorial == 8)
                MessageBox.Show("ERROR. Ahora toca deshacer un movimiento de los sectores en Deshacer Sectores");
            else if (tutorial && fasetutorial == 9)
                MessageBox.Show("ERROR. Ahora toca rehacer un movimiento de los aviones en Rehacer Aviones");
            else if (tutorial && fasetutorial == 10)
                MessageBox.Show("ERROR. Ahora toca rehacer un movimiento de los sectores en Rehacer Sectores");
            else if (tutorial && fasetutorial == 11)
                MessageBox.Show("ERROR. Ahora toca reiniciar la simulación de los aviones en Reiniciar Simulación");
            else if (tutorial && fasetutorial == 12)
                MessageBox.Show("ERROR. Ahora toca seleccionar los aviones que quieres mover en Seleccionar Aviones");
            else if (tutorial && fasetutorial == 14)
                MessageBox.Show("ERROR. Ahora toca ver la lista de aviones que hay en Funciones/Mostrar Lista de Vuelos");
            else if (tutorial && fasetutorial == 15)
                MessageBox.Show("ERROR. Ahora toca ver la lista de aerolíneas que hay en Mostrar Lista Aerolíneas");
            else if (tutorial && fasetutorial == 16)
                MessageBox.Show("ERROR. Ahora toca añadir una ciudad en Funciones/Añadir Ciudad");
            else if (tutorial && fasetutorial == 17)
                MessageBox.Show("ERROR. Ahora toca ver cuantos aviones tienen una velocidad mayor a una determinada en Comprobar Velocidad");
            else if (tutorial && fasetutorial == 18)
                MessageBox.Show("ERROR. Ahora toca borrar o eliminar un avión seleccionándolo en el mapa");
            else if (tutorial && fasetutorial == 19)
                MessageBox.Show("ERROR. Ahora toca borrar o eliminar un sector seleccionándolo en el mapa");
            else if (tutorial && fasetutorial == 20)
                MessageBox.Show("ERROR. Ahora toca guardar los aviones en Archivo/Guardar Aviones");
            else if (tutorial && fasetutorial == 21)
                MessageBox.Show("ERROR. Ahora toca guardar los sectores en Archivo/Guardar Sectores");

            else
            {
                if (milista.GetNum() == 0)
                    MessageBox.Show("No hay aviones en el espacio aéreo. Cárgalos en Archivo/Cargar Aviones");

                else if (sectores.GetNum() == 0)
                    MessageBox.Show("No hay sectores en el espacio aéreo. Cárgalos en Archivo/Cargar Sectores");

                else
                {
                    if (ciclo != 0)
                    {
                        int suma = 0;

                        for (int i = 0; i < milista.GetNum(); i++)
                        {
                            if (milista.ConsultarLista(i).GetD() == milista.ConsultarLista(i).GetA())
                                suma++;
                        }

                        if (milista.GetNum() == suma)
                            MessageBox.Show("Los aviones han llegado a los destinos");

                        else
                        {
                            deshacer.GuardarCopia(milista.copia());
                            for (int i = 0; i < milista.GetNum(); i++)
                            {
                                av = new Avio();
                                av = milista.ConsultarLista(i);
                                if (av.GetMover())
                                    av.MoverAvion(ciclo);
                            }
                            Dibujarmov();

                            if (tutorial && fasetutorial == 3)
                            {
                                MessageBox.Show("Los aviones han cambiado su posición en el mapa y ahora están más cerca de su destino.");
                                MessageBox.Show("Ahora los moveremos automáticamente. Ahora deberás introducir el tiempo total de la simulación en el cuadro que hay al lado de Simulación Automática y le das a Simulación Automática");
                                fasetutorial = 4;
                            }
                            else if (tutorial && fasetutorial == 13)
                            {
                                MessageBox.Show("Ahora solo los aviones seleccionados se han movido por el mapa");
                                MessageBox.Show("Ahora aprenderemos a ver la lista de vuelos que hay en el mapa en Funciones/Mostrar Lista de Vuelos. Podemos seleccionar si verlos todos o por sectores.");
                                fasetutorial = 14;
                            }
                        }
                    }

                    else
                    {
                        Error error = new Error();
                        error.escribirerror(-4);
                        error.ShowDialog();
                    }
                }
            }
        }

        //Botón que permite volver a todos los aviones a sus posiciones de origen
        private void button1_Click(object sender, EventArgs e)
        {
            if (tutorial && fasetutorial == 0)
                MessageBox.Show("ERROR. Ahora toca cargar una lista de aviones en Archivo/Cargar Aviones");
            else if (tutorial && fasetutorial == 1)
                MessageBox.Show("ERROR. Ahora toca cargar una lista de sectores en Archivo/Cargar Sectores");
            else if (tutorial && fasetutorial == 2)
                MessageBox.Show("ERROR. Ahora toca introducir un tiempo de ciclo en Funciones/Introduce Tiempo Ciclo");
            else if (tutorial && fasetutorial == 3)
                MessageBox.Show("ERROR. Ahora toca mover los aviones dándole al botón Mover Vuelos");
            else if (tutorial && fasetutorial == 4)
                MessageBox.Show("ERROR. Ahora toca mover los aviones automáticamente en Simulación Automática");
            else if (tutorial && fasetutorial == 5)
                MessageBox.Show("ERROR. Ahora toca añadir un avión en Funciones/Añadir Vuelo");
            else if (tutorial && fasetutorial == 6)
                MessageBox.Show("ERROR. Ahora toca añadir un sector en Funciones/Añadir Sector");
            else if (tutorial && fasetutorial == 7)
                MessageBox.Show("ERROR. Ahora deshacer un movimiento de los aviones en Deshacer Aviones");
            else if (tutorial && fasetutorial == 8)
                MessageBox.Show("ERROR. Ahora toca deshacer un movimiento de los sectores en Deshacer Sectores");
            else if (tutorial && fasetutorial == 9)
                MessageBox.Show("ERROR. Ahora toca rehacer un movimiento de los aviones en Rehacer Aviones");
            else if (tutorial && fasetutorial == 10)
                MessageBox.Show("ERROR. Ahora toca rehacer un movimiento de los sectores en Rehacer Sectores");
            else if (tutorial && fasetutorial == 12)
                MessageBox.Show("ERROR. Ahora toca seleccionar los aviones que quieres mover en Seleccionar Aviones");
            else if (tutorial && fasetutorial == 13)
                MessageBox.Show("ERROR. Ahora toca mover los aviones que has seleccionado en Mover Vuelos");
            else if (tutorial && fasetutorial == 14)
                MessageBox.Show("ERROR. Ahora toca ver la lista de aviones que hay en Funciones/Mostrar Lista de Vuelos");
            else if (tutorial && fasetutorial == 15)
                MessageBox.Show("ERROR. Ahora toca ver la lista de aerolíneas que hay en Mostrar Lista Aerolíneas");
            else if (tutorial && fasetutorial == 16)
                MessageBox.Show("ERROR. Ahora toca añadir una ciudad en Funciones/Añadir Ciudad");
            else if (tutorial && fasetutorial == 17)
                MessageBox.Show("ERROR. Ahora toca ver cuantos aviones tienen una velocidad mayor a una determinada en Comprobar Velocidad");
            else if (tutorial && fasetutorial == 18)
                MessageBox.Show("ERROR. Ahora toca borrar o eliminar un avión seleccionándolo en el mapa");
            else if (tutorial && fasetutorial == 19)
                MessageBox.Show("ERROR. Ahora toca borrar o eliminar un sector seleccionándolo en el mapa");
            else if (tutorial && fasetutorial == 20)
                MessageBox.Show("ERROR. Ahora toca guardar los aviones en Archivo/Guardar Aviones");
            else if (tutorial && fasetutorial == 21)
                MessageBox.Show("ERROR. Ahora toca guardar los sectores en Archivo/Guardar Sectores");

            else
            {
                for (int i = 0; i < milista.GetNum(); i++)
                {
                    milista.ConsultarLista(i).Reiniciar();
                }
                Dibujarmov();
                if (tutorial && fasetutorial == 11)
                {
                    MessageBox.Show("Ahora todos los aviones han vuelto a su posición de origen, así que habrá que comenzar de nuevo o darle a Deshacer Avión para que los aviones vuelvan a su posición de antes");
                    MessageBox.Show("Ahora aprenderemos a mover solamente los aviones que nosotros queramos mover. Para eso habrá que ir a Seleccionar Aviones y escoger solo los que queramos mover");
                    fasetutorial = 12;
                }
            }
        }

        //Botón que permite deshacer cualquier movimiento realizado en la lista de los aviones
        private void Deshacer_Click_1(object sender, EventArgs e)
        {
            if (tutorial && fasetutorial == 0)
                MessageBox.Show("ERROR. Ahora toca cargar una lista de aviones en Archivo/Cargar Aviones");
            else if (tutorial && fasetutorial == 1)
                MessageBox.Show("ERROR. Ahora toca cargar una lista de sectores en Archivo/Cargar Sectores");
            else if (tutorial && fasetutorial == 2)
                MessageBox.Show("ERROR. Ahora toca introducir un tiempo de ciclo en Funciones/Introduce Tiempo Ciclo");
            else if (tutorial && fasetutorial == 3)
                MessageBox.Show("ERROR. Ahora toca mover los aviones dándole al botón Mover Vuelos");
            else if (tutorial && fasetutorial == 4)
                MessageBox.Show("ERROR. Ahora toca mover los aviones automáticamente en Simulación Automática");
            else if (tutorial && fasetutorial == 5)
                MessageBox.Show("ERROR. Ahora toca añadir un avión en Funciones/Añadir Vuelo");
            else if (tutorial && fasetutorial == 6)
                MessageBox.Show("ERROR. Ahora toca añadir un sector en Funciones/Añadir Sector");
            else if (tutorial && fasetutorial == 8)
                MessageBox.Show("ERROR. Ahora toca deshacer un movimiento de los sectores en Deshacer Sectores");
            else if (tutorial && fasetutorial == 9)
                MessageBox.Show("ERROR. Ahora toca rehacer un movimiento de los aviones en Rehacer Aviones");
            else if (tutorial && fasetutorial == 10)
                MessageBox.Show("ERROR. Ahora toca rehacer un movimiento de los sectores en Rehacer Sectores");
            else if (tutorial && fasetutorial == 11)
                MessageBox.Show("ERROR. Ahora toca reiniciar la simulación de los aviones en Reiniciar Simulación");
            else if (tutorial && fasetutorial == 12)
                MessageBox.Show("ERROR. Ahora toca seleccionar los aviones que quieres mover en Seleccionar Aviones");
            else if (tutorial && fasetutorial == 13)
                MessageBox.Show("ERROR. Ahora toca mover los aviones que has seleccionado en Mover Vuelos");
            else if (tutorial && fasetutorial == 14)
                MessageBox.Show("ERROR. Ahora toca ver la lista de aviones que hay en Funciones/Mostrar Lista de Vuelos");
            else if (tutorial && fasetutorial == 15)
                MessageBox.Show("ERROR. Ahora toca ver la lista de aerolíneas que hay en Mostrar Lista Aerolíneas");
            else if (tutorial && fasetutorial == 16)
                MessageBox.Show("ERROR. Ahora toca añadir una ciudad en Funciones/Añadir Ciudad");
            else if (tutorial && fasetutorial == 17)
                MessageBox.Show("ERROR. Ahora toca ver cuantos aviones tienen una velocidad mayor a una determinada en Comprobar Velocidad");
            else if (tutorial && fasetutorial == 18)
                MessageBox.Show("ERROR. Ahora toca borrar o eliminar un avión seleccionándolo en el mapa");
            else if (tutorial && fasetutorial == 19)
                MessageBox.Show("ERROR. Ahora toca borrar o eliminar un sector seleccionándolo en el mapa");
            else if (tutorial && fasetutorial == 20)
                MessageBox.Show("ERROR. Ahora toca guardar los aviones en Archivo/Guardar Aviones");
            else if (tutorial && fasetutorial == 21)
                MessageBox.Show("ERROR. Ahora toca guardar los sectores en Archivo/Guardar Sectores");

            else
            {
                if (deshacer.Copias() < 1)
                {
                    MessageBox.Show("No quedan movimientos para retroceder.");
                }

                else
                {
                    rehacer.GuardarCopia(milista.copia());
                    milista = deshacer.RecuperarCopia();
                    DibujarVuelo(0);
                    Dibujarsector(0);
                    if (tutorial && fasetutorial == 7)
                    {
                        MessageBox.Show("Solo los aviones han hecho un paso atrás. Siempre que le des a Deshacer Aviones el último movimiento se borrará, ya haya sido mover avión, eliminar avión... En este caso el avión añadido ya no está");
                        MessageBox.Show("Ahora desharemos un movimiento en los sectores. Para hacerlo hay que ir al botón Deshacer Sectores");
                        fasetutorial = 8;
                    }
                }
            }
        }

        //Botón que permite rehacer cualquier movimiento deshecho en la lista de los aviones
        private void buttonrehacer_Click(object sender, EventArgs e)
        {
            if (tutorial && fasetutorial == 0)
                MessageBox.Show("ERROR. Ahora toca cargar una lista de aviones en Archivo/Cargar Aviones");
            else if (tutorial && fasetutorial == 1)
                MessageBox.Show("ERROR. Ahora toca cargar una lista de sectores en Archivo/Cargar Sectores");
            else if (tutorial && fasetutorial == 2)
                MessageBox.Show("ERROR. Ahora toca introducir un tiempo de ciclo en Funciones/Introduce Tiempo Ciclo");
            else if (tutorial && fasetutorial == 3)
                MessageBox.Show("ERROR. Ahora toca mover los aviones dándole al botón Mover Vuelos");
            else if (tutorial && fasetutorial == 4)
                MessageBox.Show("ERROR. Ahora toca mover los aviones automáticamente en Simulación Automática");
            else if (tutorial && fasetutorial == 5)
                MessageBox.Show("ERROR. Ahora toca añadir un avión en Funciones/Añadir Vuelo");
            else if (tutorial && fasetutorial == 6)
                MessageBox.Show("ERROR. Ahora toca añadir un sector en Funciones/Añadir Sector");
            else if (tutorial && fasetutorial == 7)
                MessageBox.Show("ERROR. Ahora deshacer un movimiento de los aviones en Deshacer Aviones");
            else if (tutorial && fasetutorial == 8)
                MessageBox.Show("ERROR. Ahora toca deshacer un movimiento de los sectores en Deshacer Sectores");
            else if (tutorial && fasetutorial == 10)
                MessageBox.Show("ERROR. Ahora toca rehacer un movimiento de los sectores en Rehacer Sectores");
            else if (tutorial && fasetutorial == 11)
                MessageBox.Show("ERROR. Ahora toca reiniciar la simulación de los aviones en Reiniciar Simulación");
            else if (tutorial && fasetutorial == 12)
                MessageBox.Show("ERROR. Ahora toca seleccionar los aviones que quieres mover en Seleccionar Aviones");
            else if (tutorial && fasetutorial == 13)
                MessageBox.Show("ERROR. Ahora toca mover los aviones que has seleccionado en Mover Vuelos");
            else if (tutorial && fasetutorial == 14)
                MessageBox.Show("ERROR. Ahora toca ver la lista de aviones que hay en Funciones/Mostrar Lista de Vuelos");
            else if (tutorial && fasetutorial == 15)
                MessageBox.Show("ERROR. Ahora toca ver la lista de aerolíneas que hay en Mostrar Lista Aerolíneas");
            else if (tutorial && fasetutorial == 16)
                MessageBox.Show("ERROR. Ahora toca añadir una ciudad en Funciones/Añadir Ciudad");
            else if (tutorial && fasetutorial == 17)
                MessageBox.Show("ERROR. Ahora toca ver cuantos aviones tienen una velocidad mayor a una determinada en Comprobar Velocidad");
            else if (tutorial && fasetutorial == 18)
                MessageBox.Show("ERROR. Ahora toca borrar o eliminar un avión seleccionándolo en el mapa");
            else if (tutorial && fasetutorial == 19)
                MessageBox.Show("ERROR. Ahora toca borrar o eliminar un sector seleccionándolo en el mapa");
            else if (tutorial && fasetutorial == 20)
                MessageBox.Show("ERROR. Ahora toca guardar los aviones en Archivo/Guardar Aviones");
            else if (tutorial && fasetutorial == 21)
                MessageBox.Show("ERROR. Ahora toca guardar los sectores en Archivo/Guardar Sectores");

            else
            {
                if (rehacer.Copias() < 1)
                {
                    MessageBox.Show("No quedan movimientos para rehacer.");
                }

                else
                {
                    deshacer.GuardarCopia(milista.copia());
                    milista = rehacer.RecuperarCopia();
                    DibujarVuelo(0);
                    Dibujarsector(0);
                    if (tutorial && fasetutorial == 9)
                    {
                        MessageBox.Show("Este botón sirve para cuando le diste a Deshacer Avión y no querías.Entonces recuperar el movimiento perdido. Lo puedes usar tantas veces como le hayas dado a deshacer y te recuperará todos los movimientos. En este caso, el avión borrado por el deshacer ha vuelto al mapa. ");
                        MessageBox.Show("Ahora reharemos un movimiento en los sectores. Para hacerlo hay que ir al botón Rehacer Sectores");
                        fasetutorial = 10;
                    }
                }
            }
        }

        //Botón que permite deshacer un movimiento en los sectores
        private void button3_Click(object sender, EventArgs e)
        {
            if (tutorial && fasetutorial == 0)
                MessageBox.Show("ERROR. Ahora toca cargar una lista de aviones en Archivo/Cargar Aviones");
            else if (tutorial && fasetutorial == 1)
                MessageBox.Show("ERROR. Ahora toca cargar una lista de sectores en Archivo/Cargar Sectores");
            else if (tutorial && fasetutorial == 2)
                MessageBox.Show("ERROR. Ahora toca introducir un tiempo de ciclo en Funciones/Introduce Tiempo Ciclo");
            else if (tutorial && fasetutorial == 3)
                MessageBox.Show("ERROR. Ahora toca mover los aviones dándole al botón Mover Vuelos");
            else if (tutorial && fasetutorial == 4)
                MessageBox.Show("ERROR. Ahora toca mover los aviones automáticamente en Simulación Automática");
            else if (tutorial && fasetutorial == 5)
                MessageBox.Show("ERROR. Ahora toca añadir un avión en Funciones/Añadir Vuelo");
            else if (tutorial && fasetutorial == 6)
                MessageBox.Show("ERROR. Ahora toca añadir un sector en Funciones/Añadir Sector");
            else if (tutorial && fasetutorial == 7)
                MessageBox.Show("ERROR. Ahora deshacer un movimiento de los aviones en Deshacer Aviones");
            else if (tutorial && fasetutorial == 9)
                MessageBox.Show("ERROR. Ahora toca rehacer un movimiento de los aviones en Rehacer Aviones");
            else if (tutorial && fasetutorial == 10)
                MessageBox.Show("ERROR. Ahora toca rehacer un movimiento de los sectores en Rehacer Sectores");
            else if (tutorial && fasetutorial == 11)
                MessageBox.Show("ERROR. Ahora toca reiniciar la simulación de los aviones en Reiniciar Simulación");
            else if (tutorial && fasetutorial == 12)
                MessageBox.Show("ERROR. Ahora toca seleccionar los aviones que quieres mover en Seleccionar Aviones");
            else if (tutorial && fasetutorial == 13)
                MessageBox.Show("ERROR. Ahora toca mover los aviones que has seleccionado en Mover Vuelos");
            else if (tutorial && fasetutorial == 14)
                MessageBox.Show("ERROR. Ahora toca ver la lista de aviones que hay en Funciones/Mostrar Lista de Vuelos");
            else if (tutorial && fasetutorial == 15)
                MessageBox.Show("ERROR. Ahora toca ver la lista de aerolíneas que hay en Mostrar Lista Aerolíneas");
            else if (tutorial && fasetutorial == 16)
                MessageBox.Show("ERROR. Ahora toca añadir una ciudad en Funciones/Añadir Ciudad");
            else if (tutorial && fasetutorial == 17)
                MessageBox.Show("ERROR. Ahora toca ver cuantos aviones tienen una velocidad mayor a una determinada en Comprobar Velocidad");
            else if (tutorial && fasetutorial == 18)
                MessageBox.Show("ERROR. Ahora toca borrar o eliminar un avión seleccionándolo en el mapa");
            else if (tutorial && fasetutorial == 19)
                MessageBox.Show("ERROR. Ahora toca borrar o eliminar un sector seleccionándolo en el mapa");
            else if (tutorial && fasetutorial == 20)
                MessageBox.Show("ERROR. Ahora toca guardar los aviones en Archivo/Guardar Aviones");
            else if (tutorial && fasetutorial == 21)
                MessageBox.Show("ERROR. Ahora toca guardar los sectores en Archivo/Guardar Sectores");

            else
            {
                if (deshacer.CopiasSec() < 1)
                {
                    MessageBox.Show("No quedan movimientos para retroceder.");
                }

                else
                {
                    rehacer.GuardarCopiaSec(sectores.copia());
                    sectores = deshacer.RecuperarCopiaSec();
                    DibujarVuelo(0);
                    Dibujarsector(0);
                    if (tutorial && fasetutorial == 8)
                    {
                        MessageBox.Show("Con los sectores pasa igual que con los aviones. Cualquier movimiento que hayas hecho, dándole a Deshacer Sectores se borrará");
                        MessageBox.Show("Ahora reharemos un movimiento en los aviones. Para hacerlo hay que ir al botón Rehacer Aviones");
                        fasetutorial = 9;
                    }
                }
            }
        }

        //Función que permite rehacer un movimiento deshecho en los sectores
        private void button4_Click(object sender, EventArgs e)
        {
            if (tutorial && fasetutorial == 0)
                MessageBox.Show("ERROR. Ahora toca cargar una lista de aviones en Archivo/Cargar Aviones");
            else if (tutorial && fasetutorial == 1)
                MessageBox.Show("ERROR. Ahora toca cargar una lista de sectores en Archivo/Cargar Sectores");
            else if (tutorial && fasetutorial == 2)
                MessageBox.Show("ERROR. Ahora toca introducir un tiempo de ciclo en Funciones/Introduce Tiempo Ciclo");
            else if (tutorial && fasetutorial == 3)
                MessageBox.Show("ERROR. Ahora toca mover los aviones dándole al botón Mover Vuelos");
            else if (tutorial && fasetutorial == 4)
                MessageBox.Show("ERROR. Ahora toca mover los aviones automáticamente en Simulación Automática");
            else if (tutorial && fasetutorial == 5)
                MessageBox.Show("ERROR. Ahora toca añadir un avión en Funciones/Añadir Vuelo");
            else if (tutorial && fasetutorial == 6)
                MessageBox.Show("ERROR. Ahora toca añadir un sector en Funciones/Añadir Sector");
            else if (tutorial && fasetutorial == 7)
                MessageBox.Show("ERROR. Ahora deshacer un movimiento de los aviones en Deshacer Aviones");
            else if (tutorial && fasetutorial == 8)
                MessageBox.Show("ERROR. Ahora toca deshacer un movimiento de los sectores en Deshacer Sectores");
            else if (tutorial && fasetutorial == 9)
                MessageBox.Show("ERROR. Ahora toca rehacer un movimiento de los aviones en Rehacer Aviones");
            else if (tutorial && fasetutorial == 11)
                MessageBox.Show("ERROR. Ahora toca reiniciar la simulación de los aviones en Reiniciar Simulación");
            else if (tutorial && fasetutorial == 12)
                MessageBox.Show("ERROR. Ahora toca seleccionar los aviones que quieres mover en Seleccionar Aviones");
            else if (tutorial && fasetutorial == 13)
                MessageBox.Show("ERROR. Ahora toca mover los aviones que has seleccionado en Mover Vuelos");
            else if (tutorial && fasetutorial == 14)
                MessageBox.Show("ERROR. Ahora toca ver la lista de aviones que hay en Funciones/Mostrar Lista de Vuelos");
            else if (tutorial && fasetutorial == 15)
                MessageBox.Show("ERROR. Ahora toca ver la lista de aerolíneas que hay en Mostrar Lista Aerolíneas");
            else if (tutorial && fasetutorial == 16)
                MessageBox.Show("ERROR. Ahora toca añadir una ciudad en Funciones/Añadir Ciudad");
            else if (tutorial && fasetutorial == 17)
                MessageBox.Show("ERROR. Ahora toca ver cuantos aviones tienen una velocidad mayor a una determinada en Comprobar Velocidad");
            else if (tutorial && fasetutorial == 18)
                MessageBox.Show("ERROR. Ahora toca borrar o eliminar un avión seleccionándolo en el mapa");
            else if (tutorial && fasetutorial == 19)
                MessageBox.Show("ERROR. Ahora toca borrar o eliminar un sector seleccionándolo en el mapa");
            else if (tutorial && fasetutorial == 20)
                MessageBox.Show("ERROR. Ahora toca guardar los aviones en Archivo/Guardar Aviones");
            else if (tutorial && fasetutorial == 21)
                MessageBox.Show("ERROR. Ahora toca guardar los sectores en Archivo/Guardar Sectores");

            else
            {
                if (rehacer.CopiasSec() < 1)
                {
                    MessageBox.Show("No quedan movimientos para rehacer.");
                }
                else
                {
                    deshacer.GuardarCopiaSec(sectores.copia());
                    sectores = rehacer.RecuperarCopiaSec();
                    DibujarVuelo(0);
                    Dibujarsector(0);
                    if (tutorial && fasetutorial == 10)
                    {
                        MessageBox.Show("Con los sectores pasa igual que con los aviones. Cualquier movimiento que pierdas dándole a deshacer, lo podrás recuperar en rehacer");
                        MessageBox.Show("Ahora reiniciaremos la simulación, es decir todos los aviones volverán a su posición de origen. Para hacerlo hay que darle a Reiniciar Simulación");
                        fasetutorial = 11;
                    }
                }
            }
        }

        //Función que permite añadir un avión a la lista y dibujarlo en el mapa
        private void añadirVueloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tutorial && fasetutorial == 0)
                MessageBox.Show("ERROR. Ahora toca cargar una lista de aviones en Archivo/Cargar Aviones");
            else if (tutorial && fasetutorial == 1)
                MessageBox.Show("ERROR. Ahora toca cargar una lista de sectores en Archivo/Cargar Sectores");
            else if (tutorial && fasetutorial == 2)
                MessageBox.Show("ERROR. Ahora toca introducir un tiempo de ciclo en Funciones/Introduce Tiempo Ciclo");
            else if (tutorial && fasetutorial == 3)
                MessageBox.Show("ERROR. Ahora toca mover los aviones dándole al botón Mover Vuelos");
            else if (tutorial && fasetutorial == 4)
                MessageBox.Show("ERROR. Ahora toca mover los aviones automáticamente en Simulación Automática");
            else if (tutorial && fasetutorial == 6)
                MessageBox.Show("ERROR. Ahora toca añadir un sector en Funciones/Añadir Sector");
            else if (tutorial && fasetutorial == 7)
                MessageBox.Show("ERROR. Ahora deshacer un movimiento de los aviones en Deshacer Aviones");
            else if (tutorial && fasetutorial == 8)
                MessageBox.Show("ERROR. Ahora toca deshacer un movimiento de los sectores en Deshacer Sectores");
            else if (tutorial && fasetutorial == 9)
                MessageBox.Show("ERROR. Ahora toca rehacer un movimiento de los aviones en Rehacer Aviones");
            else if (tutorial && fasetutorial == 10)
                MessageBox.Show("ERROR. Ahora toca rehacer un movimiento de los sectores en Rehacer Sectores");
            else if (tutorial && fasetutorial == 11)
                MessageBox.Show("ERROR. Ahora toca reiniciar la simulación de los aviones en Reiniciar Simulación");
            else if (tutorial && fasetutorial == 12)
                MessageBox.Show("ERROR. Ahora toca seleccionar los aviones que quieres mover en Seleccionar Aviones");
            else if (tutorial && fasetutorial == 13)
                MessageBox.Show("ERROR. Ahora toca mover los aviones que has seleccionado en Mover Vuelos");
            else if (tutorial && fasetutorial == 14)
                MessageBox.Show("ERROR. Ahora toca ver la lista de aviones que hay en Funciones/Mostrar Lista de Vuelos");
            else if (tutorial && fasetutorial == 15)
                MessageBox.Show("ERROR. Ahora toca ver la lista de aerolíneas que hay en Mostrar Lista Aerolíneas");
            else if (tutorial && fasetutorial == 16)
                MessageBox.Show("ERROR. Ahora toca añadir una ciudad en Funciones/Añadir Ciudad");
            else if (tutorial && fasetutorial == 17)
                MessageBox.Show("ERROR. Ahora toca ver cuantos aviones tienen una velocidad mayor a una determinada en Comprobar Velocidad");
            else if (tutorial && fasetutorial == 18)
                MessageBox.Show("ERROR. Ahora toca borrar o eliminar un avión seleccionándolo en el mapa");
            else if (tutorial && fasetutorial == 19)
                MessageBox.Show("ERROR. Ahora toca borrar o eliminar un sector seleccionándolo en el mapa");
            else if (tutorial && fasetutorial == 20)
                MessageBox.Show("ERROR. Ahora toca guardar los aviones en Archivo/Guardar Aviones");
            else if (tutorial && fasetutorial == 21)
                MessageBox.Show("ERROR. Ahora toca guardar los sectores en Archivo/Guardar Sectores");

            else
            {
                AñadirVuelos form = new AñadirVuelos();
                form.SetCiudades(listaciudades);
                form.ShowDialog();
                av = form.Añadiravion();
                if (av != null)
                {
                    deshacer.GuardarCopia(milista.copia());
                    milista.AñadirAvion(av);
                    MessageBox.Show("Avión añadido a la lista.");
                    DibujarVuelo(milista.GetNum() - 1);
                    if (tutorial && fasetutorial == 5)
                    {
                        MessageBox.Show("El nuevo avión aparece en el mapa con sus datos.");
                        MessageBox.Show("Ahora vamos a añadir un sector de la misma forma en Funciones/Añadir Sector");
                        fasetutorial = 6;
                    }
                }
            }
        }

        //Función que permite añadir un sector a la lista
        private void añadirSectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tutorial && fasetutorial == 0)
                MessageBox.Show("ERROR. Ahora toca cargar una lista de aviones en Archivo/Cargar Aviones");
            else if (tutorial && fasetutorial == 1)
                MessageBox.Show("ERROR. Ahora toca cargar una lista de sectores en Archivo/Cargar Sectores");
            else if (tutorial && fasetutorial == 2)
                MessageBox.Show("ERROR. Ahora toca introducir un tiempo de ciclo en Funciones/Introduce Tiempo Ciclo");
            else if (tutorial && fasetutorial == 3)
                MessageBox.Show("ERROR. Ahora toca mover los aviones dándole al botón Mover Vuelos");
            else if (tutorial && fasetutorial == 4)
                MessageBox.Show("ERROR. Ahora toca mover los aviones automáticamente en Simulación Automática");
            else if (tutorial && fasetutorial == 5)
                MessageBox.Show("ERROR. Ahora toca añadir un avión en Funciones/Añadir Vuelo");
            else if (tutorial && fasetutorial == 7)
                MessageBox.Show("ERROR. Ahora deshacer un movimiento de los aviones en Deshacer Aviones");
            else if (tutorial && fasetutorial == 8)
                MessageBox.Show("ERROR. Ahora toca deshacer un movimiento de los sectores en Deshacer Sectores");
            else if (tutorial && fasetutorial == 9)
                MessageBox.Show("ERROR. Ahora toca rehacer un movimiento de los aviones en Rehacer Aviones");
            else if (tutorial && fasetutorial == 10)
                MessageBox.Show("ERROR. Ahora toca rehacer un movimiento de los sectores en Rehacer Sectores");
            else if (tutorial && fasetutorial == 11)
                MessageBox.Show("ERROR. Ahora toca reiniciar la simulación de los aviones en Reiniciar Simulación");
            else if (tutorial && fasetutorial == 12)
                MessageBox.Show("ERROR. Ahora toca seleccionar los aviones que quieres mover en Seleccionar Aviones");
            else if (tutorial && fasetutorial == 13)
                MessageBox.Show("ERROR. Ahora toca mover los aviones que has seleccionado en Mover Vuelos");
            else if (tutorial && fasetutorial == 14)
                MessageBox.Show("ERROR. Ahora toca ver la lista de aviones que hay en Funciones/Mostrar Lista de Vuelos");
            else if (tutorial && fasetutorial == 15)
                MessageBox.Show("ERROR. Ahora toca ver la lista de aerolíneas que hay en Mostrar Lista Aerolíneas");
            else if (tutorial && fasetutorial == 16)
                MessageBox.Show("ERROR. Ahora toca añadir una ciudad en Funciones/Añadir Ciudad");
            else if (tutorial && fasetutorial == 17)
                MessageBox.Show("ERROR. Ahora toca ver cuantos aviones tienen una velocidad mayor a una determinada en Comprobar Velocidad");
            else if (tutorial && fasetutorial == 18)
                MessageBox.Show("ERROR. Ahora toca borrar o eliminar un avión seleccionándolo en el mapa");
            else if (tutorial && fasetutorial == 19)
                MessageBox.Show("ERROR. Ahora toca borrar o eliminar un sector seleccionándolo en el mapa");
            else if (tutorial && fasetutorial == 20)
                MessageBox.Show("ERROR. Ahora toca guardar los aviones en Archivo/Guardar Aviones");
            else if (tutorial && fasetutorial == 21)
                MessageBox.Show("ERROR. Ahora toca guardar los sectores en Archivo/Guardar Sectores");

            else
            {
                AñadirSector AS = new AñadirSector();
                AS.ShowDialog();
                misector = AS.Añadirsector();

                if (misector != null)
                {
                    deshacer.GuardarCopiaSec(sectores.copia());
                    sectores.AñadirSector(misector);
                    MessageBox.Show("Sector añadido a la lista");
                    Dibujarsector(sectores.GetNum() - 1);
                    if (tutorial && fasetutorial == 6)
                    {
                        MessageBox.Show("El nuevo sector también aparece dibujado en el mapa con sus datos");
                        MessageBox.Show("Ahora vamos a deshacer los movimientos hechos. Para deshacer un movimiento en los aviones hay que darle a Deshacer Aviones");
                        fasetutorial = 7;
                    }
                }
            }
        }

        //Botón que permite añadir una ciudad a la lista de ciudades
        private void añadirCiudadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tutorial && fasetutorial == 0)
                MessageBox.Show("ERROR. Ahora toca cargar una lista de aviones en Archivo/Cargar Aviones");
            else if (tutorial && fasetutorial == 1)
                MessageBox.Show("ERROR. Ahora toca cargar una lista de sectores en Archivo/Cargar Sectores");
            else if (tutorial && fasetutorial == 2)
                MessageBox.Show("ERROR. Ahora toca introducir un tiempo de ciclo en Funciones/Introduce Tiempo Ciclo");
            else if (tutorial && fasetutorial == 3)
                MessageBox.Show("ERROR. Ahora toca mover los aviones dándole al botón Mover Vuelos");
            else if (tutorial && fasetutorial == 4)
                MessageBox.Show("ERROR. Ahora toca mover los aviones automáticamente en Simulación Automática");
            else if (tutorial && fasetutorial == 5)
                MessageBox.Show("ERROR. Ahora toca añadir un avión en Funciones/Añadir Vuelo");
            else if (tutorial && fasetutorial == 6)
                MessageBox.Show("ERROR. Ahora toca añadir un sector en Funciones/Añadir Sector");
            else if (tutorial && fasetutorial == 7)
                MessageBox.Show("ERROR. Ahora deshacer un movimiento de los aviones en Deshacer Aviones");
            else if (tutorial && fasetutorial == 8)
                MessageBox.Show("ERROR. Ahora toca deshacer un movimiento de los sectores en Deshacer Sectores");
            else if (tutorial && fasetutorial == 9)
                MessageBox.Show("ERROR. Ahora toca rehacer un movimiento de los aviones en Rehacer Aviones");
            else if (tutorial && fasetutorial == 10)
                MessageBox.Show("ERROR. Ahora toca rehacer un movimiento de los sectores en Rehacer Sectores");
            else if (tutorial && fasetutorial == 11)
                MessageBox.Show("ERROR. Ahora toca reiniciar la simulación de los aviones en Reiniciar Simulación");
            else if (tutorial && fasetutorial == 12)
                MessageBox.Show("ERROR. Ahora toca seleccionar los aviones que quieres mover en Seleccionar Aviones");
            else if (tutorial && fasetutorial == 13)
                MessageBox.Show("ERROR. Ahora toca mover los aviones que has seleccionado en Mover Vuelos");
            else if (tutorial && fasetutorial == 14)
                MessageBox.Show("ERROR. Ahora toca ver la lista de aviones que hay en Funciones/Mostrar Lista de Vuelos");
            else if (tutorial && fasetutorial == 15)
                MessageBox.Show("ERROR. Ahora toca ver la lista de aerolíneas que hay en Mostrar Lista Aerolíneas");
            else if (tutorial && fasetutorial == 17)
                MessageBox.Show("ERROR. Ahora toca ver cuantos aviones tienen una velocidad mayor a una determinada en Comprobar Velocidad");
            else if (tutorial && fasetutorial == 18)
                MessageBox.Show("ERROR. Ahora toca borrar o eliminar un avión seleccionándolo en el mapa");
            else if (tutorial && fasetutorial == 19)
                MessageBox.Show("ERROR. Ahora toca borrar o eliminar un sector seleccionándolo en el mapa");
            else if (tutorial && fasetutorial == 20)
                MessageBox.Show("ERROR. Ahora toca guardar los aviones en Archivo/Guardar Aviones");
            else if (tutorial && fasetutorial == 21)
                MessageBox.Show("ERROR. Ahora toca guardar los sectores en Archivo/Guardar Sectores");

            else
            {
                añadirciudad = true;
                MessageBox.Show("Toca un punto del mapa");
            }
        }

        //Función que permite ver los datos de todos los aviones
        private void todosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tutorial && fasetutorial == 0)
                MessageBox.Show("ERROR. Ahora toca cargar una lista de aviones en Archivo/Cargar Aviones");
            else if (tutorial && fasetutorial == 1)
                MessageBox.Show("ERROR. Ahora toca cargar una lista de sectores en Archivo/Cargar Sectores");
            else if (tutorial && fasetutorial == 2)
                MessageBox.Show("ERROR. Ahora toca introducir un tiempo de ciclo en Funciones/Introduce Tiempo Ciclo");
            else if (tutorial && fasetutorial == 3)
                MessageBox.Show("ERROR. Ahora toca mover los aviones dándole al botón Mover Vuelos");
            else if (tutorial && fasetutorial == 4)
                MessageBox.Show("ERROR. Ahora toca mover los aviones automáticamente en Simulación Automática");
            else if (tutorial && fasetutorial == 5)
                MessageBox.Show("ERROR. Ahora toca añadir un avión en Funciones/Añadir Vuelo");
            else if (tutorial && fasetutorial == 6)
                MessageBox.Show("ERROR. Ahora toca añadir un sector en Funciones/Añadir Sector");
            else if (tutorial && fasetutorial == 7)
                MessageBox.Show("ERROR. Ahora deshacer un movimiento de los aviones en Deshacer Aviones");
            else if (tutorial && fasetutorial == 8)
                MessageBox.Show("ERROR. Ahora toca deshacer un movimiento de los sectores en Deshacer Sectores");
            else if (tutorial && fasetutorial == 9)
                MessageBox.Show("ERROR. Ahora toca rehacer un movimiento de los aviones en Rehacer Aviones");
            else if (tutorial && fasetutorial == 10)
                MessageBox.Show("ERROR. Ahora toca rehacer un movimiento de los sectores en Rehacer Sectores");
            else if (tutorial && fasetutorial == 11)
                MessageBox.Show("ERROR. Ahora toca reiniciar la simulación de los aviones en Reiniciar Simulación");
            else if (tutorial && fasetutorial == 12)
                MessageBox.Show("ERROR. Ahora toca seleccionar los aviones que quieres mover en Seleccionar Aviones");
            else if (tutorial && fasetutorial == 13)
                MessageBox.Show("ERROR. Ahora toca mover los aviones que has seleccionado en Mover Vuelos");
            else if (tutorial && fasetutorial == 15)
                MessageBox.Show("ERROR. Ahora toca ver la lista de aerolíneas que hay en Mostrar Lista Aerolíneas");
            else if (tutorial && fasetutorial == 16)
                MessageBox.Show("ERROR. Ahora toca añadir una ciudad en Funciones/Añadir Ciudad");
            else if (tutorial && fasetutorial == 17)
                MessageBox.Show("ERROR. Ahora toca ver cuantos aviones tienen una velocidad mayor a una determinada en Comprobar Velocidad");
            else if (tutorial && fasetutorial == 18)
                MessageBox.Show("ERROR. Ahora toca borrar o eliminar un avión seleccionándolo en el mapa");
            else if (tutorial && fasetutorial == 19)
                MessageBox.Show("ERROR. Ahora toca borrar o eliminar un sector seleccionándolo en el mapa");
            else if (tutorial && fasetutorial == 20)
                MessageBox.Show("ERROR. Ahora toca guardar los aviones en Archivo/Guardar Aviones");
            else if (tutorial && fasetutorial == 21)
                MessageBox.Show("ERROR. Ahora toca guardar los sectores en Archivo/Guardar Sectores");

            else
            {
                if (milista.GetNum() == 0)
                    MessageBox.Show("No hay aviones en el espacio aéreo. Cárgalos en Archivo/Cargar Aviones");

                else
                {
                    MostrarVuelos F4 = new MostrarVuelos();
                    F4.listaaviones(milista);
                    F4.ShowDialog();
                    if (tutorial && fasetutorial == 14)
                    {
                        MessageBox.Show("Hemos podido ver todos los aviones que había en el mapa con sus respectivos datos");
                        MessageBox.Show("Ahora aprenderemos a ver la lista de Aerolíneas en Lista Aerolíneas.");
                        fasetutorial = 15;
                    }
                }
            }
        }

        //Función que permite ver los datos de los aviones que están en un cierto sector
        private void porSectoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tutorial && fasetutorial == 0)
                MessageBox.Show("ERROR. Ahora toca cargar una lista de aviones en Archivo/Cargar Aviones");
            else if (tutorial && fasetutorial == 1)
                MessageBox.Show("ERROR. Ahora toca cargar una lista de sectores en Archivo/Cargar Sectores");
            else if (tutorial && fasetutorial == 2)
                MessageBox.Show("ERROR. Ahora toca introducir un tiempo de ciclo en Funciones/Introduce Tiempo Ciclo");
            else if (tutorial && fasetutorial == 3)
                MessageBox.Show("ERROR. Ahora toca mover los aviones dándole al botón Mover Vuelos");
            else if (tutorial && fasetutorial == 4)
                MessageBox.Show("ERROR. Ahora toca mover los aviones automáticamente en Simulación Automática");
            else if (tutorial && fasetutorial == 5)
                MessageBox.Show("ERROR. Ahora toca añadir un avión en Funciones/Añadir Vuelo");
            else if (tutorial && fasetutorial == 6)
                MessageBox.Show("ERROR. Ahora toca añadir un sector en Funciones/Añadir Sector");
            else if (tutorial && fasetutorial == 7)
                MessageBox.Show("ERROR. Ahora deshacer un movimiento de los aviones en Deshacer Aviones");
            else if (tutorial && fasetutorial == 8)
                MessageBox.Show("ERROR. Ahora toca deshacer un movimiento de los sectores en Deshacer Sectores");
            else if (tutorial && fasetutorial == 9)
                MessageBox.Show("ERROR. Ahora toca rehacer un movimiento de los aviones en Rehacer Aviones");
            else if (tutorial && fasetutorial == 10)
                MessageBox.Show("ERROR. Ahora toca rehacer un movimiento de los sectores en Rehacer Sectores");
            else if (tutorial && fasetutorial == 11)
                MessageBox.Show("ERROR. Ahora toca reiniciar la simulación de los aviones en Reiniciar Simulación");
            else if (tutorial && fasetutorial == 12)
                MessageBox.Show("ERROR. Ahora toca seleccionar los aviones que quieres mover en Seleccionar Aviones");
            else if (tutorial && fasetutorial == 13)
                MessageBox.Show("ERROR. Ahora toca mover los aviones que has seleccionado en Mover Vuelos");
            else if (tutorial && fasetutorial == 15)
                MessageBox.Show("ERROR. Ahora toca ver la lista de aerolíneas que hay en Mostrar Lista Aerolíneas");
            else if (tutorial && fasetutorial == 16)
                MessageBox.Show("ERROR. Ahora toca añadir una ciudad en Funciones/Añadir Ciudad");
            else if (tutorial && fasetutorial == 17)
                MessageBox.Show("ERROR. Ahora toca ver cuantos aviones tienen una velocidad mayor a una determinada en Comprobar Velocidad");
            else if (tutorial && fasetutorial == 18)
                MessageBox.Show("ERROR. Ahora toca borrar o eliminar un avión seleccionándolo en el mapa");
            else if (tutorial && fasetutorial == 19)
                MessageBox.Show("ERROR. Ahora toca borrar o eliminar un sector seleccionándolo en el mapa");
            else if (tutorial && fasetutorial == 20)
                MessageBox.Show("ERROR. Ahora toca guardar los aviones en Archivo/Guardar Aviones");
            else if (tutorial && fasetutorial == 21)
                MessageBox.Show("ERROR. Ahora toca guardar los sectores en Archivo/Guardar Sectores");

            else
            {
                if (milista.GetNum() == 0)
                    MessageBox.Show("No hay aviones en el espacio aéreo. Cárgalos en Archivo/Cargar Aviones");

                else if (sectores.GetNum() == 0)
                    MessageBox.Show("No hay sectores en el espacio aéreo. Cárgalos en Archivo/Cargar Sectores");

                else
                {
                    ElegirSector ES = new ElegirSector();
                    ES.escribirsector(sectores);
                    ES.ShowDialog();

                    if (ES.escogido())
                    {
                        misector = ES.devsector();
                        LlistaAvions lista2 = new LlistaAvions();
                        for (int i = 0; i < milista.GetNum(); i++)
                        {
                            av = milista.ConsultarLista(i);
                            if (misector.ComprobarSector(av.GetA().GetX(), av.GetA().GetY()) == 1)
                                lista2.AñadirAvion(av);
                        }

                        if (lista2.GetNum() == 0)
                            MessageBox.Show("En el sector seleccionado no hay ningún avión");

                        else
                        {
                            MostrarVuelos F4 = new MostrarVuelos();
                            F4.listaaviones(lista2);
                            F4.ShowDialog();
                        }
                    }
                    if (tutorial && fasetutorial == 14)
                    {
                        MessageBox.Show("Hemos podido ver los datos de los aviones que estaban dentro del sector seleccionado");
                        MessageBox.Show("Ahora aprenderemos a ver la lista de Aerolíneas en Lista Aerolíneas.");
                        fasetutorial = 15;
                    }
                }
            }
        }
 
        //Permite acceder a la información de los autores del programa
        private void autoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Infoautores F8 = new Infoautores();
            F8.ShowDialog();
        }

        //Permite acceder a la información de la funciones adicionales
        private void funcionesAdicionalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Infofunciones F7 = new Infofunciones();
            F7.ShowDialog();
        }

        //Botón que abre un formulario con algunas instrucciones
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Instrucciones F8 = new Instrucciones();
            F8.ShowDialog();
        }

        //Botón que permite cerrar el Formulario
        private void Simulacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cerrar Form = new Cerrar();
            Form.ShowDialog();

            if (Form.GetNum() != -1)
                e.Cancel = true;
        }
    }
}

