using EstoqueAlarmaq.Domain;
using System.Collections.Generic;

namespace EstoqueAlarmaq.Services.Interfaces
{
    public interface ILoginRepository
    {
        User GetUserById(int idUser);
        User GetUserByName(string nameUser);
        List<User> GetAllUsers();
        bool Login(string login, string password);
    }
}
