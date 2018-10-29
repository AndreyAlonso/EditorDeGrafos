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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditorGrafos
{
    public partial class EditorGrafo : Form
    {
        #region Inicialziacion

        Grafo grafo;
        NodoP nodoP, nodoAux, nodoW;
        bool activa;
        Arista nodoR;
        Graphics g;
        int opcion;
        Bitmap bmp1;
        bool band, bandF, bandA, bandI, bpar;
        Point p1, p2;
        Random rnd = new Random();
        Configuracion config;
        AdjustableArrowCap arrow;
        bool grafoEspecial;
        #endregion
        #region Propiedades
        int radio;
        int nomb;
        string nameF;
        Color cRelleno;
        Color colorFuente;
        Color cNodo;
        float width;
        float widthA;
        Color cArista;
        Pen penN;
        SolidBrush brushN;
        SolidBrush brushF;
        Font font;
        Pen penA;

        #endregion
        #region Principal
        // VARIABLES EXTRAS
        MuestraCadena muestra;


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
            bpar = false;
            arrow = new AdjustableArrowCap(5, 5);
            timer1.Enabled = false;
            numericUpDown1.Hide();
            numericUpDown2.Hide();
            numericUpDown3.Hide();
            grafoEspecial = false;
            nPartita.Enabled = false;
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
                    case 1:
                        ga.FillEllipse(grafo.brushN, p1.X - grafo.radio, p1.Y - grafo.radio, grafo.radio * 2, grafo.radio * 2);
                        ga.DrawEllipse(grafo.penN, p1.X - grafo.radio + (grafo.penN.Width / 2), p1.Y - grafo.radio + (grafo.penN.Width / 2), grafo.radio * 2 - (grafo.penN.Width / 2), grafo.radio * 2 - (grafo.penN.Width / 2));
                        if (grafo.numN >= 28 || grafo.edoNom)
                            ga.DrawString(nodoP.nombre.ToString(), grafo.font, grafo.brushF, p1.X - 6, p1.Y - 6);
                        else
                            ga.DrawString(((char)(nodoP.nombre + 64)).ToString(), grafo.font, grafo.brushF, p1.X - 6, p1.Y - 6);
                        break;

                    case 2:
                    case 9:
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
                }
                bandF = false;
            }

            if (bandI)
            {
                ga.Clear(BackColor);
                grafo.ImprimirGrafo(ga, bpar);
                bandI = false;
            }

            if (opcion == 6 || opcion == 7)
            {
                ga.Clear(BackColor);
                grafo.Clear();
                grafo.numN = 1;
                grafo.edoNom = false;
                if (opcion == 7)
                {
                    grafo = new Grafo();
                    MatrizInfinita.Enabled = false;
                    CambiaBotones(false);
                }
            }
            if (opcion != 6)
                if (opcion != 7)
                    grafo.ImprimirGrafo(ga, bpar);
            g.DrawImage(bmp1, 0, 0);

        }

        #endregion 

        #region Mouse_Events

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            p1 = e.Location;
            if (activa)
            {
                nodoW = grafo.BuscaNodo(p1);
                activa = false;
            }

            switch (opcion)
            {
                case 1:
                    if (/*grafo.Count == 1 &&*/ grafo.numN == 1)
                        CambiaBotones(true);
                    grafo.numN++;
                    if (grafo.Count > 0)
                        nodoP = new NodoP(grafo.Count - 1, p1);
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

                    warnerButton.Enabled = true;
                    break;
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button.Equals(MouseButtons.Left) && (opcion == 2 || opcion == 9) && bandA)
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

            if (e.Button.Equals(MouseButtons.Left) && opcion == 8)
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
            activa = true;
            if (bandA && band && (opcion == 2 || opcion == 9))
            {
                p2 = e.Location;
                nodoAux = grafo.BuscaNodo(p2);

                if (nodoAux != null)
                {
                    if (opcion == 2)
                    {
                        AristaDirigida.Enabled = false;
                        //  grafo = new GrafoNoDirigido(grafo);
                        nodoR = new Arista(rnd.Next(100));
                        nodoR.destino = nodoAux;
                        nodoR.origen = nodoP;
                        nodoP.aristas.Add(nodoR);


                        nodoR = new Arista(rnd.Next(100));

                        nodoR.destino = nodoP;
                        nodoR.origen = nodoAux;

                        nodoAux.aristas.Add(nodoR);
                    }

                    else if (opcion == 9)
                    {
                        AristaNoDirigida.Enabled = false;
                        //    grafo = new GrafoDirigido(grafo);
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

            if (opcion == 4)
            {
                grafo.BorrarNodo(e.Location);
                bandF = false;
            }

            if (opcion == 5)
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
            numericUpDown1.Visible = false;
            numericUpDown2.Visible = false;
            numericUpDown3.Visible = false;
            MatrizInfinita.Enabled = true;
            warnerButton.Enabled = true;
            euleriano.Enabled = true;
            nodoPendiente.Enabled = true;
            switch (e.ClickedItem.AccessibleName)
            {
                case "CrearNodo":
                case "MoverNodo":
                case "BorrarNodo":
                    bpar = false;
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
                case "agregaPeso":
                    agregaPesoArista();
                break;

            }
        }
        private void agregaPesoArista()
        {
            Costo costo = new Costo(grafo);
            if(costo.ShowDialog() == DialogResult.OK)
            {

            }


        }
        private void Configuracion_Clicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.AccessibleName)
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

                            grafo = new GrafoDirigido(grafo);

                            grafo.widthA = config.anchoArista;
                            grafo.radio = config.radio;
                            grafo.font = config.font;
                            grafo.cRelleno = config.rellenoNodo;
                            grafo.colorFuente = config.colorFuente;
                            grafo.cNodo = config.ContornoNodo;
                            grafo.width = config.anchoNodo;
                            grafo.cArista = config.colorArista;
                            grafo.penN = new Pen(grafo.cNodo, grafo.width);
                            grafo.brushN = new SolidBrush(grafo.cRelleno);
                            grafo.brushF = new SolidBrush(grafo.colorFuente);
                            grafo.font = new Font(grafo.nameF, grafo.sizeF, grafo.styleF);
                            grafo.penA = new Pen(grafo.cArista, grafo.widthA);

                            /*
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
                            grafo.penA.Width = grafo.penA.Width;
                            grafo.colorFuente = grafo.brushF.Color;
                            grafo.nameF = grafo.font.Name;
                            grafo.sizeF = grafo.font.Size;
                            grafo.styleF = grafo.font.Style;
                            */
                            grafo.penA.CustomEndCap = arrow;
                            //actualizaPropiedades();



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

            switch (e.ClickedItem.AccessibleName)
            {

                case "MoverGrafo":
                    opcion = 8;

                    warnerButton.Enabled = true;
                    break;

                case "BorrarGrafo":
                    opcion = 6;
                    break;

                case "EliminarGrafo":
                    opcion = 7;
                    warnerButton.Enabled = false;
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
                    activa = true;
                    break;

                case "MoverNodo":
                    opcion = 3;
                    break;

                case "BorrarNodo":
                    opcion = 4;
                    break;
            }
        }


        List<NodoP> circuito;
        private void metodosAdicionales(object sender, ToolStripItemClickedEventArgs e)
        {
            numericUpDown1.Visible = false;
            numericUpDown2.Visible = false;
            numericUpDown3.Visible = false;
            int i = 0;
            int j = 0;
            bool vacio = false;

            bool band = false;
            Random rand = new Random();

            switch (e.ClickedItem.AccessibleName)
            {
                case "complemento":
                    bpar = false;

                    obtenPropiedades();
                    if (AristaNoDirigida.Enabled == true && AristaDirigida.Enabled == true)
                    {
                        grafo = new GrafoNoDirigido(grafo);
                        grafo = grafo.complemento(g);
                        asignaPropiedades();
                        AristaDirigida.Enabled = false;

                    }
                    else
                    if (AristaDirigida.Enabled == true && AristaNoDirigida.Enabled == false)
                    {
                        grafo = grafo.complemento(g);
                        asignaPropiedades();
                        grafo.penA.CustomEndCap = arrow;
                    }
                    else if (AristaDirigida.Enabled == false && AristaNoDirigida.Enabled == true)
                    {
                        grafo = grafo.complemento(g);
                        asignaPropiedades();
                    }

                    grafo.numN = grafo.Count;
                    //grafo.ImprimirGrafo(g);
                    Form1_Paint(this, null);
                    break;
                case "preExamen_1":
                    if (AristaNoDirigida.Enabled == true && AristaDirigida.Enabled == false)
                    {
                        PreExamen pre = new PreExamen(grafo);
                        pre.Show();
                    }
                    else
                    {
                        MessageBox.Show("Tiene que ser grafo no  dirigido");
                    }

                    break;
                case "nPartita":
                    bpar = true;

                    List<List<int>> partita = new List<List<int>>();
                    List<Color> color = coloreate();
                    partita = grafo.nPartita(g);
                    //grafo.ImprimirGrafo(g, bpar);
                    nPartita nPartita = new nPartita(partita, grafo);

                    i = rand.Next(0, color.Count);
                    foreach (List<int> aux1 in partita)
                    {
                        foreach (int aux2 in aux1)
                        {
                            grafo.Find(x => x.nombre.Equals(aux2)).colorN = new SolidBrush(color[i]);
                            j = i;

                        }
                        if (i < color.Count - 1)
                            i++;
                        else
                            i = 0;

                    }
                    // grafo.ImprimirGrafo(g, bpar);
                    // Form1_Paint(this, null);
                    //  grafo.ImprimirGrafo(g, bpar);
                    nPartita.Show();
                    break;
                case "MatrizInfinita":

                    MatrizInfinita matriz = new MatrizInfinita(grafo);
                    matriz.Show();
                    break;
                case "nodoPendiente":
                    List<int> pendientes = new List<int>();
                    List<int> cut = new List<int>();
                    grafo = new GrafoNoDirigido(grafo);
                    bpar = true;
                    pendientes = grafo.nodoPendiente();
                    //  cut = grafo.verticeCut();
                    foreach (int aux1 in pendientes)
                    {
                        grafo.Find(x => x.nombre.Equals(aux1)).colorN = new SolidBrush(Color.Red);
                        grafo.Find(x => x.nombre.Equals(aux1)).aristas[0].destino.colorN = new SolidBrush(Color.Green);
                        grafo.Find(x => x.nombre.Equals(aux1)).aristas[0].colorA = new Pen(new SolidBrush(Color.Blue));
                        grafo.Find(x => x.nombre.Equals(aux1)).aristas[0].destino.aristas[0].colorA = new Pen(new SolidBrush(Color.Blue));
                    }
                    foreach (int nodo in cut)
                    {
                        grafo.Find(x => x.nombre.Equals(nodo)).colorN = new SolidBrush(Color.Green);
                    }
                    bpar = true;
                    break;
                case "Euleriano":
                    Euler();
                break;
                case "warner":
                    int warner;
                    warner = grafo.warner(g, nodoW);
                    if (warner == 1)
                    {
                        MessageBox.Show("Tiene un K5");
                    }
                    else if (warner == 2)
                        MessageBox.Show("Tiene un K3,3");
                    else
                        MessageBox.Show("No tiene K5 ni K3,3");
                    break;


            }

        }
        public void Euler()
        {
            bool camino = false;
            string cadena = "";
            int pares = 0;
            int impares = 0;
            List<Arista> caminos;
            List<NodoP> circuit;

            foreach (NodoP np in grafo){
                if (np.aristas.Count % 2 == 0){
                    pares++;
                }
                if (np.aristas.Count % 2 != 0){
                    impares++;
                }
            }
            if (pares == grafo.Count) // SI TODOS LOS NODOS SON DE GRADO PAR ENTONCES TIENE CIRCUITO EULERIANO
            {
                circuit = grafo.circuitoEuleriano();
                circuito = circuit;
                foreach (NodoP np in circuit){
                    cadena += (char)(np.nombre + 64) + " >> ";
                }
                
                bpar = true;
                muestra = new MuestraCadena("Circuito Euleriano", cadena);
                muestra.Show();
                muestra.timer1.Tick += Timer1_Tick;
            }

            else if (impares == 2) // SI TIENE DOS NODOS DE GRADO IMPAR, ENTONCES TIENE CAMINO EULERIANO
            {
                circuit = grafo.caminoEuleriano();
                circuito = circuit;
                foreach (NodoP np in circuit)
                {
                    cadena += (char)(np.nombre + 64) + " >> ";
                }
                bpar = true;
                muestra = new MuestraCadena("Camino Euleriano", cadena);
                muestra.Show();
                muestra.timer1.Tick += Timer1_Tick;
                
            }
            else
                MessageBox.Show("No tiene camino ni circuito Euleriano");
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            grafo.pintaEuler(g, circuito);

            timer1.Enabled = false;
            
            if (muestra != null)
            {
                muestra.button1.Enabled = false;
                muestra.timer1.Enabled = false;
                
            }
             
        }

        public List<Color> coloreate()
        {
            List<Color> color = new List<Color>();
            color.Add(Color.Red);
            color.Add(Color.Blue);
            color.Add(Color.Green);
            color.Add(Color.Yellow);
            color.Add(Color.Violet);
            color.Add(Color.DarkKhaki);
            color.Add(Color.DarkOrange);
            color.Add(Color.YellowGreen);
            color.Add(Color.DarkCyan);

            return color;

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
                    obtenPropiedades();
                    grafo = new GrafoNoDirigido(grafo);
                    asignaPropiedades();
                    nPartita.Enabled = true;

                    break;

                case "BorrarArista":
                    opcion = 5;
                    break;

                case "AristaDirigida":
                    opcion = 9;
                    obtenPropiedades();
                    grafo = new GrafoDirigido(grafo);
                    asignaPropiedades();
                    grafo.penA.CustomEndCap = arrow;
                    AristaNoDirigida.Enabled = false;
                    break;
            }
        }

        private void Archivo_Click(object sender, ToolStripItemClickedEventArgs e)
        {

            opcion = 0;
            NodoP A = null;
            bool band = false;
            int i = 0;

            bpar = false;
            if (bpar == false)
                grafo.ImprimirGrafo(g,bpar);

            IFormatter formatter = new BinaryFormatter();
            String directorio = Environment.CurrentDirectory + "..\\Grafos";
            //String directorio = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\\Grafos"));



            switch (e.ClickedItem.AccessibleName)
            {
                case "Save":
                    saveFileDialog1.InitialDirectory = directorio;
                    saveFileDialog1.FileName = "";
                    saveFileDialog1.Filter = "(*.grafo)|*.grafo";
                    if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        Stream stream = new FileStream(saveFileDialog1.FileName, FileMode.Create, FileAccess.Write, FileShare.None);
                        if (AristaDirigida.Enabled == true && AristaNoDirigida.Enabled == false)
                        {
                            formatter.Serialize(stream, (GrafoDirigido)grafo);

                        }
                        else if (AristaNoDirigida.Enabled == true && AristaDirigida.Enabled == false)
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
                        /* Algoritmo que determina si es dirigido, no dirigido, o solo tiene nodos */
                        foreach (NodoP np in grafo) { /*Se recorren nodos del grafo*/
                            foreach (Arista nr in np.aristas) { /* Se recorren las aristas de cada nodo */
                                A = nr.destino; 
                                foreach (Arista n in A.aristas) { /* Se recorren las aristas del nodo  */
                                    if (n.destino == np) //Condición si nodo A apunta a B y B apunta a A
                                    {
                                        band = true;
                                        break;
                                    }
                                    else {
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
                            grafo.bpar = false;
                            grafo.penA = new Pen(grafo.cArista, grafo.widthA);
                            AristaDirigida.Enabled = false;
                            grafo.penN = new Pen(grafo.cNodo, grafo.width);
                            grafo.brushN = new SolidBrush(grafo.cRelleno);

                            grafo.brushF = new SolidBrush(grafo.colorFuente);
                            grafo.font = new Font(grafo.nameF, grafo.sizeF, grafo.styleF);
                        }
                        else if(band == false)
                        {
                            foreach (NodoP np in grafo) {
                                if (np.aristas.Count == 0) {
                                    i++;
                                }
                            }
                            if (i == grafo.Count) { /* Si i es igual que el numero de nodos, entonces no tiene aristas el grafo*/
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
                                int TAM = 0;
                                bool compara = false;
                                foreach(NodoP np in grafo)
                                {
                                    TAM += np.aristas.Count;
                                    if (np.aristas.Count == grafo.Count - 1)
                                    {
                                        compara = true;
                                    }

                                    else if (TAM == grafo.Count * 2)
                                        compara = true;
                                    else
                                        compara = false;
                                }
                                if(compara)
                                {
                                    grafo = (GrafoNoDirigido)formatter.Deserialize(stream);
                                    obtenPropiedades();
                                    grafo = new GrafoNoDirigido(grafo);
                                    asignaPropiedades();
                                    AristaNoDirigida.Enabled = true;
                                    nPartita.Enabled = true;
                                }
                                else
                                {
                                    grafo = (GrafoNoDirigido)formatter.Deserialize(stream);
                                    obtenPropiedades();
                                    grafo = new GrafoNoDirigido(grafo);
                                    asignaPropiedades();
                                    grafo.penA.CustomEndCap = arrow;
                                    AristaDirigida.Enabled = true;

                                }
                                
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

        

        private void grafosEspeciales(object sender, ToolStripItemClickedEventArgs e)
        {
            AristaNoDirigida.Enabled = true;
            AristaDirigida.Enabled = false;
            MueveNodo.Enabled = true;
            MueveGrafo.Enabled = true;
            CrearNodo.Enabled = true;
            Cambia.Enabled = true;
            EliminarGrafo.Enabled = true;
            BorrarGrafo.Enabled = true;
            BorrarNodo.Enabled = true;
            BorrarArista.Enabled = true;
            nPartita.Enabled = true;
            MatrizInfinita.Enabled = true;
            euleriano.Enabled = true;
            nodoPendiente.Enabled = true;
            opcion = 1;
            activa = true;

            switch (e.ClickedItem.AccessibleName)
            {
                case "GrafoKn":
                    
                    numericUpDown1.Show();
                    numericUpDown2.Hide();
                    numericUpDown3.Hide();
                break;
                case "GrafoCn":
                    
                    numericUpDown1.Hide();
                    numericUpDown2.Show();
                    numericUpDown3.Hide();
                    break;
                case "GrafoWn":
                    
                    numericUpDown1.Hide();
                    numericUpDown2.Hide();
                    numericUpDown3.Show();
                    break;

              
            }
        }


        #endregion
        #region numericGrafosEspeciales
        private void numericKn(object sender, EventArgs e)
        {
            
                obtenPropiedades();
                grafo = new GrafoNoDirigido(grafo);
                asignaPropiedades();
                grafo.Clear();
                grafo.grafoKn((int)numericUpDown1.Value, g);
                grafo.numN = grafo.Count;
                Form1_Paint(this, null);
            
            

        }



        private void numericCn(object sender, EventArgs e)
        {

            obtenPropiedades();
            grafo = new GrafoNoDirigido(grafo);
            asignaPropiedades();
            grafo.Clear();
           
            grafo.grafoCn((int)numericUpDown2.Value, g);
            grafo.numN = grafo.Count;
            Form1_Paint(this, null);
        }

        

        private void numericWn(object sender, EventArgs e)
        {
            obtenPropiedades();
            grafo = new GrafoNoDirigido(grafo);
            asignaPropiedades();
            grafo.Clear();
            grafo.grafoWn((int)numericUpDown3.Value, g);
            grafo.numN = grafo.Count;
            Form1_Paint(this, null);
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

            if (grafo.numN > 27 && grafo.edoNom && grafo.nomb > 27)
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
            try
            {
                bmp1 = new Bitmap(ClientRectangle.Width, ClientRectangle.Height);
                g = CreateGraphics();
            }
            catch
            {

            }
          //  SetClientSizeCore(ClientSize.Width, this.ClientSize.Height);
            numericUpDown1.Location = new Point(toolStrip3.Location.X-toolStrip3.Width-5, numericUpDown1.Location.Y);
            numericUpDown2.Location = new Point(toolStrip3.Location.X - toolStrip3.Width - 5, numericUpDown2.Location.Y);
            numericUpDown3.Location = new Point(toolStrip3.Location.X - toolStrip3.Width - 5, numericUpDown3.Location.Y);
            
        }

        #endregion
        #region MetodosPropiedades
        public void obtenPropiedades()
        {
            radio = grafo.radio;
            nomb = grafo.nomb;
            nameF = grafo.nameF;
            cRelleno = grafo.cRelleno;
            colorFuente = grafo.colorFuente;
            cNodo = grafo.cNodo;
            width = grafo.width;
            widthA = grafo.widthA;
            cArista = grafo.cArista;
            penN = new Pen(grafo.cNodo, grafo.width);
            brushN = new SolidBrush(grafo.cRelleno);
            brushF = new SolidBrush(grafo.colorFuente);
            font = new Font(grafo.nameF, grafo.sizeF, grafo.styleF);
            penA = new Pen(grafo.cArista, grafo.widthA);
        }
        public void asignaPropiedades()
        {
            grafo.widthA = widthA;
            grafo.radio = radio;
            grafo.nomb = nomb;
            grafo.nameF = nameF;
            grafo.cRelleno = cRelleno;
            grafo.colorFuente = colorFuente;
            grafo.cNodo = cNodo;
            grafo.width = width;
            grafo.cArista = cArista;
            grafo.penN = new Pen(grafo.cNodo, grafo.width);
           
            grafo.brushN = new SolidBrush(grafo.cRelleno);
            grafo.brushF = new SolidBrush(grafo.colorFuente);
            grafo.font = new Font(grafo.nameF, grafo.sizeF, grafo.styleF);
            grafo.penA = new Pen(grafo.cArista, grafo.widthA);


        }
        #endregion



    }
}