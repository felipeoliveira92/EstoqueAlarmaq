using EstoqueAlarmaq.Domain;
using EstoqueAlarmaq.Infra.Data;
using EstoqueAlarmaq.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace EstoqueAlarmaq.Services.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly DataContext _context;

        public LoginRepository()
        {
            _context = new DataContext();
        }
        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User GetUserById(int idUser)
        {
            if (idUser != 0)
                return _context.Users.FirstOrDefault(u => u.Id == idUser);
            else
                return null;
        }

        public User GetUserByName(string nameUser)
        {
            if (!string.IsNullOrEmpty(nameUser))
                return _context.Users.FirstOrDefault(u => u.Name == nameUser);
            else
                return null;
        }

        public bool Login(string login, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Login == login);

            if(user != null)
            {
                if(user.Password == password)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
