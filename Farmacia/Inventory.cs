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
    public partial class Inventory : Form
    {
        public Inventory()
        {
            InitializeComponent();
        }
        public event EventHandler<string> AbrirForm;

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            AbrirForm?.Invoke(this, "MedicineList");
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            AbrirForm?.Invoke(this, "Category");
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            AbrirForm?.Invoke(this, "OutOfDate");
        }
    }
}
