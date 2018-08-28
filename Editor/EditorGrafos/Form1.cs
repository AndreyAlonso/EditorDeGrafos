using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditorGrafos
{
    public partial class EditorGrafo : Form
    {
        #region Inicialziacion

        Grafo grafo;
        NodoP nodoP, nodoAux;
        Arista nodoR;
        Graphics g;
        int opcion;
        Bitmap bmp1;
        bool band, bandF, bandA, bandI;
        Point p1, p2;
        Random rnd = new Random();
        Configuracion config;
        AdjustableArrowCap arrow;

        #endregion

        #region Principal

        public EditorGrafo()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            grafo = new Grafo();
            opcion = 0;
            g = CreateGraphics();
            bmp1 = new Bitmap(ClientSize.Width, ClientSize.Height);
            band = false;
            bandI = false;
            bandF = false;
            arrow = new AdjustableArrowCap(5, 5);

            CambiaBotones(false);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics ga = CreateGraphics();
            ga = Graphics.FromImage(bmp1);
            ga.Clear(BackColor);
            
            if (bandF || band)
            {
                switch (opcion)
                {
                    case 1: // Crea Nodo
                        
                        ga.FillEllipse(grafo.brushN, p1.X - grafo.radio, p1.Y - grafo.radio, grafo.radio * 2, grafo.radio * 2);
                        ga.DrawEllipse(grafo.penN, p1.X - grafo.radio + (grafo.penN.Width /2), p1.Y - grafo.radio + (grafo.penN.Width / 2), grafo.radio * 2 - (grafo.penN.Width / 2), grafo.radio * 2 - (grafo.penN.Width / 2));
                        if (grafo.numN >= 28 || grafo.edoNom || grafo.nomb >= 28)
                            ga.DrawString(nodoP.nombre.ToString(), grafo.font, grafo.brushF, p1.X - 6, p1.Y - 6);
                        else
                            ga.DrawString(((char)(nodoP.nombre + 64)).ToString(), grafo.font, grafo.brushF, p1.X - 6, p1.Y - 6);
                    break;

                    case 2:
                        if (bandF)
                        {
                            if (nodoP.Equals(nodoAux))
                                ga.DrawBezier(grafo.penA, nodoP.centro.X - 15, nodoP.centro.Y - 15, nodoP.centro.X - 20, nodoP.centro.Y - 60, nodoP.centro.X + 20, nodoP.centro.Y - 60, nodoP.centro.X + 15, nodoP.centro.Y - 15);
                            else
                                ga.DrawLine(grafo.penA, grafo.BuscaInterseccion(nodoP.centro, nodoAux.centro), grafo.BuscaInterseccion(nodoAux.centro, nodoP.centro));
                        }
                        if (band)
                            ga.DrawLine(grafo.penA, grafo.BuscaInterseccion(nodoP.centro, p2), p2);

                    break;
                    case 9:
                        if (bandF)
                        {
                            if (nodoP.Equals(nodoAux)) // Oreja
                                ga.DrawBezier(grafo.penA, nodoP.centro.X - 15, nodoP.centro.Y - 15, nodoP.centro.X - 20, nodoP.centro.Y - 60, nodoP.centro.X + 20, nodoP.centro.Y - 60, nodoP.centro.X + 15, nodoP.centro.Y - 15);
                            else
                                ga.DrawLine(grafo.penA, grafo.BuscaInterseccion(nodoP.centro, nodoAux.centro), grafo.BuscaInterseccion(nodoAux.centro, nodoP.centro));
                        }
                        if(band)
                            ga.DrawLine(grafo.penA, grafo.BuscaInterseccion(nodoP.centro, p2), p2);
                        
                    break;
                }
                bandF = false;
            }
                
            if(bandI)
            {
                ga.Clear(BackColor);
                grafo.ImprimirGrafo(ga);
                bandI = false;
            }
                
            if(opcion == 6 || opcion == 7)
            {
                ga.Clear(BackColor);
                grafo.Clear();
                grafo.numN = 1;
                grafo.edoNom = false;
                if (opcion == 7)
                {
                    grafo = new Grafo();
                    CambiaBotones(false);
                }
            }
            if(opcion != 6)
                if(opcion != 7)
                    grafo.ImprimirGrafo(ga);
            g.DrawImage(bmp1, 0, 0);
        }

        #endregion 

        #region Mouse_Events

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            p1 = e.Location;
            switch(opcion)
            {
                case 1:
                    if(grafo.numN == 1)
                        CambiaBotones(true);
                    grafo.numN++;
                    if(grafo.Count > 0)
                        nodoP = new NodoP(grafo.Count-1, p1);
                    else
                        nodoP = new NodoP(grafo.numN - 1, p1);
                    grafo.Add(nodoP);
                    grafo.nomb = nodoP.nombre;
                    nodoP.nombre = grafo.Count;
                    band = false;
                    bandF = true;
                    if (grafo.numN == 28 && grafo.Count == 28)
                    {
                        bandI = true;
                        grafo.edoNom = true;
                    }
                    else
                        bandI = false;
                    Form1_Paint(this, null);
                    break;

                case 2:
                case 9:
                    nodoP = grafo.BuscaNodo(p1);
                    if (nodoP != null)
                    {
                        band = true;
                        bandA = true;
                    }
                    else
                    {
                        band = false;
                    }
                    break;

                case 3:
                    nodoP = grafo.BuscaNodo(p1);
                    if (nodoP != null)
                        bandA = true;
                    else band = false;
                    break;

                case 8:
                    p1 = e.Location;
                break;
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button.Equals(MouseButtons.Left) && (opcion == 2 || opcion == 9) && bandA)
            {
                p2 = e.Location;
                Form1_Paint(this, null);
            }

            if (e.Button.Equals(MouseButtons.Left) && opcion == 3 && bandA)
            {
                band = false;
                bandF = false;
                bandI = true;
                nodoP.centro = e.Location;
                Form1_Paint(this, null);
            }

            if(e.Button.Equals(MouseButtons.Left) && opcion == 8)
            {
                int distx, disty;

                distx = e.Location.X - p1.X;
                disty = e.Location.Y - p1.Y;
                grafo.MueveGrafo(distx, disty);
                p1 = e.Location;

                bandI = true;
                band = false;
                bandF = false;
                bandA = false;
                Form1_Paint(this, null);
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (bandA && band && (opcion == 2 || opcion == 9))
            { 
                p2 = e.Location;
                nodoAux = grafo.BuscaNodo(p2);
                if(nodoAux != null)
                {
                    if (opcion == 2)
                    {
                        AristaDirigida.Enabled = false;
                        grafo = new GrafoNoDirigido(grafo);
                        nodoR = new Arista(rnd.Next(100));
                        nodoR.destino = nodoAux;
                        nodoR.origen = nodoP;
                        nodoP.aristas.Add(nodoR);


                        nodoR = new Arista(rnd.Next(100));

                        nodoR.destino = nodoP;
                        nodoR.origen = nodoAux;

                        nodoAux.aristas.Add(nodoR);
                    }
                        
                    else if(opcion == 9)
                    {
                        AristaNoDirigida.Enabled = false;
                        grafo = new GrafoDirigido(grafo);
                        grafo.penA.CustomEndCap = arrow;

                        nodoR = new Arista(rnd.Next(100));
                        nodoR.destino = nodoAux;
                        nodoR.origen = nodoP;

                        nodoP.aristas.Add(nodoR);
                       
                        
                        
                       

                    }
                    
                    bandF = true;
                    bandA = false;
                }
                else
                {
                    bandF = false;
                }
            }
           
            if(opcion == 4)
            {
                grafo.BorrarNodo(e.Location);
                bandF = false;
            }

            if(opcion == 5)
            {
                grafo.BorrarArista(e.Location);
                bandF = false;
            }

            band = false;
            bandA = false;
            Form1_Paint(this, null);
        }

        #endregion

        #region Manejadores_Clicked

        private void Toolbar_Clicked(object sender, ToolStripItemClickedEventArgs e)
        {
            band = false;
            bandA = false;
            bandF = false;
            bandI = false;

            switch(e.ClickedItem.AccessibleName)
            {
                case "CrearNodo":
                case "MoverNodo":
                case "BorrarNodo":
                    
                    Nodo_Click(this, e);
                   
                break;

                case "AristaDirigida":
                case "AristaNoDirigida":
                case "BorrarArista":
                    Arista_Click(this, e);
                break;

                case "Save":
                case "Open":
                case "Imprimir":
                    Archivo_Click(this, e);
                break;

                case "MoverGrafo":
                case "BorrarGrafo":
                case "EliminarGrafo":
                    Grafo_Click(this, e);
                break;

                case "Cambia":
                case "Preferencias":
                    Configuracion_Clicked(this, e);
                break;
            }
        }
        
        private void Configuracion_Clicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch(e.ClickedItem.AccessibleName)
            {
                case "Preferencias":
                    config = new Configuracion(grafo.width, grafo.widthA, grafo.radio, grafo.colorFuente, grafo.cArista, grafo.cRelleno, grafo.cNodo, grafo.font);
                    if (config.ShowDialog() == DialogResult.OK)
                    {
                        grafo.font = config.font;
                        grafo.penN = config.penN;
                        grafo.penA = config.penA;
                        grafo.brushN = config.brushN;
                        grafo.brushF = config.brushF;
                        grafo.radio = config.radio;

                        grafo.cNodo = grafo.penN.Color;
                        grafo.width = grafo.penN.Width;
                        grafo.cRelleno = grafo.brushN.Color;

                        grafo.cArista = grafo.penA.Color;
                        grafo.widthA = grafo.penA.Width;

                        grafo.colorFuente = grafo.brushF.Color;
                        grafo.nameF = grafo.font.Name;
                        grafo.sizeF = grafo.font.Size;
                        grafo.styleF = grafo.font.Style;

                        if (AristaDirigida.Enabled && !AristaNoDirigida.Enabled)
                        {
                            grafo.penA.CustomEndCap = arrow;
                            grafo = new GrafoDirigido(grafo);
                            actualizaPropiedades();
                            
                            

                        }
                            


                        bandF = false;
                        band = false;
                        bandA = false;
                        bandI = true;
                        Form1_Paint(this, null);
                    }
                    config.Dispose();
                    break;

                case "Cambia":
                    CambiaNombre();
                    break;
            }
        }

        private void Grafo_Click(object sender, ToolStripItemClickedEventArgs e)
        {
            switch(e.ClickedItem.AccessibleName)
            {
                case "MoverGrafo":
                    opcion = 8;
                break;

                case "BorrarGrafo":
                    opcion = 6;
                break;

                case "EliminarGrafo":
                    opcion = 7;
                break;
            }
        }

        private void Nodo_Click(object sender, ToolStripItemClickedEventArgs e)
        {
            band = false;
            bandA = false;
            bandF = false;
            bandI = false;

            switch (e.ClickedItem.AccessibleName)
            {
                case "CrearNodo":
                    opcion = 1;
                    break;

                case "MoverNodo":
                    opcion = 3;
                break;

                case "BorrarNodo":
                    opcion = 4;
                break;
            }
        }

        

        private void metodosAdicionales(object sender, ToolStripItemClickedEventArgs e)
        {
            switch(e.ClickedItem.AccessibleName)
            {
                case "complemento":
                    if(AristaNoDirigida.Enabled == true  && AristaDirigida.Enabled == true)
                    {
                        grafo = new GrafoNoDirigido(grafo);
                        grafo = grafo.complemento(g);
                    }
                    else
                    if (AristaDirigida.Enabled == true)
                    {
                       // grafo.penA.CustomEndCap = arrow;
                        
                        grafo = grafo.complemento(g);
                        grafo.penA.CustomEndCap = arrow;
                    }
                    else
                    {
                        grafo = grafo.complemento(g);
                    }
                       
                    
                    Form1_Paint(this, null);
                break;
            }
        }

 

        private void Arista_Click(object sender, ToolStripItemClickedEventArgs e)
        {
            band = false;
            bandA = false;
            bandF = false;
            bandI = false;

            switch (e.ClickedItem.AccessibleName)
            {
                case "AristaNoDirigida":
                    opcion = 2;
                    grafo = new GrafoNoDirigido(grafo);
                    break;

                case "BorrarArista":
                    opcion = 5;
                break;

                case "AristaDirigida":
                    opcion = 9;
                    grafo = new GrafoDirigido(grafo);
                    grafo.penA.CustomEndCap = arrow;
                    break;
            }
        }

        private void Archivo_Click(object sender, ToolStripItemClickedEventArgs e)
        {

            opcion = 0;
            NodoP A = null;
            bool band = false;
            int i = 0;

            IFormatter formatter = new BinaryFormatter();
            String directorio    = Environment.CurrentDirectory + "..\\Grafos";
           // directorio = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\Grafos"));
            


            switch (e.ClickedItem.AccessibleName)
            {
                case "Save":
                    saveFileDialog1.InitialDirectory = directorio;
                    saveFileDialog1.FileName = "";
                    saveFileDialog1.Filter = "(*.grafo)|*.grafo";
                    if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        Stream stream = new FileStream(saveFileDialog1.FileName, FileMode.Create, FileAccess.Write, FileShare.None);
                        if(AristaDirigida.Enabled == true && AristaNoDirigida.Enabled == false)
                        {
                            formatter.Serialize(stream, (GrafoDirigido)grafo);
                           
                        }
                        else if(AristaNoDirigida.Enabled == true && AristaDirigida.Enabled == false)
                        {
                            formatter.Serialize(stream, (GrafoNoDirigido)grafo);
                        }
                        else
                        {
                            formatter.Serialize(stream, (Grafo)grafo);
                        }
                        
                        stream.Close();
                    }
                    break;

                case "Open":
                    openFileDialog1.FileName = "";
                    openFileDialog1.Filter = "(*.grafo)|*.grafo";
                    openFileDialog1.InitialDirectory = directorio;
                    if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        g.Clear(BackColor);
                        grafo.Clear();
                        AristaNoDirigida.Enabled = true;
                        AristaDirigida.Enabled = true;
                        Stream stream = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read, FileShare.None);
                        grafo = (Grafo)formatter.Deserialize(stream);
                        /*Algoritmo que determina si es dirigido, no dirigido, o solo tiene nodos*/
                        foreach (NodoP np in grafo){
                            foreach(Arista nr in np.aristas){
                                A = nr.destino;
                                foreach(Arista n in A.aristas){ 
                                    if(n.destino == np) //Condición si nodo A apunta a B y B apunta a A
                                    {
                                        band = true;
                                        break;
                                    }
                                    else{
                                        band = false;
                                        break;
                                    }
                                }

                            }
                        }
                        stream.Close();
                        stream = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read, FileShare.None);
                        if (band == true) // Si band es true, entonces es no dirigido
                        {
                            grafo = (GrafoNoDirigido)formatter.Deserialize(stream);
                            grafo.penA = new Pen(grafo.cArista, grafo.widthA);
                            AristaDirigida.Enabled = false;
                            grafo.penN = new Pen(grafo.cNodo, grafo.width);
                            grafo.brushN = new SolidBrush(grafo.cRelleno);

                            grafo.brushF = new SolidBrush(grafo.colorFuente);
                            grafo.font = new Font(grafo.nameF, grafo.sizeF, grafo.styleF);
                        }
                        else
                        {
                            foreach(NodoP np in grafo){
                                if(np.aristas.Count == 0){
                                    i++;
                                }
                            }
                            if(i == grafo.Count){ /* Si i es igual que el numero de nodos, entonces no tiene aristas el grafo*/
                                grafo = (Grafo)formatter.Deserialize(stream);
                                AristaNoDirigida.Enabled = true;
                                AristaDirigida.Enabled = true;
                                grafo.penN = new Pen(grafo.cNodo, grafo.width);
                                grafo.brushN = new SolidBrush(grafo.cRelleno);

                                grafo.brushF = new SolidBrush(grafo.colorFuente);
                                grafo.font = new Font(grafo.nameF, grafo.sizeF, grafo.styleF);

                            }
                            else
                            {
                                
                                grafo = (GrafoDirigido)formatter.Deserialize(stream);

                                /* Propiedades Guardades en variables temporales*/

                                Pen         penN = new Pen(grafo.cNodo, grafo.width);
                                SolidBrush  brushN = new SolidBrush(grafo.cRelleno);
                                SolidBrush  brushF = new SolidBrush(grafo.colorFuente);
                                Font        font = new Font(grafo.nameF, grafo.sizeF, grafo.styleF);
                                Pen         penA = new Pen(grafo.cArista, grafo.width);
                                
                                /* Asiganción de variables al grafo */
                                grafo = new GrafoDirigido(grafo);

                                grafo.penN = penN;
                                grafo.brushN = brushN;
                                grafo.brushF = brushF;
                                grafo.font = font;
                                grafo.penA = penA;
                                grafo.penA.CustomEndCap = arrow;
                               
                                AristaNoDirigida.Enabled = false;
                            }
                        }

                        stream.Close();
                        
                        

                        band = false;
                        bandA = false;
                        bandF = false;
                        bandI = false;

                        MueveNodo.Enabled = true;
                        BorrarNodo.Enabled = true;
                       // AristaNoDirigida.Enabled = true;
                      //  AristaDirigida.Enabled = true;
                        BorrarArista.Enabled = true;
                        MueveGrafo.Enabled = true;
                        BorrarGrafo.Enabled = true;
                        EliminarGrafo.Enabled = true;
                        Cambia.Enabled = true;
                        Invalidate();
                    }
                break;

                case "Imprimir":
                    opcion = 10;
                    band = false;
                    bandF = false;
                    bandA = false;
                    bandI = true;
                    Invalidate();
                break;
            }
        }

        #endregion

        #region Funciones Extras

        private void CambiaBotones(bool b)
        {
            MueveNodo.Enabled = b;
            BorrarNodo.Enabled = b;
            AristaDirigida.Enabled = b;
            AristaNoDirigida.Enabled = b;
            BorrarArista.Enabled = b;
            MueveGrafo.Enabled = b;
            BorrarGrafo.Enabled = b;
            EliminarGrafo.Enabled = b;
            Cambia.Enabled = b;
        }

        private int CambiaNombre()
        {
            if (grafo.edoNom && grafo.numN < 28 && grafo.nomb < 28)
            {
                grafo.edoNom = false;
                Invalidate();
                bandI = true;
                return 1;
            }

            if (grafo.numN > 27 && grafo.edoNom  && grafo.nomb > 27)
                MessageBox.Show("No se puede cambiar el nombre de los nodos de numeros a letras porque hay demasiados nodos", "Error");

            if (grafo.numN <= 27 && !grafo.edoNom)
            {
                grafo.edoNom = true;
                Invalidate();
            }

            bandI = true;
            return 0;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            //grafo.ImprimirGrafo(g);
            //g.DrawImage(bmp1, 0, 0);
        }

        #endregion
        public void actualizaPropiedades()
        {
           // grafo.penA.CustomEndCap = arrow;

            grafo.font = config.font;
            grafo.penN = config.penN;
            grafo.penA = config.penA;
            grafo.brushN = config.brushN;
            grafo.brushF = config.brushF;
            grafo.radio = config.radio;

            grafo.cNodo = grafo.penN.Color;
            grafo.width = grafo.penN.Width;
            grafo.cRelleno = grafo.brushN.Color;

            grafo.cArista = grafo.penA.Color;
            grafo.widthA = grafo.penA.Width;

            grafo.colorFuente = grafo.brushF.Color;
            grafo.nameF = grafo.font.Name;
            grafo.sizeF = grafo.font.Size;
            grafo.styleF = grafo.font.Style;
        }
        public void actualizaGrafo()
        {
            Pen penN = new Pen(grafo.cNodo, grafo.width);
            SolidBrush brushN = new SolidBrush(grafo.cRelleno);
            SolidBrush brushF = new SolidBrush(grafo.colorFuente);
            Font font = new Font(grafo.nameF, grafo.sizeF, grafo.styleF);
            Pen penA = new Pen(grafo.cArista, grafo.width);

            /* Asiganción de variables al grafo */
            grafo = new GrafoDirigido(grafo);

            grafo.penN = penN;
            grafo.brushN = brushN;
            grafo.brushF = brushF;
            grafo.font = font;
            grafo.penA = penA;
            grafo.penA.CustomEndCap = arrow;

        }
        
    }
}