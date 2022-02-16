using EstoqueAlarmaq.Domain;
using EstoqueAlarmaq.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueAlarmaq.Services.Interfaces
{
    public interface IUserRepository
    {
        User New();
        void Insert(User user);

        void Update(int id, User user);

        IEnumerable<User> SelectAll();

        User Select(int id);

        void Delete(int id);
    }
}
