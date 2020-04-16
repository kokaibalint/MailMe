﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MailMe.Models
{
    public class User
    {
        public string email { get; set; }
        public string password { get; set; }

        public User(string email, string password)
        {
            this.email = email;
            this.password = password;
        }
    }
}
