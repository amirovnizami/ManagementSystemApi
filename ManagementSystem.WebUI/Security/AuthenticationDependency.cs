using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace ManagementSystem.WebUI.Security;

public static class AuthenticationDependency
{
    public static IServiceCollection AddAuthenticationDependency(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddAuthentication(opt =>
        {
            opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(cfg =>
        {
            cfg.RequireHttpsMetadata = false;
            cfg.SaveToken = true;
            cfg.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidIssuer = configuration["JWT:ValidIssuer"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]!)),
                ValidAudience = configuration["JWT:ValidAudience"],
                // ValidateIssuer = false,
                // ValidateIssuerSigningKey = false,
                // ValidateAudience = false
            };
            cfg.IncludeErrorDetails = true;
        });
        return services;
    }
}