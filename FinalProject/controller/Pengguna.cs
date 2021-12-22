using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace FinalProject.controller
{
    class Pengguna
    {
        //declare object
        model.PenggunaModel pengguna;
        view.LoginWindow login;
        view.Register register;

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

        public Pengguna(view.Register register)
        {
            pengguna = new model.PenggunaModel();
            this.register = register;
        }

        public void Register()
        {
            pengguna.Email = register.txtName.Text;
            pengguna.username = register.txtUsername.Text;
            pengguna.telp = register.txtNohandphone.Text;
            pengguna.password = register.txtPassword.Password;

            bool result = pengguna.InsertPengguna();
            if(result)
            {
                MessageBox.Show("Pembuatan akun berhasil, silahkan login");
                view.LoginWindow login = new view.LoginWindow();
                login.Show();
                register.Close();
            }else
            {
                MessageBox.Show("gagal membuat akun");
            }
        }


    }
}
