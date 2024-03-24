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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            guna2ProgressBar1.Value = 0;

            await Task.Run(() =>
            {
                for (int i = 0; i <= 100; i++)
                {
                    guna2ProgressBar1.Invoke((MethodInvoker)(() =>
                    {
                        guna2ProgressBar1.Value = i;
                    }));
                    System.Threading.Thread.Sleep(10);

                }
            });
            this.Hide();
            Principal principal = new Principal();
            principal.ShowDialog(null);
            this.Close();
        }
    }
}
