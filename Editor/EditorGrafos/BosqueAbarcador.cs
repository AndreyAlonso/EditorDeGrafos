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
    public partial class BosqueAbarcador : Form
    {
        public BosqueAbarcador()
        {
            InitializeComponent();
        }

        private void BosqueAbarcador_Resize(object sender, EventArgs e)
        {
            groupBox1.Location = new Point(ClientSize.Width-250, ClientSize.Height-266);
        }
    }
}
