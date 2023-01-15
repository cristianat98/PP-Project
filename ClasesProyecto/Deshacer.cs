using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesProyecto
{
    public class Deshacer
    {
        //Variables de la clase Deshacer
        Stack<LlistaAvions> pila = new Stack<LlistaAvions>();
        Stack<ListaSectores> pila2 = new Stack<ListaSectores>();

        //Método que guarda una copia de la lista de aviones que recibe como parámetro
        public void GuardarCopia(LlistaAvions lista)
        {
            pila.Push(lista);
        }

        //Método que guarda una copia de la lista de sectores que recibe como parámetro
        public void GuardarCopiaSec(ListaSectores lista)
        {
            pila2.Push(lista);
        }

        //Método que devuelve la última lista de aviones que ha entrado en la pila y la borra de la pila
        public LlistaAvions RecuperarCopia()
        {
            return pila.Pop();
        }

        //Método que devuelve la última lista de sectores que ha entrado en la pila y la borra de la pila
        public ListaSectores RecuperarCopiaSec()
        {
            return pila2.Pop();
        }

        //Método que devuelve el número de listas de aviones que hay en la pila
        public int Copias()
        {
            return pila.Count;
        }

        //Método que devuelve el número de listas de sectores que hay en la pila
        public int CopiasSec()
        {
            return pila2.Count;
        }
        
        //Método que borra todas las listas de aviones que hay en la pila
        public void Reiniciar()
        {
            pila.Clear();
        }

        //Método que borra todas las listas de sectores que hay en la pila
        public void ReiniciarSec()
        {
            pila2.Clear();
        }
    }
}
