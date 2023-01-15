using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ClasesProyecto
{
    public class ListaSectores
    {
        //Variables de la cla ListaSectores
        List<Sectors> lista = new List<Sectors>();

        //Método que carga un fichero .txt de aviones y los añade a la lista.
        public int cargarsector(string name)
        {
            StreamReader F;

            try
            {
                F = new StreamReader(name);
                int a = Convert.ToInt32(F.ReadLine());

                for (int i = 0; i < a; i++)
                {
                    string linea = F.ReadLine();
                    string[] tr = linea.Split();
                    if (tr.Length != 5)
                        return -2;

                    else
                    {
                        Coordenades NO = new Coordenades(Convert.ToDouble(tr[1]), Convert.ToDouble(tr[2]));
                        Coordenades SE = new Coordenades(Convert.ToDouble(tr[3]), Convert.ToDouble(tr[4]));
                        if (NO.GetX() > SE.GetX())
                        {
                            NO.SetX(Convert.ToDouble(tr[3]));
                            SE.SetX(Convert.ToDouble(tr[1]));
                        }

                        if (NO.GetY() > SE.GetY())
                        {
                            NO.SetY(Convert.ToDouble(tr[3]));
                            SE.SetY(Convert.ToDouble(tr[1]));
                        }

                        if (NO.GetX() > 700)
                            NO.SetX(700);
                        if (NO.GetY() > 600)
                            NO.SetY(600);
                        if (SE.GetX() > 700)
                            SE.SetX(700);
                        if (SE.GetY() > 600)
                            SE.SetY(600);
                        if (NO.GetX() != SE.GetX() && NO.GetY() != SE.GetY())
                        {
                            Sectors s = new Sectors(NO, SE, tr[0]);
                            lista.Add(s);
                        }
                    }
                }
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

        //Método que guarda la lista de aviones actual en un fichero .txt
        public void GuardarLista(string dir)
        {
            StreamWriter A = new StreamWriter(dir);
            A.WriteLine("{0}", this.lista.Count);

            for (int i = 0; i < this.lista.Count; i++)
            {
                Sectors sector = this.lista[i];
                string[] tr = sector.GetNombre().Split();
                int a = 0;
                while (a < tr.Length - 1)
                {
                    tr[0] = tr[0] + tr[a + 1];
                    a++;
                }
                A.WriteLine("{0} {1} {2} {3} {4}",tr[0], sector.GetNO().GetX(), sector.GetNO().GetY(), sector.GetSE().GetX(), sector.GetSE().GetY());
            }
            A.Close();
        }

        //Método para añadir un sector a la lista de sectores
        public void AñadirSector(Sectors s)
        {
            this.lista.Add(s);
        }

        //Método que devuelve el número de aviones que hay en la lista
        public int GetNum()
        {
            return this.lista.Count;
        }

        //Método que devuelve el Sector que hay en la posición de la lista que recibe como parámetro
        public Sectors ConsultarLista(int i)
        {
            if (i < lista.Count)
                return lista[i];

            else
                return null;
        }

        //Método que devuelve la copia de una lista de sectores
        public ListaSectores copia()
        {
            ListaSectores sectores2 = new ListaSectores();
            for (int i = 0; i < this.lista.Count; i++)
            {
                
                Sectors s = new Sectors(lista[i]);
                sectores2.AñadirSector(s);
            }
            return sectores2;
        }

        //Método que permite eliminar un sector de la lista en una posición que recibe como parámetro
        public void eliminar(int a)
        {
            lista.RemoveAt(a);
        }

        //Método que permite borrar toda la lista
        public void Borrarlista()
        {
            lista.Clear();
        }
    }
}
