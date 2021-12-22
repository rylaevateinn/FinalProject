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
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        //deklarasi kontroller
        controller.Pengguna pengguna;

        public Register()
        {
            InitializeComponent();
            pengguna = new controller.Pengguna(this);
        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            LoginWindow login = new LoginWindow();
            login.Show();
            this.Close();

        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            if(txtPassword.Password != txtConfirmPassword.Password)
            {
                MessageBox.Show("password tidak sama");
            }else
            {
                pengguna.Register();
            }

            
        }
    }
}
