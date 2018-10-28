using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditorGrafos
{
    public partial class MuestraCadena : Form
    {
        string nombre;
        string cadena;
        public bool band;
        public MuestraCadena(string nombre, string cadena, System.Windows.Forms.Timer timer)
        {
            this.nombre = nombre;
            this.cadena = cadena;
            InitializeComponent();
            
        }

        private void MuestraCadena_Load(object sender, EventArgs e)
        {
           
            label1.Text = nombre;
            textBox1.Text = cadena;
            band = false;
          
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            
        }

        public bool activa()
        {
            return band;
        }

        public void MuestraCadena_FormClosing(object sender, FormClosingEventArgs e)
        {
         //   e.Cancel = true;
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
