using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesProyecto
{
    public class Avio
    {
        //Atributos de la clase Avio//
        public Coordenades A; 
        public Coordenades D; 
        public Coordenades O;
        public string ID;
        public string compañia;
        public double velocidad;
        public string corigen;
        public string cdestino;
        public bool mover;

        //Constructor que inicializa la clase a partir de todas sus variables
        public Avio(Coordenades A, Coordenades O, Coordenades D, string id, string c, double v, List<Ciudades> lc)
        {
            this.A = A;
            this.O = O;
            this.D = D;
            this.velocidad = v;
            this.ID = id;
            this.compañia = c;
            this.mover = true;
            int i = 0;
            int suma = 0;
            while (i < lc.Count && suma < 2)
            {
                if (lc[i].GetCoordenadas().GetX() == O.GetX() && lc[i].GetCoordenadas().GetY() == O.GetY())
                {
                    this.corigen = lc[i].GetNombre();
                    suma++;
                }

                if (lc[i].GetCoordenadas().GetX() == D.GetX() && lc[i].GetCoordenadas().GetY() == D.GetY())
                {
                    this.cdestino = lc[i].GetNombre();
                    suma++;
                }
                    i++;
            }
            if (this.corigen == null)
                this.corigen = "No disponible";
            if (this.cdestino == null)
                this.cdestino = "No disponible";
        }

        //Constructor que inicializa el avión conociendo las ciudades, la velocidad, el nombre y compañía
        public Avio(string id, string com, string co, string cd, double v, Coordenades or, Coordenades de)
        {
            this.ID = id;
            this.compañia = com;
            this.corigen = co;
            this.cdestino = cd;
            this.velocidad = v;
            this.O = or;
            this.A = new Coordenades(or);
            this.D = de;
            this.mover = true;
        }

        //Constructor que inicializa la clase a partir de un avión
        public Avio(Avio av)
        {
            this.O = new Coordenades(av.O);
            this.A = new Coordenades(av.A);
            this.D = new Coordenades(av.D);
            this.velocidad = av.velocidad;
            this.compañia = av.compañia;
            this.ID = av.ID;
            this.corigen = av.corigen;
            this.cdestino = av.cdestino;
            this.mover = av.GetMover();
        }

        //Constructor que inicializa la clase vacía
        public Avio()
        {
            // TODO: Complete member initialization
        }

        //Método que realiza una copia de un avión
        public Avio Copia()
        {
            Avio copia = new Avio();
            copia.A = this.A;
            copia.O = this.O;
            copia.D = this.D;
            copia.velocidad = this.velocidad;
            copia.ID = this.ID;
            copia.compañia = this.compañia;
            copia.corigen = this.corigen;
            copia.cdestino = this.cdestino;
            copia.mover = this.mover;

            return copia;
        }

        //Método que asigna un valor a la coordenada O  
        public void SetO(Coordenades O)
        {
            this.O = O;
        }
        
        //Método que asigna un valor a la coordenada D
        public void SetD(Coordenades D)
        {
            this.D = D;
        }

        //Método que asigna un valor a la coordenada A
        public void SetA(Coordenades A)
        {
            this.A = A;
        }

        //Método que asigna un valor a la ciudad origen
        public void SetCOrigen(string co)
        {
            this.corigen = co;
        }

        //Metodo que asgina un valor a la ciudad destino
        public void SetCDestino(string cd)
        {
            this.cdestino = cd;
        }

        //Método que asigna un valor a la variable ID 
        public void SetID(string id)
        {
            this.ID = id;
        }

        //Método que asigna un valor a la variable compañia
        public void SetCompañia(string c)
        {
            this.compañia = c;
        }

        //Método que asiga un valor a la variable velocidad
        public void SetVelocidad(double v)
        {
            this.velocidad = v;
        }

        //Método que cambia el valor del Mover
        public void SetMover(bool mov)
        {
            this.mover = mov;
        }

        //Método que devuelve el valor de las coordenadas de Origen
        public Coordenades GetO()
        {
            return this.O;
        }

        //Método que devuelve el valor de las coordenadas de Destino
        public Coordenades GetD()
        {
            return this.D;
        }

        //Método que devuelve el valor de las coordenadas Actuales
        public Coordenades GetA()
        {
            return this.A;
        }

        //Método que devuelve el valor de ID
        public string GetID()
        {
            return this.ID;
        }

        //Método que devuelve el valor de la compañía
        public string GetCompañia()
        {
            return this.compañia;
        }

        //Método que devuelve el valor de la velocidad
        public double GetVelocidad()
        {
            return this.velocidad;
        }

        //Método que devuelve la ciudad origen del avión
        public string GetCOrigen()
        {
            return this.corigen;
        }

        //Método que devuelve la ciudad destino del avión
        public string GetCDestino()
        {
            return this.cdestino;
        }

        //Método que devuelve el valor del Mover
        public bool GetMover()
        {
            return this.mover;
        }

        //Método que nos devuelve la distancia al destino
        public double DistanciaDestino()
        {
            return this.A.Distancia(this.D);
            
        }

        //Método para mover el avión 
        public void MoverAvion(double tiempo)
        {
            double D = tiempo * (this.velocidad / 60);
            double resto = this.A.Distancia(this.D);

            if (resto < D)
            {
                //El vuelo ha llegado a su destino
                this.A = this.D;
            }

            else
            {
                //Calculamos a partir de las razones trigonométricas
                double L = this.O.Distancia(this.D);
                double Coseno = (this.D.GetX() - this.O.GetX()) / L;
                double Seno = (this.D.GetY() - this.O.GetY()) / L;

                //Calculamos la nueva posición del avion
                this.A.SetX(this.A.GetX() + D * Coseno);
                this.A.SetY(this.A.GetY() + D * Seno);
            }
        }

        //Método que coloca el vuelo en la posición de origen
        public void Reiniciar()
        {
            this.A = new Coordenades(this.O);
        }
    }
}
