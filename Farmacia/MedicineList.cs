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
    public partial class MedicineList : Form
    {
        List list = new List();
        public MedicineList()
        {
            InitializeComponent();
        }
        public event EventHandler<string> AbrirForm;

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            AbrirForm?.Invoke(this, "AddMedicine1");
        }

        private void MedicineList_Load(object sender, EventArgs e)
        {
            list.See(guna2DataGridView1);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            AbrirForm?.Invoke(this, "EditMedicine");
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            list.Search(guna2Button1.Text, guna2DataGridView1);
        }
    }
}
