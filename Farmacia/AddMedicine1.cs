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
    public partial class AddMedicine1 : Form
    {
        List List = new List();
        public AddMedicine1()
        {
            InitializeComponent();
        }
        public event EventHandler<string> AbrirForm;
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if(guna2TextBox1.Text.Trim() == "" || guna2TextBox2.Text.Trim() == "" || guna2TextBox3.Text.Trim() == "")
            {
                MessageBox.Show("Um ou mais campos se encontra vazio, preencha para continuar");
            }
            else
            {
                int index = guna2ComboBox1.SelectedIndex;
                List.Add(Convert.ToInt32(guna2TextBox2.Text), guna2TextBox1.Text, index, Convert.ToDouble(guna2TextBox4.Text), Convert.ToInt32(guna2TextBox3.Text));
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza que deseja cancelar?", "Confirmação", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                AbrirForm?.Invoke(this, "MedicineList");
            }

        }

        private void AddMedicine1_Load(object sender, EventArgs e)
        {
            List.ListCombobox(guna2ComboBox1);
        }
    }
}
