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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UsersApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ApplicationContext db;

        public MainWindow()
        {
            InitializeComponent();
            db = new ApplicationContext();
            ShowAuthWindow();
        }

        private void ShowAuthWindow()
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            Hide();
        }


        private void Button_Auth_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string pass = passBox.Password.Trim();

            int k = 1;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string pass = passBox.Password.Trim();
            string pass_2 = passBox_2.Password.Trim();
            string email = textBoxEmail.Text.Trim().ToLower();
            int a = 1;

            if(login.Length < 5)
            {
                textBoxLogin.ToolTip = "Це поле невірно!";
                textBoxLogin.Background = Brushes.LightPink;
                a = 0;
            } else
            {
                textBoxLogin.ToolTip = " ";
                textBoxLogin.Background = Brushes.Transparent;
            }
            if (pass.Length < 5)
            {
                passBox.ToolTip = "Це поле невірно!";
                passBox.Background = Brushes.LightPink;
                a = 0;
            }
            else
            {
                passBox.ToolTip = " ";
                passBox.Background = Brushes.Transparent;
            }
            if (pass != pass_2)
            {
                passBox_2.ToolTip = "Паролі не співпадають";
                passBox_2.Background = Brushes.LightPink;
                a = 0;
            }
            else
            {
                passBox_2.ToolTip = " ";
                passBox_2.Background = Brushes.Transparent;
            }
            if (email.Length < 5 || !email.Contains("@") || !email.Contains("."))
            {
                textBoxEmail.ToolTip = "Це поле невірно!";
                textBoxEmail.Background = Brushes.LightPink;
                a = 0;
            }
            else
            {
                textBoxEmail.ToolTip = " ";
                textBoxEmail.Background = Brushes.Transparent;
            }

            if (a == 1)
            {
                MessageBox.Show("Все добре!");
                User user = new User(login, email, pass);
                db.Users.Add(user);
                db.SaveChanges();

                AuthWindow authWindow = new AuthWindow();
                authWindow.Show();
                Hide();
            }
        }
        private void Button_Window_Auth_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            Hide();
        }
    }
}
