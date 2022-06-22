using EstoqueAlarmaq.Domain;
using System.Collections.Generic;

namespace EstoqueAlarmaq.Services.Interfaces
{
    public interface IClientRepository
    {
        Client GetClientById(int id);
        Client GetClientByName(string name);
        List<Client> GetAllClients();
        void Save(Client client);
        void Update(int id, Client client);
        void Delete(int id);
        void Dispose();
    }
}
