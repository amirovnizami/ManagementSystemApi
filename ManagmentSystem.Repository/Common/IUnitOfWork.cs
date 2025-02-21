using ManagmentSystem.Repository.Repositories;

namespace ManagmentSystem.Repository.Common;

public interface IUnitOfWork
{
    public ICategoryRepository CategoryRepository { get;}
    public ICustomerRepository CustomerRepository { get;}
    public IUserRepository UserRepository { get;}
}