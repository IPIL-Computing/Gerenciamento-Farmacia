using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Farmacia
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
        }
        public event EventHandler<string> AbrirForm;

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            AbrirForm?.Invoke(this, "Inventory");
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            AbrirForm?.Invoke(this, "OutOfDate");
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            AbrirForm?.Invoke(this, "Inventory");
        }
    }
}
