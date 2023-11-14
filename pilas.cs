using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_2_Pilas
{
    internal class pilas
    {
        #region atributos 
        protected const int max = 5;
        string[] elementos;
        int tope;
        #endregion

        #region constructores
        public pilas()
        {
            tope = -1;
            elementos = new string[max];
        }
        #endregion

        #region metodos
        private bool vacio()
        {
            return (tope == -1);
        }
        private bool lleno()
        {
            return (tope == max - 1);
        }

        public void push(string dato)
        {
            if (lleno())
            {
            }
            else
            {
                tope++;
                elementos[tope] = dato;
            }
        }

        public string pop()
        {
            if (vacio())
            {
                return (null);
            }
            else
            {
                string D;
                D = elementos[tope];
                tope--;
                return (D);
            }
        }

        public string popTope()
        {
            if (vacio())
            {
                return (null);
            }
            else
            {
                string D;
                D = elementos[tope];
                return (D);
            }
        }

        public void imprimir()
        {
            if (vacio() == true)
            {
            }
            else
            {
                string d;
                pilas Pa = new pilas();

                while (!vacio())
                {
                    d = pop();
                    Console.WriteLine(d);
                    Pa.push(d);
                }

                while (!Pa.vacio())
                {
                    push(Pa.pop());
                }
            }
        }

        //te devuelve el tamano de la pila en ese momento

        public int count()
        {
            return tope + 1;
        }

        public void clear()
        {
            tope = -1;
        }

        #endregion
    }
}
