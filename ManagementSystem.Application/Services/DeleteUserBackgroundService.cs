using ManagementSystem.Repository.Common;
using ManagmentSystem.Common.Exceptions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ManagementSystem.Application.Services;

public class DeleteUserBackgroundService(IServiceScopeFactory scopeFactory) : BackgroundService
{
    private readonly IServiceScopeFactory _scopeFactory = scopeFactory;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                using var scope = _scopeFactory.CreateScope();
                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                var userDelete = unitOfWork.UserRepository.GetAll()
                    .Where(u => u.CreatedDate == null && u.IsDeleted == false).ToList();
                if (userDelete.Any())
                {
                    foreach (var user in userDelete)
                    {
                        user.IsDeleted = true;
                        user.DeletedBy = user.Id;
                        user.DeletedDate = DateTime.Now;
                    }

                    await unitOfWork.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw new BadRequestException(e.Message);
            }

            await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
        }
    }
}