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
        public void Mostra(Form form, Form atual, EventHandler<string> eventoAbrirFormulario)
        {
            // Oculta todos os formulários filhos atualmente abertos
            foreach (Form f in atual.MdiChildren)
            {
                f.Hide();
            }

            // Associa o formulário pai ao formulário filho
            form.MdiParent = atual;

            // Aciona o evento para notificar o formulário pai sobre o formulário a ser aberto
            eventoAbrirFormulario?.Invoke(this, form.Name);

            // Exibe o formulário filho
            form.Show();
        }

    }
}
