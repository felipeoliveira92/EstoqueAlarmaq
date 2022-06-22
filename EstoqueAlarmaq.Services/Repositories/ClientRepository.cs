using EstoqueAlarmaq.Domain;
using EstoqueAlarmaq.Infra.Data;
using EstoqueAlarmaq.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace EstoqueAlarmaq.Services.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly DataContext _context;

        public ClientRepository()
        {
            _context = new DataContext();
        }

        public void Delete(int id)
        {
            if(id != 0)
            {
                var client = _context.Clients.Find(id);
                _context.Clients.Remove(client);
                _context.SaveChanges();
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public List<Client> GetAllClients()
        {
            return _context.Clients.ToList();
        }

        public Client GetClientById(int id)
        {
            if (id != 0)
                return _context.Clients.Find(id);
            return null;
        }

        public Client GetClientByName(string name)
        {
            if (!string.IsNullOrEmpty(name))
                return _context.Clients.Find(name);
            return null;
        }

        public void Save(Client client)
        {
            _context.Clients.Add(client);
            _context.SaveChanges();
        }

        public void Update(int id, Client client)
        {
            if(id == client.Id)
            {
                _context.Clients.Update(client);
                _context.SaveChanges();
            }
        }
    }
}
