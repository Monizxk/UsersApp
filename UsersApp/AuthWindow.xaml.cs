﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace UsersApp
{
    /// <summary>
    /// Interaction logic for AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void Button_Auth_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string pass = passBox.Password.Trim();

            int k = 1;

            if (login.Length < 5)
            {
                textBoxLogin.ToolTip = "Це поле невірно!";
                textBoxLogin.Background = Brushes.LightPink;
                k = 0;
            }
            else
            {
                textBoxLogin.ToolTip = " ";
                textBoxLogin.Background = Brushes.Transparent;
            }
            if (pass.Length < 5)
            {
                passBox.ToolTip = "Це поле невірно!";
                passBox.Background = Brushes.LightPink;
                k = 0;
            }
            else
            {
                passBox.ToolTip = " ";
                passBox.Background = Brushes.Transparent;
            }
            if (k == 1)
            {
                User authUser = null;
                using (ApplicationContext db = new ApplicationContext())
                {
                    authUser = db.Users.Where(b => b.Login == login && b.Pass == pass).FirstOrDefault();
                }
                if (authUser != null)
                {
                    MessageBox.Show("Все добре!");
                    UserPageWindow userPageWindow = new UserPageWindow();
                    userPageWindow.Show();
                    Hide();
                }
                else MessageBox.Show("Не авторизовано. Повторіть спробу ще раз!");
            }
        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
           MainWindow mainWindow = new MainWindow();
           mainWindow.Show();
           Hide();
        }

        private void examplText_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

