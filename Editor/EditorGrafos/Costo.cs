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
    partial class Costo : Form
    {
        Grafo grafo;
        List<Label> letras;
        List<TextBox> boxes;
        public Costo(Grafo grafo)
        {
            this.grafo = grafo;
            letras = new List<Label>();
            boxes = new List<TextBox>();
            InitializeComponent();
            inicializaCombo(grafo);
        }

        private void Costo_Load(object sender, EventArgs e)
        {

        }
        private void inicializaCombo(Grafo grafo)
        {
            foreach(NodoP np in grafo)
            {
                comboBox1.Items.Add((char)(np.nombre + 64));
            }
            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox text;
            Label label;
            int y = 100;
            foreach(TextBox tbx in boxes)
            {
                Controls.Remove(tbx);
            }
            foreach(Label la in letras)
            {
                Controls.Remove(la);
            }
            boxes.Clear();
            letras.Clear();

            foreach(NodoP np in grafo)
            {
                if (((char)(np.nombre + 64)).ToString() == comboBox1.Text)
                {
                    foreach (Arista nr in np.aristas)
                    {
                        if (nr.destino != np)
                        {
                            label = new Label();
                            label.Text = ((char)(nr.destino.nombre + 64)).ToString();
                            label.Width = 20;
                            label.Location = new Point(100, y);
                            text = new TextBox();
                            text.Width = 60;
                            text.Height = 20;
                            text.Location = new Point(150, y);
                            text.Name = label.Text;
                            y += 30;
                            Controls.Add(label);
                            letras.Add(label);
                            Controls.Add(text);
                            boxes.Add(text);
                        }


                    }
                }
                
            }
        }

        private void aplicaCostos(object sender, EventArgs e)
        {
            for(int i = 1; i < Controls.Count; i++)
            {
                // BUSCAR LOS CONTROLES QUE TENGAN DE NOMBRE LOS NOMBRES DE LOS NODOS
                foreach(NodoP np in grafo)
                {
                    if( ((char)(np.nombre+64)).ToString() == comboBox1.Text )
                    {
                        foreach(Arista nr in np.aristas)
                        {
                            if(Controls[i].Name == ((char)(nr.destino.nombre + 64)).ToString())
                            {
                                try { 
                                    nr.peso = Convert.ToInt32(Controls[i].Text);
                                    i++;
                                }
                                catch
                                {
                                    break;
                                }
                                    
                                    
                            }
                        }
                    }
                }
            }
            button2.Enabled = true;
        }

        private void listo(object sender, EventArgs e)
        {
            foreach(NodoP np in grafo)
            {
                if (((char)(np.nombre + 64)).ToString() == comboBox1.Text)
                {
                    foreach (Arista nr in np.aristas)
                    {
                        MessageBox.Show(((char)(np.nombre + 64)) + " -> " + ((char)(nr.destino.nombre + 64)) + "\n con peso " + nr.peso);
                    }
                }
               
            }
        }
    }
}
