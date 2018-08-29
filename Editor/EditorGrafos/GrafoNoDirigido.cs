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
            foreach(NodoP np in this)
            {
                nn = new NodoP(np.nombre, np.centro);
                nuevo.Add(nn);
            }
            nuevo = new GrafoNoDirigido(nuevo);

            foreach(NodoP aux1 in this) // Ciclo que recorre los nodos del grafo
            {
                if(aux1.aristas.Count == 0) // si el nodo no tiene aristas
                {
                    foreach(NodoP aux2 in nuevo) // Ciclo que recorre los nodos del grafo "copia"
                    {
                        if(aux1.nombre != aux2.nombre) // Condición para que el nodo no apunte a si mismo
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
                    foreach(NodoP aux2 in nuevo) // Ciclo que recorre los nodos 
                    {
                        if(aux1.nombre != aux2.nombre) // Compara que el nodo no se apunte a si mismo
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
                            else
                            {
                                continue;
                            }
                                                          
                                
                            }
                            
                        }
                    }
                }

            base.complemento(g);

            return nuevo;
        }
        #endregion
    }
}
