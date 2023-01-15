using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ClasesProyecto
{
    public class Ciudades
    {
        //Variables de la clase Ciudades
        public string nombre;
        public double X;
        public double Y;

        //Método que permite asignar un valor al nombre
        public void SetNombre(string nom)
        {
            this.nombre = nom;
        }

        //Método que permite asignar una coordenadas a las variables X e Y
        public void SetCordenadas(int a, int b)
        {
            this.X = a;
            this.Y = b;
        }

        //Método que devuelve el nombre de la ciudad
        public string GetNombre()
        {
            return this.nombre;
        }

        //Método que devuelve las coordenadas de la ciudad
        public Coordenades GetCoordenadas()
        {
            return new Coordenades(this.X, this.Y);
        }
    }
}
