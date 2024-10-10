using MaterIOTAPI.Collections;
using MongoDB.Driver;

namespace MaterIOTAPI.Repositories;

public class ClientRepository : IClientRepository
{
    private readonly IMongoCollection<Client> _collection;
    public ClientRepository(IMongoDatabase mongoDatabase)
    {
        _collection = mongoDatabase.GetCollection<Client>("clientes");
    }

    public async Task CreateAsync(Client client) =>
        await _collection.InsertOneAsync(client);

    public async Task DeleteAsync(string id) =>
        await _collection.DeleteOneAsync(c => c.Id == id);

    public async Task<List<Client>> GetAllAsync() =>
        await _collection.Find(c => true).ToListAsync();

    public async Task<Client> GetByIdAsync(string id) =>
        await _collection.Find(c => c.Id == id).FirstOrDefaultAsync();

    public async Task UpdateAsync(Client client) =>
        await _collection.ReplaceOneAsync(c => c.Id == client.Id, client);
}