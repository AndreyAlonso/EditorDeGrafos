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
     partial class PreExamen : Form
    {
        private int i;
        public PreExamen(Grafo g)
        {
            i = 0;
           
            InitializeComponent();
           // g.numN = 28;
            //g.edoNom = true;
            foreach (NodoP np in g)
            {


                if(!g.edoNom)
                {
                    
                         dataGridView1.Rows.Add((char)(np.nombre + 64), np.aristas.Count);
                }else
                    dataGridView1.Rows.Add(np.nombre,np.aristas.Count);
                i = i + np.aristas.Count;
            }
            label2.Text = i.ToString();
            

        }

        private void salirPreExamen1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
