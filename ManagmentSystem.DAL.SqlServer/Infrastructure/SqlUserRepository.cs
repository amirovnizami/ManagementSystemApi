using ManagmentSystem.Common.Exceptions;
using ManagmentSystem.DAL.SqlServer.Context;
using ManagmentSystem.Domain.Entites;
using ManagmentSystem.Repository.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ManagmentSystem.DAL.SqlServer.Infrastructure;

public class SqlUserRepository(AppDbContext context) : IUserRepository
{
    private readonly AppDbContext _context = context;

    public async Task RegisterAsync(User user)
    {
        user.CreatedDate = DateTime.Now;
        user.CreatedBy = 1;
        await  _context.Users.AddAsync(user);
    }

    public async void Update(User user)
    {
        user.UpdatedDate = DateTime.Now;
        user.UpdatedBy = 1;
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }

    public void Remove(int id)
    {
        var currentUser = _context.Users.FirstOrDefault(u => u.Id == id);
        if (currentUser == null)
        {
            throw new BadRequestException("User not found");
        }
        _context.Users.Remove(currentUser);
        currentUser.IsDeleted = true;
        currentUser.DeletedDate = DateTime.Now;
        currentUser.DeletedBy = 1;
        _context.Users.Update(currentUser);
        _context.SaveChanges();
    }

    public List<User> GetAll()
    {
        return _context.Users.Where(u=>u.IsDeleted == false).ToList();
    }

    public Task<User> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<User> GetByEmailAsync(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(u=>u.Email == email && u.IsDeleted == false);
    }
}