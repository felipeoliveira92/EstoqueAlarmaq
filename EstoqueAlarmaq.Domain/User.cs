﻿namespace EstoqueAlarmaq.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }
        
        public User(string name, string password, string type)
        {
            Name = name;
            Password = password;
            Type = type;
        }

        public User()
        {

        }

    }
}
