using BrutePasta.Models;

namespace BrutePasta.Interfaces
{
    public interface IClientRepository
    {
        Task<Client> GetClientById(int? id);
        Task<Client> GetClientByEmail(string? email);
        Task<Client> GetClientByCpf(string? cpf);
        Task<Client> Create(Client client);
        Task<Client> Update(Client client);
        Task<Client> Remove(Client client);
    }
}
