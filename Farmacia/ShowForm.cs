using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace Farmacia
{
    class ShowForm
    {
        public void Mostrar(Form form, Form atual)
        {
            foreach (Form f in atual.MdiChildren)
            {
                f.Hide();
            }
            form.MdiParent = atual;
            form.Show();
        }
        public void Form(Form form1, Guna2Button button1, Guna2Button button2, Guna2Button button3)
        {
            foreach (Form form in form1.MdiChildren)
            {
                if (form.Visible)
                {
                    if (button1 != null && button2 != null && button3 != null)
                    {
                        Active(button1, button2, button3);
                    }
                    break; 
                }
            }
        }

        public void Active(Guna2Button button1, Guna2Button button2, Guna2Button button3)
        {
            if (button1 != null)
            {
                button1.Checked = false;
            }
            if (button2 != null)
            {
                button2.Checked = false;
            }
            if (button3 != null)
            {
                button3.Checked = false;
            }
        }
    }
}
