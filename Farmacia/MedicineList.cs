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
        AddMedicine add = new AddMedicine();
        public MedicineList()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            addMedicine1.Visible = true;
        }

        private void MedicineList_Load(object sender, EventArgs e)
        {
        }
    }
}
