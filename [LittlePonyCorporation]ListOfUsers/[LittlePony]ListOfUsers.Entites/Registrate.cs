using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _LittlePony_Entites
{
    public class Registrate
    {
        private string login, password;
        public int RoleId;

        public Registrate(string login, string password, int role)
        {
            Login = login;
            Password = password;
            RoleId = role;
        }

        public string Login
        {
            get { return login; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception();
                }
                login = value;
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                { throw new Exception(); }
                else
                { password = value; }
            }
        }
    }
}