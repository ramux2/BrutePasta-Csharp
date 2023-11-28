using BrutePasta.Data;
using BrutePasta.Interfaces;
using BrutePasta.Models;
using Microsoft.EntityFrameworkCore;

namespace BrutePasta.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly BrutePastaDbContext _clientContext;

        public ClientRepository(BrutePastaDbContext context) 
        { 
            _clientContext = context;
        }

        public async Task<Client> GetClientByEmail(string? email)
        {
            return await _clientContext.Client.FirstOrDefaultAsync(x => x.Email == email);
        }
        public async Task<Client> Create(Client client)
        {
            _clientContext.Add(client);
            await _clientContext.SaveChangesAsync();
            return client;
        }

        public async Task<Client> GetClientById(int? id)
        {
            return await _clientContext.Client.FindAsync(id);
        }

        public async Task<Client> GetClientByCpf(string? cpf)
        {
            return await _clientContext.Client.FirstOrDefaultAsync(x => x.Cpf == cpf);
        }

        public async Task<Client> Remove(Client client)
        {
            _clientContext.Remove(client);
            await _clientContext.SaveChangesAsync();
            return client;
        }

        public async Task<Client> Update(Client client)
        {
            _clientContext.Update(client);
            await _clientContext.SaveChangesAsync();
            return client;
        }
    }
}
