using Dapper;
using Npgsql;

namespace Onboard.API.Authors;

public class Repository : IRepository
{

    private readonly NpgsqlConnection _connection;
    
    public Repository(IConfiguration config)
    {
        var connectionString = config.GetConnectionString("onboard");
        _connection = new NpgsqlConnection(connectionString);
    }

    public async Task<IEnumerable<Author>> GetAll()
    {
        await _connection.OpenAsync();
        var result = await _connection.QueryAsync<Author>("SELECT * FROM author");
        await _connection.CloseAsync();
        return result;
    }

    public async Task<Author> GetById(int id)
    {
        await _connection.OpenAsync();
        var query = $"SELECT * FROM author WHERE id = {id}";
        var result = await _connection.QueryFirstOrDefaultAsync<Author>(query);
        await _connection.CloseAsync();
        return result;
    }


    public async Task Save(Author author)
    {
        await _connection.OpenAsync();

        const string query = 
            @"INSERT INTO author
                (name, cpf, email, phone) 
            VALUES
                (@Name, @Cpf, @Email, @Phone);"; 
        
        await _connection.ExecuteAsync(query, author);
        await _connection.CloseAsync();
    }

    public async Task Update(Author author)
    {
        await _connection.OpenAsync();

        const string query = 
            @"UPDATE author SET
                name = @Name,
                cpf = @Cpf,
                email = @Email,
                phone = @Phone
            WHERE
                id = @Id"; 
        
        await _connection.ExecuteAsync(query, author);
        await _connection.CloseAsync();
    }

    public async Task Delete(int id)
    {
        await _connection.OpenAsync();
        await _connection.ExecuteAsync($"DELETE FROM author WHERE id = {id}");
        await _connection.CloseAsync();
    }
}