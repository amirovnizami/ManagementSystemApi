using ManagmentSystem.Domain.Entites;

namespace ManagmentSystem.Repository.Repositories;

public interface ICustomerRepository
{
    Task AddAsync(Customer customer);
    void Update(Customer customer);
    Task<bool> Delete(int id, int deletedBy);
    IQueryable<Customer> GetAll();
    Task<Customer?> GetByIdAsync(int id);

    Task<IEnumerable<Customer>> GetAllInitialDataAsync();
}