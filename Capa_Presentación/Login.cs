using Capa_Negocio;
using System;
using System.Windows.Forms;

namespace Capa_Presentación
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CRUD crud = new CRUD();
            Login login = new Login();
            if (txtUser.Text != "")
            {
                if (txtPass.Text != "")
                {
                    UserModel user = new UserModel();
                    var validLogin = user.LoginUser(txtUser.Text, txtPass.Text);
                    if (validLogin == true)
                    {
                        //Show the main form and hide the Login form
                        crud.Show();
                        login.Close();
                    }
                    else
                    {
                        msgError("Wrong username or password. \n Please, try again!");
                        txtPass.Clear();
                        txtUser.Clear();
                        txtUser.Focus();
                    }
                }
                else msgError("Please enter your password.");
            }
            else msgError("Please enter your username.");
        }

        // Error message function
        private void msgError(string msg)
        {
            lblErrorMessage.Text = "     " + msg;
            lblErrorMessage.Visible = true;
        }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                button1_Click(sender, e);
            }

        }

        private void txtPass_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                button1_Click(sender, e);
            }
        }
    }
}
