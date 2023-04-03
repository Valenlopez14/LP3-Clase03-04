using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MUNDO__2023_04_03_
{
    public partial class Form1 : Form
    {
        Paises p = new Paises();
        public Form1()
        {
            InitializeComponent();
           
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            p.Pais = Convert.ToInt32(txtPais.Text);
            p.Nombre = txtNombre.Text;
            p.Capital = txtCapital.Text;

            p.grabar();

            if(p.Pais == 0)
            {
                MessageBox.Show("PAIS REPETIDO, NO SE PUDO GRABAR", "ERROR");
            } else
            {
                txtPais.Text = "";
                txtNombre.Text = "";
                txtCapital.Text = "";

                txtPais.Focus();

            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            p.Pais = Convert.ToInt32(txtPais.Text);
            p.buscar();
            if(p.Pais==0)
            {
                MessageBox.Show("NO EXISTE EL PAIS QUE ESTA CONSULTANDO", "ERROR");
            } else
            {
                txtNombre.Text = p.Nombre;
                txtCapital.Text = p.Capital;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            grilla.DataSource = p.getAll();
            grilla.AutoResizeColumns();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            p.Pais = Convert.ToInt32(txtPais.Text);
            p.eliminar();
            txtPais.Text = "";
            txtNombre.Text = "";
            txtCapital.Text = "";

            txtPais.Focus();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            p.Pais = Convert.ToInt32(txtPais.Text);
            p.Nombre = txtNombre.Text;
            p.Capital = txtCapital.Text;
            p.modificar();
            txtPais.Text = "";
            txtNombre.Text = "";
            txtCapital.Text = "";

            txtPais.Focus();
        }
    }
}
