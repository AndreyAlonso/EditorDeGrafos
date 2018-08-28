using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorGrafos
{
    [Serializable]
    class NodoP
    {
        private List<Arista> ARISTAS;
        public List<Arista> aristas { set { ARISTAS = value; } get { return ARISTAS; } }
        private int NOMBRE;
        public int nombre { set { NOMBRE = value; } get { return NOMBRE; } }
        private Point CENTRO;
        public Point centro { set { CENTRO = value; } get { return CENTRO; } }    

        public NodoP(int n, Point p, Propiedad propiedades)
        {
            ARISTAS = new List<Arista>();
            NOMBRE = n;
            CENTRO = p;
        }
    }
}
