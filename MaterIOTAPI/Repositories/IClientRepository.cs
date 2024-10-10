using MaterIOTAPI.Collections;

namespace MaterIOTAPI.Repositories;

public interface IClientRepository
{
    Task<List<Client>> GetAllAsync();
    Task<Client> GetByIdAsync(string id);
    Task CreateAsync(Client client);
    Task UpdateAsync(Client client);
    Task DeleteAsync(string id);
}