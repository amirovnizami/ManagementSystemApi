using ManagmentSystem.DAL.SqlServer.Context;
using ManagmentSystem.Domain.Entites;
using ManagmentSystem.Repository.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ManagmentSystem.DAL.SqlServer.Infrastructure;
public class SqlCustomerRepository : ICustomerRepository
{
    private readonly AppDbContext _context;

    public SqlCustomerRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Customer customer)
    {
        await _context.Customers.AddAsync(customer);
        await _context.SaveChangesAsync();
    }

    public void Update(Customer customer)
    {
        _context.Customers.Update(customer);
    }

    public async Task<bool> Delete(int id, int deletedBy)
    {
        var customer = _context.Customers.FirstOrDefault(c => c.Id == id);
        if (customer != null)
        {
            customer.IsDeleted = true;
            customer.DeletedBy = deletedBy;
            customer.DeletedDate = DateTime.Now;

            return true;
        }

        return false;
    }

    public IQueryable<Customer> GetAll()
    {
        return _context.Customers.OrderByDescending(c => c.CreatedDate);
    }

    public Task<Customer?> GetByIdAsync(int id)
    {
        return _context.Customers.FirstOrDefaultAsync(c => c.Id == id);
    }

    public Task<IEnumerable<Customer>> GetAllInitialDataAsync()
    {
        return _context.Customers.Where(c => c.IsDeleted == false).ToListAsync()
            .ContinueWith(t => t.Result.AsEnumerable());
    }
}