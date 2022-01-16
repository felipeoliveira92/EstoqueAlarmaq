using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueAlarmaq.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }
        
        public User(string name, string password, string type)
        {
            Name = name;
            Password = password;
            Type = type;
        }

    }
}
