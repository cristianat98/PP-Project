using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ClasesProyecto
{
    public class Sectors
    {
        //Variables de la clase Sectors
        Coordenades NO;
        Coordenades SE;
        int congestion;
        string nombre;

        //Constructor que lo inicializa a partir de las dos coordenadas del sector y el nombre
        public Sectors(Coordenades NO, Coordenades SE, string nombre)
        {
            this.NO = NO;
            this.SE = SE;
            this.nombre = nombre;
            this.congestion = Convert.ToInt32((SE.GetX() - NO.GetX()) * (SE.GetY() - NO.GetY()) / 1500);
        }

        //Constructor que inicializa la clase a partir de un sector
        public Sectors(Sectors s)
        {
            this.NO = new Coordenades(s.NO);
            this.SE = new Coordenades(s.SE);
            this.nombre = s.nombre;
            this.congestion = s.congestion;
        }

        //Constructor que inicializa la clase en blanco
        public Sectors()
        {
        }

        //Método que realiza una copia de un sector
        public Sectors copia()
        {
            Sectors copia = new Sectors();
            copia.NO = this.NO; 
            copia.SE = this.SE;
            copia.nombre = this.nombre;
            copia.congestion = this.congestion;

            return copia;
        }

        //Método que asigna valores a la coordenada NO que recibe como parámetro
        public void SetNO(Coordenades NO)
        {
            this.NO = NO;
            this.congestion = Convert.ToInt32((SE.GetX() - NO.GetX()) * (SE.GetY() - NO.GetY()) / 1000);
        }

        //Método que asigna valores a la coordenada SE que recibe como parámetro
        public void SetSE(Coordenades SE)
        {
            this.SE = SE;
            this.congestion = Convert.ToInt32((SE.GetX() - NO.GetX()) * (SE.GetY() - NO.GetY()) / 1000);
        }

        //Método que asigna un nombre al sector
        public void SetNombre(string nom)
        {
            this.nombre = nom;
        }

        //Método que te devuelve la coordenada NO
        public Coordenades GetNO()
        {
            return this.NO;
        }

        //Método que te devuelve la coordenada SE
        public Coordenades GetSE()
        {
            return this.SE;
        }

        //Método que devuelve el valor de la congestion
        public int GetCongestion()
        {
            return this.congestion;
        }

        //Método que devuelve el nombre del sector
        public string GetNombre()
        {
            return this.nombre;
        }

        //Método que recibe como parámetro las coordenadas del avión y comprueba si está dentro del sector o no
        public int ComprobarSector(double a, double b)
        {
            if (NO.X <= a && NO.Y <= b && SE.X >= a && SE.Y >= b)
                return 1;

            else
                return 0;

        }
    }
}
