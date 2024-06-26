﻿using System;
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
        MedicineList lista = new MedicineList();
        Category categoria = new Category();
        ShowForm show = new ShowForm();
        OutOfDate expirado = new OutOfDate();
        AddMedicine1 add = new AddMedicine1();
        AddCategory addC = new AddCategory();
        EditMedicine edit = new EditMedicine();
        public Principal()
        {
            InitializeComponent();
            show.Mostrar(dashboard, this);
            dashboard.AbrirForm += Abrir;
            categoria.AbrirForm += Abrir;
            estoque.AbrirForm += Abrir;
            lista.AbrirForm += Abrir;
            addC.AbrirForm += Abrir;
            add.AbrirForm += Abrir;
        }

        public void Abrir(object sender, string nome)
        {
            switch (nome)
            {
                case "Inventory":
                    show.Mostrar(estoque, this);
                    show.Form(estoque, guna2Button1, null, null);
                    guna2Button2.Checked = true;
                    break;
                case "OutOfDate":
                    show.Mostrar(expirado, this);
                    guna2Button5.Checked = true;
                    guna2Button1.Checked = false;
                    menuExpand = false;
                    timer1.Start(); 
                    break;
                case "MedicineList":
                    show.Mostrar(lista, this);
                    show.Active(guna2Button1, guna2Button2, null);
                    guna2Button3.Checked = true;
                    menuExpand = false;
                    timer1.Start();
                    break;
                case "Category":
                    show.Mostrar(categoria, this);
                    guna2Button2.Checked = false;
                    guna2Button4.Checked = true;
                    menuExpand = false;
                    timer1.Start();
                    break;
                case "AddMedicine1":
                    show.Mostrar(add, this);
                    break;
                case "AddCategory":
                    show.Mostrar(addC, this);
                    break;
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            timer1.Start();
            show.Active(guna2Button3, guna2Button4, guna2Button5);
            show.Mostrar(estoque, this);
        }
        bool menuExpand = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
           if(menuExpand == false)
            {
                flowLayoutPanel1.Height += 10;
                if(flowLayoutPanel1.Height >= 171)
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
        


        private void guna2Button1_Click(object sender, EventArgs e)
        {
            show.Active(guna2Button3, guna2Button4, guna2Button5);
            show.Mostrar(dashboard, this);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            show.Active(guna2Button1, guna2Button2, null);
            show.Mostrar(lista, this);
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            show.Active(guna2Button1, guna2Button2, null);
            show.Mostrar(categoria, this);
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            show.Active(guna2Button1, guna2Button2, null);
            show.Mostrar(expirado, this);
        }
    }
}
