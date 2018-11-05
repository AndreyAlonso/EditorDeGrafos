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
    partial class Dijkstra : Form
    {
        GrafoDirigido g;
        List<List<NodoP>> DK;
        List<int> pesos;
        public Dijkstra(Grafo grafo)
        {
            g = new GrafoDirigido(grafo);

            DK = g.dijkstra();
            pesos = g.damePesos();
            InitializeComponent();
            inicializaCombo();
            generaTabla();
       
        }
        private void inicializaCombo()
        {
            foreach(NodoP np in g)
            {
                comboBox1.Items.Add( ((char)(np.nombre+64))  );
            }
        }
        private void generaTabla()
        {

            
            //dataGridView1.Columns.Add("A", "A");
            for (int i = 0; i < g.Count; i++)
            {
                dataGridView1.Columns.Add(((char)(g[i].nombre + 64)).ToString(), ((char)(g[i].nombre + 64)).ToString());
                dataGridView1.Columns[i].Width = (dataGridView1.Width -50) / (g.Count);
                
            }
            dataGridView1.Rows.Add();
            for(int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Rows[0].Cells[i].Value = pesos[i];
            }
        }
        
        private void Dijkstra_Load(object sender, EventArgs e)
        {

        }
    }
}
