using ManagementSystem.Domain.Entites;

namespace ManagementSystem.Repository.Repositories;

public interface IUserRepository
{
    Task RegisterAsync(User user);
    void Update(User user); 
    void Remove(int id);
    List<User> GetAll();
    Task<User> GetByIdAsync(int id);
    Task<User> GetByEmailAsync(string email);
}