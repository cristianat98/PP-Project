using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace ClasesProyecto
{
    public class LlistaAvions
    {
        //Atributos de la clase LlistaAvions 
        List<Avio> aviones = new List<Avio>();

        //Método para cargar la lista de aviones 
        public int CargarLista(string name, List<Ciudades> lc)
        {
            StreamReader F;

            try
            {

                F = new StreamReader(name);
                int b = Convert.ToInt32(F.ReadLine());
                int i = 0;

                while (i < b)
                {
                    string line = F.ReadLine();
                    string[] str = line.Split();

                    if (str.Length != 9)
                        return -2;

                    else
                    {
                        string id = str[0];
                        string compañia = str[1];              
                        Coordenades actual = new Coordenades(Convert.ToDouble(str[2]), Convert.ToDouble(str[3]));
                        Coordenades origen = new Coordenades(Convert.ToDouble(str[5]), Convert.ToDouble(str[6]));
                        Coordenades destino = new Coordenades(Convert.ToDouble(str[7]), Convert.ToDouble(str[8]));
                        double velocidad = Convert.ToDouble(str[4]);
                        if (origen.GetX() > 700)
                            origen.SetX(700);
                        if (origen.GetY() > 600)
                            origen.SetY(600);
                        if (actual.GetX() > 700)
                            actual.SetX(700);
                        if (actual.GetY() > 600)
                            actual.SetY(600);
                        if (destino.GetX() > 700)
                            destino.SetX(700);
                        if (destino.GetY() > 600)
                            destino.SetY(600);

                        Avio lista = new Avio(actual, origen, destino, id, compañia, velocidad, lc);
                        this.aviones.Add(lista);
                    }
                    i++;
                }
                F.Close();
                return 0;
            }
            catch (FileNotFoundException)
            {
                return -1;
            }
            catch (FormatException)
            {
                return -2;
            }

        }

        //Método para guardar la lista de aviones
        public void GuardarLista(string dir)
        {
            StreamWriter A = new StreamWriter(dir);
            A.WriteLine("{0}", this.aviones.Count);

            for (int i = 0; i < this.aviones.Count; i++)
            {
                Avio av = new Avio();
                av = this.aviones[i];
                string[] tr = av.GetID().Split();
                int a = 0;
                while (a < tr.Length - 1)
                {
                    tr[0] = tr[0] + tr[a + 1];
                    a++;
                }
                    A.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8}", tr[0], av.GetCompañia(), av.GetA().GetX(), av.GetA().GetY(), av.GetVelocidad(), av.GetO().GetX(), av.GetO().GetY(), av.GetD().GetX(), av.GetD().GetY());
            }
            A.Close();
        }

        //Método para añadir un avion a la lista de aviones
        public void AñadirAvion(Avio avion)
        {
            this.aviones.Add(avion);
        }

        //Método para consultar el avión que hay en una posición de la lista que recibe como parámetro
        public Avio ConsultarLista(int a)
        {
            Avio v = new Avio();
            v = this.aviones[a];
            return v;
        }

        //Método que permite eliminar un avión de la lista en una posición que recibe como parámetro
        public void eliminar(int a)
        {
            aviones.RemoveAt(a);
        }

        //Método que devuelve el número de aviones de la lista
        public int GetNum()
        {
            return this.aviones.Count;
        }

        //Método que mueve el avión durante un tiempo que recibe como parámetro
        public void Mover(int ciclo)
        {
            for (int i = 0; i < this.aviones.Count; i++)
            {
                this.aviones[i].MoverAvion(ciclo);
                i = i + 1;
            }

        }

        //Método que devuelve a los aviones a su posición de origen
        public void Reiniciar()
        {
            for (int i = 0; i < this.aviones.Count; i++)
            {
                this.aviones[i].SetA(this.aviones[i].GetO());
            }
        }

        //Método que devuelve el número de aviones que vuelan por encima de una velocidad recibida como parámetro
        public int mostrarv(double vel)
        {
            int i = 0;
            int cont = 0;
            while (i < this.aviones.Count)
            {
                if (vel < aviones[i].GetVelocidad())
                    cont++;
                i++;
            }
            return cont;
        }

        //Método que devuelve la copia de una lista de aviones
        public LlistaAvions copia()
        {
            LlistaAvions aviones2 = new LlistaAvions();
            for (int i = 0; i < this.aviones.Count; i++)
            {
                Avio av = new Avio(aviones[i]);
                aviones2.AñadirAvion(av);
            }
            return aviones2;
        }

        //Método que permite borrar toda la lista
        public void Borrarlista()
        {
            aviones.Clear();
        }
    }
}
