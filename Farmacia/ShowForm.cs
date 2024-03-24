using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    }
}
