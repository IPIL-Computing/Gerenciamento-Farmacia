using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace Farmacia
{
    public partial class Principal : Form
    {
        Dashboard dashboard = new Dashboard();
        Inventory estoque = new Inventory();
        public Principal()
        {
            InitializeComponent();
            ShowForm(dashboard);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            timer1.Start();
            Active(guna2Button3, guna2Button4);
            ShowForm(estoque);
        }
        bool menuExpand = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
           if(menuExpand == false)
            {
                flowLayoutPanel1.Height += 10;
                if(flowLayoutPanel1.Height >= 120)
                {
                    timer1.Stop();
                    menuExpand = true;
                }
            }
            else
            {
                flowLayoutPanel1.Height -= 10;
                if(flowLayoutPanel1.Height <= 0)
                {
                    timer1.Stop();
                    menuExpand = false;
                }
            }
        }
        public void Active(Guna2Button button1, Guna2Button button2)
        {
            button1.Checked = false;
            button2.Checked = false;
        }
        public void ShowForm(Form form)
        {
            foreach (Form f in this.MdiChildren)
            {
                f.Hide();
            }
            form.MdiParent = this;
            form.Show();
        }


        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Active(guna2Button3, guna2Button4);
            ShowForm(dashboard);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Active(guna2Button1, guna2Button2);
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Active(guna2Button1, guna2Button2);
        }
    }
}
