﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorGrafos
{
    [Serializable]
    class Arista
    {
        private int PESO;
        public int peso { set { PESO = value; } get { return PESO; } }
        private NodoP DESTINO;
        public NodoP destino { set { DESTINO = value; } get { return DESTINO; } }
        private NodoP ORIGEN;
        public NodoP origen { set { ORIGEN = value; } get { return ORIGEN; } }


        public Arista(int p)
        {
            PESO = p;
        }
    }
}
