using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace ComercioWIN
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Usuarios user = new Usuarios();
            user.user = txtUser.Text;
            user.pass = txtPass.Text;
            UsuarioNegocio nego = new UsuarioNegocio();
            int num = nego.Datos(user);
            if (num==0)
            {
                this.Visible = false;
                Form1 frm = new Form1();
                frm.Show();
            }else if (num==1)
            {
                MessageBox.Show("contraseña incorrecto");
            }
            else if(num==2)
            {
                MessageBox.Show("Usuario Bloqueado");
            }


        }

        public void visible(bool estado)
        {
            if(estado)
            {
                this.Visible = true;
            }
            else
            {
                this.Visible = false; 
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                btnAceptar_Click(this, new EventArgs());
            }
        }

        private void txtUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                    SendKeys.Send("{TAB}");
            }
        }
    }
}
