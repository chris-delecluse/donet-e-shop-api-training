using Business.Commands.Role;
using Business.Commands.User;
using Business.Interfaces;
using Business.Mappings;
using Business.Queries.User;
using Business.Services;
using Dal.Commands.Role;
using Dal.Commands.User;
using Dal.Database.Access;
using Dal.Entities;
using Dal.Queries.User;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Web_api.Extensions;

public static class AllServicesExtension
{
    public static IServiceCollection AddAllServices(this IServiceCollection service, IConfiguration configuration)
    {
        service.AddDbContext<AppDbContext>();

        service.RegisterIdentityService();
        service.RegisterAuthenticationService(configuration);

        service.AddMediatR(opt => opt.RegisterServicesFromAssembly(typeof(Program).Assembly));

        // services
        service.AddScoped<IUserService, UserService>();
        service.AddScoped<IAuthService, AuthService>();
        service.AddScoped<ITokenService, TokenService>();

        // cqrs commands
        service.AddScoped<IRequestHandler<CreateUserCommand, CreateUserCommandResult>, CreateUserCommandHandler>();
        service.AddScoped<IRequestHandler<CreateRoleCommand, IdentityResult>, CreateRoleCommandHandler>();

        // cqrs queries
        service.AddScoped<IRequestHandler<GetAllUsersQuery, IEnumerable<AppUser>>, GetAllUsersHandler>();
        service.AddScoped<IRequestHandler<GetUserByIdQuery, AppUser>, GetUserByIdHandler>();
        service.AddScoped<IRequestHandler<GetUserByEmailQuery, AppUser>, GetUserByEmailHandler>();
        service.AddScoped<IRequestHandler<GetUserRoleQuery, IEnumerable<string>>, GetUserRoleHandler>();

        // utilities
        service.AddScoped<IAppMapper, AppMapper>();

        return service;
    }
}
