using ManagementSystem.DAL.SqlServer.Context;
using ManagementSystem.DAL.SqlServer.Infrastructure;
using ManagementSystem.Repository.Common;
using ManagementSystem.Repository.Repositories;

namespace ManagementSystem.DAL.SqlServer.UnitOfWork.SqlUnitOfWork;

public class SqlUnitOfWork(string connectionString, AppDbContext context) : IUnitOfWork
{
    private readonly string _connectionString = connectionString;
    private readonly AppDbContext _context = context;

    public SqlCategoryRepository _categoryRepository;
    public SqlCustomerRepository _customerRepository;
    public SqlUserRepository _userRepository;
    public SqlCarRepository _carRepository;


    public ICategoryRepository CategoryRepository =>
        _categoryRepository ?? new SqlCategoryRepository(_connectionString, _context);


    public ICustomerRepository CustomerRepository => _customerRepository ?? new SqlCustomerRepository(_context);
    public IUserRepository UserRepository => _userRepository ?? new SqlUserRepository(_context);
    public ICarRepository CarRepository => _carRepository ?? new SqlCarRepository(_context);
    public Task<int> SaveChangesAsync()
    {
        throw new NotImplementedException();
    }

    public async  Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return  _context.SaveChanges();
    }
}