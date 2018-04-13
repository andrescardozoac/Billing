﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Milibreria2;

namespace Facturacion
{
    public partial class ConsultarClientes : Consultas
    {
        public ConsultarClientes()
        {
            InitializeComponent();
        }

        private void ConsultarClientes_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = LlenarDataGV("Cliente").Tables[0];

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text.Trim()) == false) {

                try
                {


                    DataSet ds;
                    string cmd = "select * from cliente where nom_cli like ('%" + textBox1.Text.Trim() + "%')";
                    ds = Utilidades.Ejecutar(cmd);
                    dataGridView1.DataSource = ds.Tables[0];

                }
                catch (Exception error) {
                    MessageBox.Show("Ha ocurrido un error: "+ error.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
