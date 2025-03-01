using System.Reflection;
using AutoMapper;
using FluentValidation;
using ManagementSystem.Application.AutoMapper;
using ManagementSystem.Application.PipelineBehaviours;
using ManagementSystem.Application.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ManagementSystem.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        var mapperConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new MappingProfile());
        });

        IMapper mapper = mapperConfig.CreateMapper();
        services.AddSingleton(mapper);
        services.AddMediatR(Assembly.GetExecutingAssembly());
        
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehaviour<,>));
        services.AddHostedService<DeleteUserBackgroundService>();
        return services;
    }
}