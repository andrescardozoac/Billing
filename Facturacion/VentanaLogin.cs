using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Milibreria2;

using System.Data.SqlClient; //importar espacio de nombre para realizar la conexion a la BD

namespace Facturacion
{
    public partial class VentanaLogin : FormBase //Heredando del formulario form Base 
    {
        public VentanaLogin()
        {
            InitializeComponent();
         

        }


        public static string codigo;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                string cadena = string.Format("Select * from Usuarios where account = '{0}' and password = '{1}'",txtCuenta.Text.Trim(),txtPass.Text.Trim()); //el string formar es para pasarle por parametro la cadena que yo quiero por lo que esta en '{}'
                //el .trim es para quitar los espacios
                DataSet ds = Utilidades.Ejecutar(cadena); //devuelve el dataset del metodo estatico ejecutar y lo guardo en ds

                //como solo devuelve uno la fila es 0
                string cuenta = ds.Tables[0].Rows[0]["account"].ToString().Trim(); //almacena el nombre de la cuenta que el dataset devolvio
                string password = ds.Tables[0].Rows[0]["password"].ToString().Trim();
                codigo = ds.Tables[0].Rows[0]["id_usuario"].ToString().Trim();

                if (cuenta == txtCuenta.Text.Trim() && password == txtPass.Text.Trim())
                {

                   if (Convert.ToBoolean(ds.Tables[0].Rows[0]["status_admin"]) == true)
                    {
                        
                        ContenedorPrincipal cp = new ContenedorPrincipal();
                        this.Hide();
                        cp.Show();

                        
                    
                        
                    }
                    else
                    {

                        ContenedorPrincipal cp = new ContenedorPrincipal();
                        this.Hide();
                        cp.Show();

                        Facturacion fac = new Facturacion();
                        fac.MdiParent = this;
                        fac.Show();

                    }

                   

                }
              


            }
            catch (Exception error) {

                // MessageBox.Show("Error : "+error.Message);
                
                MessageBox.Show("Usuario o contraseña incorrecta");
            }


        }

      
        private void VentanaLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


       

        private void VentanaLogin_Load(object sender, EventArgs e)
        {
            this.txtCuenta.Focus();

        }

        private void txtCuenta_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {

        }
    }
}
