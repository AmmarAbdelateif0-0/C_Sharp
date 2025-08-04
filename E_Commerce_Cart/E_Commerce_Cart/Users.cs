using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Cart
{
    public class User
    {
        private string name;
        private string email;
        private string password;
        private char flag;

        public string Name{
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }
        public string Email {
            get
            {
                return this.email;
            }
        }

        public string Password
        {
            set
            {
                this.password = value;
            }
        }

        public char Role => this.flag;
        public User(string Name , string Email , string Password)
        {
            this.name = Name;
            this.email = CheckEmail(Email)  ? Email : throw new ArgumentException("Invalid email domain.");
            this.password = Password;
        }

        private bool CheckEmail(string Email)
        {
            string[] parts = Email.Split('@');
            
            if(parts.Length != 2)
            {
                return false;
            }
            string domain = parts[1];
            if (domain == "admin.com")
            {
                this.flag = 'a';
                return true;
            } else if(domain == "user.com")
            {
                this.flag = 'u';
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckPassword(string input) => this.password == input;


    }
}

