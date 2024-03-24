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

        public Principal()
        {
            InitializeComponent();
        }
        bool menuExpand = false;

        public void Principal_Load_1(object sender, EventArgs e)
        {
            dashboard1.BringToFront();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (menuExpand == false)
            {
                flowLayoutPanel1.Height += 5;
                if (flowLayoutPanel1.Height >= 113)
                {
                    timer1.Stop();
                    menuExpand = true;
                }
            }
            else
            {
                flowLayoutPanel1.Height -= 5;
                if (flowLayoutPanel1.Height <= 0)
                {
                    timer1.Stop();
                    menuExpand = false;
                }
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            timer1.Start();
            Off(guna2Button3, guna2Button4);
            estoque1.BringToFront();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Off(guna2Button1, guna2Button2);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Off(guna2Button3, guna2Button4);
            dashboard1.BringToFront();
        }
        public void Off(Guna2Button botao1, Guna2Button botao2)
        {
            botao1.Checked = false;
            botao2.Checked = false;
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Off(guna2Button1, guna2Button2);
        }
       
    }
}
