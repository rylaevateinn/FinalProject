using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FinalProject.controller
{
    class Pengguna
    {
        //declare object
        model.PenggunaModel pengguna;
        view.LoginWindow login;

        //instance
        public Pengguna(view.LoginWindow login)
        {
            pengguna = new model.PenggunaModel();
            this.login = login;
        }

        public void Login()
        {
            pengguna.username = login.txtUsername.Text;
            pengguna.password = login.txtPassword.Password;
            bool result = pengguna.CekLogin();
            if (result)
            {
                view.MainWindow main = new view.MainWindow();
                main.Show();
                login.Close();
            }
            else
            {
                MessageBox.Show("Maaf username atau password salah");
                login.txtUsername.Text = "";
                login.txtPassword.Password = "";
                login.txtUsername.Focus();
            }

        }
    }
}
