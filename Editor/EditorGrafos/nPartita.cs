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
    partial class nPartita : Form
    {
        public nPartita(List<List<int>> partita, Grafo g)
        {
            InitializeComponent();
            string renglon = "";
            foreach (List<int> aux in partita)
            {
                foreach(int aux2 in aux)
                {
                    if(!g.edoNom)
                    {
                        renglon += (char)(aux2 + 64) + ", ";
                    }else
                        renglon += aux2 + ", ";
                }
                dataGridView1.Rows.Add(renglon);
                renglon = "";
                
            }
            if(partita.Count == 2)
                label1.Text = "Bi-Partita";
            else if (partita.Count == 3)
                label1.Text = "Tri-Partita";
            else
                label1.Text = partita.Count.ToString() + " - Partita";
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
