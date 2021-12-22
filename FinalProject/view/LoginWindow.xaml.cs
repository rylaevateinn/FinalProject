using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FinalProject.view
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        //declare object
        controller.Pengguna pengguna;
        public LoginWindow()
        {
            InitializeComponent();
            //instance
            pengguna = new controller.Pengguna(this);
            //Model.ModelTemplate cek = new Model.ModelTemplate();
            //cek.cekKoneksi();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            pengguna.Login();
        }

        private void lblCreateAccount_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Register register = new Register();
            register.Show();
            this.Close();
        }
    }
}
