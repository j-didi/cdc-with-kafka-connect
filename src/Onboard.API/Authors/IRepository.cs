namespace Onboard.API.Authors;

public interface IRepository
{
    Task<IEnumerable<Author>> GetAll();
    Task<Author> GetById(int id);
    Task Save(Author author);
    Task Update(Author author);
    Task Delete(int id);
}