using EstoqueAlarmaq.Domain;
using EstoqueAlarmaq.Infra.Data;
using EstoqueAlarmaq.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueAlarmaq.Services.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            _context.Remove(id);
            _context.SaveChanges();
        }

        public void Insert(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public User New()
        {
            User user = new User();
            return user;
        }

        public User Select(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);

        }

        public IEnumerable<User> SelectAll()
        {
            return _context.Users.ToList();
        }

        public void Update(int id, User user)
        {
            user.Id = id;
            _context.Update(user);
            _context.SaveChanges();
        }
    }
}
