﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersApp
{
    internal class User
    {
        public int id { get; set; }
        private string login, email, pass;

        public string Login
        {
            get { return login; }
            set { login = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Pass
        {
            get { return pass; }
            set { pass = value; }
        }

        public User() { 
        }

        public User(string login, string email, string pass)
        {
            this.Login = login;
            this.Email = email;
            this.Pass = pass;
        }
    }
}
