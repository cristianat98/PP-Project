using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesProyecto
{
    public class Coordenades
    {
        //Variables de la clase Coordenades
        public double X;
        public double Y;

        //Constructor que inicializa la clase a partir de los puntos de la coordenada
        public Coordenades(double X, double Y)
        {
            this.X = X;
            this.Y = Y;
        }

        //Constructor que inicializa la clase a partir de la coordenada
        public Coordenades(Coordenades c)
        {
            this.X = c.X;
            this.Y = c.Y;
        }

        //Método para asignar el valor de X que recibe como parámetro
        public void SetX(double X)
        {
            this.X = X;
        }

        //Método que asigna el valor de Y que recibe como parámetro
        public void SetY(double Y)
        {
            this.Y = Y;
        }

        //Método que devuelve el valor de la X
        public double GetX()
        {
            return this.X;
        }

        //Método que devuelve el valor de la Y
        public double GetY()
        {
            return this.Y;
        }

        //Método que permite calcular la distancia que recorre un avión
        public double Distancia(Coordenades Z)
        { 
            double dis = Math.Sqrt((this.X - Z.X) * (this.X - Z.X) + (this.Y - Z.Y) * (this.Y - Z.Y));
            return dis;
        }

        //Método que nos devuelve la distancia entre dos aviones
        public double DistanciaAviones(Avio A, Avio B)
        {
            double disaviones = Math.Sqrt((A.A.X - B.A.X) * (A.A.X - B.A.X) + (A.A.Y - B.A.Y) * (A.A.Y - B.A.Y));
            return disaviones;
        }
    }
}
