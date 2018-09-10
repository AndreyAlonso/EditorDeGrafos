using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorGrafos
{
    [Serializable]
    class GrafoNoDirigido:Grafo
    {
        #region Constructor
        public GrafoNoDirigido(Grafo g)
        {
            foreach (NodoP n in g)
            {
                this.Add(n);
            }
            actualizaPropiedades(g);
        }
        public void actualizaPropiedades(Grafo g)
        {
            this.penN = new Pen(g.cNodo);
            this.penA = new Pen(g.cArista);
            this.width = g.width;
            this.widthA = g.widthA;
            this.font = g.font;
            this.brushN = new SolidBrush(g.cRelleno);
            //  this.brushF = new SolidBrush(g.)
        }
        #endregion
        #region complemento

        public override Grafo complemento(Graphics g)
        {
            NodoP nn;
            Arista nnr;
            Grafo nuevo = new Grafo();
            foreach (NodoP np in this)
            {
                nn = new NodoP(np.nombre, np.centro);
                nuevo.Add(nn);
            }
            nuevo = new GrafoNoDirigido(nuevo);

            foreach (NodoP aux1 in this) // Ciclo que recorre los nodos del grafo
            {
                if (aux1.aristas.Count == 0) // si el nodo no tiene aristas
                {
                    foreach (NodoP aux2 in nuevo) // Ciclo que recorre los nodos del grafo "copia"
                    {
                        if (aux1.nombre != aux2.nombre) // Condición para que el nodo no apunte a si mismo
                        {
                            nnr = new Arista(0);
                            nnr.origen = nuevo.Find(x => x.nombre.Equals(aux1.nombre));
                            nnr.destino = aux2;
                            nuevo.Find(x => x.nombre.Equals(aux1.nombre)).aristas.Add(nnr);
                        }
                    }
                }

                else // Si el nodo ya tiene Aristas
                {
                    foreach (NodoP aux2 in nuevo) // Ciclo que recorre los nodos 
                    {
                        if (aux1.nombre != aux2.nombre) // Compara que el nodo no se apunte a si mismo
                        {
                            Arista r = new Arista(0);
                            r = aux1.aristas.Find(x => x.destino.nombre.Equals(aux2.nombre));
                            if (r == null)
                            {
                                nnr = new Arista(0);
                                nnr.origen = nuevo.Find(x => x.nombre.Equals(aux1.nombre));
                                nnr.destino = aux2;
                                if (nnr != null)
                                    nuevo.Find(x => x.nombre.Equals(aux1.nombre)).aristas.Add(nnr);
                            }
                        }
                    }
                }
            }

            //base.complemento(g);

            return nuevo;
        }
        #endregion
        #region nPartita
        public override List<List<int>> nPartita(Graphics g)
        {
            bool band = false;
            bool band2 = false;
            bool band3 = false;
            /*Hacer una lista de arreglos */
            List<int> lista;
            List<List<int>> partitas = new List<List<int>>();
            /*Crear metodo para saber si existe el elemento */

            lista = new List<int>();
            foreach (NodoP np in this)
            {
                

                foreach(Arista nr in np.aristas)
                {
                    lista = new List<int>();
                    foreach (NodoP np2 in this)
                    {
                        if(nr.destino.nombre == np2.nombre)
                        {
                            band2 = true;
                        }
                        else
                        {

                            band = encuentraLista(lista, np2.nombre);
                            if(band == false)
                            {
                                band3 = buscaRelacion(np, np2.nombre,this,lista);
                                if(band3 == false)
                                {
                                    band2 = encuentraNombre(partitas,np2.nombre);
                                    if(band2 == false)
                                    {
                                        lista.Add(np2.nombre);
                                    }
                                        
                                        
                                }
                                   
                                    
                            }
                               
                        }
                    }

                }
                if (lista.Count > 0)
                {
                    band2 = encuentraNombre(partitas, np.nombre);
                    if(band2 == false)
                        partitas.Add(lista);
                }
                    
            }
            return partitas;

        }
        public bool buscaRelacion(NodoP np,int nombre,Grafo g, List<int> lista)
        {
            bool existe = false;
            foreach(NodoP aux in g)
            {
                foreach(int l in lista)
                {
                    if(l == aux.nombre)
                    {
                        foreach(Arista nr in aux.aristas)
                        {
                            if(nr.destino.nombre == nombre)
                            {
                                existe = true;
                            }
                        }
                    }
                }
            }     
            /* 
            foreach(Arista nr in np.aristas)
            {
                if(nr.destino.nombre == nombre)
                {
                    existe = true;
                }
            }
            */
            return existe;
        }
        public bool encuentraLista(List<int> lista, int nombre)
        {
            bool existe = false;
            foreach(int aux in lista)
            {
                if(aux == nombre)
                {
                    existe = true;
                }
            }
            return existe;
        }
        public bool encuentraNombre(List<List<int>> partitas, int nombre)
        {
            bool existe = false;
            foreach(List<int> aux in partitas)
            {
                foreach(int aux2 in aux)
                {
                   if(aux2 == nombre)
                    {
                        existe = true;
                    }
                }
            }
            return existe;
        }
        #endregion
        #region  GrafosEspeciales
        public override void grafoKn(int nodos, Graphics g)
        {
            double posx, posy;
            double centrox, centroy, distancia, angulo, angulo2;
            int nomb = 1, a;
            Arista aux;
            Point pos = new Point(200, 200);
            centrox = 400;
            centroy = 400;
            distancia = 220;
            angulo = 10;
            angulo2 = (double)(360 / (double)nodos);

            for (a = 0; a < nodos; a++)
            {
                if (a == 0){
                    posx  = (int)(centrox - (distancia * Math.Cos((90 * Math.PI) / 180.0)));
                    posy  = (int)(centroy - (distancia * Math.Sin((90 * Math.PI) / 180.0)));
                    pos.X = (int)posx;
                    pos.Y = (int)posy;
                    angulo = 90;
                }
                else{

                    angulo = (float)(angulo + angulo2);
                    posx = (int)(centrox - distancia * Math.Cos((angulo * Math.PI) / 180.0));
                    posy = (int)(centroy - distancia * Math.Sin((angulo * Math.PI) / 180.0));
                    pos.X= (int) posx;
                    pos.Y = (int)posy;
                }
                this.Add(new NodoP(nomb, pos));
                nomb++;
                if (nomb > 27)
                {
                    this.edoNom = true;
                }
            }
            foreach (NodoP np in this)
            {
                foreach (NodoP np2 in this)
                {
                    if (np != np2)
                    {
                        aux = new Arista(0);
                        aux.origen = np;
                        aux.destino = np2;
                        np.aristas.Add(aux);
                    }
                }
            }
            //this.ImprimirGrafo(g);
        }
        public override void grafoCn(int nodos, Graphics g)
        {
            double posx, posy;
            double centrox, centroy, distancia, angulo, angulo2;
            int nomb = 1,a;
            Arista aux;
            Point pos = new Point(200, 200);
            centrox = 400;
            centroy = 400;
            distancia = 220;
            angulo = 10;
            angulo2 = (double)(360 / (double)nodos);

            for (a = 0; a < nodos; a++)
            {
                if (a == 0)
                {
                    posx = (int)(centrox - (distancia * Math.Cos((90 * Math.PI) / 180.0)));
                    posy = (int)(centroy - (distancia * Math.Sin((90 * Math.PI) / 180.0)));
                    pos.X = (int)posx;
                    pos.Y = (int)posy;
                    angulo = 90;
                }
                else
                {

                    angulo = (double)(angulo + angulo2);
                    posx = (int)(centrox - distancia * Math.Cos((angulo * Math.PI) / 180.0));
                    posy = (int)(centroy - distancia * Math.Sin((angulo * Math.PI) / 180.0));
                    pos.X = (int)posx;
                    pos.Y = (int)posy;
                }
                this.Add(new NodoP(nomb, pos));
                nomb++;
                if (nomb > 27){
                    this.edoNom = true;
                }
                if ( a > 0)
                {
                    aux = new Arista(0);
                    aux.origen = this[a-1];
                    aux.destino = this[a];
                    this[a-1].aristas.Add(aux);
                    aux = new Arista(0);
                    aux.origen = this[a];
                    aux.destino = this[a - 1];
                    this[a].aristas.Add(aux);
                }
            }
            aux = new Arista(0);
            aux.origen = this[a-1];
            aux.destino = this[0];
            this[a-1].aristas.Add(aux);
            aux = new Arista(0);
            aux.origen = this[0];
            aux.destino = this[a-1];
            this[0].aristas.Add(aux);
           // this.ImprimirGrafo(g);

        }
        public override void grafoWn(int nodos, Graphics g)
        {
            double posx, posy;
            double centrox, centroy, distancia, angulo, angulo2;
            int nomb = 1, a;
            Arista aux;
            Point pos = new Point(200, 200);
            centrox = 400;
            centroy = 400;
            distancia = 220;
            angulo = 10;
            angulo2 = (double)(360 / (double)nodos);
            for (a = 0; a < nodos; a++)
            {
                if (a == 0)
                {
                    posx = (double)(centrox - (distancia * Math.Cos((90 * Math.PI) / 180.0)));
                    posy = (double)(centroy - (distancia * Math.Sin((90 * Math.PI) / 180.0)));
                    pos.X = (int)posx;
                    pos.Y = (int)posy;
                    angulo = 90;
                }
                else
                {

                    angulo = angulo + angulo2;
                    posx = (double)(centrox - distancia * Math.Cos((angulo * Math.PI) / 180.0));
                    posy = (double)(centroy - distancia * Math.Sin((angulo * Math.PI) / 180.0));
                    pos.X = (int)posx;
                    pos.Y = (int)posy;
                }
                this.Add(new NodoP(nomb, pos));
                nomb++;
                if (nomb >= 27)
                {
                    this.edoNom = true;
                }
                if (a > 0)
                {
                    aux = new Arista(0);
                    aux.origen = this[a - 1];
                    aux.destino = this[a];
                    this[a - 1].aristas.Add(aux);
                    aux = new Arista(0);
                    aux.origen = this[a];
                    aux.destino = this[a - 1];
                    this[a].aristas.Add(aux);

                }
            }
            aux = new Arista(0);
            aux.origen = this[a - 1];
            aux.destino = this[0];
            this[a - 1].aristas.Add(aux);
            aux = new Arista(0);
            aux.origen = this[0];
            aux.destino = this[a - 1];
            this[0].aristas.Add(aux);
            
            Point center = new Point((int)centrox,(int) centroy);
            this.Add(new NodoP(nomb, center));
            a++;
           
            foreach(NodoP np in this)
            {
                if(np != this[a-1])
                {
                    aux = new Arista(0);
                    aux.origen = np;
                    aux.destino = this[a - 1];
                    np.aristas.Add(aux);

                    aux = new Arista(0);
                    aux.origen = this[a - 1];
                    aux.destino = np;
                    this[a-1].aristas.Add(aux);

                }
                
            }
            //this.ImprimirGrafo(g);
        }
        #endregion
    }
}
