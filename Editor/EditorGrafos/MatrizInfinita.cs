using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditorGrafos
{
    partial class MatrizInfinita : Form
    {

        Grafo g;
        private List<int> r;
        private List<List<int>> renglon = new List<List<int>>();
        private List<int> c;
        private List<List<int>> columna = new List<List<int>>();
        private List<List<int>> M = new List<List<int>>();

        public MatrizInfinita(Grafo grafo)
        {
            InitializeComponent();
            dataGridView1.Columns.Add(" ", " ");

            foreach (NodoP gr in grafo)
            {
                comboBox1.Items.Add((char)(gr.nombre + 64));
                comboBox2.Items.Add((char)(gr.nombre + 64));
            }
            g = grafo;
            comboBox1.SelectedIndex = 0;
            comboBox2.Text = ((char)(grafo[0].nombre + 64)).ToString();
            comboBox1.Text = ((char)(grafo[0].nombre + 64)).ToString();
            comboBox2.SelectedIndex = 0;
            creaListas();
            calculaMatriz(grafo);
            inicializaDatagrid(grafo);
            llenaDatagrid();
            comboBox1_SelectedIndexChanged(this, null);
            comboBox2_SelectedIndexChanged(this, null);



        }

        public void inicializaDatagrid(Grafo grafo)
        {
            //dataGridView1.Width  = 50 * grafo.Count;
            //dataGridView1.Height = 30 * grafo.Count;
            
            for (int i = 0; i < grafo.Count; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Columns.Add(((char)(grafo[i].nombre + 64)).ToString(), ((char)(grafo[i].nombre + 64)).ToString());
                dataGridView1.Columns[i].Width = (dataGridView1.Width / grafo.Count) - 20 ;
                dataGridView1.Rows[i].Cells[0].Value = ((char)(grafo[i].nombre + 64)).ToString() ;
            }
            //dataGridView1.Columns[grafo.Count].Width = dataGridView1.Width / grafo.Count;
            dataGridView1.Columns[grafo.Count].Width = (dataGridView1.Width / grafo.Count) -20;

        }
        public void creaListas()
        {
            Arista aux;
            renglon.Clear();
            columna.Clear();
            foreach(NodoP np in g)
            {
                r = new List<int>();
                c = new List<int>();
                foreach(NodoP compara in g)
                {
                    aux = np.aristas.Find(x => x.destino.Equals(compara));
                    if (aux != null)
                    {
                        r.Add(1);
                        c.Add(1);
                    }
                    else
                    {
                        r.Add(0);
                        c.Add(0);
                    }
                }
                renglon.Add(r);
                columna.Add(c);


            }
        }
        private void MatrizInfinita_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public int dameA(NodoP np, Arista  nr, Grafo grafo)
        {
            foreach(Arista aux2 in np.aristas)
            {
                foreach(NodoP nodo in grafo)
                {
                    if (aux2.destino.nombre == nodo.nombre)
                    {
                        return 1;
                    }
                    else
                        return 0;
                }                       
            }
            
            return 1;
        }
        
        public void calculaMatriz(Grafo g)
        {
            int repeticiones = (int)numericUpDown1.Value;
            List<int> nuevo = new List<int>();
            creaListas();
            int c = 0;
            int i;
            int l = 0;
            if (repeticiones == 1)
            {
                M.Clear();
                foreach (List<int> s in columna)
                    M.Add(s);      
            }
            else
            {

                for (i = 1; i < repeticiones; i++)
                {

                    M.Clear();
                    for (int h = 0; h < renglon.Count; h++) // h es el centinela del  renglon
                    {
                        nuevo = new List<int>();

                        for (int j = 0; j < renglon.Count; j++) // j es el centinela del 
                        {
                            l = 0;
                            c = 0;
                            for (int k = 0; k < columna.Count; k++)
                            {
                                c = c + renglon[h][k] * columna[j][k];
                            }
                            nuevo.Add(c);
                            l++;

                        }
                        M.Add(nuevo);
                    }
                    
                    renglon.Clear();
                    foreach (List<int> s in M)
                        renglon.Add(s);
                   
                    
                }
            }
        }
        public void llenaDatagrid()
        {
            int i = 0;
            int j = 1;
            foreach(List<int> r in M)
            {
                j = 1;
                foreach(int c in r)
                {
                    dataGridView1.Rows[i].Cells[j].Value = c;
                    j++;
                }
                i++;
            }
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            calculaMatriz(g);
            llenaDatagrid();
            comboBox1_SelectedIndexChanged(this, null);
            comboBox2_SelectedIndexChanged(this, null);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            char val = Convert.ToChar(comboBox1.Text);
            val = (char)(val - 64);
            char val2 = Convert.ToChar(comboBox2.Text);
            val2 = (char)(val2 - 64);
            int a = Convert.ToInt32(val);
            int b = Convert.ToInt32(val2);
            

           for(int i = 0;  i < dataGridView1.Rows.Count-1; i++)
            {
                for(int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    
                    if(dataGridView1.Rows[i].Cells[0].Value.ToString() == comboBox1.Text && dataGridView1.Columns[j].Name == comboBox2.Text)
                    {
                        label4.Text = dataGridView1.Rows[i].Cells[j].Value.ToString();
                        //MessageBox.Show(label4.Text);
                    }
                       
                        
                }
            }
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //comboBox2_SelectedIndexChanged(this, null);
        }
    }
}
