using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS_RAW_.BL
{
    class Credential
    {
        private string name =" ";
        public string Name { get => name; set => name = value; }

        private string password =" ";
        public string Password { get => password; set => password = value; }
        private string role=" ";
        public string Role { get => role; set => role = value; }
        public Credential()
        {

        }
        public Credential(string name, string password)
        {
            this.Name = name;
            this.Password = password;
        }
        public Credential( string password)
        {
            this.Password = password;
        }
        public Credential(string name, string password, string role)
        {
            this.Name = name;
            this.Password = password;
            this.Role = role;
        }
       
    }
}
